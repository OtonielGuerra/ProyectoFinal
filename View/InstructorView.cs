using System.Windows;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using ProyectoFinal.ModelView;

namespace ProyectoFinal.View
{
    public partial class InstructorView : MetroWindow
    {
        private InstructorModelView Modelo;
        public InstructorView()
        {
            InitializeComponent();
            Modelo = new InstructorModelView(DialogCoordinator.Instance);
            this.DataContext = Modelo;
            
        }
    }
}