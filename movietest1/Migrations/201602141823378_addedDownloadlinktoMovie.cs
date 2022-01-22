namespace movietest1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedDownloadlinktoMovie : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "DownloadLink", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "DownloadLink");
        }
    }
}
