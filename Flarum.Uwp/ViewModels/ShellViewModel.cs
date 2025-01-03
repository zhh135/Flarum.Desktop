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
using Microsoft.UI.Xaml.Media;

namespace Flarum.Uwp.ViewModels
{
    public partial class ShellViewModel : ObservableRecipient
    { 
        private readonly FlarumProvider flarumProvider;

        [ObservableProperty] private FlarumForum _currentForum;
        [ObservableProperty] private string _title;
        [ObservableProperty] private string _iconUrl;

        public ShellViewModel()
        {
            this.flarumProvider = Locator.Instance.GetService<FlarumProvider>();
        }

        public async Task GetDataAsync()
        {
            CurrentForum = App.CurrentForum;

            Title = CurrentForum.Title ?? Package.Current.DisplayName;
            IconUrl = CurrentForum.FaviconUrl ?? "ms-appx:///Assets/StoreLogo.png";
            
        }
    }
}
