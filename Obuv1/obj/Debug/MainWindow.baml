   M S B A M L   `   `   `  ����@  <Obuv1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:Obuv1Obuv1  5   	       Obuv1.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:Obuv1     5   	   _ [MaterialDesignThemes.Wpf, Version=4.8.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5          � Title$  
MainWindow��5
   	   $	��500��6   $	��800��6,   $	��450��6;   $	��800��6H   .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   �� ���#6c159d �� Padding$ 10q�6&   ._�5      �  � Orientation$ Vertical=�6   $��Center=�6/   ���#f5f5f5.+�5      ��  �� Orientation$ 
Horizontal=�6   $��0 10 0 0q�64   .+�5      �� $;��5Введите название для поиска: ��6   $	��175��6A    �� TextAlignment$ Right=�6M   �� 5      -   5         ��Name$ 
TBoxSearch��5   &   $	��225��6   6:   5      �� 5      $ 
Horizontal=�6   $��0 10 0 5q�62   .+�5      �� $��Выберите тип: ��6   $	��175��62   $ Right=�6>   �� 5      -   5         ��Name$ 	ComboType��5   '   $	��225��6   .@�5      �� -   5         ��Name$	 All��5       $��Все виды��6-   �� 5      -   5        $	 Man��5       $��Мужская обувь��6-   �� 5      -   5        $ Woman��5       $��Женская обувь��6/   �� 5      -   5        $ Children��5       $��Детская обувь��62   5       5!      5%      5&      �� 5'   
   -   5        	 ��Name$	 listView��5'      $��1��6%   $��Disabled=�63   ��5(      �� 5)      .R�5*      � $��Center=�6    $ 
Horizontal=�6=   5+      ��5/      �� 50      .R�52      � $��20q�6   $	��400��6'    53      �� 54      $��* �6,   �� 55      $
��auto �6,   �� 56      $
��auto �6,   �� 57      $
��auto �6,   �� 58      $
��auto �6,   �� 59      $
��auto �6,   .+�5<      �� $��0��6!   $��UniformToFill=�6.   $��5q�6F   ��5=      �� 5>   "   
 �� Path$
 Image_�6*   5@      �� 5A      $��1��6;   $��Center=�6H   $��Center=�6e   ��6$   �� *Name_+6e   �� 5B      $ 
textBlock1��6$   $��2��6O   $��Center=�6\   ��68   �� *Type_+6\   �� 5C      $��Размер: ��6$   $��3��64   $
��auto��6C   $��Center=�6P   �� 5D      $
 Size��6$   $��3��6H   $��	224 0 0 0q�6U   $
��auto��6h   ��62   �� *Size+6h   �� 5E      $��4��6Y   $��Center=�6f   ��6$   �� *Price+ �� StringFormat$ {0:N2} Рублей��6f   �� 5F       ��Name$ button1��6!   -	   5        $��Купить��5F   E   $��5��6V   
 � Tag 62   �� *ID+6c   5I      5K      5N      5P      5Q      