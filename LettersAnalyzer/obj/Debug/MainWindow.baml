   M S B A M L   `   `   `  ����J  FLettersAnalyzer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:LettersAnalyzerLettersAnalyzer  5   	   E'clr-namespace:LettersAnalyzer.ViewModelLettersAnalyzer.ViewModel  65        LettersAnalyzer.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:LettersAnalyzer     5   	   =	viewmodel'clr-namespace:LettersAnalyzer.ViewModel     65     � Title$  Analyzer��5   	   $	��450��6   $	��800��6'   .��5
      �  � RowDefinitions 5   
   �� 5      $��1* �6   �� 5      $��8* �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��Center=�5      $��Center=�5      .+�5      �� $,��&Идентфикаторы строк:��6      
DefaultTxb#��[  5      �� 5      -   5         ��Name$ TxtIdentity��5      |�.   
DefaultTxt#��[ 5      . �5      /� .T�5      J� .*�6    .*�5      �� �6   �� *RowsIdentifier+��5      �� *IncorrectTextBackground+5      5      5      �� 5        
DefaultBtn#��[ 6    �� 	IsDefault . {�5      �� *IsButtonEnable+��5!      �� *FindCurrentText+.��69   Подсчитать6E   5"      &   System.Windows.Controls.DataGrid  5#   
   -   5          Name$ 
GridResult��5#      $��1��5$       %� 
ScrollUnit$ Pixel=�5%      $��Center=�5'        DefaultGrid#��[ 5(      ��5&      �� *
DataView+   Columns 5)      4  .System.Windows.Controls.DataGridTemplateColumn  5*      ,  &System.Windows.Controls.DataGridColumn   Header$ 
Текст��6)   	   CellTemplate	 5+      �� 5,      .R�5-      �� $
��Wrap=�5/   !   $��5q�50   !   ��5.   !   �� *TextData.Text+50   !   52      54        56      $# Количество слов��6)   	 57      �� 58      .R�59      �� $
��Wrap=�5;   !   ��5:   !   �� *WordsAmount+5;   !   5=      5?        5A      $) #Количество гласных��6)   	 5B      �� 5C      .R�5D      �� $
��Wrap=�5F   !   ��5E   !   �� *VowelsAmount+5F   !   5H      5J      5L      5M      5N      