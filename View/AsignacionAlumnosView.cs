using System.Windows;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using ProyectoFinal.ModelView;

namespace ProyectoFinal.View
{
    public partial class AsignacionAlumnosView : MetroWindow
    {
        private AsignacionAlumnoModelView model;
        public AsignacionAlumnosView()
        {
            InitializeComponent();
            model = new AsignacionAlumnoModelView(DialogCoordinator.Instance);
            this.DataContext = model;
        }
    }
}