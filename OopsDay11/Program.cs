using OopsDay11.InventoryDataManagment;
using OopsDay11.InventoryManagment;
using System;
namespace OopsDay11
{
    public class Program
    {
        static string inventoryFile = @"D:\BridgeLabz\OopsDay11\OopsDay11\InventoryManagment\Inventory.json";
        static string inventoryFileileData = @"D:\BridgeLabz\OopsDay11\OopsDay11\InventoryDataManagment\InventoryData.json";
        static void Main(string[] args)
        {
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("Enter 1.Inventoey Managment 2.Inventory Data managment - Read and Display ");
                int option = Convert.ToInt32(Console.ReadLine());
                InventoryMang inventoryMang = new InventoryMang();
                InventoryDataMange inventoryDataMange = new InventoryDataMange();
                switch (option)
                {
                    case 1:
                        inventoryMang.ReadJSonFile(inventoryFile);
                        break;
                    case 2:
                        inventoryDataMange.ReadJsonFile(inventoryFileileData);
                        inventoryDataMange.Display();
                        break;
                    default:
                        flag = false;
                        break;
                }
            }
        }
    }
}