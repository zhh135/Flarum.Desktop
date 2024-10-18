using CommunityToolkit.Mvvm.ComponentModel;
using Flarum.Provider;
using Flarum.Provider.Models;
using Flarum.Api.ApiContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flarum.Api.Bases;
using System.Diagnostics;
using Windows.ApplicationModel;

namespace Flarum.Uwp.ViewModels
{
    public partial class ShellViewModel : ObservableRecipient
    { 
        private readonly FlarumProvider flarumProvider;

        [ObservableProperty] private FlarumForum _currentForum;
        [ObservableProperty] private string _title;
        [ObservableProperty] private Uri _iconUrl;

        public ShellViewModel(FlarumProvider flarumProvider)
        {
            this.flarumProvider = flarumProvider;
        }

        public async Task GetDataAsync()
        {
            flarumProvider.Option.Url = "https://discuss.flarum.org.cn";
            CurrentForum = await flarumProvider.GetFlarumForumAsync();

            if (CurrentForum.Title != null) Title = CurrentForum.Title;
            else Title = Package.Current.DisplayName;

            if (CurrentForum.FaviconUrl != null) IconUrl = new Uri(CurrentForum.FaviconUrl);
            else IconUrl = new Uri("ms-appx:///Assets/StoreLogo.png");
        }
    }
}
