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
    /// Interaction logic for AddInventoryItemWindow.xaml
    /// </summary>
    public partial class AddInventoryItemWindow : MetroWindow
    {
        public AddInventoryItemWindow()
        {
            InitializeComponent();
            FillCategoryComboBox();
        }

        private void FillCategoryComboBox()
        {
            PlanetVetEntities pve = new PlanetVetEntities();
            List<InventoryItemsCategory> Categories = pve.InventoryItemsCategories.ToList();
            foreach (InventoryItemsCategory iic in Categories)
            {
                InventoryItemCategoryComboBox.Items.Add(iic.CategoryName);
            }
        }

        private void AddInventoryItemButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PlanetVetEntities pve = new PlanetVetEntities();
                InventoryItem ii = new InventoryItem()
                {
                    Category = InventoryItemCategoryComboBox.Text,
                    Name = InventoryItemNameTextBox.Text,
                    StockOnHand = StockOnHandTextBox.Text,
                    PricePerUnit = float.Parse(PricePerUnitTextBox.Text)
                };

                var MatchingItems = pve.InventoryItems.Where(item => item.Name.Equals(ii.Name)).ToList();
                if (MatchingItems.Count == 0)
                {
                    pve.InventoryItems.Add(ii);
                    pve.SaveChanges();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("The item name you have entered already exists. Please enter a different name, or delete the existing item. You can edit items in the inventory window.");
                }
            }
            catch
            {

            }
        }
    }
}
