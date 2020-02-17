namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asdffg : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsMain = c.Boolean(nullable: false),
                        Product_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Organisations", t => t.Product_Id)
                .ForeignKey("dbo.Tours", t => t.Product_Id)
                .ForeignKey("dbo.Ships", t => t.Product_Id)
                .Index(t => t.Product_Id);
            
            DropColumn("dbo.Organisations", "ImagePath");
            DropColumn("dbo.Ships", "ImagePath");
            DropColumn("dbo.Tours", "ImagePath");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tours", "ImagePath", c => c.String());
            AddColumn("dbo.Ships", "ImagePath", c => c.String());
            AddColumn("dbo.Organisations", "ImagePath", c => c.String());
            DropForeignKey("dbo.Images", "Product_Id", "dbo.Ships");
            DropForeignKey("dbo.Images", "Product_Id", "dbo.Tours");
            DropForeignKey("dbo.Images", "Product_Id", "dbo.Organisations");
            DropIndex("dbo.Images", new[] { "Product_Id" });
            DropTable("dbo.Images");
        }
    }
}
