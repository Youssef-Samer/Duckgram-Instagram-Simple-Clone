namespace IAExternalDb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCommentAndLikes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Post_ID = c.Int(nullable: false),
                        comment_owner_id = c.Int(nullable: false),
                        Comment_ID = c.Int(nullable: false, identity: true),
                        text = c.String(),
                    })
                .PrimaryKey(t => t.Comment_ID)
                .ForeignKey("dbo.Posts", t => t.Post_ID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.comment_owner_id, cascadeDelete: true)
                .Index(t => t.Post_ID)
                .Index(t => t.comment_owner_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "comment_owner_id", "dbo.Users");
            DropForeignKey("dbo.Comments", "Post_ID", "dbo.Posts");
            DropIndex("dbo.Comments", new[] { "comment_owner_id" });
            DropIndex("dbo.Comments", new[] { "Post_ID" });
            DropTable("dbo.Comments");
        }
    }
}
