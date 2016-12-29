using System;
using System.Collections;
using System.Reflection;

namespace ShopCars
{
    class Program
    {
        static void Main(string[] args)
        {
            Shop shop1 = new Shop("Мир Транспорта", "ул. Советская, д.32");

            VehicleFactory factory = new VehicleFactory();

            Vehicle car1 = factory.CreateAutomobile("Фольксваген", Automobile.CategoryCar.PASSENGER, 1.6f, 130000); //на выходе объект типа Automobile
            Vehicle car2 = factory.CreateAutomobile("Форд", Automobile.CategoryCar.TRUCK, 1.8f, 190000);
            Vehicle bicycle1 = factory.CreateBicycle("Мерида", 4, 25000); //на выходе объект типа BiCycle - апкаст

            shop1.AddVehicle(car1);
            shop1.AddVehicle(car2);
            shop1.AddVehicle(bicycle1);


            Console.WriteLine(new string('-', 60));

            shop1.ShowAllVehicles();

            Console.WriteLine(new string('-', 60));

            shop1.FindVehicle("Форд");

            Console.WriteLine(new string('-', 60));

            Direction directionA = new Direction("город Воронеж", 132, 467);
            Direction directionB = new Direction("город Москва", 140, 672);


            car1.DriveTo(directionA);
            car1.DriveTo(shop1);
            car1.DriveTo(directionB);

            Console.WriteLine(new string('-', 60));

            Vehicle car3 = shop1.ExtractVehicleByName("Форд");
            car3.AllCharacteristics();

            if (car3 is IVehicleDrivable)
            {
                VehicleManager vehicleManager = new VehicleManager("C:/test1.txt");
                vehicleManager.SaveCar(car3);
                //carManager.LoadCarByName("");
            }
        }
    }
}