   M S B A M L   `   `   `  ����	  agent*    $agent.Views.LearnAgent_Messageconfig   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      T PPrism.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59$prismhttp://prismlibrary.com/  5      !  Prism.Mvvm.ViewModelLocator    AutoWireViewModel  True5      .��5      � .+�5   
   �� 
����·� �� CornerRadius$ 	0,0,20,20��6&   $��5 0 5 5q�6?   6R   � 5   
   $��
20 0 20 20q�6    � ColumnDefinitions 5	      �� 5
      $��2* �6#   �� 5      .+�5      � $��0��6    � RowDefinitions 5      �� 5      $��1* �6$   �� 5      $��7* �6$   .+�5      �� $
��Left=�6   $��Center=�63   $��个体筛选��6O   $��15(�6^   �� 5      $
��Left=�6   $��70,0,0,0q�66   $��Center=�6H   $	��110��6c    �� SelectedIndex 6o   �� *SelectPropoerty+.@�5      �� .��6#   (请选择属性类型)6.   �� 5      .��6#   性别6'   �� 5      .��6#   年龄6'   �� 5      .��6#   职业6'   �� 5      .��6#   受教育程度6*   5      �� 5      $
��Left=�6   $��	190,0,0,0q�66   $��Center=�6I   $	��110��6d   $ 0��6p    �� DisplayMemberPath$
 Name��5   E   ��6   �� *PropertyValue+ �� SelectedItem 5      �� *SelectedPropoertyValue+5      &   System.Windows.Controls.DataGrid  5      -   5        $��NetNodes��5!   \   $��1��5         AutoGenerateColumns$ False��6(      
IsReadOnly$  True��6e   	   CanUserAddRows$	 False��5       
   CanUserResizeColumns$
 False��66      CanUserReorderColumns$ False��6S      CanUserSortColumns$
 True��6q      SelectionUnit$ FullRow=�5!      $ -1��67   $��0 0 0 30q�6J   ��5   D   �� *
NetNodes+   Columns 5"      0  *System.Windows.Controls.DataGridTextColumn  5#      ,  &System.Windows.Controls.DataGridColumn   Header$ 编号��6-   1  +System.Windows.Controls.DataGridBoundColumn   Binding 69   �� *id+  5$      $ 年龄��6-    69   �� *AgentProperty.Age+  5%      $ 性别��6-    69   �� *AgentProperty.Gender+  5&      $ 职业��6-    69   �� *AgentProperty.Occupation.Name+  5'      $ 受教育程度��6-    6<   �� *AgentProperty.EduLevel.Name+5)      �� 5*      $��确定选择��6   $��Bottom=�6(   $��30��6C   
����ح�$��1��6f   ��5+   !   �� *SelectedNodesCommand+��6J   ��  �� ElementName$ NetNodes�� �� Path$ SelectedItems�5-      � 5/      $��1��6   $��5 0 0 0q�6#    50      �� 51      $��5* �6$   .+�53      � $��0��6    54      �� 55      $��1* �6(   �� 56      $��1* �6(   �� 57      $��5* �6(   �� 58      $��1* �6(   �� 59      $��5* �6(   �� 5:      $��1* �6(   .+�5<      �� $��0��6   
�������$��Center=�6A    6e   �� *	InfoIndex+{�6�   �� *SelectNodeCheck+.@�5=      �� .��6'   谣言队列6-   �� 5>      .��6'   经验队列6-   5?      �� 5@      $��1��6   $��2��6*   
�������$	��Top=�6O   $ 5��6d   $��0 0 0 5q�6u   �� 5A      $��1��6   $��个体已配置信息��6)   $��15(�6;   $��Center=�6I   $��Center=�6m   �� 5B      $��2��6   $��13(�6+   $
��Left=�69   $��Visible=�5C   *   $
��True��6]   $��Visible=�6�   $ -1��5D   *   $
 Name��6=   $��0 0 0 5q�6V   ��5B   [   �� *ConfigedInfo+5D   V   �� 5F      $��3��6   $��2��6*   
�������$	��Top=�6O   $ 5��6d   $��0 5 0 0q�6u   �� 5G      $��3��6   $��个体可配置信息��6)   $��15(�6;   $��Center=�6I   $��Center=�5H   $   �� 5I      -   5        $��ConfigableInfo��5K   |   $��4��5I      $��13(�6+   $
��Left=�69   $��Visible=�5J   &   $
��True��6Y   $��Visible=�6~   $ -1��5K   &    �� SelectionMode$ Multiple=�69   $
 Name��6R   $��0 0 0 5q�6k   ��5I   [   �� *ConfigableInfo+5K   |   �� 5L      $��5��6   $��添加��6*   
����ح���5M   %   �� *AddInfosCommand+��6I   �� $ ConfigableInfo��$ SelectedItems�5O      5P      5Q      5R      5S      