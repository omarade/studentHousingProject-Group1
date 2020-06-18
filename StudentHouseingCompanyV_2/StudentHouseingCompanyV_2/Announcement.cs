using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentHouseingCompanyV_2
{
    class Announcement
    {
        private static int idSeeder = 1;

        public int AnnouncementId { get; }
        public string AnnouncementSubject { get; private set; }
        public string AnnouncementText { get; private set; }

        public Announcement(string announcSubject, string announcText)
        {
            AnnouncementId = idSeeder;
            AnnouncementSubject = announcSubject;
            AnnouncementText = announcText;
            idSeeder++;
        }
    }
}
