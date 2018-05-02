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
    public class FranchiseSerialization
    {
        private readonly string _path;

        public FranchiseSerialization(string path)
        {
            _path = path;
        }

        public List<Franchise> GetFranchisesXML()
        {
            FranchiseCollection f = null;
            XmlSerializer serializer = new XmlSerializer(typeof(FranchiseCollection));

            using (StreamReader reader = new StreamReader(_path))
            f = (FranchiseCollection)serializer.Deserialize(reader);

            return f.FranchiseCollectionList;
        }
    }

    [XmlRoot("FranchiseCollection")]
    public class FranchiseCollection
    {
        [XmlArray("Franchises")]
        [XmlArrayItem("Franchise", typeof(Franchise))]
        public List<Franchise> FranchiseCollectionList { get; set; }
    }
}
