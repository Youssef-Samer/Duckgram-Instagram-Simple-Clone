namespace IAExternalDb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OwnerNameComment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "owner_name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Comments", "owner_name");
        }
    }
}
