   M S B A M L   `   `   `  ����F  BDormFinding, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:DormFindingDormFinding  5          DormFinding.Login   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      %localclr-namespace:DormFinding  5      Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466-fa$http://schemas.fontawesome.io/icons/  5        � 	Resources  5         colorTextBox �� Color  
colorGreen��%^   &	        &	 %     �� 5   
   $ #F4F8F7��5      �� 5   
   $ #3AB19B��5      5      .��5      ��  �� CornerRadius$ 1��6   
�������._�5   
   �  � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $��0.61* �6#   .+�5      �� -   5         ��Name$
 lyWB��5      $	��720��5       K� ZIndex$ 1��5      $��2��5      $��Center=�5      $y�	Collapsed=�5      $	��400��5      .+�5       �� -   5         ��Name$ btnBackLogin��5"      
���   �$��0q�5!      +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowEdges$
 None=�5$       J� Opacity$	 0.8Q�5%      $��10,-5,10,-5q�5&      	   ShadowDepth$	 Depth0=�5'      $��22��5(      
 �� Left$
 43��5)      $��46��5*      
 �� Top$ 5��5+      .��5,      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ 	ArrowBack=�6.   5-      (  "System.Windows.Controls.WebBrowser  5.      -   5          Name$ 	wbBrowser��5.      $	��600��5/   !   $	��400��50   !   $ 1��52   !   $��Center=�53   !   $��Center=�54   !   $��	100,0,0,0q�55   !   57      59      �� 5:      -   5         ��Name$ layoutLogin��5:      $��0��5;       �� Orientation$ Vertical=�5<       � Cursor$ Arrow��5=      .+�5>      �  � Orientation$ 
Horizontal=�6   $	��Top=�5?      $
��Left=�5@      $��20q�5A      .+�5B      !  FontAwesome.WPF.FontAwesome     Icon$
 Home=�6%   $��Center=�5C   %   $��18(�5D   %   �� 5E      $��Dorm Finding��6   $��Avenir LT Std 65 Medium)�5F      $��12(�5G      5H      � 5I      $ Vertical=�6   $	��Top=�5J      $��Center=�5K      .+�5L      �� $��Sign in to Dorm Finding��6    $��Helvetica Neue LT Std)�5M       #��[ 5N       $��32(�5O       $
��Wrap=�5P       �� 5Q      -   5        $ btnFaceBook��5Q      $��0,20,0,0q�5S      $��0q�5T      $��35��5U      $��35��5V      $
 Hand��5W      $	 Depth0=�5X      
���   ���5Z      �� 5[       �� 
TargetType" ��6.   .R�5\   "   � .+�5]   &   A� 
�������$��1��5^   .   
�������5_   .   �� 5`   &   $��Center=�67   $��Center=�5a   7   5b   #   5c      ��5e        5f      $ Facebook=�6-   
���   �5g   -   5i      �� 5k      $��or use email account:��6    $��Helvetica Neue)�5l       $��Center=�5m       
�������$��0 25 0 0q�5o       $��12(�5p       $
��Wrap=�5q       5s      � 5t      $ Vertical=�6   $��Center=�5u      $��0 20 0 0q�5v      $��Stretch=�5w      .+�5x      �� $ 10��6   $	��350��5y      ���#F4F8F7._�5{      � $
��auto��6    5|      �� 5}   "   $��50 �63   6@   �� 5~   "   $	��85* �63   .+�5�        $ Email=�66   $��20��5�   6   $��20��5�   6   $��Center=�5�   6   $��Center=�5�   6   
�������5�   6   �� 5�      -   5         ��Name$ tbEmail��5�   &   $��1��5�   &   $��40��5�   &   $��13(�5�   &   $��	0 3.8 0 0q�5�   &   $��Avenir LT Std 65 Medium)�5�   &   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Email��5�   &   .  (MaterialDesignThemes.Wpf.TextFieldAssist   UnderlineCornerRadius$ 2��5�   &      DecorationVisibility$ 	Collapsed=�5�   &      HasClearButton .    RippleOnFocusEnabled .    TextFieldCornerRadius$ 5��5�   &   $��Center=�5�   &    �� TextAlignment$
 Left=�5�   &   $��0q�5�   &   5�      5�      �� 5�      $ 10��6   $��	0 15 0 0 q�5�      $	��350��5�      $��40��5�      ���#F4F8F7._�5�      � $
��auto��6    5�      �� 5�   "   $��50 �63   6@   �� 5�   "   $	��85* �63   .+�5�        $	 Key=�66   $��20��5�   6   $��20��5�   6   $��Center=�5�   6   $��Center=�5�   6   
�������5�   6   G� 5�      -   5         G�Name$ 
tbPassword��5�   *   $��1��5�   *   $��13(�5�   *   $��	0 0 0 3.8q�5�   *   $��40��5�   *   $��Avenir LT Std 65 Medium)�5�   *   $ Password��5�   *   $ 2��5�   *   $ 	Collapsed=�5�   *    .  . $ 5��5�   *   $��Center=�5�   *   $��0q�5�   *   5�      5�      �� 5�      -   5        $ tbForgetPass��5�       7  1MaterialDesignThemes.Wpf.Transitions.Transitioner   MoveLastCommand#��Z 5�       $��Forgot password?��5�       
������ $��0q�5�       $��0q�5�       $
 Hand��5�       $��14(�5�       $��0,10,0,0q�5�       $��Avenir LT Std 65 Medium)�5�       
������$��Center=�5�       $��Center=�5�       �� 5�      -	   5         ��Name$ cbRememberPass��5�      $��Remember password��5�      $��0,20,0,0q�5�      #��[ 5�        MaterialDesignBody#��[ 5�      $��Avenir LT Std 65 Medium)�5�      $��Center=�5�      $��Center=�5�      $��13(�5�      5�      �� 5�      -
   5        $ btnLogin��5�      $
 Hand��5�      $	��150��5�      $��50 20q�5�      $��Sign In��5�      $��42��5�      $��Avenir LT Std 55 Roman)�5�      #��[ 5�      #��[  5�      
���   �+  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 18��5�      $	 Depth0=�5�      $	 All=�5�      $
��Bold"�5�      $��0q�5�      $��20(�5�      $��Center=�5�      $��Center=�5�      5�      �� 5�      -   5          ��Name$  layoutMainLogin��5�      $��1��5�      $ 0 1 1 0��5�      ��5�      �� 5�      ! �� ImageSource$! ../images/back_ground.png��6!   " j� Stretch$" UniformToFill=�5�   !   ._�5�      � $��Center=�6   $��Center=�5�      .+�5�      � $ Vertical=�6    .+�5�      �� $��	Greeting!��6    $��Center=�5�       
�������$��32(�5�       $��Helvetica Neue LT Std)�5�       �� 5�      $!��Enter your personal details��6    ���#F3FAFA$��	15 15 0 0q�5�       $��Center=�5�       $��Center=�5�       $��Center=�5�       $��14(�5�       $��Avenir LT Std 55 Roman)�5�       �� 5�      $$��and start your journey with us��6    ���#F3FAFA$��20 0 0 0q�5      $��Avenir LT Std 55 Roman)�5      $��Center=�5      $��Center=�5      $��Center=�5      $��14(�5      �� 5     -   5        $ btnCreateAccount��5  !   #   MoveNextCommand#��Z# 5  !   $��0 20 0 0q�5  !   $	��1.2q�5	  !   $��Center=�5
  !   
������ 
�������
�������$	��150��5  !   $ 16��5  !   $	 Depth0=�5  !   $��42��5  !   $
 Hand��5  !   $��Center=�5  !   $��Avenir LT Std 55 Roman)�5  !   $��Sign Up��5  !   $��16(�5  !   5     5     5     �� 5     -   5        $ btnShutDown��5"     $��2��5     $	��Top=�5     
������ $��0q�5!     $��0 0 5 0q�5$     $��0q�5%     $��Right=�5&     .��5'     "	  FontAwesome.WPF.ImageAwesome	  $ 	  Icon$$ Close=�6"   $��12��5(  "   % 	  
Foreground
% �����$��12��5*  "   5+     �� 5,     -   5        $ btnMinimizedWindow��50     $��2��5,     $	��Top=�5-     
������ $��0q�5/     $��0 0 30 0q�52     $��0q�53     $��Right=�54     .��55     	  $$ WindowMinimize=�6"   $��12��56  "   
% �����$��12��58  "   59     5:     5<     5=     