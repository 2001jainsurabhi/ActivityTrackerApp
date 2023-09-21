using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ActivityTrackerApp.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public string Gender { get; set; }
        public double BMI
        {
            get
            {
                return CalculateBMI();
            }
        }

        private double CalculateBMI()
        {
            // BMI formula: BMI = weight (kg) / (height (m))^2
            if (Height == 0)
                return 0;

            return Weight / (Height * Height);
        }

        public List<ActivityRecord> ActivityRecords { get; set; }
    }

}