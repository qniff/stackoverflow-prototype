   M S B A M L   `   `   `  ����B  >MainApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:MainAppMainApp  5   	       MainApp.NewQuestionWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:MainApp     5   	     � Title$  New Question��5   	   $	��800��6   $	��400��6*   .��5	      � 
�������$��0,10,0,0q�6    � ColumnDefinitions 5
   
   �� 5      �� 5      $��0* �6    � RowDefinitions 5   
   �� 5      $��4* �6   �� 5      $	��21* �6   .+�5   
   �� -   5         ��Name$ btnSubmitQuestion��5      $��Submit Question��6,   $
��Left=�6F   $	��Top=�6a   $	��142��6y   $��640,254,0,0q�6�   $��1��6�   $��40��6�   6�   �� 5   
   -   5         ��Name$ brdTitle��5      
���   �$��1q�67   �� 5   
   -   5        $ brdPost��5      
���   �$��1q�66   $
��Left=�6J   $	��306��6e   $	��Top=�6r   $	��800��6�   $��2��6�   $��2��6�   $��0,0,-8,0q�6�   ._�5      �� 
���   �$��1q�6)   $��9,84,9,9q�6=   ._�5      �� -   5         ��Name$ txtQuestionDescription��5       �� TextWrapping$
 Wrap=�6:   $!��Describe your question here��6N   $��14(�6q   $��
-1,-1,0,-1q�6   5      5      �� 5   
   -   5        $ txtQuestionTitle��5      $
��Left=�6,   $��42��6G   $
 Wrap=�6S   $ ��Give your question a title��6g   $	��Top=�6�   $	��772��6�   $��10,5,0,0q�6�   $��24(�6�   5      5      