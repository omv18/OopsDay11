using Newtonsoft.Json;
using OopsDay11.InventoryDataManagment;
using OopsDay11.InventoryManagment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopsDay11.StockManagment
{
    internal class StockMangment
    {
        CustomerAccountList customerAccountList;
        List<CustomerAccount> A_List;
        List<CustomerAccount> B_List;
        List<CustomerAccount> C_List;

        public void ReadJsonFileAccount(string file)
        {
            var jsonData = File.ReadAllText(file);
            customerAccountList = JsonConvert.DeserializeObject<CustomerAccountList>(jsonData);
            A_List = customerAccountList.A;
            B_List = customerAccountList.B;
            C_List = customerAccountList.C;
        }
        public void ReadJSonFile(string file)
        {
            var JsonData = File.ReadAllText(file);
            List<CustomerAccount> inventories = JsonConvert.DeserializeObject<List<CustomerAccount>>(JsonData);
            foreach (var data in inventories)
            {
                Console.WriteLine(data.Name + "  " + data.NoOfShares + "  " + data.SharePerPrice);
            }
        }

        public void Display(string file,string file1)
        {
            ReadJsonFileAccount(file);
            Read(A_List);
            Read(B_List);
            Read(C_List);
            Console.WriteLine();
            ReadJSonFile(file1);
        }

        public void Read(List<CustomerAccount> customer)
        {
            foreach(var data in customer)
            {
                Console.WriteLine(data.Name + " "+data.NoOfShares+ " "+data.SharePerPrice);
            }
        }
    }
}
