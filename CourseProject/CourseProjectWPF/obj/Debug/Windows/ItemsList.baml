   M S B A M L   `   `   `  ����K  GCourseProjectWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:CourseProjectWPF.WindowsCourseProjectWPF.Windows  5   	   (    "CourseProjectWPF.Windows.ItemsList   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:CourseProjectWPF.Windows     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)    � 	Resources 5         ItemCollection �� Source �� Path��%C   &	        �� 5   
    5      �� $ 	ItemsList�5      5      ��5      �� 5   
    �� EndPoint$ 0.5,1&�6    �� 
StartPoint$ 0.5,0&�6/   .��5      �  � Color$ 	#FFED7899��6    � Offset$ 1Q�6-   � 5      $ 	#FFF9E3AE��6   5      .��5"      �  � ColumnDefinitions 5#   
   �� 5$      $
��Auto �6   �� 5%      $	��61* �6   �� 5&      $
��675* �6   	 � RowDefinitions	 5)   
   �� 5*      $
��Auto �6   �� 5+      $��* �6   �� 5,      $
��Auto �6   .+�5/   
   �� 
 �� CornerRadius$
 10��6   $��2��6#   ��50      �� 51      .��52      � $ 	#FFF9E3AE��6#   $	 0.0Q�65   � 53      $ 	#FFF48FB1��6#   $ 1Q�65   54      56      �� 58   
   -   5         ��Name$ 	txtFilter��58   o   $��2��6   $��1��6"   $��444.4,287,92.6,109q�6/   6o   �� 59   
   $��../Images/image2.png��6   $��396.4,23.4,56.6,138q�6.    J� OpacityMask �	#FFDFA406$��2��6c   $��1��6s   &   System.Windows.Controls.DataGrid  5<   
   -   5          Name$ dgItems��5=      $��1��5<      $��3��6       AutoGenerateColumns .     SelectionMode$ Single=�5?         SelectionUnit$ FullRow=�5@         GridLinesVisibility$ 
Horizontal=�5A         CanUserDeleteRows .     CanUserAddRows .     CanUserResizeRows .  $��0,0.4,372.6,0q�5E   f    �	#FF545454$��14(�6�   $
��Bold"�6�   ���	#FF8D6C9F��5<   4   ��  �� Source# [  ��5J      �� 5K      $ 0.5,1&�6&   $ 0.5,0&�67   .��5L      � $ 	#FFA99A76��6#   $ 0Q�65   � 5M      $ 	#FF7A4758��6#   $ 1Q�65   5N      .@�5R      �� $
 10��6   $��2��6'   ��5S      �� 5T      .��5U      � $ 	#FFF9E3AE��6'   $	 0.0Q�69   � 5V      $ 	#FFF48FB1��6'   $ 1Q�69   5W      5Y         Columns 5Z      0  *System.Windows.Controls.DataGridTextColumn  5^      ,  &System.Windows.Controls.DataGridColumn   Header$ ItemID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ SizeToCells 65      
IsReadOnly .    MinWidth$ 60Q�6[   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6i   �� *ItemID+  5_      $
 Name��6%   $ SizeToCells 63    . $	 200Q�6Y    6h   �� *Name+  5`      $ Price��6%   $ SizeToCells 64    . $ 80Q�6Z    6h   �� *Price+  5a      $ OnStock��6%   $ SizeToCells 66    . $ 80Q�6\    6j   �� *	OnStock+   	CellStyle 5c      �� 5d       �� 
TargetType*  $System.Windows.Controls.DataGridCell"  6    �� Triggers 5e      P� 5f       P� Property �@ 
IsSelected  P� Value  . . �5g      �� ! �� Property! � ��" �� Value$" 0q�6@   5h      5j      5l      �� 5m   
   -   5        # ��Name$# 
btnAddItem��5m   $   $��NEW ITEM��6   $��374.4,367,233.6,10q�69   $��2��6n   $��1��6~   $��3��6�   $��0q�6�   $ J� SnapsToDevicePixels$ . $��Segoe UI Semibold)�6�   $
��Bold"�6�   $��18(�6  
���������6�   Z� 6  5n      5o      