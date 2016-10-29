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

namespace Capstone.Windows
{ 
    public partial class AppointmentSchedulingWindow : MetroWindow
    {
        public static DateTime SelectedDate { get; set; }
        public static int MinutesForAppointment { get; set; }
        public AppointmentSchedulingWindow()
        {
            InitializeComponent();
            WorkOnWindow();
        }

        private void WorkOnWindow()
        {
            SelectedDateLabel.Content = SelectedDate.ToShortDateString();
            
            PlanetVetEntities pve = new PlanetVetEntities();
            List<DateTime> DatesAvailable = new List<DateTime>();
            //Correlate the date with appointments
            OfficeHour oh = pve.OfficeHours.Where(officehour => officehour.DayName.Contains(SelectedDate.DayOfWeek.ToString())).First();
            //OH Contains the start and ending hours of the business day

            DateTime DayEnds = new DateTime(SelectedDate.Year, SelectedDate.Month, SelectedDate.Day, oh.DayEnd.Hour, oh.DayEnd.Minute, 0);

            //Loop through all minutes of the day
            DateTime TimeSlot = new DateTime(SelectedDate.Year, SelectedDate.Month, SelectedDate.Day, oh.DayStart.Hour, oh.DayStart.Minute, 0);
            DateTime NewAppointmentEnd = new DateTime(TimeSlot.Year, TimeSlot.Month, TimeSlot.Day, TimeSlot.Hour, TimeSlot.Minute, 0);
            NewAppointmentEnd = NewAppointmentEnd.AddMinutes(MinutesForAppointment);

            while (TimeSlot != DayEnds)
            {
                if (NewAppointmentEnd > DayEnds)
                {
                    break;
                }
                List<Appointment> AppointmentsOverlapping = pve.Appointments.Where(app => app.TimeStart <= TimeSlot && TimeSlot < app.TimeEnd).ToList();
                List<Appointment> AppointmentsOverlappingWithEndTimeList = pve.Appointments.Where(app => app.TimeStart <= NewAppointmentEnd
              && NewAppointmentEnd < app.TimeEnd).ToList();
                if (AppointmentsOverlapping.Count != pve.ExamRooms.ToList().Count && AppointmentsOverlappingWithEndTimeList.Count != pve.ExamRooms.ToList().Count)
                {
                    DatesAvailable.Add(TimeSlot);
                    TimeSlot = TimeSlot.AddMinutes(10);
                    NewAppointmentEnd = NewAppointmentEnd.AddMinutes(10);
                }
                else
                {
                    TimeSlot = TimeSlot.AddMinutes(10);
                    NewAppointmentEnd = NewAppointmentEnd.AddMinutes(10);
                }
            }

            AppointmentListBox.ItemsSource = DatesAvailable;
        }
            
      

        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            AddAppointmentWindow aaw = new AddAppointmentWindow();
            aaw.SelectedDate = SelectedDate;
            aaw.Show();
            this.Close();
        }

        private Boolean AllExamRoomsBooked(List<Appointment> AppointmentsForThisDayList)
        {
            PlanetVetEntities pve = new PlanetVetEntities();
            int NumberOfExamRooms = pve.ExamRooms.ToList().Count;

            
            return false;
        }

        private void AppointmentSlotsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //AppointmentSlot a = (AppointmentSlot) AppointmentSlotsDataGrid.SelectedItem;
            AddAppointmentWindow aaw = new AddAppointmentWindow();
            aaw.SelectedDate = SelectedDate;
            aaw.Show();
            this.Close();
        }

        private void AppointmentListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime dt = (DateTime) AppointmentListBox.SelectedItem;
            AddAppointmentWindow aaw = new AddAppointmentWindow();
            aaw.SelectedDate = dt;
            aaw.ProcedureTime = MinutesForAppointment;
            aaw.Show();
            this.Close();
        }
    }
}
