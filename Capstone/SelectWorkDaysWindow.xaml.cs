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
    /// Interaction logic for OfficeHoursSetupWindow.xaml
    /// </summary>
    public partial class SelectWorkDaysWindow : MetroWindow
    {
        List<String> DaysSelected = new List<String>();

        public SelectWorkDaysWindow()
        {
            InitializeComponent();
        }

        private void checkBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private Boolean AtLeastOneDaySelected()
        {
            if(MondayCheckBox.IsChecked == false && TuesdayCheckBox.IsChecked == false &&
                WednesdayCheckBox.IsChecked == false && ThursdayCheckBox.IsChecked == false 
                && FridayCheckBox.IsChecked == false && SaturdayCheckBox.IsChecked == false
                && SundayCheckBox.IsChecked == false)
            {
                return false;
            }
            return true;
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            if(!AtLeastOneDaySelected())
            {
                MessageBox.Show("You need to select at least one day!");
            }else
            {
                if (SundayCheckBox.IsChecked == true)
                {
                    DaysSelected.Add("Sunday");
                }

                if (MondayCheckBox.IsChecked == true)
                {
                    DaysSelected.Add("Monday");
                }

                if (TuesdayCheckBox.IsChecked == true)
                {
                    DaysSelected.Add("Tuesday");
                }

                if (WednesdayCheckBox.IsChecked == true)
                {
                    DaysSelected.Add("Wednesday");
                }

                if (ThursdayCheckBox.IsChecked == true)
                {
                    DaysSelected.Add("Thursday");
                }

                if (FridayCheckBox.IsChecked == true)
                {
                    DaysSelected.Add("Friday");
                }

                if (SaturdayCheckBox.IsChecked == true)
                {
                    DaysSelected.Add("Saturday");
                }

                AppointmentHoursSetup adm = new AppointmentHoursSetup(DaysSelected);

                BusinessHoursWindow bhw = new BusinessHoursWindow();
                bhw.Show();
                this.Close();

            }
        }

        private void MF_Checked(object sender, RoutedEventArgs e)
        {
            //Check all the checkboxes M-F
            MondayCheckBox.IsChecked = true;
            TuesdayCheckBox.IsChecked = true;
            WednesdayCheckBox.IsChecked = true;
            ThursdayCheckBox.IsChecked = true;
            FridayCheckBox.IsChecked = true;

            //Make it so that the checkboxes cannot be unchecked while quick selected checkbox is checked
            MondayCheckBox.IsEnabled = false;
            TuesdayCheckBox.IsEnabled = false;
            WednesdayCheckBox.IsEnabled = false;
            ThursdayCheckBox.IsEnabled = false;
            FridayCheckBox.IsEnabled = false;
        }

        private void MF_Unchecked(object sender, RoutedEventArgs e)
        {
            MondayCheckBox.IsChecked = false;
            TuesdayCheckBox.IsChecked = false;
            WednesdayCheckBox.IsChecked = false;
            ThursdayCheckBox.IsChecked = false;
            FridayCheckBox.IsChecked = false;

            //Make it so that the checkboxes cannot be unchecked while quick selected checkbox is checked
            MondayCheckBox.IsEnabled = true;
            TuesdayCheckBox.IsEnabled = true;
            WednesdayCheckBox.IsEnabled = true;
            ThursdayCheckBox.IsEnabled = true;
            FridayCheckBox.IsEnabled = true;
        }
        private void SS_Checked(object sender, RoutedEventArgs e)
        {
            SundayCheckBox.IsChecked = true;
            SaturdayCheckBox.IsChecked = true;

            SundayCheckBox.IsEnabled = false;
            SaturdayCheckBox.IsEnabled = false;
        }

        private void SS_Unchecked(object sender, RoutedEventArgs e)
        {
            SundayCheckBox.IsChecked = false;
            SaturdayCheckBox.IsChecked = false;

            SundayCheckBox.IsEnabled = true;
            SaturdayCheckBox.IsEnabled = true;
        }

        
    }
}
