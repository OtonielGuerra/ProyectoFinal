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

namespace ProyectoFinal.ModelView
{
    public class AlumnoModelView : INotifyPropertyChanged, ICommand
    {
        enum ACCION
        {
            NINGUNO,
            NUEVO,
            MODIFICAR
        }
        private IDialogCoordinator dialogCoordinator;
        public AlumnoModelView(IDialogCoordinator instance)
        {
            this.dialogCoordinator = instance;
            this.Instancia = this;
            this.dbContext = new ProyectoFinalDB();
        }
        private ACCION _Accion = new ACCION();
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
        private int _Posicion;
        public int Posicion
        {
            get { return _Posicion; }
            set 
            { 
                _Posicion = value;
                NotificarCambio("Update");
            }
        }
        private Alumno _Update;
        public Alumno Update
        {
            get { return _Update; }
            set 
            { 
                _Update = value;
                NotificarCambio("Update");
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

        public async void Execute(object parameter)
        {
            // ------------------- * NUEVO * ------------------------- //
            if(parameter.Equals("Nuevo"))
            {
                this.ElementoSeleccionados = new Alumno();
                this._Accion = ACCION.NUEVO;
                await this.dialogCoordinator.ShowMessageAsync(this, "Registro", "Ingrese el nuevo regitro");
                Crear = true;
                Ver = false;
            }
            // ------------------- * MODIFICAR * ------------------------- //
            else if(parameter.Equals("Modificar"))
            {
                if (this.ElementoSeleccionados != null)
                {
                    this._Accion = ACCION.MODIFICAR;

                    this.Posicion = this.ListaAlumno.IndexOf(this.ElementoSeleccionados);
                    this.Update = new Alumno();
                    this.Update.AlumnoId = this.ElementoSeleccionados.AlumnoId;
                    this.Update.Apellidos = this.ElementoSeleccionados.Apellidos;
                    this.Update.Nombres = this.ElementoSeleccionados.Nombres;
                    this.Update.Email = this.ElementoSeleccionados.Email;
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
                if(this.ElementoSeleccionados != null )
                {
                    try
                    {
                        this.dbContext.Alumnos.Remove(this.ElementoSeleccionados);
                        this.dbContext.SaveChanges();

                        this.ListaAlumno.Remove(this.ElementoSeleccionados);

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
            // ------------------- * GUARDAR * ------------------------- //
            else if(parameter.Equals("Guardar"))
            {
                //Cuando guarda, verifíca si se guarda o se modifica, lo que está en los cuadros
                switch (this._Accion)
                {
                    case ACCION.MODIFICAR:
                        if (this.ElementoSeleccionados != null)
                        {
                            this.dbContext.Entry(this.ElementoSeleccionados).State = EntityState.Modified;
                            //this.dbContext.Alumnos.Update(this.ElementoSeleccionados); También es Funcional
                            this.dbContext.SaveChanges();

                            await this.dialogCoordinator.ShowMessageAsync(this, "Modificado", "Registro modificado con Éxito");
                        }
                        else 
                        {
                            await this.dialogCoordinator.ShowMessageAsync(this, "Espere", "Debe ingresar la información que quiera ctualizar");
                        }
                    break;
                    case ACCION.NUEVO:
                        try
                        {
                            this.dbContext.Alumnos.Add(this.ElementoSeleccionados);
                            this.dbContext.SaveChanges();

                            this.ListaAlumno.Add(this.ElementoSeleccionados);
                            await this.dialogCoordinator.ShowMessageAsync(this, "Guardado", "Datos Guardados con Éxito");
                        }
                        catch (Exception e)
                        {
                            await this.dialogCoordinator.ShowMessageAsync(this, "Excepción encontrada", $"{e}");
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
                    this.ListaAlumno.RemoveAt(this.Posicion);
                    //Y pone lo que tenía antes
                    this.ListaAlumno.Insert(this.Posicion, this.Update);
                }
                this._Accion = ACCION.NINGUNO;
                Crear = false;
                Ver = true;
            }
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