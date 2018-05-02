using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Xml.Serialization;

namespace PZModels
{
    [Serializable()]
    public class Restaurant
    {
        [Key]
        [XmlElement("rIndex")]
        public int rIndex { get; set; }

        [XmlElement("FranchiseID")]
        public int FranchiseID { get; set; }

        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("City")]
        public string City { get; set; }

        [XmlElement("Zipcode")]
        public string Zipcode { get; set; }

        [XmlElement("State")]
        public string State { get; set; }

        [XmlElement("Address")]
        public string Address { get; set; }

        [XmlIgnore]
        public double? AvgRating  { get; set; }

        public override string ToString()
        {
            return
                $"\nindex: {rIndex}\nfIndex: {FranchiseID}\nname: {Name} \ncity: {City}\nZip: {Zipcode}\nstate: {State}\naddress: {Address}\naverage rating: {AvgRating}\n";
        }

        public void CalcAvgRating(IEnumerable<Review> reviews)
        {
            AvgRating = Math.Round(reviews.Select(x => x.Rating).Average(), 2);    
        }
    }
}
