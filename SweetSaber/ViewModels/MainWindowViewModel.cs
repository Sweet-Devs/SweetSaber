using System.Collections.Generic;
using SweetSaber.Models;
using System.Collections.ObjectModel;
using ReactiveUI;

namespace SweetSaber.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private int _tabIndex;

        public static List<VerticalTab> Tabs => new()
        {
            new VerticalTab { Name = "start" },
            new VerticalTab { Name = "mods" },
            new VerticalTab { Name = "settings" }
        };

        public int TabIndex
        {
            get => _tabIndex;
            set => this.RaiseAndSetIfChanged(ref _tabIndex, value);
        }
    }
}
