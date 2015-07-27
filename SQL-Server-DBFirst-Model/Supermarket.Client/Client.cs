using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supermarket.Data;

namespace Supermarket.Client
{
    public class Client
    {
        static void Main()
        {
            using (var context = new SupermarketContext())
            {
                var customers = context.Customers.Count();

                Console.WriteLine(customers);
            }

        }
    }
}