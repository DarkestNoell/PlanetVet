   M S B A M L   `   `   `  ����T  PMahApps.Metro, Version=1.2.4.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	   C ?Capstone, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:CapstoneCapstone 5   	   5   /Capstone.Windows.ClientInformationDisplayWindow   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:Capstone     5   	     � Title$  Client Information��5	   	   $��740.713��6$   $��1800.324��65    � Icon$; 5https://s32.postimg.org/tjsb6eoqd/Planet_Vet_Logo.png��5
   	   .��5      � $��0,-24,-8,-1q�6    � ColumnDefinitions 5   
   �� 5      $��1031* �6   �� 5      $
��769* �6   .+�5   
   �� -   5         ��Name$ ClientLastNameTextBox��5      $
��Left=�61   $��23��6L   $��	37,78,0,0q�6X    �� TextWrapping$
 Wrap=�6k   $	��Top=�6   $	��120��6�   �� 5   
   -   5        $ ClientFirstNameTextBox��5      $
��Left=�62   $��23��6M   $��
175,78,0,0q�6Y   $
 Wrap=�6m   $	��Top=�6�   $	��120��6�   �� 5   
   -   5         ��Name$ SearchButton��5      $��SEARCH��6'   $
��Left=�68   $��
314,78,0,0q�6S   $	��Top=�6g   $��75��6   6�   �� 5   
   -   5        $ FirstNameTextBox��5      $
��Left=�6,   $��23��6G   $��
31,246,0,0q�6S   $
 Wrap=�6g   $	��Top=�6{   $	��120��6�   �� 5   
   -   5        $ MiddleInitialTextBox��5      $
��Left=�60   $��23��6K   $��169,246,0,0q�6W   $
 Wrap=�6l   $	��Top=�6�   $��42��6�   �� 5   
   -   5        $ LastNameTextBox��5      $
��Left=�6+   $��23��6F   $��242,246,0,0q�6R   $
 Wrap=�6g   $	��Top=�6{   $	��120��6�   �� 5   
   -   5        $ AddressTextBox��5      $
��Left=�6*   $��23��6E   $��414,276,0,0q�6Q   $
 Wrap=�6f   $	��Top=�6z   $	��120��6�   �� 5   
   -   5        $ StateTextBox��5      $
��Left=�6(   $��23��6C   $��565,276,0,0q�6O   $
 Wrap=�6d   $	��Top=�6x   $��59��6�   �� 5   
   -	   5        $! PhoneNumber1AreaCodeTextBox��5      $
��Left=�67   $��23��6R   $��169,374,0,0q�6^   $
 Wrap=�6s   $	��Top=�6�   $��57��6�   �� 5   
   -
   5        $ CountryTextBox��5      $
��Left=�6*   $��23��6E   $��414,376,0,0q�6Q   $
 Wrap=�6f   $	��Top=�6z   $	��120��6�   �� 5   
   -   5        $ ZIPCodeTextBox��5      $
��Left=�6*   $��23��6E   $��565,324,0,0q�6Q   $
 Wrap=�6f   $	��Top=�6z   $��60��6�   �� 5   
   -   5        $ CityTextBox��5      $
��Left=�6'   $��23��6B   $��414,324,0,0q�6N   $
 Wrap=�6c   $	��Top=�6w   $	��120��6�   �� 5   
   -   5        $! PhoneNumber2AreaCodeTextBox��5      $
��Left=�67   $��23��6R   $��169,418,0,0q�6^   $
 Wrap=�6s   $	��Top=�6�   $��57��6�   �� 5   
   -   5        $ Phone2TextBox��5      $
��Left=�6)   $��23��6D   $��242,418,0,0q�6P   $
 Wrap=�6e   $	��Top=�6y   $	��120��6�   �� 5   
   -   5        $ CompanyTextBox��5      $
��Left=�6*   $��23��6E   $��
31,294,0,0q�6Q   $
 Wrap=�6e   $	��Top=�6y   $	��120��6�   �� 5   
   -   5        $ BalanceDueTextBox��5      $
��Left=�6-   $��23��6H   $��472,142,0,0q�6T   $
 Wrap=�6i   $	��Top=�6}   $	��120��6�   
���   ����	#FF23FF00$
��0.00��6�   �� 5    
   -   5        $ FaxNumberTextBox��5       $
��Left=�6,   $��23��6G   $��
31,472,0,0q�6S   $
 Wrap=�6g   $	��Top=�6{   $	��120��6�   �� 5!   
   -   5        $ EmailTextBox��5!      $
��Left=�6(   $��23��6C   $��169,472,0,0q�6O   $
 Wrap=�6d   $	��Top=�6x   $	��193��6�   �� 5"   
   -   5        $ CodesTextBox��5"      $
��Left=�6(   $��23��6C   $��242,520,0,0q�6O   $
 Wrap=�6d   $	��Top=�6x   $	��120��6�   �� 5#   
   -   5        $ DateAddedTextBox��5#      $
��Left=�6,   $��23��6G   $��
472,77,0,0q�6S   $
 Wrap=�6g   $	��Top=�6{   $	��120��6�   �� 5$   
   -   5        $ FolderTextBox��5$      $
��Left=�6)   $��23��6D   $��
31,520,0,0q�6P   $
 Wrap=�6d   $	��Top=�6x   $��78��6�   �� 5%   
   -   5        $ 	CoTextBox��5%      $
��Left=�6%   $��23��6@   $��139,520,0,0q�6L   $
 Wrap=�6a   $	��Top=�6u   $��72��6�   �� 5&   
   -   5        $ Phone1TextBox��5&      $
��Left=�6)   $��23��6D   $��242,374,0,0q�6P   $
 Wrap=�6e   $	��Top=�6y   $	��120��6�   &   System.Windows.Controls.DataGrid  5'   
   -   5          Name$ PatientsDataGrid��5'      $
��Left=�6-   $��
-3,584,0,0q�6H   $	��Top=�6\   $	��148��6t   $
��1793��6�   $��2��6�   �� 5(   
   -   5         ��Name$ PatientImage��5(      $
��Left=�6&   $	��243��6A   $��666,255,0,0q�6N   $	��Top=�6c   $	��366��6{   $;��5https://s32.postimg.org/tjsb6eoqd/Planet_Vet_Logo.png��6�   $��2��6�   �� 5*   
   -   5        $ UploadImageButton��5+      $��23��5*      $
��Left=�6   $��788,0,0,208q�5+   
   $��Bottom=�6:   $	��107��5,   
   $��UPLOAD IMAGE��6   6-   �� 5.   
   -   5         ��Name$ label��5.      $��	Last Name��6   $
��Left=�63   $��	37,52,0,0q�6N   $	��Top=�6a   �� 5/   
   -   5        $ 
label_Copy��5/      $��
First Name��6$   $
��Left=�69   $��
175,52,0,0q�6T   $	��Top=�6h   �� 50   
   -   5        $ label_Copy1��50      $��Title��6%   $
��Left=�65   $��
31,166,0,0q�6P   $	��Top=�6d   �� 51   
   -   5        $ label_Copy2��51      $��
First Name��6%   $
��Left=�6:   $��
31,224,0,0q�6U   $	��Top=�6i   �� 52   
   -   5        $ label_Copy3��52      $��MI��6%   $
��Left=�62   $��169,224,0,0q�6M   $	��Top=�6b   �� 53   
   -    5        $ label_Copy4��53      $��	Last Name��6%   $
��Left=�69   $��242,224,0,0q�6T   $	��Top=�6i   �� 54   
   -!   5        $ label_Copy5��54      $��Address��6%   $
��Left=�67   $��414,250,0,0q�6R   $	��Top=�6g   �� 55   
   -"   5        $ label_Copy6��55      $��State��6%   $
��Left=�65   $��565,250,0,0q�6P   $	��Top=�6e   �� 56   
   -#   5        $ label_Copy7��56      $
��City��6%   $
��Left=�64   $��414,298,0,0q�6O   $	��Top=�6d   �� 57   
   -$   5        $ label_Copy8��57      $��ZIP Code��6%   $
��Left=�68   $��565,298,0,0q�6S   $	��Top=�6h   �� 58   
   -%   5        $ label_Copy9��58      $��County��6%   $
��Left=�66   $��414,348,0,0q�6Q   $	��Top=�6f   �� 59   
   -&   5        $ label1��59      $��Company��6    $
��Left=�62   $��
31,272,0,0q�6M   $	��Top=�6a   �� 5:   
   -'   5        $ label2��5:      $��Phone 1 Type��6    $
��Left=�67   $��
31,348,0,0q�6R   $	��Top=�6f   �� 5;   
   -(   5        $ label2_Copy��5;      $��Phone 2 Type��6%   $
��Left=�6<   $��
31,392,0,0q�6W   $	��Top=�6k   �� 5<   
   -)   5        $ label2_Copy1��5<      $��AC��6&   $
��Left=�63   $��169,348,0,0q�6N   $	��Top=�6c   �� 5=   
   -*   5        $ label2_Copy2��5=      $��	Phone 1 #��6&   $
��Left=�6:   $��242,342,0,0q�6U   $	��Top=�6j   �� 5>   
   -+   5        $ label2_Copy3��5>      $��AC��6&   $
��Left=�63   $��168,392,0,0q�6N   $	��Top=�6c   �� 5?   
   -,   5        $ label2_Copy4��5?      $��Phone 2#��6&   $
��Left=�69   $��242,392,0,0q�6T   $	��Top=�6i   �� 5@   
   --   5        	 ��Name$	 Phone1TypeComboBox��5@      $
��Left=�6/   $��
31,374,0,0q�6J   $	��Top=�6^   $	��120��6v   .@�5A      �� $
��Home��6   $
��Left=�6*   $	��118��6E   �� 5B      $
��Cell��6   $
��Left=�6*   $	��118��6E   �� 5C      $
��Work��6   $
��Left=�6*   $	��118��6E   5D      �� 5E   
   -.   5        $	 Phone2TypeComboBox��5E      $
��Left=�6/   $��
31,424,0,0q�6J   $	��Top=�6^   $	��120��6v   .@�5F      �� $
��Home��6   $
��Left=�6*   $	��118��6E   �� 5G      $
��Cell��6   $
��Left=�6*   $	��118��6E   �� 5H      $
��Work��6   $
��Left=�6*   $	��118��6E   5I      �� 5J   
   -/   5        $ label3��5J      $	��Fax��6    $
��Left=�6.   $��
31,446,0,0q�6I   $	��Top=�6]   $	��120��6u   �� 5K   
   -0   5        $ label4��5K      $��Email��6    $
��Left=�60   $��169,450,0,0q�6K   $	��Top=�6`   �� 5L   
   -1   5        $ label5��5L      $��Folder��6    $
��Left=�61   $��
31,494,0,0q�6L   $	��Top=�6`   �� 5M   
   -2   5        $ label5_Copy��5M      $	��Co.��6%   $
��Left=�63   $��139,494,0,0q�6N   $	��Top=�6c   �� 5N   
   -3   5        $ label5_Copy1��5N      $��Codes��6&   $
��Left=�66   $��242,494,0,0q�6Q   $	��Top=�6f   �� 5O   
   -4   5        $ ClassTextBox��5O      $
��Left=�6(   $��23��6C   $��381,520,0,0q�6O   $
 Wrap=�6d   $	��Top=�6x   $��56��6�   �� 5P   
   -5   5        $ label5_Copy3��5P      $��Class��6&   $
��Left=�66   $��381,494,0,0q�6Q   $	��Top=�6f   �� 5Q   
   -6   5        $ label6��5Q      $��
Date Added��6    $
��Left=�65   $��
472,52,0,0q�6P   $	��Top=�6d   �� 5R   
   -7   5        $ label6_Copy��5R      $��Balance Due��6%   $
��Left=�6;   $��472,116,0,0q�6V   $	��Top=�6k   
�������
���  ��6�   �� 5S   
   -8   5        $ label7��5S      $>��8Select a Patient Below to view that animal's record data��6    $
��Left=�6c   $��
-3,553,0,0q�6~   $	��Top=�6�   $
��Bold"�6�   �� 5T   
   -9   5        
 ��Name$
 IsInactiveCheckBox��5T      $��Client Inactive��6/   $
��Left=�6I   $��472,174,0,0q�6d   $	��Top=�6y   6�   �� 5U   
   -:   5         ��Name$ RecommendedSearchListBox��5U      $
��Left=�64   $��56��6O   $��
37,104,0,0q�6[   $	��Top=�6o   $	��258��6�   6�   �� 5V   
   -;   5        $ DashBoardButton��5V      $��	DASHBOARD��6*   $
��Left=�6>   $��	37,32,0,0q�6Y   $	��Top=�6l   $��75��6�   6�     5W   
   -<   5        $ PatientProceduresDataGrid��5W      $
��Left=�66   $��	95,87,0,0q�6Q   $	��Top=�6d   $	��233��6|   $	��664��6�   $��1��6  �� 5X   
   -=   5        $ label7_Copy1��5X      $��Procedure History��6&   $
��Left=�6B   $��	93,57,0,0q�6]   $	��Top=�6p   $
��Bold"�6�   $��52��6�   $��1��6�   �� 5Y   
   ->   5        $ NewPatientComboBox��5Y      $��New Patient��6-   $
��Left=�6C   $��326,554,0,0q�6^   $	��Top=�6s   $��92��6�   6�   �� 5Z   
   -?   5        $ AddProcedureButton��5Z      $��ADD Procedure��6-   $
��Left=�6E   $��
209,57,0,0q�6`   $	��Top=�6t   $	��106��6�   $��19��6�   $��1��6�   �� 5[   
   -@   5        $ DeleteProcedureButton��5[      $��Delete Procedure��60   $
��Left=�6K   $��
429,57,0,0q�6f   $	��Top=�6z   $	��106��6�   $��25��6�   $��1��6�   �� 5\   
   -A   5        $ SaveClientChanges��5\      $��SAVE CHANGES FOR CLIENT��6,   $
��Left=�6N   $��472,520,0,0q�6i   $	��Top=�6~   $	��156��6�   6�   �� 5]   
   -B   5        $	 TitleComboBox��5]      $
��Left=�6*   $��
31,197,0,0q�6E   $	��Top=�6Y   $	��120��6q   .@�5^      �� $	��Mr.��6   $
��Left=�6)   $	��118��6D   �� 5_      $
��Mrs.��6   $
��Left=�6*   $	��118��6E   �� 5`      $	��Ms.��6   $
��Left=�6)   $	��118��6D   �� 5a      $	��Dr.��6   $
��Left=�6)   $	��118��6D   �� 5b      $	��Sir��6   $
��Left=�6)   $	��118��6D   5c      �� 5d   
   -C   5        $ label8��5d      $��Patient Image:��6    $
��Left=�69   $��666,224,0,0q�6T   $	��Top=�6i   $
��Bold"�6�   �� 5e   
   -D   5        $ label7_Copy��5e      $��Items used on Patient��6%   $
��Left=�6E   $��
95,332,0,0q�6`   $	��Top=�6t   $
��Bold"�6�   $��52��6�   $��1��6�     5f   
   -E   5        $  ItemsUsedOnPatientDataGrid��5f      $
��Left=�67   $��
95,368,0,0q�6R   $	��Top=�6f   $	��216��6~   $	��664��6�   $��1��6�   �� 5g   
   -F   5        $ AddItemsButton��5g      $	��ADD��6)   $
��Left=�67   $��233,333,0,0q�6R   $	��Top=�6g   $	��106��6   $��19��6�   $��1��6�   �� 5h   
   -G   5        $ RemoveItemButton��5h      $��remove��6+   $
��Left=�6<   $��363,333,0,0q�6W   $	��Top=�6l   $	��106��6�   $��19��6�   $��1��6�     5i   
   -H   5        $ PatientDocumentsDataGrid��5i      $
��Left=�65   $��
616,87,0,0q�6P   $	��Top=�6d   $	��137��6|   $	��503��6�   $��2��6�   6�   �� 5j   
   -I   5        $ label9��5j      $��Patient Documents��6    $
��Left=�6<   $��
616,52,0,0q�6W   $	��Top=�6k   $
��Bold"�6�   �� 5k   
   -J   5        $  AddDocumentToPatientButton��5k      $	��ADD��65   $
��Left=�6C   $��
754,52,0,0q�6^   $	��Top=�6r   $��74��6�   6�   �� 5l   
   -K   5        $ DeleteDocumentButton��5l      $��DELETE DOCUMENT��6/   $
��Left=�6I   $��
894,53,0,0q�6d   $	��Top=�6x   $	��112��6�   6�   5m      5n      