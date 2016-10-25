using Capstone.Authentication;
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
    /// Interaction logic for ClockInOutWindow.xaml
    /// </summary>
    public partial class ClockInOutWindow : MetroWindow
    {
        public ClockInOutWindow()
        {
            InitializeComponent();
            AdjustButtons();
        }

        private void AdjustButtons()
        {
            PlanetVetEntities pve = new PlanetVetEntities();
            Employee e = pve.Employees.Where(em => em.Username.Equals(SessionData.CurrentUser.UserName)).FirstOrDefault();
            Boolean isWorking = e.IsWorking;
            Boolean isOnLunchBreak = e.IsOnLunchBreak;

            if (!isWorking && !isOnLunchBreak)
            {
                ClockOutButton.IsEnabled = false;
                LunchEndButton.IsEnabled = false;
                LunchStartButton.IsEnabled = false;
            }
            else if(isOnLunchBreak)
            {
                ClockInButton.IsEnabled = false;
                ClockOutButton.IsEnabled = false;
                LunchStartButton.IsEnabled = false;
                LunchEndButton.IsEnabled = true;
            }else if(isWorking)
            {
                ClockInButton.IsEnabled = false;
                ClockOutButton.IsEnabled = true;
                LunchEndButton.IsEnabled = false;
                LunchStartButton.IsEnabled = true;
            }
        }

        private void DashBoardButton_Click(object sender, RoutedEventArgs e)
        {
            PlanetVetWindow pvw = new PlanetVetWindow();
            pvw.Show();
            this.Close();
        }

        private void ClockInButton_Click(object sender, RoutedEventArgs e)
        {
            PlanetVetEntities pve = new PlanetVetEntities();
            Employee emp = pve.Employees.Where(em => em.Username.Equals(SessionData.CurrentUser.UserName)).FirstOrDefault();
            emp.IsWorking = true;

            EmployeeWorkHourLog ewhl = new EmployeeWorkHourLog();
            ewhl.Clock_In = DateTime.Now;
            ewhl.EmployeeID = emp.EmployeeId;
            pve.EmployeeWorkHourLogs.Add(ewhl);
            pve.SaveChanges();

            MessageBox.Show("Clocked in at: " + ewhl.Clock_In);
            AdjustButtons();

        }

        private void ClockOutButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PlanetVetEntities pve = new PlanetVetEntities();
                Employee emp = pve.Employees.Where(em => em.Username.Equals(SessionData.CurrentUser.UserName)).FirstOrDefault();
                EmployeeWorkHourLog ewhl = pve.EmployeeWorkHourLogs.Where(worklog => worklog.EmployeeID == emp.EmployeeId && worklog.Clock_Out == null).FirstOrDefault();
                pve.EmployeeWorkHourLogs.Attach(ewhl);
                ewhl.Clock_Out = DateTime.Now;
                pve.Entry(ewhl).State = System.Data.Entity.EntityState.Modified;
                pve.SaveChanges();

                MessageBox.Show("Clocked out at: " + ewhl.Clock_Out);
                pve.Employees.Attach(emp);
                emp.IsOnLunchBreak = false;
                emp.IsWorking = false;
                pve.Entry(emp).State = System.Data.Entity.EntityState.Modified;
                pve.SaveChanges();

                PlanetVetWindow pvw = new PlanetVetWindow();
                pvw.Show();
                this.Close();
            }
            catch
            {

            }
        }

        private void LunchStartButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PlanetVetEntities pve = new PlanetVetEntities();
                Employee emp = pve.Employees.Where(em => em.Username.Equals(SessionData.CurrentUser.UserName)).FirstOrDefault();
                EmployeeWorkHourLog ewhl = pve.EmployeeWorkHourLogs.Where(worklog => worklog.EmployeeID == emp.EmployeeId && worklog.Clock_Out == null).FirstOrDefault();


                if (ewhl != null && ewhl.LunchStart == null)
                {
                    pve.EmployeeWorkHourLogs.Attach(ewhl);
                    ewhl.LunchStart = DateTime.Now;
                    pve.Entry(ewhl).State = System.Data.Entity.EntityState.Modified;
                    pve.SaveChanges();

                    pve.Employees.Attach(emp);
                    emp.IsOnLunchBreak = true;
                    emp.IsWorking = false;
                    pve.Entry(emp).State = System.Data.Entity.EntityState.Modified;
                    pve.SaveChanges();

                    MessageBox.Show("Lunch Started at: " + ewhl.LunchStart);

                    AdjustButtons();
                }else
                {
                    MessageBox.Show("Your lunch has been taken. Please clock out and back in for a second lunch.");
                }
            }
            catch
            {
                
            }
        }

        private void LunchEndButton_Click(object sender, RoutedEventArgs e)
        {
            PlanetVetEntities pve = new PlanetVetEntities();
            Employee emp = pve.Employees.Where(em => em.Username.Equals(SessionData.CurrentUser.UserName)).FirstOrDefault();
            EmployeeWorkHourLog ewhl = pve.EmployeeWorkHourLogs.Where(worklog => worklog.EmployeeID == emp.EmployeeId && worklog.Clock_Out == null).FirstOrDefault();

            pve.EmployeeWorkHourLogs.Attach(ewhl);
            ewhl.LunchEnd = DateTime.Now;
            pve.Entry(ewhl).State = System.Data.Entity.EntityState.Modified;
            pve.SaveChanges();

            pve.Employees.Attach(emp);
            emp.IsOnLunchBreak = false;
            emp.IsWorking = true;
            pve.Entry(emp).State = System.Data.Entity.EntityState.Modified;
            pve.SaveChanges();

            MessageBox.Show("Lunch Ended at: " + ewhl.LunchEnd);

            AdjustButtons();
        }
    }
}
