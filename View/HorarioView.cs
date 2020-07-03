using System.Windows;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using ProyectoFinal.ModelView;

namespace ProyectoFinal.View
{
    public partial class HorarioView : MetroWindow
    {
        private HorarioModelView Modelo;
        public HorarioView()
        {
            InitializeComponent();
            Modelo = new HorarioModelView(DialogCoordinator.Instance);
            this.DataContext = Modelo;
        }
    }
}