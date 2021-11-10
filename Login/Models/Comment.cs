using System;
using System.Collections.Generic;

#nullable disable

namespace Login.Models
{
    public partial class Comment
    {
        public Comment()
        {
            Notifications = new HashSet<Notification>();
        }

        public int Id { get; set; }
        public string UserId { get; set; }
        public string Content { get; set; }
        public int EnventRegitsId { get; set; }
        public DateTime? Timestamp { get; set; }
        public int? AbilityFactorsId { get; set; }

        public virtual AbilityFactor AbilityFactors { get; set; }
        public virtual EventRegit EnventRegits { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }
    }
}
