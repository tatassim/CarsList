using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AboutCars
{
    public interface IFileManager
    {
        void PrintToFile(List<Car> list, string fileName);
        List<Car> LoadFromFile(string fileName);
    }
}
