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

namespace Flarum.Uwp.ViewModels
{
    public partial class ShellViewModel : ObservableRecipient
    { 
        private readonly FlarumProvider flarumProvider;

        [ObservableProperty] private FlarumForum _currentForum;
        [ObservableProperty] private string _title;
        [ObservableProperty] private string _iconUrl;

        public ShellViewModel(FlarumProvider flarumProvider)
        {
            this.flarumProvider = flarumProvider;
        }

        public async void GetData()
        {
            flarumProvider.Option.Url = "https://community.wvbtech.com";
            CurrentForum = await flarumProvider.GetFlarumForumAsync();

            Title = CurrentForum.Title;
            IconUrl = CurrentForum.FaviconUrl;
            
        }
    }
}
