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
    public class InstructorModelView : INotifyPropertyChanged, ICommand
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
        // --------------- * InstructorUpdate * --------------- //
        private Instructor _InstructorUpdate;
        public Instructor InstructorUpdate
        {
            get { return _InstructorUpdate; }
            set 
            { 
                _InstructorUpdate = value;
                NotificarCambio("InstructorUpdate");
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
        private Instructor _ElementoSeleccionado;
        public Instructor ElementoSeleccionado
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
        private InstructorModelView _Instancia;
        public InstructorModelView Instancia
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
        public InstructorModelView()
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
                this.ElementoSeleccionado = new Instructor();
                this._Accion = ACCION.NUEVO;
                MessageBox.Show("Ingrese el nuevo registro, porfavor", "Registro");
            }
            // --------------- * Modificar * --------------- //
            else if (parameter.Equals("Modificar"))
            {
                if (this.ElementoSeleccionado != null)
                {
                    this._Accion = ACCION.MODIFICAR;
                    this.Posicion = this.ListaInstructor.IndexOf(this.ElementoSeleccionado);
                    this.InstructorUpdate = new Instructor();
                    this.InstructorUpdate.InstructorId = this.ElementoSeleccionado.InstructorId;
                    this.InstructorUpdate.Apellidos = this.ElementoSeleccionado.Apellidos;
                    this.InstructorUpdate.Nombres = this.ElementoSeleccionado.Nombres;
                    this.InstructorUpdate.Comentario = this.ElementoSeleccionado.Comentario;
                    this.InstructorUpdate.Direccion = this.ElementoSeleccionado.Direccion;
                    this.InstructorUpdate.Estatus = this.ElementoSeleccionado.Estatus;
                    this.InstructorUpdate.Foto = this.ElementoSeleccionado.Foto;
                    this.InstructorUpdate.Telefono = this.ElementoSeleccionado.Telefono;
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
                        this.dbContext.Instructores.Remove(this.ElementoSeleccionado);
                        this.dbContext.SaveChanges();

                        this.ListaInstructor.Remove(this.ElementoSeleccionado);

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
                            this.dbContext.Instructores.Add(this.ElementoSeleccionado);
                            this.dbContext.SaveChanges();

                            this.ListaInstructor.Add(this.ElementoSeleccionado);
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
                    this.ListaInstructor.RemoveAt(this.Posicion);
                    //Y pone lo que tenía antes
                    this.ListaInstructor.Insert(this.Posicion, this.InstructorUpdate);
                }
                this._Accion = ACCION.NINGUNO;
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
    }
}