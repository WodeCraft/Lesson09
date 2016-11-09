namespace MbmStore.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class ProductCreatedDateAttribute : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product", "CreatedDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2", defaultValueSql: "GETUTCDATE()"));
        }

        public override void Down()
        {
            DropColumn("dbo.Product", "CreatedDate");
        }
    }
}
