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
            PlanetVetWindow pvw = new PlanetVetWindow();
            pvw.Show();
            this.Close();
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


    }
}
