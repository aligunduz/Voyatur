namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asdfdgfsdf : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Images", "Product_Id", "dbo.Organisations");
            DropForeignKey("dbo.Images", "Product_Id", "dbo.Tours");
            DropForeignKey("dbo.Images", "Product_Id", "dbo.Ships");
            DropIndex("dbo.Images", new[] { "Product_Id" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Images", "Product_Id");
            AddForeignKey("dbo.Images", "Product_Id", "dbo.Ships", "Id");
            AddForeignKey("dbo.Images", "Product_Id", "dbo.Tours", "Id");
            AddForeignKey("dbo.Images", "Product_Id", "dbo.Organisations", "Id");
        }
    }
}
