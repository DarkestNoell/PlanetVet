using Capstone.HelperClasses;
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

            if(pve.AllDates.ToList().Count == 0 || !(pve.AllDates.OrderByDescending(p => p.Date).FirstOrDefault().Date.Year == 2100))
            {
                StartupQueries suq = new StartupQueries();
                suq.StartAllDatesThread();
            }

            if (pve.OfficeHours.ToList().Count == 0)
            {
                SelectWorkDaysWindow swdw = new SelectWorkDaysWindow();
                swdw.Show();
                this.Close();
            }
            else
            {

                AppointmentDateSelectorWindow esw = new AppointmentDateSelectorWindow();
                esw.Show();
                this.Close();
            }
       }
    }
}
