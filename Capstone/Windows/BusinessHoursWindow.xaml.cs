using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Globalization;
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
        private static OfficeHour[] OfficeHours;
        static int CurrentDay = 0;
        
        public BusinessHoursWindow()
        {
            InitializeComponent();
            AppointmentHoursSetup ahs = new AppointmentHoursSetup();
            OfficeHours = new OfficeHour[ahs.WorkDaysArrayReturn().Length];
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
            //1/8
            if (AppointmentHoursStartAMPM_ComboBox.Text.Equals("AM"))
            {
                if (AppointmentHoursStartHourComboBox.Text.Equals("12"))
                {
                    WorkDayStartHour = 0;
                }
                else
                {
                    WorkDayStartHour = int.Parse(AppointmentHoursStartHourComboBox.Text);
                }

                //P.M HOURS
            }
            else if (AppointmentHoursStartAMPM_ComboBox.Text.Equals("PM"))
            {
                if (AppointmentHoursStartHourComboBox.Text.Equals("12"))
                {
                    WorkDayStartHour = 12;
                }
                else
                {
                    WorkDayStartHour = 12 + int.Parse(AppointmentHoursStartHourComboBox.Text);
                }
            }

            //2/8
            WorkDayStartMinute = int.Parse(AppointmentHoursStartMinuteComboBox.Text);


            ////3/8
            if (AppointmentHoursEndAMPM_ComboBox.Text.Equals("AM"))
            {
                if (AppointmentHoursEndHourComboBox.Text.Equals("12"))
                {
                    WorkDayEndHour = 0;
                }
                else
                {
                    WorkDayEndHour = int.Parse(AppointmentHoursEndHourComboBox.Text);
                }

                //P.M HOURS
            }
            else if (AppointmentHoursEndAMPM_ComboBox.Text.Equals("PM"))
            {
                if (AppointmentHoursEndHourComboBox.Text.Equals("12"))
                {
                    WorkDayEndHour = 12;
                }
                else
                {
                    WorkDayEndHour = 12 + int.Parse(AppointmentHoursEndHourComboBox.Text);
                }
            }


            ////4/8
            WorkDayEndMinute = int.Parse(AppointmentHoursEndMinuteComboBox.Text);

            if (ReversedHoursError(WorkDayStartHour, WorkDayEndHour))
            {
                MessageBox.Show("Please check your work hours.");
                if (CurrentDay != 0)
                {
                    CurrentDay--;
                }
            }
            else if (SameTimeError(WorkDayStartHour, WorkDayStartMinute, WorkDayEndHour, WorkDayEndMinute))
            {
                MessageBox.Show("You can't schedule your appointment hours at the same time. Except for 24 hours (12A.M. - 12A.M.)");
                if (CurrentDay != 0)
                {
                    CurrentDay--;
                }
            }
            else
            {

                if (ClosedForLunchRadioButton.IsChecked == true)
                {
                    ////5/8
                    ////Lunch start
                    if (LunchHourStartAMPM_ComboBox.Text.Equals("AM"))
                    {
                        if (LunchHourStartHourComboBox.Text.Equals("12"))
                        {
                            LunchStartHour = 0;
                        }
                        else
                        {
                            LunchStartHour = int.Parse(LunchHourStartHourComboBox.Text);
                        }

                        //P.M HOURS
                    }
                    else if (LunchHourStartAMPM_ComboBox.Text.Equals("PM"))
                    {
                        if (LunchHourStartHourComboBox.Text.Equals("12"))
                        {
                            LunchStartHour = 12;
                        }
                        else
                        {
                            LunchStartHour = 12 + int.Parse(LunchHourStartHourComboBox.Text);
                        }
                    }


                    ////6/8
                    LunchStartMinute = int.Parse(LunchHourStartMinuteComboBox.Text);


                    ////Lunch End
                    ////7/8
                    if (LunchHourEndAMPM_ComboBox.Text.Equals("AM"))
                    {
                        if (LunchHourEndHourComboBox.Text.Equals("12"))
                        {
                            LunchEndHour = 0;
                        }
                        else
                        {
                            LunchEndHour = int.Parse(LunchHourEndHourComboBox.Text);
                        }

                        //P.M HOURS
                    }
                    else if (LunchHourEndAMPM_ComboBox.Text.Equals("PM"))
                    {
                        if (LunchHourEndHourComboBox.Text.Equals("12"))
                        {
                            LunchEndHour = 12;
                        }
                        else
                        {
                            LunchEndHour = 12 + int.Parse(LunchHourEndHourComboBox.Text);
                        }
                    }

                    ////8/8
                    LunchEndMinute = int.Parse(LunchHourEndMinuteComboBox.Text);

                    if (ReversedHoursError(LunchStartHour, LunchEndHour))
                    {
                        MessageBox.Show("Please check your lunch hours.");
                        if (CurrentDay != 0)
                        {
                            CurrentDay--;
                        }
                    }
                    else if (SameTimeError(LunchStartHour, LunchStartMinute, LunchEndHour, LunchEndMinute))
                    {
                        MessageBox.Show("You can't schedule your lunch hours at the same time.");
                        if (CurrentDay != 0)
                        {
                            CurrentDay--;
                        }
                    }
                }
            }

            bool tentativeDayChecked = TentativeDay_CheckBox.IsChecked == true;
            bool tentativeLunchHours = CloseForTentativeHoursRadioButton.IsChecked == true;

            if (CurrentDay != 0)
            {
                // Create OfficeHours
                if (ClosedForLunchRadioButton.IsChecked == true)
                {
                    OfficeHours[CurrentDay - 1] = new OfficeHour
                    {
                        DayID = CurrentDay,
                        DayName = DayLabel.Content.ToString(),
                        DayStart = new DateTime(1, 1, 1, WorkDayStartHour, WorkDayStartMinute, 0),
                        DayEnd = new DateTime(1, 1, 1, WorkDayEndHour, WorkDayEndMinute, 0),
                        LunchStart = new DateTime(1, 1, 1, LunchStartHour, LunchStartMinute, 0),
                        LunchEnd = new DateTime(1, 1, 1, LunchEndHour, LunchEndMinute, 0),
                        TentativeWorkingDay = tentativeDayChecked,
                        TentativeLunchHours = tentativeLunchHours
                    };
                }
                else
                {
                    OfficeHours[CurrentDay - 1] = new OfficeHour
                    {
                        DayID = CurrentDay,
                        DayName = DayLabel.Content.ToString(),
                        DayStart = new DateTime(1, 1, 1, WorkDayStartHour, WorkDayStartMinute, 0),
                        DayEnd = new DateTime(1, 1, 1, WorkDayEndHour, WorkDayEndMinute, 0),
                        TentativeLunchHours = tentativeLunchHours
                    };
                }
            }
            
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

        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            AppointmentHoursSetup ahs = new AppointmentHoursSetup();
            String[] AppointmentDays = ahs.WorkDaysArrayReturn();

            if (!WorkHoursSelected())
            {
                MessageBox.Show("Please select your work hours");
            }
            else if (WorkHoursSelected() && MustSelectLunchHours() && !LunchHoursSelected())
            {
                    MessageBox.Show("Please select your lunch hours");
            }
            else if (PMAMError() && MustSelectLunchHours())
            {
                MessageBox.Show("Your days may not overlap.");
            }else if(NoLunchOptionSelectedError())
            {
                MessageBox.Show("Please select an option for your lunch hours.");
            }
            else
            {
                //If valid buttons are pressed
                CreateWorkDay();

                if (CurrentDay == AppointmentDays.Length)
                {
                    MessageBox.Show("Setup complete. Returning to dashboard.");
                    PlanetVetEntities pve = new PlanetVetEntities();
                    foreach (OfficeHour odm in OfficeHours)
                    {
                        pve.OfficeHours.Add(odm);
                    }
                    pve.SaveChanges();

                    AddAllTimeSlots();
                    
                    PlanetVetWindow pvw = new PlanetVetWindow();
                    pvw.Show();
                    this.Close();
                }
                else
                {
                    AskForAppointmentDays();
                }
            }
        }

        public void AddAllTimeSlots()
        {
            PlanetVetEntities pve = new PlanetVetEntities();
            foreach (OfficeHour oh in pve.OfficeHours)
            {
                //Add timeslots per day
                AddTimeSlotPerDay(oh);
            }
        }

        private void AddTimeSlotPerDay(OfficeHour oh)
        {
            PlanetVetEntities pve = new PlanetVetEntities();

            DateTime DaySlot = oh.DayStart;
            DateTime DayEnds = oh.DayEnd;

            while (!(DaySlot > DayEnds))
            {
                pve.AppointmentSlots.Add(new AppointmentSlot()
                {
                    DayName = oh.DayName,
                    TimeSlot = DaySlot,
                    TimeParsed = DaySlot.ToString("hh:mm tt", CultureInfo.InvariantCulture)
                });
                DaySlot = DaySlot.AddMinutes(10);
            }
            pve.SaveChanges();
        }

        private void PreviousButton_Click(object sender, RoutedEventArgs e)
        {
            CurrentDay -= 2;
            AskForAppointmentDays();
        }

        private bool NoLunchOptionSelectedError()
        {
            if (ClosedForLunchRadioButton.IsChecked == false && NoLunchBreaksRadioButton.IsChecked == false && ScheduledLunchRadioButton.IsChecked == false && CloseForTentativeHoursRadioButton.IsChecked == false)
                return true;

            return false;
        }

        private bool PMAMError()
        {
            if(AppointmentHoursStartAMPM_ComboBox.Text.Equals("PM") && AppointmentHoursEndAMPM_ComboBox.Text.Equals("AM") && !AppointmentHoursEndHourComboBox.Text.Equals("12"))
                return true;

            if (LunchHourStartAMPM_ComboBox.Text.Equals("PM") && LunchHourEndAMPM_ComboBox.Text.Equals("AM") && !LunchHourEndHourComboBox.Text.Equals("12"))
                return true;

          return false;
        }

        private bool ReversedHoursError(int StartHour, int EndHour)
        {
            if(EndHour < StartHour && EndHour != 0)
            {
                return true; 
            }
            return false;
        }

        private bool LunchHoursSelected()
        {
            if(LunchHourStartHourComboBox.Text.Equals("") || LunchHourStartMinuteComboBox.Text.Equals("") || LunchHourStartAMPM_ComboBox.Text.Equals("")
                || LunchHourEndHourComboBox.Text.Equals("") || LunchHourEndMinuteComboBox.Text.Equals("") || LunchHourEndAMPM_ComboBox.Text.Equals(""))
            {
                return false;
            }
            return true;
        }

        private bool WorkHoursSelected()
        {
            if(AppointmentHoursStartHourComboBox.Text.Equals("") || AppointmentHoursStartMinuteComboBox.Text.Equals("") || AppointmentHoursStartAMPM_ComboBox.Text.Equals("")
                || AppointmentHoursEndHourComboBox.Text.Equals("") || AppointmentHoursEndMinuteComboBox.Text.Equals("") || AppointmentHoursEndAMPM_ComboBox.Text.Equals(""))
            {
                return false;
            }
            return true;
        }
            
        private bool MustSelectLunchHours()
        {
            if(ClosedForLunchRadioButton.IsChecked == true)
            {
                return true;
            }

            return false;
        }

        private bool SameTimeError(int StartHour, int StartMinute, int EndHour, int EndMinute)
        {
            //24 hrs
            if (StartHour == 0 && EndHour == 0 && StartMinute == 0 && EndMinute == 0)
            {
                return false;
            }
            if(StartHour == EndHour && StartMinute == EndMinute)
            {
                return true;    
            }
            return false;
        }       
    }
}
