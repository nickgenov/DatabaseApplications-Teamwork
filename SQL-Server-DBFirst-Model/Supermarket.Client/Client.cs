using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using Supermarket.Data;
using Supermarket.Data.Migrations;

namespace Supermarket.Client
{
    public class Client
    {
        private const string DatabaseHost = "mongodb://127.0.0.1";
        private const string DatabaseName = "Supermarket";
        private const string OutputDir = "../../Json-Reports/";

        static void Main()
        {
            //set database
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SupermarketContext, Configuration>());

            var context = new SupermarketContext();

            var count = context.Categories.Count();
            Console.WriteLine(count);

            //create reports for the sales of each product for given period in JSON format
            DateTime startDate = new DateTime(2015, 07, 15);
            DateTime endDate = new DateTime(2015, 07, 31);

            //var db = GetDatabase(DatabaseName, DatabaseHost);
            //var collection = db.GetCollection<string>("SalesByProductReports");

            JSONReports.GetSalesByPeriod(startDate, endDate);
            JSONReports.ExportSalesToJson(startDate, endDate);

        }


        public static MongoDatabase GetDatabase(string name, string host)
        {
            MongoClient mongoClient = new MongoClient(host);
            MongoServer server = mongoClient.GetServer();
            return server.GetDatabase(name);
        }

        private static void SalesJSONReport(DateTime startDate, DateTime endDate)
        {
            Directory.CreateDirectory(OutputDir);

            using (var context = new SupermarketContext())
            {

            }

        }
    }
}