using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IAExternalDb.Models
{
    public class Comment
    {
        [Key]
        public int Comment_ID { get; set; }

        public string owner_name { get; set; }

        [ForeignKey("MainPost")]
        [Column(Order = 0)]
        public int Post_ID { get; set; }

        
        [ForeignKey("Owner")]
        [Column(Order = 1)]
        public int comment_owner_id { get; set; }

        public string text { get; set; }

        public virtual User Owner { get; set; }

        public virtual Post MainPost { get; set; }
    }
}