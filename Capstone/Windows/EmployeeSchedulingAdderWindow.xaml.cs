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
    /// Interaction logic for EmployeeSchedulingAdderWindow.xaml
    /// </summary>
    public partial class EmployeeSchedulingAdderWindow : MetroWindow
    {
        public static String SelectedDayOfWeek { get; set; }
        public static DateTime SelectedDate { get; set; }
        //SUN - 0
        //SAT - 6
        public EmployeeSchedulingAdderWindow()
        {
            InitializeComponent();
            FillEmployeeComboBox();
        }

        private void FillEmployeeComboBox()
        {
            try {
                PlanetVetEntities pve = new PlanetVetEntities();
                foreach (Employee emp in pve.Employees)
                {
                    if (emp.IsDoctor)
                    {
                        EmployeeComboBox.Items.Add(emp.FirstName + " " + emp.LastName);
                    }
                }

                OfficeHour oh = pve.OfficeHours.Where(offhr => offhr.DayName.Equals(SelectedDayOfWeek)).FirstOrDefault();
                if(oh == null)
                {
                    MessageBox.Show("You are not open on this day. Please reconfigure your business hours to make changes.");
                    this.Close();
                }else
                {

                }

            }catch
            {

            }
       }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            CreateEmployeeSchedule();
        }

        int WorkDayStartHour;
        int WorkDayStartMinute;

        int WorkDayEndHour;
        int WorkDayEndMinute;

        private void CreateEmployeeSchedule()
        {
            PlanetVetEntities pve = new PlanetVetEntities();
            //1/8
            if (StartAMPM_ComboBox.Text.Equals("AM"))
            {
                if (StartHourComboBox.Text.Equals("12"))
                {
                    WorkDayStartHour = 0;
                }
                else
                {
                    WorkDayStartHour = int.Parse(StartHourComboBox.Text);
                }

                //P.M HOURS
            }
            else if (StartHourComboBox.Text.Equals("PM"))
            {
                if (StartHourComboBox.Text.Equals("12"))
                {
                    WorkDayStartHour = 12;
                }
                else
                {
                    WorkDayStartHour = 12 + int.Parse(StartHourComboBox.Text);
                }
            }

            //2/8
            WorkDayStartMinute = int.Parse(StartMinuteComboBox.Text);


            ////3/8
            if (EndAMPM_ComboBox.Text.Equals("AM"))
            {
                if (EndHourComboBox.Text.Equals("12"))
                {
                    WorkDayEndHour = 0;
                }
                else
                {
                    WorkDayEndHour = int.Parse(EndHourComboBox.Text);
                }

                //P.M HOURS
            }
            else if (EndAMPM_ComboBox.Text.Equals("PM"))
            {
                if (EndHourComboBox.Text.Equals("12"))
                {
                    WorkDayEndHour = 12;
                }
                else
                {
                    WorkDayEndHour = 12 + int.Parse(EndHourComboBox.Text);
                }
            }


            ////4/8
            WorkDayEndMinute = int.Parse(EndMinuteComboBox.Text);

            //Get employee
            String[] EmployeeName = EmployeeComboBox.Text.Split(' ');
            String FirstName = EmployeeName[0];
            String LastName = EmployeeName[1];
            Employee e = pve.Employees.Where(emp => emp.FirstName.Equals(FirstName) && emp.LastName.Equals(LastName)).FirstOrDefault();


            pve.EmployeeSchedules.Add(new EmployeeSchedule()
            {
                Date = SelectedDate,
                TimeStart = new DateTime(SelectedDate.Year, SelectedDate.Month, SelectedDate.Day, WorkDayStartHour, WorkDayStartMinute, 0),
                TimeEnd = new DateTime(SelectedDate.Year, SelectedDate.Month, SelectedDate.Day, WorkDayEndHour, WorkDayEndMinute, 0),
                EmployeeID = e.EmployeeId,
                EmployeeFirstName = FirstName,
                EmployeeLastName = LastName
            });

            pve.SaveChanges();
            this.Close();
        }
    }
}
