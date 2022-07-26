using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IAExternalDb.Models
{
    public class Like
    {
        [Key][ForeignKey("MainPost")][Column(Order = 0)]
        public int Post_ID { get; set; }

        [Key][ForeignKey("Owner")][Column(Order = 1)]
        public int like_owner_id { get; set; }

        public virtual User Owner { get; set; }

        public virtual Post MainPost { get; set; }
    }
}