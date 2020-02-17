namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.YachtRentings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        YachtId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.YachtRentings");
        }
    }
}
