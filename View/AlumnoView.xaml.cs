using System;
using System.Windows;
using ProyectoFinal.ModelView;

namespace ProyectoFinal.View
{
    public partial class AlumnoView : Window
    {
        private AlumnoModelView model;
        public AlumnoView()
        {
            InitializeComponent();
            model = new AlumnoModelView();
            this.DataContext = model;
        }
    }
}