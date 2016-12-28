using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ShopCars
{

    interface ISerializable
    {
        string Serialize(Vehicle vehicle);
    }

    class VehicleManager : ISerializable
    {
        public string Serialize(Vehicle vehicle)
        {
            string state = String.Format("name={0}", vehicle.Name);
            return state;
        }

        private string path;
        public void SaveCar(Vehicle vehicle)
        {
            StreamWriter file = new StreamWriter(this.path, true);
            string tempState = Serialize(vehicle);   
            file.WriteLine(tempState);    
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

            Hashtable carState = new Hashtable();
            carState["name"] = "Форд";
            carState["volumeEngine"] = 0.5;
            carState["cost"] = 1000;
            carState["pos.x"] = 10;
            carState["pos.y"] = 10;
            carState["model"] = "грузовой";
        }

        public VehicleManager(string path)
        {
            this.path = path;
        }
    }
}
