using Capstone.Authentication;
using Capstone.Windows;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    public partial class PlanetVetWindow : MetroWindow
    {
        public PlanetVetWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            PlanetVetEntities pve = new PlanetVetEntities();
         
            if (pve.OfficeHours.ToList().Count == 0)
            {
                SelectWorkDaysWindow swdw = new SelectWorkDaysWindow();
                swdw.Show();
                this.Close();
            }
            else
            {
                AddMoveDeleteScheduleMenuWindow amdsmw = new AddMoveDeleteScheduleMenuWindow();
                amdsmw.Show();
                this.Close();
            }
       }

        private void AddNewClientButton_Click(object sender, RoutedEventArgs e)
        {
            AddNewClientWindow ancw = new AddNewClientWindow();
            ancw.Show();
            this.Close();
        }

        private void ClientSearchButton_Click(object sender, RoutedEventArgs e)
        {
            ClientInformationDisplayWindow cidw = new ClientInformationDisplayWindow();
            cidw.Show();
            this.Close();
        }

        private void InventoryButton_Click(object sender, RoutedEventArgs e)
        {
            InventoryInformationWindow iiw = new InventoryInformationWindow();
            iiw.Show();
            this.Close();
        }

        private void ReconfigureBusinessHoursWindow_Click(object sender, RoutedEventArgs e)
        {
            PlanetVetEntities pve = new PlanetVetEntities();
            foreach(OfficeHour oh in pve.OfficeHours)
            {
                pve.OfficeHours.Remove(oh);
            }

            pve.SaveChanges();
            SelectWorkDaysWindow swdw = new SelectWorkDaysWindow();
            swdw.Show();
            this.Close();
        }

        private void AddNewUserButton_Click(object sender, RoutedEventArgs e)
        {
            RegisterNewUserWindow rnuw = new RegisterNewUserWindow();
            rnuw.ShowDialog();
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PlanetVetEntities pve = new PlanetVetEntities();
                Employee em = pve.Employees.Where(emp => emp.Username.Equals(SessionData.CurrentUser.UserName)).FirstOrDefault();
                UserSession us = pve.UserSessions.Where(usersesh => usersesh.EmployeeID == em.EmployeeId && usersesh.SessionEnd == null).FirstOrDefault();
                pve.UserSessions.Attach(us);
                us.SessionEnd = DateTime.Now;
                pve.Entry(us).State = System.Data.Entity.EntityState.Modified;
                pve.SaveChanges();
                SessionData.CurrentUser = null;

                MainWindow mw = new MainWindow();
                mw.Show();
                this.Close();
            }
            catch
            {

            }
        }

        private void EmployeeManagementButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ClockInOutButton_Click(object sender, RoutedEventArgs e)
        {
            ClockInOutWindow ciow = new ClockInOutWindow();
            ciow.Show();
            this.Close();
        }

        private void EmployeeSchedulingButton_Click(object sender, RoutedEventArgs e)
        {
            EmployeeSchedulingWindow esw = new EmployeeSchedulingWindow();
            esw.Show();
            this.Close();
        }
    }
}
