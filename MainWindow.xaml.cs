﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ProyectoFinal.ModelView;
using MahApps.Metro.Controls;

namespace ProyectoFinal
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        private MainWindowModelView Modelo;
        public MainWindow()
        {
            InitializeComponent();
            Modelo = new MainWindowModelView();
            this.DataContext = Modelo;
        }
    }
}