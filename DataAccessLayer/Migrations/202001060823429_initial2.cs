namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Organisations", "StartDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Organisations", "EndDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Tours", "StartDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Tours", "EndDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Tours", "Date");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tours", "Date", c => c.DateTime(nullable: false));
            DropColumn("dbo.Tours", "EndDate");
            DropColumn("dbo.Tours", "StartDate");
            DropColumn("dbo.Organisations", "EndDate");
            DropColumn("dbo.Organisations", "StartDate");
        }
    }
}
