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
    /// Interaction logic for AddInventoryItem.xaml
    /// </summary>
    public partial class AddInventoryItemLogWindow : MetroWindow
    {
        //( ͡° ͜ʖ ͡°)
        public AddInventoryItemLogWindow()
        {
            InitializeComponent();
            FillCategoryComboBox();
            FillInventoryItemsComboBox();
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
        
        private void FillInventoryItemsComboBox()
        {
            PlanetVetEntities pve = new PlanetVetEntities();
            List<InventoryItem> InventoryItems = pve.InventoryItems.ToList();
            foreach(InventoryItem ii in InventoryItems)
            {
                InventoryItemComboBox.Items.Add(ii.Name);
            }
        }


        private void AddInventoryItemButton_Click(object sender, RoutedEventArgs e)
        {

            PlanetVetEntities pve = new PlanetVetEntities();
            //InventoryItem ii = new InventoryItem()
            //{
            //    Category = InventoryItemCategoryComboBox.Text,
            //    Name = InventoryItemComboBox.Text,
            //    StockOnHand = QuantityOnHandTextBox.Text,
            //    PricePerUnit = float.Parse(PricePerUnitTextBox.Text)
            //};

            //pve.InventoryItems.Add(ii);
            //pve.SaveChanges();
            //this.Close();

            InventoryLog il = new InventoryLog()
            {
                Category = InventoryItemCategoryComboBox.Text,
                InventoryItemName = InventoryItemComboBox.Text,
                Description = DescriptionTextBox.Text,
                Quantity = QuantityTextBox.Text
            };

            pve.InventoryLogs.Add(il);
            pve.SaveChanges();
            this.Close();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
