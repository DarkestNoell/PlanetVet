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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Capstone
{
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            PlanetVetEntities pve = new PlanetVetEntities();
            //Get username and password
            String username = userNameBox.Text;
            String password = passwordBox.Password;

            User u = pve.Users.Where(us => us.UserName.Equals(username)).FirstOrDefault();
            Employee em = pve.Employees.Where(emp => emp.Username.Equals(username)).FirstOrDefault();
            if (u != null) {
                String decryptedPassword = StringCipher.Decrypt(u.Password_Encrypted_, StringCipher.PlaceHolderPassPraise);
                if(decryptedPassword.Equals(password))
                {
                    SessionData.CurrentUser = u;
                    UserSession us = new UserSession()
                    {
                        EmployeeID = em.EmployeeId,
                        EmployeeName = em.FirstName + " " + em.LastName,
                        SessionStart = DateTime.Now
                    };

                    pve.UserSessions.Add(us);
                    pve.SaveChanges();

                    PlanetVetWindow pvw = new PlanetVetWindow();
                    pvw.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Invalid username or password.");
                }
            }else
            {
                MessageBox.Show("Invalid username or password.");
            }
        }

        private void passwordBox_MouseEnter(object sender, MouseEventArgs e)
        {
            if (passwordBox.Password.Equals("password"))
            {
                passwordBox.Password = "";
            }
        }

        private void passwordBox_MouseLeave(object sender, MouseEventArgs e)
        {
            if(passwordBox.Password.Equals(""))
            {
                passwordBox.Password = "password";
            }
        }

        private void createAccountButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
