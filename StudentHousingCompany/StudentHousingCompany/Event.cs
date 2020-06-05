using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        public List<string> NegativeResponses { get; }

        public Event(string eventName, DateTime dateOfEvent, string eventDesc, string eventOwner)
        {
            EventId = idSeeder;
            EventName = eventName;
            EventDesc = eventDesc;
            DateOfEvent = dateOfEvent;
            EventOwner = eventOwner;
            idSeeder++;
            NegativeResponses = new List<string>();
        }

        public void AddResponse(string tenant)
        {
            NegativeResponses.Add(tenant);
        }

        public ListViewItem GetInfo()
        {
            string[] arr = new string[4];
            ListViewItem itm;
            //add items to ListView
            arr[0] = EventOwner;
            arr[1] = EventName;
            arr[2] = EventDesc;
            arr[3] = DateOfEvent.ToString("dd/MM/yyyy");
            itm = new ListViewItem(arr);

            return itm;
        }
    }
}
