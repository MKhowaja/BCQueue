using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BCQueue
{
    public class Member
    {
        public int GamesWon { get; set; }
        public int GamesLost { get; set; }
        public int TotalGames { get {return GamesLost+GamesWon;} }
        public int SkillLevel { get; set; } //make enum later (Beginner, Intermediate, Advanced, Tournament-Level)
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PreferredDiscipline
        { //1 - Singles, 2 - Doubles, 3 - Mixed, 4 - N/A ->also make enum
            get
            {
                return PreferredDiscipline;
            }
            set
            {
                if (value > 0 && value < 4)
                    PreferredDiscipline = value;
                else
                    PreferredDiscipline = 4;
            } 
        } 
        
    }
}
