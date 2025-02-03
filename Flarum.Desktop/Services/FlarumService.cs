using AsyncAwaitBestPractices;
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
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flarum.Desktop.Services
{
    public class FlarumService : IFlarumService
    {
        private readonly FlarumProvider _flarumProvider;
        private readonly IShellService _shellService;

        public FlarumService(FlarumProvider flarumProvider, IShellService shellService) 
        {
            _flarumProvider = flarumProvider;
            _shellService = shellService;
        }

        
    }
}
