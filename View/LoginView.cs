using System.Windows;
using MahApps.Metro.Controls;
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
            this.ModelView = new LoginModelView(usuario, mainViewModel);
            this.DataContext = ModelView;
        }
    }
}