using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows;

namespace BCQueue.ViewModels
{
    public class MainViewModel: ViewModelBase
    {
        private ViewModelBase _currentViewModel;

        #region Static Instances of ViewModels

        //Static Instances of CPBaseViewModel
        public readonly static CreateProfileVM.CPBaseViewModel _cPBaseViewModel = new CreateProfileVM.CPBaseViewModel();
        

        //Static Instances in the root ViewModels folder
        public readonly static HomeViewModel _homeViewModel = new HomeViewModel();
        public readonly static StartViewModel _startViewModel = new StartViewModel();

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

        private void ExecuteHomeViewCommand()
        {
            CurrentViewModel = MainViewModel._homeViewModel;
        }
     

        public MainViewModel()
        {
            CurrentViewModel = MainViewModel._startViewModel;
            HomeViewCommand = new RelayCommand(() => ExecuteHomeViewCommand());
        }

    }
}
