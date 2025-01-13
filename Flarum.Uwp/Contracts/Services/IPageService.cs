using System;

namespace Flarum.Contracts.Services;

public interface IPageService
{
    Type GetPageType(string key);
}
