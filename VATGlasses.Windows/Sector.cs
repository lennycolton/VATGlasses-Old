using GMap.NET.WindowsForms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VATGlasses
{
    class Sector
    {
        public static List<Sector> list;
        public static List<Sector> listSorted;

        public string strID;
        public int? intMinAlt;
        public int? intMaxAlt;
        public List<Runway> listRunways;

        public Sector(string _pack, string _id, int _min, int _max, List<Runway> _runways)
        {
            strID = _pack + "/" + _id;
            intMinAlt = _min;
            intMaxAlt = _max;
            listRunways = _runways;
        }

        public Sector(string _pack, string _id, int _alt, bool _max, List<Runway> _runways)
        {
            strID = _pack + "/" + _id;

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

            listRunways = _runways;
        }

        public Sector(string _pack, string _id, string _name, List<Runway> _runways)
        {
            strID = _pack + "/" + _id;
            intMinAlt = null;
            intMaxAlt = null;
            listRunways = _runways;
        }

        public Sector(string _pack, string[] _data)
        {
            strID = _pack + "/" + _data[0];

            try
            {
                intMinAlt = int.Parse(_data[1], DataLink.DataCulture);
            }
            catch
            {
                intMinAlt = null;
            }

            try
            {
                intMaxAlt = int.Parse(_data[2], DataLink.DataCulture);
            }
            catch
            {
                intMaxAlt = null;
            }

            listRunways = new List<Runway>();

            if (_data[3].Length > 0)
            {
                foreach (string strStr in _data[3].Split(','))
                {
                    listRunways.Add(Runway.Find(_pack + "/" + strStr));
                }
            }
        }

        public Sector(Sector _sector)
        {
            strID = _sector.strID;
            intMinAlt = _sector.intMinAlt;
            intMaxAlt = _sector.intMaxAlt;
            listRunways = new List<Runway>(_sector.listRunways);
        }

        public static void Create(string _pack, string[] _data)
        {
            if (_data[4] == "0")
            {
                list.Add(new PolySector(_pack, _data));
            }
            else if (_data[4] == "1")
            {
                list.Add(new CircleSector(_pack, _data));
            }
        }

        public static async Task Load(string _pack)
        {
            using (FileStream fs = File.Open(DataLink.strDataDirectory + @"\" + _pack + @"\sectors.txt", FileMode.Open, FileAccess.Read, FileShare.Read))
            using (BufferedStream bs = new BufferedStream(fs))
            using (StreamReader sr = new StreamReader(bs))
            {
                string strRaw;
                while ((strRaw = sr.ReadLine()) != null)
                {
                    if (strRaw.First() != ';')
                    {
                        string[] strarrCommented = strRaw.Split(';');
                        strRaw = strarrCommented[0];

                        string[] strarrSplit = strRaw.Split('|');

                        if (strarrSplit.Length >= 5)
                        {
                            Create(_pack, strarrSplit);
                        }
                        else
                        {
                            Console.WriteLine(strRaw);
                            throw new ArgumentOutOfRangeException("Each line in the file must contain at least four entries, separated by a '|'");
                        }
                    }
                }
            }
        }

        public static Sector Find(string _id)
        {
            //Set bounds
            int intMidpoint;
            int intMin = 0;
            int intMax = listSorted.Count - 1;

            do
            {
                //Set midpoint
                intMidpoint = (intMin + intMax) / 2;

                //Find midpoint items
                Sector sctCurrent = listSorted[intMidpoint];

                //If current is search
                if (string.Compare(sctCurrent.strID, _id) == 0)
                {
                    return sctCurrent;
                }
                //If current is before search
                else if (string.Compare(sctCurrent.strID, _id) < 0)
                {
                    intMin = intMidpoint + 1;
                }
                //If current is after search
                else if (string.Compare(sctCurrent.strID, _id) > 0)
                {
                    intMax = intMidpoint - 1;
                }
            } while (intMin <= intMax);

            return null;
        }

        public static async Task SortAsync()
        {
            listSorted = Sort(list);
        }

        public static List<Sector> Sort(List<Sector> _list)
        {
            if (_list.Count <= 1)
            {
                return _list;
            }

            int midpoint = _list.Count / 2;

            List<Sector> left = new List<Sector>();
            List<Sector> right = new List<Sector>();

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

        private static List<Sector> Combine(List<Sector> _left, List<Sector> _right)
        {
            List<Sector> sorted = new List<Sector>();

            while (_left.Count > 0 || _right.Count > 0)
            {
                if (_left.Count > 0 && _right.Count > 0)
                {
                    if (string.Compare(_left[0].strID, _right[0].strID) <= 0)
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

        public static List<Tuple<Controller, Airspace, Sector, GMapPolygon, bool>> SortDisplay(List<Tuple<Controller, Airspace, Sector, GMapPolygon, bool>> _list)
        {
            if (_list.Count <= 1)
            {
                return _list;
            }

            int midpoint = _list.Count / 2;

            List<Tuple<Controller, Airspace, Sector, GMapPolygon, bool>> left = new List<Tuple<Controller, Airspace, Sector, GMapPolygon, bool>>();
            List<Tuple<Controller, Airspace, Sector, GMapPolygon, bool>> right = new List<Tuple<Controller, Airspace, Sector, GMapPolygon, bool>>();

            for (int i = 0; i < midpoint; i++)
            {
                left.Add(_list[i]);

            }
            for (int j = midpoint; j < _list.Count; j++)
            {
                right.Add(_list[j]);
            }

            left = SortDisplay(left);
            right = SortDisplay(right);
            return CombineDisplay(left, right);
        }

        private static List<Tuple<Controller, Airspace, Sector, GMapPolygon, bool>> CombineDisplay(List<Tuple<Controller, Airspace, Sector, GMapPolygon, bool>> _left, List<Tuple<Controller, Airspace, Sector, GMapPolygon, bool>> _right)
        {
            List<Tuple<Controller, Airspace, Sector, GMapPolygon, bool>> sorted = new List<Tuple<Controller, Airspace, Sector, GMapPolygon, bool>>();

            while (_left.Count > 0 || _right.Count > 0)
            {
                if (_left.Count > 0 && _right.Count > 0)
                {
                    if (_left[0].Item3.intMinAlt > _right[0].Item3.intMinAlt)
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

    class PolySector : Sector
    {
        public List<double[]> Points;

        public PolySector(string _pack, string[] _data) : base(_pack, _data)
        {
            Points = new List<double[]>();

            for (int i = 5; i < _data.Length; i++)
            {
                string[] strCoord = _data[i].Split(',');
                Points.Add(new double[] { double.Parse(strCoord[0], DataLink.DataCulture), double.Parse(strCoord[1], DataLink.DataCulture) });
            }
        }
    }

    class CircleSector : Sector
    {
        public double[] Point;
        public double Radius;

        public CircleSector(string _pack, string[] _data) : base(_pack, _data)
        {
            string[] strCoord = _data[5].Split(',');
            Point = new double[] { double.Parse(strCoord[0], DataLink.DataCulture), double.Parse(strCoord[1], DataLink.DataCulture) };

            Radius = double.Parse(_data[6], DataLink.DataCulture);
        }
    }
}
