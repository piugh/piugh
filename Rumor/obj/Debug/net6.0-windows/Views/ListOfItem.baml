   M S B A M L   `   `   `  ����	  Rumor    Rumor.Views.ListOfItem   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5      [ WPrism.DryIoc.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59T PPrism.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59&prismhttp://prismlibrary.com/   5      !  Prism.Mvvm.ViewModelLocator    AutoWireViewModel  True5	      .��5
      �  � RowDefinitions 5   
   �� 5      $��2* �6   �� 5      $��2* �6   �� 5      $	��22* �6   �� 5      $��4* �6   .+�5   
   �� $��4��6   
����·� �� CornerRadius$ 20,20,20,20��67   $��5 5 0 5q�6R   6e   �� 5   
   $��0��6/   
���   �$��18(�6O   $��Heavy"�6]   $��0 10 0 0q�6p   $��Center=�6�   ��6   �� *	Listtitle+6�   �� 5   
   $��1��6    �� Orientation$ 
Horizontal=�6"   $��Center=�6;   $��Center=�6V   .+�5      �� $��Center=�6   $��搜索内容��65   $��Center=�6A   $��15(�6\   �� 5      -   5        $��Search��5   X   $��Center=�6   $	��Top=�64   $	��100��6L   $��Center=�6f   .��6�   *  $Microsoft.Xaml.Behaviors.Interaction   Triggers 5      +  %Microsoft.Xaml.Behaviors.EventTrigger  5         	EventName$ TextChanged��6%   *  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 5      -  'Prism.Interactivity.InvokeCommandAction     Command 60   �� *SearchForList+   CommandParameter 6R   �� *Text+	 �� ElementName$	 Search��5      .��5   &   5       5"      �� 5%   
   -   5        
 ��Name$
 ListOfItems��5%      $��2��6'   $��	20 0 20 0q�64   $��Stretch=�6G   $��Stretch=�6c   $��18(�5&      $
��Left=�6$   
�������$��2q�5'   ,    �� DisplayMemberPath$
 Name��5(   5   $��Visible=�5)      $��Visible=�5*      $
��True��6I   ��5(      �� *MyItem+ �� SelectedItem 6N   �� *SelectedItem+5+      �� 5.   
   $��3��6   $ 
Horizontal=�6"   $��Center=�6;   $��Center=�6X   .+�5/      �� $��新建方案��6   
����ح�$��12(�6;   
������ ��6c   �� *NewItemCommand+�� 51      $��删除方案��6   $��5 0 0 0q�6$   
����ح�$��12(�6L   
������ ��52      �� *DeleteItemCommand+��6?   �� *SelectedItem+$	 ListOfItems��53      54      55      