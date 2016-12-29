using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace ShopCars
{
    interface ISerializable
    {
        string Serialize();
    }

    interface IVehicleDrivable
    {
        bool DriveTo(IDirection direction); //Ехать К (Направление)
    }

    abstract class Vehicle : IVehicleDrivable, ISerializable // класс Средство передвижения
    {
        public string Name { get; set; } 
        public int Cost { get; protected set; }

        public Direction.GeographicalCoordinates myLocation { get; protected set; }

        public bool DriveTo(IDirection direction)
        {
            this.myLocation = direction.Location;
            Console.WriteLine("Приехали в {0}", direction.Name);

            return true;
        }

        public string Serialize()
        {
            Type type = this.GetType();
                        
            PropertyInfo[] properties = type.GetProperties();
            FieldInfo[] fields = type.GetFields();

            string shape = "";

            for (int i = 0; i < properties.Length; i++)
            {
                shape = shape + String.Format("{0}={1};", properties[i].Name, properties[i].GetValue(this));
            }

            for (int i = 0; i < fields.Length; i++)
            {
                shape = shape + String.Format("{0}={1};", fields[i].Name, fields[i].GetValue(this));
            }

            return shape;
        }

        public Vehicle(int longitude, int latitude)
        {
            this.myLocation = new Direction.GeographicalCoordinates(longitude, latitude);
        }

        public abstract void AllCharacteristics();
    }

    class Automobile : Vehicle // класс Автомобиль наследуется от Средства передвижения
    {
      //  public const string TRUCK_CAR = "грузовой";
       // public const string PASSENGER_CAR = "легковой";

        public enum CategoryCar : byte
        {
        TRUCK,
        PASSENGER
        }
      
        public CategoryCar Category { get; private set; } // Грузовой/легковой
        public float VolumeEngine { get; private set; } // Объём двигателя

        public Automobile(string name, CategoryCar category, float volumeEngine, int cost)
            : base(127, 465)
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

        public Bicycle(string name, int numberGears, int cost)
            : base(127, 465)
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

            if (category == Automobile.CategoryCar.TRUCK || category == Automobile.CategoryCar.PASSENGER)
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
