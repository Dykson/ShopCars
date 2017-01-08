using System;

namespace ShopCars
{
    class Program
    {
        static void Main(string[] args)
        {
            VehicleFactory factory = new VehicleFactory("Завод транспорта", 30, 100, 200); 
                // строим фабрику, задаём максимальное число передач для изготовления велосипедов
                // и положение в пространстве по умолчанию для будущих средств передвижения
                factory.ShowAllCorpsAuto();

            Vehicle car1 = factory.CreateAutomobile("Фольксваген", "седан", 1.6f, 140000);
            Vehicle car2 = factory.CreateAutomobile("Форд", "лимузин", 1.8f, 190500);
            Vehicle bicycle1 = factory.CreateBicycle("Мерида", 5, 25000); 

            Shop shop1 = new Shop("Магазин Транспорта", "ул. Советская, д.32", 120, 210);
                if (car1 != null) { shop1.AddVehicle(car1); }
                if (car2 != null) { shop1.AddVehicle(car2); }
                if (bicycle1 != null) { shop1.AddVehicle(bicycle1); }

                shop1.ShowAllVehicles();
                shop1.FindVehicle("Форд");

            Vehicle car3 = shop1.ExtractVehicleByName("Форд");
                if (car3 != null) { car3.PrintAllCharacteristics(); }

            Location locationA = new Location("Воронеж", new Location.Coordinates(132, 467));
                car1.DriveTo(locationA);
                car1.DriveTo(shop1);
                car1.DriveTo(car1);
                car1.DriveTo(car2);
                car1.DriveTo(factory);

            VehicleManager vehicleManager = new VehicleManager("serialization.txt");
                vehicleManager.SaveCar(bicycle1);
                Vehicle car4 = vehicleManager.LoadCarByName("Форд");
        }
    }
}