using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets._BowAndArrow.Scripts.Extra
{
    internal class ReleaseadEventArgs : EventArgs
    {
        internal ReleaseadEventArgs(int value)
        { 
            Value = value;
        
        }

        public int Value { get; }
    }
}
