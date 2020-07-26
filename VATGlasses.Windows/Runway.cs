using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VATGlasses
{
    class Runway
    {
        public static readonly string strCurrentFile = DataLink.strPrefsDirectory + @"\currentrunways.txt";

        public static List<Runway> list;
        public static List<Runway> listSorted;

        public string strID { get; private set; }
        public Airport apOwner { get; private set; }
        public string strRunway { get; private set; }

        public Runway(string _pack, string[] _data)
        {
            strID = _pack + "/" + _data[0];

            int intIndex = int.Parse(_data[1], DataLink.DataCulture);
            if (intIndex >= 0 && intIndex < Airport.list.Count())
            {
                apOwner = Airport.FindID(int.Parse(_data[1], DataLink.DataCulture));

                apOwner.listRunways.Add(this);
                apOwner.listActive.Add(this);
            }
            else
            {
                apOwner = null;
            }

            strRunway = _data[2];
        }

        public static Runway Find(string _id)
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
                Runway rwyCurrent = listSorted[intMidpoint];

                //If current is search
                if (string.Compare(rwyCurrent.strID, _id) == 0)
                {
                    return rwyCurrent;
                }
                //If current is before search
                else if (string.Compare(rwyCurrent.strID, _id) < 0)
                {
                    intMin = intMidpoint + 1;
                }
                //If current is after search
                else if (string.Compare(rwyCurrent.strID, _id) > 0)
                {
                    intMax = intMidpoint - 1;
                }
            } while (intMin <= intMax);

            return null;
        }

        public static List<Runway> Sort(List<Runway> _list)
        {
            if (_list.Count <= 1)
            {
                return _list;
            }

            int midpoint = _list.Count / 2;

            List<Runway> left = new List<Runway>();
            List<Runway> right = new List<Runway>();

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

        private static List<Runway> Combine(List<Runway> _left, List<Runway> _right)
        {
            List<Runway> sorted = new List<Runway>();

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

        public static void SaveCurrent(string _currents, Airport _ap)
        {
            string strAll = "";

            using (FileStream fs = File.Open(_currents, FileMode.Open, FileAccess.Read, FileShare.Read))
            using (BufferedStream bs = new BufferedStream(fs))
            using (StreamReader sr = new StreamReader(bs))
            {
                string[] strarrAp = new string[_ap.listRunways.Count];

                for (int i = 0; i <_ap.listRunways.Count; i++)
                {
                    strarrAp[i] = _ap.listRunways[i].strID;
                }

                string strRaw;
                while ((strRaw = sr.ReadLine()) != null)
                {
                    if (!strarrAp.Contains(strRaw))
                    {
                        strAll += strRaw + "\r\n";
                    }
                }

                foreach (Runway rwyRwy in _ap.listActive)
                {
                    strAll += rwyRwy.strID + "\r\n";
                }
            }

            using (FileStream fs = File.Open(_currents, FileMode.Open, FileAccess.Write, FileShare.Write))
            using (BufferedStream bs = new BufferedStream(fs))
            using (StreamWriter sw = new StreamWriter(bs))
            {
                sw.Write(strAll);
            }
        }

        public static async Task Load(string _pack)
        {
            using (FileStream fs = File.Open(DataLink.strDataDirectory + @"\" + _pack + @"\runways.txt", FileMode.Open, FileAccess.Read, FileShare.Read))
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

                        if (strarrSplit.Length == 3)
                        {
                            list.Add(new Runway(_pack, strarrSplit));
                        }
                        else
                        {
                            Console.WriteLine(strRaw);
                            throw new ArgumentOutOfRangeException("Each line in the file must contain three entries, separated by a '|'");
                        }
                    }
                }
            }
        }

        public static void LoadCurrents(string _file)
        {
            FileStream fs;

            if (!Directory.Exists(DataLink.strPrefsDirectory))
            {
                Directory.CreateDirectory(DataLink.strPrefsDirectory);
            }

            if (!File.Exists(_file))
            {
                fs = File.Create(_file);
            }
            else
            {
                fs = File.Open(_file, FileMode.Open, FileAccess.Read, FileShare.Read);
            }

            using (BufferedStream bs = new BufferedStream(fs))
            using (StreamReader sr = new StreamReader(bs))
            {
                string strRaw;
                while ((strRaw = sr.ReadLine()) != null)
                {
                    if (strRaw.Length > 0 && strRaw.First() != ';')
                    {
                        Runway rwyFind = Find(strRaw);

                        if (rwyFind != null)
                        {
                            if (rwyFind.apOwner.isActiveSet == true)
                            {
                                rwyFind.apOwner.AddActive(rwyFind);
                            }
                            else
                            {
                                rwyFind.apOwner.isActiveSet = true;
                                rwyFind.apOwner.ClearActives();
                                rwyFind.apOwner.AddActive(rwyFind);
                            }
                        }
                    }
                }
            }

            fs.Close();
        }
    }
}
