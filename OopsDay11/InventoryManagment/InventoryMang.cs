using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopsDay11.InventoryManagment
{
    internal class InventoryMang
    {
        public void ReadJSonFile(string file)
        {
            var JsonData = File.ReadAllText(file);
            List<Inventory> inventories = JsonConvert.DeserializeObject<List<Inventory>>(JsonData);
            foreach(var data in inventories)
            {
                Console.WriteLine(data.Name + " \n "+ data.Weight +" \n " + data.Price);
            }
        }
    }
}
