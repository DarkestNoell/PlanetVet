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
            var Slots = pve.AppointmentSlots.Where(dayToFind => dayToFind.DayName.Contains(SelectedDate.DayOfWeek.ToString())).ToList();

            AppointmentSlotsDataGrid.ItemsSource = Slots;
            AppointmentSlotsDataGrid.Columns.Remove(AppointmentSlotsDataGrid.Columns[0]);
            AppointmentSlotsDataGrid.Columns.Remove(AppointmentSlotsDataGrid.Columns[0]);
            AppointmentSlotsDataGrid.Columns.Remove(AppointmentSlotsDataGrid.Columns[0]);
            AppointmentSlotsDataGrid.Columns.Remove(AppointmentSlotsDataGrid.Columns[0]);

        }
    }
}
