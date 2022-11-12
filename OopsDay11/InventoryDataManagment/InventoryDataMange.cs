using Newtonsoft.Json;
using OopsDay11.InventoryManagment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopsDay11.InventoryDataManagment
{
    internal class InventoryDataMange
    {
        InventoryData inventoryData;
        List<Inventory> RiceList;
        List<Inventory> WheatList;
        List<Inventory> PulseList;
        
        public void ReadJsonFile(string file)
        {
            var jsonData = File.ReadAllText(file);
            inventoryData = JsonConvert.DeserializeObject<InventoryData>(jsonData);
            RiceList = inventoryData.Rice;
            WheatList = inventoryData.Wheat;
            PulseList = inventoryData.Pulse;
        }

        public void Display()
        {
            Read(RiceList);
            Read(WheatList);
            Read(PulseList);
        }
        public void Read(List<Inventory> inventories)
        {
            foreach (var data in inventories)
            {
                Console.WriteLine(data.Name + " " + data.Weight + " "+data.Price);
            }
            Console.WriteLine();
        }
    }
}
