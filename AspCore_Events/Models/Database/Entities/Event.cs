using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspCore_Events.Models.Database
{
    public class Event
    {
        public int Id { get; set; }
        public string URL { get; set; }
        public string Title { get; set; }        
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool AllDay { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }


        public ICollection<EventLabel> EventLabels { get; set; }
    }
}
