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
    /// Interaction logic for EmployeeSchedulingWindow.xaml
    /// </summary>
    public partial class EmployeeSchedulingWindow : MetroWindow
    {
        public EmployeeSchedulingWindow()
        {
            InitializeComponent();
        }

        private void DatePickerCalendar_CalendarOpened(object sender, RoutedEventArgs e)
        {
            DatePickerCalendar.DisplayDateStart = DateTime.Now.AddYears(-1);
            DatePickerCalendar.DisplayDateEnd = DateTime.Now + TimeSpan.FromDays(500);

            var minDate = DatePickerCalendar.DisplayDateStart ?? DateTime.MinValue;
            var maxDate = DatePickerCalendar.DisplayDateEnd ?? DateTime.MaxValue;

            for (var d = minDate; d <= maxDate && DateTime.MaxValue > d; d = d.AddDays(1))
            {
                if (!(d.DayOfWeek.ToString().Equals("Sunday")))
                {
                    DatePickerCalendar.BlackoutDates.Add(new CalendarDateRange(d));
                }
            }
        }

        List<DateTime> SelectedDays = new List<DateTime>();
        private void DatePickerCalendar_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                SelectedDays.Clear();
                DateTime dt = DatePickerCalendar.SelectedDate.Value;
                DateTime WeeksEnd = dt.AddDays(6);

                //Cycle through Sunday > Saturday
                //Insert appts per day into the correlating datagrid
                PlanetVetEntities pve = new PlanetVetEntities();
                for (var d = dt; d <= WeeksEnd && DateTime.MaxValue > d; d = d.AddDays(1))
                {
                    List<EmployeeSchedule> EmployeeScheduleForThisDay = pve.EmployeeSchedules.Where(empsch => empsch.Date.Value.Year == d.Year &&
                                                                                   empsch.Date.Value.Month == d.Month &&
                                                                                   empsch.Date.Value.Day == d.Day).ToList();
                    SelectedDays.Add(d);

                    if (d.DayOfWeek.ToString().Equals("Sunday"))
                    {
                        SundayDataGrid.ItemsSource = EmployeeScheduleForThisDay;
                        SundayDataGrid.Columns.Remove(SundayDataGrid.Columns[0]);
                        SundayDataGrid.Columns[1].Header = "Shift Start";
                        SundayDataGrid.Columns[2].Header = "Shift End";
                        SundayDataGrid.Columns.Remove(SundayDataGrid.Columns[3]);
                    }
                    else if (d.DayOfWeek.ToString().Equals("Monday"))
                    {
                        MondayDataGrid.ItemsSource = EmployeeScheduleForThisDay;

                        MondayDataGrid.Columns.Remove(MondayDataGrid.Columns[0]);
                        MondayDataGrid.Columns[1].Header = "Shift Start";
                        MondayDataGrid.Columns[2].Header = "Shift End";
                        MondayDataGrid.Columns.Remove(MondayDataGrid.Columns[3]);
                    }
                    else if (d.DayOfWeek.ToString().Equals("Tuesday"))
                    {
                        TuesdayDataGrid.ItemsSource = EmployeeScheduleForThisDay;
                        TuesdayDataGrid.Columns.Remove(TuesdayDataGrid.Columns[0]);
                        TuesdayDataGrid.Columns[1].Header = "Shift Start";
                        TuesdayDataGrid.Columns[2].Header = "Shift End";
                        TuesdayDataGrid.Columns.Remove(TuesdayDataGrid.Columns[3]);
                    }
                    else if (d.DayOfWeek.ToString().Equals("Wednesday"))
                    {
                        WednesdayDataGrid.ItemsSource = EmployeeScheduleForThisDay;
                        WednesdayDataGrid.Columns.Remove(WednesdayDataGrid.Columns[0]);
                        WednesdayDataGrid.Columns[1].Header = "Shift Start";
                        WednesdayDataGrid.Columns[2].Header = "Shift End";
                        WednesdayDataGrid.Columns.Remove(WednesdayDataGrid.Columns[3]);
                    }
                    else if (d.DayOfWeek.ToString().Equals("Thursday"))
                    {
                        ThursdayDataGrid.ItemsSource = EmployeeScheduleForThisDay;
                        ThursdayDataGrid.Columns.Remove(ThursdayDataGrid.Columns[0]);
                        ThursdayDataGrid.Columns[1].Header = "Shift Start";
                        ThursdayDataGrid.Columns[2].Header = "Shift End";
                        ThursdayDataGrid.Columns.Remove(ThursdayDataGrid.Columns[3]);
                    }
                    else if (d.DayOfWeek.ToString().Equals("Friday"))
                    {
                        FridayDataGrid.ItemsSource = EmployeeScheduleForThisDay;
                        FridayDataGrid.Columns.Remove(FridayDataGrid.Columns[0]);
                        FridayDataGrid.Columns[1].Header = "Shift Start";
                        FridayDataGrid.Columns[2].Header = "Shift End";
                        FridayDataGrid.Columns.Remove(FridayDataGrid.Columns[3]);
                    }
                    else if (d.DayOfWeek.ToString().Equals("Saturday"))
                    {
                        SaturdayDataGrid.ItemsSource = EmployeeScheduleForThisDay;
                        SaturdayDataGrid.Columns.Remove(FridayDataGrid.Columns[0]);
                        SaturdayDataGrid.Columns[1].Header = "Shift Start";
                        SaturdayDataGrid.Columns[2].Header = "Shift End";
                        SaturdayDataGrid.Columns.Remove(FridayDataGrid.Columns[3]);
                    }

                }
                //List starts at 0
            }catch
            {

            }
            
            
            }


        private void RefreshDataGrids()
        {
            SelectedDays.Clear();
            DateTime dt = DatePickerCalendar.SelectedDate.Value;
            DateTime WeeksEnd = dt.AddDays(6);

            //Cycle through Sunday > Saturday
            //Insert appts per day into the correlating datagrid
            PlanetVetEntities pve = new PlanetVetEntities();
            for (var d = dt; d <= WeeksEnd && DateTime.MaxValue > d; d = d.AddDays(1))
            {
                List<EmployeeSchedule> EmployeeScheduleForThisDay = pve.EmployeeSchedules.Where(empsch => empsch.Date.Value.Year == d.Year &&
                                                                               empsch.Date.Value.Month == d.Month &&
                                                                               empsch.Date.Value.Day == d.Day).ToList();
                SelectedDays.Add(d);

                if (d.DayOfWeek.ToString().Equals("Sunday"))
                {
                    SundayDataGrid.ItemsSource = EmployeeScheduleForThisDay;
                    SundayDataGrid.Columns.Remove(SundayDataGrid.Columns[0]);
                    SundayDataGrid.Columns[1].Header = "Shift Start";
                    SundayDataGrid.Columns[2].Header = "Shift End";
                    SundayDataGrid.Columns.Remove(SundayDataGrid.Columns[3]);
                }
                else if (d.DayOfWeek.ToString().Equals("Monday"))
                {
                    MondayDataGrid.ItemsSource = EmployeeScheduleForThisDay;

                    MondayDataGrid.Columns.Remove(MondayDataGrid.Columns[0]);
                    MondayDataGrid.Columns[1].Header = "Shift Start";
                    MondayDataGrid.Columns[2].Header = "Shift End";
                    MondayDataGrid.Columns.Remove(MondayDataGrid.Columns[3]);
                }
                else if (d.DayOfWeek.ToString().Equals("Tuesday"))
                {
                    TuesdayDataGrid.ItemsSource = EmployeeScheduleForThisDay;
                    TuesdayDataGrid.Columns.Remove(TuesdayDataGrid.Columns[0]);
                    TuesdayDataGrid.Columns[1].Header = "Shift Start";
                    TuesdayDataGrid.Columns[2].Header = "Shift End";
                    TuesdayDataGrid.Columns.Remove(TuesdayDataGrid.Columns[3]);
                }
                else if (d.DayOfWeek.ToString().Equals("Wednesday"))
                {
                    WednesdayDataGrid.ItemsSource = EmployeeScheduleForThisDay;
                    WednesdayDataGrid.Columns.Remove(WednesdayDataGrid.Columns[0]);
                    WednesdayDataGrid.Columns[1].Header = "Shift Start";
                    WednesdayDataGrid.Columns[2].Header = "Shift End";
                    WednesdayDataGrid.Columns.Remove(WednesdayDataGrid.Columns[3]);
                }
                else if (d.DayOfWeek.ToString().Equals("Thursday"))
                {
                    ThursdayDataGrid.ItemsSource = EmployeeScheduleForThisDay;
                    ThursdayDataGrid.Columns.Remove(ThursdayDataGrid.Columns[0]);
                    ThursdayDataGrid.Columns[1].Header = "Shift Start";
                    ThursdayDataGrid.Columns[2].Header = "Shift End";
                    ThursdayDataGrid.Columns.Remove(ThursdayDataGrid.Columns[3]);
                }
                else if (d.DayOfWeek.ToString().Equals("Friday"))
                {
                    FridayDataGrid.ItemsSource = EmployeeScheduleForThisDay;
                    FridayDataGrid.Columns.Remove(FridayDataGrid.Columns[0]);
                    FridayDataGrid.Columns[1].Header = "Shift Start";
                    FridayDataGrid.Columns[2].Header = "Shift End";
                    FridayDataGrid.Columns.Remove(FridayDataGrid.Columns[3]);
                }
                else if (d.DayOfWeek.ToString().Equals("Saturday"))
                {
                    SaturdayDataGrid.ItemsSource = EmployeeScheduleForThisDay;
                    SaturdayDataGrid.Columns.Remove(FridayDataGrid.Columns[0]);
                    SaturdayDataGrid.Columns[1].Header = "Shift Start";
                    SaturdayDataGrid.Columns[2].Header = "Shift End";
                    SaturdayDataGrid.Columns.Remove(FridayDataGrid.Columns[3]);
                }
            }
        }

        private void SundayAddButton_Click(object sender, RoutedEventArgs e)
        {
            EmployeeSchedulingAdderWindow.SelectedDayOfWeek = "Sunday";
            EmployeeSchedulingAdderWindow.SelectedDate = SelectedDays[0];
            EmployeeSchedulingAdderWindow esaw = new EmployeeSchedulingAdderWindow();
            esaw.ShowDialog();
            RefreshDataGrids();
        }

        private void MondayAddButton_Click(object sender, RoutedEventArgs e)
        {
            EmployeeSchedulingAdderWindow.SelectedDayOfWeek = "Monday";
            EmployeeSchedulingAdderWindow.SelectedDate = SelectedDays[1];
            EmployeeSchedulingAdderWindow esaw = new EmployeeSchedulingAdderWindow();
            esaw.ShowDialog();
            RefreshDataGrids();
        }

        private void TuesdayAddButton_Click(object sender, RoutedEventArgs e)
        {
            EmployeeSchedulingAdderWindow.SelectedDayOfWeek = "Tuesday";
            EmployeeSchedulingAdderWindow.SelectedDate = SelectedDays[2];
            EmployeeSchedulingAdderWindow esaw = new EmployeeSchedulingAdderWindow();
            esaw.ShowDialog();
            RefreshDataGrids();
        }

        private void WednesdayAddButton_Click(object sender, RoutedEventArgs e)
        {
            EmployeeSchedulingAdderWindow.SelectedDayOfWeek = "Wednesday";
            EmployeeSchedulingAdderWindow.SelectedDate = SelectedDays[3];
            EmployeeSchedulingAdderWindow esaw = new EmployeeSchedulingAdderWindow();
            esaw.ShowDialog();
            RefreshDataGrids();
        }

        private void ThursdayAddButton_Click(object sender, RoutedEventArgs e)
        {
            EmployeeSchedulingAdderWindow.SelectedDayOfWeek = "Thursday";
            EmployeeSchedulingAdderWindow.SelectedDate = SelectedDays[4];
            EmployeeSchedulingAdderWindow esaw = new EmployeeSchedulingAdderWindow();
            esaw.ShowDialog();
            RefreshDataGrids();
        }

        private void FridayAddButton_Click(object sender, RoutedEventArgs e)
        {
            EmployeeSchedulingAdderWindow.SelectedDayOfWeek = "Friday";
            EmployeeSchedulingAdderWindow.SelectedDate = SelectedDays[5];
            EmployeeSchedulingAdderWindow esaw = new EmployeeSchedulingAdderWindow();
            esaw.ShowDialog();
            RefreshDataGrids();
        }

        private void SaturdayAddButton_Click(object sender, RoutedEventArgs e)
        {
            EmployeeSchedulingAdderWindow.SelectedDayOfWeek = "Saturday";
            EmployeeSchedulingAdderWindow.SelectedDate = SelectedDays[6];
            EmployeeSchedulingAdderWindow esaw = new EmployeeSchedulingAdderWindow();
            esaw.ShowDialog();
            RefreshDataGrids();
        }

        private void SundayDataGrid_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                SundayDataGrid.CommitEdit();
            }
            catch
            {

            }
            }

        private void MondayDataGrid_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                MondayDataGrid.CommitEdit();
            }
            catch
            {

            }
            }

        private void TuesdayDataGrid_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                TuesdayDataGrid.CommitEdit();
            }
            catch
            {

            }
            }

        private void WednesdayDataGrid_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                WednesdayDataGrid.CommitEdit();
            }
            catch
            {

            }
            }

        private void ThursdayDataGrid_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                ThursdayDataGrid.CommitEdit();
            }
            catch
            {

            }
            }

        private void FridayDataGrid_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                FridayDataGrid.CommitEdit();
            }
            catch
            {

            }
            }

        private void SaturdayDataGrid_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                SaturdayDataGrid.CommitEdit();
            }
            catch
            {

            }
            }

        private void BackToDashboardButton_Click(object sender, RoutedEventArgs e)
        {
            PlanetVetWindow pvw = new PlanetVetWindow();
            pvw.Show();
            this.Close();
        }

        private void SundayDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PlanetVetEntities pve = new PlanetVetEntities();
                EmployeeSchedule es = (EmployeeSchedule)SundayDataGrid.SelectedItem;
                pve.EmployeeSchedules.Attach(es);
                pve.EmployeeSchedules.Remove(es);
                pve.SaveChanges();
                RefreshDataGrids();
            }
            catch
            {

            }
            }

        private void MondayDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PlanetVetEntities pve = new PlanetVetEntities();
                EmployeeSchedule es = (EmployeeSchedule)MondayDataGrid.SelectedItem;
                pve.EmployeeSchedules.Attach(es);
                pve.EmployeeSchedules.Remove(es);
                pve.SaveChanges();
                RefreshDataGrids();
            }
            catch
            {

            }
        }

        private void TuesdayDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PlanetVetEntities pve = new PlanetVetEntities();
                EmployeeSchedule es = (EmployeeSchedule)TuesdayDataGrid.SelectedItem;
                pve.EmployeeSchedules.Attach(es);
                pve.EmployeeSchedules.Remove(es);
                pve.SaveChanges();
                RefreshDataGrids();
            }
            catch
            {

            }
        }

        private void WednesdayDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PlanetVetEntities pve = new PlanetVetEntities();
                EmployeeSchedule es = (EmployeeSchedule)WednesdayDataGrid.SelectedItem;
                pve.EmployeeSchedules.Attach(es);
                pve.EmployeeSchedules.Remove(es);
                pve.SaveChanges();
                RefreshDataGrids();
            }
            catch
            {

            }
        }

        private void ThursdayDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PlanetVetEntities pve = new PlanetVetEntities();
                EmployeeSchedule es = (EmployeeSchedule)ThursdayDataGrid.SelectedItem;
                pve.EmployeeSchedules.Attach(es);
                pve.EmployeeSchedules.Remove(es);
                pve.SaveChanges();
                RefreshDataGrids();
            }
            catch
            {

            }
        }

        private void FridayDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PlanetVetEntities pve = new PlanetVetEntities();
                EmployeeSchedule es = (EmployeeSchedule)FridayDataGrid.SelectedItem;
                pve.EmployeeSchedules.Attach(es);
                pve.EmployeeSchedules.Remove(es);
                pve.SaveChanges();
                RefreshDataGrids();
            }
            catch
            {

            }
        }

        private void SaturdayDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PlanetVetEntities pve = new PlanetVetEntities();
                EmployeeSchedule es = (EmployeeSchedule)SaturdayDataGrid.SelectedItem;
                pve.EmployeeSchedules.Attach(es);
                pve.EmployeeSchedules.Remove(es);
                pve.SaveChanges();
                RefreshDataGrids();
            }
            catch
            {

            }
        }
    }
}
