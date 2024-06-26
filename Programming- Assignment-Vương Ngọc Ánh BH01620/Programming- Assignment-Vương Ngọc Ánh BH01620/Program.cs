using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Programming__Assignment_Vương_Ngọc_Ánh_BH01620
{
    internal class Program
    {
        public static object VAT { get; private set; }
        static void Main(string[] args)
        {
            double enviroment;
            double totalBill = 0;
            string customerType = "";
            double numberOfpeople;
            int number;
            Console.WriteLine("Welcome to the Water Billing Program");
            Console.Write("Enter customer name: ");
            string customerName = Console.ReadLine();

            Console.Write("Enter last month's water meter readings: ");
            int lastMonth = int.Parse(Console.ReadLine());

            Console.Write("Enter this month's water meter readings: ");
            int thisMonth = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter number of people:");
            numberOfpeople = Convert.ToInt32(Console.ReadLine());
            while (numberOfpeople <= 0)
            {
                Console.WriteLine("The number of members must be greater than 0. Please enter the number of members again.");
                numberOfpeople = Convert.ToInt32(Console.ReadLine());
            }
                int consumption = thisMonth - lastMonth;
            while (lastMonth > thisMonth)
            {
                Console.WriteLine("The number of water last month is not greater than the number of water this month. Please try again.");
                Console.WriteLine("Last month's water meter readings:");
                lastMonth = int.Parse(Console.ReadLine());

                Console.WriteLine("This month's water meter readings:");
                thisMonth = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("-------------Enter type of customer:--------------------|");
            Console.WriteLine("|1. Household                                           |");
            Console.WriteLine("|2. Administrative agency, public services              |");
            Console.WriteLine("|3. Production units                                    |");
            Console.WriteLine("|4. Business services                                   |");
            Console.WriteLine("|_______________________________________________________|");
            //Kieu khach hang 
            Console.Write("Enter customer type (1-4): ");
            double price = 0;
           
            // Chuyển đổi từ chuỗi sang số nguyên
            int typeOfCustomer = int.Parse(Console.ReadLine());

            switch (typeOfCustomer)
            {
                    case 1 : 
                        customerType = "Household";
                        Console.WriteLine("Household ");
                        if (consumption <= 10)
                        {
                            price = 5.973;
                            enviroment = 597.30;
                        }
                        else if (consumption <= 20)
                        {
                            price = 7.052;
                            enviroment = 705.20;
                        }
                        else if (consumption <= 30)
                        {
                            price = 8.699;
                            enviroment = 866.90;
                        }
                        else
                        {
                            price = 15.929;
                            enviroment = 1592.90;
                        }
                      
                        break;

                    case 2: 
                        customerType = "Administrative agency, public services";
                        Console.WriteLine("Administrative agency, public services");
                        price = 9.955;
                        enviroment = 995.50;
                        break;

                    case 3: 
                        customerType = "Production units";
                        Console.WriteLine("Production units");
                        price = 11.615;
                        enviroment = 1161.50;
                        break;

                    case 4: 
                        customerType = "Business services";
                        Console.WriteLine("Business services");
                        price = 22.068;
                        enviroment = 2206.80;
                        break;

                    default:
                        Console.WriteLine("Error.");
                        return;
                }
                // In ra thong tin khach hang va tong bill.
                Console.WriteLine();
                Console.WriteLine("Customer Name:" + customerName);
                Console.WriteLine("Last Month's Water Meter Readings: " + lastMonth);
                Console.WriteLine("This Month's Water Meter Readings: " + thisMonth);
                Console.WriteLine("Amount of Consumption: " + consumption + " m3");

            double VAT = 0.1 * totalBill;
            double total = customerType == "Household" ? (consumption / numberOfpeople) * price : consumption * price;
            double AmountOfconsumption  = total * 0.1;
            double totalVAT = total * 0.1;
            double lBill = AmountOfconsumption + totalVAT + total;
            double waterBill = consumption + price + enviroment;

            Console.WriteLine("Water Bill:" + waterBill + "VND");
            Console.WriteLine("Environment Fee: " + AmountOfconsumption + " VND");
            Console.WriteLine("VAT " + totalVAT + "VND");
            Console.WriteLine("TOTAL BILL: " + lBill + " VND");
            Bill(customerName, lastMonth, thisMonth,totalVAT, lBill,waterBill, AmountOfconsumption );
        }
        static void Bill(string customerName, int lastMonth,int thisMonth , double totalVAT, double lBill,double waterBill,double AmountOfconsumption)
        { 
            double numberOfpeople;
            numberOfpeople = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("----------------------THE BILL------------------------");
            Console.WriteLine("Customer name:" + customerName);
            Console.WriteLine("Last month's water meter readings:" + lastMonth + "m3 ");
            Console.WriteLine("This month's water meter readings:" + thisMonth + "m3");
            Console.WriteLine("Water Bill:" + waterBill + "VND");
            Console.WriteLine("Environment Fee: " + AmountOfconsumption + " VND");
            Console.WriteLine("VAT " + totalVAT + "VND");
            Console.WriteLine("TOTAL BILL: " + lBill + "VND ");
            Console.ReadLine();
            return;
        }
    }
}
