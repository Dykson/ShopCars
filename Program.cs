using System;

namespace ShopCars
{
    class Point
    {
        int x;
        int y;

        public Point(int x, int y) 
        {
            this.x = x;
            this.y = y;
        }
    }

    interface IVehicleDrive
    {
        bool DriveTo(IDirection direction); //Ехать К (Направление)
    }

    interface IDirection // Направление
    {
        Point GetPoint(); // Прочитать Точку
        string GetName(); // Прочитать Имя
    }

    class Direction : IDirection
    {
        private string name;
        public string Name
        {
            set
            {
                this.name = value;
            }
            get
            {
                return this.name;
            }
        }


        private Point location = new Point(2, 4);

        public Point GetPoint()
        {
            return this.location;
        }

        public string GetName()
        {
            return this.name;
        }

        public Direction(string name)
        {
            this.name = name;
        }


    }

    class CarFactory
    {
        public Vehicle CreateCar(string category, string name, float volumeEngine, int cost)
        {

            if (category == ModelCar.TRUCK_CAR || category == ModelCar.PASSENGER_CAR)
            {
                ModelCar model = new ModelCar(category, name);
                Vehicle car1 = new Vehicle(model, volumeEngine, cost);

                return car1;
            }

            return null;
        }
    }
    class ModelCar // класс Модель автомобиля
    {
        public const string TRUCK_CAR = "грузовой";
        public const string PASSENGER_CAR = "легковой";

        private string name;
        private string category;

        public ModelCar(string category, string name)
        {
            this.category = category;
            this.name = name;
        }

        public string Name
        {
            get { return this.name; }
        }

        public string Category
        {
            get { return this.category; }
        }
    }
    class Vehicle : IVehicleDrive  // класс Средство передвижения
    {
        private ModelCar model;
        private float volumeEngine; // Объём двигателя
        private int cost;  // Цена
        private IDirection myPosition;   //Моё положение 

        public bool DriveTo(IDirection direction)
        {
            this.myPosition = direction;
            Console.WriteLine("Приехали в {0}", this.myPosition.GetName());

            return true;
        }

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

        public string GetCategory() //Прочитать категорию машины
        {
            return this.model.Category;
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

    class Shop : IDirection //Магазин автомобилей
    {
        private string name;
        private string address;

        public Shop(string name, string address)
        {
            this.name = name;
            this.address = address;
        }

        public Point GetPoint()
        {
            return null;
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
                Console.WriteLine("В магазине {0} по адресу {1} в наличии следующие машины:\n", this.GetName(), this.GetAddress());

                for (int i = 0; i < this.pointerPlace; i++)
                {
                    Console.WriteLine(this.garage[i].GetName());
                }
            }
            else { Console.WriteLine("Гараж пуст!"); }
        }

        public void FindCar(string name) // Найти машину по имени
        //Тест метода.
        //Возможные состояния: 
        //1 машина
        //2 и более машин с одинак. именем
        //Нет машин с таким именем
        //Гараж пуст
        {
            //string newName = name.ToLower();
            //char[] a = newName.ToCharArray();
            //a[0] = a.

       
            if (this.pointerPlace > 0)
            {
                bool searchStatus = false;
                for (int i = 0; i < this.pointerPlace; i++)
                {
                    if (this.garage[i].GetName() == name)
                    {
                        Console.WriteLine("В магазине присутствует {0} автомобиль {1} со следующими характеристиками:\nОбъём двигателя: {2} л\nЦена: {3} рублей", this.garage[i].GetCategory(), this.garage[i].GetName(), this.garage[i].GetVolumeEngine(), this.garage[i].GetCost());
                        searchStatus = true;
                    }
                }
                if (searchStatus == false)
                {
                    Console.WriteLine("Данной машины нет в наличии");
                }
            }
            else { Console.WriteLine("Гараж пуст!!"); }
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
            Console.WriteLine(new string('*', 60));
            Shop shop1 = new Shop("Мир Авто", "ул. Советская, д.32");

            CarFactory carFactory = new CarFactory();
            Vehicle vehicle1 = carFactory.CreateCar(ModelCar.TRUCK_CAR, "Фольксваген", 1.6f, 130000);
            Vehicle vehicle2 = carFactory.CreateCar(ModelCar.PASSENGER_CAR, "Форд", 1.8f, 190000);

            if (vehicle1 is Vehicle)
            {
                shop1.AddCar(vehicle1);
            }

            if (vehicle2 is Vehicle)
            {
                shop1.AddCar(vehicle2);
            }

            Console.WriteLine(new string('-', 60));

            shop1.ShowAllCars();
            Console.WriteLine(new string('-', 60));
            shop1.FindCar("Форд");

            Console.WriteLine(new string('-', 60));

            Direction direction1 = new Direction("город Тамбов");
            IDirection direction2 = shop1;
            Direction direction3 = new Direction("город Москва");


            vehicle1.DriveTo(direction1);
            vehicle1.DriveTo(direction2);
            vehicle1.DriveTo(direction3);

            direction1.GetPoint();

        }
    }
}
