using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectShopCars
{
    class ModelCar // класс Модель автомобиля
    {
        private string nameModelCar;

        public string NameModelCar
        {
            set { this.nameModelCar = value; }
            get { return nameModelCar; }
        }
    }
    class Vehicle  // класс Средство передвижения
    {
        private string nameVehicle;
        private float volumeEngine; // Объём двигателя
        private int costVehicle;  // Цена

        public Vehicle(ModelCar modelCar, float volumeEngine, int costVehicle)  // Пользовательский конструктор
        {
            this.nameVehicle = modelCar.NameModelCar;
            this.volumeEngine = volumeEngine;
            this.costVehicle = costVehicle;
        }

        public string GetNameVehicle() //Прочитать Имя средства передвижения
        {
            return this.nameVehicle;
        }

        public float GetVolumeEngine() //Прочитать Объём двигателя
        {
            return this.volumeEngine;
        }

        public int GetCostVehicle() // Прочитать цену
        {
            return this.costVehicle;
        }
    }

    class ShopCars //Магазин автомобилей
    {
        private string nameShopCars;
        private string addressShopCars;

        public ShopCars(string nameShopCars, string addressShopCars)
        {
            this.nameShopCars = nameShopCars;
            this.addressShopCars = addressShopCars;
        }

        private Vehicle[] garage = new Vehicle[3]; // Cars --> garage   Создаём гараж из трёх мест под Средства передвижения
        private int countPlaces = 0; // Счётчик мест в гараже. Указатель на пустое место в гараже

        public void AddCar(Vehicle car)  // Добавить машину в гараж
        {
            if (countPlaces < garage.Length)
            {
                this.garage[this.countPlaces] = car; // В гараж помещаем машину
                this.countPlaces++;
                Console.WriteLine("Добавлена машина {0}", car.GetNameVehicle());
            }
            else { Console.WriteLine("Гараж полон. {0} не помещается в гараж", car.GetNameVehicle()); }
        }
        public void ShowAllCars() // Показать все машины
        {
            if (this.countPlaces > 0)
            {
                Console.WriteLine("В магазине {0} по адресу {1} в наличии следующие машины:", this.GetNameShop(), this.GetAddressShop());
                
                for (int i = 0; i < this.countPlaces; i++)
                {
                    Console.WriteLine(this.garage[i].GetNameVehicle());
                }
            }
            else { Console.WriteLine("Гараж пуст!"); }
        }

        public string GetNameShop() // Прочитать Название Магазина
        {
            return this.nameShopCars;
        }

        public string GetAddressShop() // Прочитать Адрес магазина
        {
            return this.addressShopCars;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ModelCar modelCar1 = new ModelCar();

            modelCar1.NameModelCar = "Фольксваген";
            Vehicle car1 = new Vehicle(modelCar1, 1.4f, 700000);

            modelCar1.NameModelCar = "Ауди";
            Vehicle car2 = new Vehicle(modelCar1, 1.6f, 900000);

            modelCar1.NameModelCar = "Форд";
            Vehicle car3 = new Vehicle(modelCar1, 2.3f, 1100000);

            modelCar1.NameModelCar = "Мерседес";
            Vehicle car4 = new Vehicle(modelCar1, 2.8f, 1600000);


            ShopCars ShopCars1 = new ShopCars("Мир Авто", "ул. Советская, д.32");
            ShopCars1.AddCar(car1);
            //ShopCars1.AddCar(car2);
            //ShopCars1.AddCar(car3);
            //ShopCars1.AddCar(car4);

            Console.WriteLine(new string('-', 30));
            ShopCars1.ShowAllCars();
        }
    }
}
