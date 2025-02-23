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
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var user = Locator.Instance.GetService<FlarumProvider>()
                .GetFlarumUserByIdAsync(((string)value).ConvertToInt()).Result;
            return new BitmapImage(new Uri(user.AvatarUrl));
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
