   M S B A M L   `   `   `  ����L  HFoodToOrderWPFApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:FoodToOrderWPFAppFoodToOrderWPFApp  5   	   +    %FoodToOrderWPFApp.AddRestaurantWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:FoodToOrderWPFApp     5   	     � Title$  AddRestaurantWindow��5   	   $	��450��6%   $	��800��62   
 � Top$	 100��6>    � Left$	 400��6H   .��5	      �� .+�5
   
   �� $��0��6   $��Center=�5      $
��Wrap=�5      $��FoodToOrder App��5      $��26(�5      $	��Top=�5      $
��auto��5      $
��auto��5      $��	0 20 0 20q�5      
��� � �5   	   �� 5   
   $��Add Restaurant Panel��6   
��� � �
������� �� TextAlignment$ Center=�6V   $��16(�5      $��Heavy"�6   $��Stretch=�6)   � 5   
   -   5         �Name$ grid_addRestDet��5      $��Center=�5      $��0 30 0 0q�6    � ColumnDefinitions 5      �� 5      $
��Auto �6#   �� 5      $
��Auto �6#   �� 5      $
��Auto �6#   �� 5       $
��Auto �6#    � RowDefinitions 5#      �� 5$      $
��Auto �6    �� 5%      $
��Auto �6    .+�5)      �� $��0��5+      $��0��6   $��Restaurant Name��5,      $��12(�5-      $��Medium"�5.      �� 50      -   5        $��add_restName��52      $��1��6   $��0��6&   �� 54      $��0��57      $��1��6   $
��Open��58      $��12(�59      $��Medium"�5:      $��	20 0 20 0q�5;      �� 5<      -   5         ��Name$ add_restOpen��5=      $��Center=�5>      $��1��5?      $��1��6   �� 5@      $��0��5C      $��2��6   $��UserId��5D      $��12(�5E      $��Medium"�5F      �� 5H      -   5        $��
add_userId��5J      $��50��5I      $��1��5J      $��2��6$   �� 5K      -   5         ��Name$ 
btn_updDet��5L      $��3��5K      $��2��6'      RoundButton#���   5M      $	��Add��5N      $��30��5O      $��60��5P      
��� ���$��20 0 0 0q�5S   
   5T      &   System.Windows.Controls.DataGrid  5V   
   -   5        $��dg_add_dishes��5V      $y�	Collapsed=�6(   $��Center=�5W      	   AutoGenerateColumns$	 False��5X      
   CanUserAddRows$
 False��5Y      $��0 20 0 0q�6      Columns 5Z      0  *System.Windows.Controls.DataGridTextColumn  5[      ,  &System.Windows.Controls.DataGridColumn   Header$ 	Dish Name��6B   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *
DishName+6B   4  .System.Windows.Controls.DataGridCheckBoxColumn  5\      $
 Open��6I    6+   �� *	Available+6I     5]      $ Price��6?    6%   �� *Price+6?   5_      �� 5a   
   -   5        $ btn_wantToAddDishDet��5c   	   $��0 20 0 0q�5a      $y�	Collapsed=�5b      #���   5d      $��Add dish��5e      $��30��5f      $��60��5g      
��� ���5i      � 5k   
   -   5        $ grid_addDishDet��5k      $��Center=�5l      $��0 20 0 0q�6"   $y�	Collapsed=�64    5o      �� 5p      $
��Auto �6#   �� 5q      $
��Auto �6#   �� 5r      $
��Auto �6#   �� 5s      $
��Auto �6#    5v      �� 5w      $
��Auto �6    �� 5x      $
��Auto �6    .+�5|      �� $��0��5~   
   $��0��6   $��	Dish Name��5   
   $��12(�5�   
   $��Medium"�5�   
   �� 5�      -	   5        $��add_dishName��5�   	   $��1��6   $��0��6*   �� 5�      $��0��5�   	   $��1��6   $��	Available��5�   	   $��12(�5�   	   $��Medium"�5�   	   $��	20 0 20 0q�5�   	   �� 5�      -
   5        $ add_dishAvl��5�   	   $��Center=�5�   	   $��1��5�   	   $��1��6   �� 5�      $��0��5�   	   $��2��6   $��Price��5�   	   $��12(�5�   	   $��Medium"�5�   	   �� 5�      -   5        $��add_dishPrice��5�   	   $��1��6   $��2��6+   �� 5�      -   5        $ btn_addDishDet��5�   	   $��3��5�      $��2��6%   $��20 0 0 0q�66   #���   5�      $	��Add��5�      $��30��5�      $��60��5�      
��� ���5�      5�      5�      5�      