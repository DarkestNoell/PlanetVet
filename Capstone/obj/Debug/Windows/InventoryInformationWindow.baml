   M S B A M L   `   `   `  ����T  PMahApps.Metro, Version=1.2.4.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	   C ?Capstone, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:CapstoneCapstone 5   	   1   +Capstone.Windows.InventoryInformationWindow   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:Capstone     5   	     � Title$  Client Search��5	   	   $��409.213��6   $��668.824��60    � Icon$; 5https://s32.postimg.org/tjsb6eoqd/Planet_Vet_Logo.png��5
   	   .��5      �  � ColumnDefinitions 5   
   �� 5      $
��189* �6   �� 5      $
��472* �6   .+�5   
   �� -   5         ��Name$ InventoryCategoryListBox��5      $
��Left=�64   $	��284��6O   $	��Top=�6\   $	��200��6t   $��0,26,0,0q�6�   $��2��6�   6�   �� 5   
   -   5         ��Name$ textBox��5      $
��Left=�6#   $��23��6>    �� TextWrapping$
 Wrap=�6J   $	��Top=�6^   $	��120��6v   $��80,0,0,0q�6�   $��2��6�   �� 5   
   -   5         ��Name$ label��5      $��Item Search��6   $
��Left=�65   $	��Top=�6P   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ InventoryDataGrid��5      $
��Left=�6.   $��	16,26,0,0q�6I   $	��Top=�6\   $	��284��6t   $	��446��6�   $��1��6�   6�   �� 5   
   -   5         ��Name$ AddCategoryButton��5      $��ADD CATEGORY��6,   $
��Left=�6C   $��
35,315,0,0q�6^   $	��Top=�6r   $��96��6�   6�   �� 5   
   -   5        $! AddInventoryItemToLogButton��5      $��ADD ITEM��66   $
��Left=�6I   $��
16,315,0,0q�6d   $	��Top=�6x   $	��161��6�   $��1��6�   6�   �� 5   
   -   5        $ RemoveItemFromLogButton��5      $��REMOVE SELECTED ITEM��62   $
��Left=�6Q   $��316,315,0,0q�6l   $	��Top=�6�   $	��146��6�   $��1��6�   6�   �� 5   
   -   5        $ label1��5      $�� ��6    $��1��6+   $
��Left=�6;   $��26,0,0,0q�6V   $	��Top=�6h   �� 5   
   -	   5        $ ViewInventoryLogButton��5      $��VIEW LOG��61   $
��Left=�6D   $��	301,0,0,0q�6_   $	��Top=�6r   $	��161��6�   $��1��6�   6�   �� 5   
   -
   5        $ ViewInventoryButton��5      $��VIEW INVENTORY��6.   $
��Left=�6G   $��16,0,0,0q�6b   $	��Top=�6t   $	��161��6�   $��1��6�   6�   �� 5   
   -   5        $ DeleteSelectedCategory��5      $��DELETE SELECTED CATEGORY��61   $
��Left=�6T   $��
10,340,0,0q�6o   $	��Top=�6�   $	��147��6�   6�   �� 5   
   -   5        $ DashboardButton��5      $��	DASHBOARD��6*   $
��Left=�6>   $��
16,348,0,0q�6Y   $	��Top=�6m   $	��446��6�   $��1��6�   6�   5      5      