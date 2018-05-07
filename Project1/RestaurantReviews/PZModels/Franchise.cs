using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.Data.Entity;

namespace PZModels
{
    [Serializable()]
    public class Franchise
    {
        [Key]
        [XmlElement("fIndex")]
        public int FranchiseId { get; set; }

        [Index(IsUnique = true)]
        [StringLength(50,ErrorMessage = "Franchise name must be less than 50 characters.")]
        [XmlElement("Name")]
        public string Name { get; set; }

        [StringLength(50,ErrorMessage = "Genre must be less than 50 Characters.")]
        [XmlElement("Genre")]
        public string Genre { get; set; }

        //public virtual ICollection<Restaurant> Restaurants { get; set; }

        public override string ToString() => $"Name: {Name}\nGenre: {Genre}\n";

    }
}
