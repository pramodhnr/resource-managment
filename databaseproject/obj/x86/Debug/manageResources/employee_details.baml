   M S B A M L   `   `   `  ����  databaseproject&     databaseproject.employee_details   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  employee_details��5   	   $	��356��6"   $	��504��6/    � WindowStartupLocation$ CenterScreen=�6;   .��5      �  J� IsManipulationEnabled . ���	#FF90D4FF.+�5   
   �� -   5        $��stackPanel_labels��5   R   $	��160��6   $��Right=�6"   $��
0,86,370,0q�6>   $	��Top=�6k   $	��100��6�   .+�5      �� -   5        $��label_department��5   5   $��
Department��6   $��40��6)   65   �� 5      -   5        $��label_group��5   0   $��Group��6   $��40��6$   60   �� 5	      -   5        $��
label_team��5	   /   $
��Team��6   $��40��6#   6/   �� 5
      -   5        $��label_project��5
   2   $��Project��6   $��40��6&   62   5      �� 5   
   -   5        $��stackPanel_comboboxes��5   Q   $	��160��6   $
��Left=�6"   $��
118,86,0,0q�6=   $	��Top=�6n   $	��200��6�   .+�5      �� -   5        $��comboBox_department��5   #   $��40��6   $	��199��6>    �� 
IsEditable .  .   �� 
IsReadOnly .  6z   �� 5      -   5        $��comboBox_group��5   5   $��40��6    . $	��199��6K    .   .  6j   �� 5      -	   5        $��comboBox_team��5   5   $��40��6    . $	��199��6J    .  6V   �� 5      -
   5        $��comboBox_project��5   5   $��40��6    . $	��199��6M    .   .  6w   5      �� 5   
   -   5        $��button_adddepartment��5   X   $��+��6   $��23��6   $
��Left=�6)   $��
333,87,0,0q�6D   $	��Top=�6t   $��18��6�   6�   �� 5   
   -   5        $��button_viewdpeartment��5   \   $
��view��6   $��23��6    $
��Left=�6,   $��365,0,0,208q�6G   $��Bottom=�6y   $��32��6�   �� 5   
   -   5        $��button_addproject��5   X   $��+��6   $��23��6   $
��Left=�6)   $��
333,0,0,87q�6D   $��Bottom=�6q   $��18��6�   6�   �� 5   
   -   5        $��button_viewproject��5   [   $
��view��6   $��23��6    $
��Left=�6,   $��
365,0,0,88q�6G   $��Bottom=�6u   $��32��6�   �� 5   
   -   5        $��button_addteam��5   Y   $��+��6   $��23��6   $
��Left=�6)   $��333,167,0,0q�6D   $	��Top=�6o   $��18��6�   6�   �� 5   
   -   5        $��button_viewteam��5   \   $
��view��6   $��23��6    $
��Left=�6,   $��365,0,0,128q�6G   $��Bottom=�6s   $��32��6�   �� 5   
   -   5        $��button_addgroup��5   Y   $��+��6   $��23��6   $
��Left=�6)   $��333,127,0,0q�6D   $	��Top=�6p   $��18��6�   6�   �� 5   
   -   5        $��button_viewgroup��5   \   $
��view��6   $��23��6    $
��Left=�6,   $��365,0,0,168q�6G   $��Bottom=�6t   $��32��6�   �� 5   
   -   5        $��button_manageresources��5   h   $��Manage resources��6   $��23��6,   $
��Left=�68   $��164,273,0,0q�6S   $	��Top=�6�   $	��107��6�   6�   �� 5   
   -   5        $��button_deletedepartment��5   ^   $��delete��6   $��23��6"   $
��Left=�6.   $��411,0,0,207q�6I   $��Bottom=�6}   $��42��6�   6�   �� 5   
   -   5        $��button1_deletegroup��5   ^   $��delete��6   $��23��6"   $
��Left=�6.   $��411,0,0,167q�6I   $��Bottom=�6y   $��42��6�   6�   �� 5   
   -   5        $��button_deleteteam��5   ^   $��delete��6   $��23��6"   $
��Left=�6.   $��411,0,0,127q�6I   $��Bottom=�6w   $��42��6�   6�   �� 5   
   -   5        $��button_deleteProject��5   ]   $��delete��6   $��23��6"   $
��Left=�6.   $��
411,0,0,87q�6I   $��Bottom=�6y   $��42��6�   6�   5      5       