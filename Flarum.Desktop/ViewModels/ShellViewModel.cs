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
using Flarum.Desktop.Contracts.ViewModels;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media.Imaging;

namespace Flarum.ViewModels
{
    public partial class ShellViewModel : ObservableRecipient, IViewModel
    { 
        private readonly FlarumProvider _flarumProvider;

        [ObservableProperty] private FlarumForum _currentForum;
        [ObservableProperty] private string _title;
        [ObservableProperty] private string _iconUrl;
        [ObservableProperty] private string _userName;
        [ObservableProperty] private IconElement _userIcon;

        public ShellViewModel(FlarumProvider flarumProvider)
        {
            _flarumProvider = flarumProvider;
        }

        public async Task GetDataAsync()
        {
            CurrentForum = App.CurrentForum;
            IconUrl = CurrentForum.FaviconUrl ?? "ms-appx:///Assets/StoreLogo.png";
            Title = CurrentForum.Title ?? Package.Current.DisplayName;

            if (_flarumProvider.CurrentUser is not null)
            {
                UserName = _flarumProvider.CurrentUser.DisplayName;
            }
            else
                UserName = "未登录";

            if (_flarumProvider.CurrentUser is not null)
            {
                var pic = new BitmapImage(new Uri(_flarumProvider.CurrentUser.AvatarUrl ?? ""));
                UserIcon = new ImageIcon() { Source = pic };
            }
            else
                UserIcon = new FontIcon { FontFamily = new Microsoft.UI.Xaml.Media.FontFamily("Segoe Fluent Icons"), Glyph = "\uE8FA" };
        }
    }
}
