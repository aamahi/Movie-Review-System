namespace movietest1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedrequiredonMovie : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "image", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "image", c => c.String());
        }
    }
}
