   M S B A M L   `   `   `  ����  databaseproject,    &databaseproject.Window_manageResources   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   9   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     6v   -   5        $��window_manageresources��5   �     � Title$  Window_manageResources��6	    � WindowStartupLocation$ CenterScreen=�6  .��5      �� $	��705��6   .+�5      � $	��365��6   $	��700��6   
 �� Top$ 7��6$    �� Left$ 0��63   ���	#FF90D4FF.+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��dataGrid_manageresources��5   �      AutoGenerateColumns .  $	��200��6e   $
��Left=�6r   $��	17,49,0,0q�6�   $	��Top=�6�   $	��645��6�   ��60   ��  �� Path$ resourcemanage.employee�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5	      ,  &System.Windows.Controls.DataGridColumn   Header$
 Name��6W      Width5  /System.Windows.Controls.DataGridLengthConverter$	 275 6e   	   
IsReadOnly	 .  1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6)   �� $ emp_name� �� Mode$ TwoWay=�6q     5
      $ Email id��6G   $	 275 6Y   	 .  
 6%   �� $ email_id�6e     5      $ Loading��6F   	 .     MaxWidth$ InfinityQ�6j   $	 100 6~   
 6%   �� $ loading�6~   5      �� 5   
   -   5        $��button_addResource��5   d   $��Add resource��6   $��23��6(   $
��Left=�64   $��465,264,0,0q�6O   $	��Top=�6~   $��88��6�   6�   �� 5   
   -   5        $��button_Delete��5   g   $��Delete resource��6   $��23��6+   $
��Left=�67   $��572,264,0,0q�6R   $	��Top=�6|   $��90��6�   6�   5      5      5      