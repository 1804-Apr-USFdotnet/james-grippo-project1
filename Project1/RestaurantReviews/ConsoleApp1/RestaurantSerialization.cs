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
    public class RestaurantSerialization
    {
        private readonly string _path;

        public RestaurantSerialization(string path)
        {
            _path = path;
        }

        public List<Restaurant> GetRestaurantsXML()
        {
            RestaurantCollection f = null;
            XmlSerializer serializer = new XmlSerializer(typeof(RestaurantCollection));

            using (StreamReader reader = new StreamReader(_path))
                f = (RestaurantCollection)serializer.Deserialize(reader);

            return f.RestaurantCollectionList;
        }
    }

    [XmlRoot("RestaurantCollection")]
    public class RestaurantCollection
    {
        [XmlArray("Restaurants")]
        [XmlArrayItem("Restaurant", typeof(Restaurant))]
        public List<Restaurant> RestaurantCollectionList { get; set; }
    }
}
