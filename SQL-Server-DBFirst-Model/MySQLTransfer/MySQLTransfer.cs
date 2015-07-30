using Supermarket.Data;
using Supermarket.Models;

namespace DataToMySQL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using MySql.Data.Entity;
    using System.Data.Entity;

    using MySql.Data.MySqlClient;

    public class ToMySqlTransfer
    {
        static void Main()
        {
            var context = new SupermarketContext();
            var measures = context.Measures;
            var categories = context.Categories;
            var customers = context.Customers;
            var suppliers = context.Suppliers;
            var products = context.Products;
            var orders = context.Orders;

            String mySqlDataSource = @"server=localhost;database=supermarket;userid=root;";
            MySqlConnection connection = null;
            try
            {
                connection = new MySqlConnection(mySqlDataSource);
                connection.Open();

                //InsertMeasuresIntoDb(measures, connection);

                //InsertCategoriesIntoDb(categories, connection);

                //InsertCustomersIntoDb(customers, connection);

                //InsertSuppliersIntoDb(suppliers, connection);

                //InsertProductsIntoDb(products, connection);

                //InsertOrdersIntoDb(orders, connection);


                //String cmdText = "INSERT INTO measures(name) VALUES(@name)";
                //MySqlCommand cmd2 = new MySqlCommand(cmdText, connection);

                //cmd2.Prepare();
                //cmd2.Parameters.AddWithValue("@name", "345");
                //cmd2.ExecuteNonQuery();


                foreach (var measure in measures)
                {
                    Console.WriteLine(measure.Name);
                    var insertQuery = "INSERT INTO measures (name) VALUES (@name)";
                    MySqlCommand cmd = new MySqlCommand(insertQuery, connection);
                    cmd.Prepare();
                    cmd.Parameters.AddWithValue("@name", measure.Name);
                    cmd.ExecuteNonQuery();
                }



            }

            catch (MySqlException err)
            {
                Console.WriteLine("Error: " + err.ToString());
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close(); //close the connection
                }
            }
        }
        //public string ExportDataIntoMySql()
        //{
        //    var context = new SupermarketContext();
        //    var measures = context.Measures;
        //    var categories = context.Categories;
        //    var customers = context.Customers;
        //    var suppliers = context.Suppliers;
        //    var products = context.Products;
        //    var orders = context.Orders;

        //    const string mySqlDataSource = @"server=localhost;database=supermarket;userid=root;";
        //    var connection = new MySqlConnection(mySqlDataSource);
        //    connection.Open();
        //    using (connection)
        //    {
        //        InsertMeasuresIntoDb(measures, connection);

        //        InsertCategoriesIntoDb(categories, connection);

        //        InsertCustomersIntoDb(customers, connection);

        //        InsertSuppliersIntoDb(suppliers, connection);

        //        InsertProductsIntoDb(products, connection);

        //        InsertOrdersIntoDb(orders, connection);

        //    }

        //    return "Data exporting into MySql: Done!";
        //}

        private static void InsertOrdersIntoDb(IDbSet<Order> orders, MySqlConnection connection)
        {
            foreach (var order in orders)
            {
                var insertQuery =
                    "insert into orders (quantity, product_id, discount, customer_id, order_date) values (@quantity, @product_id, @discount, @customer_id, @order_date)";
                var cmd = new MySqlCommand(insertQuery, connection);
                cmd.Parameters.AddWithValue("@quantity", order.Quantity);
                cmd.Parameters.AddWithValue("@product_id", order.ProductId);
                cmd.Parameters.AddWithValue("@discount", order.Discount);
                cmd.Parameters.AddWithValue("@customer_id", order.CustomerId);
                cmd.Parameters.AddWithValue("@order_date", order.Date);
                cmd.ExecuteNonQuery();
            }
        }

        private static void InsertProductsIntoDb(IDbSet<Product> products, MySqlConnection connection)
        {
            foreach (var product in products)
            {
                var insertQuery =
                    "insert into products (name, price, supplier_id, category_id, measure_id) values (@name, @price, @supplier_id, @category_id, @measure_id)";
                var cmd = new MySqlCommand(insertQuery, connection);
                cmd.Parameters.AddWithValue("@name", product.Name);
                cmd.Parameters.AddWithValue("@price", product.Price);
                cmd.Parameters.AddWithValue("@supplier_id", product.SupplierId);
                cmd.Parameters.AddWithValue("@category_id", product.CategoryId);
                cmd.Parameters.AddWithValue("@measure_id", product.MeasureId);
                cmd.ExecuteNonQuery();
            }
        }

        private static void InsertSuppliersIntoDb(IDbSet<Supplier> suppliers, MySqlConnection connection)
        {
            foreach (var supplier in suppliers)
            {
                var insertQuery = "insert into suppliers (name, address, phone) values (@name, @address, @phone)";
                var cmd = new MySqlCommand(insertQuery, connection);
                cmd.Parameters.AddWithValue("@name", supplier.Name);
                cmd.Parameters.AddWithValue("@address", supplier.Address);
                cmd.Parameters.AddWithValue("@phone", supplier.Phone);
                cmd.ExecuteNonQuery();
            }
        }

        private static void InsertCustomersIntoDb(IDbSet<Customer> customers, MySqlConnection connection)
        {
            foreach (var customer in customers)
            {
                var insertQuery = "insert into customers (name, address, phone) values (@name, @address, @phone)";
                var cmd = new MySqlCommand(insertQuery, connection);
                cmd.Parameters.AddWithValue("@name", customer.Name);
                cmd.Parameters.AddWithValue("@address", customer.Address);
                cmd.Parameters.AddWithValue("@phone", customer.Phone);
                cmd.ExecuteNonQuery();
            }
        }

        private static void InsertCategoriesIntoDb(IDbSet<Category> categories, MySqlConnection connection)
        {
            foreach (var category in categories)
            {
                var insertQuery = "insert into categories (name, description) values (@name, @description)";
                var cmd = new MySqlCommand(insertQuery, connection);
                cmd.Parameters.AddWithValue("@name", category.Name);
                cmd.Parameters.AddWithValue("@supermarket", category.Description);
                cmd.ExecuteNonQuery();
            }
        }

        private static void InsertMeasuresIntoDb(IDbSet<Measure> measures, MySqlConnection connection)
        {
            foreach (var measure in measures)
            {
                var insertQuery = "insert into measures (name) values (@name)";
                var cmd = new MySqlCommand(insertQuery, connection);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@name", measure.Name);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
