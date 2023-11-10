using Antlr.Runtime;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Ass2.Models
{
    public class Destiny
    {
        public int ID { get; set; }
        [Display(Name = "Destiny Name")]
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Characters> Characters { get; set; }
    }
}