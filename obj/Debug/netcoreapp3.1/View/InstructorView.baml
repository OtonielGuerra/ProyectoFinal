   M S B A M L   `   `   `  ����H  DProyectoFinal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:ProyectoFinalProyectoFinal  5   	   T PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls 5   	   fCclr-namespace:MahApps.Metro.Controls.Dialogs;assembly=MahApps.MetroMahApps.Metro.Controls.Dialogs 5   	   '    !ProyectoFinal.View.InstructorView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:ProyectoFinal     5   	   Kmah;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5   	   VDialogCclr-namespace:MahApps.Metro.Controls.Dialogs;assembly=MahApps.Metro     5   	     � Title$  Ventana Salón��5   	   $	��500��6   $	��800��6,   8  2MahApps.Metro.Controls.Dialogs.DialogParticipation   Register 5	      �� .��5      �  � RowDefinitions 5   
   �� 5      $	��100 �6   �� 5      $��40 �6   �� 5      $��40 �6   �� 5      $��40 �6   �� 5      $��40 �6   �� 5      $��40 �6   �� 5      $��40 �6   �� 5      $��40 �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      �� 5      .+�5   
   &   System.Windows.Controls.DataGrid  $��0��6A      CanUserAddRows$ False��5         ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6$      AutoGenerateColumns$ False��64   $��2��6P    �� SelectedItem 5      �� *ElementoSeleccionado+��6P   �� *ListaInstructor+   Columns 5       0  *System.Windows.Controls.DataGridTextColumn  5!      ,  &System.Windows.Controls.DataGridColumn	   Header$	 ID��6F   
   
IsReadOnly$

 True��6R   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *InstructorId+6R     5"      $	 	Apellidos��6C   $

 True��6V    6%   �� *	Apellidos+6V     5#      $	 Nombres��6A   $

 True��6R    6%   �� *	Nombres+6R     5$      $	 
Comentario��6D   $

 True��6X    6%   �� *
Comentario+6X     5%      $	 	Direccion��6C   $

 True��6V    6%   �� *	Direccion+6V     5&      $	 Estatus��6A   $

 True��6R    6%   �� *	Estatus+6R     5'      $
	 Foto��6>   $

 True��6L    6%   �� *Foto+6L     5(      $	 Telefono��6B   $

 True��6T    6%   �� *
Telefono+6T   5*      �� 5,   
   $��1��6   $��0��6   $��	Apellidos��6-   �� 5-   
   $��1��6   $��1��6   ��6/   �� * ElementoSeleccionado.Apellidos+6a   �� 5/   
   $��2��6   $��0��6   $��Nombres��6-   �� 50   
   $��2��6   $��1��6   ��6/   �� *ElementoSeleccionado.Nombres+6_   �� 52   
   $��3��6   $��0��6   $��
Comentario��6-   �� 53   
   $��3��6   $��1��6   ��6/   �� *!ElementoSeleccionado.Comentario+6b   �� 55   
   $��4��6   $��0��6   $��	Direccion��6-   �� 56   
   $��4��6   $��1��6   ��6/   �� * ElementoSeleccionado.Direccion+6a   �� 58   
   $��5��6   $��0��6   $��Estatus��6-   �� 59   
   $��5��6   $��1��6   ��6/   �� *ElementoSeleccionado.Estatus+6_   �� 5;   
   $��6��6   $��0��6   $
��Foto��6-   �� 5<   
   $��6��6   $��1��6   ��6/   �� *ElementoSeleccionado.Foto+6\   �� 5>   
   $��7��6   $��0��6   $��Telefono��6-   �� 5?   
   $��7��6   $��1��6   ��6/   �� *ElementoSeleccionado.Telefono+6`   �� 5A   
   $��8��6   $��2��6"    �� Orientation$ 
Horizontal=�66   $��10q�6O   $��Center=�6[   .+�5B      �� $��10q�6/   $��5q�6;   $��Crear Nuevo��6H   $��Nuevo��6|   {�6   �� *Ver+��6^   �� *	Instancia+6|   �� 5C      $��10q�6/   $��5q�6;   $��	Modificar��6G   $��	Modificar��6y   {�6   �� *Ver+��6[   �� *	Instancia+6y   �� 5D      $��10q�6/   $��5q�6;   $��Eliminar��6G   $��Eliminar��6x   {�6   �� *Ver+��6Z   �� *	Instancia+6x   �� 5E      $��10q�61   $��5q�6=   $��Guardar��6I   $��Guardar��6y   {�6   �� *Crear+��6[   �� *	Instancia+6y   �� 5F      $��10q�61   $��5q�6=   $��Cancelar��6I   $��Cancelar��6z   {�6   �� *Crear+��6\   �� *	Instancia+6z   5G      5H      5I      