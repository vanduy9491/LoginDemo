using System;
using System.Collections.Generic;

#nullable disable

namespace Login.Models
{
    public partial class Notification
    {
        public int Id { get; set; }
        public string FromUserId { get; set; }
        public string ToUserId { get; set; }
        public bool? IsRead { get; set; }
        public string Url { get; set; }
        public int? CommentId { get; set; }

        public virtual Comment Comment { get; set; }
    }
}
