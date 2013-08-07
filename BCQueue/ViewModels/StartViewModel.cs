using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace BCQueue.ViewModels
{
    public class StartViewModel: ViewModelBase
    {
        public StartViewModel()
        {
            ShowLoadClubInterface = new RelayCommand(() => LoadClubInterfaceExecute());
            ShowCreateClubInterface = new RelayCommand(() => CreateClubInterfaceExecute());

        }

        public ICommand ShowCreateClubInterface { get; private set; }
        public ICommand ShowLoadClubInterface { get; private set; }

        private static void CreateClubInterfaceExecute()
        {
            (App.Current.Resources["Locator"] as ViewModelLocator).Main.CurrentViewModel = MainViewModel._cPBaseViewModel;
        }

        private static void LoadClubInterfaceExecute()
        {
            (App.Current.Resources["Locator"] as ViewModelLocator).Main.CurrentViewModel = MainViewModel._homeViewModel;
        }
    }
}
