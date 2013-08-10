using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using BCQueue.Resources;

namespace BCQueue.Views.MainMenuViews
{
    /// <summary>
    /// Interaction logic for MMPlayerSignInView.xaml
    /// </summary>
    public partial class MMPlayerSignInView : UserControl
    {
        public MMPlayerSignInView()
        {
            InitializeComponent();
            if ((App.Current.Resources["Locator"] as BCQueue.ViewModels.ViewModelLocator).Main.MyProfile.Members != null)
                MembersSignInList.DataContext = (App.Current.Resources["Locator"] as BCQueue.ViewModels.ViewModelLocator).Main.MyProfile.Members;
        }

        private void MemberClicked(object sender, EventArgs e)
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

        private void Button_Loaded(object sender, EventArgs e)
        {
            Member m = ((Button)sender).Tag as Member;
            if (m.isOnline == false)
            {
                ((Button)sender).SetResourceReference(Button.BackgroundProperty, "offline");
            }
            else
            {
                ((Button)sender).SetResourceReference(Button.BackgroundProperty, "online");
            }
        }
    }
}
