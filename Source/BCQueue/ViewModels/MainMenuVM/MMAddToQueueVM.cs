using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows;
using System.Collections.ObjectModel;
using DragDrop = GongSolutions.Wpf.DragDrop.DragDrop;
using GongSolutions.Wpf.DragDrop;
using System.Windows.Media;
using System.Windows.Controls;


namespace BCQueue.ViewModels.MainMenuVM
{
    public class MMAddToQueueVM : ViewModelBase, IDropTarget
    {

        public ObservableCollection<ObservableCollection<Member>> QueueList; //for the active games page
        public ObservableCollection<Member> AvailablePool { get; set; }
        public ObservableCollection<Member> Player1 { get; set; }
        public ObservableCollection<Member> Player2 { get; set; }
        public ObservableCollection<Member> Player3 { get; set; }
        public ObservableCollection<Member> Player4 { get; set; }

        public MMAddToQueueVM()
        {
            AvailablePool = new ObservableCollection<Member>();
            AvailablePool.Add(new Member("aniket verma"));
            AvailablePool.Add(new Member("joshua fontana"));
            AvailablePool.Add(new Member("mustaqeem khowajasdfsdaddfa"));
            AvailablePool.Add(new Member("clement hoang"));
            AvailablePool[0].SkillLevel = Member.sl.Intermediate;
            AvailablePool[1].SkillLevel = Member.sl.Beginner;
            AvailablePool[2].SkillLevel = Member.sl.Advanced;
            AvailablePool.Add(new Member("clement dsf"));
            AvailablePool.Add(new Member("clemsdf hoang"));
            AvailablePool.Add(new Member("sdfement hoang"));
            AvailablePool.Add(new Member("yuyent hoang"));
            AvailablePool.Add(new Member("nmbement hoang"));
            Player1 = new ObservableCollection<Member>();
            Player2 = new ObservableCollection<Member>();
            Player3 = new ObservableCollection<Member>();
            Player4 = new ObservableCollection<Member>();
        }

        void IDropTarget.DragOver(IDropInfo dropInfo)
        {
            if (IsDraggedIntoQueue(dropInfo))
            {
                if (GongSolutions.Wpf.DragDrop.DefaultDropHandler.GetList(dropInfo.TargetCollection).Count != 0)
                {
                    return;
                }
            }
            if (GongSolutions.Wpf.DragDrop.DefaultDropHandler.CanAcceptData(dropInfo))
            {
                dropInfo.Effects = DragDropEffects.Move;
                dropInfo.DropTargetAdorner = DropTargetAdorners.Insert;
            }
        }

        void IDropTarget.Drop(IDropInfo dropInfo)
        {
            var insertIndex = dropInfo.InsertIndex;
            var destinationList = GongSolutions.Wpf.DragDrop.DefaultDropHandler.GetList(dropInfo.TargetCollection);
            var data = GongSolutions.Wpf.DragDrop.DefaultDropHandler.ExtractData(dropInfo.Data);
            {
                if (dropInfo.DragInfo.VisualSource == dropInfo.VisualTarget)
                {
                    var sourceList = GongSolutions.Wpf.DragDrop.DefaultDropHandler.GetList(dropInfo.DragInfo.SourceCollection);

                    foreach (var o in data)
                    {
                        var index = sourceList.IndexOf(o);

                        if (index != -1)
                        {
                            sourceList.RemoveAt(index);

                            if (sourceList == destinationList && index < insertIndex)
                            {
                                --insertIndex;
                            }
                        }
                    }
                }

                foreach (var o in data)
                {
                    destinationList.Insert(insertIndex++, o);
                }
            }
            MessageBox.Show("Dropped!");
            MessageBox.Show(((FrameworkElement)(dropInfo.VisualTarget)).Name);
        }
        bool IsDraggedIntoQueue(IDropInfo dropInfo)
        {
            string name = ((FrameworkElement)(dropInfo.VisualTarget)).Name;
            if (name == "Player1" || name == "Player2" || name == "Player3" || name == "Player4")
                return true;
            else
                return false;
        }
    }
}
