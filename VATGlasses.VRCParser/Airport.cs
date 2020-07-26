using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VATGlasses.VRCParser
{
    class Airport
    {
        public static List<Airport> list;
        public static List<Airport> listSorted;

        public int ID { get; private set; }
        public string ICAO { get; private set; }
        public double lat { get; private set; }
        public double lon { get; private set; }

        public Airport(string[] _data)
        {
            ID = int.Parse(_data[0]);
            ICAO = _data[1];
            lat = double.Parse(_data[3]);
            lon = double.Parse(_data[4]);
        }

        public static void Load(string _filename)
        {
            list = new List<Airport>();

            using (FileStream fs = File.Open(_filename, FileMode.Open, FileAccess.Read, FileShare.Read))
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

                        if (strarrSplit.Length == 7)
                        {
                            Airport apTemp = new Airport(strarrSplit);
                            list.Add(apTemp);
                        }
                        else
                        {
                            Console.WriteLine(strRaw);
                            throw new ArgumentOutOfRangeException("Each line in the file must contain eight entries, separated by a '|'");
                        }
                    }
                }
            }

            listSorted = Sort(list);
        }

        public static List<Airport> Sort(List<Airport> _list)
        {
            if (_list.Count <= 1)
            {
                return _list;
            }

            int midpoint = _list.Count / 2;

            List<Airport> left = new List<Airport>();
            List<Airport> right = new List<Airport>();

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

        private static List<Airport> Combine(List<Airport> _left, List<Airport> _right)
        {
            List<Airport> sorted = new List<Airport>();

            while (_left.Count > 0 || _right.Count > 0)
            {
                if (_left.Count > 0 && _right.Count > 0)
                {
                    if (string.Compare(_left[0].ICAO, _right[0].ICAO) <= 0)
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

        //Binary Search for class instance from public list.
        public static Airport Find(string _icao)
        {
            Airport airCurrent = null;
            _icao = _icao.ToUpper();

            //Set bounds
            int intMidpoint;
            int intMin = 0;
            int intMax = listSorted.Count - 1;

            do
            {
                //Set midpoint
                intMidpoint = (intMin + intMax) / 2;

                //Find midpoint items
                airCurrent = listSorted[intMidpoint];

                //If current is search
                if (string.Compare(airCurrent.ICAO, _icao) == 0)
                {
                    return airCurrent;
                }
                //If current is before search
                else if (string.Compare(airCurrent.ICAO, _icao) < 0)
                {
                    intMin = intMidpoint + 1;
                }
                //If current is after search
                else if (string.Compare(airCurrent.ICAO, _icao) > 0)
                {
                    intMax = intMidpoint - 1;
                }
            } while (intMin <= intMax);

            return null;
        }
    }
}
