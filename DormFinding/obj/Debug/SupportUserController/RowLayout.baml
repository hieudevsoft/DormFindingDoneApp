   M S B A M L   `   `   `  ����F  BDormFinding, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:DormFindingDormFinding  5          DormFinding.RowLayout   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      +localclr-namespace:DormFinding     5      b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466-fa$http://schemas.fontawesome.io/icons/  5      .��5      ?  9MaterialDesignThemes.Wpf.Transitions.TransitioningContent  -   5           Name$  TransitioningContentSlide��5   *   C  =MaterialDesignThemes.Wpf.Transitions.TransitioningContentBase   OpeningEffect 5   *   D  >MaterialDesignThemes.Wpf.Transitions.TransitionEffectExtension  *SlideInFromBottom+   Duration$ 	0:0:0:0.5X�.��5   
   ��  �� CornerRadius$ 10��6    � Cursor$
 Hand��6#   ���#e8eaf6 J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         
BlurRadius$ 2Q�6#      ShadowDepth$ 1Q�5   #      Color$
 Gray��5   #   ._�5      � 	 � ColumnDefinitions	 5      �� 5      �� 5      $��4* �6'   �� 5      �� 5      �� 5      �� 5      �� 5      
 � RowDefinitions
 5      �� 5      $
��1.8* �6$   �� 5       .+�5"      "  FontAwesome.WPF.ImageAwesome     Icon$
 Home=�6"   $��0��6.   $��46��5#      $��46��5$         
Foreground �#3131315%   "   � 5'       � Orientation$ Vertical=�6   $��1��63   $��Center=�6C   $
��Left=�6^   .+�5(      �� $��24(�67   $
��Wrap=�6E   $��WordEllipsis=�6Y   ��6    �� *Owner+6Y   �� 5)      $��12(�5*       $
��Wrap=�5+       $��WordEllipsis=�5,       ��5)       �� *	Address+5,       5-        5.      $
 Wifi=�6"   $��2��6.   $��30��5/      $��30��50       �#31313151   "     53      $ 
Television=�6"   $��3��64   $��30��54      $��30��55       �#31313156   "     58      $
 Bath=�6"   $��4��6.   $��30��59      $��30��5:       �#3131315;   "     5=      $ 
Motorcycle=�6"   $��5��64   $��30��5>      $��30��5?       �#3131315@   "   '  !MaterialDesignThemes.Wpf.PackIcon  5B         Kind$ 	MoreHoriz=�6*   $��Center=�5C   *   $��Center=�5D   *   $��6��5E   *   $��30��5F   *   $��30��5G   *   �� 5H       �� Orientation$ 
Horizontal=�6   $��6��5I      $��1��5J      $��50 0 0 0q�5K      $��Center=�5L      $��Center=�5M      .+�5O      �� -   5         ��Name$ 	btnDelete��5T      $��Delete��5O      +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 10��5P      $	��110��5Q      $��
0 -10 20 0q�5R      $��0q�5S      ���#E348535V      �� 5W      -   5        $ btnEdit��5]      $
��Edit��5W      $ 10��5X      $	��110��5Y      $��
0 -10 20 0q�5Z      $��0q�5[      ���#75C7E05^      �� 5`      -   5        $ btnReset��5g      $��Reset��5`      $ 10��5a      $	��110��5b      $��
0 -10 20 0q�5c      $��0q�5d      ���#ffa0405g      5i      5j      5k      5l      5m      