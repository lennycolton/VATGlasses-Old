using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VATGlasses.VRCParser
{
    class Sector
    {
        public static List<Sector> list;

        public static int count = 0;

        public int ID;
        public string ident;
        public int? minAlt;
        public int? maxAlt;
        public List<Controller> owners;
        public List<SectorLine> lines;
        public List<Runway> runways;

        public Sector()
        {

        }

        public Sector(string[] _data)
        {
            ID = count;
            count++;

            ident = _data[1];

            minAlt = int.Parse(_data[2]);
            if (minAlt == 0)
            {
                minAlt = null;
            }

            maxAlt = int.Parse(_data[3]);
            if (maxAlt == 66000)
            {
                maxAlt = null;
            }

            owners = new List<Controller>();
            lines = new List<SectorLine>();
            runways = new List<Runway>();
        }

        internal static bool SetOffset(string v)
        {
            if (int.TryParse(v, out count) && count >= 0)
            {
                return true;
            }

            return false;
        }
    }
}
