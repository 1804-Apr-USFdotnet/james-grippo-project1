using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [XmlElement("revIndex")]
        public int ReviewId { get; set; }

        [Required(ErrorMessage = "The name of the reviewer is required.")]
        [StringLength(50, ErrorMessage = "Name must be less then 50 characters.")]
        [XmlElement("Reviewer")]
        public string Reviewer { get; set; }

        [Required(ErrorMessage = "Comment is required.")]
        [StringLength(255, ErrorMessage = "Comment must be less than 255 characters.")]
        [XmlElement("Description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Rating is required.")]
        [Range(1,10, ErrorMessage = "Rating must be between 1 through 10.")]
        [XmlElement("Rating")]
        public int Rating { get; set; }

        public virtual Restaurant Restaurant { get; set; }

        public override string ToString()
        {
            return $"\nrevIndex: {ReviewId}\nReviewer: {Reviewer}\nReview: {Description}\nRating: {Rating}\n";
        }

        public string Details()
        {
            return $"{Reviewer}: {Rating}     \n {Description}";
        }
    }
}
