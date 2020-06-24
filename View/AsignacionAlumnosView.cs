using System.Windows;
using ProyectoFinal.ModelView;

namespace ProyectoFinal.View
{
    public partial class AsignacionAlumnosView : Window
    {
        private AsignacionAlumnoModelView model;
        public AsignacionAlumnosView()
        {
            InitializeComponent();
            model = new AsignacionAlumnoModelView();
            this.DataContext = model;
        }
    }
}