using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using Ass2.Data;
using Ass2.Models;
using Ass2.ViewModels;
using PagedList;
namespace Ass2.Controllers
{
    public class CharactersController : Controller
    {
        private Ass2Context db = new Ass2Context();

        // GET: Characters
        public ActionResult Index(String destiny, string search, int? page)
        {
            CharacterIndexViewModel characterIndexViewModel = new CharacterIndexViewModel();
            var characters = db.Characters.Include(c => c.Destiny);
            if (!String.IsNullOrEmpty(search))
            {
               characters = characters.Where(p => p.Name.Contains(search) ||
               p.Description.Contains(search) ||
               p.Destiny.Name.Contains(search));
                characterIndexViewModel.Search = search;
            }
            characterIndexViewModel.DesWithCount = from matchingCharacters in characters
                                      where
                                      matchingCharacters.DestinyID != null
                                      group matchingCharacters by
                                      matchingCharacters.Destiny.Name into
                                      catGroup
                                      select new DestinyWithCount()
                                      {
                                          DestinyName = catGroup.Key,
                                          CharactersCount = catGroup.Count()
                                      };
            if (!String.IsNullOrEmpty(destiny))
            {
                characters = characters.Where(p => p.Destiny.Name == destiny);
                characterIndexViewModel.Destiny = destiny;
            }
            characters= characters.OrderBy(p => p.Name);
            const int PageItems = 5;
            int currentPage = (page ?? 1);
            characterIndexViewModel.Characters = characters.ToPagedList(currentPage, PageItems);
            return View(characterIndexViewModel);
        }

        // GET: Characters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Characters characters = db.Characters.Find(id);
            if (characters == null)
            {
                return HttpNotFound();
            }
            return View(characters);
        }

        // GET: Characters/Create
        public ActionResult Create()
        {
            ViewBag.DestinyID = new SelectList(db.Destinies, "ID", "Name");
            return View();
        }

        // POST: Characters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Description,DestinyID")] Characters characters)
        {
            if (ModelState.IsValid)
            {
                db.Characters.Add(characters);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DestinyID = new SelectList(db.Destinies, "ID", "Name", characters.DestinyID);
            return View(characters);
        }

        // GET: Characters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Characters characters = db.Characters.Find(id);
            if (characters == null)
            {
                return HttpNotFound();
            }
            ViewBag.DestinyID = new SelectList(db.Destinies, "ID", "Name", characters.DestinyID);
            return View(characters);
        }

        // POST: Characters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Description,DestinyID")] Characters characters)
        {
            if (ModelState.IsValid)
            {
                db.Entry(characters).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DestinyID = new SelectList(db.Destinies, "ID", "Name", characters.DestinyID);
            return View(characters);
        }

        // GET: Characters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Characters characters = db.Characters.Find(id);
            if (characters == null)
            {
                return HttpNotFound();
            }
            return View(characters);
        }

        // POST: Characters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Characters characters = db.Characters.Find(id);
            db.Characters.Remove(characters);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
