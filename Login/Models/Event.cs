using System;
using System.Collections.Generic;

#nullable disable

namespace Login.Models
{
    public partial class Event
    {
        public Event()
        {
            EventRegits = new HashSet<EventRegit>();
        }

        public int Id { get; set; }
        public string EventName { get; set; }
        public string Icon { get; set; }

        public virtual ICollection<EventRegit> EventRegits { get; set; }
    }
}
