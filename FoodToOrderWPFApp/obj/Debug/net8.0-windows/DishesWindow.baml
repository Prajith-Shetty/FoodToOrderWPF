   M S B A M L   `   `   `  ����L  HFoodToOrderWPFApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:FoodToOrderWPFAppFoodToOrderWPFApp  5   	   G(clr-namespace:FoodToOrderWPFApp.ControlsFoodToOrderWPFApp.Controls  67   $    FoodToOrderWPFApp.DishesWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:FoodToOrderWPFApp     5   	   ;local1(clr-namespace:FoodToOrderWPFApp.Controls     67     � Title$  DishesWindow��5   	   $	��600��6   $	��800��6+   
 � Top$	 100��67    � Left$	 400��6A    � 	Resources 5	      &   System.Windows.Controls.DataGrid �� 
TargetType �� Property �� Value��%�   '        �� 5
   
   dg_style��"  6"   .�5      ��  � ��
 �����6+   �� 5       � ��
 � � �6,   5      5      .��5      �� .+�5   
   �� $��Center=�5      $
��Wrap=�5      $��FoodToOrder App��5      $��26(�5      $	��Top=�5      $
��auto��5      $
��auto��5      $��	0 40 0 20q�5      
��� � �5   	   �� 5   
   $��Select Dishes��6   
��� � �
������� �� TextAlignment$ Center=�6O   $��16(�5      $��Heavy"�6   $��Stretch=�61     5   
   -   5        $��	dg_dishes��5   %   $��0 20 0 0q�6   $��Center=�5          AutoGenerateColumns$ False��5!      	   CanUserAddRows$	 False��5"      
   Columns
 5#      0  *System.Windows.Controls.DataGridTextColumn  5$      ,  &System.Windows.Controls.DataGridColumn   Header$ 	Dish Name��6B   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *
DishName+6B     5%      $ Price��6?    6%   �� *Price+6?   4  .System.Windows.Controls.DataGridTemplateColumn  5&      $ Image��6)      CellTemplate 5'      �� 5(      .R�5)      �� $��50��6A   $��50��6L   ��6$   �� *	ImagePath+6L   5*      5,        5.      $ Quantity��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$	 200 6;    5/      �� 50      .R�51      0   *FoodToOrderWPFApp.Controls.QuantityControl     Quantity$ 0��65   52      54        56      $ Add to Cart��6)    57      �� 58      .R�59      �� -   5        $	��Add��59   %      RoundButton#���   6Q   
��� ���6�   5:      5<      5>      �� 5@   
    �� Orientation$ 
Horizontal=�6   $��Center=�6.   .+�5A      �� -   5        #���   5A      $
��Sort��5B      $��36��5C      $��80��5D      
��� ���$��	0 20 20 0q�5F      �� 5H      -   5        #���   5H      $��Order��5I      $��36��5J      $��80��5K      
��� ���$��0 20 0 0q�5M      5N      5P      5U      