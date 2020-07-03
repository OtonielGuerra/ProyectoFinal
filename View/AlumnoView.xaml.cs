using System;
using System.Windows;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using ProyectoFinal.ModelView;

namespace ProyectoFinal.View
{
    public partial class AlumnoView : MetroWindow
    {
        private AlumnoModelView model;
        public AlumnoView()
        {
            InitializeComponent();
            model = new AlumnoModelView(DialogCoordinator.Instance);
            this.DataContext = model;
        }
    }
}