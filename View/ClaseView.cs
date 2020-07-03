using System.Windows;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using ProyectoFinal.ModelView;

namespace ProyectoFinal.View
{
    public partial class ClaseView : MetroWindow
    {
        private ClaseModelView Modelo;
        public ClaseView()
        {
            InitializeComponent();
            Modelo = new ClaseModelView(DialogCoordinator.Instance);
            this.DataContext = Modelo;
        }
    }
}   