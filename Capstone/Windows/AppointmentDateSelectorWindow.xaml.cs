using Capstone.Windows;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Capstone
{
    /// <summary>
    /// Interaction logic for EmployeeScheduleWindow.xaml
    /// </summary>
    public partial class AppointmentDateSelectorWindow : MetroWindow
    {
        public Boolean NewAppointment { get; set; }
        public Boolean MoveAppointment { get; set; }
        public Boolean CancelAppointment { get; set; }
        List<String> DaysOpened = new List<String>();

        public AppointmentDateSelectorWindow()
        {
            InitializeComponent();
            AppointmentSelectDatePicker.BlackoutDates.AddDatesInPast();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            PlanetVetWindow pvw = new PlanetVetWindow();
            pvw.Show();
            this.Close();
        }

        private void ScheduleButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ProcedureLengthHrsTextBox.Text.Equals("") && ProcedureLengthMinutesTextBox.Text.Equals(""))
                {
                    MessageBox.Show("Please supply an appointment length!");
                }
                else
                {
                    int MinutesNeeded = 0;
                    if (!ProcedureLengthHrsTextBox.Text.Equals(""))
                    {
                        int num = int.Parse(ProcedureLengthHrsTextBox.Text);
                        num *= 60;
                        MinutesNeeded += num;
                    }
                    else if (!ProcedureLengthMinutesTextBox.Text.Equals(""))
                    {
                        MinutesNeeded += int.Parse(ProcedureLengthMinutesTextBox.Text);
                    }


                    AppointmentSchedulingWindow.SelectedDate = AppointmentSelectDatePicker.SelectedDate.Value;
                    AppointmentSchedulingWindow.MinutesForAppointment = MinutesNeeded;

                    AppointmentSchedulingWindow asw = new AppointmentSchedulingWindow();
                    asw.Show();
                    this.Close();
                }
            }
            catch
            {
                MessageBox.Show("Please provide an appointment length, then select a date.");
            }
        }

        private bool DayBooked(DateTime dayToCheck, int timeNeededForAppoinment)
        {
            bool DayBooked = true;
            PlanetVetEntities pve = new PlanetVetEntities();

            //Correlate the date with appointments
            if (DaysOpened.Contains(dayToCheck.DayOfWeek.ToString()))
            {
                OfficeHour oh = pve.OfficeHours.Where(officehour => officehour.DayName.Contains(dayToCheck.DayOfWeek.ToString())).First();
                //OH Contains the start and ending hours of the business day
      
                DateTime DayEnds = new DateTime(dayToCheck.Year, dayToCheck.Month, dayToCheck.Day, oh.DayEnd.Hour, oh.DayEnd.Minute, 0);

                //Loop through all minutes of the day
                DateTime TimeSlot = new DateTime(dayToCheck.Year, dayToCheck.Month, dayToCheck.Day, oh.DayStart.Hour, oh.DayStart.Minute, 0);
                DateTime NewAppointmentEnd = new DateTime(TimeSlot.Year, TimeSlot.Month, TimeSlot.Day, TimeSlot.Hour, TimeSlot.Minute, 0);
                NewAppointmentEnd = NewAppointmentEnd.AddMinutes(timeNeededForAppoinment);

                while(TimeSlot != DayEnds)
                {
                    if (NewAppointmentEnd > DayEnds)
                    {
                        DayBooked = true;
                        break;
                    }

                        //All appointments between scheduled time
                        //If the result returns null, an appointment can be scheduled
                        //if results are returned, proceed on
                        //Appointment ApptsBetween = pve.Appointments.Where(app => app.TimeStart <= TimeSlot && app.TimeEnd > NewAppointmentEnd).ToList();

                    //Appointments Between start/end

                    //Appt we are trying to schedule is:
                       
                        List<Appointment> AppointmentsOverlapping = pve.Appointments.Where(app => app.TimeStart <= TimeSlot && TimeSlot < app.TimeEnd).ToList();
                        List<Appointment> AppointmentsOverlappingWithEndTimeList = pve.Appointments.Where(app => app.TimeStart <= NewAppointmentEnd
                      && NewAppointmentEnd < app.TimeEnd).ToList();
                        if(AppointmentsOverlapping.Count != pve.ExamRooms.ToList().Count && AppointmentsOverlappingWithEndTimeList.Count != pve.ExamRooms.ToList().Count)
                        {
                                 DayBooked = false;
                                 break;
                    
                        }else
                        {
                            TimeSlot = TimeSlot.AddMinutes(10);
                            NewAppointmentEnd = NewAppointmentEnd.AddMinutes(10);
                        }
                }
            }
            return DayBooked;
        }

        private void AppointmentSelectDatePicker_CalendarOpened(object sender, RoutedEventArgs e)
        {
            AppointmentSelectDatePicker.BlackoutDates.Clear();
            if (ProcedureLengthHrsTextBox.Text.Equals("") && ProcedureLengthMinutesTextBox.Text.Equals(""))
            {
                MessageBox.Show("Please provide an appointment length");
            }
            else
            {
                int MinutesNeeded = 0;
                if (!ProcedureLengthHrsTextBox.Text.Equals(""))
                {
                    int num = int.Parse(ProcedureLengthHrsTextBox.Text);
                    num *= 60;
                    MinutesNeeded += num;
                }
                else if (!ProcedureLengthMinutesTextBox.Text.Equals(""))
                {
                    MinutesNeeded += int.Parse(ProcedureLengthMinutesTextBox.Text);
                }

                //Received minutes needed for appointment
                //Now correlate this with appointments on X day

                AppointmentSelectDatePicker.DisplayDateStart = DateTime.Now.AddYears(-1); ;
                AppointmentSelectDatePicker.DisplayDateEnd = DateTime.Now + TimeSpan.FromDays(500);
                AppointmentSelectDatePicker.IsTodayHighlighted = true;

                var minDate = AppointmentSelectDatePicker.DisplayDateStart ?? DateTime.MinValue;
                var maxDate = AppointmentSelectDatePicker.DisplayDateEnd ?? DateTime.MaxValue;

                PlanetVetEntities pve = new PlanetVetEntities();

                foreach (OfficeHour oh in pve.OfficeHours)
                {
                    DaysOpened.Add(oh.DayName);
                }

                for (var d = minDate; d <= maxDate && DateTime.MaxValue > d; d = d.AddDays(1))
                {
                    if (!(DaysOpened.Contains(d.DayOfWeek.ToString())))
                    {
                        AppointmentSelectDatePicker.BlackoutDates.Add(new CalendarDateRange(d));
                    }
                    else
                    {

                    }
                }

                if (NewAppointment)
                {
                    for (var d = minDate; d <= maxDate && DateTime.MaxValue > d; d = d.AddDays(1))
                    {
                        if (!(DaysOpened.Contains(d.DayOfWeek.ToString())))
                        {
                            AppointmentSelectDatePicker.BlackoutDates.Add(new CalendarDateRange(d));
                        }
                        else if (DayBooked(d, MinutesNeeded))
                        {
                            AppointmentSelectDatePicker.BlackoutDates.Add(new CalendarDateRange(d));
                        }
                    }
                }
                else if (MoveAppointment)
                {

                }
                else if (CancelAppointment)
                {

                }
            }
        }
    }
}
