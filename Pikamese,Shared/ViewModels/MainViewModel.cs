using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;

namespace Pikamese.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private int _marVar;

        public int MyVar
        {
            get => _marVar;
            set
            {
                _marVar = value;
                RaisePropertyChanged(() => MyVar);
            }
        }

        private ObservableCollection<int> _myList;

        public ObservableCollection<int> MyList
        {
            get => _myList;
            set
            {
                _myList = value;
                RaisePropertyChanged(()=>MyList);
            }
        }

        public MainViewModel()
        {
            MyVar = 1;
            MyList = new ObservableCollection<int>()
            {
                1,2,3,78,22
            };
        }
    }
}
