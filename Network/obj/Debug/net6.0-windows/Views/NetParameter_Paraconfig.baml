   M S B A M L   `   `   `  ����  Network+    %Network.Views.NetParameter_Paraconfig   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      T PPrism.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59$prismhttp://prismlibrary.com/  5      !  Prism.Mvvm.ViewModelLocator    AutoWireViewModel  True5      .��5      � .+�5   
   �� 
����·� �� CornerRadius$ 	0,0,20,20��6&   $��5 0 5 5q�6?   6R   &   System.Windows.Controls.DataGrid  5   
      AutoGenerateColumns$ False��6      
IsReadOnly$  True��6e   $��
20 0 20 20q�6y      CanUserAddRows$ False��5	         CanUserResizeColumns$ False��62      CanUserReorderColumns$ False��6O      CanUserSortColumns$
 True��6m   ��5   /   �� *SelectedItem.ModelParaConfigs+   Columns 5
      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$	 参数名称��6%   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 63   �� *&$OptionalParaConfig.OptionalPara.Name+  5      $	 	参数值��6%   
 62   �� *Value+5      5      5      