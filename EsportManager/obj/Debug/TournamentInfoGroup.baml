   M S B A M L   `   `   `  ����H  DEsportManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:EsportManagerEsportManager  5   	   '    !EsportManager.TournamentInfoGroup   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:EsportManager     5   	     � Title$  Detail turnaje��5   	   $	��450��6    $	��800��6-    � 
ResizeMode$ NoResize=�69   .��5	      � -   5        $��MainGrid��5	      .+�5
   
   &   System.Windows.Controls.DataGrid  -   5        $��	Standings��5
      $
��Left=�6$   $	��345��6?   $��	10,65,0,0q�6L   $	��Top=�6_   $	��480��6w      
IsReadOnly .    CanUserDeleteRows .     CanUserAddRows .     CanUserResizeColumns .     CanUserResizeRows .     CanUserSortColumns .     AutoGenerateColumns .  $��18(�64  	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn
   Header$
 Postup��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 69 65   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5      �� *TournamentTo+  5      $
 #��6%   $ 25 60    5      �� *
Position+  5      $
 Název týmu��6%   $	 128 69    5      �� *
TeamName+  5      $
 Z��6%   $ 32 60    5      �� *MatchesPlayed+  5      $
 V��6%   $ 32 60    5      �� *
MatchesWon+  5      $
 P��6%   $ 32 60    5      �� *MatchesLost+  5      $
 VM��6%   $ 36 61    5      �� *	MapsWon+  5      $
 PM��6%   $ 36 61    5      �� *
MapsLost+  5      $
 $��6%   $ 63 60    5      �� *	PrizePool+5      �� 5    
   -   5        $��TournamentName��5       $
��Left=�6'   $��Center=�6B   $��	10,10,0,0q�6f   $	��Top=�6y   $��45��6�   $	��440��6�   $��20(�6�   �� 5!   
   $��WrapWithOverflow=�6   $
��Left=�64    �� TextAlignment$ Center=�6O   $!��Poslední odehrané zápasy��6f   $��
500,10,0,0q�6�   $	��Top=�6�   $��45��6�   $	��130��6�   $��14(�6�   �� 5"   
   $��WrapWithOverflow=�6   $
��Left=�64   $ Center=�6O   $��Nadcházející zápasy��6f   $��
640,10,0,0q�6�   $	��Top=�6�   $��45��6�   $	��130��6�   $��14(�6�   � 5#   
   -   5        $��MatchesPlayed��5#      $
��Left=�6$   $	��345��6?   $��
500,65,0,0q�6L   $	��Top=�6`   $	��130��6x   
������6�   � 5$   
   -   5        $��MatchesIncoming��5$      $
��Left=�6&   $	��345��6A   $��
640,65,0,0q�6N   $	��Top=�6b   $	��130��6z   
������6�   5'      5(      