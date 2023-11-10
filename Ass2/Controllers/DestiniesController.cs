using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Ass2.Data;
using Ass2.Models;

namespace Ass2.Controllers
{
    public class DestiniesController : Controller
    {
        private Ass2Context db = new Ass2Context();

        // GET: Destinies
        public ActionResult Index()
        {
            return View(db.Destinies.OrderBy(c => c.Name).ToList());
        }

        // GET: Destinies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Destiny destiny = db.Destinies.Find(id);
            if (destiny == null)
            {
                return HttpNotFound();
            }
            return View(destiny);
        }

        // GET: Destinies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Destinies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Description")] Destiny destiny)
        {
            if (ModelState.IsValid)
            {
                db.Destinies.Add(destiny);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(destiny);
        }

        // GET: Destinies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Destiny destiny = db.Destinies.Find(id);
            if (destiny == null)
            {
                return HttpNotFound();
            }
            return View(destiny);
        }

        // POST: Destinies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Description")] Destiny destiny)
        {
            if (ModelState.IsValid)
            {
                db.Entry(destiny).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(destiny);
        }

        // GET: Destinies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Destiny destiny = db.Destinies.Find(id);
            if (destiny == null)
            {
                return HttpNotFound();
            }
            return View(destiny);
        }

        // POST: Destinies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Destiny destiny = db.Destinies.Find(id);
            db.Destinies.Remove(destiny);
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
