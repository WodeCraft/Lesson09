namespace MbmStore.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Product",
                c => new
                {
                    ProductId = c.Int(nullable: false, identity: true),
                    Title = c.String(),
                    Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    ImageUrl = c.String(),
                    Category = c.String(),
                })
                .PrimaryKey(t => t.ProductId);

            CreateTable(
                "dbo.Customer",
                c => new
                {
                    CustomerId = c.Int(nullable: false, identity: true),
                    Firstname = c.String(),
                    Lastname = c.String(),
                    Address = c.String(),
                    Zip = c.String(),
                    City = c.String(),
                    Email = c.String(),
                    Birthdate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                })
                .PrimaryKey(t => t.CustomerId);

            CreateTable(
                "dbo.Invoice",
                c => new
                {
                    InvoiceId = c.Int(nullable: false, identity: true),
                    CustomerId = c.Int(nullable: false),
                    OrderDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                })
                .PrimaryKey(t => t.InvoiceId)
                .ForeignKey("dbo.Customer", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);

            CreateTable(
                "dbo.OrderItem",
                c => new
                {
                    OrderItemId = c.Int(nullable: false, identity: true),
                    ProductId = c.Int(nullable: false),
                    Quantity = c.Int(nullable: false),
                    Invoice_InvoiceId = c.Int(),
                })
                .PrimaryKey(t => t.OrderItemId)
                .ForeignKey("dbo.Product", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Invoice", t => t.Invoice_InvoiceId)
                .Index(t => t.ProductId)
                .Index(t => t.Invoice_InvoiceId);

            CreateTable(
                "dbo.Track",
                c => new
                {
                    TrackId = c.Int(nullable: false, identity: true),
                    Title = c.String(),
                    Composer = c.String(),
                    Length = c.Time(nullable: false, precision: 7),
                    MusicCD_ProductId = c.Int(),
                })
                .PrimaryKey(t => t.TrackId)
                .ForeignKey("dbo.MusicCD", t => t.MusicCD_ProductId)
                .Index(t => t.MusicCD_ProductId);

            CreateTable(
                "dbo.Phone",
                c => new
                {
                    PhoneId = c.Int(nullable: false, identity: true),
                    Number = c.String(),
                    CustomerId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.PhoneId)
                .ForeignKey("dbo.Customer", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);

            CreateTable(
                "dbo.Book",
                c => new
                {
                    ProductId = c.Int(nullable: false),
                    Author = c.String(),
                    Publisher = c.String(),
                    Published = c.Short(nullable: false),
                    ISBN = c.String(),
                })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.Product", t => t.ProductId)
                .Index(t => t.ProductId);

            CreateTable(
                "dbo.Movie",
                c => new
                {
                    ProductId = c.Int(nullable: false),
                    Director = c.String(),
                })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.Product", t => t.ProductId)
                .Index(t => t.ProductId);

            CreateTable(
                "dbo.MusicCD",
                c => new
                {
                    ProductId = c.Int(nullable: false),
                    Artist = c.String(),
                    Label = c.String(),
                    Released = c.Short(nullable: false),
                })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.Product", t => t.ProductId)
                .Index(t => t.ProductId);

        }

        public override void Down()
        {
            DropForeignKey("dbo.MusicCD", "ProductId", "dbo.Product");
            DropForeignKey("dbo.Movie", "ProductId", "dbo.Product");
            DropForeignKey("dbo.Book", "ProductId", "dbo.Product");
            DropForeignKey("dbo.Phone", "CustomerId", "dbo.Customer");
            DropForeignKey("dbo.OrderItem", "Invoice_InvoiceId", "dbo.Invoice");
            DropForeignKey("dbo.OrderItem", "ProductId", "dbo.Product");
            DropForeignKey("dbo.Track", "MusicCD_ProductId", "dbo.MusicCD");
            DropForeignKey("dbo.Invoice", "CustomerId", "dbo.Customer");
            DropIndex("dbo.MusicCD", new[] { "ProductId" });
            DropIndex("dbo.Movie", new[] { "ProductId" });
            DropIndex("dbo.Book", new[] { "ProductId" });
            DropIndex("dbo.Phone", new[] { "CustomerId" });
            DropIndex("dbo.Track", new[] { "MusicCD_ProductId" });
            DropIndex("dbo.OrderItem", new[] { "Invoice_InvoiceId" });
            DropIndex("dbo.OrderItem", new[] { "ProductId" });
            DropIndex("dbo.Invoice", new[] { "CustomerId" });
            DropTable("dbo.MusicCD");
            DropTable("dbo.Movie");
            DropTable("dbo.Book");
            DropTable("dbo.Phone");
            DropTable("dbo.Track");
            DropTable("dbo.OrderItem");
            DropTable("dbo.Invoice");
            DropTable("dbo.Customer");
            DropTable("dbo.Product");
        }
    }
}
