using Avalonia.Media.Imaging;
using ReactiveUI;
using SweetSaber.BeatMods.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetSaber.Models
{
    public class SweetMod : ReactiveObject
    {
        private bool _isInstalled;
        private bool _updateAvailable;
        private bool _updating;
        private bool _isExpanded;
        private string? _currentVersion;
        private string? _currentGameVersion;
        private string? _installedPath;
        private BSMod? _mod;

        public bool IsInstalled
        {
            get => _isInstalled;
            set
            {
                this.RaiseAndSetIfChanged(ref _isInstalled, value);
                this.RaisePropertyChanged(nameof(StatusImage));
            }
        }

        public bool UpdateAvailable
        {
            get => _updateAvailable;
            set
            {
                this.RaiseAndSetIfChanged(ref _updateAvailable, value);
                this.RaisePropertyChanged(nameof(StatusImage));

            }
        }

        public bool Updating
        {
            get => _updating;
            set
            {
                this.RaiseAndSetIfChanged(ref _updating, value);
                this.RaisePropertyChanged(nameof(StatusImage));
            }
        }

        public bool IsExpanded
        {
            get => _isExpanded;
            set => this.RaiseAndSetIfChanged(ref _isExpanded, value);
        }

        public Bitmap StatusImage
        {
            get
            {
                if (UpdateAvailable || Updating)
                    return new Bitmap(App.AssetLoader!.Open(new Uri("avares://SweetSaber/Assets/updating.png")));
                if (IsInstalled)
                    return new Bitmap(App.AssetLoader!.Open(new Uri("avares://SweetSaber/Assets/trash.png")));
                else
                    return new Bitmap(App.AssetLoader!.Open(new Uri("avares://SweetSaber/Assets/download.png")));
            }
        }

        public string? CurrentVersion
        {
            get => _currentVersion;
            set => this.RaiseAndSetIfChanged(ref _currentVersion, value);
        }

        public string? CurrentGameVersion
        {
            get => _currentGameVersion;
            set => this.RaiseAndSetIfChanged(ref _currentGameVersion, value);
        }

        public string? InstalledPath
        {
            get => _installedPath;
            set => this.RaiseAndSetIfChanged(ref _installedPath, value);
        }

        public BSMod? Mod
        {
            get => _mod;
            set => this.RaiseAndSetIfChanged(ref _mod, value);
        }

    }
}
