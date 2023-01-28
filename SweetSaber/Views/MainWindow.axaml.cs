using Avalonia.Controls;
using SweetSaber.ViewModels;
using System;

namespace SweetSaber.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        protected override void OnOpened(EventArgs e)
        {
            base.OnOpened(e);

            if (DataContext is MainWindowViewModel vm)
            {
                vm.WindowOpened(this, e);
            }
        }
    }
}