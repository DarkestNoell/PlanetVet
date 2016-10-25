using Capstone.HelperClasses;
using MahApps.Metro.Controls;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using Xceed.Wpf.DataGrid.Converters;

namespace Capstone.Windows
{
    /// <summary>
    /// Interaction logic for ClientInformationDisplayWindow.xaml
    /// </summary>
    public partial class ClientInformationDisplayWindow : MetroWindow
    {
        private Client SelectedClient { get; set; }
        private Patient SelectedPatient { get; set; }

        public ClientInformationDisplayWindow()
        {
            InitializeComponent();
            DeActivateButtons();
        }

        private void DeActivateButtons()
        {
            UploadImageButton.IsEnabled = false;
            AddProcedureButton.IsEnabled = false;
            DeleteProcedureButton.IsEnabled = false;
            UploadImageButton.IsEnabled = false;
            SaveClientChanges.IsEnabled = false;
            AddDocumentToPatientButton.IsEnabled = false;
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            PlanetVetEntities pve = new PlanetVetEntities();
            var ClientsFound = pve.Clients.Where(client => client.FirstName.Contains(ClientFirstNameTextBox.Text) && client.LastName.Contains(ClientLastNameTextBox.Text));
            RecommendedSearchListBox.Items.Clear();

            foreach (Client c in ClientsFound)
            {
                RecommendedSearchListBox.Items.Add(c.LastName + "," + c.FirstName);
            }
        }

 

        private void RecommendedSearchListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PlanetVetEntities pve = new PlanetVetEntities();
            String SelectedItem = RecommendedSearchListBox.SelectedItem.ToString();

            String[] ClientName = SelectedItem.Split(',');
            String first = ClientName[1];
            String last = ClientName[0];

            Client ClientSelected = pve.Clients.Where(client => client.FirstName.Contains(first) && client.LastName.Contains(last)).FirstOrDefault();
            SelectedClient = ClientSelected;
            var ClientsPets = pve.Patients.Where(pet => pet.ClientID == ClientSelected.ClientId);
            PatientsDataGrid.ItemsSource = ClientsPets.ToList();

            PatientsDataGrid.Columns.Remove(PatientsDataGrid.Columns[0]);
            PatientsDataGrid.Columns.Remove(PatientsDataGrid.Columns[0]);
            PatientsDataGrid.Columns.Remove(PatientsDataGrid.Columns[0]);
            PatientsDataGrid.Columns.Remove(PatientsDataGrid.Columns[0]);
            PatientsDataGrid.Columns.Remove(PatientsDataGrid.Columns[16]);
            PatientsDataGrid.Columns[11].Header = "Weight type";

            ClientFirstNameTextBox.Text = ClientName[1];
            ClientLastNameTextBox.Text = ClientName[0];
            FirstNameTextBox.Text = ClientName[1];
            LastNameTextBox.Text = ClientName[0];
            AddressTextBox.Text = ClientSelected.Address;
            StateTextBox.Text = ClientSelected.State;
            CityTextBox.Text = ClientSelected.City;
            ZIPCodeTextBox.Text = ClientSelected.ZIP;
            CountryTextBox.Text = ClientSelected.County;
            PhoneNumber1AreaCodeTextBox.Text = ClientSelected.FirstPhoneNumAC;
            Phone1TextBox.Text = ClientSelected.FirstPhoneNum;


            
            if(ClientSelected.MiddleInitial != null)
            {
                MiddleInitialTextBox.Text = ClientSelected.MiddleInitial;
            }

            if(ClientSelected.FirstPhoneNumType.Equals("Home"))
            {
                Phone1TypeComboBox.SelectedIndex = 0;
            }else if(ClientSelected.FirstPhoneNumType.Equals("Cell"))
            {
                Phone1TypeComboBox.SelectedIndex = 1;
            }else if(ClientSelected.FirstPhoneNumType.Equals("Work"))
            {
                Phone1TypeComboBox.SelectedIndex = 2;
            }

            if(ClientSelected.Title.Equals("Mr."))
            {
                TitleComboBox.SelectedIndex = 0;
            }else if(ClientSelected.Title.Equals("Mrs."))
            {
                TitleComboBox.SelectedIndex = 1;
            }
            else if(ClientSelected.Title.Equals("Ms."))
            {
                TitleComboBox.SelectedIndex = 2;
            }
            else if(ClientSelected.Title.Equals("Dr."))
            {
                TitleComboBox.SelectedIndex = 3;
            }
            else if(ClientSelected.Title.Equals("Sir"))
            {
                TitleComboBox.SelectedIndex = 4;
            }

            if (ClientSelected.SecondPhoneNumType!= null)
            {
                if (ClientSelected.SecondPhoneNumType.Equals("Home"))
                {
                    Phone2TypeComboBox.SelectedIndex = 0;
                }
                else if (ClientSelected.SecondPhoneNumType.Equals("Cell"))
                {
                    Phone2TypeComboBox.SelectedIndex = 1;
                }
                else if (ClientSelected.SecondPhoneNumType.Equals("Work"))
                {
                    Phone2TypeComboBox.SelectedIndex = 2;
                }

                PhoneNumber2AreaCodeTextBox.Text = ClientSelected.SecondPhoneNumAC;
                Phone2TextBox.Text = ClientSelected.SecondPhoneNum;

                if(ClientSelected.Folder != null)
                {
                    FolderTextBox.Text = ClientSelected.Folder.ToString();
                }

                if(ClientSelected.Co_ != null)
                {
                    CoTextBox.Text = ClientSelected.Co_.ToString();
                }

                if(ClientSelected.Codes != null)
                {
                    CodesTextBox.Text = ClientSelected.Codes;
                }

                if(ClientSelected.Class != null)
                {
                    ClassTextBox.Text = ClientSelected.Class;
                }

                BalanceDueTextBox.Text = ClientSelected.BalanceDue.ToString();

                if (ClientSelected.BalanceDue > 0)
                {
                    BalanceDueTextBox.Background = new SolidColorBrush(Colors.Red);
                }
                
                if(ClientSelected.Email != null)
                {
                    EmailTextBox.Text= ClientSelected.Email;
                }

               
                DateAddedTextBox.Text = ClientSelected.DateAdded.ToString();
                if(ClientSelected.IsInactive)
                {
                    IsInactiveCheckBox.IsChecked = true;
                }
            }
            
        }

        private void PatientsDataGridCellValueChanged(object sender, RoutedEventArgs e)
        {
            PatientsDataGrid.CommitEdit();
        }
        
        private void ProceduresDataGridCellValueChanged(object sender, RoutedEventArgs e)
        {
            PatientProceduresDataGrid.CommitEdit();
        }

        private void DashBoardButton_Click(object sender, RoutedEventArgs e)
        {
            PlanetVetWindow pvw = new PlanetVetWindow();
            pvw.Show();
            this.Close();
        }

        private void PatientsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Patient p = (Patient)PatientsDataGrid.SelectedItem;
                AddProcedureWindow.SelectedPatient = p;
                AddProcedureButton.IsEnabled = true;
                DeleteProcedureButton.IsEnabled = true;
                UploadImageButton.IsEnabled = true;
                SaveClientChanges.IsEnabled = true;
                AddDocumentToPatientButton.IsEnabled = true;
                AddDocumentToPatientWindow.SelectedPatient = p;
                //Get list of procedures for patient
                PlanetVetEntities pve = new PlanetVetEntities();
                List<Procedure> ProceduresDoneOnPatient = pve.Procedures.Where(pr => pr.PatientID == p.PatientID).ToList();
                PatientProceduresDataGrid.ItemsSource = ProceduresDoneOnPatient;
                PatientProceduresDataGrid.Columns.Remove(PatientProceduresDataGrid.Columns[0]);
                PatientProceduresDataGrid.Columns[0].Header = "Procedure Category";
                PatientProceduresDataGrid.Columns[1].Header = "Description";
                PatientProceduresDataGrid.Columns.Remove(PatientProceduresDataGrid.Columns[2]);
                PatientProceduresDataGrid.Columns[2].Header = "Charge to Client";

                List<InventoryLog> InventoryUsedOnPatient = pve.InventoryLogs.Where(inv => inv.PatientID == p.PatientID).ToList();
                ItemsUsedOnPatientDataGrid.ItemsSource = InventoryUsedOnPatient;

                ItemsUsedOnPatientDataGrid.Columns.Remove(ItemsUsedOnPatientDataGrid.Columns[0]);
                ItemsUsedOnPatientDataGrid.Columns[1].Header = "Item Name";
                ItemsUsedOnPatientDataGrid.Columns.Remove(ItemsUsedOnPatientDataGrid.Columns[2]);
                ItemsUsedOnPatientDataGrid.Columns[4].Header = "Employeye Initials";
                ItemsUsedOnPatientDataGrid.Columns[5].Header = "Charge to Client";


                UploadImageButton.IsEnabled = true;

                //Documents attached to patient
                List<PatientDocument> DocumentsPerPatient = pve.PatientDocuments.Where(doc => doc.PatientID == p.PatientID).ToList();
                PatientDocumentsDataGrid.ItemsSource = DocumentsPerPatient;
                PatientDocumentsDataGrid.Columns.Remove(PatientDocumentsDataGrid.Columns[0]);
                PatientDocumentsDataGrid.Columns.Remove(PatientDocumentsDataGrid.Columns[0]);
                PatientDocumentsDataGrid.Columns.Remove(PatientDocumentsDataGrid.Columns[2]);

                if (p.Image == null)
                {
                    BitmapImage bmi = new BitmapImage();
                    bmi.BeginInit();
                    bmi.UriSource = new Uri("https://s32.postimg.org/tjsb6eoqd/Planet_Vet_Logo.png");
                    bmi.EndInit();

                    PatientImage.Source = bmi;
                }
                else
                {
                    byte[] ImageBytes = p.Image;
                    PatientImage.Source = LoadImage(ImageBytes);
                }
            }catch
            {
                AddProcedureButton.IsEnabled = false;
                DeleteProcedureButton.IsEnabled = false;
            }
        }

        private static BitmapImage LoadImage(byte[] imageData)
        {
            if (imageData == null || imageData.Length == 0) return null;
            var image = new BitmapImage();
            using (var mem = new MemoryStream(imageData))
            {
                mem.Position = 0;
                image.BeginInit();
                image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = null;
                image.StreamSource = mem;
                image.EndInit();
            }
            image.Freeze();
            return image;
        }

        private void NewPatientComboBox_Click(object sender, RoutedEventArgs e)
        {
            AddNewPatientWindow anpw = new AddNewPatientWindow();
            anpw.SelectedClient = SelectedClient;
            anpw.ShowDialog();

            PlanetVetEntities pve = new PlanetVetEntities();
            Client ClientSelected = pve.Clients.Where(client => client.FirstName.Contains(FirstNameTextBox.Text) && client.LastName.Contains(LastNameTextBox.Text)).FirstOrDefault();
            SelectedClient = ClientSelected;
            var ClientsPets = pve.Patients.Where(pet => pet.ClientID == ClientSelected.ClientId);
            PatientsDataGrid.ItemsSource = ClientsPets.ToList();

            PatientsDataGrid.Columns.Remove(PatientsDataGrid.Columns[0]);
            PatientsDataGrid.Columns.Remove(PatientsDataGrid.Columns[0]);
            PatientsDataGrid.Columns.Remove(PatientsDataGrid.Columns[0]);
            PatientsDataGrid.Columns.Remove(PatientsDataGrid.Columns[0]);
            PatientsDataGrid.Columns.Remove(PatientsDataGrid.Columns[16]);
            PatientsDataGrid.Columns[11].Header = "Weight type";
        }

        private void IsInactiveCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            PlanetVetEntities pve = new PlanetVetEntities();
            SelectedClient.IsInactive = true;
            pve.Clients.Attach(SelectedClient);
            pve.Entry(SelectedClient).State = System.Data.Entity.EntityState.Modified;
            pve.SaveChanges();
        }

        private void IsInactiveCheckbox_Unchecked(object sender, RoutedEventArgs e)
        {
            PlanetVetEntities pve = new PlanetVetEntities();
            SelectedClient.IsInactive = false;
            pve.Clients.Attach(SelectedClient);
            pve.Entry(SelectedClient).State = System.Data.Entity.EntityState.Modified;
            pve.SaveChanges();
        }

        private void SaveClientChanges_Click(object sender, RoutedEventArgs e)
        {
            PlanetVetEntities pve = new PlanetVetEntities();

            SelectedClient.FirstName = FirstNameTextBox.Text;
            SelectedClient.MiddleInitial = MiddleInitialTextBox.Text;
            SelectedClient.LastName = LastNameTextBox.Text;
            SelectedClient.Address = AddressTextBox.Text;
            SelectedClient.State = StateTextBox.Text;
            SelectedClient.City = StateTextBox.Text;
            SelectedClient.ZIP = ZIPCodeTextBox.Text;
            SelectedClient.County = CountryTextBox.Text;
            SelectedClient.Company = CompanyTextBox.Text;
            SelectedClient.FaxNumber = FaxNumberTextBox.Text;
            SelectedClient.FirstPhoneNumType = Phone1TypeComboBox.Text;
            SelectedClient.FirstPhoneNumAC = PhoneNumber1AreaCodeTextBox.Text;
            SelectedClient.FirstPhoneNum = Phone1TextBox.Text;
            SelectedClient.SecondPhoneNumType = Phone2TypeComboBox.Text;
            SelectedClient.SecondPhoneNumAC = PhoneNumber2AreaCodeTextBox.Text;
            SelectedClient.SecondPhoneNum = Phone2TextBox.Text;
            SelectedClient.Folder = FolderTextBox.Text;
            SelectedClient.Co_ = CoTextBox.Text;
            SelectedClient.Title = TitleComboBox.Text;
            SelectedClient.Codes = CodesTextBox.Text;
            SelectedClient.Class = ClassTextBox.Text;
            SelectedClient.Email = EmailTextBox.Text;

            pve.Clients.Attach(SelectedClient);
            pve.Entry(SelectedClient).State = System.Data.Entity.EntityState.Modified;
            pve.SaveChanges();

            Client ClientSelected = SelectedClient;
            ClientFirstNameTextBox.Text = SelectedClient.FirstName;
            ClientLastNameTextBox.Text = SelectedClient.LastName;
            FirstNameTextBox.Text = SelectedClient.FirstName;
            LastNameTextBox.Text = SelectedClient.LastName;
            AddressTextBox.Text = ClientSelected.Address;
            StateTextBox.Text = ClientSelected.State;
            CityTextBox.Text = ClientSelected.City;
            ZIPCodeTextBox.Text = ClientSelected.ZIP;
            CountryTextBox.Text = ClientSelected.County;
            PhoneNumber1AreaCodeTextBox.Text = ClientSelected.FirstPhoneNumAC;
            Phone1TextBox.Text = ClientSelected.FirstPhoneNum;



            if (ClientSelected.MiddleInitial != null)
            {
                MiddleInitialTextBox.Text = ClientSelected.MiddleInitial;
            }

            if (ClientSelected.FirstPhoneNumType.Equals("Home"))
            {
                Phone1TypeComboBox.SelectedIndex = 0;
            }
            else if (ClientSelected.FirstPhoneNumType.Equals("Cell"))
            {
                Phone1TypeComboBox.SelectedIndex = 1;
            }
            else if (ClientSelected.FirstPhoneNumType.Equals("Work"))
            {
                Phone1TypeComboBox.SelectedIndex = 2;
            }

            if (ClientSelected.Title.Equals("Mr."))
            {
                TitleComboBox.SelectedIndex = 0;
            }
            else if (ClientSelected.Title.Equals("Mrs."))
            {
                TitleComboBox.SelectedIndex = 1;
            }
            else if (ClientSelected.Title.Equals("Ms."))
            {
                TitleComboBox.SelectedIndex = 2;
            }
            else if (ClientSelected.Title.Equals("Dr."))
            {
                TitleComboBox.SelectedIndex = 3;
            }
            else if (ClientSelected.Title.Equals("Sir"))
            {
                TitleComboBox.SelectedIndex = 4;
            }

            if (ClientSelected.SecondPhoneNumType != null)
            {
                if (ClientSelected.SecondPhoneNumType.Equals("Home"))
                {
                    Phone2TypeComboBox.SelectedIndex = 0;
                }
                else if (ClientSelected.SecondPhoneNumType.Equals("Cell"))
                {
                    Phone2TypeComboBox.SelectedIndex = 1;
                }
                else if (ClientSelected.SecondPhoneNumType.Equals("Work"))
                {
                    Phone2TypeComboBox.SelectedIndex = 2;
                }

                PhoneNumber2AreaCodeTextBox.Text = ClientSelected.SecondPhoneNumAC;
                Phone2TextBox.Text = ClientSelected.SecondPhoneNum;

                if (ClientSelected.Folder != null)
                {
                    FolderTextBox.Text = ClientSelected.Folder.ToString();
                }

                if (ClientSelected.Co_ != null)
                {
                    CoTextBox.Text = ClientSelected.Co_.ToString();
                }

                if (ClientSelected.Codes != null)
                {
                    CodesTextBox.Text = ClientSelected.Codes;
                }

                if (ClientSelected.Class != null)
                {
                    ClassTextBox.Text = ClientSelected.Class;
                }

                BalanceDueTextBox.Text = ClientSelected.BalanceDue.ToString();

                if (ClientSelected.BalanceDue > 0)
                {
                    BalanceDueTextBox.Background = new SolidColorBrush(Colors.Red);
                }

                if (ClientSelected.Email != null)
                {
                    EmailTextBox.Text = ClientSelected.Email;
                }


                DateAddedTextBox.Text = ClientSelected.DateAdded.ToString();
                if (ClientSelected.IsInactive)
                {
                    IsInactiveCheckBox.IsChecked = true;
                }
            }
        }

        private void UploadImageButton_Click(object sender, RoutedEventArgs e)
        {
            PlanetVetEntities pve = new PlanetVetEntities();
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.ShowDialog();

            PatientImage.Source = new BitmapImage(new Uri(dlg.FileName));

            FileStream fs = new FileStream(dlg.FileName, FileMode.Open,FileAccess.Read);

            byte[] data = new byte[fs.Length];
            fs.Read(data, 0, System.Convert.ToInt32(fs.Length));
            fs.Close();

            Patient p = (Patient)PatientsDataGrid.SelectedItem;
            p.Image = data;

            pve.Patients.Attach(p);
            pve.Entry(p).State = System.Data.Entity.EntityState.Modified;
            pve.SaveChanges();

            Client ClientSelected = pve.Clients.Where(client => client.FirstName.Contains(FirstNameTextBox.Text) && client.LastName.Contains(LastNameTextBox.Text)).FirstOrDefault();
            SelectedClient = ClientSelected;
            var ClientsPets = pve.Patients.Where(pet => pet.ClientID == ClientSelected.ClientId);
            PatientsDataGrid.ItemsSource = ClientsPets.ToList();
        }

        private void PatientsDataGrid_CurrentCellChanged(object sender, EventArgs e)
        {
            PlanetVetEntities pve = new PlanetVetEntities();
            try
            {
                Patient p = (Patient)PatientsDataGrid.SelectedItem;
                pve.Patients.Attach(p);
                pve.Entry(p).State = System.Data.Entity.EntityState.Modified;
                pve.SaveChanges();
            }
            catch
            {

            }

        }

        private void PatientDocumentsDataGrid_CurrentCellChanged(object sender, EventArgs e)
        {
            PlanetVetEntities pve = new PlanetVetEntities();
            try
            {
                PatientDocument D = (PatientDocument)PatientDocumentsDataGrid.SelectedItem;
                pve.PatientDocuments.Attach(D);
                pve.Entry(D).State = System.Data.Entity.EntityState.Modified;
                pve.SaveChanges();
            }
            catch
            {

            }

        }

        private void ItemsUsedDataGrid_CurrentCellChanged(object sender, EventArgs e)
        {
            PlanetVetEntities pve = new PlanetVetEntities();
            try
            {
                InventoryLog il = (InventoryLog)ItemsUsedOnPatientDataGrid.SelectedItem;
                pve.InventoryLogs.Attach(il);
                pve.Entry(il).State = System.Data.Entity.EntityState.Modified;
                pve.SaveChanges();

                BalanceCalculator BC = new BalanceCalculator();
                double? NewBalance = BC.CalculateBalance(SelectedClient.ClientId);
                pve.Clients.Attach(SelectedClient);
                SelectedClient.BalanceDue = NewBalance;
                pve.Entry(SelectedClient).State = System.Data.Entity.EntityState.Modified;
                pve.SaveChanges();

                BalanceDueTextBox.Text = SelectedClient.BalanceDue.ToString();
            }
            catch
            {

            }

        }

        private void PatientProceduresDataGrid_CurrentCellChanged(object sender, EventArgs e)
            {
                 PlanetVetEntities pve = new PlanetVetEntities();
            try { 
            
                Procedure p = (Procedure)PatientProceduresDataGrid.SelectedItem;
                pve.Procedures.Attach(p);
                pve.Entry(p).State = System.Data.Entity.EntityState.Modified;
                pve.SaveChanges();

                BalanceCalculator BC = new BalanceCalculator();
                double? NewBalance = BC.CalculateBalance(SelectedClient.ClientId);
                pve.Clients.Attach(SelectedClient);
                SelectedClient.BalanceDue = NewBalance;
                pve.Entry(SelectedClient).State = System.Data.Entity.EntityState.Modified;
                pve.SaveChanges();

                //update cost in text box
                BalanceDueTextBox.Text = SelectedClient.BalanceDue.ToString();

                if (SelectedClient.BalanceDue > 0)
                {
                    BalanceDueTextBox.Background = new SolidColorBrush(Colors.Red);
                }else
                {
                    BalanceDueTextBox.Background = new SolidColorBrush(Colors.Green);
                }
            }
              catch
              {
    
               }
             }

        private void AddProcedureButton_Click(object sender, RoutedEventArgs e)
        {
            AddProcedureWindow apw = new AddProcedureWindow();
            apw.ShowDialog();

            //Get list of procedures for patient
            PlanetVetEntities pve = new PlanetVetEntities();
            List<Procedure> ProceduresDoneOnPatient   = pve.Procedures.Where(pr => pr.PatientID == AddProcedureWindow.SelectedPatient.PatientID).ToList();
            PatientProceduresDataGrid.ItemsSource = ProceduresDoneOnPatient;
            Client PatientOwner = pve.Clients.Where(po => po.ClientId == AddProcedureWindow.SelectedPatient.ClientID).FirstOrDefault();
            BalanceDueTextBox.Text = PatientOwner.BalanceDue.ToString();


            if (SelectedClient.BalanceDue > 0)
            {
                BalanceDueTextBox.Background = new SolidColorBrush(Colors.Red);
            }

            PatientProceduresDataGrid.Columns.Remove(PatientProceduresDataGrid.Columns[0]);
            PatientProceduresDataGrid.Columns[0].Header = "Procedure Category";
            PatientProceduresDataGrid.Columns[1].Header = "Description";
            PatientProceduresDataGrid.Columns.Remove(PatientProceduresDataGrid.Columns[2]);
            PatientProceduresDataGrid.Columns[2].Header = "Charge to Client";
        }

        private void PatientProceduresDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //
            //
            //
        }

        private void DeleteProcedureButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PlanetVetEntities pve = new PlanetVetEntities();
                Procedure p = (Procedure)PatientProceduresDataGrid.SelectedItem;
                Procedure SelectedProcedure = pve.Procedures.Where(pro => pro.Id == p.Id).FirstOrDefault();
                //Take the selected procedure, subtract the cost from the client's balance due, then update the cost box
                pve.Clients.Attach(SelectedClient);
                SelectedClient.BalanceDue -= p.ProcedureCost;
                pve.Entry(SelectedClient).State = System.Data.Entity.EntityState.Modified;
                pve.Procedures.Remove(SelectedProcedure);
                pve.SaveChanges();

                Patient Pat = (Patient)PatientsDataGrid.SelectedItem;
                AddProcedureWindow.SelectedPatient = Pat;

                SelectedPatient = Pat;

                BalanceDueTextBox.Text = SelectedClient.BalanceDue.ToString();


                if (SelectedClient.BalanceDue > 0)
                {
                    BalanceDueTextBox.Background = new SolidColorBrush(Colors.Red);
                }else
                {
                    BalanceDueTextBox.Background = new SolidColorBrush(Colors.Green);
                }

                //Get list of procedures for patient
                List<Procedure> ProceduresDoneOnPatient = pve.Procedures.Where(pr => pr.PatientID == p.PatientID).ToList();
                PatientProceduresDataGrid.ItemsSource = ProceduresDoneOnPatient;

                PatientProceduresDataGrid.Columns.Remove(PatientProceduresDataGrid.Columns[0]);
                PatientProceduresDataGrid.Columns[0].Header = "Procedure Category";
                PatientProceduresDataGrid.Columns[1].Header = "Description";
                PatientProceduresDataGrid.Columns.Remove(PatientProceduresDataGrid.Columns[2]);
                PatientProceduresDataGrid.Columns[2].Header = "Charge to Client";


            }
            catch
            {
                
            }
        }

        private void AddItemsButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Patient Pat = (Patient)PatientsDataGrid.SelectedItem;
                AddInventoryForPatientWindow.SelectedPatient = Pat;
                PlanetVetEntities pve = new PlanetVetEntities();
                AddInventoryForPatientWindow aifpw = new AddInventoryForPatientWindow();
                aifpw.ShowDialog();

                Patient p = (Patient)PatientsDataGrid.SelectedItem;
                ItemsUsedOnPatientDataGrid.ItemsSource = pve.InventoryLogs.Where(inv => inv.PatientID == p.PatientID).ToList();

                Client c = pve.Clients.Where(cl => cl.ClientId == p.ClientID).FirstOrDefault();
                BalanceDueTextBox.Text = c.BalanceDue.ToString();

                if (c.BalanceDue > 0)
                {
                    BalanceDueTextBox.Background = new SolidColorBrush(Colors.Red);
                }
                else
                {
                    BalanceDueTextBox.Background = new SolidColorBrush(Colors.Green);
                }
                ItemsUsedOnPatientDataGrid.Columns.Remove(ItemsUsedOnPatientDataGrid.Columns[0]);
                ItemsUsedOnPatientDataGrid.Columns[1].Header = "Item Name";
                ItemsUsedOnPatientDataGrid.Columns.Remove(ItemsUsedOnPatientDataGrid.Columns[2]);
                ItemsUsedOnPatientDataGrid.Columns[4].Header = "Employeye Initials";
                ItemsUsedOnPatientDataGrid.Columns[5].Header = "Charge to Client";
            }
            catch
            {

            }
        }

        private void RemoveItemButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PlanetVetEntities pve = new PlanetVetEntities();
                InventoryLog il = (InventoryLog)ItemsUsedOnPatientDataGrid.SelectedItem;
                Patient Pat = (Patient)PatientsDataGrid.SelectedItem;

                Client PatientOwner = pve.Clients.Where(po => po.ClientId == Pat.ClientID).FirstOrDefault();
                pve.Clients.Attach(PatientOwner);
                PatientOwner.BalanceDue -= il.ChargeToClient;
                pve.Entry(PatientOwner).State = System.Data.Entity.EntityState.Modified;

                pve.InventoryLogs.Attach(il);
                pve.InventoryLogs.Remove(il);
                pve.SaveChanges();

                ItemsUsedOnPatientDataGrid.ItemsSource = pve.InventoryLogs.Where(inv => inv.PatientID == Pat.PatientID).ToList();
                BalanceDueTextBox.Text = PatientOwner.BalanceDue.ToString();

                ItemsUsedOnPatientDataGrid.Columns.Remove(ItemsUsedOnPatientDataGrid.Columns[0]);
                ItemsUsedOnPatientDataGrid.Columns[1].Header = "Item Name";
                ItemsUsedOnPatientDataGrid.Columns.Remove(ItemsUsedOnPatientDataGrid.Columns[2]);
                ItemsUsedOnPatientDataGrid.Columns[4].Header = "Employeye Initials";
                ItemsUsedOnPatientDataGrid.Columns[5].Header = "Charge to Client";
            }
            catch
            {

            }
            }

        private void AddDocumentToPatientButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AddDocumentToPatientWindow adtpw = new AddDocumentToPatientWindow();
                adtpw.ShowDialog();

                Patient Pat = (Patient)PatientsDataGrid.SelectedItem;

                PlanetVetEntities pve = new PlanetVetEntities();
                List<PatientDocument> DocumentsPerPatient = pve.PatientDocuments.Where(doc => doc.PatientID == Pat.PatientID).ToList();
                PatientDocumentsDataGrid.ItemsSource = DocumentsPerPatient;

                PatientDocumentsDataGrid.Columns.Remove(PatientDocumentsDataGrid.Columns[0]);
                PatientDocumentsDataGrid.Columns.Remove(PatientDocumentsDataGrid.Columns[0]);
                PatientDocumentsDataGrid.Columns.Remove(PatientDocumentsDataGrid.Columns[2]);
            }
            catch
            {

            }
            }

        private void DeleteDocumentButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PlanetVetEntities pve = new PlanetVetEntities();
                PatientDocument D = (PatientDocument)PatientDocumentsDataGrid.SelectedItem;
                pve.PatientDocuments.Attach(D);
                pve.PatientDocuments.Remove(D);
                pve.SaveChanges();

                Patient Pat = (Patient)PatientsDataGrid.SelectedItem;
                List<PatientDocument> DocumentsPerPatient = pve.PatientDocuments.Where(doc => doc.PatientID == Pat.PatientID).ToList();
                PatientDocumentsDataGrid.ItemsSource = DocumentsPerPatient;

                PatientDocumentsDataGrid.Columns.Remove(PatientDocumentsDataGrid.Columns[0]);
                PatientDocumentsDataGrid.Columns.Remove(PatientDocumentsDataGrid.Columns[0]);
                PatientDocumentsDataGrid.Columns.Remove(PatientDocumentsDataGrid.Columns[2]);
            }
            catch
            {

            }
        }

        private void PatientDocumentsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                PatientDocument pd = (PatientDocument)PatientDocumentsDataGrid.SelectedItem;
                String Path = pd.Path;
                System.Diagnostics.Process.Start(Path);
            }
            catch
            {

            }
        }
    }
}
