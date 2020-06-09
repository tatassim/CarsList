using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AboutCars
{
    public enum transmitionKind { Автоматическая = 1, Механическая =2, Смешанная =3, Null = -1 };
    [Serializable]
    public class Car
    {
        
        private string brand;
        private string model;
        private int year_create;
        private double volume;
        private int run;
        private transmitionKind transmition;
        
        public string Brand
        {
            get
            {
                return brand;
            }
            set
            {
                if (value != "")
                {
                    brand = value;
                }
            }
        }
        public string Model
        {
            get
            {
                return model;
            }
            set
            {
                if (value != "")
                {
                    model = value;
                }
            }
        }

        public int Year_create
        {
            get
            {
                return year_create;
            }
            set
            {
                if (year_create >= 1900 && year_create <= 2020)
                {
                    year_create = value;
                }
            }
        }
        public double Volume
        {
            get
            {
                return volume;
            }
            set
            {
                if (volume > 0 && volume < 10)
                {
                    volume = value;
                }
            }
        }
        public int Run
        {
            get
            {
                return run;
            }
            set
            {
                if (run >= 0)
                {
                    run = value;
                }
            }
        }

        public transmitionKind Transmition
        {
            get
            {
                return transmition;
            }
            set
            {
                value = transmition;
            }
        }

        public Car()
        {
            Brand = "Default";
            Model = "Default";
            Year_create = 0;
            Volume = 0;
            Run = 0;
            Transmition = transmitionKind.Null;
        }

        public Car(string brand, string model, int year_create, double volume, int run, transmitionKind transmition)
        {
            this.brand = brand;
            this.model = model;
            this.year_create = year_create;
            this.volume = volume;
            this.run = run;
            this.transmition = transmition;
        }
       

        public override string ToString()
        {
            return String.Format("Марка: {0}, Модель: {1}, Год выпуска: {2} г., \n Объем двигателя: {3} литров, Пробег: {4} км, Тип коробки передач: {5} \n",
                Brand, Model, Year_create.ToString(), Volume.ToString(), Run.ToString(), Help.KindToString(Transmition));
        }
    }  
       
}
