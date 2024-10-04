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

namespace Flarum.Uwp.ViewModels
{
    public partial class ShellViewModel : ObservableRecipient
    { 
        private readonly FlarumProvider flarumProvider;

        [ObservableProperty] private FlarumForum _currentForum;

        public ShellViewModel(FlarumProvider flarumProvider)
        {
            this.flarumProvider = flarumProvider;
        }

        public async void GetData()
        {
            flarumProvider.Option.Url = "https://community.wvbtech.com";
            _currentForum = await flarumProvider.GetFlarumForumAsync(); 
        }
    }
}
