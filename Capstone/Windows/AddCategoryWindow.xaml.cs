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
    public partial class AddCategoryWindow : MetroWindow
    {
        public AddCategoryWindow()
        {
            InitializeComponent();
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            PlanetVetEntities pve = new PlanetVetEntities();
            var MatchingCategories = pve.InventoryItemsCategories.Where(cat => cat.CategoryName.Equals(CategoryTextBox.Text)).ToList();

            if (MatchingCategories.Count == 0)
            {
                pve.InventoryItemsCategories.Add(
                    new InventoryItemsCategory()
                    {
                        CategoryName = CategoryTextBox.Text
                    }
                    );
                this.Close();
                pve.SaveChanges();
            }else
            {
                MessageBox.Show("An existing category already exists. Please select another category name.");
            }
        }
    }
}
