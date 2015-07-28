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
        
        static void Main()
        {
            //set database
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SupermarketContext, Configuration>());

            var context = new SupermarketContext();

            var count = context.Categories.Count();
            Console.WriteLine(count);

            //set period to get sales by it
            DateTime startDate = new DateTime(2015, 07, 15);
            DateTime endDate = new DateTime(2015, 07, 31);

            //export SQL data about sales by given period in JSON format
            JSONReports.ExportSalesToJson(startDate, endDate);

            //import data about requested sales in MongoDB
            MongoDBImport.MongoDbImportData(startDate, endDate);

        }


        

        
    }
}