using System.Windows;
using ProyectoFinal.ModelView;

namespace ProyectoFinal.View
{
    public partial class CarreraView: Window
    {
        private CarreraModelView Modelo;
        public CarreraView()
        {
            InitializeComponent();
            Modelo = new CarreraModelView();
            this.DataContext = Modelo;
        }
    }
}