using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace BCQueue.ViewModels
{
    public class StartViewModel : ViewModelBase
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

            //Temporary for testing purposes
            (App.Current.Resources["Locator"] as ViewModelLocator).Main.MyProfile.ClubName = "TFSS Club";
            (App.Current.Resources["Locator"] as ViewModelLocator).Main.MyProfile.NumRows = 2;
            (App.Current.Resources["Locator"] as ViewModelLocator).Main.MyProfile.NumColumns = 3;
            (App.Current.Resources["Locator"] as ViewModelLocator).Main.MyProfile.TimerValue = 20;
            for (int i = 0; i < 6; i++)
                (App.Current.Resources["Locator"] as ViewModelLocator).Main.MyProfile.Courts.Add(new Court());
            (App.Current.Resources["Locator"] as ViewModelLocator).Main.MyProfile.Members.Add(new Member());
            (App.Current.Resources["Locator"] as ViewModelLocator).Main.MyProfile.Members[0].FirstName = "Clement";
            (App.Current.Resources["Locator"] as ViewModelLocator).Main.MyProfile.Members[0].LastName = "Hoang";
            (App.Current.Resources["Locator"] as ViewModelLocator).Main.MyProfile.Members.Add(new Member());
            (App.Current.Resources["Locator"] as ViewModelLocator).Main.MyProfile.Members[1].FirstName = "Mustaqeem";
            (App.Current.Resources["Locator"] as ViewModelLocator).Main.MyProfile.Members[1].LastName = "Khowaja";
            (App.Current.Resources["Locator"] as ViewModelLocator).Main.MyProfile.Members[1].AboutMe = "Hi, I love FF6.";
            (App.Current.Resources["Locator"] as ViewModelLocator).Main.MyProfile.Members.Add(new Member());
            (App.Current.Resources["Locator"] as ViewModelLocator).Main.MyProfile.Members[2].FirstName = "Joshua";
            (App.Current.Resources["Locator"] as ViewModelLocator).Main.MyProfile.Members[2].LastName = "Fontana";
            
            
        }

    }
}
