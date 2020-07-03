using System.Windows;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using ProyectoFinal.ModelView;

namespace ProyectoFinal.View
{
    public partial class CarreraView: MetroWindow
    {
        private CarreraModelView Modelo;
        public CarreraView()
        {
            InitializeComponent();
            Modelo = new CarreraModelView(DialogCoordinator.Instance);
            this.DataContext = Modelo;
        }
    }
}