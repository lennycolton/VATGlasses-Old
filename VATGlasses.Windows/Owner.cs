using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VATGlasses
{
    class Owner : OwnershipBase
    {
        public Controller ctlStation;

        public Owner(Controller _station, bool _approach, int _min, int _max) : base(_approach, _min, _max)
        {
            ctlStation = _station;
        }

        public Owner(Controller _station, bool _approach, int _alt, bool _max) : base(_approach, _alt, _max)
        {
            ctlStation = _station;
        }

        public Owner(Controller _station, bool _approach) : base(_approach)
        {
            ctlStation = _station;
        }

        public Owner(string _pack, string[] _data) : base(_data)
        {
            string[] strPackSplit = _data[0].Split('/');

            if (strPackSplit.Length == 1)
            {
                ctlStation = Controller.Find(_pack + "/" + _data[0]);
            }
            else if (strPackSplit.Length == 2)
            {
                ctlStation = Controller.Find(_data[0]);
            }
        }
    }
}
