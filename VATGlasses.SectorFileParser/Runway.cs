using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VATGlasses.SectorFileParser
{
    class Runway
    {
        public static int count = 0;
        public static List<Runway> list;

        public int ID;
        public int airport;
        public string runway;

        public Runway(int _airport, string _runway)
        {
            ID = count;
            count++;

            airport = _airport;
            runway = _runway;
        }

        //Binary Search for class instance from public list.
        public static Runway Find(int _airport, string _runway)
        {
            foreach (Runway rwyRwy in list)
            {
                if (rwyRwy.airport == _airport && rwyRwy.runway == _runway)
                {
                    return rwyRwy;
                }
            }

            return null;
        }
    }
}
