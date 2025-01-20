using Flarum.Api.ApiContracts;
using Flarum.Api.Bases;
using Flarum.Api.Models.ResponseModel;
using Flarum.Desktop.Contracts.Services;
using Flarum.Desktop.Dialogs;
using Flarum.Provider;
using Flarum.Provider.Mappers;
using Flarum.Provider.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flarum.Desktop.Services
{
    public class FlarumService : IFlarumService
    {
        private readonly FlarumProvider _flarumProvider;

        public FlarumService(FlarumProvider flarumProvider) 
        {
            _flarumProvider = flarumProvider;
        }

        public async Task<FlarumForum> GetForumInfoAsync()
        {
            var result = await _flarumProvider.RequestAsync<GetForumInfoRequest, GetForumInfoResponse, ErrorResultBase, GetForumInfoActualRequest>(new GetForumInfoApi());
            return ForumDataToFlarumForumMapper.MapToFlarumForum( result.Match(
                        success => success?.Data.flarumForum,
                        error => {
                            var dialog = (ErrorDialog)Locator.Instance.GetService<IDialogService>().GetDialog("ErrorDialog");
                            dialog.ShowDialogWithMeassageAsync(error.Message);
                            return new FlarumForumDto();
                        }));
        }
    }
}
