   M S B A M L   `   `   `  ����H  DProyectoFinal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:ProyectoFinalProyectoFinal  5   	   T PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls 5   	   fCclr-namespace:MahApps.Metro.Controls.Dialogs;assembly=MahApps.MetroMahApps.Metro.Controls.Dialogs 5   	   .    (ProyectoFinal.View.AsignacionAlumnosView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:ProyectoFinal     5   	   Kmah;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5   	   VDialogCclr-namespace:MahApps.Metro.Controls.Dialogs;assembly=MahApps.Metro     5   	     � Title$  Ventana Salón��5   	   $	��400��6   $	��800��6,   8  2MahApps.Metro.Controls.Dialogs.DialogParticipation   Register 5	      �� .��5      �  � RowDefinitions 5   
   �� 5      $	��100 �6   �� 5      $��60 �6   �� 5      $��60 �6   �� 5      $��60 �6   �� 5      $��80 �6    � ColumnDefinitions 5   
   �� 5      �� 5      .+�5   
   &   System.Windows.Controls.DataGrid  $��0��6A      CanUserAddRows$ False��5         ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6$      AutoGenerateColumns$ False��64   $��2��6P    �� SelectedItem 5      �� *ElementoSeleccionado+��6P   �� *ListaAsignacion+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$	 ID��6F   
   
IsReadOnly$

 True��6R   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *AsignacionId+6R     5      $	 ID del Alumno��6B   $

 True��6Y    6%   �� *
AlumnoId+6Y     5      $	 ID de la Clase��6A   $

 True��6Y    6%   �� *	ClaseId+6Y     5       $	 Fecha de Asignacion��6I   $

 True��6f    6%   �� *FechaAsignacion+6f   5"      �� 5$   
   $��1��6   $��0��6   $��ID del Alumno��6-   �� 5&   
   -   5         ��Name$ 	cmbAlumno��5&   0   $��1��6   $��1��6     �� DisplayMemberPath$ AlumnoId��5'   :   ��5&   C   �� *ListaAlumno+ 5'      �� *AlumnoSeleccionados+6Y   �� 5)   
   $��2��6   $��0��6   $��ID de la Clase��6-   �� 5+   
   -   5        $ cmbClase��5+   0   $��2��6   $��1��6    $ ClaseId��5,   8   ��5+   B   �� *
ListaClase+ 5,      �� *ClaseSeleccionado+6V   �� 5.   
   $��3��6   $��0��6   $��Fecha de Asignacion��6-   (  "System.Windows.Controls.DatePicker  50   
   $��3��6   $��1��6"      SelectedDate 62   �� *&$ElementoSeleccionado.FechaAsignacion+�� 52   
   $��4��6   $��2��6"    �� Orientation$ 
Horizontal=�66   $��10q�6O   $��Center=�6[   .+�53      �� $��10q�6/   $��5q�6;   $��Crear Nuevo��6H   $��Nuevo��6|   {�6   �� *Ver+��6^   �� *	Instancia+6|   �� 54      $��10q�6/   $��5q�6;   $��	Modificar��6G   $��	Modificar��6y   {�6   �� *Ver+��6[   �� *	Instancia+6y   �� 55      $��10q�6/   $��5q�6;   $��Eliminar��6G   $��Eliminar��6x   {�6   �� *Ver+��6Z   �� *	Instancia+6x   �� 56      $��10q�61   $��5q�6=   $��Guardar��6I   $��Guardar��6y   {�6   �� *Crear+��6[   �� *	Instancia+6y   �� 57      $��10q�61   $��5q�6=   $��Cancelar��6I   $��Cancelar��6z   {�6   �� *Crear+��6\   �� *	Instancia+6z   58      59      5:      