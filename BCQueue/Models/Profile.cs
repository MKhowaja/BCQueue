using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace BCQueue
{
    [Serializable]
    public class Profile
    {
        private ObservableCollection<Court> _courts = new ObservableCollection<Court>();
        private ObservableCollection<Member> _members = new ObservableCollection<Member>();

        public String ClubName { get; set; }
        public int NumCourts { get {return NumRows*NumColumns;} } //number of courts in the gym
        public int NumRows { get; set; } 
        public int NumColumns { get; set; }
        public int TimerValue { get; set; } //minutes of play allowed on court
        public ObservableCollection<Court> Courts { get { return _courts; } }
        public ObservableCollection<Member> Members { get { return _members; } }
    }
}
