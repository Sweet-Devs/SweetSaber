using Avalonia.Controls;
using SweetSaber.ViewModels;
using System;
using Avalonia.Input;
using SweetSaber.BeatMods.Models;
using SweetSaber.Models;

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
                vm.LoadData(this, e);
            }
        }

        private void ModActionPic_OnPointerPressed(object? sender, PointerPressedEventArgs e)
        {
            try
            {
                var listBoxItem = (ListBoxItem)((Control?)sender)?.Parent?.Parent!;
                var mod = (SweetMod?)listBoxItem.DataContext;

                if (DataContext is MainWindowViewModel vm)
                {
                    vm.ApplyModAction(mod);
                }
            }
            catch
            {

            }
        }

        private void ModExpandPic_OnPointerPressed(object? sender, PointerPressedEventArgs e)
        {
            try
            {
                var listBoxItem = (ListBoxItem)((Control?)sender)?.Parent?.Parent!;
                var mod = (SweetMod?)listBoxItem.DataContext;

                if (DataContext is MainWindowViewModel vm)
                {
                    vm.ExpandMod(mod);
                }
            }
            catch
            {

            }
        }
    }
}