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
            if (m.isOnline == false)
            {
                ((Button)sender).SetResourceReference(Button.BackgroundProperty, "online");
                m.isOnline = true;
                //note: adds member to the OnlineMembers collection after isOnline is set to true
                (App.Current.Resources["Locator"] as BCQueue.ViewModels.ViewModelLocator).Main.OnlineMembers.Add(m);
            }
            else
            {
                ((Button)sender).SetResourceReference(Button.BackgroundProperty, "offline");
                //note: removes member from OnlineMembers collection before isOnline is set to false
                (App.Current.Resources["Locator"] as BCQueue.ViewModels.ViewModelLocator).Main.OnlineMembers.Remove(m);
                m.isOnline = false;
                //not sure if this works yet
                //remember to implement a proper notification interface for when properties in indiv. members change
            }
            (App.Current.Resources["Locator"] as BCQueue.ViewModels.ViewModelLocator).Main.MyProfile.Members.Sort((x, y) => x.FullName.CompareTo(y.FullName));
            (App.Current.Resources["Locator"] as BCQueue.ViewModels.ViewModelLocator).Main.MyProfile.Members.Sort((y, x) => x.isOnline.CompareTo(y.isOnline));
        }
    }
}
