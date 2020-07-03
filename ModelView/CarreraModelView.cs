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
        private IDialogCoordinator dialogCoordinator;

        public CarreraModelView(IDialogCoordinator instance)
        {
            this.dialogCoordinator = instance;
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

        public async void Execute(object parameter)
        {
            // --------------- * Nuevo * --------------- //
            if (parameter.Equals("Nuevo"))
            {
                this.ElementoSeleccionado = new Carrera();
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
                    this.Posicion = this.ListaCarrera.IndexOf(this.ElementoSeleccionado);
                    this.CarreraUpdate = new Carrera();
                    this.CarreraUpdate.CarreraId = this.ElementoSeleccionado.CarreraId;
                    this.CarreraUpdate.Nombre = this.ElementoSeleccionado.Nombre;
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
                        this.dbContext.CarrerasTecnicas.Remove(this.ElementoSeleccionado);
                        this.dbContext.SaveChanges();

                        this.ListaCarrera.Remove(this.ElementoSeleccionado);

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
                            this.dbContext.CarrerasTecnicas.Add(this.ElementoSeleccionado);
                            this.dbContext.SaveChanges();

                            this.ListaCarrera.Add(this.ElementoSeleccionado);
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
                    this.ListaCarrera.RemoveAt(this.Posicion);
                    //Y pone lo que tenía antes
                    this.ListaCarrera.Insert(this.Posicion, this.CarreraUpdate);
                }
                this._Accion = ACCION.NINGUNO;
                Crear = false;
                Ver = true;
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