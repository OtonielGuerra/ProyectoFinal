   M S B A M L   `   `   `  ����H  DProyectoFinal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:ProyectoFinalProyectoFinal  5   	   T PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls 5   	   fCclr-namespace:MahApps.Metro.Controls.Dialogs;assembly=MahApps.MetroMahApps.Metro.Controls.Dialogs 5   	   "    ProyectoFinal.View.ClaseView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:ProyectoFinal     5   	   Kmah;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5   	   VDialogCclr-namespace:MahApps.Metro.Controls.Dialogs;assembly=MahApps.Metro     5   	     � Title$  Ventana Salón��5   	   $	��550��6   $	��800��6,   8  2MahApps.Metro.Controls.Dialogs.DialogParticipation   Register 5	      �� .��5      �  � RowDefinitions 5   
   �� 5      $	��100 �6   �� 5      $��40 �6   �� 5      $��40 �6   �� 5      $��40 �6   �� 5      $��40 �6   �� 5      $��40 �6   �� 5      $��40 �6   �� 5      $��40 �6   �� 5      $��40 �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      �� 5      .+�5"   
   &   System.Windows.Controls.DataGrid  $��0��6A      CanUserAddRows$ False��5#         ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6$      AutoGenerateColumns$ False��64   $��2��6P    �� SelectedItem 5"      �� *ElementoSeleccionado+��6P   �� *
ListaClase+   Columns 5$      0  *System.Windows.Controls.DataGridTextColumn  5%      ,  &System.Windows.Controls.DataGridColumn	   Header$	 ID��6A   
   
IsReadOnly$

 True��6M   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *	ClaseId+6M     5&      $	 Ciclo��6?   $

 True��6N    6%   �� *Ciclo+6N     5'      $	 Cupo Máximo��6D   $

 True��6Y    6%   �� *
CupoMaximo+6Y     5(      $	 Cupo Mínimo��6D   $

 True��6Y    6%   �� *
CupoMinimo+6Y     5)      $	 Descripcion��6E   $

 True��6Z    6%   �� *Descripcion+6Z     5*      $	 	CarreraId��6C   $

 True��6V    6%   �� *	CarreraId+6V     5+      $	 	HorarioId��6C   $

 True��6V    6%   �� *	HorarioId+6V     5,      $	 InstructorId��6F   $

 True��6\    6%   �� *InstructorId+6\     5-      $	 SalonId��6A   $

 True��6R    6%   �� *	SalonId+6R   5/      �� 51   
   $��1��6   $��0��6   $��Ciclo��6-   �� 52   
   $��1��6   $��1��6   ��6/   �� *ElementoSeleccionado.Ciclo+6]   �� 54   
   $��2��6   $��0��6   $��
CupoMaximo��6-   �� 55   
   $��2��6   $��1��6   ��6/   �� *!ElementoSeleccionado.CupoMaximo+6b   �� 57   
   $��3��6   $��0��6   $��
CupoMinimo��6-   �� 58   
   $��3��6   $��1��6   ��6/   �� *!ElementoSeleccionado.CupoMinimo+6b   �� 5:   
   $��4��6   $��0��6   $��Descripcion��6-   �� 5;   
   $��4��6   $��1��6   ��6/   �� *" ElementoSeleccionado.Descripcion+6c   �� 5=   
   $��5��6   $��0��6   $��	CarreraId��6-   �� 5>   
   $��5��61   $��1��6>   y�6   �� *	Mostrar+��6N   �� * ElementoSeleccionado.CarreraId+6�   �� 5?   
   -   5         ��Name$ 
cmbCarrera��5?   M   $��5��60   $��1��6=    �� DisplayMemberPath$ 	CarreraId��5@   :   y�5?      �� *Crear+��6a   �� *ListaCarrera+ 5@      �� *CarreraSeleccionado+6Z   �� 5B   
   $��6��6   $��0��6   $��	HorarioId��6-   �� 5C   
   $��6��61   $��1��6>   y�6   �� *	Mostrar+��6N   �� * ElementoSeleccionado.HorarioId+6�   �� 5D   
   -   5        $ 
cmbHorario��5D   M   $��6��60   $��1��6=   $ 	HorarioId��5E   :   y�5D      �� *Crear+��6a   �� *ListaHorario+ 5E      �� *HorarioSeleccionado+6Z   �� 5G   
   $��7��6   $��0��6   $��InstructorId��6-   �� 5H   
   $��7��61   $��1��6>   y�6   �� *	Mostrar+��6N   �� *#!ElementoSeleccionado.InstructorId+6�   �� 5I   
   -   5        $ cmbInstructor��5I   M   $��7��60   $��1��6=   $ InstructorId��5J   =   y�5I      �� *Crear+��6d   �� *ListaInstructor+ 5J      �� *InstructorSeleccionado+6`   �� 5L   
   $��8��6   $��0��6   $��SalonId��6-   �� 5M   
   $��8��61   $��1��6>   y�6   �� *	Mostrar+��6N   �� *ElementoSeleccionado.SalonId+6~   �� 5N   
   -   5        $ cmbSalon��5N   M   $��8��60   $��1��6=   $ SalonId��5O   8   y�5N      �� *Crear+��6_   �� *
ListaSalon+ 5O      �� *SalonSeleccionado+6V   �� 5Q   
   $��9��6   $��2��6"    �� Orientation$ 
Horizontal=�66   $��10q�6O   $��Center=�6[   .+�5R      �� $��10q�6/   $��5q�6;   $��Crear Nuevo��6H   $��Nuevo��6|   {�6   �� *Ver+��6^   �� *	Instancia+6|   �� 5S      $��10q�6/   $��5q�6;   $��	Modificar��6G   $��	Modificar��6y   {�6   �� *Ver+��6[   �� *	Instancia+6y   �� 5T      $��10q�6/   $��5q�6;   $��Eliminar��6G   $��Eliminar��6x   {�6   �� *Ver+��6Z   �� *	Instancia+6x   �� 5U      $��10q�61   $��5q�6=   $��Guardar��6I   $��Guardar��6y   {�6   �� *Crear+��6[   �� *	Instancia+6y   �� 5V      $��10q�61   $��5q�6=   $��Cancelar��6I   $��Cancelar��6z   {�6   �� *Crear+��6\   �� *	Instancia+6z   5W      5X      5Y      