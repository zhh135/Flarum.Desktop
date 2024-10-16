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

        public async Task GetDataAsync()
        {
            flarumProvider.Option.Url = "https://community.wvbtech.com";
            CurrentForum = await flarumProvider.GetFlarumForumAsync();

            if (CurrentForum.Title is not null)
            {
                Title = CurrentForum.Title;
                IconUrl = CurrentForum.FaviconUrl;
            }
            else
            {
                Title = "Flarent";
                IconUrl = "";
            }  
        }
    }
}
