using System;
using GalaSoft.MvvmLight.Views;
using Xamarin.Forms;

namespace Pikamese.Services
{
    public interface IExtendedNavigationService : INavigationService
    {
        void RegisterView(string pageKey, Type pageType);
        void RegisterView<T>();
    }
}
