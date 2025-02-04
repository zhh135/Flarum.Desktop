using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Flarum.Api.ApiContracts;
using Flarum.Api.Bases;
using Flarum.Desktop.Contracts.ViewModels;
using Flarum.Provider;
using Flarum.Provider.Mappers;
using Flarum.Provider.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flarum.ViewModels
{
    public partial class HomeViewModel : ObservableRecipient, IViewModel
    {
        private readonly FlarumProvider _flarumProvider;

        [ObservableProperty] private List<FlarumDiscussion> _discussions;
        [ObservableProperty] private FlarumForum _forum;
        [ObservableProperty] private int _pageCounter;

        public HomeViewModel(FlarumProvider flarumProvider)
        {
            _flarumProvider = flarumProvider;
        }

        public async Task GetDataAsync()
        {
            Forum = App.CurrentForum;

            PageCounter = 0;
            Discussions = await _flarumProvider.GetAllFlarumDiscussionsAsync(PageCounter);

        }

        [RelayCommand]
        public async Task GetDiscussionAsync()
        {
            PageCounter += 1;
            var newDiscussions = await _flarumProvider.GetAllFlarumDiscussionsAsync(PageCounter);
        }
    }
}
