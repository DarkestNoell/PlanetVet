using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone
{
    public class AppointmentHoursSetup
    {
        private static String[] WorkDaysArray;
        public AppointmentHoursSetup()
        {

        }

        public AppointmentHoursSetup(List<String> AppointmentDays)
        {
            WorkDaysArray = AppointmentDays.ToArray();
        }
        
        public String[] WorkDaysArrayReturn()
        {
            return WorkDaysArray;
        }   
    }
}
