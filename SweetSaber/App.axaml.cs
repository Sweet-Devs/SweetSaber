using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Avalonia.Platform;
using SweetSaber.ViewModels;
using SweetSaber.Views;

namespace SweetSaber
{
    public partial class App : Application
    {
        public static int MajorVer = 0;
        public static int MinorVer = 0;
        public static int BuildVer = 1;

        public static string VerString => $"{MajorVer}.{MinorVer:00}.{BuildVer:0000}";
        public static IAssetLoader? AssetLoader => AvaloniaLocator.Current.GetService<IAssetLoader>();

        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new MainWindow
                {
                    DataContext = new MainWindowViewModel(),
                };
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}