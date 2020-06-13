using System.Windows;
using ProyectoFinal.ModelView;

namespace ProyectoFinal.View
{
    public partial class InstructorView : Window
    {
        private InstructorModelView Modelo;
        public InstructorView()
        {
            InitializeComponent();
            Modelo = new InstructorModelView();
            this.DataContext = Modelo;
            
        }
    }
}