using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VATGlasses
{
    class OwnedAirspace : OwnershipBase
    {
        public Airspace aspAirspace;

        public OwnedAirspace(Airspace _airspace, bool _approach, int _min, int _max) : base(_approach, _min, _max)
        {
            aspAirspace = _airspace;
        }

        public OwnedAirspace(Airspace _airspace, OwnershipBase _base) : base(_base)
        {
            aspAirspace = _airspace;
        }

        public static List<OwnedAirspace> Sort(List<OwnedAirspace> _list)
        {
            if (_list.Count <= 1)
            {
                return _list;
            }

            int midpoint = _list.Count / 2;

            List<OwnedAirspace> left = new List<OwnedAirspace>();
            List<OwnedAirspace> right = new List<OwnedAirspace>();

            for (int i = 0; i < midpoint; i++)
            {
                left.Add(_list[i]);

            }
            for (int j = midpoint; j < _list.Count; j++)
            {
                right.Add(_list[j]);
            }

            left = Sort(left);
            right = Sort(right);
            return Combine(left, right);
        }

        private static List<OwnedAirspace> Combine(List<OwnedAirspace> _left, List<OwnedAirspace> _right)
        {
            List<OwnedAirspace> sorted = new List<OwnedAirspace>();

            while (_left.Count > 0 || _right.Count > 0)
            {
                if (_left.Count > 0 && _right.Count > 0)
                {
                    if (string.Compare(_left[0].aspAirspace.strID, _right[0].aspAirspace.strID) <= 0)
                    {
                        sorted.Add(_left[0]);
                        _left.Remove(_left[0]);
                    }
                    else
                    {
                        sorted.Add(_right[0]);
                        _right.Remove(_right[0]);
                    }
                }
                else if (_left.Count > 0)
                {
                    sorted.Add(_left[0]);
                    _left.Remove(_left[0]);
                }
                else if (_right.Count > 0)
                {
                    sorted.Add(_right[0]);
                    _right.Remove(_right[0]);
                }
            }

            return sorted;
        }
    }
}
