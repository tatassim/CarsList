using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AboutCars
{
    class FileProcessor
    {
        string f;
        private readonly IFileManager manager;

        public FileProcessor(IFileManager manager)
        {
            this.manager = manager;
        }

        public void Print(List<Car> list)
        {
            manager.PrintToFile(list, f);
        }

        public List<Car> Load()
        {
            return manager.LoadFromFile(f);
        }

    }
}
