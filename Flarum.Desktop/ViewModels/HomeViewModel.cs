using CommunityToolkit.Mvvm.ComponentModel;
using Flarum.Api.ApiContracts;
using Flarum.Api.Bases;
using Flarum.Desktop.Contracts.ViewModels;
using Flarum.Provider;
using Flarum.Provider.Mappers;
using Flarum.Provider.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flarum.ViewModels
{
    public partial class HomeViewModel : ObservableRecipient, IViewModel
    {
        private readonly FlarumProvider _flarumProvider;

        [ObservableProperty] private ObservableCollection<FlarumDiscussion> _discussions;
        [ObservableProperty] private FlarumForum _forum;

        public HomeViewModel(FlarumProvider flarumProvider)
        {
            _flarumProvider = flarumProvider;
        }

        public async Task GetDataAsync()
        {
            Forum = App.CurrentForum;

            var discussions = _flarumProvider.GetAllFlarumDiscussionsAsync(0);
        }
    }
}
