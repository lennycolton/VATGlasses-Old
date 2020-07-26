using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VATGlasses
{
    class Country
    {
        public static readonly string strDataFile = DataLink.strDataDirectory + @"\countries.txt";

        public static List<Country> list { get; private set; }

        public string strName { get; private set; }
        public string strICAO { get; private set; }

        public Country(string _name, string _icao)
        {
            strName = _name;
            strICAO = _icao;
        }

        public Country(string[] _data)
        {
            strName = _data[0];
            strICAO = _data[1];
        }

        public static async Task Load(string _filename)
        {
            list = new List<Country>();

            using (FileStream fs = File.Open(_filename, FileMode.Open, FileAccess.Read, FileShare.Read))
            using (BufferedStream bs = new BufferedStream(fs))
            using (StreamReader sr = new StreamReader(bs))
            {
                string strRaw;
                while ((strRaw = sr.ReadLine()) != null)
                {
                    string[] strarrSplit = strRaw.Split('|');

                    if (strarrSplit.Length == 2)
                    {
                        list.Add(new Country(strarrSplit));
                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException("Each line in the file must contain two entries, separated by a '|': a country name, followed by its ICAO identifier.");
                    }
                }
            }

            list = Sort(list);
        }

        public static List<Country> Sort(List<Country> _list)
        {
            if (_list.Count <= 1)
            {
                return _list;
            }

            int midpoint = _list.Count / 2;

            List<Country> left = new List<Country>();
            List<Country> right = new List<Country>();

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

        private static List<Country> Combine(List<Country> _left, List<Country> _right)
        {
            List<Country> sorted = new List<Country>();

            while (_left.Count > 0 || _right.Count > 0)
            {
                if (_left.Count > 0 && _right.Count > 0)
                {
                    if (string.Compare(_left[0].strICAO, _right[0].strICAO) <= 0)
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
}
