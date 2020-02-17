namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asdfdgf : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Images", "Tip", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Images", "Tip");
        }
    }
}
