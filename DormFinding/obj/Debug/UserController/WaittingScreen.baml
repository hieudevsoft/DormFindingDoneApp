   M S B A M L   `   `   `  ����F  BDormFinding, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:DormFindingDormFinding  5           DormFinding.WaittingScreen   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      %localclr-namespace:DormFinding  5      .��5
      ?  9MaterialDesignThemes.Wpf.Transitions.TransitioningContent  -   5           Name$  TransitioningContentSlide��5
   *   C  =MaterialDesignThemes.Wpf.Transitions.TransitioningContentBase   OpeningEffect 5   *   D  >MaterialDesignThemes.Wpf.Transitions.TransitionEffectExtension  *FadeIn+   Duration$ 0:0:1X�.��5   
   � -   5         �Name$ 
layoutMain��5      .+�5      �� $��2��6   
������ $��0 30 0 0q�5   '   $��Hidden=�5   '   $
��Auto=�5   '   .  (MaterialDesignThemes.Wpf.ScrollBarAssist   ButtonsVisibility$ 	Collapsed=�5   '   .��5      � .+�5      ��  �� Orientation$ Vertical=�6!   $��20 0 0 0q�5   -   .+�5      �� $��Dorms��6$   $	��Top=�5   0   $��28(�5   0   $��Avenir LT Std 65 Medium)�5   0   
���   �$
��Left=�5   0   �� 5      -   5         ��Name$ listViewDormBook��5   /   $
��auto��5   3   $
��auto��5   /   $��	-10 5 0 0q�5   /   ��5!   /   �� *
BookDorm+��5"      �� 5#   "    �� 
TargetType" ��6(   .�5$   &   ��  �� Property � ��	 �� Value
	 ���� 5%   9   �� 5&   &    � ��	 5'   *   �� 5(   .   
 �� 
TargetType"
 ��6>   .R�5)   2   �� 5*   /   5,   '   5-   #   ��5/      �� 50   "   .R�51   &      DormFinding.RowWaitting  $��	0 0 10 10q�68   $	��380��52   B   $��45��53   B   55   #   ��57      �� 58   "   .R�59   &   � $
��1150��60   5:   #   5=      5>      5?      5@      5A      5B      5C      