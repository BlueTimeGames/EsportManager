   M S B A M L   `   `   `  ����H  DEsportManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:EsportManagerEsportManager  5   	       EsportManager.TeamDetail   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:EsportManager     5   	     � Title$  Detail týmu��5   	   $	��450��6   $	��800��6*    � 
ResizeMode$ NoResize=�66   .��5	      � .+�5
   
   �� -   5        $��TeamLogo��5
      $
��Left=�6    $	��260��6;   $	��260��6H   $��	10,10,0,0q�6T   $	��Top=�6g   &   System.Windows.Controls.DataGrid  5   
   -   5        $��TournamentsGrid��5      $
��Left=�6*   $	��134��6E   $��
10,275,0,0q�6R   $	��Top=�6f   $	��262��6~      
IsReadOnly .    CanUserDeleteRows .     CanUserAddRows .     CanUserResizeColumns .     CanUserResizeRows .     CanUserSortColumns .     AutoGenerateColumns .  	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn
   Header$
 Sekce��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 50 64   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5      �� *SectionName+  5      $
 Turnaj��6%   $	 185 65    5      �� *Name+5        5   
   -   5        $��PlayersGrid��5      $
��Left=�6&   $	��344��6A   $��
277,65,0,0q�6N   $	��Top=�6b   $	��505��6z    .  .   .   .   .   .   .  	 5        5      $
 Sekce��6%   $ 70 64    5      �� *SectionName+  5      $
 Pozice��6%   $ 80 65    5      �� *PositionName+  5      $

 Nick��6%   $	 110 63    5      �� *Nick+  5      $
 Jméno��6%   $	 109 64    5      �� *Name+  5      $
 Příjmení��6%   $	 109 67    5      �� *	Surname+5!      �� 5"   
   -   5        $��TeamNameLabel��5"      $
��Left=�6%   $��30(�6@   $��
277,10,0,0q�6N   $	��Top=�6b   $��50��6z   $	��505��6�   5#      5$      