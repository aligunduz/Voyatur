namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.YachtRentings", "YachtId", c => c.Int());
            AlterColumn("dbo.YachtRentings", "UserId", c => c.Int());
            CreateIndex("dbo.YachtRentings", "YachtId");
            CreateIndex("dbo.YachtRentings", "UserId");
            AddForeignKey("dbo.YachtRentings", "UserId", "dbo.Users", "Id");
            AddForeignKey("dbo.YachtRentings", "YachtId", "dbo.Ships", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.YachtRentings", "YachtId", "dbo.Ships");
            DropForeignKey("dbo.YachtRentings", "UserId", "dbo.Users");
            DropIndex("dbo.YachtRentings", new[] { "UserId" });
            DropIndex("dbo.YachtRentings", new[] { "YachtId" });
            AlterColumn("dbo.YachtRentings", "UserId", c => c.Int(nullable: false));
            AlterColumn("dbo.YachtRentings", "YachtId", c => c.Int(nullable: false));
        }
    }
}
