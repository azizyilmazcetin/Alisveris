   M S B A M L   `   `   `  ����?  ;ODEV, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:ODEVODEV  5   	       ODEV.AdminWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:ODEV     5   	     � Title$  AdminWindow��5   	   $	��450��6   $	��800��6*   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $
��791* �6   �� 5      .+�5   
   �� -   5        $��SellersComboBox��5   A   $
��Left=�6   $��	10,32,0,0q�6.   $	��Top=�6X   $	��174��6p   $��22��6|   �� 5   
   $
��Left=�6   $��	70,12,0,0q�6/   $
��Wrap=�6B   $��Sellers List��6V   $	��Top=�6j   $��57��6�   $��15��6�   �� 5   
   -   5        $��BuyersComboBox��5   A   $
��Left=�6   $��	10,86,0,0q�6.   $	��Top=�6W   $	��174��6o   $��22��6{   �� 5   
   $
��Left=�6   $��	70,66,0,0q�6/   $
��Wrap=�6B   $��Buyers List��6V   $	��Top=�6i   $��57��6�   $��15��6�   �� 5   
   -   5        $��ListView��5   O   $
��Left=�6   $	��153��6.   $��
593,32,0,0q�6;   $	��Top=�6_   $	��169��6w    �� View 5      �� 5      .P�5      �� 5      5      �� 5   
   -   5        $��SellOrdersListView��5   P   $
��Left=�6   $	��165��6.   $��593,217,0,0q�6;   $	��Top=�6j   $	��168��6�    5      �� 5      .P�5      �� 5      5      �� 5    
   -   5        $��ActiveSellOrdersListView��5    P   $
��Left=�6   $	��165��6.   $��222,217,0,0q�6;   $	��Top=�6p   $	��346��6�    5!      �� 5"      .P�5#      �� 5$      5&      �� 5'   
   $
��Left=�6   $��17��6/   $��352,200,0,0q�6;   $
��Wrap=�6P   $��Active Sell Orders��6d   $	��Top=�6~   $��94��6�   �� 5(   
   $
��Left=�6   $��17��6/   $��619,200,0,0q�6;   $
��Wrap=�6P   $��Requested Sell Orders��6d   $	��Top=�6�   $	��117��6�   �� 5)   
   $
��Left=�6   $��17��6/   $��
633,14,0,0q�6;   $
��Wrap=�6O   $��Balance Requests��6c   $	��Top=�6{   $��94��6�   �� 5*   
   -   5         ��Name$ ToLoginButton��5*   ;   $
��Quit��6   $
��Left=�6    $��725,387,0,0q�6R   $	��Top=�6g   $��36��6   6�   5,      5-      