using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.DataModels
{
    public class OfficeDayModel
    {
        public int DayID { get; set; }
        public String DayName { get; set; }
        public DateTime DayStart { get; set; }
        public DateTime DayEnd { get; set; }
        public DateTime LunchStart { get; set; }
        public DateTime LunchEnd { get; set; }
        public bool TentativeDay { get; set; }
    }
}
