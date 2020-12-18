using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Canteen.Models
{
    public class AvailabilityInfo
    {
        public string Breakfast { get; set; }

        public string Dinner { get; set; }

        public string Lunch { get; set; }

        public string Weekdays { get; set; }

        public string Weekends { get; set; }
    }
}