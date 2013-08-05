using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BCQueue
{
    [Serializable]
    public class Court
    {
        public Boolean IsCourtActive { get; set; } //indicates whether a certain court is available for usage
    }
}
