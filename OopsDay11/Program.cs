using OopsDay11.InventoryDataManagment;
using OopsDay11.InventoryManagment;
using OopsDay11.StockManagment;
using System;
namespace OopsDay11
{
    public class Program
    {
        static string inventoryFile = @"D:\BridgeLabz\OopsDay11\OopsDay11\InventoryManagment\Inventory.json";
        static string inventoryFileData = @"D:\BridgeLabz\OopsDay11\OopsDay11\InventoryDataManagment\InventoryData.json";
        static string fileStock = @"D:\BridgeLabz\OopsDay11\OopsDay11\StockManagment\StockAccount.json";
        static string fileCustomer = @"D:\BridgeLabz\OopsDay11\OopsDay11\StockManagment\CustomerAccount.json";
        static void Main(string[] args)
        {
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("Enter 1.Inventoey Managment 2.Inventory Data managment(IDM) - Read and Display 3.IDM - ADD \n 4. IDM - Edit 5.IDM-Delte 6.IDM - ALL DELETE" +
                    "\n 7.Display Stock and Customer info 8.Buy Customer Share");
                int option = Convert.ToInt32(Console.ReadLine());
                InventoryMang inventoryMang = new InventoryMang();
                InventoryDataMange inventoryDataMange = new InventoryDataMange();
                StockMangment stockMangment = new StockMangment();
                switch (option)
                {
                    case 1:
                        inventoryMang.ReadJSonFile(inventoryFile);
                        break;
                    case 2:
                        inventoryDataMange.Dislay(inventoryFileData);
                        break;
                    case 3:
                        inventoryDataMange.ReadJsonFile(inventoryFileData);
                        Console.Write("Enter Inventory Name to add(Rice, Wheat, Pulse) : ");
                        string addName = Console.ReadLine();
                        inventoryDataMange.AddInventoryData(addName);
                        inventoryDataMange.WriteJsonFile(inventoryFileData);
                        break;
                    case 4:
                        inventoryDataMange.ReadJsonFile(inventoryFileData);
                        Console.Write("Enter Inventory Name to edit(Rice, Wheat, Pulse) : ");
                        string editName = Console.ReadLine();
                        inventoryDataMange.EditInventoryData(editName);
                        inventoryDataMange.WriteJsonFile(inventoryFileData);
                        break;
                    case 5:
                        inventoryDataMange.ReadJsonFile(inventoryFileData);
                        Console.Write("Enter Inventory Name to delte(Rice, Wheat, Pulse) : ");
                        string deleteName = Console.ReadLine();
                        inventoryDataMange.DeleteInventoryData(deleteName);
                        inventoryDataMange.WriteJsonFile(inventoryFileData);
                        break;
                    case 6:
                        inventoryDataMange.ReadJsonFile(inventoryFileData);
                        Console.Write("Enter Inventory Name to all delte(Rice, Wheat, Pulse) : ");
                        string deleteAll = Console.ReadLine();
                        inventoryDataMange.AllDelteInventoryData(deleteAll);
                        inventoryDataMange.WriteJsonFile(inventoryFileData);
                        break;
                    case 7:
                        stockMangment.Display(fileCustomer, fileStock);
                        break;
                    case 8:
                        stockMangment.ReadJsonFileCustomer(fileCustomer);
                        Console.Write("Enter Customer name : ");
                        string customer = Console.ReadLine();   
                        Console.Write("Enter company name : ");
                        string company = Console.ReadLine();
                        int check = stockMangment.BuyCustomer(customer, 100, company, fileCustomer);
                        stockMangment.WriteJsonFileCustomer(fileCustomer);
                        if (check > 0)
                        {
                            stockMangment.ReadJsonFileStock(fileStock);
                            stockMangment.SellComapny(company, check);
                            stockMangment.WriteJsonFileStock(fileStock);
                        }
                        break;
                    default:
                        flag = false;
                        break;
                }
            }
        }
    }
}



//{"Amazon":[{"Name":"Amazon","NoOfShares":1004,"SharePerPrice":10}],"IBM":[{"Name":"IBM","NoOfShares":400,"SharePerPrice":20}],"Apple":[{"Name":"Apple","NoOfShares":600,"SharePerPrice":100}]}