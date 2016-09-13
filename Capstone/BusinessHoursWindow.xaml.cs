using Capstone.DataModels;
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
    /// Interaction logic for BusinessHoursWindow.xaml
    /// </summary>
    public partial class BusinessHoursWindow : MetroWindow
    {
        private static OfficeDayModel[] OfficeHours;
        static int CurrentDay = 0;
        
        public BusinessHoursWindow()
        {
            InitializeComponent();
            AppointmentHoursSetup ahs = new AppointmentHoursSetup();
            OfficeHours = new OfficeDayModel[ahs.WorkDaysArrayReturn().Length];
            AskForAppointmentDays();
        }

        public void AskForAppointmentDays()
        {
            AppointmentHoursSetup ahs = new AppointmentHoursSetup();
            String[] AppointmentDays = ahs.WorkDaysArrayReturn();
            DayLabel.Content = AppointmentDays[CurrentDay];
            LunchDayLabel.Content = AppointmentDays[CurrentDay] + "?";

            if (CurrentDay == 0)
            {
                PreviousButton.Content = "";
                PreviousButton.IsEnabled = false;
            }else
            {
                PreviousButton.Content = "Previous";
                PreviousButton.IsEnabled = true;
            }

            CurrentDay++;
        }


        int WorkDayStartHour;
        int WorkDayStartMinute;

        int WorkDayEndHour;
        int WorkDayEndMinute;

        int LunchStartHour;
        int LunchStartMinute;

        int LunchEndHour;
        int LunchEndMinute;

        private void CreateWorkDay()
        {
            WorkDayStartHour = int.Parse(AppointmentHoursStartHourComboBox.SelectedItem.ToString());

            //1/8
            if (AppointmentHoursStartAMPM_ComboBox.SelectedItem.ToString().Equals("AM"))
            {
                if (AppointmentHoursStartHourComboBox.SelectedItem.ToString().Equals("12"))
                {
                    WorkDayStartHour = 0;
                }
                else
                {
                    WorkDayStartHour = int.Parse(AppointmentHoursStartHourComboBox.SelectedItem.ToString());
                }

                //P.M HOURS
            }
            else if (AppointmentHoursStartAMPM_ComboBox.SelectedItem.ToString().Equals("PM"))
            {
                if (AppointmentHoursStartHourComboBox.SelectedItem.ToString().Equals("12"))
                {
                    WorkDayStartHour = 12;
                }
                else
                {
                    WorkDayStartHour = 12 + int.Parse(AppointmentHoursStartHourComboBox.SelectedItem.ToString());
                }
            }
            TestLabel.Content = WorkDayStartHour.ToString();

            //2/8
            //WorkDayStartMinute = int.Parse(AppointmentHoursStartHourComboBox.SelectedItem.ToString());


            ////3/8
            //if (AppointmentHoursEndAMPM_ComboBox.SelectedItem.ToString().Equals("AM"))
            //{
            //    if (AppointmentHoursEndHourComboBox.SelectedItem.ToString().Equals("12"))
            //    {
            //        WorkDayEndHour = 0;
            //    }
            //    else
            //    {
            //        WorkDayEndHour = int.Parse(AppointmentHoursEndHourComboBox.SelectedItem.ToString());
            //    }

            //    //P.M HOURS
            //}
            //else if (AppointmentHoursEndAMPM_ComboBox.SelectedItem.ToString().Equals("PM"))
            //{
            //    if (AppointmentHoursEndHourComboBox.SelectedItem.ToString().Equals("12"))
            //    {
            //        WorkDayEndHour = 12;
            //    }
            //    else
            //    {
            //        WorkDayEndHour = 12 + int.Parse(AppointmentHoursEndHourComboBox.SelectedItem.ToString());
            //    }
            //}


            ////4/8
            //WorkDayEndMinute = int.Parse(AppointmentHoursEndMinuteComboBox.SelectedItem.ToString());


            ////5/8
            ////Lunch start
            //if (LunchHourStartAMPM_ComboBox.SelectedItem.ToString().Equals("AM"))
            //{
            //    if (LunchHourStartHourComboBox.SelectedItem.ToString().Equals("12"))
            //    {
            //        LunchStartHour = 0;
            //    }
            //    else
            //    {
            //        LunchStartHour = int.Parse(LunchHourStartHourComboBox.SelectedItem.ToString());
            //    }

            //    //P.M HOURS
            //}
            //else if (LunchHourStartAMPM_ComboBox.SelectedItem.ToString().Equals("PM"))
            //{
            //    if (LunchHourStartHourComboBox.SelectedItem.ToString().Equals("12"))
            //    {
            //        LunchStartHour = 12;
            //    }
            //    else
            //    {
            //        WorkDayEndHour = 12 + int.Parse(LunchHourStartHourComboBox.SelectedItem.ToString());
            //    }
            //}


            ////6/8
            //LunchStartMinute = int.Parse(LunchHourStartMinuteComboBox.SelectedItem.ToString());


            ////Lunch End
            ////7/8
            //if (LunchHourEndAMPM_ComboBox.SelectedItem.ToString().Equals("AM"))
            //{
            //    if (LunchHourEndHourComboBox.SelectedItem.ToString().Equals("12"))
            //    {
            //        LunchEndHour = 0;
            //    }
            //    else
            //    {
            //        LunchEndHour = int.Parse(LunchHourEndHourComboBox.SelectedItem.ToString());
            //    }

            //    //P.M HOURS
            //}
            //else if (LunchHourEndAMPM_ComboBox.SelectedItem.ToString().Equals("PM"))
            //{
            //    if (LunchHourEndHourComboBox.SelectedItem.ToString().Equals("12"))
            //    {
            //        LunchStartHour = 12;
            //    }
            //    else
            //    {
            //        LunchStartHour = 12 + int.Parse(LunchHourEndHourComboBox.SelectedItem.ToString());
            //    }
            //}

            ////8/8
            //LunchEndMinute = int.Parse(LunchHourEndMinuteComboBox.SelectedItem.ToString());

            //bool tentativeDayChecked = TentativeDay_CheckBox.IsChecked == true;

            //Create OfficeHours
            //OfficeHours[CurrentDay] = new OfficeDayModel
            //{
            //    DayID = CurrentDay,
            //    DayName = DayLabel.Content.ToString(),
            //    DayStart = new DateTime(0, 0, 0, WorkDayStartHour, WorkDayStartMinute, 0),
            //    DayEnd = new DateTime(0, 0, 0, WorkDayEndHour, WorkDayEndMinute, 0),
            //    LunchStart = new DateTime(0, 0, 0, LunchStartHour, LunchStartMinute, 0),
            //    LunchEnd = new DateTime(0, 0, 0, LunchEndHour, LunchEndMinute, 0),
            //    TentativeDay = tentativeDayChecked
            //};
        }

        private void NoLunchBreaksButton_Checked(object sender, RoutedEventArgs e)
        {
            LunchHoursLabel.Content = "No lunch hours to schedule for this day";

            //Disable combo boxes
            LunchHourStartAMPM_ComboBox.IsEnabled = false;
            LunchHourStartHourComboBox.IsEnabled = false;
            LunchHourStartMinuteComboBox.IsEnabled = false;

            LunchHourEndAMPM_ComboBox.IsEnabled = false;
            LunchHourEndHourComboBox.IsEnabled = false;
            LunchHourEndMinuteComboBox.IsEnabled = false;

            LunchHourApplyBox.IsEnabled = false;
        }

        private void radioButton_Copy_Checked(object sender, RoutedEventArgs e)
        {
            LunchHoursLabel.Content = "No lunch hours to schedule for this day";

            //Disable combo boxes
            LunchHourStartAMPM_ComboBox.IsEnabled = false;
            LunchHourStartHourComboBox.IsEnabled = false;
            LunchHourStartMinuteComboBox.IsEnabled = false;

            LunchHourEndAMPM_ComboBox.IsEnabled = false;
            LunchHourEndHourComboBox.IsEnabled = false;
            LunchHourEndMinuteComboBox.IsEnabled = false;

            LunchHourApplyBox.IsEnabled = false;
        }

        private void radioButton_Checked(object sender, RoutedEventArgs e)
        {
            LunchHoursLabel.Content = "Lunch hours";

            //Disable combo boxes
            LunchHourStartAMPM_ComboBox.IsEnabled = true;
            LunchHourStartHourComboBox.IsEnabled = true;
            LunchHourStartMinuteComboBox.IsEnabled = true;

            LunchHourEndAMPM_ComboBox.IsEnabled = true;
            LunchHourEndHourComboBox.IsEnabled = true;
            LunchHourEndMinuteComboBox.IsEnabled = true;

            LunchHourApplyBox.IsEnabled = true;
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            AppointmentHoursSetup ahs = new AppointmentHoursSetup();
            String[] AppointmentDays = ahs.WorkDaysArrayReturn();

            //If valid buttons are pressed
            CreateWorkDay();
            
            if (CurrentDay == AppointmentDays.Length)
            {
                MessageBox.Show("Thank you!");
            }
            else
            {
                AskForAppointmentDays();
            }
        }

        private void PreviousButton_Click(object sender, RoutedEventArgs e)
        {
            CurrentDay -= 2;
            AskForAppointmentDays();
        }

        private bool MustSelectLunchHours()
        {
            if(ClosedForLunchRadioButton.IsChecked == true)
            {
                return true;
            }

            return false;
        }

        private bool CanProceedToNextWorkDay()
        {

            return false;
        }
       
    }
}
