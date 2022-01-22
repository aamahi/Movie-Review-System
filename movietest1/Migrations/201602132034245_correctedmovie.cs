namespace movietest1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class correctedmovie : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Movies");
            AddColumn("dbo.Movies", "key", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Movies", "key");
            DropColumn("dbo.Movies", "ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "ID", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.Movies");
            DropColumn("dbo.Movies", "key");
            AddPrimaryKey("dbo.Movies", "ID");
        }
    }
}
