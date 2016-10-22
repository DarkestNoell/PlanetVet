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
    /// Interaction logic for InventoryManagementWindow.xaml
    /// </summary>
    public partial class InventoryInformationWindow : MetroWindow
    {
        private Boolean InventoryLogIsSelected = false;
        private Boolean InventorySelected = false;
        public InventoryInformationWindow()
        {
            InitializeComponent();
            PopulateListView();
            PopulateDataGridWithFullInventory();
            InventoryLogIsSelected = true;
        }

        private void PopulateListView()
        {
            PlanetVetEntities pve = new PlanetVetEntities();
            List<InventoryItemsCategory> InventoryCategories = pve.InventoryItemsCategories.OrderByDescending(ic => ic.CategoryName).ToList();
            InventoryCategoryListBox.Items.Add("All");
            foreach (InventoryItemsCategory iic in InventoryCategories)
            {
                InventoryCategoryListBox.Items.Add(iic.CategoryName);
            }
        }

        
        private void PopulateDataGridWithFullInventory()
        {
            PlanetVetEntities pve = new PlanetVetEntities();
            var InventoryLog = pve.InventoryLogs;
            InventoryDataGrid.ItemsSource = InventoryLog.ToList();
        }

        private void AddCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            AddCategoryWindow acw = new AddCategoryWindow();
            acw.ShowDialog();
            InventoryCategoryListBox.Items.Clear();
            PopulateListView();
        }

        private void AddInventoryItemToLogButton_Click(object sender, RoutedEventArgs e)
        {
            if (InventoryLogIsSelected)
            {
                AddInventoryItemLogWindow aiiw = new AddInventoryItemLogWindow();
                aiiw.ShowDialog();
                PopulateDataGridWithFullInventory();
            }else
            {
                AddInventoryItemWindow aiiw = new AddInventoryItemWindow();
                aiiw.ShowDialog();
                AddInventoryToDataGrid();
            }
        }

        private void AddInventoryToDataGrid()
        {
            PlanetVetEntities pve = new PlanetVetEntities();
            List<InventoryItem> InventoryItems = pve.InventoryItems.OrderByDescending(ic => ic.Name).ToList();
            InventoryDataGrid.ItemsSource = InventoryItems;
        }

        private void RemoveItemFromLogButton_Click(object sender, RoutedEventArgs e)
        {
            PlanetVetEntities pve = new PlanetVetEntities();
            try
            {
                if (InventoryLogIsSelected)
                {
                    InventoryLog p = (InventoryLog)InventoryDataGrid.SelectedItem;
                    InventoryLog SelectedInventoryItem = pve.InventoryLogs.Where(pro => pro.Id == p.Id).FirstOrDefault();
                    pve.InventoryLogs.Remove(SelectedInventoryItem);

                    //Get list of procedures for patient
                    List<InventoryLog> InventoryLog = pve.InventoryLogs.ToList();
                    InventoryDataGrid.ItemsSource = InventoryLog;
                }else
                {
                    InventoryItem ii = (InventoryItem)InventoryDataGrid.SelectedItem;
                    InventoryItem SelectedInventoryItem = pve.InventoryItems.Where(pro => pro.Id == ii.Id).FirstOrDefault();
                    pve.InventoryItems.Remove(SelectedInventoryItem);
                    //Get list of procedures for patient
                    List<InventoryItem> InventoryItems = pve.InventoryItems.ToList();
                    InventoryDataGrid.ItemsSource = InventoryItems;
                }
            }
            catch
            {

            }
            pve.SaveChanges();
        }

        private void InventoryDataGrid_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                PlanetVetEntities pve = new PlanetVetEntities();
                InventoryLog il = (InventoryLog)InventoryDataGrid.SelectedItem;
                pve.InventoryLogs.Attach(il);
                pve.Entry(il).State = System.Data.Entity.EntityState.Modified;
                pve.SaveChanges();
            }catch
            {

            }
        }

        private void InventoryCategoryListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                PlanetVetEntities pve = new PlanetVetEntities();
                String SelectedItem = InventoryCategoryListBox.SelectedItem.ToString();

                if (SelectedItem.Equals("All"))
                {
                    if (InventoryLogIsSelected)
                    {
                        var InventoryItemsOfCategory = pve.InventoryLogs.ToList();
                        InventoryDataGrid.ItemsSource = InventoryItemsOfCategory;
                    }
                    else
                    {
                        var InventoryItemsOfCategory = pve.InventoryItems.ToList();
                        InventoryDataGrid.ItemsSource = InventoryItemsOfCategory;
                    }
                }
                else
                {
                    if (InventoryLogIsSelected)
                    {
                        var InventoryItemsOfCategory = pve.InventoryLogs.Where(inv => inv.Category == SelectedItem).ToList();
                        InventoryDataGrid.ItemsSource = InventoryItemsOfCategory;
                    }
                    else
                    {
                        var InventoryItemsOfCategory = pve.InventoryItems.Where(inv => inv.Category == SelectedItem).ToList();
                        InventoryDataGrid.ItemsSource = InventoryItemsOfCategory;
                    }
                }
            }
            catch
            {

            }
        }

        private void ViewInventoryLogButton_Click(object sender, RoutedEventArgs e)
        {
            InventoryLogIsSelected = true;
            InventorySelected = false;
            PopulateDataGridWithFullInventory();
        }

        private void ViewInventoryButton_Click(object sender, RoutedEventArgs e)
        {
            InventorySelected = true;
            InventoryLogIsSelected = false;
            AddInventoryToDataGrid();
        }

        private void DeleteSelectedCategory_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DashboardButton_Click(object sender, RoutedEventArgs e)
        {
            PlanetVetWindow pvw = new PlanetVetWindow();
            pvw.Show();
            this.Close();
        }
    }
}
