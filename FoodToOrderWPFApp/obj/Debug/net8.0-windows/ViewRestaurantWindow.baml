   M S B A M L   `   `   `  ����L  HFoodToOrderWPFApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:FoodToOrderWPFAppFoodToOrderWPFApp  5   	   ,    &FoodToOrderWPFApp.ViewRestaurantWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:FoodToOrderWPFApp     5   	     � Title$  ViewRestaurantWindow��5   	   $	��700��6&   $	��900��63   
 � Top$	 100��6?    � Left$	 400��6I   .��5	      �� .+�5
   
   �� $��0��6   $��Center=�5      $
��Wrap=�5      $��FoodToOrder App��5      $��26(�5      $	��Top=�5      $
��auto��5      $
��auto��5      $��	0 20 0 20q�5      
��� � �5      �� 5   
   $��Restaurants��6   
��� � �
������� �� TextAlignment$ Center=�6M   $��16(�5      $��Heavy"�6   $��Stretch=�6)   $��0 0 0 20q�6G   &   System.Windows.Controls.DataGrid  5   
   -   5        $��dg_rests��5      $��Center=�5         AutoGenerateColumns$ False��5         CanUserAddRows$ False��5         Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Restaurant Name��6H   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *RestaurantName+6H   4  .System.Windows.Controls.DataGridCheckBoxColumn  5      $
 Open��6D    6+   �� *Open+6D     5       $ UserId��6@    6%   �� *UserId+6@   4  .System.Windows.Controls.DataGridTemplateColumn  5#      $
 View��6)   	   CellTemplate	 5$      �� 5%      .R�5&      �� -   5        $
��View��5&   E      RoundButton#���   6T   $��50��6z   
��� ���6�   5)      5+      5-        50   
   -   5        $��dg_view_dishes��50      $y�	Collapsed=�6)   $��Center=�51      $ False��52      $ False��53      $��0 20 0 0q�6"    54        55      $ 	Dish Name��6B    6%   �� *
DishName+6B     56      $
 Open��6I    6+   �� *	Available+6I     57      $ Price��6?    6%   �� *Price+6?     58      $ Image��6)   	 59      �� 5:      .R�5;      �� $��50��6A   $��50��6L   ��6$   �� *	ImagePath+6L   5<      5>      5E      5I      5J      