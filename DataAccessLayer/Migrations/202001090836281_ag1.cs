namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ag1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.YachtRentings", "Email", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.YachtRentings", "Email");
        }
    }
}
