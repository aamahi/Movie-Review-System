namespace movietest1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedPostTime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "PostedOn", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "PostedOn");
        }
    }
}
