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
    /// Interaction logic for AddAppointmentWindow.xaml
    /// </summary>
    public partial class AddAppointmentWindow : MetroWindow
    {
        public DateTime SelectedDate { get; set; }

        public AddAppointmentWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Populate Combo Boxes accordingly
            DateTimeDisplayLabel.Content = SelectedDate.ToShortDateString();
            PlanetVetEntities pve = new PlanetVetEntities();
            foreach(Employee emp in pve.Employees)
            {
                if (emp.IsDoctor)
                {
                    DoctorComboBox.Items.Add(emp.FirstName + " " + emp.LastName);
                }
            }

            foreach(ExamRoom er in pve.ExamRooms)
            {
                ExamRoomComboBox.Items.Add(er.ExamRoomNumber);
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
            var ClientsPets = pve.Patients.Where(pet => pet.ClientID == ClientSelected.ClientId);
            foreach (Patient p in ClientsPets)
            {
                PatientComboBox.Items.Add(p.Name);
            }

            ClientFirstNameTextBox.Text = ClientName[1];
            ClientLastNameTextBox.Text = ClientName[0];
            PhoneNumberTextBox.Text = ClientSelected.FirstPhoneNum.ToString();
            AreaCodeTextBox.Text = ClientSelected.FirstPhoneNumAC.ToString();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            PlanetVetEntities pve = new PlanetVetEntities();
            var ClientsFound = pve.Clients.Where(client => client.FirstName.Contains(ClientFirstNameTextBox.Text) && client.LastName.Contains(ClientLastNameTextBox.Text));
            RecommendedSearchListBox.Items.Clear();
            foreach (Client c in ClientsFound)
            {
                RecommendedSearchListBox.Items.Add(c.LastName + "," + c.FirstName);
            }
        }

        private void SpeciesComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PlanetVetEntities pve = new PlanetVetEntities();
            BreedComboBox.Items.Clear();
            String SelectedSpecies = ((ComboBoxItem)SpeciesComboBox.SelectedItem).Content.ToString();
            var BreedList = pve.Breeds.Where(breed => breed.SpeciesName.Contains(SelectedSpecies));
            foreach(Breed b in BreedList)
            {
                BreedComboBox.Items.Add(b.BreedName);
            }
        }

        private void PatientComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            String SelectedPatient= PatientComboBox.SelectedItem.ToString();
            PlanetVetEntities pve = new PlanetVetEntities();
            if(!SelectedPatient.Equals("New Patient"))
            {
                Client curClient = pve.Clients.Where(c => c.FirstName.Equals(ClientFirstNameTextBox.Text) && c.LastName.Equals(ClientLastNameTextBox.Text)).FirstOrDefault();
                var ClientsPet = pve.Patients.Where(pet => pet.ClientID == curClient.ClientId && pet.Name.Equals(SelectedPatient)).FirstOrDefault();
                SpeciesComboBox.Text = ClientsPet.Species.ToString();
                BreedComboBox.Text = ClientsPet.Breed.ToString();
                WeightTextBox.Text = ClientsPet.Weight.ToString();
            }
            }
        }
    }

