using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentHouseingCompanyV_2
{
    class Event
    {
        private static int idSeeder = 1;

        public int EventId { get; }
        public string EventName { get; private set; }
        public string EventDesc { get; private set; }
        public DateTime DateOfEvent { get; private set; }
        public string EventOwner { get; private set; }
        public List<string> NegativeResponses { get; }
        public List<string> PositiveResponses { get; }

        public Event(string eventName, DateTime dateOfEvent, string eventDesc, string eventOwner)
        {
            EventId = idSeeder;
            EventName = eventName;
            EventDesc = eventDesc;
            DateOfEvent = dateOfEvent;
            EventOwner = eventOwner;
            idSeeder++;
            NegativeResponses = new List<string>();
            PositiveResponses = new List<string>();
        }

        public void Disagree(string tenant)
        {
            NegativeResponses.Add(tenant);
            PositiveResponses.Remove(tenant);
        }

        public void Agree(string tenant)
        {
            PositiveResponses.Add(tenant);
            NegativeResponses.Remove(tenant);
        }

        public ListViewItem GetInfo()
        {
            string[] arr = new string[5];
            ListViewItem itm;
            //add items to ListView
            arr[0] = EventId.ToString();
            arr[1] = EventOwner;
            arr[2] = EventName;
            arr[3] = EventDesc;
            arr[4] = DateOfEvent.ToString("dd/MM/yyyy");
            itm = new ListViewItem(arr);

            return itm;
        }
    }
}
