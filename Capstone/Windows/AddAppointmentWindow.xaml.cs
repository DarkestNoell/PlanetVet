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
    /// <summary>
    /// Interaction logic for AddAppointmentWindow.xaml
    /// </summary>
    public partial class AddAppointmentWindow : Window
    {
        public DateTime SelectedDate { get; set; }

        public AddAppointmentWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Populate Combo Boxes accordingly
            PlanetVetEntities pve = new PlanetVetEntities();
            foreach(Employee emp in pve.Employees)
            {
                if (emp.IsDoctor)
                {
                    DoctorComboBox.Items.Add(emp.FirstName + " " + emp.LastName);
                }
            }

            foreach(ExamRoom er in pve.ExamRooms)
            {
                ExamRoomComboBox.Items.Add(er);
            }
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
