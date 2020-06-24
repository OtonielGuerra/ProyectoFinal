using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Microsoft.EntityFrameworkCore;
using ProyectoFinal.DataContext;
using ProyectoFinal.Model;

namespace ProyectoFinal.ModelView
{
    public class AsignacionAlumnoModelView  : INotifyPropertyChanged, ICommand
    {
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
        // --------------- * Asignacion Update * --------------- //
        private AsignacionAlumno _AsignacionUpdate;
        public AsignacionAlumno AsignacionUpdate
        {
            get { return _AsignacionUpdate; }
            set 
            { 
                _AsignacionUpdate = value;
                NotificarCambio("AsignacionUpdate");
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
        private ObservableCollection<AsignacionAlumno> _ListaAsignacion;
        public ObservableCollection<AsignacionAlumno> ListaAsignacion
        {
            get 
            { 
                if (_ListaAsignacion == null)
                {
                    try
                    {
                        _ListaAsignacion = new ObservableCollection<AsignacionAlumno>(dbContext.AsignacionAlumnos.ToList());
                    }
                    catch (System.Exception e)
                    {
                        MessageBox.Show(e.ToString());
                        throw;
                    }
                }
                return _ListaAsignacion;
            }
            set 
            { 
                _ListaAsignacion = value;
                NotificarCambio("ListaAsignacion");
            }
        }
        
        // ------------------------------------ //
        // --------------- * Elemento Seleccionado * --------------- //
        private AsignacionAlumno _ElementoSeleccionado;
        public AsignacionAlumno ElementoSeleccionado
        {
            get { return _ElementoSeleccionado;}
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
        private AsignacionAlumnoModelView _Instancia;
        public AsignacionAlumnoModelView Instancia
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
        public AsignacionAlumnoModelView()
        {
            this.dbContext = new ProyectoFinalDB();
            this.Instancia = this;
        }
        // ------------------------------------ //
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
                this.ElementoSeleccionado = new AsignacionAlumno();

                this._Accion = ACCION.NUEVO;
                MessageBox.Show("Ingrese el nuevo registro, porfavor", "Registro");

                MessageBox.Show(
                                $"Alumno :{this.ElementoSeleccionado.AlumnoId} \n " + 
                                $"Clase :{this.ElementoSeleccionado.ClaseId} \n "+
                                $"Fecha Asignacion :{this.ElementoSeleccionado.FechaAsignacion}", "Datos");
            }
            // --------------- * Modificar * --------------- //
            else if (parameter.Equals("Modificar"))
            {
                if (this.ElementoSeleccionado != null)
                {
                    this._Accion = ACCION.MODIFICAR;
                    this.Posicion = this.ListaAsignacion.IndexOf(this.ElementoSeleccionado);
                    this.AsignacionUpdate = new AsignacionAlumno();
                    this.AsignacionUpdate.AsignacionId = this.ElementoSeleccionado.AsignacionId;
                    this.AsignacionUpdate.AlumnoId = this.ElementoSeleccionado.AlumnoId;
                    this.AsignacionUpdate.ClaseId = this.ElementoSeleccionado.ClaseId;
                    this.AsignacionUpdate.FechaAsignacion = this.ElementoSeleccionado.FechaAsignacion;
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
                        this.dbContext.AsignacionAlumnos.Remove(this.ElementoSeleccionado);
                        this.dbContext.SaveChanges();

                        this.ListaAsignacion.Remove(this.ElementoSeleccionado);

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
                            this.ElementoSeleccionado.AlumnoId = AlumnoSeleccionados.AlumnoId;
                            this.ElementoSeleccionado.ClaseId = ClaseSeleccionado.ClaseId;

                            MessageBox.Show(
                                $"Alumno :{this.ElementoSeleccionado.AlumnoId} \n" + 
                                $"Clase :{this.ElementoSeleccionado.ClaseId} \n"+
                                $"Fecha Asignacion :{this.ElementoSeleccionado.FechaAsignacion}", "Datos");

                            this.dbContext.AsignacionAlumnos.Add(this.ElementoSeleccionado);
                            this.dbContext.SaveChanges();

                            this.ListaAsignacion.Add(this.ElementoSeleccionado);
                            MessageBox.Show("Datos Guardados Exitosamente");
                        }
                        catch (System.Exception e)
                        {
                            MessageBox.Show("Excepción encontrada: " + e, "Excepción 0000");
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
                    this.ListaAsignacion.RemoveAt(this.Posicion);
                    //Y pone lo que tenía antes
                    this.ListaAsignacion.Insert(this.Posicion, this.AsignacionUpdate);
                }
                this._Accion = ACCION.NINGUNO;
            }
        }
        // --------------------------------------------- //
        #endregion
        #region * Lista Alumno *
        private Alumno _AlumnoSeleccionado;
        public Alumno AlumnoSeleccionados
        {
            get { return _AlumnoSeleccionado; }
            set 
            { 
                _AlumnoSeleccionado = value; 
                NotificarCambio("AlumnoSeleccionados");
            }
        }
        // --------------- * Lista Alumno * ----------------- //
        public ObservableCollection<Alumno> _ListaAlumno;

        public ObservableCollection<Alumno> ListaAlumno { 
            get
            {
                if(_ListaAlumno == null)
                {
                    try
                    {
                        _ListaAlumno = new ObservableCollection<Alumno>(dbContext.Alumnos.ToList());
                    }
                    catch(Exception e)
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
        // -------------------------------------------------- //
        #endregion
        #region * Lista Clase *
        // --------------- * Elemento Seleccionado * --------------- //
        private Clase _ClaseSeleccionado;
        public Clase ClaseSeleccionado
        {
            get { return _ClaseSeleccionado; }
            set 
            {
                _ClaseSeleccionado = value;
                NotificarCambio("ClaseSeleccionado");
            }
        }
        
        // ------------------------------------ //
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
        #endregion
    }
}