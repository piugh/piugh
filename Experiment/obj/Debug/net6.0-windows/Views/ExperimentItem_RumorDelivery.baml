   M S B A M L   `   `   `  ����  
Experiment3    -Experiment.Views.ExperimentItem_RumorDelivery   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      T PPrism.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59$prismhttp://prismlibrary.com/  5      !  Prism.Mvvm.ViewModelLocator    AutoWireViewModel  True5      .��5      � .+�5   
   �� 
����·� �� CornerRadius$ 	0,0,20,20��6&   $��5 0 5 5q�6?   6R   �� 5   
   $
��Auto=�6   $��
20 0 20 20q�6:   .��5	      ��  �� Orientation$ Vertical=�6   .+�5
      �� $ 
Horizontal=�6   $��Center=�66   $��0 10 0 0q�6S   .+�5      �� $��投放谣言：��6   $	��100��6,   $��18(�68   �� 5      $��16(�6I   $��Center=�6W   ��6    �� *SelectedItem.Rumor.Name+6W   5      �� 5      
���   �$��3q�60   �� 5      $ 
Horizontal=�6   $
��Left=�66   $��0 10 0 0q�6Q   .+�5      �� $��创建者：��6   $	��100��6+   $��18(�67   �� 5      $��16(�6O   $��Center=�6]   ��6    �� *SelectedItem.Rumor.CreateName+6]   5      �� 5      $ 
Horizontal=�6   $
��Left=�66   $��0 10 0 0q�6Q   .+�5      �� $��备注信息：��6   $	��100��6,   $��18(�68   �� 5      $��16(�6K   $��Center=�6Y   ��6    �� *SelectedItem.Rumor.Remark+6Y   5      �� 5      $ 
Horizontal=�6   $
��Left=�66   $��0 10 0 0q�6Q   .+�5      �� $��谣言内容：��6   $	��100��6,   $��18(�68   �� 5      $��16(�6O   $��Center=�6]   $
��Wrap=�6x   $	��350��6�   ��6    �� *SelectedItem.Rumor.MeanString+6�   5      �� 5      $ 
Horizontal=�6   $
��Left=�66   $��0 10 0 0q�6Q   .+�5      �� $��投放步长：��6   $	��100��6,   $��18(�68   �� 5      $��没有定义��6    $��16(�6-   $��Center=�6;   5      �� 5      $ 
Horizontal=�6   $
��Left=�66   $��0 10 0 0q�6Q   .+�5       �� $��投放个体：��6   $	��100��6,   $��18(�68   �� 5!      $	��150��6   $��16(�6,   $��Center=�6:   5"      �� 5#      $ 
Horizontal=�6   $
��Left=�66   $��0 10 0 0q�6Q   .+�5$      �� $��个体属性：��6   $	��100��6,   $��18(�68   �� 5%      $��没有东西��6    $��16(�6,   $��Center=�6:   5&      5'      5)      5*      5+      