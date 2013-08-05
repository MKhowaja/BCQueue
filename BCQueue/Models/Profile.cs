using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BCQueue
{
    [Serializable]
    public class Profile
    {
        private Court[] _courts;
        private List<Member> _members;

        public int NumCourts { get {return NumRows*NumColumns;} } //number of courts in the gym
        public int NumRows { get; set; } 
        public int NumColumns { get; set; }
        public int timerValue { get; set; } //minutes of play allowed on court
        
    }
}
