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
    public class AlumnoModelView : INotifyPropertyChanged, ICommand
    {
        enum ACCION
        {
            NINGUNO,
            NUEVO,
            MODIFICAR
        }
        public AlumnoModelView()
        {
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
            // ------------------- * NUEVO * ------------------------- //
            if(parameter.Equals("Nuevo"))
            {
                this.ElementoSeleccionados = new Alumno();
                this._Accion = ACCION.NUEVO;
                MessageBox.Show("Ingrese el nuevo registro, por favor", "Registro");
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

                }
                else
                {
                    MessageBox.Show("Elija un elemento a modificar", "Modificar");
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

                            MessageBox.Show("Modificado con éxito");
                        }
                        else 
                        {
                            MessageBox.Show("Debe ingresar la información que quiera actualizar");
                        }
                    break;
                    case ACCION.NUEVO:
                        try
                        {
                            this.dbContext.Alumnos.Add(this.ElementoSeleccionados);
                            this.dbContext.SaveChanges();

                            this.ListaAlumno.Add(this.ElementoSeleccionados);
                            MessageBox.Show("Datos Guardados Exitosamente");
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show($"Excepción econtrada: {e}", "Excepción");
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
                    this.ListaAlumno.RemoveAt(this.Posicion);
                    //Y pone lo que tenía antes
                    this.ListaAlumno.Insert(this.Posicion, this.Update);
                }
                this._Accion = ACCION.NINGUNO;
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