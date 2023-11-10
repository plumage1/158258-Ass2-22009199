using Ass2.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using PagedList;
namespace Ass2.ViewModels
{
    public class CharacterIndexViewModel
    {
        //public IQueryable<Characters> Characters { get; set; }
    public IPagedList<Characters> Characters { get; set; }
    public string Search { get; set; }
    public IEnumerable<DestinyWithCount> DesWithCount { get; set; }
    public string Destiny { get; set; }
    public IEnumerable<SelectListItem> DesFilterItems
        {
            get
            {
                var allCats = DesWithCount.Select(cc => new SelectListItem
                {
                    Value = cc.DestinyName,
                    Text = cc.DesNameWithCount
                });
                return allCats;
            }
        }
    }
    public class DestinyWithCount
    {
        public int CharactersCount { get; set; }
        public string DestinyName { get; set; }
        public string DesNameWithCount
        {
            get
            {
                return DestinyName + " (" + CharactersCount.ToString() + ")";
            }
        }
    }
}