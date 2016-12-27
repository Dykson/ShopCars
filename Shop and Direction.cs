using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace ShopCars
{
    interface IDirection // Направление
    {
        Direction.GeographicalCoordinates Location { get; set; } // Географическая координата
        string Name { get; set; } // Имя направления
    }

    class Direction : IDirection
    {
        public class GeographicalCoordinates
        {
            public int Longitude { get; set; } // долгота
            public int Latitude { get; set; } // широта

            public GeographicalCoordinates(int longitude, int latitude)
            {
                this.Longitude = longitude;
                this.Latitude = latitude;
            }
        }

        public GeographicalCoordinates Location { get; set; }
        public string Name { get; set; }

        public Direction(string name, int longitude, int latitude)          
        {
            this.Name = name;
            this.Location = new GeographicalCoordinates(longitude, latitude);
        }
    }

    class Shop : Direction //Магазин автомобилей
    {
        public string Address { get; set; }

        public Shop(string name, string address) // Магазин в Тамбове
            : base(name, 132, 467)
        {
            this.Address = address;
        }

        private Vehicle[] garage = new Vehicle[3]; // Создаём гараж из трёх мест под средства передвижения
        private int pointerPlace = 0; // Указатель на пустое место в гараже

        public void AddVehicle(Vehicle vehicle)  // Добавить средство передвижения в гараж
        {
            if (pointerPlace < garage.Length)
            {
                this.garage[this.pointerPlace] = vehicle; // В гараж помещаем средство передвижения
                this.pointerPlace++;
                Console.WriteLine("Добавлен {0}", vehicle.Name);
            }
            else { Console.WriteLine("Гараж полон. {0} не помещается в гараж", vehicle.Name); }
        }

        public void ShowAllVehicles() // Показать все Средства Передвижения
        {
            if (this.pointerPlace > 0)
            {
                Console.WriteLine("В магазине {0} по адресу {1} в наличии:\n", this.Name, this.Address);

                for (int i = 0; i < this.pointerPlace; i++)
                {
                    Console.WriteLine(this.garage[i].Name);
                }
            }
            else { Console.WriteLine("Гараж пуст!"); }
        }

        public Vehicle FindVehicle(string name) // Найти машину по имени
        {
            //string newName = name.ToLower();
            //char[] a = newName.ToCharArray();
            //a[0] = a.

            if (this.pointerPlace > 0)
            {
                bool searchStatus = false;
                for (int i = 0; i < this.pointerPlace; i++)
                {
                    if (this.garage[i].Name == name)
                    {
                        Console.WriteLine("В магазине присутствует {0}", this.garage[i].Name);
                        searchStatus = true;

                        return this.garage[i];
                    }
                }
                if (searchStatus == false)
                {
                    Console.WriteLine("Ничего не нашлось!");

                    return null;
                }
            }
            Console.WriteLine("Гараж пуст!!");

            return null;
        }

        public Vehicle ExtractVehicleByName(string name)
        {
            return this.FindVehicle(name);
        }
    }
}
