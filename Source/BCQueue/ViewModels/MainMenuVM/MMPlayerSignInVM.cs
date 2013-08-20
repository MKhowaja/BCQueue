using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows;
using System.Windows.Controls;
using BCQueue.Resources;

namespace BCQueue.ViewModels.MainMenuVM
{
    public class MMPlayerSignInVM:ViewModelBase
    {
        public MMPlayerSignInVM()
        {
        }
        //A parameter of type button is passed through a Click Event in code-behind that calls this method
        public static void SignInOutExecute(Button sender)
        {
            Member m = ((Button)sender).Tag as Member;
            //Changes visual display, sets the model's isOnline property correspondingly, then adds the Member to 
            //an Observable Collection of Online Members
            if (m.isOnline == false)
            {
                ((Button)sender).SetResourceReference(Button.BackgroundProperty, "online");
                m.isOnline = true;
                (App.Current.Resources["Locator"] as BCQueue.ViewModels.ViewModelLocator).Main.OnlinePool.Add(m);
            }
            else
            {
                ((Button)sender).SetResourceReference(Button.BackgroundProperty, "offline");
                (App.Current.Resources["Locator"] as BCQueue.ViewModels.ViewModelLocator).Main.OnlinePool.Remove(m);
                m.isOnline = false;
            }
            //Uses an extension method Sort to sort the ObservableCollection by name and online status (online members preceding, and alphabetical order)
            (App.Current.Resources["Locator"] as BCQueue.ViewModels.ViewModelLocator).Main.MyProfile.Members.Sort((x, y) => x.FullName.CompareTo(y.FullName));
            (App.Current.Resources["Locator"] as BCQueue.ViewModels.ViewModelLocator).Main.MyProfile.Members.Sort((y, x) => x.isOnline.CompareTo(y.isOnline));
        }
    }
}
