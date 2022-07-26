using IAExternalDb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace IAExternalDb.Context
{
    public class DataContext : DbContext
    {
        public DbSet<User> UserTable { get; set; }

        public DbSet<Post> PostTable { get; set; }

        public DbSet<Like> LikeTable { get; set; }

        public DbSet<Dislike> DislikeTable { get; set; }

        public DbSet<Comment> CommentTable { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
               .HasMany(x => x.FollowersList)
               .WithMany()
               .Map(m =>
               {
                   m.MapLeftKey("UserId");
                   m.MapRightKey("FollowerID");
                   m.ToTable("UserFollower");
               });

            modelBuilder.Entity<User>()
               .HasMany(x => x.FollowingList)
               .WithMany()
               .Map(m =>
               {
                   m.MapLeftKey("UserId");
                   m.MapRightKey("FollowingID");
                   m.ToTable("UserFollowing");
               });

            modelBuilder.Entity<User>()
               .HasMany(x => x.FriendsReqList)
               .WithMany()
               .Map(m =>
               {
                   m.MapLeftKey("UserId");
                   m.MapRightKey("RequesterID");
                   m.ToTable("UserRequests");
               });

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Telephone)
                .IsUnique();
        }
    }
}