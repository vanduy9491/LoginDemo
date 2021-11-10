using System;
using System.Collections.Generic;

#nullable disable

namespace Login.Models
{
    public partial class AbilityFactor
    {
        public AbilityFactor()
        {
            Comments = new HashSet<Comment>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public string Tags { get; set; }
        public int? SkillId { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
