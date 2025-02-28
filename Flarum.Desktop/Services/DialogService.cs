using Flarum.Desktop.Contracts.Services;
using Flarum.Desktop.Contracts.ViewModels;
using Flarum.Desktop.Dialogs;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flarum.Desktop.Services
{
    public class DialogService : IDialogService
    {
        private readonly Dictionary<string, Type> _dialogs = new();

        public DialogService()
        {
            Configure<ErrorDialog>();
            Configure<SignInDialog>();
        }

        public ContentDialog GetDialog(string key)
        {
            Type? pageType;
            lock (_dialogs)
            {
                if (!_dialogs.TryGetValue(key, out pageType))
                {
                    throw new ArgumentException($"Page not found: {key}. Did you forget to call PageService.Configure?");
                }
            }

            return (ContentDialog) Activator.CreateInstance(pageType);
        }

        private void Configure<V>()
            where V : class
        {
            lock (_dialogs)
            {
                var t = typeof(V);
                var key = t.Name;
                if (_dialogs.ContainsKey(key))
                {
                    throw new ArgumentException($"The key {key} is already configured in PageService");
                }

                var type = typeof(V);
                if (_dialogs.ContainsValue(type))
                {
                    throw new ArgumentException($"This type is already configured with key {_dialogs.First(p => p.Value == type).Key}");
                }

                _dialogs.Add(key, type);
            }
        }
    }
}
