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
            //List<DateTime> AvailableAppointmentTimes = new List<DateTime>();
            //OfficeHour StartOfDay = pve.OfficeHours.Where(day => day.DayName.Equals(SelectedDate.DayOfWeek)).FirstOrDefault();
            //MessageBox.Show(StartOfDay.DayStart.ToShortTimeString());
            //MessageBox.Show("sdjklfjlsjflks");

            //SelectedDate Starts at 12A.M.
            //PlanetVetEntities pve = new PlanetVetEntities();
            PlanetVetEntities pve = new PlanetVetEntities();
            OfficeHour Day = pve.OfficeHours.Where(day => day.DayName.Equals(SelectedDate.DayOfWeek.ToString())).FirstOrDefault();
            ////Start of given work day
            DateTime AppointmentStart = new DateTime(SelectedDate.Year, SelectedDate.Month, SelectedDate.Day, Day.DayStart.Hour, Day.DayStart.Minute, 0);
            DateTime AppointmentEnd = AppointmentStart.AddMinutes(MinutesForAppointment);
            SelectedDateLabel.Content = SelectedDate.ToShortDateString();
            //SelectedDate.ToShortDateString();

            List<Appointment> AppointmentsForThisDay = pve.Appointments.Where(app => app.TimeStart.Year == SelectedDate.Year &&
                                                                              app.TimeStart.Month == SelectedDate.Month &&
                                                                              app.TimeStart.Day == SelectedDate.Day).ToList();

            DateTime StartOfDay = new DateTime(SelectedDate.Year, SelectedDate.Month, SelectedDate.Date.Day, Day.DayStart.Hour, Day.DayStart.Minute, 0);
            DateTime EndOfDay = new DateTime(SelectedDate.Year, SelectedDate.Month, SelectedDate.Date.Day, Day.DayEnd.Hour, Day.DayEnd.Minute, 0);
            //SelectedDateLabel.Content = SelectedDate.ToShortDateString();

            List<DateTime> AvailableAppointmentTimes = new List<DateTime>();
            Boolean CanAdd = true;

            while ((AppointmentEnd <= EndOfDay))
            {
                CanAdd = true;
                foreach (Appointment a in AppointmentsForThisDay)
                {
                    if (a.TimeStart <= AppointmentStart && a.TimeEnd >= AppointmentEnd)
                    {
                        CanAdd = false;
                    }
                }

                if (CanAdd)
                {
                    AvailableAppointmentTimes.Add(AppointmentStart);
                }

                AppointmentStart = AppointmentStart.AddMinutes(10);
                AppointmentEnd = AppointmentEnd.AddMinutes(10);
            }
            AppointmentListBox.ItemsSource = AvailableAppointmentTimes;
        }
      

        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            AddAppointmentWindow aaw = new AddAppointmentWindow();
            aaw.SelectedDate = SelectedDate;
            aaw.Show();
            this.Close();
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
