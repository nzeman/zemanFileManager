   M S B A M L   `   `   `  ����K  GzemanFileManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:zemanFileManagerzemanFileManager  5      $    zemanFileManager.FolderBrowser   5      T PMahApps.Metro, Version=1.1.2.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4f;Controls,http://metro.mahapps.com/winfx/xaml/controls  5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      0localclr-namespace:zemanFileManager     5      -   5           AccentColorBrush(  "MahApps.Metro.Controls.MetroWindow    	GlowBrush#  �   5       � Title$ FolderBrowser��5      $	��800��6   $	��600��6(   $	��600��64   $	��800��6C    � WindowStartupLocation$ CenterScreen=�6q    � Icon$ Slike/floppySlika.png��6�   .��5      �  � RowDefinitions 5	   
   �� 5
      $	��40* �6   �� 5      $	��40* �6   �� 5      $
��750* �6    � ColumnDefinitions 5   
   �� 5      $	��60* �6   �� 5      $	��60* �6   �� 5      $
��190* �6   .+�5   
   �� -   5        $��obrišiDirektorijButton��5   .   $��1��6   $��0��6   $��2q�6L     AccentedSquareButtonStyle#��[ 6W   .��5      �� $��  Obriši direktorij��6   $��Center=�63   $��Center=�6P   5      �� 5   
   -   5        $$��preimenovanjeDirektorijaButton��5   .   $��1��6   $��1��6   $��2q�6T   #��[ 6_   .��5      �� $��  Preimenuj direktorij��6   $��Center=�66   $��Center=�6S   5      �� 5   
   -   5        $��preimenovanjeTextBox��5   :   $��3��6   $��1��6"   $��2q�6/   .��6W   5      R� 5!   
   -   5         R�Name$ foldersItem��5!      $
��Auto��6^   ���	#FFFFFFFF���	#FFFFFFFF���	#FFFFFFFF$��2��6�   $��0��6�   $��3��6�   $��2��6�    � 	Resources 5"       �� 
TargetType	 �� Property
 �� Value �� Orientation �� RelativeSource �� Mode �� AncestorType �� Path-   'zemanFileManager.HeaderToImageConverter   Instance �� 	Converter��%d  'Q�       �� 5#      " Q�6   .�5$      �� 	 � ��
 5%      �� 5&      .R�5'   "   �� $ 
Horizontal=�6-   .+�5(   &   �� $	��img��6,   $��20��68   $��20��6C   $
��Fill=�6O   ��5)   (   ��  �� $ FindAncestor=�" Q�$ Header�# Z �� 50   &   $	��5,0q�6A   ��60   �� 6A   51   #   52      54      55      56      57      �� 59   
   -   5        $��okButton��59   #   $��Potvrdi��6   $��5q�63   6>   �� 5:   
   -   5        $��pathDirektorija��5:      $��1��6)   $��2��69   $��5q�6N   {�.  6Y   5<      5=      