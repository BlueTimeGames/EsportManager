   M S B A M L   `   `   `  ����H  DEsportManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:EsportManagerEsportManager  5   	        EsportManager.PlayerSearch   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:EsportManager     5   	     � Title$  Vyhledávání hráčů��5   	   $	��450��6#   $	��500��60    � 
ResizeMode$ NoResize=�6<   .��5	      � .+�5
   
   �� -   5        $��TournamentsComboBox��5
      $
��Left=�6.   $��
150,10,0,0q�6I   $	��Top=�6]   $	��140��6u   6�   &   System.Windows.Controls.DataGrid  5   
   -   5        $��FreePlayersGrid��5   !   $��12(�6   $��Center=�68   $	��400��6U   $��	0,50,0,10q�6a      
IsReadOnly .    AutoGenerateColumns .     CanUserAddRows .     CanUserReorderColumns .    CanUserResizeColumns .     CanUserResizeRows .     CanUserSortColumns .  	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn
   Header$

 Tým��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 36 5   8   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6   �� *
TeamName+68     5      $
 Sekce��6%   $ 40 5   ;    6   �� *SectionName+6;     5      $
 Pozice��6%   $ 60 5   <    6   �� *PositionName+6<     5      $

 Nick��6%   $ 79 5   4    6   �� *Nick+64     5      $
 Jméno��6%   $ 79 5   4    6   �� *Name+64     5      $
 Příjmení��6%   $ 79 5   7    6   �� *	Surname+67   5      �� 5   
   -   5        $��TeamsComboBox��5      $
��Left=�6(   $��
307,10,0,0q�6C   $	��Top=�6W   $	��140��6o   6{   �� 5   
   -   5        $��GameComboBox��5      $
��Left=�6'   $��	47,10,0,0q�6B   $	��Top=�6U   $��80��6m   $��80��6x   6�   5      5      