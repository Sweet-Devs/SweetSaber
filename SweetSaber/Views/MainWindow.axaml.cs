using Avalonia.Controls;
using SweetSaber.ViewModels;
using System;
using System.Linq;
using Avalonia.Input;
using SweetSaber.BeatMods.Models;
using SweetSaber.Models;
using System.Reflection;
using Avalonia.Interactivity;

namespace SweetSaber.Views
{
    public partial class MainWindow : Window
    {
        TextBlock _DropState;
        Border _DropBorder;
        private const string CustomFormat = "application/xxx-avalonia-controlcatalog-custom";

        public MainWindow()
        {
            InitializeComponent();
            _DropState = this.Get<TextBlock>("DropState");
            _DropBorder = this.Get<Border>("DropBorder");

            _DropBorder.AddHandler(DragDrop.DropEvent, Drop);
            _DropBorder.AddHandler(DragDrop.DragEnterEvent, DraggingEnter);
            _DropBorder.AddHandler(DragDrop.DragLeaveEvent, DraggingLeave);
        }

        private void DraggingLeave(object? sender, RoutedEventArgs e)
        {
            _DropBorder.Classes.Remove("Dragging");
        }

        private void DraggingEnter(object? sender, DragEventArgs e)
        {
            _DropBorder.Classes.Add("Dragging");
        }

        private void Drop(object? sender, DragEventArgs e)
        {
            if (DataContext is not MainWindowViewModel vm) return;
            if (!e.Data.Contains(DataFormats.FileNames)) return;

            var fileName = e.Data.GetFileNames()?.First();

            vm.Status = $"Loading mod from: {fileName}";
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