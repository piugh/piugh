   M S B A M L   `   `   `  ����  Network     Network.Views.NewNetConfig   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5      T PPrism.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59$prismhttp://prismlibrary.com/  5      -   5        $��NewItem��5        � Title$  新建网络模型方案��5      $	��500��6   $	��880��6,   !  Prism.Mvvm.ViewModelLocator   AutoWireViewModel True5      .��5	      � 
����ح�.+�5
   
   �� $��输入信息有误！��6   $��30��6"   $��
320 0 0 20q�6.   $��14(�6B   
���  ��$��Bottom=�6a   y�5       �� *	Warning+�� 5   
   -   5        $��
tabcontrol��5   *   $��10,10,10,10q�6    �� SelectedIndex 6<   �� *
TabIndex+.@�5      �� $��基础信息��6   .��5      �  � RowDefinitions 5      �� 5      $��2* �6(   �� 5      $��2* �6(   �� 5      $��2* �6(   �� 5      $��1* �6(   .+�5      �� $��0��6   .+�5      �� $��方案名称:��6    $��40��60   $	��120��6<   $��30 40q�6H   $��14(�6W   �� 5      -   5        $��ItemName��5   G   $��40��5   "   $��150 40q�6.   $	��500��6>   $��14(�6J   ��5   "   ��  �� Path$ NewItem.Name�6G   5      �� 5      $��1��6   .+�5      �� $��创建者名称:��6    $��30��61   $	��120��6=   $��30 40q�6I   $��14(�6X   �� 5      -   5        $��	CreatName��5   G   $��40��5   "   $��150 40q�6.   $	��500��6>   $��14(�6J   ��5   "   �� *NewItem.CreateName+6G   5      �� 5       $��2��6   .+�5!      �� $��备注信息：��6    $��30��60   $	��120��6<   $��30 40q�6H   $��14(�6W   �� 5"      -   5        $��Remark��5"   l   $��40��6"   $��150 40q�6.   $	��500��6>   $��14(�6J    �� TextWrapping$
 Wrap=�6X   ��5#   "   �� *NewItem.Remark+5$      �� 5%      $��4��6   .+�5&      �� $��	下一步��6!   $��30��6/   $	��120��6;    �� Right$ 20��6G   
 �� Top$ 10��6Y   
����ح�
������ ��5'   !   �� *Next1+5(      5)      5*      �� 5+      $��参数配置��6   .��5,      �  5-      �� 5.      $��6* �6(   �� 5/      $��1* �6(   .+�51      � $��0��6    52      �� 53      �� 54      �� 55      .+�57      �� $��0��6%    �� Orientation$ 
Horizontal=�62   $��Center=�6K   $��Center=�6h   .+�58      �� $	��150��6$   $!��网络结构方案选择：��60   $��15(�6D   $
��Bold"�6R   �� 59      -   5        $��NetWorkModels��59   3   $	��300��6'   $��Center=�6H   	 �� DisplayMemberPath$
	 Name��5:   M   ��6'   �� *NetWorkModels+*  $Microsoft.Xaml.Behaviors.Interaction
   Triggers
 5;   "   +  %Microsoft.Xaml.Behaviors.EventTrigger  5<   &      	EventName$ SelectionChanged��65   *  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 5=   *   -  'Prism.Interactivity.InvokeCommandAction     Command 6D   �� *SelectedNetWorkModel+   CommandParameter 6m   �� *SelectedItem+ �� ElementName$ NetWorkModels��5>   '   5@      5A      �� 5B      $��1��6%   $ 
Horizontal=�62   $��Center=�6K   $��Center=�6h   .+�5C      �� $	��150��6$   $!��网络参数方案选择：��60   $��15(�6D   $
��Bold"�6R   �� 5D      -   5        $��
ModelParas��5D   3   $	��300��6'   $��Center=�6E   $
	 Name��6i   ��5E   '   �� *
ModelParas+ �� SelectedItem 6J   �� *NewItem.ModelPara+5F      �� 5G      $��2��6%   $ 
Horizontal=�62   $��Center=�6K   $��Center=�6h   .+�5H      �� $	��150��6$   $��个体集方案选择：��60   $��15(�6C   $
��Bold"�6Q   �� 5I      -   5        $��	AgentSets��5I   3   $	��300��6'   $��Center=�6D   $
	 Name��6h   ��5J   '   �� *	AgentSets+ 6I   �� *NewItem.AgentSet+5K      5L      �� 5M      $��1��6   .+�5N      �� $��完成��6"   $��30��6/   $	��120��6;   $ 20��6G   $ 10��6Y   
����ح�
������ ��5O   !   �� *Finish+��6=   �� $ NewItem��5P      5Q      5R      5S      5U      5V      