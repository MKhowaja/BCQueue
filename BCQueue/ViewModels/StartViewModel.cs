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
            ShowCreateClubInterface = new RelayCommand(() => CreateClubInterfaceExecute()); //used to have a ()=>true here
            ShowLoadClubInterface = new RelayCommand(() => LoadClubInterfaceExecute());
        }

        public ICommand ShowCreateClubInterface { get; private set; }
        public ICommand ShowLoadClubInterface { get; private set; }

        private static void CreateClubInterfaceExecute()
        {
            //TODO: call method that switches view
        }

        private static void LoadClubInterfaceExecute()
        {
            MessageBox.Show("Browse"); //TODO: Implement stuff
        }
    }
}
