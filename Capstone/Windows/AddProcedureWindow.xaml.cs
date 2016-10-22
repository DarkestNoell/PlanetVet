using Capstone.HelperClasses;
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
    /// Interaction logic for AddProcedureWindow.xaml
    /// </summary>
    public partial class AddProcedureWindow : MetroWindow
    {
        public static Patient SelectedPatient { get; set; }
        public AddProcedureWindow()
        {
            InitializeComponent();

            PlanetVetEntities pve = new PlanetVetEntities();
            FillComboBox();
            AddInventoryForPatientWindow.SelectedPatient = SelectedPatient;
            //InventoryUsedForProcedureDataGrid.ItemsSource = pve.InventoryLogs.Where(inv => inv.PatientID == SelectedPatient.PatientID).ToList();
        }

        private void FillComboBox()
        {
            PlanetVetEntities pve = new PlanetVetEntities();
            List <ProcedureCategory> ProcedureCategories = pve.ProcedureCategories.ToList();
            foreach(ProcedureCategory pc in ProcedureCategories)
            {
                ProcedureCategoryComboBox.Items.Add(pc.CategoryName);
            }
        }

        private void AddProcedureButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PlanetVetEntities pve = new PlanetVetEntities();

                Procedure p = new Procedure()
                {
                    ProcedureCategory = ProcedureCategoryComboBox.Text,
                    ProcedureDescription = DescriptionTextBox.Text,
                    PatientID = SelectedPatient.PatientID,
                    ProcedureCost = float.Parse(ChargeToClientTextBox.Text)
                };

                pve.Procedures.Add(p);

                Client PatientOwner = pve.Clients.Where(po => po.ClientId == SelectedPatient.ClientID).FirstOrDefault();
                PatientOwner.BalanceDue += float.Parse(ChargeToClientTextBox.Text);

                pve.SaveChanges();

                this.Close();
            }catch
            {
                MessageBox.Show("There was a problem with one or more of your inputs. Please check for any errors.");
            }
        }

        //private void AddInventoryButton_Click(object sender, RoutedEventArgs e)
        //{
        //    PlanetVetEntities pve = new PlanetVetEntities();
        //    AddInventoryForPatientWindow aifpw = new AddInventoryForPatientWindow();
        //    aifpw.ShowDialog();

        //    //Update
        //    InventoryUsedForProcedureDataGrid.ItemsSource = pve.InventoryLogs.Where(inv => inv.PatientID == SelectedPatient.PatientID).ToList();
        //}

        private void RemoveProcedureButton_Click(object sender, RoutedEventArgs e)
        {
           // try
           // {
            //    PlanetVetEntities pve = new PlanetVetEntities();
            //    InventoryLog il = (InventoryLog)InventoryUsedForProcedureDataGrid.SelectedItem;

            ////Remove selected item from database, update what patient owes
            //Client c = pve.Clients.Where(cl => cl.ClientId == SelectedPatient.ClientID).FirstOrDefault();
            //    pve.Clients.Attach(c);
            //    c.BalanceDue -= il.ChargeToClient;
            //    pve.Entry(c).State = System.Data.Entity.EntityState.Modified;

            //pve.InventoryLogs.Attach(il);
            //pve.InventoryLogs.Remove(il);
            //pve.SaveChanges();

            //InventoryUsedForProcedureDataGrid.ItemsSource = pve.InventoryLogs.Where(inv => inv.PatientID == SelectedPatient.PatientID).ToList();
            //}
            //catch
            //{

            //}
        }

        private void InventoryUsedForProcedureDataGrid_CurrentCellChanged(object sender, EventArgs e)
        {
            //PlanetVetEntities pve = new PlanetVetEntities();
            //try
            //{
            //    //InventoryLog il = (InventoryLog)InventoryUsedForProcedureDataGrid.SelectedItem;
            //    pve.InventoryLogs.Attach(il);
            //    pve.Entry(il).State = System.Data.Entity.EntityState.Modified;
            //    pve.SaveChanges();

            //    Client c = pve.Clients.Where(cl => cl.ClientId == SelectedPatient.ClientID).FirstOrDefault();

            //    BalanceCalculator BC = new BalanceCalculator();
            //    double? NewBalance = BC.CalculateBalance(c.ClientId);
            //    pve.Clients.Attach(c);
            //    c.BalanceDue = NewBalance;
            //    pve.Entry(c).State = System.Data.Entity.EntityState.Modified;
            //    pve.SaveChanges();
            //}
            //catch
            //{

            //}
        }
    }
}
