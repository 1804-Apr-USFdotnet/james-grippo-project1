using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using PZModels;

namespace ConsoleApp1
{
    public class ReviewSerialization
    {
        private readonly string _path;

        public ReviewSerialization(string path)
        {
            _path = path;
        }

        public List<Review> GetReviewsXML()
        {
            ReviewCollection f = null;
            XmlSerializer serializer = new XmlSerializer(typeof(ReviewCollection));

            using (StreamReader reader = new StreamReader(_path))
                f = (ReviewCollection)serializer.Deserialize(reader);

            return f.ReviewCollectionList;
        }
    }

    [XmlRoot("ReviewCollection")]
    public class ReviewCollection
    {
        [XmlArray("Reviews")]
        [XmlArrayItem("Review", typeof(Review))]
        public List<Review> ReviewCollectionList { get; set; }
    }
}
