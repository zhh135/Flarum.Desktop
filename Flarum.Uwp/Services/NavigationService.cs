using Flarum.Uwp.Contracts.Services;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;
using System;
using Windows.UI.Xaml;

namespace Flarum.Uwp.Services
{
    public class NavigationService : INavigationService
    {
        private readonly IPageService _pageService;
        private object? _lastParameterUsed;
        private Frame? _frame;

        public event NavigatedEventHandler? Navigated;

        public Frame? Frame
        {
            get
            {
                return _frame;
            }
        }

        
        public bool CanGoBack => Frame != null && Frame.CanGoBack;


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

            var frame = Frame;
            

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
        }

    }
}
