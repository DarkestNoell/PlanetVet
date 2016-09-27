﻿using Capstone.Windows;
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

namespace Capstone
{
    /// <summary>
    /// Interaction logic for EmployeeScheduleWindow.xaml
    /// </summary>
    public partial class AppointmentDateSelectorWindow : MetroWindow
    {
        public AppointmentDateSelectorWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            PlanetVetWindow pvw = new PlanetVetWindow();
            pvw.Show();
            this.Close();
        }

        private void ScheduleButton_Click(object sender, RoutedEventArgs e)
        {
            AppointmentSchedulingWindow asw = new AppointmentSchedulingWindow();
            asw.Show();
            this.Close();
        }
    }
}
