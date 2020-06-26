using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using ProyectoFinal.Model;
using ProyectoFinal.View;

namespace ProyectoFinal.ModelView
{
    public class MainWindowModelView : INotifyPropertyChanged, ICommand
    {
        #region Propiedades
        private MainWindowModelView _Instancia;
        public MainWindowModelView Instancia
        {
            get { return _Instancia; }
            set 
            { 
                _Instancia = value;

            }
        }

        private bool _IsMenuCatalogo = false;

        public bool IsMenuCatalogo
        {
            get { return _IsMenuCatalogo; }
            set 
            { 
                _IsMenuCatalogo = value; 
                NotificarCambio("IsMenuCatalogo");
            }
        }

        private Usuario _Usuario;
        public Usuario Usuario
        {
            get { return _Usuario; }
            set 
            { 
                _Usuario = value;
                NotificarCambio("Usuario");
            }
        }
        
        #endregion
        public MainWindowModelView()
        {
            this.Instancia = this;
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter.Equals("Alumno"))
            {
                new AlumnoView().ShowDialog();
            }
            if (parameter.Equals("Salon"))
            {
                new SalonView().ShowDialog();
            }
            if (parameter.Equals("Carrera"))
            {
                new CarreraView().ShowDialog();
            }
            if (parameter.Equals("Instructor"))
            {
                new InstructorView().ShowDialog();
            }
            if (parameter.Equals("Horario"))
            {
                new HorarioView().ShowDialog();
            }
            if (parameter.Equals("Clase"))
            {
                new ClaseView().ShowDialog();
            }
            if (parameter.Equals("Asignacion"))
            {
                new AsignacionAlumnosView().ShowDialog();
            }
            else if (parameter.Equals("Login"))
            {
                new LoginView(this.Usuario, this).ShowDialog();
                if (this.Usuario != null)
                {
                    this.IsMenuCatalogo = true;
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotificarCambio(string propiedad)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propiedad));
            }
        }
    }
}