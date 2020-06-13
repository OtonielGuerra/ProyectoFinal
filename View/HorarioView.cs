using System.Windows;
using ProyectoFinal.ModelView;

namespace ProyectoFinal.View
{
    public partial class HorarioView : Window
    {
        private HorarioModelView Modelo;
        public HorarioView()
        {
            InitializeComponent();
            Modelo = new HorarioModelView();
            this.DataContext = Modelo;
        }
    }
}