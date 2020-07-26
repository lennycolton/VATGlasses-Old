using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VATGlasses.VRCParser
{
    class Airspace
    {
        public static List<Airspace> list;

        public static int count = 0;

        public int ID;
        public List<Controller> owners;
        public List<Sector> sectors;

        public Airspace(List<Controller> _owners)
        {
            ID = count;
            count++;
            owners = _owners;
            sectors = new List<Sector>();
        }

        public Airspace(Sector _sector)
        {
            ID = count;
            count++;
            owners = _sector.owners;
            sectors = new List<Sector>();
            sectors.Add(_sector);
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
