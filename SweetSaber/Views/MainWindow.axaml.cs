using Avalonia.Controls;
using SweetSaber.Common;

namespace SweetSaber.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var location = BeatSaberFinder.TryFind();
        }
    }
}