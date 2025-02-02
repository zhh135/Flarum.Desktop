using Microsoft.UI.Xaml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flarum.Desktop.Contracts.Services
{
    public interface IShellService
    {

        XamlRoot GetCurrentXamlRoot();

        void RegisterXamlRoot(XamlRoot xamlRoot);

        void UnregisterXamlRoot();
    }
}
