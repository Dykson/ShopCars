using System;
using System.Collections;
using System.Collections.Specialized;

namespace ShopCars
{
    interface ISerializable // возможность сериализовывать, рассказывать своё текущее состояние одной строкой
    {
        string Serialize();
    }
    
    interface IDrivable // возможность двигаться к определённой локации
    {
        void DriveTo(ILocation location);
    }

    interface ILocation // Локация - собирательное понятие из точки на карте, имеющую координаты х и у, и названия точки
    {
        Location.Coordinates MyCoordinates { get; set; } // Точка на карте
        string Name { get; set; } // Имя точки
    }

    class Location : ILocation
    {
        public class Coordinates
        {
            public int X { get; private set; }
            public int Y { get; private set; }

            public Coordinates(int x, int y)
            {
                this.X = x;
                this.Y = y;
            }
        }

        public Coordinates MyCoordinates { get; set; }
        public virtual string Name { get; set; }

        public Location()
        {

        }

        public Location(string name, Coordinates coordinates)
        {
            this.Name = name;
            this.MyCoordinates = new Coordinates(coordinates.X, coordinates.Y);
        }
    }

    abstract class Vehicle : IDrivable, ISerializable, ILocation // класс Средство передвижения
    {
        public string Name { get; set; } 
        public int Cost { get; protected set; }

        public Location.Coordinates MyCoordinates { get; set; }

        public void DriveTo(ILocation location)
        {
            if (this.MyCoordinates == location.MyCoordinates)
            {
                Console.WriteLine("Сами к себе не можем приехать");
            }
            else
            {
                this.MyCoordinates = location.MyCoordinates;
                Console.WriteLine("Подъехали к {0}", location.Name);
            }
        } 

        public abstract void PrintAllCharacteristics();

        public abstract string Serialize();
    }

    class Automobile : Vehicle // класс Автомобиль наследуется от Средства передвижения
    {
        public static class Corpstype //Тип кузова, корпуса
        {
            private static readonly string[] corpsTypesDefault;

            static Corpstype()
            {
                corpsTypesDefault = System.IO.File.ReadAllLines("corpsTypesDefault.txt");
            }

            public static bool CheckCorpsTypesUser(string corpsTypeUser)
            {
                foreach (string corpsType in corpsTypesDefault)
                {
                    int index = corpsType.IndexOf(corpsTypeUser);
                    if (index != -1)
                    {
                        return true;
                    }
                }
                return false;
            }

            public static void ShowAllCorpsAuto()
            {
                foreach (string corpsType in corpsTypesDefault)
                {
                    Console.WriteLine(corpsType);
                }
            }
        }

        public string CorpsType { get; private set; } 
        public float VolumeEngine { get; private set; } // Объём двигателя

        public Automobile(string name, string corpsType, float volumeEngine, int cost, Location.Coordinates myCoordinates)
        {
            this.Name = name;
            this.CorpsType = corpsType;
            this.VolumeEngine = volumeEngine;
            this.Cost = cost;
            this.MyCoordinates = new Location.Coordinates(myCoordinates.X, myCoordinates.Y);
        }

        public override void PrintAllCharacteristics()
        {
            Console.WriteLine("Характеристики:\nТип кузова - {0}\nОбъём двигателя - {1}\nЦена - {2}", this.CorpsType, this.VolumeEngine, this.Cost);
        }

        public override string Serialize()
        {
            SortedList members = new SortedList();
            members["Name"] = this.Name;
            members["CorpsType"] = this.CorpsType;
            members["VolumeEngine"] = this.VolumeEngine;
            members["Cost"] = this.Cost;
            members["MyCoordinate.X"] = this.MyCoordinates.X;
            members["MyCoordinate.Y"] = this.MyCoordinates.Y;

            string shape = "";
            string vehicleId = "";

            for (int i = 0; i < members.Count; i++)
            {
                shape += string.Format("{0}={1};", members.GetKey(i), members[members.GetKey(i)]);
            }
            vehicleId = this.ToString() + "_" + shape.GetHashCode() + ":";

            return vehicleId + shape;
        }
    }

    class Bicycle : Vehicle // класс Велосипед наследуется от Средства передвижения
    {
        public int NumberGears { get; private set; }  // Кол-во передач

        public Bicycle(string name, int numberGears, int cost, Location.Coordinates myCoordinates)
        {
            this.Name = name;
            this.NumberGears = numberGears;
            this.Cost = cost;
            this.MyCoordinates = new Location.Coordinates(myCoordinates.X, myCoordinates.Y);
        }

        public override void PrintAllCharacteristics()
        {
            Console.WriteLine("Характеристики:\nКоличество передач - {0}\nЦена - {1}", this.NumberGears, this.Cost);
        }

        public override string Serialize()
        {
            SortedList members = new SortedList();
            members["Name"] = this.Name;
            members["NumberGears"] = this.NumberGears;
            members["Cost"] = this.Cost;
            members["MyCoordinate.X"] = this.MyCoordinates.X;
            members["MyCoordinate.Y"] = this.MyCoordinates.Y;

            string shape = "";
            string vehicleId = "";

            for (int i = 0; i < members.Count; i++)
            {
                shape += string.Format("{0}={1};", members.GetKey(i), members[members.GetKey(i)]);
            }
            vehicleId = this.ToString() + "_" + shape.GetHashCode() + ":";

            return vehicleId + shape;
        }
    }

    class VehicleFactory : Location
    {
        public readonly int maxNumberGears;

        public VehicleFactory(string name, int x, int y )
            : base(name, new Coordinates(x, y)) { }

        public VehicleFactory(string name, int maxNumberGears, int x, int y )
           : base(name, new Coordinates(x, y))
        {
            this.maxNumberGears = maxNumberGears;
        }
        public void ShowAllCorpsAuto() // Показать все возможные кузова автомобилей
        {
            Automobile.Corpstype.ShowAllCorpsAuto();
        }

        public Vehicle CreateAutomobile(string name, string corpsType, float volumeEngine, int cost)
        {
            if (corpsType == "")
            {
                Console.WriteLine("Автомобиль без кузова фабрика не будет изготавливать.");
                return null;
            }

            if (Automobile.Corpstype.CheckCorpsTypesUser(corpsType))
            {
                Console.WriteLine("{0} успешно изготовлен", name);
                return new Automobile(name, corpsType, volumeEngine, cost, this.MyCoordinates);
            }
            Console.WriteLine("Автомобиль с данным типом кузова фабрика не может изготовить.");

            return null;
        }
        public Vehicle CreateBicycle(string name, int numberGears, int cost)
        {

            if (numberGears > 0 && numberGears <= this.maxNumberGears)
            {
                Console.WriteLine("{0} успешно изготовлен", name);
                return new Bicycle(name, numberGears, cost, this.MyCoordinates);
            }

            Console.WriteLine("С таким количеством передач не смогу собрать велосипед");

            return null;
        }
    }
}
