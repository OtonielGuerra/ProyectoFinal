   M S B A M L   `   `   `  ����H  DProyectoFinal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:ProyectoFinalProyectoFinal  5   	   T PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls 5   	   fCclr-namespace:MahApps.Metro.Controls.Dialogs;assembly=MahApps.MetroMahApps.Metro.Controls.Dialogs 5	   	   #    ProyectoFinal.View.AlumnoView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:ProyectoFinal     5   	   Kmah;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5   	   VDialogCclr-namespace:MahApps.Metro.Controls.Dialogs;assembly=MahApps.Metro     5	   	     � Title$  Ventana Alumno��5   	   $	��450��6    $	��800��6-   8  2MahApps.Metro.Controls.Dialogs.DialogParticipation   Register 5
      �� .��5      �  � RowDefinitions 5   
   �� 5      $	��100 �6   �� 5      $��60 �6   �� 5      $��60 �6   �� 5      $��60 �6   �� 5      $��60 �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      �� 5      .+�5   
   &   System.Windows.Controls.DataGrid  $��0��6B      CanUserAddRows$ False��5         ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6$      AutoGenerateColumns$ False��64   $��2��6P    �� SelectedItem 5      �� *ElementoSeleccionados+��6Q   �� *ListaAlumno+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$	 ID��6B   
   
IsReadOnly$

 True��6N   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *
AlumnoId+6N     5      $	 Carné��6?   $

 True��6N    6%   �� *Carne+6N     5       $	 	Apellidos��6C   $

 True��6V    6%   �� *	Apellidos+6V     5!      $	 Nombres��6A   $

 True��6R    6%   �� *	Nombres+6R     5"      $	 Email��6?   $

 True��6N    6%   �� *Email+6N   5$      �� 5&   
   $��1��6   $��0��6   $��Carné��6-   �� 5'   
   $��1��6   $��1��6   ��6/   �� *ElementoSeleccionados.Carne+6^   �� 5(   
   $��2��6   $��0��6   $��	Apellidos��6-   �� 5)   
   $��2��6   $��1��6   ��6/   �� *!ElementoSeleccionados.Apellidos+6b   �� 5*   
   $��3��6   $��0��6   $��Nombres��6-   �� 5+   
   $��3��6   $��1��6   ��6/   �� *ElementoSeleccionados.Nombres+6`   �� 5,   
   $��4��6   $��0��6   $��Email��6-   �� 5-   
   $��4��6   $��1��6   ��6/   �� *ElementoSeleccionados.Email+6^   �� 5/   
   $��5��6   $��2��6"    �� Orientation$ 
Horizontal=�66   $��10q�6O   $��Center=�6[   .+�50      �� $��10q�6/   $��5q�6;   $��Crear Nuevo��6H   $��Nuevo��6|   {�6   �� *Ver+��6^   �� *	Instancia+6|   �� 51      $��10q�6/   $��5q�6;   $��	Modificar��6G   $��	Modificar��6y   {�6   �� *Ver+��6[   �� *	Instancia+6y   �� 52      $��10q�6/   $��5q�6;   $��Eliminar��6G   $��Eliminar��6x   {�6   �� *Ver+��6Z   �� *	Instancia+6x   �� 53      $��10q�61   $��5q�6=   $��Guardar��6I   $��Guardar��6y   {�6   �� *Crear+��6[   �� *	Instancia+6y   �� 54      $��10q�61   $��5q�6=   $��Cancelar��6I   $��Cancelar��6z   {�6   �� *Crear+��6\   �� *	Instancia+6z   55      56      57      