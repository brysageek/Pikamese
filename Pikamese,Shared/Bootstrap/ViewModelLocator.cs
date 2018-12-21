using GalaSoft.MvvmLight.Ioc;
using Pikamese.ViewModels;

namespace Pikamese.Bootstrap
{
    public class ViewModelLocator
    {
        public MainViewModel MainViewModel => SimpleIoc.Default.GetInstance<MainViewModel>();

        public ViewModelLocator()
        {
            SimpleIoc.Default.Register<MainViewModel>();
        }
    }
}
