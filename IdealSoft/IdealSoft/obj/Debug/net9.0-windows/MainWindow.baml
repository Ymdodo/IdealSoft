   M S B A M L   `   `   `  ����  	IdealSoft    IdealSoft.MainWindow   5   	   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Cadastro��5   	   $	��450��6   $	��800��6'   ���#344e6f.��5      �  � ColumnDefinitions 5   
   �� 5      $
��643* �6   �� 5      $
��157* �6   .+�5
   
   �� $��	IdealSoft��6   $
��Left=�6%   $
��Bold"�6@   $��32(�6R   
�������$��
332,10,0,0q�6s   �� 5   
    �� Orientation$ Vertical=�6   $��10,10,10,10q�6,   $��2��6A   .+�5      �� $��Formulário de Cadastro��6   $
��Bold"�66   $��18(�6H   
�������$��	0,50,0,10q�6i   �� 5      
������� �� Padding$ 10q�6(    �� CornerRadius$ 5��65   ._�5      �� $ Vertical=�6   .+�5      �� $ 
Horizontal=�6!   $��0,5,0,5q�6:   .+�5      �� $��Nome:��6    
���   �$��0,5,0,0q�6C   �� 5      -   5         ��Name$ txtNome��5   "   $	��185��63   $��22��6?   �� 5      $��
Sobrenome:��6    
���   �$��10,5,0,0q�6H   �� 5      -   5        $ txtSobrenome��5   "   $	��185��68   $��22��6D   �� 5      $��	Telefone:��6    
���   �$��10,5,0,0q�6G   �� 5      -   5        $ txtTelefone��5   "   $	��185��67   $��22��6C   5      �� 5      -   5        $��Salvar��5      $	��100��6.   $��Center=�6:   ���#007ACC
�������$
��Bold"�6   $��
645,10,0,0q�6�   6�   5      5      �� 5      $��Histórico de Cadastro��6   $
��Bold"�65   $��18(�6G   
�������$��	0,20,0,10q�6h   �� 5       
�������$ 10q�6(   $ 5��65   ._�5!      &   System.Windows.Controls.DataGrid  -   5          Name$ CadastroGrid��5!         AutoGenerateColumns$ False��61      CanUserAddRows$ False��6M   $
��Auto��6d   $	��900��6q   $
��left=�6�   $
��0,10q�6�   	   Columns	 5"      0  *System.Windows.Controls.DataGridTextColumn  5#      ,  &System.Windows.Controls.DataGridColumn
   Header$

 Nome��6-      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6T   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6;   �� *Nome+6T     5$      $
 	Sobrenome��6-   $ * 6^    6@   �� *	Sobrenome+6^     5%      $
 Telefone��6-   $ * 6\    6?   �� *
Telefone+6\   4  .System.Windows.Controls.DataGridTemplateColumn  5'      $
 Ações��61   $
 Auto 6@      CellTemplate 5(      �� 5)   "   .R�5*   &   �� $ 
Horizontal=�61   .+�5+   *   �� -   5        $��Editar��5+   1   
��� � �
�������$	��5,0q�6h   
 � Tag 6�   �� �� 5,   *   -   5        $��Excluir��5,   1   
���  ��
�������$	��5,0q�6g    6�   �� 5-   '   5.   #   50      52      53      54      55      56      