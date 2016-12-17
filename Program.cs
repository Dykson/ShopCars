using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectShopCars
{
    class CarFactory
    {
        public Vehicle CreateCar(string type, string name, float volumeEngine, int cost)
        {

            if (type == ModelCar.TRUCK_CAR || type == ModelCar.PASSENGER_CAR)
            {
                ModelCar model = new ModelCar(type, name);
                Vehicle car1 = new Vehicle(model, volumeEngine, cost);

                return car1;
            }

            return null;
        }
    }
    class ModelCar // класс Модель автомобиля
    {
        public const string TRUCK_CAR = "Truck";
        public const string PASSENGER_CAR = "Passenger";

        private string name;
        private string type;

        public ModelCar(string type, string name)
        {
            this.type = type;
            this.name = name;
        }

        public string Name
        {
            set { this.name = value; }
            get { return name; }
        }
    }
    class Vehicle  // класс Средство передвижения
    {
        private ModelCar model;
        private float volumeEngine; // Объём двигателя
        private int cost;  // Цена

        public Vehicle(ModelCar modelCar, float volumeEngine, int cost)  // Пользовательский конструктор
        {
            this.model = modelCar;
            this.volumeEngine = volumeEngine;
            this.cost = cost;
        }

        public string GetName() //Прочитать Имя средства передвижения
        {
            return this.model.Name;
        }

        public float GetVolumeEngine() //Прочитать Объём двигателя
        {
            return this.volumeEngine;
        }

        public int GetCost() // Прочитать цену
        {
            return this.cost;
        }
    }

    class Shop //Магазин автомобилей
    {
        private string name;
        private string address;

        public Shop(string name, string address)
        {
            this.name = name;
            this.address = address;
        }

        private Vehicle[] garage = new Vehicle[3]; // Создаём гараж из трёх мест под Средства передвижения
        private int pointerPlace = 0; // Указатель на пустое место в гараже

        public void AddCar(Vehicle car)  // Добавить машину в гараж
        {
            if (pointerPlace < garage.Length)
            {
                this.garage[this.pointerPlace] = car; // В гараж помещаем машину
                this.pointerPlace++;
                Console.WriteLine("Добавлена машина {0}", car.GetName());
            }
            else { Console.WriteLine("Гараж полон. {0} не помещается в гараж", car.GetName()); }
        }
        public void ShowAllCars() // Показать все машины
        {
            if (this.pointerPlace > 0)
            {
                Console.WriteLine("В магазине {0} по адресу {1} в наличии следующие машины:", this.GetName(), this.GetAddress());
                
                for (int i = 0; i < this.pointerPlace; i++)
                {
                    Console.WriteLine(this.garage[i].GetName());
                }
            }
            else { Console.WriteLine("Гараж пуст!"); }
        }

        public string GetName() // Прочитать Название Магазина
        {
            return this.name;
        }

        public string GetAddress() // Прочитать Адрес магазина
        {
            return this.address;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Shop shop1 = new Shop("Мир Авто", "ул. Советская, д.32");

            CarFactory carFactory = new CarFactory();
            Vehicle vehicle1 = carFactory.CreateCar(ModelCar.TRUCK_CAR, "Фольксваген", 1.6f, 130000);

            if (vehicle1 is Vehicle)
            {
                shop1.AddCar(vehicle1);                
            }

            Console.WriteLine(new string('-', 30));
            shop1.ShowAllCars();
        }
    }
}
