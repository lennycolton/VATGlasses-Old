using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VATGlasses
{
    class OwnershipBase
    {
        public bool isApproach;
        public int? intMinAlt;
        public int? intMaxAlt;

        public OwnershipBase(OwnershipBase _base)
        {
            isApproach = _base.isApproach;
            intMinAlt = _base.intMinAlt;
            intMaxAlt = _base.intMaxAlt;
        }

        public OwnershipBase(bool _approach, int? _min, int? _max)
        {
            isApproach = _approach;
            intMinAlt = _min;
            intMaxAlt = _max;
        }

        public OwnershipBase(bool _approach, int _alt, bool _max)
        {
            isApproach = _approach;

            if (_max)
            {
                intMinAlt = null;
                intMaxAlt = _alt;
            }
            else
            {
                intMinAlt = _alt;
                intMaxAlt = null;
            }
        }

        public OwnershipBase(bool _approach)
        {
            isApproach = _approach;
            intMinAlt = null;
            intMaxAlt = null;
        }

        public OwnershipBase(string[] _data)
        {
            if (_data[1] == "1")
            {
                isApproach = true;
            }
            else
            {
                isApproach = false;
            }

            try
            {
                intMinAlt = int.Parse(_data[2], DataLink.DataCulture);
            }
            catch
            {
                intMinAlt = null;
            }

            try
            {
                intMaxAlt = int.Parse(_data[3], DataLink.DataCulture);
            }
            catch
            {
                intMaxAlt = null;
            }
        }
    }
}
