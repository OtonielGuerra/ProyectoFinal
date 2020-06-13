using System;
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
    public class CarreraModelView : INotifyPropertyChanged, ICommand
    {
        #region * Contructor e Instancia *
        // --------------- * Instancia * --------------- //
        private CarreraModelView _Instancia;
        public CarreraModelView Instancia
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
        public CarreraModelView()
        {
            this.dbContext = new ProyectoFinalDB();
            this.Instancia = this;
        }
        // ------------------------------------ //
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
        // --------------- * CarreraUpdate * --------------- //
        private Carrera _CarreraUpdate;
        public Carrera CarreraUpdate
        {
            get { return _CarreraUpdate; }
            set 
            { 
                _CarreraUpdate = value;
                NotificarCambio("CarreraUpdate");
            }
        }
        // ------------------------------------ //
        #endregion
        #region * Lista y ElementoSeleccionado *
        // --------------- * Lista * --------------- //
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
        // --------------- * Elemento Seleccionado * --------------- //
        private Carrera _ElementoSeleccionado;
        public Carrera ElementoSeleccionado
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
        #region * Property Changed *
        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler CanExecuteChanged;
        public void NotificarCambio(string propiedad)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propiedad));
            }
        }
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
                this.ElementoSeleccionado = new Carrera();
                this._Accion = ACCION.NUEVO;
                MessageBox.Show("Ingrese el nuevo registro, porfavor", "Registro");
            }
            // --------------- * Modificar * --------------- //
            else if (parameter.Equals("Modificar"))
            {
                if (this.ElementoSeleccionado != null)
                {
                    this._Accion = ACCION.MODIFICAR;
                    this.Posicion = this.ListaCarrera.IndexOf(this.ElementoSeleccionado);
                    this.CarreraUpdate = new Carrera();
                    this.CarreraUpdate.CarreraId = this.ElementoSeleccionado.CarreraId;
                    this.CarreraUpdate.Nombre = this.ElementoSeleccionado.Nombre;
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
                        this.dbContext.CarrerasTecnicas.Remove(this.ElementoSeleccionado);
                        this.dbContext.SaveChanges();

                        this.ListaCarrera.Remove(this.ElementoSeleccionado);

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
                            this.dbContext.CarrerasTecnicas.Add(this.ElementoSeleccionado);
                            this.dbContext.SaveChanges();

                            this.ListaCarrera.Add(this.ElementoSeleccionado);
                            MessageBox.Show("Datos Guardados Exitosamente");
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
                    this.ListaCarrera.RemoveAt(this.Posicion);
                    //Y pone lo que tenía antes
                    this.ListaCarrera.Insert(this.Posicion, this.CarreraUpdate);
                }
                this._Accion = ACCION.NINGUNO;
            }
        }
        // --------------------------------------------- //
        #endregion
    }
}