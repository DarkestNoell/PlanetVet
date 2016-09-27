using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Capstone.HelperClasses
{
    public class StartupQueries
    {
        //Insert ALL dates up until 01/01/2100
        public void AddAllDates()
        {
            
            DateTime DayToStartFrom = DateTime.Now;
            DateTime EndDate = new DateTime(2100, 1, 1);
            PlanetVetEntities pve = new PlanetVetEntities();
            if(!(pve.AllDates.ToList().Count == 0))
            {
                DayToStartFrom = pve.AllDates.OrderByDescending(p => p.DayID).First().Date;
            }

            foreach (DateTime day in EachDay(DayToStartFrom, EndDate))
            {
                //Add Day
                pve.AllDates.Add(new AllDate()
                {
                    Date = day
                });

                pve.SaveChanges();
                //Last day entered
                AllDate LastDateEntered = pve.AllDates.OrderByDescending(p => p.DayID).First();

                //See if current day is a work day
                OfficeHour oh = pve.OfficeHours.Where(ohh => ohh.DayName.Equals(day.DayOfWeek.ToString())).FirstOrDefault();
                if(oh != null)
                {
                    //oh is a workday

                    //Call the enumerable method
                    //Get datetime start from oh
                    DateTime start = oh.DayStart;
                    //Get datetime end from oh
                    DateTime end = oh.DayEnd;

                    //Assign hours/minutes/seconds to new datetime
                    DateTime TimeToStart = new DateTime(day.Year, day.Month, day.Day, start.Hour, start.Minute, start.Second);

                    DateTime TimeToEnd = new DateTime(day.Year, day.Month, day.Day, end.Hour, end.Minute, end.Second);

                    pve.Appointments.Add(
                                    new Appointment()
                                    {
                                        DayID = LastDateEntered.DayID,
                                        SlotTaken = false,
                                        Time = TimeToStart
                                    });

                    while (TimeToStart < TimeToEnd)
                    {
                        TimeToStart = TimeToStart.AddMinutes(15);
                        pve.Appointments.Add(
                                    new Appointment()
                                    {
                                        DayID = LastDateEntered.DayID,
                                        SlotTaken = false,
                                        Time = TimeToStart
                                    });
                    }

                }

                pve.SaveChanges();
            }
        }

        public void StartAllDatesThread()
        {
            ThreadStart ts = AddAllDates;
            Thread t = new Thread(ts);
            t.Start();
        }

        
        public IEnumerable<DateTime> EachDay(DateTime from, DateTime thru)
        {
            for (var day = from.Date; day.Date <= thru.Date; day = day.AddDays(1))
                yield return day;
        }
    }
}
