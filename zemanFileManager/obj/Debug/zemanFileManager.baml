   M S B A M L   `   `   `  ����  zemanFileManager'    !zemanFileManager.ZemanFileManager   5      T PMahApps.Metro, Version=1.1.2.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4f;Controls,http://metro.mahapps.com/winfx/xaml/controls  5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	      AccentColorBrush(  "MahApps.Metro.Controls.MetroWindow    	GlowBrush#  �   5   	    � WindowStartupLocation$ CenterScreen=�5   	    � WindowState$ 	Maximized=�5   	    � Title$ ZemanFileManager��5   	   $	��600��6"   $	��850��6/   $	��500��6;   $	��750��6K    � Icon$ Slike/floppySlika.png��6Z   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $	��15* �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   .+�5"   
   ]� $��0��6   $��8��6$   $��5��68   .+�5#      �� -   5        $��	statusBar��5#   0   $��Bottom=�6   
����� �.@�5$      �� .��5%      �� -   5        $
��info��5%       5&      5'      5)      �� 5,   
   -   5        $��lijeviButton��5,      $��2q�6%   $��0��60   $��1��6@     AccentedSquareButtonStyle#��[ 6h   .��5-      ��  �� Orientation$ 
Horizontal=�6   .+�5.      �� $��Slike\openFolderSlika.png��6   $��20��6;   �� 5/      $��  Otvori mapu��6   $��Center=�61   $��Center=�6N   50      51      �� 54   
   -   5        $��lijeviRenameButton��54   .   $��0��6   $��0��6   $��2q�6H   #��[ 6S   .��55      �� $��  Preimenuj��6   $��Center=�6+   $��Center=�6H   56      �� 58   
   -   5        $��lijeviRenameTextBox��58      $��1��6.   $��0��6>   $��2��6K   �� 5<   
   -   5        $��desniRenameButton��5<   .   $��0��6   $��7��6   $��2q�6G   #��[ 6R   .��5=      �� $��  Preimenuj��6   $��Center=�6+   $��Center=�6H   5>      �� 5@   
   -   5        $��desniRenameTextBox��5@      $��5��6-   $��0��6=   $��2��6J   �� 5E   
   -   5        $��lijeviKopirajButton��5E   .   $��1��6   $��1��6    � ToolTip$! Kopira selektiranu datoteku��6I   $��2q�6o   #��[ 6�   .��5F      �� $ 
Horizontal=�6   .+�5G      �� $��Slike\copySlika.png��6   $��20��65   �� 5H      $��	  Kopiraj��6   $��Center=�6-   $��Center=�6J   5I      5J      �� 5L   
   -	   5        $��lijeviMoveButton��5L   .   $��1��6   $��2��6   $" Pomiče selektiranu datoteku��6F   $��2q�6l   #��[ 6�   .��5M      �� $ 
Horizontal=�6   .+�5N      �� $��Slike\moveSlika.png��6   $��18��65   �� 5O      $��	  Pomakni��6   $��Center=�6-   $��Center=�6J   5P      5Q      �� 5S   
   -
   5        $��lijeviDeleteButton��5S   .   $��1��6   $��3��6   $! Briše selektiranu datoteku��6H   $��2q�6m   #��[ 6�   .��5T      �� $ 
Horizontal=�6   .+�5U      �� $��Slike\removeSlika.png��6   $��20��67   �� 5V      $��
  Izbriši��6   $��Center=�6-   $��Center=�6J   5W      5X      �� 5\   
   -   5        $��desniButton��5\      $��2q�6%   $��8��60   $��1��6@   #��[ 6g   .��5]      �� $ 
Horizontal=�6   .+�5^      �� $��Slike\openFolderSlika.png��6   $��20��6;   �� 5_      $��  Otvori mapu��6   $��Center=�61   $��Center=�6N   5`      5a      �� 5c   
   -   5        $��desniKopirajButton��5c   .   $��1��6   $��4��6   $! Kopira selektiranu datoteku��6H   $��2q�6n   #��[ 6�   .��5d      �� $ 
Horizontal=�6   .+�5e      �� $��Slike\copySlika.png��6   $��20��65   �� 5f      $��	  Kopiraj��6   $��Center=�6-   $��Center=�6J   5g      5h      �� 5k   
   -   5        $��desniMoveButton��5k   .   $��1��6   $��5��6   $" Pomiče selektiranu datoteku��6E   $��2q�6l   #��[ 6w   .��5l      �� $ 
Horizontal=�6   .+�5m      �� $��Slike\moveSlika.png��6   $��18��65   �� 5n      $��	  Pomakni��6   $��Center=�6-   $��Center=�6J   5o      5p      �� 5q   
   -   5        $��desniDeleteButton��5q   .   $��1��6   $��6��6   $! Briše selektiranu datoteku��6G   $��2q�6l   #��[ 6w   .��5r      �� $ 
Horizontal=�6   .+�5s      �� $��Slike\removeSlika.png��6   $��20��67   �� 5t      $��
  Izbriši��6   $��Center=�6-   $��Center=�6J   5u      5v      � 5x   
   -   5        $��lijeviDiskProgressBar��5x      $��2��63   $��0��6@   $
��Auto��6P   $
��Auto��6^   � 5y   
   -   5        $��desniDiskProgressBar��5y      $��2��62   $��7��6?   $
��Auto��6O   $
��Auto��6]   �� 5|   
   -   5        $��lijevaVelicinaDiskaLabel��5|      $��0��60   $��2��6@   $< 6Veličina slobodnog prostora / Veličina cijelog diska��6M   $��Center=�6�   $��Stretch=�6�   $��Stretch=�6�   �� 5}   
   -   5        $��desnaVelicinaDiskaLabel��5}      $��8��60   $��2��6@   $< 6Veličina slobodnog prostora / Veličina cijelog diska��6M   $��Center=�6�   $��Stretch=�6�   $��Stretch=�6�   �� 5�   
   -   5        $��lijeviListView��5�      	 �� AlternationCount$	 2��6)   $��0��6?   $��4��5�      $��2,5,4,5q�6'   ���	#FFE8F4FF
���   �$��1q�6c   $��3��5�      $��1��6    $��Visible=�5�      $��Visible=�6H   
 �� SelectionMode$
 Single=�6{    �� View 5�      �� 5�      .P�5�      ��  �� Width$	 350��6%   $	��Ime��61    �� DisplayMemberBinding 6>   �� *Name+�� 5�      $	 140��6%   $��Vrijeme kreiranja��61    6L   �� *CreationTime+�� 5�      $ 85��6%   $��
Ekstenzija��60    6E   �� *	Extension+5�      5�      �� 5�   
   -   5        $��desniListView��5�      $	 2��6)   $��4��6>   $��4��6N   $��4,5,2,5q�6b   ���	#FFE8F4FF
���   �$��1q�5�   >   $��3��6R   $��1��6_   $��Visible=�5�      $��Visible=�6H   $
 Single=�5�       5�      �� 5�      .P�5�      �� $	 350��6%   $	��Ime��61    6>   �� *Name+�� 5�      $	 140��6%   $��Vrijeme kreiranja��61    6L   �� *CreationTime+�� 5�      $ 85��6%   $��
Ekstenzija��60    6E   �� *	Extension+5�      5�      �� 5�   
   -   5        $��lijeviPathTextBox��5�      $��0,0,4,0q�6+   $��1��6<   $��2��6L   $��3��6Y   {�.  6n   �� 5�   
   -   5        $��desniPathTextBox��5�      $��0,0,2,0q�6*   $��4��6;   $��2��6K   $��3��6X   {�.  6l   �� 5�   
   $��0��6   $��4��6#   $��4��60   $)��#informacije o selektiranoj datoteci��6D   ���	#CC6CD7FF.��5�      �� $��3��6   $��0��6&   $ 
Horizontal=�66   .+�5�      �� -   5        $��veličinaDatotekeLabel1��5�   n   $��
Veličina:��6   $��Center=�6,   $! Veličina odabrane datoteke��6I   6n   �� 5�      -   5        $��lijevaVeličinaTextBox��5�      $��3q�67   $��80��6B   {�.  6M   �� 5�      -   5        $��IsReadOnlyLabel1��5�   y   $��Moguće samo čitanje��6   $��Center=�67   $  Atributi odabrane datoteke��6T   6y   �� 5�      -   5        $��lijeviIsReadOnlyCheckBox��5�      {�.  6;   �� 5�      -   5        $��AtributiDatotekeLabel1��5�   n   $��	Atributi:��6   $��Center=�6,   $  Atributi odabrane datoteke��6I   6n   �� 5�      -   5        $#��lijeviAtributiDatotekeTextBox��5�      $��3q�6?   {�.  6J   5�      5�      �� 5�   
   $��4��6   $��4��6#   $��4��60   $)��#informacije o selektiranoj datoteci��6D   ���	#CC6CD7FF.��5�      �� $��3��6   $��0��6&   $ 
Horizontal=�66   .+�5�      �� -   5        $��veličinaDatotekeLabel2��5�   n   $��
Veličina:��6   $��Center=�6,   $! Veličina odabrane datoteke��6I   6n   �� 5�      -   5        $��desniVeličinaTextBox��5�      $��3q�66   $��80��6A   {�.  6L   �� 5�      -   5        $��IsReadOnlyLabel2��5�   y   $��Moguće samo čitanje��6   $��Center=�67   $  Atributi odabrane datoteke��6T   6y   �� 5�      -    5        $��desniIsReadOnlyCheckBox��5�      {�.  6:   �� 5�      -!   5        $��AtributiDatotekeLabel2��5�   n   $��	Atributi:��6   $��Center=�6,   $  Atributi odabrane datoteke��6I   6n   �� 5�      -"   5        $"��desniAtributiDatotekeTextBox��5�      $��3q�6>   {�.  6I   5�      5�      5�      5�      