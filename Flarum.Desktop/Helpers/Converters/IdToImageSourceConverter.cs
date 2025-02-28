using AsyncAwaitBestPractices;
using Flarum.Provider;
using Flarum.Provider.Models;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Media.Imaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinUICommunity;

namespace Flarum.Desktop.Helpers.Converters
{
    public class IdToImageSourceConverter : IValueConverter
    {
        private FlarumUser user = new FlarumUser();

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var ret = GetUserAsync(int.Parse((string)value)).Result;
            return new BitmapImage(new Uri(ret.AvatarUrl));
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }

        private async Task<FlarumUser> GetUserAsync(int id)
        {
            return await Locator.Instance.GetService<FlarumProvider>()
                .GetFlarumUserByIdAsync(id);
            
        }
    }
}
