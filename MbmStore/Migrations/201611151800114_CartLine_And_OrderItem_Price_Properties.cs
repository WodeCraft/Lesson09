namespace MbmStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CartLine_And_OrderItem_Price_Properties : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderItem", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.OrderItem", "Price");
        }
    }
}
