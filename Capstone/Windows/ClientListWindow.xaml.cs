using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for ClientList.xaml
    /// </summary>
    public partial class ClientListWindow : MetroWindow
    {
        public Boolean SearchByFirst { get; set; }
        public Boolean SearchByLast { get; set; }
        public Boolean SearchByFull { get; set; }
        public String SearchEntry { get; set; }
        public ClientListWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SearchForClient();
        }

        private void SearchForClient()
        {

            //AdjustGrid();
            PlanetVetEntities pve = new PlanetVetEntities();
            if(SearchByFirst)
            {
                ClientDataGrid.ItemsSource = pve.Clients.Where(client => client.FirstName.Contains(SearchEntry)).ToList();
                ClientDataGrid.IsReadOnly = true;
                SearchByFirst = false;
                AdjustGrid();
            }else if(SearchByLast)
            {
                ClientDataGrid.ItemsSource = pve.Clients.Where(client => client.LastName.Contains(SearchEntry)).ToList();
                ClientDataGrid.IsReadOnly = true;
                SearchByLast = false;
                AdjustGrid();

            }
            else if(SearchByFull)
            {
                String[] SplitStringArray = SearchEntry.Split(null);
                List<Client> MatchingClients = new List<Client>();

                if (SplitStringArray.Length == 2)
                {
                    foreach (Client c in pve.Clients)
                    {
                        if (c.LastName.Contains(SplitStringArray[1]) && c.FirstName.Contains(SplitStringArray[0]))
                        {
                            MatchingClients.Add(c);
                        }
                    }
                }else if(SplitStringArray.Length == 3)
                {
                    foreach (Client c in pve.Clients)
                    {
                        if (c.LastName.Contains(SplitStringArray[2]) && c.FirstName.Contains(SplitStringArray[0]) && c.MiddleInitial.Contains(SplitStringArray[1]))
                        {
                            MatchingClients.Add(c);
                        }
                    }
                }

                ClientDataGrid.ItemsSource = MatchingClients;
                ClientDataGrid.IsReadOnly = true;
                SearchByFull = false;
                AdjustGrid();              
            }
        }

        private void ClientDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ClientAppointmentHistoryWindow cahw = new ClientAppointmentHistoryWindow();
            Client value = ClientDataGrid.SelectedItem as Client;
            cahw.SearchEntry = value.LastName + "," + value.FirstName;

            cahw.Show();
            this.Close();
        }

        private void AdjustGrid()
        {
            ClientDataGrid.Columns[0].Header = "ID";
            ClientDataGrid.Columns[1].Header = "First Name";
            ClientDataGrid.Columns[2].Header = "Middle Initial";
            ClientDataGrid.Columns[3].Header = "Last Name";
            ClientDataGrid.Columns[4].Header = "Address";
            ClientDataGrid.Columns[5].Header = "State";
            ClientDataGrid.Columns[6].Header = "City";
            ClientDataGrid.Columns[7].Header = "Zip Code";
            ClientDataGrid.Columns[8].Header = "County";
            ClientDataGrid.Columns[9].Header = "Company";
            ClientDataGrid.Columns[10].Header = "Fax Number";
            ClientDataGrid.Columns[11].Header = "Phone 1 Area Code";
            ClientDataGrid.Columns[12].Header = "Phone 1";
            ClientDataGrid.Columns[13].Header = "Phone 2 Area Code";
            ClientDataGrid.Columns[14].Header = "Phone 2";
            ClientDataGrid.Columns[15].Header = "Phone 1 Type";
            ClientDataGrid.Columns[16].Header = "Phone 2 Type";
            ClientDataGrid.Columns[17].Header = "Folder";
            ClientDataGrid.Columns[18].Header = "Co.";
            ClientDataGrid.Columns[19].Header = "Title";
            ClientDataGrid.Columns[20].Header = "Codes";
            ClientDataGrid.Columns[21].Header = "Class";
            ClientDataGrid.Columns[22].Header = "Balance Due";
            ClientDataGrid.Columns[23].Header = "Email";
            ClientDataGrid.Columns[24].Header = "Date Added";
        }

        private void AppointmentMenuButton_Click(object sender, RoutedEventArgs e)
        {
            AddMoveDeleteScheduleMenuWindow amdsmw = new AddMoveDeleteScheduleMenuWindow();
            amdsmw.Show();
            this.Close();
        }

        private void DashboardButton_Click(object sender, RoutedEventArgs e)
        {
            PlanetVetWindow pvw = new PlanetVetWindow();
            pvw.Show();
            this.Close();
        }
    }
}
