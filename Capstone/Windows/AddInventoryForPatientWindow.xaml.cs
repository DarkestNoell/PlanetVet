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
    /// Interaction logic for AddInventoryForPatientWindow.xaml
    /// </summary>
    public partial class AddInventoryForPatientWindow : MetroWindow
    {
        public static Patient SelectedPatient { get; set; }
        public AddInventoryForPatientWindow()
        {
            InitializeComponent();
            FillComboBox();
        }

        private void FillComboBox()
        {
            PlanetVetEntities pve = new PlanetVetEntities();
            List<InventoryItemsCategory> Categories = pve.InventoryItemsCategories.ToList();
            foreach(InventoryItemsCategory iic in Categories)
            {
                InventoryItemCategoryComboBox.Items.Add(iic.CategoryName);
            }
        }

        private void AddInventoryItemButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PlanetVetEntities pve = new PlanetVetEntities();
                InventoryLog il = new InventoryLog()
                {
                    Category = InventoryItemCategoryComboBox.Text,
                    InventoryItemName = InventoryItemComboBox.Text,
                    PatientID = SelectedPatient.PatientID,
                    Quantity = QuantityUsedTextBox.Text,
                    Description = DescriptionTextBox.Text,
                    ChargeToClient = float.Parse(ChargeToClientTextBox.Text)
                };

                //Get client to charge to
                Client PatientOwner = pve.Clients.Where(po => po.ClientId == SelectedPatient.ClientID).FirstOrDefault();
                PatientOwner.BalanceDue += float.Parse(ChargeToClientTextBox.Text);

                pve.InventoryLogs.Add(il);
                pve.SaveChanges();
                this.Close();
            }catch
            {
                MessageBox.Show("There was an error with one of your inputs. Please check your entries again.");
            }
        }

        private void InventoryItemCategoryComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PlanetVetEntities pve = new PlanetVetEntities();
            String SelectedItem = InventoryItemCategoryComboBox.SelectedItem.ToString();
            var ItemsByCategory = pve.InventoryItems.Where(item => item.Category.Equals(SelectedItem)).ToList();
            foreach (InventoryItem ii in ItemsByCategory)
            {
                InventoryItemComboBox.Items.Add(ii.Name);
            }
        }

        private void InventoryItemComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }
}
