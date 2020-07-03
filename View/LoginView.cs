using System.Windows;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using ProyectoFinal.Model;
using ProyectoFinal.ModelView;

namespace ProyectoFinal.View
{
    public partial class LoginView : MetroWindow
    {
        private LoginModelView ModelView;
        public LoginView(Usuario usuario, MainWindowModelView mainViewModel)
        {
            InitializeComponent();
            this.ModelView = new LoginModelView(usuario, mainViewModel, DialogCoordinator.Instance);
            this.DataContext = ModelView;
        }
    }
}