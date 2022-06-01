using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspCore_Events.Models.Database
{
    public class EventLabel
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public short Label { get; set; }

        public Event Event { get; set; }
    }
}
