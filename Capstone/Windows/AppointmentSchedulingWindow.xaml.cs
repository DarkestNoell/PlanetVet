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
        public DateTime SelectedDate { get; set; }
        public AppointmentSchedulingWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SelectedDateLabel.Content = SelectedDate;
            PlanetVetEntities pve = new PlanetVetEntities();

            //All appointment slots on selected date
            var Slots = pve.AppointmentSlots.Where(dayToFind => dayToFind.DayName.Contains(SelectedDate.DayOfWeek.ToString())).ToList();

            //Appointments on selected date
            var AppointmentsForThisDay = pve.Appointments.Where(appt => appt.TimeStart.Year == SelectedDate.Year && appt.TimeStart.Month == SelectedDate.Month && appt.TimeStart.Month == SelectedDate.Day);

            foreach (AppointmentSlot AS in Slots)
            {
                foreach (Appointment a in AppointmentsForThisDay)
                {
                    if(a.TimeStart.Hour == AS.TimeSlot.Hour && a.TimeStart.Minute == AS.TimeSlot.Minute)
                    {
                        Slots.Remove(AS);
                    }
                }
            }

            AppointmentSlotsDataGrid.ItemsSource = Slots;
            AppointmentSlotsDataGrid.Columns.Remove(AppointmentSlotsDataGrid.Columns[0]);
            AppointmentSlotsDataGrid.Columns.Remove(AppointmentSlotsDataGrid.Columns[0]);
            AppointmentSlotsDataGrid.Columns.Remove(AppointmentSlotsDataGrid.Columns[0]);
            AppointmentSlotsDataGrid.Columns.Remove(AppointmentSlotsDataGrid.Columns[0]);
            AppointmentSlotsDataGrid.IsReadOnly = true;
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
            AddAppointmentWindow aaw = new AddAppointmentWindow();
            aaw.SelectedDate = SelectedDate;
            aaw.Show();
            this.Close();
        }
    }
}
