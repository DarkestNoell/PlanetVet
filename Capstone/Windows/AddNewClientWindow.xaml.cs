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
    /// Interaction logic for AddNewClientWindow.xaml
    /// </summary>
    public partial class AddNewClientWindow : MetroWindow
    {
        public AddNewClientWindow()
        {
            InitializeComponent();
        }

        private void AddNewClientButton_Click(object sender, RoutedEventArgs e)
        {
            //Put everything together
            if(RequiredInputReceived())
            {
                PlanetVetEntities pve = new PlanetVetEntities();

                Client c = new Client()
                {
                    FirstName = FirstNameTextBox.Text,
                    MiddleInitial = MiddleInitialTextBox.Text,
                    LastName = LastNameTextBox.Text,
                    Address = AddressTextBox.Text,
                    State = StateTextBox.Text,
                    ZIP = ZIPCodeTextBox.Text,
                    County = CountyTextBox.Text,
                    Company = CompanyTextBox.Text,
                    FaxNumber = FaxNumberTextBox.Text,
                    FirstPhoneNumType = PhoneNumber1TypeComboBox.Text,
                    FirstPhoneNumAC = PhoneNumber1AreaCodeTextBox.Text,
                    FirstPhoneNum = PhoneNumber1TextBox.Text,
                    SecondPhoneNumType = PhoneNumber2TypeComboBox.Text,
                    SecondPhoneNumAC = PhoneNumber2AreaCodeTextBox.Text,
                    SecondPhoneNum = PhoneNumber2TextBox.Text,
                    Email = EmailAddressTextBox.Text,
                    City = CityTextBox.Text,
                    Title = TitleComboBox.Text,
                    DateAdded = DateTime.Now,
                    BalanceDue = 0,
                                     
                };

                pve.Clients.Add(c);
                pve.SaveChanges();

                MessageBox.Show("Succesfully added |" + c.LastName + "," + c.FirstName + "| to the system.");
                PlanetVetWindow pvw = new PlanetVetWindow();
                pvw.Show();
                this.Close();
            }
        }

        private Boolean RequiredInputReceived()
        {
            if (FirstNameTextBox.Text.Equals(""))
            {
                MessageBox.Show("First Name is required.");
                return false;

            }
            else if (LastNameTextBox.Text.Equals(""))
            {
                MessageBox.Show("Last Name is required.");
                return false;

            }
            else if (AddressTextBox.Text.Equals(""))
            {
                MessageBox.Show("Address is required.");
                return false;

            }
            else if (StateTextBox.Text.Equals(""))
            {
                MessageBox.Show("State is required.");
                return false;

            }
            else if (CityTextBox.Text.Equals(""))
            {
                MessageBox.Show("City is required.");
                return false;

            }
            else if (CountyTextBox.Text.Equals(""))
            {
                MessageBox.Show("County is required.");
                return false;

            }
            else if (ZIPCodeTextBox.Text.Equals(""))
            {
                MessageBox.Show("ZIP Code is required.");
                return false;

            }
            else if(PhoneNumber1TypeComboBox.Text.Equals(""))
            {
                MessageBox.Show("Phone Number 1 Type is required.");
                return false;

            }
            else if(PhoneNumber1AreaCodeTextBox.Text.Equals(""))
            {
                MessageBox.Show("Phone Number 1 Area Code is required.");
                return false;

            }
            else if(PhoneNumber1TextBox.Text.Equals(""))
            {
                MessageBox.Show("Phone Number 1 Phone Number is required");
                return false;

            }

            return true;
        }

        private void DashboardButton_Click(object sender, RoutedEventArgs e)
        {
            PlanetVetWindow pve = new PlanetVetWindow();
            pve.Show();
            this.Close();
        }
    }
}
