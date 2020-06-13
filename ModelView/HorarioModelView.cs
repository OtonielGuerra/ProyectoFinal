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
    public class HorarioModelView : INotifyPropertyChanged, ICommand
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
        // --------------- * HorarioUpdate * --------------- //
        private Horario _HorarioUpdate;
        public Horario HorarioUpdate
        {
            get { return _HorarioUpdate; }
            set 
            { 
                _HorarioUpdate = value;
                NotificarCambio("SalonUpdate");
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
        private Horario _ElementoSeleccionado;
        public Horario ElementoSeleccionado
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
        private HorarioModelView _Instancia;
        public HorarioModelView Instancia
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
        public HorarioModelView()
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
                this.ElementoSeleccionado = new Horario();
                this._Accion = ACCION.NUEVO;
                MessageBox.Show("Ingrese el nuevo registro, porfavor", "Registro");
            }
            // --------------- * Modificar * --------------- //
            else if (parameter.Equals("Modificar"))
            {
                if (this.ElementoSeleccionado != null)
                {
                    this._Accion = ACCION.MODIFICAR;
                    this.Posicion = this.ListaHorario.IndexOf(this.ElementoSeleccionado);
                    this.HorarioUpdate = new Horario();
                    this.HorarioUpdate.HorarioId = this.ElementoSeleccionado.HorarioId;
                    this.HorarioUpdate.HorarioInicio = this.ElementoSeleccionado.HorarioInicio;
                    this.HorarioUpdate.HorarioFinal = this.ElementoSeleccionado.HorarioFinal;
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
                        this.dbContext.Horarios.Remove(this.ElementoSeleccionado);
                        this.dbContext.SaveChanges();

                        this.ListaHorario.Remove(this.ElementoSeleccionado);

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
                            this.dbContext.Horarios.Add(this.ElementoSeleccionado);
                            this.dbContext.SaveChanges();

                            this.ListaHorario.Add(this.ElementoSeleccionado);
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
                    this.ListaHorario.RemoveAt(this.Posicion);
                    //Y pone lo que tenía antes
                    this.ListaHorario.Insert(this.Posicion, this.HorarioUpdate);
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