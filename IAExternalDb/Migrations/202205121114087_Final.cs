namespace IAExternalDb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Final : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Dislikes",
                c => new
                    {
                        Post_ID = c.Int(nullable: false),
                        dislike_owner_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Post_ID, t.dislike_owner_id })
                .ForeignKey("dbo.Posts", t => t.Post_ID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.dislike_owner_id, cascadeDelete: true)
                .Index(t => t.Post_ID)
                .Index(t => t.dislike_owner_id);
            
            AddColumn("dbo.Posts", "Caption", c => c.String());
            AddColumn("dbo.Users", "Password", c => c.String());
            AlterColumn("dbo.Users", "Bio", c => c.String(maxLength: 240));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Dislikes", "dislike_owner_id", "dbo.Users");
            DropForeignKey("dbo.Dislikes", "Post_ID", "dbo.Posts");
            DropIndex("dbo.Dislikes", new[] { "dislike_owner_id" });
            DropIndex("dbo.Dislikes", new[] { "Post_ID" });
            AlterColumn("dbo.Users", "Bio", c => c.String());
            DropColumn("dbo.Users", "Password");
            DropColumn("dbo.Posts", "Caption");
            DropTable("dbo.Dislikes");
        }
    }
}
