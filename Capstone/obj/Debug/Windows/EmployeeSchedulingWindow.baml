   M S B A M L   `   `   `  ����T  PMahApps.Metro, Version=1.2.4.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	   C ?Capstone, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:CapstoneCapstone 5   	   /   )Capstone.Windows.EmployeeSchedulingWindow   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:Capstone     5   	     � Title$  Appointment Menu��5	   	   $��409.213��6"   $��875.491��63    � Icon$; 5https://s32.postimg.org/tjsb6eoqd/Planet_Vet_Logo.png��5
   	   .��5      � .+�5   
   (  "System.Windows.Controls.DatePicker  -   5          Name$ DatePickerCalendar��5      $
��Left=�61   $	��Top=�6L   $��94��6d   $	��344��6p   $��0,34,0,0q�6|   6�   �� 5   
   -   5         ��Name$ label��5      $E��?Select a date for the week you'd like to schedule employees for��6   $
��Left=�6i   $	��Top=�6�   $��0,8,0,0q�6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ MondayDataGrid��5      $
��Left=�6+   $��	0,154,0,0q�6F   $	��Top=�6Y   $	��104��6q   $	��268��6~   6�     5   
   -   5        $ TuesdayDataGrid��5      $
��Left=�6,   $��307,154,0,0q�6G   $	��Top=�6\   $	��104��6t   $	��268��6�   6�     5   
   -   5        $ ThursdayDataGrid��5      $
��Left=�6-   $��	0,294,0,0q�6H   $	��Top=�6[   $��85��6s   $	��268��6   6�     5   
   -   5        $ FridayDataGrid��5      $
��Left=�6+   $��287,294,0,0q�6F   $	��Top=�6[   $��85��6s   $	��268��6   6�     5   
   -   5        $ WednesdayDataGrid��5      $
��Left=�6.   $��580,154,0,0q�6I   $	��Top=�6^   $	��104��6v   $	��268��6�   6�     5   
   -   5        $ SaturdayDataGrid��5      $
��Left=�6-   $��580,294,0,0q�6H   $	��Top=�6]   $��85��6u   $	��268��6�   6�     5   
   -	   5        $ SundayDataGrid��5      $
��Left=�6+   $��
391,31,0,0q�6F   $	��Top=�6Z   $��97��6r   $	��476��6~    J� RenderTransformOrigin$ 	0.5,0.642&�6�   6�   �� 5   
   -
   5        $ label1��5      $��Sunday��6    $
��Left=�61   $��	391,0,0,0q�6L   $	��Top=�6_   �� 5   
   -   5        $ label1_Copy��5      $��Monday��6%   $
��Left=�66   $��	0,128,0,0q�6Q   $	��Top=�6d   �� 5   
   -   5        $ label1_Copy1��5      $��Tuesday��6&   $
��Left=�68   $��287,128,0,0q�6S   $	��Top=�6h   �� 5   
   -   5        $ label1_Copy2��5      $��	Wednesday��6&   $
��Left=�6:   $��580,126,0,0q�6U   $	��Top=�6j   �� 5   
   -   5        $ label1_Copy3��5      $��Thursday��6&   $
��Left=�69   $��	0,263,0,0q�6T   $	��Top=�6g   �� 5   
   -   5        $ label1_Copy4��5      $��Friday��6&   $
��Left=�67   $��287,263,0,0q�6R   $	��Top=�6g   �� 5   
   -   5        $ label1_Copy5��5      $��Saturday��6&   $
��Left=�69   $��580,263,0,0q�6T   $	��Top=�6i   �� 5   
   -   5         ��Name$ SundayAddButton��5      $	��ADD��6*   $
��Left=�68   $��	445,1,0,0q�6S   $	��Top=�6f   $��75��6~   6�   �� 5   
   -   5        $ SundayDeleteButton��5      $��DELETE��6-   $
��Left=�6>   $��	561,1,0,0q�6Y   $	��Top=�6l   $��75��6�   6�   �� 5   
   -   5        $ MondayAddButton��5      $	��ADD��6*   $
��Left=�68   $��
55,128,0,0q�6S   $	��Top=�6g   $��75��6   6�   �� 5   
   -   5        $ MondayDeleteButton��5      $��DELETE��6-   $
��Left=�6>   $��171,128,0,0q�6Y   $	��Top=�6n   $��75��6�   6�   �� 5    
   -   5        $ TuesdayAddButton��5       $	��ADD��6+   $
��Left=�69   $��353,128,0,0q�6T   $	��Top=�6i   $��75��6�   6�   �� 5!   
   -   5        $ TuesdayDeleteButton��5!      $��DELETE��6.   $
��Left=�6?   $��469,128,0,0q�6Z   $	��Top=�6o   $��75��6�   6�   �� 5"   
   -   5        $ WednesdayAddButton��5"      $	��ADD��6-   $
��Left=�6;   $��666,128,0,0q�6V   $	��Top=�6k   $��75��6�   6�   �� 5#   
   -   5        $ WednesdayDeleteButton��5#      $��DELETE��60   $
��Left=�6A   $��782,128,0,0q�6\   $	��Top=�6q   $��75��6�   6�   �� 5$   
   -   5        $ ThursdayAddButton��5$      $	��ADD��6,   $
��Left=�6:   $��
65,263,0,0q�6U   $	��Top=�6i   $��75��6�   6�   �� 5%   
   -   5        $ ThursdayDeleteButton��5%      $��DELETE��6/   $
��Left=�6@   $��181,263,0,0q�6[   $	��Top=�6p   $��75��6�   6�   �� 5&   
   -   5        $ FridayAddButton��5&      $	��ADD��6*   $
��Left=�68   $��344,264,0,0q�6S   $	��Top=�6h   $��75��6�   6�   �� 5'   
   -   5        $ FridayDeleteButton��5'      $��DELETE��6-   $
��Left=�6>   $��445,264,0,0q�6Y   $	��Top=�6n   $��75��6�   6�   �� 5(   
   -   5        $ SaturdayAddButton��5(      $	��ADD��6,   $
��Left=�6:   $��647,263,0,0q�6U   $	��Top=�6j   $��75��6�   6�   �� 5)   
   -   5        $ SaturdayDeleteButton��5)      $��DELETE��6/   $
��Left=�6@   $��763,263,0,0q�6[   $	��Top=�6p   $��75��6�   6�   �� 5*   
   -   5        $ BackToDashboardButton��5*      $��BACK TO DASHBOARD��60   $
��Left=�6L   $��	735,1,0,0q�6g   $	��Top=�6z   $	��132��6�   6�   5,      5-      