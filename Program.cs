using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication12
{
    class ModelCar // класс Модель автомобиля
    {
        private string nameModel;

        public string NameModel
        {
            set { this.nameModel = value; }
            get { return nameModel; }
        }
    }
    class Vehicle  // класс Средство передвижения
    {
        private string nameVehicle;
        private float volumeEngine; // Объём двигателя
        private int cost;  // Цена

        public Vehicle(ModelCar modelCar, float volumeEngine, int cost)  // Пользовательский конструктор
        {
            this.nameVehicle = modelCar.NameModel;
            this.volumeEngine = volumeEngine;
            this.cost = cost;
        }

        public string getNameModel() //Прочитать Имя
        {
            return this.nameVehicle;
        }

        public float getVolumeEngine() //Прочитать Объём двигателя
        {
            return this.volumeEngine;
        }

        public int getCost() // Прочитать цену
        {
            return this.cost;
        }


    }

    class ShopCars //Магазин автомобилей
    {
        private string nameShop;
        private string addressShop;

        public ShopCars(string nameShop, string addressShop)
        {
            this.nameShop = nameShop;
            this.addressShop = addressShop;
        }

        private Vehicle[] garage = new Vehicle[3]; // (Cars --> garage   Создаём гараж из трёх мест под Средства передвижения)

        private int countPlaces = 0; // Счётчик мест в гараже. Указатель на пустое место в гараже

        public void ShowAllCars() // Показать все машины
        {
            Console.WriteLine("В магазине {0} по адресу {1} в наличии следующие машины:", this.getNameShop(), this.getAddressShop());
            for (int i = 0; i < garage.Length; i++)
            {
                Console.WriteLine(this.garage[i].getNameModel());
            }
        }

        public string getNameShop() // Прочитать Название Магазина
        {
           return this.nameShop;
        }

        public string getAddressShop() // Прочитать Адрес магазина
        {
            return this.addressShop;
        }
        public void AddCar(Vehicle car)  // Добавить машину в гараж
        {
            //countPlaces = 0;
            if (countPlaces < garage.Length)
            {
                this.garage[this.countPlaces] = car; // В гараж помещаем машину
                this.countPlaces++;
                Console.WriteLine("Добавлена машина {0}", car.getNameModel());
            }
            else { Console.WriteLine("Гараж полон. {0} не помещается в гараж", car.getNameModel()); }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ModelCar modelCar1 = new ModelCar();

            modelCar1.NameModel = "Фольксваген";
            Vehicle car1 = new Vehicle(modelCar1, 1.4f, 700000);

            modelCar1.NameModel = "Ауди";
            Vehicle car2 = new Vehicle(modelCar1, 1.6f, 900000);

            modelCar1.NameModel = "Форд";
            Vehicle car3 = new Vehicle(modelCar1, 2.3f, 1100000);

            modelCar1.NameModel = "Мерседес";
            Vehicle car4 = new Vehicle(modelCar1, 2.8f, 1600000);



            ShopCars ShopCars1 = new ShopCars("Мир Авто", "ул. Советская, д.32");
            ShopCars1.AddCar(car1);
            ShopCars1.AddCar(car2);
            ShopCars1.AddCar(car3);
            ShopCars1.AddCar(car4);

            Console.WriteLine(new string('-',30));
            ShopCars1.ShowAllCars();

        }
    }
}
