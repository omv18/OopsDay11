using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OopsDay11.InventoryDataManagment;
using OopsDay11.InventoryManagment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OopsDay11.StockManagment
{
    internal class StockMangment
    {
        CustomerAccount customerAccount;
        StockAccount stockAccount;
        List<CustomerData> A_List;
        List<CustomerData> B_List;
        List<CustomerData> C_List;
        List<StockData> Amazon_List;
        List<StockData> IBM_List;
        List<StockData> Apple_List;

        public void ReadJsonFileCustomer(string file)
        {
            var jsonData = File.ReadAllText(file);
            customerAccount = JsonConvert.DeserializeObject<CustomerAccount>(jsonData);
            A_List = customerAccount.A;
            B_List = customerAccount.B;
            C_List = customerAccount.C;
        }

        public void ReadJsonFileStock(string file)
        {
            var jsonData = File.ReadAllText(file);
            stockAccount = JsonConvert.DeserializeObject<StockAccount>(jsonData);
            Amazon_List = stockAccount.Amazon;
            IBM_List = stockAccount.IBM;
            Apple_List = stockAccount.Apple;
        }


        public void SellComapny(string company, int num)
        {
            switch (company)
            {
                case "Amazon":
                    foreach (var item in Amazon_List)
                    {
                        item.NoOfShares -= num;
                    }
                    break;
                case "IBM":
                    foreach (var item in IBM_List)
                    {
                        item.NoOfShares -= num;
                    }
                    break;
                case "Apple":
                    foreach (var item in Apple_List)
                    {
                        item.NoOfShares -= num;
                    }
                    break;
            }
        }

        public void BuyComapny(string company, int num)
        {
            switch (company)
            {
                case "Amazon":
                    foreach (var item in Amazon_List)
                    {
                        item.NoOfShares += num;
                    }
                    break;
                case "IBM":
                    foreach (var item in IBM_List)
                    {
                        item.NoOfShares += num;
                    }
                    break;
                case "Apple":
                    foreach (var item in Apple_List)
                    {
                        item.NoOfShares += num;
                    }
                    break;
            }
        }
        public int NewBuyCustomer(string name, int amount, string fileCustomer, List<CustomerData> list)
        {
            int value = 0;
            CustomerData customerData = new CustomerData();
            switch (name)
            {
                case "Amazon":
                    customerData.Name = name;
                    int num = amount / 10;
                    value += num;
                    customerData.NoOfShares = num;
                    customerData.SharePerPrice = 10;
                    list.Add(customerData);
                    WriteJsonFileCustomer(fileCustomer);
                    break;

                case "IBM":
                    customerData.Name = name;
                    int num1 = amount / 20;
                    value += num1;
                    customerData.NoOfShares = num1;
                    customerData.SharePerPrice = 20;
                    list.Add(customerData);
                    WriteJsonFileCustomer(fileCustomer);
                    break;
                case "Apple":
                    customerData.Name = name;
                    int num2 = amount / 100;
                    value += num2;
                    customerData.NoOfShares = num2;
                    customerData.SharePerPrice = 100;
                    list.Add(customerData);
                    WriteJsonFileCustomer(fileCustomer);
                    break;
            }
            return value;
        }

        public int BuyCustomer(string option, int amount, string name, string fileCustomer)
        {
            int value = 0;
            bool flag = true;
            switch (option)
            {
                case "A":
                    foreach (var buy in A_List)
                    {
                        
                        if (buy.Name.Equals(name))
                        {
                            flag = false;
                            if (buy.SharePerPrice > amount) break;
                            if(amount >= buy.SharePerPrice)
                            {
                                int num = amount / buy.SharePerPrice;
                                buy.NoOfShares += num;
                                value += num;
                            }
                        }
                    }
                    if (flag)
                    {
                        value += NewBuyCustomer(name, amount, fileCustomer, A_List);
                    }
                    break;
                case "B":
                    foreach (var buy in B_List)
                    {
                        if (buy.Name.Equals(name))
                        {
                            flag = false;
                            if (buy.SharePerPrice > amount) break;
                            if (amount >= buy.SharePerPrice)
                            {
                                int num = amount / buy.SharePerPrice;
                                buy.NoOfShares += num;
                                value += num;
                            }
                        }
                    }
                    if (flag)
                    {
                        value += NewBuyCustomer(name, amount, fileCustomer, B_List);
                    }
                    break;
                case "C":
                    foreach (var buy in C_List)
                    {
                        if (buy.Name.Equals(name))
                        {
                            flag = false;
                            if (buy.SharePerPrice > amount) break;
                            if (amount >= buy.SharePerPrice)
                            {
                                int num = amount / buy.SharePerPrice;
                                buy.NoOfShares += num;
                                value += num;
                            }
                        }
                    }
                    if (flag)
                    {
                        value += NewBuyCustomer(name, amount, fileCustomer, C_List);
                    }
                    break;
            }
            return value;
        }

        public int SellCustomer(string option, int amount, string name)
        {
            int value = 0;
            switch (option)
            {
                case "A":
                    foreach (var buy in A_List)
                    {

                        if (buy.Name.Equals(name))
                        {
                            if (buy.SharePerPrice > amount) break;
                            if (amount >= buy.SharePerPrice)
                            {
                                int num = amount / buy.SharePerPrice;
                                buy.NoOfShares -= num;
                                value += num;
                            }
                        }
                    }
                    break;
                case "B":
                    foreach (var buy in B_List)
                    {
                        if (buy.Name.Equals(name))
                        {
                            if (buy.SharePerPrice > amount) break;
                            if (amount >= buy.SharePerPrice)
                            {
                                int num = amount / buy.SharePerPrice;
                                buy.NoOfShares -= num;
                                value += num;
                            }
                        }
                    }
                    break;
                case "C":
                    foreach (var buy in C_List)
                    {
                        if (buy.Name.Equals(name))
                        {
                            if (buy.SharePerPrice > amount) break;
                            if (amount >= buy.SharePerPrice)
                            {
                                int num = amount / buy.SharePerPrice;
                                buy.NoOfShares -= num;
                                value += num;
                            }
                        }
                    }
                    break;
            }
            return value;
        }


        public void Display(string file1, string file2)
        {
            ReadJsonFileCustomer(file1);
            Console.WriteLine("Coustomer Name : A ");
            ReadC(A_List);
            Console.WriteLine("Coustomer Name : B ");
            ReadC(B_List);
            Console.WriteLine("Coustomer Name : C ");
            ReadC(C_List);
            Console.WriteLine();
            ReadJsonFileStock(file2);
            Console.WriteLine("Company Name : Amazon ");
            ReadS(Amazon_List);
            Console.WriteLine("Company Name : IBM ");
            ReadS(IBM_List);
            Console.WriteLine("Company Name : Apple ");
            ReadS(Apple_List);
       }

        public void ReadS(List<StockData> customer)
        {
            foreach(var data in customer)
            {
                Console.WriteLine(data.Name + " "+data.NoOfShares+ " "+data.SharePerPrice);
            }
        }

        public void ReadC(List<CustomerData> customer)
        {
            foreach (var data in customer)
            {
                Console.WriteLine(data.Name + " " + data.NoOfShares + " " + data.SharePerPrice);
            }
        }

        public void WriteJsonFileCustomer(string file)
        {
            var json = JsonConvert.SerializeObject(customerAccount);
            File.WriteAllText(file, json);
        }
        public void WriteJsonFileStock(string file)
        {
            var json = JsonConvert.SerializeObject(stockAccount);
            File.WriteAllText(file, json);
        }
    }
}
