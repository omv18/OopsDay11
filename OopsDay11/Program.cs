using OopsDay11.InventoryManagment;
using System;
namespace OopsDay11
{
    public class Program
    {
        static string file = @"D:\BridgeLabz\OopsDay11\OopsDay11\InventoryManagment\Inventory.json";
        static void Main(string[] args)
        {
            InventoryMang inventoryMang = new InventoryMang();
            inventoryMang.ReadJSonFile(file);
            
        }
    }
}