using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectShopCars
{
    class ModelCar // класс Модель автомобиля
    {
        private string name;

        public string Name
        {
            set { this.name = value; }
            get { return name; }
        }
    }
    class Vehicle  // класс Средство передвижения
    {
        private string name;
        private float volumeEngine; // Объём двигателя
        private int cost;  // Цена

        public Vehicle(ModelCar modelCar, float volumeEngine, int cost)  // Пользовательский конструктор
        {
            this.name = modelCar.Name;
            this.volumeEngine = volumeEngine;
            this.cost = cost;
        }

        public string GetName() //Прочитать Имя средства передвижения
        {
            return this.name;
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
            ModelCar modelCar1 = new ModelCar();

            modelCar1.Name = "Фольксваген";
            Vehicle car1 = new Vehicle(modelCar1, 1.4f, 700000);

            modelCar1.Name = "Ауди";
            Vehicle car2 = new Vehicle(modelCar1, 1.6f, 900000);

            modelCar1.Name = "Форд";
            Vehicle car3 = new Vehicle(modelCar1, 2.3f, 1100000);

            modelCar1.Name = "Мерседес";
            Vehicle car4 = new Vehicle(modelCar1, 2.8f, 1600000);


            Shop Shop1 = new Shop("Мир Авто", "ул. Советская, д.32");
            Shop1.AddCar(car1);
            //ShopCars1.AddCar(car2);
            //ShopCars1.AddCar(car3);
            //ShopCars1.AddCar(car4);

            Console.WriteLine(new string('-', 30));
            Shop1.ShowAllCars();
        }
    }
}
