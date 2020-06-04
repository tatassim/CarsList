using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace AboutCars
{
    class BinaryFile: IFileManager
    {
        public List<Car> LoadFromFile(string fileName)
        {
            using (FileStream f = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                BinaryFormatter bf = new BinaryFormatter();
                return (List<Car>)bf.Deserialize(f);
            } 
        }

        public void PrintToFile(List<Car> list, string fileName)
        {
            using (FileStream f = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(f, list);
                f.Close();
            }
            
        }
    }
}

