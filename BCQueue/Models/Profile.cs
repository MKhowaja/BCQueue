using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BCQueue
{
    [Serializable]
    public class Profile
    {

        public int NumCourts { get {return NumRows*NumColumns;} } //number of courts in the gym
        public int NumRows { get; set; } 
        public int NumColumns { get; set; }
        private Court[] courts;
        private List<Member> members;
        public int timerValue { get; set; } //minutes of play allowed on court


        
    }
}
