using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Xml.Serialization;

namespace PZModels
{
    [Serializable()]
    public class Restaurant
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [XmlElement("rIndex")]
        public int RestaurantId { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(30, ErrorMessage = "Name cannot be longer than 30 characters.")]
        [XmlElement("Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "City is required.")]
        [StringLength(50, ErrorMessage = "City cannot be longer than 30 characters.")]
        [XmlElement("City")]
        public string City { get; set; }

        [Required(ErrorMessage = "Zipcode is required.")]
        [DataType(DataType.PostalCode, ErrorMessage = "Please enter a valid postal code.")]
        [XmlElement("Zipcode")]
        public string Zipcode { get; set; }

        [Required(ErrorMessage = "State is required.")]
        [StringLength(2, ErrorMessage = "State should be 2 characters.")]
        [XmlElement("State")]
        public string State { get; set; }

        [Required(ErrorMessage = "Street address is required.")]
        [StringLength(255, ErrorMessage = "Street address cannot be longer than 255 characters.")]
        [XmlElement("Street")]
        public string Street { get; set; }

        [XmlIgnore]
        [Range(1,10, ErrorMessage = "Rating must be between 1 and 10.")]
        public double? AvgRating  { get; set; }

        public int FranchiseId { get; set; }

        public virtual Franchise Franchise { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }

        public override string ToString()
        {
            return
                $"\nindex: {RestaurantId}\nfIndex: {FranchiseId}\nname: {Name} \ncity: {City}\nZip: {Zipcode}\nstate: {State}\naddress: {Street}\naverage rating: {AvgRating}\n";
        }

        public string Address()
        {
                return $" {Street}, {City}, {State}, {Zipcode}";
        }

        public void CalcAvgRating(IEnumerable<Review> reviews)
        {
            AvgRating = Math.Round(reviews.Select(x => x.Rating).Average(), 2);    
        }
    }
}
