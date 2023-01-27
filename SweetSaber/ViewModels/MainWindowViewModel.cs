using System;
using System.Collections.Generic;
using SweetSaber.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using ReactiveUI;
using SweetSaber.BeatMods;
using Avalonia;
using System.Reactive;
using DynamicData;

namespace SweetSaber.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public static List<VerticalTab> Tabs => new()
        {
            new VerticalTab { Name = "Start" },
            new VerticalTab { Name = "Mods" },
            new VerticalTab { Name = "Settings" },
            new VerticalTab { Name = "About" },
        };

        private BeatModsAPI _modsAPI;
        private ObservableCollection<string> _versions;
        private bool _filterPopupVisible = true;
        private int _tabIndex = 1;
        private string? _status;
        private string? _searchQuery;


        public string ApplicationVersion => App.VerString;
        public ObservableCollection<string> Versions
        {
            get => _versions;
            set => this.RaiseAndSetIfChanged(ref _versions, value);
        }
        public bool FilterPopupVisible
        {
            get => _filterPopupVisible;
            set => this.RaiseAndSetIfChanged(ref _filterPopupVisible, value);
        }

        public int TabIndex
        {
            get => _tabIndex;
            set => this.RaiseAndSetIfChanged(ref _tabIndex, value);
        }

        public string? Status
        {
            get => _status;
            set => this.RaiseAndSetIfChanged(ref _status, value);
        }
        
        public string? SearchQuery
        {
            get => _searchQuery;
            set => this.RaiseAndSetIfChanged(ref _searchQuery, value);
        }

        

        public MainWindowViewModel()
        {
            _modsAPI = new BeatModsAPI();
            _versions = new ObservableCollection<string>();
        }


        public async void WindowOpened(object? s, EventArgs e)
        {
            Status = "Loading versions...";

            var versions = await _modsAPI.GetVersions();
            Versions.Clear();
            Versions.AddRange(versions ?? new List<string>());
            //this.RaisePropertyChanged(nameof(Versions));

            Status = "";
        }

        public void TogglePopup()
        {
            FilterPopupVisible = !FilterPopupVisible;
        }
    }
}
