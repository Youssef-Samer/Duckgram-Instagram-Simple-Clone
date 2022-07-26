namespace IAExternalDb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        PostImage = c.String(),
                        Owner_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Users", t => t.Owner_Id)
                .Index(t => t.Owner_Id);
            
            CreateTable(
                "dbo.Likes",
                c => new
                    {
                        Post_ID = c.Int(nullable: false),
                        like_owner_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Post_ID, t.like_owner_id })
                .ForeignKey("dbo.Posts", t => t.Post_ID)
                .ForeignKey("dbo.Users", t => t.like_owner_id)
                .Index(t => t.Post_ID)
                .Index(t => t.like_owner_id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        user_id = c.Int(nullable: false, identity: true),
                        Fname = c.String(nullable: false, maxLength: 20),
                        Lname = c.String(nullable: false, maxLength: 20),
                        Bio = c.String(),
                        Telephone = c.Int(nullable: false),
                        Email = c.String(nullable: false, maxLength: 100),
                        gender = c.Int(nullable: false),
                        ProfilePicture = c.String(),
                    })
                .PrimaryKey(t => t.user_id)
                .Index(t => t.Telephone, unique: true)
                .Index(t => t.Email, unique: true);
            
            CreateTable(
                "dbo.UserFollower",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        FollowerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.FollowerID })
                .ForeignKey("dbo.Users", t => t.UserId)
                .ForeignKey("dbo.Users", t => t.FollowerID)
                .Index(t => t.UserId)
                .Index(t => t.FollowerID);
            
            CreateTable(
                "dbo.UserFollowing",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        FollowingID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.FollowingID })
                .ForeignKey("dbo.Users", t => t.UserId)
                .ForeignKey("dbo.Users", t => t.FollowingID)
                .Index(t => t.UserId)
                .Index(t => t.FollowingID);
            
            CreateTable(
                "dbo.UserRequests",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        RequesterID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.RequesterID })
                .ForeignKey("dbo.Users", t => t.UserId)
                .ForeignKey("dbo.Users", t => t.RequesterID)
                .Index(t => t.UserId)
                .Index(t => t.RequesterID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "Owner_Id", "dbo.Users");
            DropForeignKey("dbo.Likes", "like_owner_id", "dbo.Users");
            DropForeignKey("dbo.UserRequests", "RequesterID", "dbo.Users");
            DropForeignKey("dbo.UserRequests", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserFollowing", "FollowingID", "dbo.Users");
            DropForeignKey("dbo.UserFollowing", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserFollower", "FollowerID", "dbo.Users");
            DropForeignKey("dbo.UserFollower", "UserId", "dbo.Users");
            DropForeignKey("dbo.Likes", "Post_ID", "dbo.Posts");
            DropIndex("dbo.UserRequests", new[] { "RequesterID" });
            DropIndex("dbo.UserRequests", new[] { "UserId" });
            DropIndex("dbo.UserFollowing", new[] { "FollowingID" });
            DropIndex("dbo.UserFollowing", new[] { "UserId" });
            DropIndex("dbo.UserFollower", new[] { "FollowerID" });
            DropIndex("dbo.UserFollower", new[] { "UserId" });
            DropIndex("dbo.Users", new[] { "Email" });
            DropIndex("dbo.Users", new[] { "Telephone" });
            DropIndex("dbo.Likes", new[] { "like_owner_id" });
            DropIndex("dbo.Likes", new[] { "Post_ID" });
            DropIndex("dbo.Posts", new[] { "Owner_Id" });
            DropTable("dbo.UserRequests");
            DropTable("dbo.UserFollowing");
            DropTable("dbo.UserFollower");
            DropTable("dbo.Users");
            DropTable("dbo.Likes");
            DropTable("dbo.Posts");
        }
    }
}
