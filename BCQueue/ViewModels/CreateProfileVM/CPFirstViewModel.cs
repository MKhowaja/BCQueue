using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;


namespace BCQueue.ViewModels.CreateProfileVM
{
    public class CPFirstViewModel : ViewModelBase
    {
        public ICommand CPNextPageCommand { get; private set; }

        private static void ExecuteCPNextPageCommand()
        {
            (App.Current.Resources["CPLocator"] as CPViewModelLocator).MainView.CurrentCPViewModel = CPBaseViewModel._cPSecondViewModel;
        }
        public CPFirstViewModel()
        {
            CPNextPageCommand = new RelayCommand(() => ExecuteCPNextPageCommand());
        }
    }
}
