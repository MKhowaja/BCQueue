using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows;
using System.ComponentModel;


namespace BCQueue.ViewModels
{
    public class MainViewModel: ViewModelBase, INotifyPropertyChanged
    {

        private string _homeButtonVisibility;
        public string HomeButtonVisibility { 
            get { return _homeButtonVisibility; } 
            set 
            {
                if (value == "Collapsed" || value == "Hidden" || value == "Visible")
                {
                    _homeButtonVisibility = value;
                    RaisePropertyChanged("HomeButtonVisibility");
                }
            }
        }

        private ViewModelBase _currentViewModel;

        #region Static Instances of ViewModels

        //Static Instance of CPBaseViewModel
        public readonly static CreateProfileVM.CPBaseViewModel _cPBaseViewModel = new CreateProfileVM.CPBaseViewModel();
        
        //Static Instances in the root ViewModels folder
        public readonly static HomeViewModel _homeViewModel = new HomeViewModel();
        public readonly static StartViewModel _startViewModel = new StartViewModel();
      
        //Static Instances in ViewModels/MainMenuVM/
        public readonly static MainMenuVM.MMAboutVM _mMAboutVM = new MainMenuVM.MMAboutVM();
        public readonly static MainMenuVM.MMAddToQueueVM _mMAddToQueueVM = new MainMenuVM.MMAddToQueueVM();
        public readonly static MainMenuVM.MMConfigureClubProfileVM _mMConfigureClubProfileVM = new MainMenuVM.MMConfigureClubProfileVM();
        public readonly static MainMenuVM.MMPlayerSignInVM _mMPlayerSignInVM = new MainMenuVM.MMPlayerSignInVM();
        public readonly static MainMenuVM.MMViewActiveGamesVM _mMViewActiveGamesVM = new MainMenuVM.MMViewActiveGamesVM();
        public readonly static MainMenuVM.MMViewPlayerProfilesVM _mMViewPlayerProfilesVM = new MainMenuVM.MMViewPlayerProfilesVM();

        #endregion 

        public ViewModelBase CurrentViewModel
        {
            get
            {
                return _currentViewModel;
            }
            set
            {
                if (_currentViewModel == value)
                    return;
                _currentViewModel = value;
                RaisePropertyChanged("CurrentViewModel");
            }
        }
        
        public ICommand HomeViewCommand { get; private set; }
        public ICommand MMAboutViewCommand { get; private set; }
        public ICommand MMAddToQueueViewCommand { get; private set; }
        public ICommand MMConfigureCPViewCommand { get; private set; }
        public ICommand MMPlayerSignInViewCommand { get; private set; }
        public ICommand MMViewActiveGamesViewCommand { get; private set; }
        public ICommand MMViewPPViewCommand { get; private set; }
        

        private void ExecuteHomeViewCommand()
        {
            CurrentViewModel = MainViewModel._homeViewModel;
            HomeButtonVisibility = "Collapsed";
        }
        private void ExecuteMMAboutViewCommand()
        {
            CurrentViewModel = MainViewModel._mMAboutVM;
            HomeButtonVisibility = "Visible";
        }
        private void ExecuteMMAddToQueueViewCommand()
        {
            CurrentViewModel = MainViewModel._mMAddToQueueVM;
            HomeButtonVisibility = "Visible";
        }
        private void ExecuteMMConfigureCPViewCommand()
        {
            CurrentViewModel = MainViewModel._mMConfigureClubProfileVM;
            HomeButtonVisibility = "Visible";
        }
        private void ExecuteMMPlayerSignInViewCommand()
        {
            CurrentViewModel = MainViewModel._mMPlayerSignInVM;
            HomeButtonVisibility = "Visible";
        }
        private void ExecuteMMViewActiveGamesViewCommand()
        {
            CurrentViewModel = MainViewModel._mMViewActiveGamesVM;
            HomeButtonVisibility = "Visible";
        }
        private void ExecuteMMViewPPViewCommand()
        {
            CurrentViewModel = MainViewModel._mMViewPlayerProfilesVM;
            HomeButtonVisibility = "Visible";
        }

     

        public MainViewModel()
        {
            CurrentViewModel = MainViewModel._startViewModel;
            HomeButtonVisibility = "Collapsed";

            HomeViewCommand = new RelayCommand(() => ExecuteHomeViewCommand());
            MMAboutViewCommand = new RelayCommand(() => ExecuteMMAboutViewCommand());
            MMAddToQueueViewCommand = new RelayCommand(() => ExecuteMMAddToQueueViewCommand());
            MMConfigureCPViewCommand = new RelayCommand(() => ExecuteMMConfigureCPViewCommand());
            MMPlayerSignInViewCommand = new RelayCommand(() => ExecuteMMPlayerSignInViewCommand());
            MMViewActiveGamesViewCommand = new RelayCommand(() => ExecuteMMViewActiveGamesViewCommand());
            MMViewPPViewCommand = new RelayCommand(() => ExecuteMMViewPPViewCommand());
        }

        

      

    }
}
