   M S B A M L   `   `   `  ����D  @AnimElite, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:AnimElite	AnimElite  5      !    AnimElite.SeeYouSpaceCowboy   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )localclr-namespace:AnimElite     5        � 	Resources  5	         
Storyboard �� TargetProperty �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value��%u  &	        �� 5
   
   .��5      U� $ (UIElement.Opacity)�6,   $
 grid��6\   .\�5        $ 0��6'   $ 0Q�63     5      $ 0:0:2��6'   $ 1Q�67   5      U� 5      $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�6,   $ image��6�   .\�5        $ 0:0:2��6'   $	 128Q�67   5      5      5       � Triggers 5      :� 5   
    :� RoutedEvent$ FrameworkElement.Loaded��6   .[�5      �� #��[  6   5      .��5      � -   5         �Name$
 grid��5      
���   �.+�5   
   �� -   5         ��Name$ image��5      $��89,10,130,-2q�6   $��Image/SeeYou.png��65   $
��Fill=�6O   	 J� RenderTransformOrigin$	 0.5,0.5&�6^   z�5      V� 5      .~�5      �� �� 5      �� 5       T� 5!      5"      5$      5%      5&      