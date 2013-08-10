using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BCQueue
{
    public class Member
    {
        #region enum declarations
        public enum pd { None = 0, Singles = 1, Doubles = 2, Mixed = 3 }
        public enum sl { Unknown = 0, Beginner = 1, Intermediate = 2, Advanced = 3, Tournament = 4 }
        public enum gend { Unspecified = 0, Male = 1, Female = 2 }
        #endregion

        private pd _preferredDiscipline;
        private sl _skillLevel;
        private gend _gender;
        public bool isOnline { get; set; } 
        public String AboutMe { get; set; } //TODO: Find a better data type to support this
        public int GamesWon { get; set; }
        public int GamesLost { get; set; }
        public int TotalGames { get { return GamesLost + GamesWon; } }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get { return FirstName+" "+LastName; } }
        public pd PreferredDiscipline
        {
            get { return _preferredDiscipline; }
            set
            {
                if ((int)value < 0 || (int)value > 3)
                    _preferredDiscipline = pd.None;
                else
                    _preferredDiscipline = value;
            }
        }
        public sl SkillLevel
        {
            get { return _skillLevel; }
            set
            {
                if ((int)value < 0 || (int)value > 4)
                    _skillLevel = sl.Unknown;
                else
                    _skillLevel = value;
            }
        }
        public gend Gender
        {
            get { return _gender; }
            set
            {
                if ((int)value < 0 || (int)value > 2)
                    _skillLevel = sl.Unknown;
                else
                    _gender = value;
            }
        }
    }
}
