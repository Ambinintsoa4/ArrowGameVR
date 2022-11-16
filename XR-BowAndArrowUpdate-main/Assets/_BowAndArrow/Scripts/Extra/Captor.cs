using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace Assets._BowAndArrow.Scripts.Extra
{

    internal class Captor
    {
        SerialPort sp = new SerialPort("COM7", 9600);



        public EventHandler<ReleaseadEventArgs> Released;

        private bool _released;
        private int _xMax;
        private const int Threshold = 2;

        internal void RunWithEvent()
        {
            _xMax = 0;
            _released = false;
            int value = 0;

            while (true)
            {
                if(!sp.IsOpen)
                {
                    sp.Open();
                    sp.ReadTimeout = 1;
                }

                if (sp.IsOpen)
                {
                    try
                    {
                        value = sp.ReadByte();
                    }
                    catch (SystemException)
                    {

                    }
                }


                if (value > _xMax)
                {
                    _xMax = value;
                    continue;
                }


                if (IsReleased(value))
                {
                    Released?.Invoke(this, new ReleaseadEventArgs(_xMax));
                    return;
                }
            }

            bool IsReleased(int value)
            {
                var diff = _xMax - Threshold;
                return (value <= diff && _xMax > Threshold);
            }
        }
    }
}
