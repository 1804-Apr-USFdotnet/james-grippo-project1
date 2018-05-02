using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PZModels
{
    [Serializable()]
    public class Review
    {
        [Key]
        [XmlElement("revIndex")]
        public int revIndex { get; set; }
        [XmlElement("RestaurantID")]
        public int RestaurantID { get; set; }
        [XmlElement("Reviewer")]
        public string Reviewer { get; set; }
        [XmlElement("Description")]
        public string Description { get; set; }
        [XmlElement("Rating")]
        public int Rating { get; set; }

        public override string ToString()
        {
            return $"\nrevIndex: {revIndex}\nRestaurantID: {RestaurantID}\nReviewer: {Reviewer}\nReview: {Description}\nRating: {Rating}\n";
        }
    }
}
