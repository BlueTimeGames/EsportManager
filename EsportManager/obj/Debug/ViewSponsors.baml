   M S B A M L   `   `   `  ����H  DEsportManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:EsportManagerEsportManager  5   	        EsportManager.ViewSponsors   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:EsportManager     5   	   -   5          � Title$  	Sponzoři��5   	   $	��340��6   $	��400��6'    � 
ResizeMode$ NoResize=�63   .��5	      � .+�5
   
   �� -   5        $��AddSponsor1��5
      $��Přidat sponzora��6$   $��Center=�6>   $��0,80,0,0q�6[   $	��Top=�6m   $	��100��6�   $y�Hidden=�6�      MyButtonStyle#���   6�   �� 5   
   -   5        $��AddSponsor2��5      $��Přidat sponzora��6$   $��Center=�6>   $��	0,180,0,0q�6[   $	��Top=�6n   $	��100��6�   $y�Hidden=�6�   #���   6�   �� 5   
   -   5        $��AddSponsor3��5      $��Přidat sponzora��6$   $��Center=�6>   $��	0,280,0,0q�6[   $	��Top=�6n   $	��100��6�   $y�Hidden=�6�   #���   6�   �� 5   
   -   5        $��Sponsor1Name��5      $��Center=�6$   $��NÁZEV��6H   $
��Left=�6X   $��30,0,0,0q�6s   $	��Top=�6�   $	��100��6�   �� 5   
   -   5        $ ��Sponsor1MonthlyIncomeLabel��5      $��Měsíční příjem��62   $
��Left=�6K   $��	150,0,0,0q�6f   $	��Top=�6y   �� 5   
   -   5        $��Sponsor1MonthlyIncome��5      $��HODNOTA��6-   $
��Left=�6?   $��
150,20,0,0q�6Z   $	��Top=�6n   �� 5   
   -   5        $��Sponsor1BonusIncomeLabel��5      $��Bonus při obnovení��60   $
��Left=�6M   $��
150,50,0,0q�6h   $	��Top=�6|   �� 5   
   -	   5        $��Sponsor1BonusIncome��5      $��HODNOTA��6+   $
��Left=�6=   $��
150,70,0,0q�6X   $	��Top=�6l   �� 5   
   -
   5        $#��Sponsor1DateOfExpirationLabel��5      $��Datum vypršení��65   $
��Left=�6N   $��	280,0,0,0q�6i   $	��Top=�6|   �� 5   
   -   5        $��Sponsor1DateOfExpiration��5      $��HODNOTA��60   $
��Left=�6B   $��
280,20,0,0q�6]   $	��Top=�6q   �� 5   
   -   5        $��Sponsor1RenewContract��5      $��Obnovit��6.   $
��Left=�6@   $��
280,50,0,0q�6[   $	��Top=�6o   $��75��6�   #���   6�   �� 5   
   -   5        $��Sponsor1SignContract��5      $��Podepsat��6-   $
��Left=�6@   $��
280,50,0,0q�6[   $	��Top=�6o   $��75��6�   #���   6�   �� 5   
   -   5        $��Sponsor1CancelContract��5      $��Vypovědět��6/   $
��Left=�6C   $��
280,70,0,0q�6^   $	��Top=�6r   $��75��6�   #���   6�   �� 5   
   -   5        $��Sponsor1Logo��5      $
��Left=�6$   $��70��6?   $��	50,25,0,0q�6K   $	��Top=�6^   $��70��6v   �� 5   
   -   5        $��Sponsor2Name��5      $��Center=�6$   $��NÁZEV��6H   $
��Left=�6X   $��
30,100,0,0q�6s   $	��Top=�6�   $	��100��6�   �� 5   
   -   5        $ ��Sponsor2MonthlyIncomeLabel��5      $��Měsíční příjem��62   $
��Left=�6K   $��150,100,0,0q�6f   $	��Top=�6{   �� 5   
   -   5        $��Sponsor2MonthlyIncome��5      $��HODNOTA��6-   $
��Left=�6?   $��150,120,0,0q�6Z   $	��Top=�6o   �� 5   
   -   5        $��Sponsor2BonusIncomeLabel��5      $��Bonus při obnovení��60   $
��Left=�6M   $��150,150,0,0q�6h   $	��Top=�6}   �� 5   
   -   5        $��Sponsor2BonusIncome��5      $��HODNOTA��6+   $
��Left=�6=   $��150,170,0,0q�6X   $	��Top=�6m   �� 5   
   -   5        $#��Sponsor2DateOfExpirationLabel��5      $��Datum vypršení��65   $
��Left=�6N   $��280,100,0,0q�6i   $	��Top=�6~   �� 5   
   -   5        $��Sponsor2DateOfExpiration��5      $��HODNOTA��60   $
��Left=�6B   $��280,120,0,0q�6]   $	��Top=�6r   �� 5    
   -   5        $��Sponsor2RenewContract��5       $��Obnovit��6.   $
��Left=�6@   $��280,150,0,0q�6[   $	��Top=�6p   $��75��6�   #���   6�   �� 5!   
   -   5        $��Sponsor2SignContract��5!      $��Podepsat��6-   $
��Left=�6@   $��280,150,0,0q�6[   $	��Top=�6p   $��75��6�   #���   6�   �� 5"   
   -   5        $��Sponsor2CancelContract��5"      $��Vypovědět��6/   $
��Left=�6C   $��280,170,0,0q�6^   $	��Top=�6s   $��75��6�   #���   6�   �� 5#   
   -   5        $��Sponsor2Logo��5#      $
��Left=�6$   $��70��6?   $��
50,125,0,0q�6K   $	��Top=�6_   $��70��6w   �� 5%   
   -   5        $��Sponsor3Name��5%      $��Center=�6$   $��NÁZEV��6H   $
��Left=�6X   $��
30,200,0,0q�6s   $	��Top=�6�   $	��100��6�   �� 5&   
   -   5        $ ��Sponsor3MonthlyIncomeLabel��5&      $��Měsíční příjem��62   $
��Left=�6K   $��150,200,0,0q�6f   $	��Top=�6{   �� 5'   
   -   5        $��Sponsor3MonthlyIncome��5'      $��HODNOTA��6-   $
��Left=�6?   $��150,220,0,0q�6Z   $	��Top=�6o   �� 5(   
   -   5        $��Sponsor3BonusIncomeLabel��5(      $��Bonus při obnovení��60   $
��Left=�6M   $��150,250,0,0q�6h   $	��Top=�6}   �� 5)   
   -   5        $��Sponsor3BonusIncome��5)      $��HODNOTA��6+   $
��Left=�6=   $��150,270,0,0q�6X   $	��Top=�6m   �� 5*   
   -    5        $#��Sponsor3DateOfExpirationLabel��5*      $��Datum vypršení��65   $
��Left=�6N   $��280,200,0,0q�6i   $	��Top=�6~   �� 5+   
   -!   5        $��Sponsor3DateOfExpiration��5+      $��HODNOTA��60   $
��Left=�6B   $��280,220,0,0q�6]   $	��Top=�6r   �� 5,   
   -"   5        $��Sponsor3RenewContract��5,      $��Obnovit��6.   $
��Left=�6@   $��280,250,0,0q�6[   $	��Top=�6p   $��75��6�   #���   6�   �� 5-   
   -#   5        $��Sponsor3SignContract��5-      $��Podepsat��6-   $
��Left=�6@   $��280,250,0,0q�6[   $	��Top=�6p   $��75��6�   #���   6�   �� 5.   
   -$   5        $��Sponsor3CancelContract��5.      $��Vypovědět��6/   $
��Left=�6C   $��280,270,0,0q�6^   $	��Top=�6s   $��75��6�   #���   6�   �� 5/   
   -%   5        $��Sponsor3Logo��5/      $
��Left=�6$   $��70��6?   $��
50,225,0,0q�6K   $	��Top=�6_   $��70��6w   �� 51   
   
���   �$��1��6!   $��	0,200,0,0q�6,   
���   �$	��Top=�6N   $
��Left=�6f   $	��400��6�   �� 52   
   
���   �$��1��6!   $��	0,100,0,0q�6,   
���   �$	��Top=�6N   $
��Left=�6f   $	��400��6�   54      55      