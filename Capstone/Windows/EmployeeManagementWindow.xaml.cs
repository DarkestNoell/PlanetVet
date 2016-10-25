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
    /// Interaction logic for EmployeeManagementWindow.xaml
    /// </summary>
    public partial class EmployeeManagementWindow : MetroWindow
    {
        public EmployeeManagementWindow()
        {
            InitializeComponent();
        }

        private void FillWithEmployees()
        {
            PlanetVetEntities pve = new PlanetVetEntities();
            List<Employee> EmployeeList = pve.Employees.ToList();
            EmployeeDataGrid.ItemsSource = EmployeeList;
        }

        private void DashboardButton_Click(object sender, RoutedEventArgs e)
        {
            PlanetVetWindow pvw = new PlanetVetWindow();
            pvw.Show();
            this.Close();
        }
    }
}
