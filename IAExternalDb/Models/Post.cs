using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IAExternalDb.Models
{
    public class Post
    {
        [Key]
        public int id { get; set; }

        [FileExtensions(Extensions = "jpg,jpeg,png")]
        [DataType(DataType.ImageUrl)]
        [Display(Name = "PostImage")]
        public string PostImage { get; set; }

        [ForeignKey("User")]
        public int Owner_Id { get; set; }

        public string Caption { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<Like> LikesList { get; set; }

        public virtual ICollection<Dislike> DislikesList { get; set; }

        public virtual ICollection<Comment> CommentList { get; set; }
    }
}