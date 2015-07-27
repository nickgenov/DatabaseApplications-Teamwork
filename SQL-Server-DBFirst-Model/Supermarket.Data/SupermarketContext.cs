

using Supermarket.Models;

namespace Supermarket.Data
{
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using Supermarket.Data.Migrations;

    public class SupermarketContext : DbContext
    {
        public SupermarketContext()
            : base("SupermarketModel")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SupermarketContext, Configuration>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Measure> Measures { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
    }
}