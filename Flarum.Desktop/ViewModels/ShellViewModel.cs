using CommunityToolkit.Mvvm.ComponentModel;
using Flarum.Provider;
using Flarum.Provider.Models;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Flarum.Desktop.Contracts.ViewModels;

namespace Flarum.ViewModels
{
    public partial class ShellViewModel : ObservableRecipient, IViewModel
    { 
        private readonly FlarumProvider flarumProvider;

        [ObservableProperty] private FlarumForum _currentForum;
        [ObservableProperty] private string _title;
        [ObservableProperty] private string _iconUrl;

        public ShellViewModel()
        {
            flarumProvider = Locator.Instance.GetService<FlarumProvider>();
        }

        public async Task GetDataAsync()
        {
            CurrentForum = App.CurrentForum;
            IconUrl = CurrentForum.FaviconUrl ?? "ms-appx:///Assets/StoreLogo.png";
            Title = CurrentForum.Title ?? Package.Current.DisplayName;
            
        }
    }
}
