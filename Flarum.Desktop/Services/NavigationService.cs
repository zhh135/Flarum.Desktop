using Flarum.Contracts.Services;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media.Animation;
using Microsoft.UI.Xaml.Navigation;
using System;
using Microsoft.UI.Xaml;
using System.Diagnostics;

namespace Flarum.Services
{
    public class NavigationService : INavigationService
    {
        private readonly IPageService _pageService;
        private object? _lastParameterUsed;
        private Frame? _frame;

        public event NavigatedEventHandler? Navigated;

        public bool CanGoBack => _frame != null && _frame.CanGoBack;


        public NavigationService(IPageService pageService)
        {
            _pageService = pageService;
        }

        public void UnregisterFrameEvents()
        {
            if (_frame != null)
            {
                _frame.Navigated -= OnNavigated;
            }
        }

        public bool GoBack()
        {
            if (CanGoBack)
            {             
                _frame.GoBack();
                return true;
            }

            return false;
        }

        private void OnNavigated(object sender, NavigationEventArgs e)
        {
            if (sender is Frame frame)
            {
                var clearNavigation = (bool)frame.Tag;
                if (clearNavigation)
                {
                    frame.BackStack.Clear();
                }

                Navigated?.Invoke(sender, e);
            }
        }

        public bool NavigateTo(string pageKey, object parameter = null, bool clearNavigation = false)
        {
            var pageType = _pageService.GetPageType(pageKey);

            var frame = _frame;
            

            if (frame != null && (frame.Content?.GetType() != pageType || (parameter != null && !parameter.Equals(_lastParameterUsed))))
            {
                frame.Tag = clearNavigation;
                var navigated = frame.Navigate(pageType, parameter);
                if (navigated)
                {
                    _lastParameterUsed = parameter;

                }
                return navigated;
            }

            return false;
        }

        public void RegisterFrameEvents(Frame frame)
        {
            _frame = frame;

            if (_frame != null)
            {
                _frame.Navigated += OnNavigated;
            }
            else
            {
                Debug.WriteLine("The content frame is null");
            }
        }

    }
}
