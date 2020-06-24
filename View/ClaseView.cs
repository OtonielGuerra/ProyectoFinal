using System.Windows;
using ProyectoFinal.ModelView;

namespace ProyectoFinal.View
{
    public partial class ClaseView : Window
    {
        private ClaseModelView Modelo;
        public ClaseView()
        {
            InitializeComponent();
            Modelo = new ClaseModelView();
            this.DataContext = Modelo;
        }
    }
}   