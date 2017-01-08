using System;
using System.IO;
using System.Reflection;

namespace ShopCars
{
    class VehicleManager
    {
        
        private string path;
        public void SaveCar(Vehicle vehicle)   //
        {
            
                string tempState = vehicle.Serialize();

                if (System.IO.File.ReadAllText(path).IndexOf(tempState) == -1)
                {
                    using (StreamWriter file = new StreamWriter(this.path, true))
                    {
                    file.WriteLine(tempState);
                    }
                    Console.WriteLine("Состояние успешно сохранено");
                }
                else Console.WriteLine("Данное состояние средства передвижения было ранее сохранено");
        }

        public Vehicle LoadCarByName(string name)
        {
            string[] lines = System.IO.File.ReadAllLines(this.path);

            foreach (string line in lines)
            {
                int index = line.IndexOf(name);

                if (index != -1)
                {
                    if (line.StartsWith("ShopCars.Automobile"))
                    {
                        char[] separator = {':', '=', ';'};
                        string[] substring = line.Split(separator);
                        return new VehicleFactory(name, Convert.ToInt32(substring[6]), Convert.ToInt32(substring[8])).CreateAutomobile(name, substring[2], Convert.ToSingle(substring[12]), Convert.ToInt32(substring[4]));
                    }
                    if (line.StartsWith("ShopCars.Bicycle"))
                    {
                        char[] separator = { ':', '=', ';' };
                        string[] substring = line.Split(separator);
                        return new VehicleFactory(name, Convert.ToInt32(substring[10]), Convert.ToInt32(substring[4]), Convert.ToInt32(substring[6])).CreateBicycle(name, Convert.ToInt32(substring[10]), Convert.ToInt32(substring[2]));
                    }

                    return null;
                }
            }
            Console.WriteLine("Средства передвижения с данным именем не существует.");

            return null;
        }

        public VehicleManager(string path)
        {
            this.path = path;
        }
    }
}
