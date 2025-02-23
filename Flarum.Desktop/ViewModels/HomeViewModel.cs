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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flarum.ViewModels
{
    public partial class HomeViewModel : ObservableRecipient, IViewModel
    {
        private readonly FlarumProvider _flarumProvider;

        [ObservableProperty] private ObservableCollection<FlarumDiscussion> _discussions;
        [ObservableProperty] private ObservableCollection<FlarumUser> _users; 
        [ObservableProperty] private FlarumForum _forum;
        [ObservableProperty] private int _pageCounter;

        public HomeViewModel(FlarumProvider flarumProvider)
        {
            _flarumProvider = flarumProvider;

            PageCounter = 0;
            Discussions = new ();
        }

        public async Task GetDataAsync()
        {
            Forum = App.CurrentForum;

            var disc = await _flarumProvider.GetAllFlarumDiscussionsAsync(0);
            
            foreach (FlarumDiscussion ndisc in disc)
            {
                Discussions.Add(ndisc);
            }
        }

        [RelayCommand]
        private async Task GetNewDataAsync()
        {
            PageCounter += 1;

            var newDiscussions = await _flarumProvider.GetAllFlarumDiscussionsAsync(PageCounter);

            foreach (FlarumDiscussion newDiscussion in newDiscussions)
            {
                Discussions.Add(newDiscussion);
            }
        }
    }
}
