   M S B A M L   `   `   `  ����L  HFoodToOrderWPFApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:FoodToOrderWPFAppFoodToOrderWPFApp  5   	   "    FoodToOrderWPFApp.BillWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:FoodToOrderWPFApp     5   	     � Title$  
BillWindow��5   	   $	��450��6   $	��800��6)   
 � Top$	 100��65    � Left$	 400��6?   .��5	      �� .+�5
   
   �� $��Center=�5      $
��Wrap=�5      $��FoodToOrder App��5      $��26(�5      $	��Top=�5      $
��auto��5      $
��auto��5      $��	0 40 0 20q�5      
��� � �5      �� 5   
   $��
Total Bill��6   
��� � �
������� �� TextAlignment$ Center=�6L   $��16(�5      $��Heavy"�6"   $��Stretch=�65   &   System.Windows.Controls.DataGrid  5   
   -   5        $��dg_cartDetails��5      $��Center=�5         AutoGenerateColumns$ False��5         CanUserAddRows$ False��5      $��	0 20 0 20q�5         Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 	Dish Name��6B   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *
DishName+6B     5      $ Quantity��6B    6%   �� *
Quantity+6B     5      $ Price��6?    6%   �� *Price+6?     5      $ Amount��6@    6%   �� *Amount+6@   5%      �� 5&   
   -   5        	 ��Name$	 
tb_totbill��5&      $��16(�6(   $��Medium"�66   $��Total bill:��6J   $ Right=�6]   $��	0 0 350 0q�6s   5'      5(      