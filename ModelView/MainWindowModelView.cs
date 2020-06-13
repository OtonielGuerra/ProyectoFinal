using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
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