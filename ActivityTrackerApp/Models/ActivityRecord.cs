using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ActivityTrackerApp.Models
{
    public class ActivityRecord
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public bool Gym { get; set; }
        public bool Meditation { get; set; }
        public int MeditationMinutes { get; set; }
        public bool Reading { get; set; }
        public int PagesRead { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }
    }
}