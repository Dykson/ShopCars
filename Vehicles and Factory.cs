using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCars
{
    interface IVehicleDrivable
    {
        bool DriveTo(IDirection direction); //Ехать К (Направление)
    }

    abstract class Vehicle : IVehicleDrivable // класс Средство передвижения
    {
        public string Name { get; protected set; }
        protected IDirection myPosition;   //Моё положение 

        public bool DriveTo(IDirection direction)
        {
            this.myPosition = direction;
            Console.WriteLine("Приехали в {0}", this.myPosition.Name);

            return true;
        }

        public abstract void AllCharacteristics();
    }

    class Automobile : Vehicle // класс Автомобиль наследуется от Средства передвижения
    {
      //  public const string TRUCK_CAR = "грузовой";
       // public const string PASSENGER_CAR = "легковой";

        public enum CategoryCar : byte
        {
        TRUCK_CAR,
        PASSENGER_CAR
        }

        public CategoryCar Category { get; private set; } // Грузовой/легковой
        public float VolumeEngine { get; private set; } // Объём двигателя
        public int Cost { get; private set; }  // Цена

        public Automobile(string name, CategoryCar category, float volumeEngine, int cost)
        {
            this.Name = name;
            this.Category = category;
            this.VolumeEngine = volumeEngine;
            this.Cost = cost;
        }

        public override void AllCharacteristics()
        {
            Console.WriteLine("Характеристики:\nКатегория кузова - {0}\nОбъём двигателя - {1}\nЦена - {2}", this.Category, this.VolumeEngine, this.Cost);
        }
    }

    class Bicycle : Vehicle // класс Велосипед наследуется от Средства передвижения
    {
        public int NumberGears { get; private set; }  // Кол-во передач
        public int Cost { get; private set; }  // Цена

        public Bicycle(string name, int numberGears, int cost)
        {
            this.Name = name;
            this.NumberGears = numberGears;
            this.Cost = cost;
        }

        public override void AllCharacteristics()
        {
            Console.WriteLine("Характеристики:\nКоличество передач - {0}\nЦена - {1}", this.NumberGears, this.Cost);
        }
    }

    class VehicleFactory
    {
        public Vehicle CreateAutomobile(string name, Automobile.CategoryCar category, float volumeEngine, int cost)
        {

            if (category == Automobile.CategoryCar.TRUCK_CAR || category == Automobile.CategoryCar.PASSENGER_CAR)
            {
                return new Automobile(name, category, volumeEngine, cost);
            }

            Console.WriteLine("Данной категории автомобиля не существует.");

            return null;
        }
        public Vehicle CreateBicycle(string name, int numberGears, int cost)
        {

            if (numberGears > 0 && numberGears <= 7)
            {
                return new Bicycle(name, numberGears, cost);
            }

            Console.WriteLine("С таким количеством передач не смогу собрать велосипед");

            return null;
        }
    }
}
