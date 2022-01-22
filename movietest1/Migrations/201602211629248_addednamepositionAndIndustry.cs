namespace movietest1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addednamepositionAndIndustry : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "Industry", c => c.String(nullable: false));
            AddColumn("dbo.Movies", "NamePosition", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "NamePosition");
            DropColumn("dbo.Movies", "Industry");
        }
    }
}
