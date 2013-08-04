using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace BCQueue.ViewModels
{
    public class MainViewModel: ViewModelBase
    {
        private ViewModelBase _currentViewModel;

        #region Static Instances of ViewModels

        //Static Instances of ViewModels in CreateProfileVM 
        readonly static CreateProfileVM.CPFirstViewModel _cPFirstViewModel=new CreateProfileVM.CPFirstViewModel();
        readonly static CreateProfileVM.CPSecondViewModel _cPSecondViewModel=new CreateProfileVM.CPSecondViewModel();
        readonly static CreateProfileVM.CPThirdViewModel _cpThirdViewModel = new CreateProfileVM.CPThirdViewModel();

        //Static Instances in the root ViewModels folder
        readonly static HomeViewModel _homeViewModel = new HomeViewModel();
        readonly static StartViewModel _startViewModel = new StartViewModel();

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
        /*
        public ICommand HomeViewCommand { get; private set; }
        public ICommand CPFirstViewCommand { get; private set; } //only make available during zeroview/2nd view
        public ICommand CPSecondViewCommand { get; private set; }
        public ICommand CPThirdViewCommand { get; private set; }
         * Don't think any are necessary in MainViewModel
        */

        public MainViewModel()
        {
            CurrentViewModel = MainViewModel._startViewModel;
        }
    }
}
