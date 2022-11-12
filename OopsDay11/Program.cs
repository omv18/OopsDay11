using OopsDay11.InventoryDataManagment;
using OopsDay11.InventoryManagment;
using System;
namespace OopsDay11
{
    public class Program
    {
        static string inventoryFile = @"D:\BridgeLabz\OopsDay11\OopsDay11\InventoryManagment\Inventory.json";
        static string inventoryFileData = @"D:\BridgeLabz\OopsDay11\OopsDay11\InventoryDataManagment\InventoryData.json";
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
                        inventoryDataMange.ReadJsonFile(inventoryFileData);
                        inventoryDataMange.Display();
                        break;
                    case 3:
                        inventoryDataMange.ReadJsonFile(inventoryFileData);
                        Console.Write("Enter Inventory Name to add(Rice, Wheat, Pulse) : ");
                        string addName = Console.ReadLine();
                        inventoryDataMange.AddInventoryData(addName);
                        inventoryDataMange.WriteJsonFile(inventoryFileData);
                        break;
                    default:
                        flag = false;
                        break;
                }
            }
        }
    }
}