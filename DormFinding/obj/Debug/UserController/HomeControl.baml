   M S B A M L   `   `   `  ����F  BDormFinding, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:DormFindingDormFinding  5          DormFinding.HomeControl   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      +localclr-namespace:DormFinding     5      Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466-fa$http://schemas.fontawesome.io/icons/  5      b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	      .��5      ?  9MaterialDesignThemes.Wpf.Transitions.TransitioningContent  -   5           Name$  TransitioningContentSlide��5   *   C  =MaterialDesignThemes.Wpf.Transitions.TransitioningContentBase   OpeningEffect 5   *   D  >MaterialDesignThemes.Wpf.Transitions.TransitionEffectExtension  *SlideInFromleft+   Duration$ 	0:0:0:0.5X�.��5   
   � -   5         �Name$ layoutMainDorm��5      
�������.+�5      �  � 	Resources 5       �� Source�� 5      $ ../StyleResource.xaml?�6)   %    .+�5      ��  �� Orientation$ Vertical=�6   $��0��5      .+�5      �� $��
Hello Guys��6    $��	20 10 0 0q�5       $	��Top=�5       $
��Left=�5       $��20(�5       $��Avenir LT Std 65 Medium)�5          	colorGray#��[  5       �� 5      $��Find your Dorm��6    $��20 8 0 0q�5        $	��Top=�5!       $
��Left=�5"       $��24(�5#       $��Avenir LT Std 65 Medium)�5$         
colorBlack#��[ 5%       �� 5&      $ 
Horizontal=�6!   .+�5'      �� 
������ ._�5(      ��  �� CornerRadius$ 10��6%   $��	18 10 0 0q�5)   !   $	��400��5*   !   $��2q�5+   !   #��[  5,   !   $
��Left=�5-   !   $��Stretch=�5.   !   ._�5/   "   � $
��auto��6'    � ColumnDefinitions 50   &   �� 51   *   $��50 �6;   6H   �� 52   *   $	��85* �6;   �� 53   *   $
��262* �6;   .+�55   &   "  FontAwesome.WPF.ImageAwesome  	   Icon$	 Search=�66   $��25��56   2   $��25��57   2   
   
Foreground
 �#9FA1BE$��12,18,12.6,18q�58   G   �� 59   &   -   5         ��Name$ searchQuery��5J   *   $��1��59   .   $��60��5:   *   $��0 9 0 0q�5;   *   $��16(�5<   *   $��Avenir LT Std 65 Medium)�5>   *   ���#242365)  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Search something....��5@   *   .  (MaterialDesignThemes.Wpf.TextFieldAssist   UnderlineCornerRadius$ 2��5A   *      DecorationVisibility$ 	Collapsed=�5B   *      
Foreground �#242365   HasClearButton .    RippleOnFocusEnabled .    TextFieldCornerRadius$ 5��5F   *   $��Center=�5G   *    �� TextAlignment$
 Left=�5H   *   $��0q�5I   *   $��2��5J   ?   5K   #   5L      5M      �� 5N      $	��250��6!   
���   �
������ $��Bottom=�5Q   -   $
��Left=�5R   -   $��60��5S   -   $ 10��5T   -   $��1q�5U   -   $��5 5 0 1q�5V   -   ._�5W      �� -   5         ��Name$ 	cbOptions��5[   3   $
��Left=�5W   '   $��	10 0 10 0q�5X   3   $��18(�5Y   3   
���   �$ Select Options��5]   3   $ 3��5^   3      UnderlineBrush
 ���� $��Avenir LT Std 65 Medium)�5`   3   
���   ���5b   "   �� 5c   &    �� 
TargetType" ��6,   .�5d   *   ��  �� Property � �� �� Value
 �����5e   =   �� 5f   *    � �� �#2632385g   =   �� 5h   *    � ��$ 0q�6L   5i   '   .@�5k   "   �� .��6/   New64   �� 5l   "   .��6/   Increasing Price6A   �� 5m   "   .��6/   Decreasing Price6A   �� 5n   "   .��6/   Increasing Booked Times6H   �� 5o   "   .��6/   Decreasing Booked Times6H   �� 5p   "   .��6/   Increasing Like6@   �� 5q   "   .��6/   Decreasing Like6@   �� 5r   "   .��6/   Increasing Rating6C   �� 5s   "   .��6/   Decreasing Rating6C   5t      5u      5v      5w      � 5x      $��1��6   .+�5y      �� $ Vertical=�6!   .+�5z      �� $��Popular Dorm��6$   $��	20 10 0 0q�5{   $   $	��Top=�5|   $   $��28(�5}   $   $��Avenir LT Std 65 Medium)�5~   $   
���   �$
��Left=�5�   $   �� 5�      -   5         ��Name$ listViewHori��5�   #   $
��1200��5�   #   $
��auto��5�   #   $��	20 15 0 0q�5�   #   +  %MaterialDesignThemes.Wpf.RippleAssist   RippleOnTop .    ClipToBounds . ��5�   #   �� *Dorm+��5�      �� 5�   "   " ��6(   .�5�   &   ��  � ��
 ���� 5�   -   �� 5�   &    � �� 5�   *   �� 5�   .    �� 
TargetType" ��6>   .R�5�   2   �� 5�   /   5�   '   5�   #   ��5�      �� 5�   "   .R�5�   &      DormFinding.DormItemHori  $��0 0 10 5q�69   5�   #   ��5�      �� 5�   "   .R�5�   &   �  � Orientation$ 
Horizontal=�60   5�   #   5�      5�      5�      �� 5�      $��2��6   
������ $��0 30 0 0q�5�      $��Hidden=�5�      $
��Auto=�5�      .	  (MaterialDesignThemes.Wpf.ScrollBarAssist 	  ButtonsVisibility$ Visible=�5�      .��5�      � .+�5�      �� $ Vertical=�6%   $��20 0 0 0q�5�   %   .+�5�      �� $��Dorms��6(   $	��Top=�5�   (   $��28(�5�   (   $��Avenir LT Std 65 Medium)�5�   (   
���   �$
��Left=�5�   (   �� 5�      -   5        $ listViewVerti��5�   '   $
��auto��5�   '   $
��auto��5�   '   $��0 5 0 0q�5�   '    .  . ��5�   '   �� *Dorm+��5�   "   �� 5�   &   " ��6,   .�5�   *   ��  � ��
 ���� 5�   1   �� 5�   *    � �� 5�   .   �� 5�   2   " ��6B   .R�5�   6   �� 5�   3   5�   +   5�   '   ��5�   "   �� 5�   &   .R�5�   *   
   DormFinding.DormItem
  $��	0 0 30 20q�69   5�   '   ��5�   "   �� 5�   &   .R�5�   *   � $
��1200��64   5�   '   5�      5�      5�      5�       � RowDefinitions 5�      �� 5�      $
��0.6* �6$   64   �� 5�      $��* �6$   61   �� 5�      $��* �6$   61   5�      5�      5�      5�      