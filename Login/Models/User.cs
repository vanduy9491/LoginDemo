using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

#nullable disable

namespace Login.Models
{
    public partial class User : IdentityUser
    {
        public User()
        {
            Comments = new HashSet<Comment>();
            EventRegits = new HashSet<EventRegit>();
            UserOfSchoolYears = new HashSet<UserOfSchoolYear>();
        }
        public string StudentCode { get; set; }
        public string FullName { get; set; }
        public string Avatar { get; set; }
        public string? ParentId { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<EventRegit> EventRegits { get; set; }
        public virtual ICollection<UserOfSchoolYear> UserOfSchoolYears { get; set; }
    }
}
