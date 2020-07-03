using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using MahApps.Metro.Controls.Dialogs;
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
        private IDialogCoordinator dialogCoordinator;
        public HorarioModelView(IDialogCoordinator instance)
        {
            this.dialogCoordinator = instance;
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

        public async void Execute(object parameter)
        {
            // --------------- * Nuevo * --------------- //
            if (parameter.Equals("Nuevo"))
            {
                this.ElementoSeleccionado = new Horario();
                this._Accion = ACCION.NUEVO;
                await this.dialogCoordinator.ShowMessageAsync(this, "Registro", "Ingrese el nuevo regitro");
                Crear = true;
                Ver = false;
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
                    Crear = true;
                    Ver = false;
                }
                else
                {
                    await this.dialogCoordinator.ShowMessageAsync(this, "Modificar", "Elija un elemento a modificar");
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

                         await this.dialogCoordinator.ShowMessageAsync(this, "Eliminado", "Datos eliminados exitosamente");
                    }
                    catch (Exception e)
                    {
                        await this.dialogCoordinator.ShowMessageAsync(this, "Excepción Encontrada", $"{e}");
                    }
                }
                else
                {
                    await this.dialogCoordinator.ShowMessageAsync(this, "Seleccionar un elemento", "Debe seleccionar un elemento para eliminarlo");
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
                            await this.dialogCoordinator.ShowMessageAsync(this, "Guardado", "Datos Guardados con Éxito");
                        }
                        catch (System.Exception e)
                        {
                            await this.dialogCoordinator.ShowMessageAsync(this, "Excepción encontrada", $"{e}");
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
                                await this.dialogCoordinator.ShowMessageAsync(this, "Modificado", "Registro modificado con Éxito");
                            }
                            else 
                            {
                                await this.dialogCoordinator.ShowMessageAsync(this, "Espere", "Debe ingresar la información que quiera ctualizar");
                            }
                        }
                        catch (System.Exception e)
                        {
                            await this.dialogCoordinator.ShowMessageAsync(this, "Excepción encontrada", $"{e}");
                            throw;
                        }
                    break;
                    default:
                    break;
                }
                Crear = false;
                Ver = true;
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
                Crear = false;
                Ver = true;
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
        #region * Switch *
        private bool _Crear = false;
        public bool Crear
        {
            get { return _Crear; }
            set 
            { 
                _Crear = value;
                NotificarCambio("Crear");
            }
        }
        private bool _Ver = true;
        public bool Ver
        {
            get { return _Ver; }
            set 
            { 
                _Ver = value;
                NotificarCambio("Ver");
            }
        }
        #endregion
    }
}