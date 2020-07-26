using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VATGlasses
{
    class FPlan : Client
    {
        public static List<FPlan> prefiles { get; private set; }

        public string strAircraft { get; protected set; }
        public decimal decTASCruise { get; protected set; }
        public Airport apDep { get; protected set; }
        public Airport apArr { get; protected set; }
        public Airport apAlt { get; protected set; }
        public int intPlanAlt { get; protected set; } = 0;
        public string strRevision { get; protected set; }
        public string strRules { get; protected set; }
        public DateTime dtDep { get; protected set; }
        public TimeSpan tspEnroute { get; protected set; }
        public TimeSpan tspFuel { get; protected set; }
        public string strRoute { get; protected set; }
        public string strRemarks { get; protected set; }

        public FPlan(string[] _data) : base (_data)
        {
            strAircraft = _data[9];

            if (decimal.TryParse(_data[10], NumberStyles.Float, DataLink.DataCulture, out decimal decTemp))
            {
                decTASCruise = decTemp;
            }
            else
            {
                decTASCruise = 0;
            }

            apDep = Airport.FindICAO(_data[11]);
            apArr = Airport.FindICAO(_data[13]);
            apAlt = Airport.FindICAO(_data[28]);

            if (int.TryParse(_data[12], NumberStyles.Integer, DataLink.DataCulture, out int intTemp))
            {
                intPlanAlt = intTemp;
            }
            else
            {
                try
                {
                    _data[12] = _data[12].Substring(1);
                    if (int.TryParse(_data[12], NumberStyles.Integer, DataLink.DataCulture, out intTemp))
                    {
                        intPlanAlt = intTemp;
                    }
                    else
                    {
                        intPlanAlt = 0;
                    }
                }
                catch
                {
                    intPlanAlt = 0;
                }
            }

            if (intPlanAlt.ToString().Length < 4)
            {
                intPlanAlt *= 100;
            }

            strRevision = _data[20];
            strRules = _data[21];

            try
            {
                dtDep = new DateTime(1, 1, 1, int.Parse(_data[22].Substring(0, 2), DataLink.DataCulture), int.Parse(_data[22].Substring(2, 2), DataLink.DataCulture), 0); 
            }
            catch
            {
                dtDep = default(DateTime);
            }

            try
            {
                tspEnroute = new TimeSpan(int.Parse(_data[24], DataLink.DataCulture), int.Parse(_data[25], DataLink.DataCulture), 0);
            }
            catch
            {
                tspEnroute = default(TimeSpan);
            }

            try
            {
                tspFuel = new TimeSpan(int.Parse(_data[26], DataLink.DataCulture), int.Parse(_data[27], DataLink.DataCulture), 0);
            }
            catch
            {
                tspFuel = default(TimeSpan);
            }

            strRoute = _data[30];
            strRemarks = _data[29];
        }

        public static void ResetPrefiles()
        {
            prefiles = new List<FPlan>();
        }

        public static void AddPrefile(FPlan _prefile)
        {
            prefiles.Add(_prefile);
        }
    }
}
