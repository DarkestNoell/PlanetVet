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
    /// Interaction logic for NewPatientWindow.xaml
    /// </summary>
    public partial class AddNewPatientWindow : MetroWindow
    {
        public Client SelectedClient { get; set; }
        public AddNewPatientWindow()
        {
            InitializeComponent();
        }

        private void ClientSpeciesTextBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PlanetVetEntities pve = new PlanetVetEntities();
            PatientBreedComboBox.Items.Clear();
            String SelectedSpecies = ((ComboBoxItem)PatientSpeciesComboBox.SelectedItem).Content.ToString();
            var BreedList = pve.Breeds.Where(breed => breed.SpeciesName.Contains(SelectedSpecies));
            foreach(Breed b in BreedList)
            {
                PatientBreedComboBox.Items.Add(b.BreedName);
            }
        }

        private Boolean AllItemsFilled()
        {
            if (ClientAgeTextBox.Text.Equals("") || PatientColorTextBox.Text.Equals("") || PatientNameTextBox.Text.Equals("") || PatientBreedComboBox.SelectedItem.Equals("")
                || PatientSexComboBox.SelectedItem.Equals("") || PatientSpeciesComboBox.SelectedItem.Equals(""))
            {
                return false;
            }

            return true;
        }

        private void AddNewPatientButton_Click(object sender, RoutedEventArgs e)
        {
            
            PlanetVetEntities pve = new PlanetVetEntities();
            String SelectedSpecies = PatientSpeciesComboBox.Text;
            String SelectedBreed = PatientBreedComboBox.Text;

            Species s = pve.Species.Where(species => species.SpeciesName.Equals(SelectedSpecies)).FirstOrDefault();
            Breed b = pve.Breeds.Where(breed => breed.BreedName.Equals(SelectedBreed)).FirstOrDefault();

            if (AllItemsFilled())
            {
                Patient p = new Patient()
                {
                    ClientID = SelectedClient.ClientId,
                    SpeciesID = s.Id,
                    BreedID = b.Id,
                    Species = s.SpeciesName,
                    Breed = b.BreedName,
                    Name = PatientNameTextBox.Text,
                    Sex = PatientSexComboBox.Text,
                    Age = ClientAgeTextBox.Text

                };

                pve.Patients.Add(p);
                pve.SaveChanges();
                MessageBox.Show("|" + p.Name + "| has been added as a pet of: |" + SelectedClient.LastName + "," + SelectedClient.FirstName + "|");
                this.Close();
            }else
            {
                MessageBox.Show("Please fill in all fields before continuing");
            }
        }
    }
}
