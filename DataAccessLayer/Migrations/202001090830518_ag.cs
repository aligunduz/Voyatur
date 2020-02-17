namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ag : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.YachtRentings", "Phone", c => c.String());
            AddColumn("dbo.YachtRentings", "Note", c => c.String());
            AddColumn("dbo.Users", "UserName", c => c.String());
            AddColumn("dbo.Users", "Surname", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Surname");
            DropColumn("dbo.Users", "UserName");
            DropColumn("dbo.YachtRentings", "Note");
            DropColumn("dbo.YachtRentings", "Phone");
        }
    }
}
