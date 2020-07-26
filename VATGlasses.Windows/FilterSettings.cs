using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VATGlasses
{
    class FilterSettings
    {
        public static int intMinATCAlt = 0;
        public static int intMaxATCAlt = 1000000;

        public static List<string> listATCCallsigns = new List<string>();

        public static int intMinPilotAlt = 0;
        public static int intMaxPilotAlt = 1000000;

        public static List<Airport> listDep = new List<Airport>();
        public static List<Airport> listArr = new List<Airport>();

        public static int intPilotFilterMode = 3;
    }
}