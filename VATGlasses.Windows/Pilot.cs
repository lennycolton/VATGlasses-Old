using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Device.Location;
using System.Globalization;

namespace VATGlasses
{
    class Pilot : FPlan
    {
        public static List<(string, bool)> list7500 = new List<(string, bool)>();
        public static List<(string, bool)> list7600 = new List<(string, bool)>();
        public static List<(string, bool)> list7700 = new List<(string, bool)>();

        public static new List<Pilot> list { get; protected set; }
        public static List<Pilot> listDep { get; private set; }
        public static List<Pilot> listArr { get; private set; }

        public double dblLat { get; protected set; }
        public double dblLon { get; protected set; }
        public int intAlt { get; protected set; }
        public decimal decGS { get; protected set; }
        public string strServer { get; protected set; }
        public int intXPDR { get; protected set; }
        public DateTime dtLogon { get; protected set; }
        public int intHeading{ get; protected set; }

        public Pilot(string[] _data) : base (_data)
        {
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

            if (int.TryParse(_data[7], NumberStyles.Integer, DataLink.DataCulture, out int intTemp))
            {
                intAlt = intTemp;
            }
            else
            {
                intAlt = 0;
            }

            if (decimal.TryParse(_data[8], NumberStyles.Float, DataLink.DataCulture, out decimal decTemp))
            {
                decGS = decTemp;
            }
            else
            {
                decGS = 0;
            }

            strServer = _data[14];

            if (int.TryParse(_data[17], NumberStyles.Integer, DataLink.DataCulture, out intTemp))
            {
                intXPDR = intTemp;
            }
            else
            {
                intXPDR = 0;
            }

            dtLogon = new DateTime(int.Parse(_data[37].Substring(0, 4), DataLink.DataCulture), int.Parse(_data[37].Substring(4, 2), DataLink.DataCulture), int.Parse(_data[37].Substring(6, 2), DataLink.DataCulture), int.Parse(_data[37].Substring(8, 2), DataLink.DataCulture), int.Parse(_data[37].Substring(10, 2), DataLink.DataCulture), int.Parse(_data[37].Substring(12, 2), DataLink.DataCulture));

            if (int.TryParse(_data[38], NumberStyles.Integer, DataLink.DataCulture, out intTemp))
            {
                intHeading = intTemp;
            }
            else
            {
                intHeading = 0;
            }

            if (apDep != null)
            {
                apDep.AddFrom();
            }

            if (apArr != null)
            {
                apArr.AddTo();
            }

            if (list7500.Contains((strCallsign, true)))
            {
                if (intXPDR != 7500)
                {
                    list7500.Remove((strCallsign, true));
                }
            }
            else if (list7500.Contains((strCallsign, false)))
            {
                if (intXPDR != 7500)
                {
                    list7500.Remove((strCallsign, false));
                }
            }
            else if (intXPDR == 7500)
            {
                list7500.Add((strCallsign, true));
            }

            if (list7600.Contains((strCallsign, true)))
            {
                if (intXPDR != 7600)
                {
                    list7600.Remove((strCallsign, true));
                }
            }
            else if (list7600.Contains((strCallsign, false)))
            {
                if (intXPDR != 7600)
                {
                    list7600.Remove((strCallsign, false));
                }
            }
            else if (intXPDR == 7600)
            {
                list7600.Add((strCallsign, true));
            }

            if (list7700.Contains((strCallsign, true)))
            {
                if (intXPDR != 7700)
                {
                    list7700.Remove((strCallsign, true));
                }
            }
            else if (list7700.Contains((strCallsign, false)))
            {
                if (intXPDR != 7700)
                {
                    list7700.Remove((strCallsign, false));
                }
            }
            else if (intXPDR == 7700)
            {
                list7700.Add((strCallsign, true));
            }
        }

        public static new void Reset()
        {
            list = new List<Pilot>();
        }

        public static void Add(Pilot _pilot)
        {
            list.Add(_pilot);
            Client.Add(_pilot);
        }

        public static void SortList()
        {
            listDep = new List<Pilot>();
            listArr = new List<Pilot>();

            foreach (Pilot pltPlt in list)
            {
                if (pltPlt.apDep != null)
                {
                    listDep.Add(pltPlt);
                }

                if (pltPlt.apArr != null)
                {
                    listArr.Add(pltPlt);
                }
            }

            list = Sort(list, 0);
            listDep = Sort(listDep, 1);
            listArr = Sort(listArr, 2);
        }

        public static List<Pilot>[] Find(Airport _ap)
        {
            List<Pilot>[] listarrReturn = new List<Pilot>[] { new List<Pilot>(), new List<Pilot>() };

            foreach (Pilot pltPlt in list)
            {
                if (pltPlt.apDep == _ap)
                {
                    listarrReturn[0].Add(pltPlt);
                }

                if (pltPlt.apArr == _ap)
                {
                    listarrReturn[1].Add(pltPlt);
                }
            }

            return listarrReturn;
        }

        public static List<Pilot> FindStartCS(string _start)
        {
            List<Pilot> listResult = new List<Pilot>();

            foreach (Pilot pltPlt in list)
            {
                if (pltPlt.strCallsign.StartsWith(_start))
                {
                    listResult.Add(pltPlt);
                }
            }

            return listResult;
        }

        public static List<Pilot> FindStartName(string _start)
        {
            List<Pilot> listResult = new List<Pilot>();

            foreach (Pilot pltPlt in list)
            {
                if (pltPlt.strName.StartsWith(_start))
                {
                    listResult.Add(pltPlt);
                }
            }

            return listResult;
        }

        public static List<Pilot> FindStartCID(string _start)
        {
            List<Pilot> listResult = new List<Pilot>();

            foreach (Pilot pltPlt in list)
            {
                if (pltPlt.intCID.ToString().StartsWith(_start))
                {
                    listResult.Add(pltPlt);
                }
            }

            return listResult;
        }

        public static List<Pilot> FindStartDepICAO(string _start)
        {
            List<Pilot> listResult = new List<Pilot>();

            foreach (Pilot pltPlt in list)
            {
                if (pltPlt.apDep != null && pltPlt.apDep.strICAO.StartsWith(_start))
                {
                    listResult.Add(pltPlt);
                }
            }

            return listResult;
        }

        public static List<Pilot> FindStartArrICAO(string _start)
        {
            List<Pilot> listResult = new List<Pilot>();

            foreach (Pilot pltPlt in list)
            {
                if (pltPlt.apArr != null && pltPlt.apArr.strICAO.StartsWith(_start))
                {
                    listResult.Add(pltPlt);
                }
            }

            return listResult;
        }

        public static List<Pilot> FindStartAircraft(string _start)
        {
            List<Pilot> listResult = new List<Pilot>();

            foreach (Pilot pltPlt in list)
            {
                if (pltPlt.strAircraft.StartsWith(_start))
                {
                    listResult.Add(pltPlt);
                }
            }

            return listResult;
        }

        private static List<Pilot> Sort(List<Pilot> _list, int _by)
        {
            if (_list.Count <= 1)
            {
                return _list;
            }

            int midpoint = _list.Count / 2;

            List<Pilot> left = new List<Pilot>();
            List<Pilot> right = new List<Pilot>();

            for (int i = 0; i < midpoint; i++)
            {
                left.Add(_list[i]);

            }
            for (int j = midpoint; j < _list.Count; j++)
            {
                right.Add(_list[j]);
            }

            left = Sort(left, _by);
            right = Sort(right, _by);

            switch (_by)
            {
                case 0:
                    return CombineCS(left, right);
                case 1:
                    return CombineDep(left, right);
                case 2:
                    return CombineArr(left, right);
                default:
                    return null;
            }
        }

        private static List<Pilot> CombineCS(List<Pilot> _left, List<Pilot> _right)
        {
            List<Pilot> sorted = new List<Pilot>();

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

        private static List<Pilot> CombineDep(List<Pilot> _left, List<Pilot> _right)
        {
            List<Pilot> sorted = new List<Pilot>();

            while (_left.Count > 0 || _right.Count > 0)
            {
                if (_left.Count > 0 && _right.Count > 0)
                {
                    if (string.Compare(_left[0].apDep.strICAO, _right[0].apDep.strICAO) <= 0)
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

        private static List<Pilot> CombineArr(List<Pilot> _left, List<Pilot> _right)
        {
            List<Pilot> sorted = new List<Pilot>();

            while (_left.Count > 0 || _right.Count > 0)
            {
                if (_left.Count > 0 && _right.Count > 0)
                {
                    if (string.Compare(_left[0].apArr.strICAO, _right[0].apArr.strICAO) <= 0)
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

        public double GetDistanceTo(Airport _airport)
        {
            GeoCoordinate geoPilot = new GeoCoordinate(dblLat, dblLon);
            GeoCoordinate geoAirport = new GeoCoordinate(_airport.dblLat, _airport.dblLon);

            return geoPilot.GetDistanceTo(geoAirport) / 1852;
        }
    }
}
