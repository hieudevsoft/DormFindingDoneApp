   M S B A M L   `   `   `  ����F  BDormFinding, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:DormFindingDormFinding  5          DormFinding.MyDorm   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      +localclr-namespace:DormFinding     5      b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466-fa$http://schemas.fontawesome.io/icons/  5      -   5        $��myDorm��5
      .��5      ?  9MaterialDesignThemes.Wpf.Transitions.TransitioningContent  -   5           Name$  TransitioningContentSlide��5   *   C  =MaterialDesignThemes.Wpf.Transitions.TransitioningContentBase   OpeningEffect 5   *   D  >MaterialDesignThemes.Wpf.Transitions.TransitionEffectExtension  *FadeIn+   Duration$ 0:0:1X�.��5   
   � -   5         �Name$ layoutMainDorm��5      .+�5      ��  �� CornerRadius$ 15��6   ��5      �� 5       �� ImageSource$ ../images/bg_mydorm.png��6!    j� Stretch$ Uniform=�5   !   ._�5      �  � RowDefinitions 5      �� 5      $
��0.2* �6(   �� 5      $��* �6(   .+�5      �  � Orientation$ 
Horizontal=�6    $��Center=�5       $��Right=�5       $��0 0 15 0q�5       .+�5      �� $��Arial Rounded MT Bold)�5       $��20(�5        $��Center=�5!       $��0 0 10 0q�5"       
���   ���5       �� *	NameOwner+	 �� ElementName$	 myDorm��5#       A� 5$      $��40��6"   $��40��5%   "   ��5&      �� 5'   "    6-   �� *
ImageOwner+$	 myDorm��5)      �� 5*      -   5        
 ��Name$
 btnHome��5-   !   
������ $��0q�5+   !   $��
10 40 8 10q�5,   !   $��Bottom=�5/   !   $��Right=�50   !   $��0q�51   !   ��52      !  FontAwesome.WPF.FontAwesome  53   "      Icon$
 Home=�61   
���   �$��25(�55   1   57      �� 58      -   5        $
 btnDormWating��5:   %   
������ $��0q�59   %   $��
10 30 10 0q�5<   %   $��0q�5=   %   ��5>        5?   "   $ History=�61   
���   �$��23(�5A   5   5C      �� 5D      $��5 0 15 0q�6!   $��Center=�5E   !   .+�5F      �� -   5        $
 	btnNotify��5H   %   
������ $��0q�5G   %   $��0q�5J   %   ��5K   "     5L   &   $
 Bell=�65   
���   �$��20(�5N   5   5P      A� 5Q      -   5         A�Name$ notifyMyDorm��5U   &   $��10��5Q   &   $��10��5R   &    �� Left$ 1��5S   &   
 �� Top$ 4��5T   &   $y�	Collapsed=�5V   &   ��5W   "   �� 5X   &    �� Color$ #E34853��66   5Z      5[      5\      � 5^      -   5        $ layoutControl��5^   (   $��1��6   .+�5_      �� $��2��6'   
������ $��0 30 0 0q�5a   '   $��Hidden=�5b   '   $
��Auto=�5c   '   .  (MaterialDesignThemes.Wpf.ScrollBarAssist   ButtonsVisibility$ Visible=�5d   '   .��5e      � .+�5f   "   ��  �� Orientation$ Vertical=�6-   $��20 0 0 0q�5g   -   .+�5h   &   �� $��Dorms��60   $	��Top=�5i   0   $��28(�5j   0   $��Avenir LT Std 65 Medium)�5k   0   
���   �$
��Left=�5m   0   �� 5n   &   -	   5         ��Name$ listViewVerti��5q   /   $
��auto��5n   /   $
��auto��5o   /   $��0 5 0 0q�5p   /   +  %MaterialDesignThemes.Wpf.RippleAssist   RippleOnTop .    ClipToBounds . ��5s   /   �� *Dorm+��5v   *   �� 5w   .    �� 
TargetType" ��64   .�5x   2   ��  �� Property � �� �� Value
 ���� 5y   9   �� 5z   2    � �� 5{   6   �� 5|   :    �� 
TargetType" ��6J   .R�5}   >   �� 5~   ;   5�   3   5�   /   ��5�   *   �� 5�   .   .R�5�   2      DormFinding.RowLayout  $��	0 0 10 10q�6B   $	��550��5�   B   $	��100��5�   B   5�   /   ��5�   *   �� 5�   .   .R�5�   2   � $
��1150��6<   5�   /   5�   '   5�   #   5�      5�      5�      5�      5�      5�      5�      5�      