using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace AboutCars
{
    class XmlFIle : IFileManager
    {
        public List<Car> LoadFromFile(string fileName)
        {  
            using (XmlReader reader = XmlReader.Create(fileName))
            {
                XmlSerializer s = new XmlSerializer(typeof(List<Car>));
                return (List<Car>)s.Deserialize(reader);
            }   
        }

        public void PrintToFile(List<Car> list, string fileName)
        {
            using (XmlWriter writer = XmlWriter.Create(fileName))
            {
                XmlSerializer s = new XmlSerializer(typeof(List<Car>));
                s.Serialize(writer, list);
                writer.Close();
            }
            
        }
    }
}