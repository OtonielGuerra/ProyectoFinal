using System.Windows;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using ProyectoFinal.ModelView;

namespace ProyectoFinal.View
{
    public partial class SalonView : MetroWindow
    {
        private SalonModelView Modelo;
        public SalonView()
        {
            InitializeComponent();
            Modelo = new SalonModelView(DialogCoordinator.Instance);
            this.DataContext = Modelo;
        }
    }
}