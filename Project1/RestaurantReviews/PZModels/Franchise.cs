using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public int fIndex { get; set; }

        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("Genre")]
        public string Genre { get; set; }

        public override string ToString() => $"\nfIndex: {fIndex}\nName: {Name}\nGenre: {Genre}\n";

    }
}
