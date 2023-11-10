using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Ass2.Models
{
    public class Characters
    {
        public int ID {  get; set; }
        [Required(ErrorMessage = "The character name cannot be blank")]
        [Display(Name = "Character Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "The description cannot be blank")]
        public string Description { get; set; }
        public int DestinyID {  get; set; }
        public Destiny Destiny {  get; set; }
    }
}