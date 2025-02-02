using CommunityToolkit.Mvvm.ComponentModel;
using Flarum.Desktop.Contracts.ViewModels;
using Flarum.Provider;
using Flarum.Provider.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Flarum.ViewModels
{
    public partial class HomeViewModel : ObservableRecipient, IViewModel
    {
        private readonly FlarumProvider _flarumProvider;

        [ObservableProperty] private List<FlarumDiscussion> _discussions;
        [ObservableProperty] private FlarumForum _forum;
        [ObservableProperty] private int _pageCount;

        public HomeViewModel(FlarumProvider flarumProvider)
        {
            _flarumProvider = flarumProvider;

            // Initialize Counters.
            PageCount = 0;
        }

        public async Task GetDataAsync()
        {
            Forum = App.CurrentForum;

            Discussions = await Locator.Instance.GetService<FlarumProvider>().
                GetAllFlarumDiscussionsAsync(PageCount);
            PageCount += 1;
        }
    }
}
