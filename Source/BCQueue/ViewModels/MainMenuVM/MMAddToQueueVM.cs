﻿using System.Windows.Input;
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
        /// <summary>
        /// List of players who are currently waiting on the queue; Will be displayed in the Active Games view
        /// </summary>
        public ObservableCollection<ObservableCollection<Member>> QueueList;

        /// <summary>
        /// List of players who are not in any active games nor waiting on the queue
        /// </summary>
        public ObservableCollection<Member> AvailablePool { get; set; }

        /// <summary>
        /// Each one of these ObservableCollections should logically only hold 1 Member object.
        /// The code is written this way as a workaround for the limitations of gong-wpf's drag'n'drop library.
        /// This will likely be changed in the future.
        /// </summary>
        public ObservableCollection<Member> Player1 { get; set; }
        public ObservableCollection<Member> Player2 { get; set; }
        public ObservableCollection<Member> Player3 { get; set; }
        public ObservableCollection<Member> Player4 { get; set; }

        /// <summary>
        /// This constructor initializes all the ObservableCollection properties in the ViewModel to new, empty ones
        /// </summary>
        public MMAddToQueueVM()
        {
            AvailablePool = new ObservableCollection<Member>();
            Player1 = new ObservableCollection<Member>();
            Player2 = new ObservableCollection<Member>();
            Player3 = new ObservableCollection<Member>();
            Player4 = new ObservableCollection<Member>();
        }

        /// <summary>
        /// Similar to the default except it doesn't allow drop when IsDraggedIntoQueue is true
        /// </summary>
        /// <param name="dropInfo"></param>
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

        /// <summary>
        /// Moves the data upon drop
        /// </summary>
        /// <param name="dropInfo"></param>
        void IDropTarget.Drop(IDropInfo dropInfo)
        {
            var insertIndex = dropInfo.InsertIndex;
            var destinationList = GongSolutions.Wpf.DragDrop.DefaultDropHandler.GetList(dropInfo.TargetCollection);
            var data = GongSolutions.Wpf.DragDrop.DefaultDropHandler.ExtractData(dropInfo.Data);
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

            foreach (var o in data)
            {
                destinationList.Insert(insertIndex++, o);
                //sets isBusy to true when dragged into queue and sets isBusy to false when dragged out of queue
                if (IsDraggedIntoQueue(dropInfo))
                {
                    ((Member)o).isBusy = true;
                }
                else
                {
                    ((Member)o).isBusy = false;
                }
            }
        }

        /// <summary>
        /// Returns true if the VisualTarget in the DropInfo is named Player1, Player2, Player3, or Player4
        /// </summary>
        /// <param name="dropInfo"></param>
        /// <returns></returns>
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
