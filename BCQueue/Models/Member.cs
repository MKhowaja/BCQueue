using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BCQueue
{
    public class Member
    {
        #region enum declarations
        public enum pd { Singles = 0, Doubles = 1, Mixed = 2, None = 3 }
        public enum sl {Beginner = 0, Intermediate = 1, Advanced = 2, Tournament = 3, Unknown = 4}
        #endregion

        private pd _preferredDiscipline;
        private sl _skillLevel;
        public String AboutMe { get; set; }
        public bool Gender { get; set; }
        public int GamesWon { get; set; }
        public int GamesLost { get; set; }
        public int TotalGames { get {return GamesLost+GamesWon;} }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public pd PreferredDiscipline
        { 
            get {return _preferredDiscipline;}
            set
            {
                if ((int)value < 0 || (int)value > 3)
                    _preferredDiscipline = value;
                else
                    _preferredDiscipline = pd.None;
            } 
        } 
        public sl SkillLevel
        {
            get {return _skillLevel;}
            set
            {
                if ((int)value < 0 || (int)value > 4)
                    _skillLevel = value;
                else
                    _skillLevel = sl.Unknown;
            }
        }

        
        
    }
}
