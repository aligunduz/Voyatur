namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asdf : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Organisations", "ImagePath", c => c.String());
            AddColumn("dbo.Tours", "ImagePath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tours", "ImagePath");
            DropColumn("dbo.Organisations", "ImagePath");
        }
    }
}
