using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using Pikamese.Models;
using Pikamese.Services;

namespace Pikamese.ViewModels
{
    public class ConnectionsViewModel : ViewModelBase
    {
        private readonly IConnectionService _connectionService = SimpleIoc.Default.GetInstance<IConnectionService>();
        private Connection _connection;

        public Connection Connection
        {
            get => _connection;
            set
            {
                _connection = value;
                RaisePropertyChanged(()=>Connection);
            }
        }

        private readonly RelayCommand _saveConnectionCommand;
        public ICommand SaveConnectionCommand => _saveConnectionCommand;

        public ConnectionsViewModel()
        {
            _connection  = new Connection();

            _saveConnectionCommand =
                new RelayCommand(() => { _connectionService.SaveConnection(_connection); }, () => true);
        }
    }
}
