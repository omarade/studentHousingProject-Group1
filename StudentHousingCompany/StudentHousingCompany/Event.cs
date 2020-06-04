using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentHousingCompany
{
    class Event
    {
        private static int idSeeder = 0;

        public int EventId { get; }
        public string EventName { get; set; }
        public string EventDesc { get; set; }
        public DateTime DateOfEvent { get; set; }
        public string EventOwner { get; set; }
        public List<Event> NegativeResponses { get; }

        public Event(string eventName, DateTime dateOfEvent, string eventDesc, string eventOwner)
        {
            EventId = idSeeder;
            EventName = eventName;
            EventDesc = eventDesc;
            DateOfEvent = dateOfEvent;
            EventOwner = eventOwner;
            idSeeder++;
            NegativeResponses = new List<Event>();
        }
    }
}
