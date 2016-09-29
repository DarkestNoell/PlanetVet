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
    /// Interaction logic for ClientAppointmentHistoryWindow.xaml
    /// </summary>
    public partial class ClientAppointmentHistoryWindow : MetroWindow
    {
        public String SearchEntry { get; set; }
        public ClientAppointmentHistoryWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            PopulateGrid();
        }

        private void PopulateGrid()
        {
            PlanetVetEntities pve = new PlanetVetEntities();
            var AppointmentsForThisClient = pve.Appointments.Where(client => client.Client.Contains(SearchEntry)).ToList();
            ClientDataGrid.ItemsSource = AppointmentsForThisClient;
            ClientDataGrid.IsReadOnly = true;
            ClientDataGrid.Columns.Remove(ClientDataGrid.Columns[0]);
            ClientDataGrid.Columns.Remove(ClientDataGrid.Columns[0]);
            ClientDataGrid.Columns.Remove(ClientDataGrid.Columns[1]);
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            PlanetVetWindow pvw = new PlanetVetWindow();
            pvw.Show();
            this.Close();
        }
    }
}
