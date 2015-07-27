using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
//using MongoDB.Bson.IO;
using Supermarket.Data;
using Supermarket.Models;
using Newtonsoft.Json;

namespace Supermarket.Client
{
    class JSONReports
    {
        private const string DatabaseHost = "mongodb://127.0.0.1";
        private const string DatabaseName = "Supermarket";
        private const string OutputDir = "../../Json-Reports/";

        public static IEnumerable<Sale> GetSalesByPeriod(DateTime startDate, DateTime endDate)
        {
            using (var context = new SupermarketContext())
            {
                var salesByPeriod = context.Orders
                    .Where(o => o.Date >= startDate && o.Date <= endDate)
                    .GroupBy(o => new
                    {
                        o.ProductId,
                        ProductName = o.Product.Name,
                        VendorName = o.Product.Supplier.Name
                    })
                    .Select(p => new Sale
                    {
                        ProductId = p.Key.ProductId,
                        ProductName = p.Key.ProductName,
                        VendorName = p.Key.VendorName,
                        Quantity = (double)p.Sum(g => g.Quantity),
                        TotalIncomes = (double)p.Sum(g => g.Quantity * g.Product.Price)
                    })
                    .ToList();

                return salesByPeriod;
            }
        }

        public static void ExportSalesToJson(DateTime startDate, DateTime endDate)
        {
            Directory.CreateDirectory(OutputDir);
            var sales = GetSalesByPeriod(startDate, endDate);
            foreach (var sale in sales)
            {
                var json = JsonConvert.SerializeObject(sale, Newtonsoft.Json.Formatting.Indented);
                var path = OutputDir + sale.ProductId + ".json";
                File.WriteAllText(path, json);
            }
        }



    }
}
