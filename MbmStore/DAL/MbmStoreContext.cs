using MbmStore.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Diagnostics;

namespace MbmStore.DAL
{
    public class MbmStoreContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<MusicCD> MusicCDs { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Track> Tracks { get; set; }

        public MbmStoreContext() : base("MbmStoreContext")
        {
            Database.Log = sql => Debug.Write(sql);
            //Database.SetInitializer(new MbmStoreInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}