using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCars
{

    interface ISerializable
    {
        string Serialize(Automobile car);
    }

    class VehicleManager : ISerializable
    {
        public string Serialize(Automobile car)
        {
            string state = String.Format("name={0}", car.Name);
            return state;
        }

        private string path;
        public void SaveCar(Automobile car)
        {
            string tempState = Serialize(car);

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(this.path, true))
            {
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
