namespace MbmStore.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<MbmStore.DAL.MbmStoreContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MbmStore.DAL.MbmStoreContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            // Products 
            var products = new List<Product> {
                new Book {ProductId=1, Title="A Hard Day's Write: The Stories Behind Every Beatles Song ", Author="Steve Turner", Price=150.00M, Publisher="It Books", Published=2005, ISBN="978-0060844097", ImageUrl="A_Hard_Days_Write.jpg", Category="Book" },
                new Book { ProductId = 2, Title = "With a Little Help from My Friends: The Making of Sgt. Pepper", Author = "Georg Martin", Price = 180.00M, Publisher = "Little Brown & Co", Published = 1995, ISBN = "0316547832", ImageUrl = "The Making of Sgt. Pepper.jpg", Category = "Book" },
                new MusicCD { ProductId = 3, Title = "Abbey Road (Remastered)", Artist = "Beatles", Price = 128.00M, Released = 2009, Label = "EMI", ImageUrl = "abbey_road.jpg", Category = "Music",
                    Tracks = new List<Track> {
                        new Track { Title = "Come Together", Length = new TimeSpan(0, 4, 20), Composer = "Lennon, McCartney" },
                        new Track { Title = "Something", Length = new TimeSpan(0, 3, 03), Composer = "Harrison" },
                        new Track { Title = "Maxwell's Silver Hammer", Length = new TimeSpan(0, 3, 29), Composer = "Lennon, McCartney" },
                        new Track { Title = "Oh! Darling", Length = new TimeSpan(0, 3, 26), Composer = "Lennon, McCartney" },
                        new Track { Title = "Octopus's Garden", Length = new TimeSpan(0, 2, 51), Composer = "Starkey" },
                        new Track { Title = "I Want You (She's So Heavy)", Length = new TimeSpan(0, 7, 47), Composer = "Lennon, McCartney" },
                        new Track { Title = "Here Comes The Sun", Length = new TimeSpan(0, 3, 05), Composer = "Harrison" },
                        new Track { Title = "Because", Length = new TimeSpan(0, 2, 45), Composer = "Lennon, McCartney" },
                        new Track { Title = "You Never Give Me Your Money", Length = new TimeSpan(0, 4, 02), Composer = "Lennon, McCartney" },
                        new Track { Title = "Sun King", Length = new TimeSpan(0, 2, 26), Composer = "Lennon, McCartney" },
                        new Track { Title = "Mean Mr. Mustard", Length = new TimeSpan(0, 1, 6), Composer = "Lennon, McCartney" },
                        new Track { Title = "Polythene Pam", Length = new TimeSpan(0, 1, 12), Composer = "Lennon, McCartney" },
                        new Track { Title = "She Came In Through The Bathroom Window", Length = new TimeSpan(0, 1, 57), Composer = "Lennon, McCartney" },
                        new Track { Title = "Golden Slumbers", Length = new TimeSpan(0, 1, 31), Composer = "Lennon, McCartney" },
                        new Track { Title = "Carry That Weight", Length = new TimeSpan(0, 1, 36), Composer = "Lennon, McCartney" },
                        new Track { Title = "The End", Length = new TimeSpan(0, 2, 19), Composer = "Lennon, McCartney" },
                        new Track { Title = "Her Majesty", Length = new TimeSpan(0, 0, 23), Composer = "Lennon, McCartney" }
                    }
                },
                new MusicCD
                {
                    ProductId = 4,
                    Title = "Revolver (Remastered)",
                    Artist = "The Beatles",
                    Price = 128.00M,
                    Released = 2009,
                    Label = "EMI",
                    ImageUrl = "revolver.jpg",
                    Category = "Music",
                    Tracks = new List<Track> {
                        new Track {Title="Taxman", Length=new TimeSpan(0, 2, 28), Composer="Harrison"},
                        new Track {Title="Eleanor Rigby", Length=new TimeSpan(0, 2, 6), Composer="Lennon, McCartney"},
                        new Track {Title="I'm Only Sleeping", Length=new TimeSpan(0, 3, 0), Composer="Lennon, McCartney"},
                        new Track {Title="Love You To", Length=new TimeSpan(0, 2, 59), Composer="Harrison"},
                        new Track {Title="Here, There And Everywhere", Length=new TimeSpan(0, 2, 23), Composer="Harrison"},
                        new Track {Title="Yellow Submarine", Length=new TimeSpan(0, 2, 38), Composer="Lennon, McCartney"},
                        new Track {Title="She Said She Said", Length=new TimeSpan(0, 2, 36), Composer="Lennon, McCartney"},
                        new Track {Title="Good Day Sunshine", Length=new TimeSpan(0, 2, 9), Composer="Lennon, McCartney"},
                        new Track {Title="Doctor Robert", Length=new TimeSpan(0, 1, 14), Composer="Lennon, McCartney"},
                        new Track {Title="I Want To Tell You", Length=new TimeSpan(0, 2, 27), Composer="Harrison"},
                        new Track {Title="Got To Get You Into My Life", Length=new TimeSpan(0, 2, 29), Composer="Lennon, McCartney"},
                        new Track {Title="Tomorrow Newer Knows", Length=new TimeSpan(0, 3, 01), Composer="Lennon, McCartney"} }
                },
                new Movie { ProductId = 5, Title = "Jungle Book", Price = 160.50M, ImageUrl = "junglebook.jpg", Director = "Jon Favreau", Category = "Movie" },
                new Movie { ProductId = 6, Title = "Gladiator", Price = 49.95M, ImageUrl = "gladiator.jpg", Director = "Ridley Scott", Category = "Movie" },
                new Movie { ProductId = 7, Title = "Forrest Gump", Price = 160.50M, ImageUrl = "forrest-gump.jpg", Director = "Robert Zemeckis", Category = "Movie" }
            };

            // populate the database 
            products.ForEach(p => context.Products.AddOrUpdate(p));
            context.SaveChanges();

            // Customers 
            var customers = new List<Customer> {
                new Customer { CustomerId = 1, Firstname = "Tina", Lastname = "Petterson", Address = "Irisdahlsvej 32", Zip = "8200", City = "Århus N" },
                new Customer { CustomerId = 2, Firstname = "Thomas", Lastname = "Larsson", Address = "Solsikkevej 32", Zip = "8000", City = "Århus C" }
            };

            // populate the database 
            customers.ForEach(c => context.Customers.AddOrUpdate(c));
            context.SaveChanges();

            // populate the database 
            var invoices = new List<Invoice> {
                new Invoice {
                    InvoiceId = 1, OrderDate = new DateTime(2016, 09, 12), CustomerId = 1,
                    OrderItems = new List<OrderItem> {
                        new OrderItem { ProductId = 7, Quantity = 1 },
                        new OrderItem { ProductId = 2, Quantity = 1 }
                    }
                },
                new Invoice {
                    InvoiceId = 2, OrderDate = new DateTime(2016, 09, 18), CustomerId = 2,
                    OrderItems = new List<OrderItem> {
                        new OrderItem { OrderItemId = 1, ProductId = 1, Quantity = 1 },
                        new OrderItem { OrderItemId = 2, ProductId = 3, Quantity = 1 }
                    }
                }
            };
            invoices.ForEach(i => context.Invoices.AddOrUpdate(i));
            context.SaveChanges();
        }
    }
}
