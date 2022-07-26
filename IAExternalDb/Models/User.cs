using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IAExternalDb.Models
{
    public class User
    {
        [Key]
        public int user_id { get; set; }
        
        [Required]
        public string Password { get; set; }

        [Required]
        [StringLength(20,ErrorMessage ="Name too Long")]
        public string Fname { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Name too Long")]
        public string Lname { get; set; }

        [StringLength(240, ErrorMessage = "Name too Long")]
        public string Bio { get; set; }

        [Required]
        public int Telephone { get; set; }
        
        [EmailAddress]
        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        public Gender gender { get; set; }

        [FileExtensions(Extensions = "jpg,jpeg,png")]
        [DataType(DataType.ImageUrl)]
        [Display(Name = "Photo")]
        public string ProfilePicture { get; set; }
        
        public virtual ICollection<User> FollowersList { get; set; }

        public virtual ICollection<User> FollowingList { get; set; }
        
        public virtual ICollection<User> FriendsReqList { get; set; }

        public virtual ICollection<Post> PostsList { get; set; }
    }

    public enum Gender
    {
        Male,
        Female
    };
}