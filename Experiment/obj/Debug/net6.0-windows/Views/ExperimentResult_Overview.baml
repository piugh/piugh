   M S B A M L   `   `   `  ����  
Experiment0    *Experiment.Views.ExperimentResult_Overview   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      T PPrism.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59$prismhttp://prismlibrary.com/  5      !  Prism.Mvvm.ViewModelLocator    AutoWireViewModel  True5      .��5      � .+�5   
   �� 
����·� �� CornerRadius$ 	0,0,20,20��6&   $��5 0 5 5q�6?   6R   � 5   
   $��
20 0 20 20q�6   .+�5	      �� $
��Auto=�6   $��
20 0 20 20q�6>   .��5
      ��  �� Orientation$ Vertical=�6   .+�5      �� $ 
Horizontal=�6!   $
��Left=�6:   $��0 10 0 0q�6U   .+�5      �� $��18(�6    $��参与节点数:��6.   �� 5      $��16(�6i   ��6    �� *64SelectedItem.Experiment.NetworkResult.NetNodes.Count+6i   5      �� 5      $ 
Horizontal=�6!   $
��Left=�6:   $��0 10 0 0q�6U   .+�5      �� $��18(�6    $��产生步长总数:��6.   �� 5      $��16(�6>   ��6    �� *	StepCount+6>   5      �� 5      $ 
Horizontal=�6!   $
��Left=�6:   $��0 10 0 0q�6U   .+�5      �� $��18(�6    $��产生消息总数:��6.   �� 5      $��16(�6F   ��6    �� *SpreadInfos.Count+6F   5      �� 5      $ 
Horizontal=�6!   $
��Left=�6:   $��0 10 0 0q�6U   .+�5      �� $��18(�6    $"��单位步长传递消息数:��6.   �� 5      $��16(�6D   ��6    �� *InfoByEveryStep+6D   5      �� 5      $ 
Horizontal=�6!   $
��Left=�6:   $��0 10 0 0q�6U   .+�5      �� $��18(�6    $"��最终步长传递消息数:��6.   �� 5      $��16(�6F   ��6    �� *LastStepInfoCount+6F   5      �� 5      $ Vertical=�6!   $��0 10 0 0q�68   .+�5       �� $��18(�6    $"��传播次数最多的消息:��6.   $
��Left=�6C   �� 5!      $
��Wrap=�6$   $��16(�6T   $��Center=�6b   $��20 0 0 0q�6   ��68   �� *
WidelyInfo+6   5"      �� 5#      $ 
Horizontal=�6!   $
��Left=�6:   $��0 0 0 0q�6U   .+�5$      �� $��18(�6    $"��传播该消息的节点数:��6.   �� 5%      $��16(�6D   ��6    �� *WidelyInfoCount+6D   5&      �� 5'      $ 
Horizontal=�6!   $
��Left=�6:   $��0 10 0 0q�6U   .+�5(      �� $��18(�6    $"��最后消息的细节数量:��6.   �� 5)      $��16(�6G   ��6    �� *LastInfo.DetailNum+6G   5*      5+      5,      5-      5.      5/      