   M S B A M L   `   `   `  ����B  >MainApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:MainAppMainApp  5   	       MainApp.AnswersWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:MainApp     5   	     � Title$  Question��5   	   $	��800��6   $	��800��6'   $��Center=�63   $��Center=�6N   .��5	      � $��	0,0,2,-21q�6    � ColumnDefinitions 5
   
   �� 5      $��1* �6    � RowDefinitions 5   
   �� 5      $��1* �6   �� 5      $��2* �6   �� 5      $��1* �6   �� 5      $��2* �6   �� 5      $��9* �6   .+�5   
   �� $��3��6   $��0,0,0,10q�6$   .��5      �� -   5        $��stkComments��5      5      �� 5   
   $��4��6   $��0,0,0,10q�6$   .��5      �� -   5        $��
stkAnswers��5      5      �� 5   
   -   5        $��lbTitle��5      $��Title��6   $��20(�6/   $
��Left=�6=   $��	10,10,0,0q�6X   $	��Top=�6k   $��54��6�   $	��770��6�   $��2��6�   �� 5   
   -   5        $��lbDescription��5      $��Description��6%   $��1��6;   $��20(�6H   $
��Left=�6V   $��	10,10,0,0q�6q   $	��Top=�6�   $��54��6�   $	��770��6�   �� 5   
   -   5        $��lbAuthor��5      $��Author��6    $��2��61   $��20(�6>   $
��Left=�6L   $��	10,10,0,0q�6g   $	��Top=�6z   $��54��6�   $	��516��6�   $��2��6�   �� 5   
   -   5        $��lbDate��5      $
��Date��6   $��2��6-   $��20(�6:   $��Right=�6H   $��0,11,0,0q�6d   $	��Top=�6v   $��54��6�   $	��152��6�   $��2��6�   5      5      