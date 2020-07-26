using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VATGlasses
{
    class ATC : Client
    {
        public static new List<ATC> list { get; protected set; }
        public static List<ATC> observers { get; protected set; }

        public static readonly string[] strarrRatings = { "OBS", "S1", "S2", "S3", "C1", "C2", "C3", "I1", "I2", "I3", "SUP", "ADM" };
        public static readonly string[] strarrFacilities = { "FSS", "DEL", "GND", "TWR", "APP/DEP", "CTR", "ATIS" };

        public decimal decFreq { get; protected set; }
        public double dblLat { get; protected set; }
        public double dblLon { get; protected set; }
        public string strServer { get; protected set; }
        public int intRating { get; protected set; }
        public int intFacility { get; protected set; }
        public int intVisibility { get; protected set; }
        public string strATIS { get; protected set; }
        public bool isObs { get; private set; }
        public DateTime dtLogon { get; protected set; }
        public Controller ctlController { get; protected set; }

        public ATC(string[] _data, bool _obs) : base(_data)
        {
            if (decimal.TryParse(_data[4], NumberStyles.Float, DataLink.DataCulture, out decimal decTemp))
            {
                decFreq = decTemp;
            }
            else
            {
                decFreq = 0;
            }

            if (double.TryParse(_data[5], NumberStyles.Float, DataLink.DataCulture, out double dblTemp))
            {
                dblLat = dblTemp;
            }
            else
            {
                dblLat = 0;
            }

            if (double.TryParse(_data[6], NumberStyles.Float, DataLink.DataCulture, out dblTemp))
            {
                dblLon = dblTemp;
            }
            else
            {
                dblLon = 0;
            }

            strServer = _data[14];

            if (int.TryParse(_data[16], NumberStyles.Integer, DataLink.DataCulture, out int intTemp) && intTemp > 0 && intTemp < 13)
            {
                intRating = intTemp;
            }
            else
            {
                intRating = 1;
            }

            if (_data[0].Split('_').Last() == "ATIS")
            {
                intFacility = 7;
            }
            else
            {
                if (int.TryParse(_data[18], NumberStyles.Integer, DataLink.DataCulture, out intTemp))
                {
                    intFacility = intTemp;
                }
                else
                {
                    intFacility = 1;
                }
            }

            if (int.TryParse(_data[19], NumberStyles.Integer, DataLink.DataCulture, out intTemp))
            {
                intVisibility = intTemp;
            }
            else
            {
                intVisibility = 0;
            }

            strATIS = FormatATIS(_data[35]);

            try
            {
                dtLogon = new DateTime(int.Parse(_data[37].Substring(0, 4), DataLink.DataCulture), int.Parse(_data[37].Substring(4, 2), DataLink.DataCulture), int.Parse(_data[37].Substring(6, 2), DataLink.DataCulture), int.Parse(_data[37].Substring(8, 2), DataLink.DataCulture), int.Parse(_data[37].Substring(10, 2), DataLink.DataCulture), int.Parse(_data[37].Substring(12, 2), DataLink.DataCulture));
            }
            catch
            {
                dtLogon = new DateTime(1918, 4, 1);
            }

            if (intFacility == 7 || (intFacility >= 2 && intFacility <= 4))
            {
                Airport apTemp = Airport.FindWithAlias(strCallsign.Split('_')[0]);

                if (apTemp != null && decFreq != (decimal)199.998)
                {
                    if (intFacility == 2)
                    {
                        apTemp.AddDelivery(this);
                    }
                    else if (intFacility == 3)
                    {
                        apTemp.AddGround(this);
                    }
                    else if (intFacility == 4)
                    {
                        apTemp.AddTower(this);
                    }
                    else if (intFacility == 7)
                    {
                        apTemp.AddATIS(this);
                    }
                }
            }

            isObs = _obs;
        }

        public Controller Controller
        {
            get
            {
                return ctlController;
            }
            set
            {
                if (ctlController == null)
                {
                    ctlController = value;
                }
            }
        }

        private string FormatATIS(string _atis)
        {
            string[] strarrATIS = _atis.Split(new string[] { "^Â§" }, StringSplitOptions.None);
            string strReturn = "";

            foreach (string strStr in strarrATIS)
            {
                if (!strStr.StartsWith("$ "))
                {
                    strReturn += (strStr + "\r\n\r\n");
                }
            }

            if (strReturn.Length >= 2)
            {
                strReturn = strReturn.Substring(0, strReturn.Length - 2);
            }
            
            return strReturn;
        }

        public static void SortList()
        {
            list = Sort(list);
        }

        private static List<ATC> Sort(List<ATC> _list)
        {
            if (_list.Count <= 1)
            {
                return _list;
            }

            int midpoint = _list.Count / 2;

            List<ATC> left = new List<ATC>();
            List<ATC> right = new List<ATC>();

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

        private static List<ATC> Combine(List<ATC> _left, List<ATC> _right)
        {
            List<ATC> sorted = new List<ATC>();

            while (_left.Count > 0 || _right.Count > 0)
            {
                if (_left.Count > 0 && _right.Count > 0)
                {
                    if (string.Compare(_left[0].strCallsign, _right[0].strCallsign) <= 0)
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

        public static List<ATC> FindStartCS(string _start)
        {
            List<ATC> listResult = new List<ATC>();

            foreach (ATC atcAtc in list)
            {
                if (atcAtc.strCallsign.StartsWith(_start))
                {
                    listResult.Add(atcAtc);
                }
            }

            return listResult;
        }

        public static List<ATC> FindStartName(string _start)
        {
            List<ATC> listResult = new List<ATC>();

            foreach (ATC atcAtc in list)
            {
                if (atcAtc.strName.StartsWith(_start))
                {
                    listResult.Add(atcAtc);
                }
            }

            return listResult;
        }

        public static List<ATC> FindStartCID(string _start)
        {
            List<ATC> listResult = new List<ATC>();

            foreach (ATC atcAtc in list)
            {
                if (atcAtc.intCID.ToString().StartsWith(_start))
                {
                    listResult.Add(atcAtc);
                }
            }

            return listResult;
        }

        public static List<ATC> FindStartEnd(string _start)
        {
            List<ATC> listResult = new List<ATC>();

            foreach (ATC atcAtc in list)
            {
                if (atcAtc.strCallsign.Split('_').Last().StartsWith(_start))
                {
                    listResult.Add(atcAtc);
                }
            }

            return listResult;
        }

        public static List<ATC> FindStartStart(string _start)
        {
            List<ATC> listResult = new List<ATC>();

            foreach (ATC atcAtc in list)
            {
                if (atcAtc.strCallsign.Split('_')[0].StartsWith(_start))
                {
                    listResult.Add(atcAtc);
                }
            }

            return listResult;
        }

        public static List<ATC> FindStartFreq(string _start)
        {
            List<ATC> listResult = new List<ATC>();

            foreach (ATC atcAtc in list)
            {
                if (atcAtc.decFreq.ToString("###.###").StartsWith(_start))
                {
                    listResult.Add(atcAtc);
                }
            }

            return listResult;
        }

        public static List<ATC> FindStartRating(string _start)
        {
            List<ATC> listResult = new List<ATC>();

            foreach (ATC atcAtc in list)
            {
                if (strarrRatings[atcAtc.intRating - 1].StartsWith(_start))
                {
                    listResult.Add(atcAtc);
                }
            }

            return listResult;
        }

        public static List<ATC> FindOBSStartCS(string _start)
        {
            List<ATC> listResult = new List<ATC>();

            foreach (ATC obsObs in observers)
            {
                if (obsObs.strCallsign.StartsWith(_start))
                {
                    listResult.Add(obsObs);
                }
            }

            return listResult;
        }

        public static List<ATC> FindOBSStartName(string _start)
        {
            List<ATC> listResult = new List<ATC>();

            foreach (ATC obsObs in observers)
            {
                if (obsObs.strName.StartsWith(_start))
                {
                    listResult.Add(obsObs);
                }
            }

            return listResult;
        }

        public static List<ATC> FindOBSStartCID(string _start)
        {
            List<ATC> listResult = new List<ATC>();

            foreach (ATC obsObs in observers)
            {
                if (obsObs.intCID.ToString().StartsWith(_start))
                {
                    listResult.Add(obsObs);
                }
            }

            return listResult;
        }

        public static List<ATC> FindOBSStartRating(string _start)
        {
            List<ATC> listResult = new List<ATC>();

            foreach (ATC obsObs in observers)
            {
                if (strarrRatings[obsObs.intRating].StartsWith(_start))
                {
                    listResult.Add(obsObs);
                }
            }

            return listResult;
        }

        public static new void Reset()
        {
            list = new List<ATC>();
        }

        public static ATC Add(string[] _data, bool _obs)
        {
            ATC atcTemp = new ATC(_data, _obs);
            Add(atcTemp);

            if (_obs)
            {
                observers.Add(atcTemp);
            }
            else
            {
                list.Add(atcTemp);
            }

            return atcTemp;
        }

        public static int[] GetConnectionStat()
        {
            int intATIS = 0;

            foreach (ATC atcAtc in list)
            {
                if (atcAtc.intFacility == 7)
                {
                    intATIS++;
                }
            }

            return new int[] { list.Count - intATIS, intATIS };
        }

        public static void ResetOBS()
        {
            observers = new List<ATC>();
        }
    }
}