using System;
using System.Collections.Generic;

#nullable disable

namespace Login.Models
{
    public partial class UserOfSchoolYear
    {
        public string UserId { get; set; }
        public int SchoolYearId { get; set; }

        public virtual SchoolYear SchoolYear { get; set; }
        public virtual User User { get; set; }
    }
}
