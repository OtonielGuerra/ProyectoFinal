using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using ProyectoFinal.DataContext;
using ProyectoFinal.Model;

namespace ProyectoFinal.ModelView
{
    public class AlumnoModelView : INotifyPropertyChanged, ICommand
    {
        public AlumnoModelView()
        {
            this.Instancia = this;
            this.dbContext = new ProyectoFinalDB();
        }
        private ProyectoFinalDB dbContext;
        private AlumnoModelView _Instancia;
        public AlumnoModelView Instancia
        {
            get 
            { 
                return _Instancia;
            }
            set 
            { 
                _Instancia = value;
                NotificarCambio("Instancia"); 
            }
        }
        private Alumno _ElementoSeleccionado;
        public Alumno ElementoSeleccionados
        {
            get { return _ElementoSeleccionado; }
            set 
            { 
                _ElementoSeleccionado = value; 
                NotificarCambio("ElementoSeleccionados");
            }
        }
        public ObservableCollection<Alumno> _ListaAlumno;

        public ObservableCollection<Alumno> ListaAlumno { 
            get
            {
                if(_ListaAlumno == null)
                {
                    try
                    {
                        _ListaAlumno = new ObservableCollection<Alumno>(dbContext.Alumnos.ToList());
                    }catch(Exception e)
                    {
                        MessageBox.Show(e.ToString());
                    }
                }
                return _ListaAlumno;
            }
            set {
                _ListaAlumno = value;
            }
        }
        public event EventHandler CanExecuteChanged;
        public event PropertyChangedEventHandler PropertyChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            throw new NotImplementedException();
        }
        public void NotificarCambio(string propiedad)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propiedad));
            }
        }
    }
}