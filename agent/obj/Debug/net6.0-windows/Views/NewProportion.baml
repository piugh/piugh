   M S B A M L   `   `   `  ����	  agent    agent.Views.NewProportion   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      T PPrism.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59$prismhttp://prismlibrary.com/  5      -   5        $��NewItem��5        � Title$  新建统计比例方案��5      $	��500��6   $	��880��6,   !  Prism.Mvvm.ViewModelLocator   AutoWireViewModel True5      .��5      � 
����ح�.+�5	   
   �� -   5        $��
tabcontrol��5	   *   $��10,10,10,10q�6    �� SelectedIndex 6<   �� *
TabIndex+.@�5
      �� $��基础信息��6   .��5      �  � RowDefinitions 5      �� 5      $��2* �6(   �� 5      $��2* �6(   �� 5      $��2* �6(   �� 5      $��1* �6(   .+�5      �� $��0��6   .+�5      �� $��方案名称:��6    $��40��60   $	��120��6<   $��30 40q�6H   $��14(�6W   �� 5      -   5        $��ItemName��5   G   $��40��5   "   $��150 40q�6.   $	��500��6>   $��14(�6J   ��5   "   ��  �� Path$ NewItem.Name�6G   5      �� 5      $��1��6   .+�5      �� $��创建者名称:��6    $��30��61   $	��120��6=   $��30 40q�6I   $��14(�6X   �� 5      -   5        $��	CreatName��5   G   $��40��5   "   $��150 40q�6.   $	��500��6>   $��14(�6J   ��5   "   �� *NewItem.CreateName+6G   5      �� 5      $��2��6   .+�5      �� $��备注信息：��6    $��30��60   $	��120��6<   $��30 40q�6H   $��14(�6W   �� 5      -   5        $��Remark��5   l   $��40��6"   $��150 40q�6.   $	��500��6>   $��14(�6J    �� TextWrapping$
 Wrap=�6X   ��5   "   �� *NewItem.Remark+5       �� 5!      $��4��6   .+�5"      �� $!��输入信息不能为空！��6    $��30��64   $��	320 0 0 0q�6@   $��14(�6S   
���  ��y�5#       �� *	Warning+�� 5$      $��	下一步��6!   $��30��6/   $	��120��6;    �� Right$ 20��6G   
 �� Top$ 10��6Y   
����ح�
������ ��5%   !   �� *Next1+5&      5'      5(      �� 5)      $��地理分布��6   .��5*      �  5+      �� 5,      $��6* �6(   �� 5-      $��1* �6(   .+�5/      �� $��0��6   .+�50      &   System.Windows.Controls.DataGrid  $	��360��6$   $	��780��62   $
��40 0q�6>   $��15(�6L      CanUserAddRows$ False��51       	   AutoGenerateColumns$	 False��67   
   CanUserResizeColumns$
 False��52          CanUserReorderColumns$ False��6=      CanUserSortColumns$ False��6[   ��53       �� *NewLocationConfigs+   Columns 54      0  *System.Windows.Controls.DataGridTextColumn  55   "   ,  &System.Windows.Controls.DataGridColumn   Header$ 地区名称��65      
IsReadOnly$
 True��6e   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6C   �� *Location.Name+6e     56   "   $ 经度上限��65   $
 True��6o    6C   �� *Location.LongitudeUpper+6o     57   "   $ 经度下限��65   $
 True��6o    6C   �� *Location.LongitudeLower+6o     58   "   $ 纬度上限��65   $
 True��6n    6C   �� *Location.LatitudeUpper+6n     59   "   $ 纬度下限��65   $
 True��6n    6C   �� *Location.LatitudeLower+6n     5:   "   $ 分布比例��65    6C   �� *Value+5<      5=      �� 5>      $��1��6   .+�5?      �� $��	下一步��6"   $��30��60   $	��120��6<   $ 20��6H   $ 10��6Z   
����ح�
������ ��5@   !   �� *Next2+5A      5B      5C      �� 5D      $��个体信息��6   .��5E      �  5F      �� 5G      $��6* �6(   �� 5H      $��1* �6(   .+�5J      �� $��0��6   .+�5K      �� $	��360��6'   $	��780��64   $
��40 0q�6A   $��15(�6O   .��5L      R� $��0q�6'   $��0q�63   $��1q�6>   ��5M   '   �� $ 	TreeDatas���5N   "   �� 5O   &    �� ItemsSource 6?   �� $ 	TreeDatas�.R�5P   *   ��  �� Orientation$ 
Horizontal=�65   $��0,5,0,5q�6N   .+�5Q   .   �� $��Center=�68   ��6S   �� *Classify.Name+6t   �� 5R   .   $	��100��6M   $��10,0,0,0q�6Y   ��66   �� *Value+6Y    � ToolTip 5S   .   �� 5T   2   $��Center=�6<   $
��Wrap=�6v   $	��200��6�   ��6W   �� *Classify.Name+6�   5V   +   5W   '   5Y      5Z      5[      �� 5\      $��1��6   .+�5]      �� $��完成��6"   $��30��6/   $	��120��6;   $ 20��6G   $ 10��6Y   
����ح�
������ ��5^   !   �� *Finish+��6=   ��  �� ElementName$ NewItem��5_      5`      5a      5b      5d      5f      