using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Xamarin.Forms;

namespace Pikamese.Services
{
    class NavigationService : IExtendedNavigationService
    {
        private readonly Dictionary<string, Type> _appPages = new Dictionary<string, Type>();
        private NavigationPage _navigationPage;

        public string CurrentPageKey
        {
            get
            {
                lock (_appPages)
                {
                    if (_navigationPage.CurrentPage == null)
                    {
                        return null;
                    }

                    var pageType = _navigationPage.CurrentPage.GetType();

                    return _appPages.ContainsValue(pageType)
                        ? _appPages.First(p => p.Value == pageType).Key
                        : null;
                }
            }
        }

        public void Initialize(NavigationPage navigationPage)
        {
            _navigationPage = navigationPage;
        }

        public void GoBack()
        {
            _navigationPage.PopAsync();
        }

        public void NavigateTo(string pageKey)
        {
            NavigateTo(pageKey, null);
        }

        public void NavigateTo(string pageKey, object parameter)
        {
            lock (_appPages)
            {
                var foundPage = _appPages[pageKey];
                if (_appPages.ContainsKey(pageKey))
                {
                    ConstructorInfo ctorInfo;
                    object[] parameters;
                    if (parameter == null)
                    {
                        ctorInfo = foundPage.GetTypeInfo()
                            .DeclaredConstructors
                            .FirstOrDefault(c => !c.GetParameters().Any());
                        parameters = new object[] {};
                    }
                    else
                    {
                        ctorInfo = foundPage.GetTypeInfo()
                            .DeclaredConstructors
                            .FirstOrDefault(c =>
                            {
                                var p = c.GetParameters();
                                return p.Length == 1 && p[0].ParameterType == parameter.GetType();
                            });
                        parameters = new object[] { };
                    }

                    if (ctorInfo == null)
                    {
                        throw new Exception($"No Suitable constructor found for page {pageKey}.");
                    }

                    var page = ctorInfo.Invoke(parameters) as ContentPage;
                    _navigationPage.PushAsync(page);
                }
                else
                {
                    throw new ArgumentException($"no such page: {pageKey}.  Check to make sure the view has been registered");
                }
            }
        }

        public void RegisterView(string pageKey, Type pageType)
        {
            lock (_appPages)
            {
                if (_appPages.ContainsKey(pageKey))
                {
                    _appPages[pageKey] = pageType;
                }
                else
                {
                    _appPages.Add(pageKey, pageType);
                }
            }
        }

        public void RegisterView<T>()
        {
            RegisterView(typeof(T).Name, typeof(T));
        }
    }
}
