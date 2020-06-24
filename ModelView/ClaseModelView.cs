using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Microsoft.EntityFrameworkCore;
using ProyectoFinal.DataContext;
using ProyectoFinal.Model;

// --------------- *  * --------------- //
// ------------------------------------ //
namespace ProyectoFinal.ModelView
{
    public class ClaseModelView : INotifyPropertyChanged, ICommand
    {
        #region * Visibilidad *
        private Visibility _Crear = Visibility.Hidden;
        public Visibility Crear
        {
            get { return _Crear; }
            set 
            {
                _Crear = value;
                NotificarCambio("Crear"); 
            }
        }
        private Visibility _Mostrar = Visibility.Visible;
        public Visibility Mostrar
        {
            get { return _Mostrar; }
            set 
            {
                _Mostrar = value;
                NotificarCambio("Mostrar");
            }
        }
        #endregion
        #region * Posición y Elemento para Actualizar *
        // --------------- * Posicion * --------------- //
        private int _Posicion;
        public int Posicion
        {
            get { return _Posicion; }
            set 
            { 
                _Posicion = value;
                NotificarCambio("Posicion");
            }
        }
        
        // ------------------------------------ //
        // --------------- * SalonUpdate * --------------- //
        private Clase _ClaseUpdate;
        public Clase ClaseUpdate
        {
            get { return _ClaseUpdate; }
            set 
            { 
                _ClaseUpdate = value;
                NotificarCambio("ClaseUpdate");
            }
        }
        
        // ------------------------------------ //
        #endregion
        #region * Enumeración *
        // --------------- * ENUM * --------------- //
        enum ACCION
        {
            NINGUNO,
            NUEVO,
            MODIFICAR
        }
        private ACCION _Accion = new ACCION();
        // ------------------------------------ //
        #endregion
        #region * Lista y ElementoSeleccionado *
        // --------------- * Lista * --------------- //
        private ObservableCollection<Clase> _ListaClase;
        public ObservableCollection<Clase> ListaClase
        {
            get 
            { 
                if (_ListaClase == null)
                {
                    try
                    {
                        _ListaClase = new ObservableCollection<Clase>(dbContext.Clases.ToList());
                    }
                    catch (System.Exception e)
                    {
                        MessageBox.Show(e.ToString());
                        throw;
                    }
                }
                return _ListaClase;
            }
            set 
            { 
                _ListaClase = value;
                NotificarCambio("ListaClase");
            }
        }
        
        // ------------------------------------ //
        // --------------- * Elemento Seleccionado * --------------- //
        private Clase _ElementoSeleccionado;
        public Clase ElementoSeleccionado
        {
            get { return _ElementoSeleccionado; }
            set 
            {
                _ElementoSeleccionado = value;
                NotificarCambio("ElementoSeleccionado");
            }
        }
        
        // ------------------------------------ //
        #endregion
        #region * Contructor e Instancia *
        // --------------- * Instancia * --------------- //
        private ClaseModelView _Instancia;
        public ClaseModelView Instancia
        {
            get { return _Instancia; }
            set 
            { 
                _Instancia = value;
                NotificarCambio("Instancia");
            }
        }
        // ------------------------------------ //
        // --------------- * Constructor * --------------- //
        private ProyectoFinalDB dbContext;
        public ClaseModelView()
        {
            this.dbContext = new ProyectoFinalDB();
            this.Instancia = this;
        }
        // ------------------------------------ //
        #endregion
        #region * ICommand *
        // --------------- * ICommand * --------------- //
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            // --------------- * Nuevo * --------------- //
            if (parameter.Equals("Nuevo"))
            {
                this.Crear = Visibility.Visible;
                this.Mostrar = Visibility.Hidden;

                this.ElementoSeleccionado = new Clase();
                this._Accion = ACCION.NUEVO;
                MessageBox.Show("Ingrese el nuevo registro, porfavor", "Registro");
            }
            // --------------- * Modificar * --------------- //
            else if (parameter.Equals("Modificar"))
            {
                if (this.ElementoSeleccionado != null)
                {
                    this._Accion = ACCION.MODIFICAR;
                    this.Posicion = this.ListaClase.IndexOf(this.ElementoSeleccionado);
                    this.ClaseUpdate = new Clase();
                    this.ClaseUpdate.ClaseId = this.ElementoSeleccionado.ClaseId;
                    this.ClaseUpdate.Ciclo = this.ElementoSeleccionado.Ciclo;
                    this.ClaseUpdate.CupoMaximo = this.ElementoSeleccionado.CupoMaximo;
                    this.ClaseUpdate.CupoMinimo = this.ElementoSeleccionado.CupoMinimo;
                    this.ClaseUpdate.Descripcion = this.ElementoSeleccionado.Descripcion;
                    this.ClaseUpdate.CarreraId = this.ElementoSeleccionado.CarreraId;
                    this.ClaseUpdate.HorarioId = this.ElementoSeleccionado.HorarioId;
                    this.ClaseUpdate.InstructorId = this.ElementoSeleccionado.InstructorId;
                    this.ClaseUpdate.SalonId = this.ElementoSeleccionado.SalonId;
                }
                else
                {
                    MessageBox.Show("Elija un elemento a modificar", "Modificar");
                }
            }
            // ------------------- * ELIMINAR * ------------------------- //
            else if(parameter.Equals("Eliminar"))
            {
                if(this.ElementoSeleccionado != null )
                {
                    try
                    {
                        this.dbContext.Clases.Remove(this.ElementoSeleccionado);
                        this.dbContext.SaveChanges();

                        this.ListaClase.Remove(this.ElementoSeleccionado);

                        MessageBox.Show("Datos Eliminados Exitosamente");
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show($"Excepción econtrada: {e}");
                    }
                }
                else
                {
                    MessageBox.Show("Debes seleccionar un elemento para borrar");
                }
            }
            // --------------- * Guardar * --------------- //
            else if (parameter.Equals("Guardar"))
            {
                switch (this._Accion)
                {
                    case ACCION.NUEVO:
                        try
                        {
                            this.ElementoSeleccionado.CarreraId = this.CarreraSeleccionado.CarreraId;
                            this.ElementoSeleccionado.HorarioId = this.HorarioSeleccionado.HorarioId;
                            this.ElementoSeleccionado.InstructorId = this.InstructorSeleccionado.InstructorId;
                            this.ElementoSeleccionado.SalonId = this.SalonSeleccionado.SalonId;
                            
                            this.dbContext.Clases.Add(this.ElementoSeleccionado);
                            this.dbContext.SaveChanges();

                            this.ListaClase.Add(this.ElementoSeleccionado);
                            MessageBox.Show("Datos Guardados Exitosamente");

                            VerElemento();
                        }
                        catch (System.Exception e)
                        {
                            MessageBox.Show("Excepción encontrada: " + e, "Excepción");
                            throw;
                        }
                    break;
                    case ACCION.MODIFICAR:
                        try
                        {
                            if (this.ElementoSeleccionado != null)
                            {
                                this.dbContext.Entry(ElementoSeleccionado).State = EntityState.Modified;
                                this.dbContext.SaveChanges();
                                MessageBox.Show("Modificado con éxito");
                            }
                            else 
                            {
                                MessageBox.Show("Debe ingresar la información que quiera actualizar");
                            }
                        }
                        catch (System.Exception e)
                        {
                            MessageBox.Show("Excepción encontrada: " + e, "Excepción");
                            throw;
                        }
                    break;
                    default:
                    break;
                }
            }
            // ------------------- * CANCELAR * ------------------------- //
            else if(parameter.Equals("Cancelar"))
            {
                if (this._Accion == ACCION.MODIFICAR)
                {
                    //Quita lo que había antes
                    this.ListaClase.RemoveAt(this.Posicion);
                    //Y pone lo que tenía antes
                    this.ListaClase.Insert(this.Posicion, this.ClaseUpdate);
                }
                this._Accion = ACCION.NINGUNO;
                VerElemento();
            }
        }
        // --------------------------------------------- //
        #endregion
        #region * Property Changed *
        // --------------- * Property Changed * --------------- // 
        public event EventHandler CanExecuteChanged;
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotificarCambio(string propiedad)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propiedad));
            }
        }
        // --------------------------------------------- //
        #endregion
        #region * Carrera List *
        private ObservableCollection<Carrera> _ListaCarrera;
        public ObservableCollection<Carrera> ListaCarrera
        {
            get 
            { 
                if (_ListaCarrera == null)
                {
                    try
                    {
                        _ListaCarrera = new ObservableCollection<Carrera>(dbContext.CarrerasTecnicas.ToList());
                    }
                    catch (System.Exception e)
                    {
                        MessageBox.Show(e.ToString());
                        throw;
                    }
                }
                return _ListaCarrera;
            }
            set 
            { 
                _ListaCarrera = value;
                NotificarCambio("ListaCarrera");
            }
        }
        
        // ------------------------------------ //
        // --------------- * Carrera Seleccionado * --------------- //
        private Carrera _CarreraSeleccionado;
        public Carrera CarreraSeleccionado
        {
            get { return _CarreraSeleccionado; }
            set 
            {
                _CarreraSeleccionado = value;
                NotificarCambio("CarreraSeleccionado");
            }
        }
        
        // ------------------------------------ //
        #endregion
        #region * Horario List *
        private ObservableCollection<Horario> _ListaHorario;
        public ObservableCollection<Horario> ListaHorario
        {
            get 
            { 
                if (_ListaHorario == null)
                {
                    try
                    {
                        _ListaHorario = new ObservableCollection<Horario>(dbContext.Horarios.ToList());
                    }
                    catch (System.Exception e)
                    {
                        MessageBox.Show(e.ToString());
                        throw;
                    }
                }
                return _ListaHorario;
            }
            set 
            { 
                _ListaHorario = value;
                NotificarCambio("ListaHorario");
            }
        }
        
        // ------------------------------------ //
        // --------------- * Elemento Seleccionado * --------------- //
        private Horario _HorarioSeleccionado;
        public Horario HorarioSeleccionado
        {
            get { return _HorarioSeleccionado; }
            set 
            {
                _HorarioSeleccionado = value;
                NotificarCambio("HorarioSeleccionado");
            }
        }
        
        // ------------------------------------ //
        #endregion
        #region * Instructor List *
        // --------------- * Lista * --------------- //
        private ObservableCollection<Instructor> _ListaInstructor;
        public ObservableCollection<Instructor> ListaInstructor
        {
            get 
            { 
                if (_ListaInstructor == null)
                {
                    try
                    {
                        _ListaInstructor = new ObservableCollection<Instructor>(dbContext.Instructores.ToList());
                    }
                    catch (System.Exception e)
                    {
                        MessageBox.Show(e.ToString());
                        throw;
                    }
                }
                return _ListaInstructor;
            }
            set 
            { 
                _ListaInstructor = value;
                NotificarCambio("ListaSalon");
            }
        }
        
        // ------------------------------------ //
        // --------------- * Elemento Seleccionado * --------------- //
        private Instructor _InstructorSeleccionado;
        public Instructor InstructorSeleccionado
        {
            get { return _InstructorSeleccionado; }
            set 
            { 
                _InstructorSeleccionado = value;
                NotificarCambio("InstructorSeleccionado");
            }
        }
        
        // ------------------------------------ //
        #endregion
        #region * Salon List *
        // --------------- * Lista * --------------- //
        private ObservableCollection<Salon> _ListaSalon;
        public ObservableCollection<Salon> ListaSalon
        {
            get 
            { 
                if (_ListaSalon == null)
                {
                    try
                    {
                        _ListaSalon = new ObservableCollection<Salon>(dbContext.Salones.ToList());
                    }
                    catch (System.Exception e)
                    {
                        MessageBox.Show(e.ToString());
                        throw;
                    }
                }
                return _ListaSalon;
            }
            set 
            { 
                _ListaSalon = value;
                NotificarCambio("ListaSalon");
            }
        }
        
        // ------------------------------------ //
        // --------------- * Elemento Seleccionado * --------------- //
        private Salon _SalonSeleccionado;
        public Salon SalonSeleccionado
        {
            get { return _SalonSeleccionado; }
            set 
            { 
                _SalonSeleccionado = value;
                NotificarCambio("SalonSeleccionado");
            }
        }
        
        // ------------------------------------ //
        #endregion
        #region * Método para ver Elementos *
        private void VerElemento()
        {
            this.Crear = Visibility.Hidden;
            this.Mostrar = Visibility.Visible;
            
        }
        #endregion
    }
}