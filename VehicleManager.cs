using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ShopCars
{
    class VehicleManager
    {
        private string path;
        public void SaveCar(Vehicle vehicle)
        {
            using (StreamWriter file = new StreamWriter(this.path, true))
            {
                string tempState = vehicle.Serialize();
                file.WriteLine(tempState);
            }
        }

        public void LoadCarByName(string name)
        {
            //string[] lines = System.IO.File.ReadAllLines(this.path);

            //foreach (string line in lines)
            //{
            //    int index = line.IndexOf(name);

            //    if (index != -1)
            //    {

            //    }
            //    Console.WriteLine(line);
            //}


        }

        public VehicleManager(string path)
        {
            this.path = path;
        }
    }
}
