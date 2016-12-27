using System;
using System.Collections;

namespace ShopCars
{
    class Program
    {
        static void Main(string[] args)
        {
            Shop shop1 = new Shop("Мир Авто", "ул. Советская, д.32");

            VehicleFactory factory = new VehicleFactory();

            Vehicle car1 = factory.CreateVehicle("Фольксваген", Automobile.TRUCK_CAR, 1.6f, 130000);
            Vehicle car2 = factory.CreateVehicle("Форд", Automobile.PASSENGER_CAR, 1.8f, 190000);
            Vehicle bicycle1 = factory.CreateVehicle("Мерида", 4, 25000);

            if (car1 is Vehicle)
            {
                shop1.AddVehicle(car1);
            }

            if (car2 is Vehicle)
            {
                shop1.AddVehicle(car2);
            }

            if (bicycle1 is Vehicle)
            {
                shop1.AddVehicle(bicycle1);
            }

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

            Vehicle car3 = shop1.ExtractVehicleByName("Мерида");
            car3.AllCharacteristics();

            //if (car3 is IVehicleDrivable)
            //{
            //    CarManager carManager = new CarManager("D:/test3.txt");
            //    carManager.SaveCar(car3);
            //    //carManager.LoadCarByName("");
            //}
        }
    }
}