   M S B A M L   `   `   `  ����Q  MWPFTextBoxAutoComplete, Version=1.0.0.2, Culture=neutral, PublicKeyToken=null_Dclr-namespace:WPFTextBoxAutoComplete;assembly=WPFTextBoxAutoCompleteWPFTextBoxAutoComplete  5   	   T PMahApps.Metro, Version=1.2.4.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls 5   	   C ?Capstone, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:CapstoneCapstone 5   	   +   %Capstone.Windows.AddAppointmentWindow   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   X	behaviorsDclr-namespace:WPFTextBoxAutoComplete;assembly=WPFTextBoxAutoComplete    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:Capstone     5   	     � Title$  Appointment Menu��5
   	   $��409.213��6"   $��668.824��63    � Icon$; 5https://s32.postimg.org/tjsb6eoqd/Planet_Vet_Logo.png��5   	   .��5      � .+�5   
   �� -   5         ��Name$ DoctorComboBox��5      $
��Left=�6+   $��	63,41,0,0q�6F   $	��Top=�6Y   $	��200��6q   �� 5   
   -   5         ��Name$ label��5      $	��Dr.��6   $
��Left=�6-   $��	10,41,0,0q�6H   $	��Top=�6[   �� 5   
   -   5         ��Name$ ClientLastNameTextBox��5      $
��Left=�61   $��23��6L   $��
63,100,0,0q�6X    �� TextWrapping$
 Wrap=�6l   $	��Top=�6�   $	��200��6�   �� 5   
   -   5        $ label1��5      $��Client��6    $
��Left=�61   $��
10,100,0,0q�6L   $	��Top=�6`   �� 5   
   -   5        $ AreaCodeTextBox��5      $
��Left=�6+   $��23��6F   $��365,185,0,0q�6R   $
 Wrap=�6g   $	��Top=�6{   $��66��6�   �� 5   
   -   5        $ PhoneNumberTextBox��5      $
��Left=�6.   $��23��6I   $��440,185,0,0q�6U   $
 Wrap=�6j   $	��Top=�6~   $	��120��6�   �� 5   
   -   5        $ label2��5      $��Patient��6    $
��Left=�62   $��
10,216,0,0q�6M   $	��Top=�6a   �� 5   
   -   5        $ label3��5      $��	Area Code��6    $
��Left=�64   $��366,154,0,0q�6O   $	��Top=�6d   �� 5   
   -	   5        $ label4��5      $��Phone #��6    $
��Left=�62   $��306,185,0,0q�6M   $	��Top=�6b   �� 5   
   -
   5        $ label5��5      $��Phone #��6    $
��Left=�62   $��440,154,0,0q�6M   $	��Top=�6b   �� 5   
   -   5        $ SpeciesComboBox��5      $
��Left=�6,   $��365,216,0,0q�6G   $	��Top=�6\   $	��120��6t   .@�5      �� $��Feline��6   $
��Left=�6,   $	��118��6G   �� 5      $��Canine��6   $
��Left=�6,   $	��118��6G   5      �� 5   
   -   5        $ label6��5      $��Species��6    $
��Left=�62   $��306,216,0,0q�6M   $	��Top=�6b   �� 5   
   -   5        $ BreedComboBox��5      $
��Left=�6*   $��365,246,0,0q�6E   $	��Top=�6Z   $	��120��6r   �� 5   
   -   5        $ label7��5      $��Breed��6    $
��Left=�60   $��315,246,0,0q�6K   $	��Top=�6`   �� 5   
   -   5        $ label8��5      $��Weight��6    $
��Left=�61   $��315,278,0,0q�6L   $	��Top=�6a   �� 5   
   -   5         ��Name$ ScheduleButton��5      $��schedule��6)   $
��Left=�6<   $��
0,355,-6,0q�6W   $	��Top=�6k   $	��667��6�   ���	#FF0DE45B6�   �� 5    
   -   5        $ label9��5       $%��Scheduling new appointment for:��6    $
��Left=�6J   $��
139,10,0,0q�6e   $	��Top=�6y   �� 5!   
   -   5        $ DateTimeDisplayLabel��5!      $��DisplayDateTimeHere��6.   $
��Left=�6L   $��
360,10,0,0q�6g   $	��Top=�6{   �� 5"   
   -   5        $ ExamRoomComboBox��5"      $
��Left=�6-   $��
365,41,0,0q�6H   $	��Top=�6\   $	��195��6t   �� 5#   
   -   5        $ label10��5#      $��	Exam Room��6!   $
��Left=�65   $��
283,41,0,0q�6P   $	��Top=�6d   �� 5$   
   -   5        $ PatientComboBox��5$      $
��Left=�6,   $��
63,216,0,0q�6G   $	��Top=�6[   $	��200��6s   .@�5%      �� $��New Patient��6   $
��Left=�61   $	��198��6L   5&      �� 5'   
   -   5        $ NewPatientNameTextBox��5'      $
��Left=�61   $��23��6L   $��
63,246,0,0q�6X   $
 Wrap=�6l   $	��Top=�6�   $	��200��6�   �� 5(   
   -   5        $ label11��5(      $
��Name��6!   $
��Left=�60   $��
10,246,0,0q�6K   $	��Top=�6_   �� 5)   
   -   5         ��Name$ RecommendedSearchListBox��5)      $
��Left=�64   $��85��6O   $��
63,126,0,0q�6[   $	��Top=�6o   $	��200��6�   6�   �� 5*   
   -   5        $ button1��5*      $��search
��6"   $
��Left=�6=   $��503,101,0,0q�6X   $	��Top=�6m   $��57��6�   $��28��6�   6�   �� 5+   
   -   5        $ label12��5+      $��	Last Name��6!   $
��Left=�65   $��	63,72,0,0q�6P   $	��Top=�6c   �� 5,   
   -   5        $ ClientFirstNameTextBox��5,      $
��Left=�62   $��23��6M   $��285,100,0,0q�6Y   $
 Wrap=�6n   $	��Top=�6�   $	��200��6�   �� 5-   
   -   5        $ label12_Copy��5-      $��
First Name��6&   $
��Left=�6;   $��
283,72,0,0q�6V   $	��Top=�6j   �� 5.   
   -   5        $ WeightTextBox��5.      $
��Left=�6)   $��8��6D   $��363,278,0,0q�6O   $
 Wrap=�6d   $	��Top=�6x   $	��121��6�    J� RenderTransformOrigin$ 0.945,0.538&�6�   �� 5/   
   -   5        $ NotesTextBox��5/      $
��Left=�6(   $��41��6C   $��363,309,0,0q�6O   $
 Wrap=�6d   $	��Top=�6x   $	��288��6�   �� 50   
   -   5        $ label15��50      $��Notes:��6!   $
��Left=�62   $��314,312,0,0q�6M   $	��Top=�6b   51      52      