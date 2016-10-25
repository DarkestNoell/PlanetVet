using MahApps.Metro.Controls;
using Microsoft.Win32;
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
    public partial class AddDocumentToPatientWindow : MetroWindow
    {
        public static Patient SelectedPatient { get; set; }
        List<PatientDocument> DocumentsAdded = new List<PatientDocument>();
        public AddDocumentToPatientWindow()
        {
            InitializeComponent();
            FillCategories();
        }

        private void FillCategories()
        {
            PlanetVetEntities pve = new PlanetVetEntities();
            List<ProcedureCategory> AllCategories = pve.ProcedureCategories.ToList();
            foreach(ProcedureCategory pc in AllCategories)
            {
                CategoryComboBox.Items.Add(pc.CategoryName);
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PlanetVetEntities pve = new PlanetVetEntities();
                OpenFileDialog choofdlog = new OpenFileDialog();
                choofdlog.Filter = "All Files (*.*)|*.*";
                choofdlog.FilterIndex = 1;
                choofdlog.Multiselect = true;

                choofdlog.ShowDialog();
                string sFileName = choofdlog.FileName;
                string[] arrAllFiles = choofdlog.FileNames; //used when Multiselect = true  
                

                if (arrAllFiles.Length > 1 && !(CategoryComboBox.Text.Equals("")))
                {
                    foreach (string s in arrAllFiles)
                    {
                        PatientDocument D = new PatientDocument();
                        D.Description = DescriptionTextBox.Text;
                        D.Path = s;
                        D.PatientID = SelectedPatient.PatientID;
                        D.DocumentCategory = CategoryComboBox.Text;
                        D.DateAdded = DateTime.Now;
                        DocumentsAdded.Add(D);
                    }
                }else
                {
                    PatientDocument D = new PatientDocument();
                    D.Description = DescriptionTextBox.Text;
                    D.Path = sFileName;
                    D.PatientID = SelectedPatient.PatientID;
                    D.DocumentCategory = CategoryComboBox.Text;
                    D.DateAdded = DateTime.Now;
                    DocumentsAdded.Add(D);
                }

                foreach(PatientDocument d in DocumentsAdded)
                {
                    pve.PatientDocuments.Add(d);
                }

                pve.SaveChanges();
                this.Close();
            }
            catch
            {

            }
        }
    }
}
