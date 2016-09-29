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
    /// <summary>
    /// Interaction logic for AddMoveDeleteScheduleMenu.xaml
    /// </summary>
    public partial class AddMoveDeleteScheduleMenuWindow : MetroWindow
    {
        public AddMoveDeleteScheduleMenuWindow()
        {
            InitializeComponent();
        }
       
        //Set a boolean depending on option
        private void NewButton_Click(object sender, RoutedEventArgs e)
        {
            AppointmentDateSelectorWindow adsw = new AppointmentDateSelectorWindow();
            adsw.NewAppointment = true;
            adsw.Show();
            this.Close();
        }

        private void MoveButton_Click(object sender, RoutedEventArgs e)
        {
            AppointmentDateSelectorWindow adsw = new AppointmentDateSelectorWindow();
            adsw.MoveAppointment = true;
            adsw.Show();
            this.Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            AppointmentDateSelectorWindow adsw = new AppointmentDateSelectorWindow();
            adsw.CancelAppointment = true;
            adsw.Show();
            this.Close();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            
            ClientListWindow clw = new ClientListWindow();
            String test = SearchComboBox.Text;
            clw.SearchEntry = textBox.Text;

            if (SearchComboBox.Text.Contains("First Name"))
            {
                clw.SearchByFirst = true;
            }

            if (SearchComboBox.Text.Contains("Last Name"))
            {
                clw.SearchByLast = true;
            }

            if (SearchComboBox.Text.Contains("Full Name"))
            {
                clw.SearchByFull = true;
            }

            clw.Show();
            this.Close();
        }
    }
}
