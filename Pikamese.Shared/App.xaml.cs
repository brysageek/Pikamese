﻿using GalaSoft.MvvmLight.Ioc;
using Pikamese.Services;
using Pikamese.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Pikamese
{
    public partial class App : Application
    {
        public App()
        {
            var navigationService = new NavigationService();
            SimpleIoc.Default.Register<IExtendedNavigationService>(() => navigationService, true);
            InitializeComponent();

            navigationService.RegisterView<MainPage>();
            navigationService.RegisterView<PublishPage>();
            navigationService.RegisterView<ConnectionPage>();
            navigationService.RegisterView<SubscribePage>();
            navigationService.RegisterView<SettingsPage>();
            var navigationPage = new NavigationPage(new MainPage());
            navigationService.Initialize(navigationPage);

            MainPage = navigationPage;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
