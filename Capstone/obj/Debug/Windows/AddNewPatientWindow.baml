   M S B A M L   `   `   `  ����Q  MWPFTextBoxAutoComplete, Version=1.0.0.2, Culture=neutral, PublicKeyToken=null_Dclr-namespace:WPFTextBoxAutoComplete;assembly=WPFTextBoxAutoCompleteWPFTextBoxAutoComplete  5   	   T PMahApps.Metro, Version=1.2.4.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls 5   	   C ?Capstone, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:CapstoneCapstone 5   	   *   $Capstone.Windows.AddNewPatientWindow   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   X	behaviorsDclr-namespace:WPFTextBoxAutoComplete;assembly=WPFTextBoxAutoComplete    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:Capstone     5   	     � Title$  New Patient��5
   	   $��216.7��6   $��668.824��6,    � Icon$; 5https://s32.postimg.org/tjsb6eoqd/Planet_Vet_Logo.png��5   	   .��5      �  � ColumnDefinitions 5   
   �� 5      $
��246* �6   �� 5      $
��415* �6   .+�5   
   �� -   5         ��Name$ PatientNameTextBox��5      $
��Left=�6.   $��23��6I   $��	25,66,0,0q�6U    �� TextWrapping$
 Wrap=�6h   $	��Top=�6|   $	��120��6�   �� 5   
   -   5         ��Name$ PatientSexComboBox��5      $
��Left=�6/   $��
168,66,0,0q�6J   $	��Top=�6^   $	��120��6v   $��2��6�   .@�5      �� $
��Male��6   $
��Left=�6*   $	��118��6E   �� 5      $��Female��6   $
��Left=�6,   $	��118��6G   5      �� 5   
   -   5        $ ClientAgeTextBox��5      $
��Left=�6,   $��23��6G   $��	56,66,0,0q�6S   $
 Wrap=�6f   $	��Top=�6z   $	��120��6�   $��1��6�   �� 5   
   -   5        $ PatientBreedComboBox��5      $
��Left=�61   $��265,119,0,0q�6L   $	��Top=�6a   $	��120��6y    J� RenderTransformOrigin$ 1.294,3.127&�6�   $��1��6�   �� 5   
   -   5        $ PatientSpeciesComboBox��5      $
��Left=�63   $��
265,73,0,0q�6N   $	��Top=�6b   $	��120��6z   $��1��6�   .@�5      �� $��Canine��6   $
��Left=�6,   $	��118��6G   �� 5      $��Feline��6   $
��Left=�6,   $	��118��6G   5      �� 5   
   -   5        $ PatientColorTextBox��5      $
��Left=�6/   $��23��6J   $��
25,119,0,0q�6V   $
 Wrap=�6j   $	��Top=�6~   $	��120��6�   �� 5   
   -   5         ��Name$ label��5      $-��'Please input new user information below��6   $
��Left=�6Q   $��10,0,0,0q�6l   $	��Top=�6~   $
��Bold"�6�   $��2��6�   �� 5   
   -   5        $ 
label_Copy��5      $��*��6$   $
��Left=�60   $��	10,23,0,0q�6K   $	��Top=�6^   ���	#FFE00E0E$
��Bold"�6�   $��Italic$�6�   �� 5   
   -	   5        $ label1��5      $ ��indicates a required field��6    $
��Left=�6E   $��	25,23,0,0q�6`   $	��Top=�6s   $
��Bold"�6�   �� 5    
   -
   5         ��Name$ AddNewPatientButton��5       $��ADD NEW PATIENT��6.   $
��Left=�6H   $��	0,164,0,0q�6c   $	��Top=�6v   $	��661��6�   $��27��6�   ���	#FF8B4098$��2��6�   6�   �� 5!   
   -   5        $ label2��5!      $
��Name��6    $
��Left=�6/   $��	25,43,0,0q�6J   $	��Top=�6]   �� 5"   
   -   5        $ label2_Copy��5"      $	��Sex��6%   $
��Left=�63   $��
168,43,0,0q�6N   $	��Top=�6b   �� 5#   
   -   5        $ label2_Copy1��5#      $	��Age��6&   $
��Left=�64   $��	56,40,0,0q�6O   $	��Top=�6b   $��1��6z   �� 5$   
   -   5        $ label2_Copy2��5$      $��Species��6&   $
��Left=�68   $��
265,48,0,0q�6S   $	��Top=�6g   $��1��6   �� 5%   
   -   5        $ label2_Copy3��5%      $��Breed��6&   $
��Left=�66   $��
265,93,0,0q�6Q   $	��Top=�6e   $��1��6}   �� 5&   
   -   5        $ label2_Copy4��5&      $��Color��6&   $
��Left=�66   $��	25,93,0,0q�6Q   $	��Top=�6d   �� 5'   
   -   5        $ label_Copy1��5'      $��*��6%   $
��Left=�61   $��	67,43,0,0q�6L   $	��Top=�6_   ���	#FFE00E0E$
��Bold"�6�   $��Italic$�6�   �� 5(   
   -   5        $ label_Copy2��5(      $��*��6%   $
��Left=�61   $��
196,43,0,0q�6L   $	��Top=�6`   ���	#FFE00E0E$
��Bold"�6�   $��Italic$�6�   �� 5)   
   -   5        $ label_Copy3��5)      $��*��6%   $
��Left=�61   $��	87,40,0,0q�6L   $	��Top=�6_   ���	#FFE00E0E$
��Bold"�6�   $��Italic$�6�   $��1��6�   �� 5*   
   -   5        $ label_Copy4��5*      $��*��6%   $
��Left=�61   $��
315,51,0,0q�6L   $	��Top=�6`   ���	#FFE00E0E$
��Bold"�6�   $��Italic$�6�   $��1��6�   �� 5+   
   -   5        $ label_Copy5��5+      $��*��6%   $
��Left=�61   $��
300,93,0,0q�6L   $	��Top=�6`   ���	#FFE00E0E$
��Bold"�6�   $��Italic$�6�   $��1��6�   �� 5,   
   -   5        $ label_Copy6��5,      $��*��6%   $
��Left=�61   $��	64,92,0,0q�6L   $	��Top=�6_   ���	#FFE00E0E$
��Bold"�6�   $��Italic$�6�   5.      5/      