using GalaSoft.MvvmLight.Ioc;
using Pikamese.Services;
using Pikamese.ViewModels;

namespace Pikamese.Bootstrap
{
    public class ViewModelLocator
    {
        public MainViewModel MainViewModel => SimpleIoc.Default.GetInstance<MainViewModel>();
        public ConnectionsViewModel ConnectionsViewModel => SimpleIoc.Default.GetInstance<ConnectionsViewModel>();
        public SettingsViewModel SettingsViewModel => SimpleIoc.Default.GetInstance<SettingsViewModel>();

        public ViewModelLocator()
        {
            SimpleIoc.Default.Register<IConnectionService>(()=> new ConnectionService());

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<ConnectionsViewModel>();
            SimpleIoc.Default.Register<SettingsViewModel>();
        }
    }
}
