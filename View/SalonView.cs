using System.Windows;
using ProyectoFinal.ModelView;

namespace ProyectoFinal.View
{
    public partial class SalonView : Window
    {
        private SalonModelView Modelo;
        public SalonView()
        {
            InitializeComponent();
            Modelo = new SalonModelView();
            this.DataContext = Modelo;
        }
    }
}