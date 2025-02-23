using CommunityToolkit.Mvvm.ComponentModel;
using Flarum.Desktop.Contracts.ViewModels;
using Flarum.Provider;
using Flarum.Provider.Models;
using System;
using System.Threading.Tasks;

namespace Flarum.Desktop.ViewModels
{
    public partial class DiscussionViewModel : ObservableRecipient, IViewModel
    {
        private readonly FlarumProvider _provider;

        [ObservableProperty] private FlarumDiscussion _currentDiscussion;
        [ObservableProperty] private string _title;
        [ObservableProperty] private DateTime _createdAt;
        [ObservableProperty] private FlarumUser _creator;
        [ObservableProperty] private int _id;

        public DiscussionViewModel(FlarumProvider provider)
        {
            _provider = provider;
        }

        public async Task GetDataAsync()
        {
            CurrentDiscussion = await _provider.GetFlarumDiscussionByIdAsync(Id);
            Creator = await _provider.GetFlarumUserByIdAsync(int.Parse(CurrentDiscussion.User.Data.Id));

            Title = CurrentDiscussion.Title;
            CreatedAt = CurrentDiscussion.CreatedAt;
        }
    }
}
