   M S B A M L   `   `   `  ����H  DEsportManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:EsportManagerEsportManager  5   	        EsportManager.PowerRanking   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:EsportManager     5   	     � Title$  Power Ranking��5   	   $	��390��6   $	��290��6,    � 
ResizeMode$ NoResize=�68    � WindowStartupLocation$ CenterScreen=�6N   .��5	      � .+�5
   
   &   System.Windows.Controls.DataGrid  -   5        $��PowerRankingGrid��5
      $
��Left=�6+   $	��292��6F   $��	10,48,0,0q�6S      
IsReadOnly .    CanUserDeleteRows .     CanUserAddRows .     CanUserResizeColumns .     CanUserResizeRows .     CanUserSortColumns .  $	��Top=�6�   $	��254��6  	   AutoGenerateColumns	 .  
   Columns
 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ #��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 20 60   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5      �� *PowerPosition+  5      $ Název týmu��6%   $	 140 69    5      �� *
TeamName+  5      $ V��6%   $ 20 60    5      �� *Wins+  5      $ P��6%   $ 20 60    5      �� *Loses+  5      $ H��6%   $ 27 60    5      �� *PowerRanking+5      �� 5   
   -   5        $��
SectionsCB��5      $
��Left=�6%   $��	10,10,0,0q�6@   $	��Top=�6S   $	��254��6k   6w   5      5      