   M S B A M L   `   `   `  ����T  PMahApps.Metro, Version=1.2.4.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	   C ?Capstone, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:CapstoneCapstone 5   	      Capstone.MainWindow   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:Capstone     5   	     � Title$  Login��5	   	   $��321.366��6   $��433.758��6(    � 
ResizeMode$ CanMinimize=�68    � Icon$; 5https://s32.postimg.org/tjsb6eoqd/Planet_Vet_Logo.png��5
   	   .��5      � 
�������$��0,0,0,-7q�6   $
��Left=�60   $	��447��6K    � ColumnDefinitions 5   
   �� 5      �� 5      $��0* �6   �� 5      $��0* �6   .+�5   
   �� -   5         ��Name$ signInButton��5      $��Sign In��6'   $
��Left=�69   $��
82,220,0,0q�6T   $	��Top=�6h   $	��124��6�   $��2q�6�   $��Microsoft YaHei)�6�   $��25��6�   ���	#FF93FFB6���	#FF8C73FF6�   �� 5   
   -   5         ��Name$ userNameBox��5      $��82,130,73,144q�6'   $��Segoe UI Semilight)�6>    � ToolTip$ User ID��6^   4  .System.Windows.Automation.AutomationProperties   IsRequiredForForm .    HelpText$ User ID��6�   $��26��6�   	 �� 
CaretBrush
	 �   �.��6�   ��5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5   -   �� 6   6sys&clr-namespace:System;assembly=mscorlib     6-   
 �� 
TargetType"
 ��6    �� 	Resources 5         CueBannerBrush j� 
AlignmentX j� 
AlignmentY j� Stretch !� Visual��%�   &	        !� 5      $
 Left=�6=   $ Center=�6O   $
 None=�6c    5      �� 5   "   $��User ID��6(   
�������$��Arial Narrow)�6M   5      5       �� Triggers 5      P� 5       P� Property � �� �� Empty P� Value# Z 62   . �5      ��  �� Property � �� �� Value# [  6;   5      P� 5        � �� 62   Z� . �5!      ��  � ��# [  6;   5"      P� 5#       �@J�IsKeyboardFocused . . �5$      ��  � ��
 �����6;   5%      5'      .��5(      5)      �� 5*   
   $;��5https://s32.postimg.org/tjsb6eoqd/Planet_Vet_Logo.png��6   $��98,10,85,170q�6O   �� 5+   
   -   5         ��Name$ label��5+      $��User ID��6   $
��Left=�61   $��
10,128,0,0q�6L   $	��Top=�6`   $��28��6x   $
��Bold"�6�   $��14(�6�   $��58��6�   �� 5,   
   -   5        $ 
label_Copy��5,      $��Password��6$   $
��Left=�67   $��
10,159,0,0q�6R   $	��Top=�6f   $��28��6~   $
��Bold"�6�   $��14(�6�   $��72��6�   G� 5-   
   -   5         G�Name$ passwordBox��5-      $
��Left=�6+   $��
82,161,0,0q�6F   $	��Top=�6Z   $	��292��6r    G� Password$ password��6~   6�   �� 5.   
   -   5         ��Name$ KeepMeLoggedInCheckBox��5.      $��Keep me logged in��63   $
��Left=�6O   $��
82,192,0,0q�6j   $	��Top=�6~   ���	#FF61FFA96�   �� 5/   
   -   5        $ cantLoginButton��5/      $��Can't log in?��6*   $
��Left=�6B   $��250,220,0,0q�6]   $	��Top=�6r   $	��124��6�   $��2q�6�   $��Microsoft YaHei)�6�   $��25��6�   ���	#FF93FFB6���	#FF8C73FF6  �� 50   
   -   5        $ createAccountButton��50      $#��Create a new employee account��6.   $
��Left=�6V   $��
82,265,0,0q�6q   $	��Top=�6�   $	��292��6�   $��2q�6�   $��Microsoft YaHei)�6�   $��25��6�   ���	#FFF2FF9C���	#FF322E2E6  �� 51   
   $
��Left=�6   $��21��6/   $��-5,245,-11,0q�6;   $	��Top=�6Q   $	��451��6i   $��3��6u   54      55      