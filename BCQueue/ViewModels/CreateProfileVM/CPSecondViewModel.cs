using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace BCQueue.ViewModels.CreateProfileVM
{
    public class CPSecondViewModel : ViewModelBase
    {
        public ICommand CPNextPageCommand { get; private set; }
        public ICommand CPPreviousPageCommand { get; private set; }

        private static void ExecuteCPNextPageCommand()
        {
            (App.Current.Resources["CPLocator"] as CPViewModelLocator).MainView.CurrentCPViewModel = CPBaseViewModel._cPThirdViewModel;
        }

        private static void ExecuteCPPreviousPageCommand()
        {
            (App.Current.Resources["CPLocator"] as CPViewModelLocator).MainView.CurrentCPViewModel = CPBaseViewModel._cPFirstViewModel;
        }
        public CPSecondViewModel()
        {
            CPNextPageCommand = new RelayCommand(() => ExecuteCPNextPageCommand());
            CPPreviousPageCommand = new RelayCommand(() => ExecuteCPPreviousPageCommand());
        }
    }
}
