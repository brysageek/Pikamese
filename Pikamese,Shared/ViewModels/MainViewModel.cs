using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using Pikamese.Models;
using Pikamese.Services;
using Pikamese.Views;

namespace Pikamese.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IConnectionService _connectionService = SimpleIoc.Default.GetInstance<IConnectionService>();

        private readonly IExtendedNavigationService _navigationService = SimpleIoc.Default.GetInstance<IExtendedNavigationService>();

        private ObservableCollection<Connection> _connections;

        public ObservableCollection<Connection> Connections
        {
            get => _connections;
            set
            {
                _connections = value;
                RaisePropertyChanged(()=>Connections);
            }
        }

        private readonly RelayCommand _navigateConnectionPage;

        public ICommand NavigationConnectionPage => _navigateConnectionPage;

        public MainViewModel()
        {
            GetConnections();
            _navigateConnectionPage = new RelayCommand(() =>
            {
                _navigationService.NavigateTo(nameof(ConnectionPage));
            });
        }

        private async void GetConnections()
        {
            Connections = new ObservableCollection<Connection>(await _connectionService.GetConnections());
        }
    }
}
