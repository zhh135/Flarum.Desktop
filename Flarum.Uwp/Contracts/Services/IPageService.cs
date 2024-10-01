using System;

namespace Flarum.Uwp.Contracts.Services;

public interface IPageService
{
    Type GetPageType(string key);
}
