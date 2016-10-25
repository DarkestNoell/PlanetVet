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
    /// Interaction logic for RegisterNewUser.xaml
    /// </summary>
    public partial class RegisterNewUserWindow : MetroWindow
    {
        public RegisterNewUserWindow()
        {
            InitializeComponent();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            PlanetVetEntities pve = new PlanetVetEntities();
            if(AllFieldsAreComplete())
            {
                if(!UsernameExists())
                {
                    //Encrypt password with secret praise
                    String EncryptedPassword = StringCipher.Encrypt(PasswordBox.Password,StringCipher.PlaceHolderPassPraise);

                    User u = new User()
                    {
                        UserName = UsernameTextBox.Text,
                        Password_Encrypted_ = EncryptedPassword,
                        
                    };

                    Boolean? FullTime = FullTimeCheckBox.IsChecked;

                    Employee emp = new Employee()
                    {
                        FirstName = FirstNameTextBox.Text,
                        LastName = LastNameTextBox.Text,
                        Position = PositionComboBox.Text,
                        Username = u.UserName,
                        IsFullTime = FullTime
                    };

                    pve.Employees.Add(emp);
                    pve.Users.Add(u);

                    pve.SaveChanges();
                    this.Close();
                }
            }else
            {
            }
        }

        private bool UsernameExists()
        {
            PlanetVetEntities pve = new PlanetVetEntities();
            User u = pve.Users.Where(us => us.UserName.Equals(UsernameTextBox.Text)).FirstOrDefault();
            if (u == null)
            {
                return false;
            }else
            {
                MessageBox.Show("This username already exists, please choose a different one.");
                return true;
            }
        }

        private bool AllFieldsAreComplete()
        {
            if (FirstNameTextBox.Text.Equals(""))
            {
                MessageBox.Show("Please provide a First Name.");
            }
            else if (LastNameTextBox.Text.Equals(""))
            {
                MessageBox.Show("Please provide a Last Name.");
            }
            else if (UsernameTextBox.Text.Equals(""))
            {
                MessageBox.Show("Please provide a Username");
            }
            else if (PasswordBox.Password.Equals(""))
            {
                MessageBox.Show("Please provide a Password");
            }
            else if (PositionComboBox.Text.Equals(""))
            {
                MessageBox.Show("Please select a role");
            }

            if (FirstNameTextBox.Text.Equals("") || LastNameTextBox.Text.Equals("") || UsernameTextBox.Text.Equals("") || PasswordBox.Password.Equals("")
                || PositionComboBox.Text.Equals(""))
            {
                return false;
            }
            return true;
        }

        private void PositionComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            String SelectedItem = PositionComboBox.SelectedItem.ToString();
            if(SelectedItem.Equals("New Role"))
                {
                MessageBox.Show("To add a new role, please have your manager log in.");
                }
        }
    }
}
