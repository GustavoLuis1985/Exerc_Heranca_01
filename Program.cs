using HerancaPolimorfismo.Entities;
using System.Globalization;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;

namespace HerancaPolimorfismo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number of products: ");
            int n = int.Parse(Console.ReadLine());

            List<Product> list = new List<Product>();

            for(int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Product #{i} data:");
                Console.Write("Common, used or imported (c/u/i)? ");
                string p = Console.ReadLine();

                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Price: ");
                double price = double.Parse(Console.ReadLine());

                if(p == "i")
                {
                    Console.Write("Customs Fee: ");
                    double fee = double.Parse(Console.ReadLine());
                    list.Add(new ImportedProduct(name, price, fee));
                }

                else if(p == "u")
                {
                    Console.Write("Manufacture date (DD-MM-YYYY): ");
                    DateTime date = DateTime.ParseExact(Console.ReadLine(), "dd-MM-yyyy", CultureInfo.InvariantCulture);
                    list.Add(new UsedProduct(name, price, date));
                }

                else
                {
                    list.Add(new Product(name, price));
                }
            }

            Console.WriteLine("PRICE TAGS:");

            foreach(Product product in list)
            {
                Console.WriteLine(product.PriceTag());
            }
        }
    }
}