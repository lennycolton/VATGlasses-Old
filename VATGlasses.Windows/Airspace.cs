using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VATGlasses
{
    class Airspace
    {
        public static List<Airspace> list;
        public static List<Airspace> listSorted;

        public string strID { get; protected set; }
        public List<Sector> listSectors { get; protected set; }
        public List<Owner> listOwners { get; protected set; }
        public string strName { get; protected set; }
        public string strDescription { get; protected set; }

        public Airspace(string _pack, string _id, List<Sector> _sectors, List<Owner> _owners, string _name, string _description)
        {
            strID = _pack + "/" + _id;
            listSectors = _sectors;
            listOwners = _owners;
            strName = _name;
            strDescription = _description;
        }

        public Airspace(string _pack, string[] _data)
        {
            strID = _pack + @"/" + _data[0];
            listSectors = new List<Sector>();
            foreach (string strStr in _data[1].Split(','))
            {
                if (strStr != "")
                {
                    string[] strarrPackSplit = strStr.Split('/');
                    Sector sctTemp = null;

                    if (strarrPackSplit.Length == 1)
                    {
                        sctTemp = Sector.Find(_pack + "/" + strStr);
                    }
                    else if (strarrPackSplit.Length == 2)
                    {
                        sctTemp = Sector.Find(strStr);
                    }

                    if (sctTemp != null)
                    {
                        listSectors.Add(sctTemp);
                    }
                }
            }

            listOwners = new List<Owner>();
            for (int i = 2; i < _data.Length - 2; i++)
            {
                string[] strarrSplit = _data[i].Split(',');
                if (strarrSplit.Length == 4 && strarrSplit[0] != "")
                {
                    listOwners.Add(new Owner(_pack, strarrSplit));
                }
            }

            strName = _data[_data.Length - 2].Trim(' ');
            strDescription = _data[_data.Length - 1].Trim(' ');
        }

        public Sector FindSector(string _id)
        {
            //Set bounds
            int intMidpoint;
            int intMin = 0;
            List<Sector> listSectorsSorted = Sector.Sort(listSectors);
            int intMax = listSectorsSorted.Count - 1;

            do
            {
                //Set midpoint
                intMidpoint = (intMin + intMax) / 2;

                //Find midpoint items
                Sector sctCurrent = listSectorsSorted[intMidpoint];

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

        private bool Assign()
        {
            foreach (Owner ownOwn in listOwners)
            {
                if (ownOwn.ctlStation.atcClient != null)
                {
                    ownOwn.ctlStation.Add(this, ownOwn);
                    return true;
                }
            }

            return false;
        }

        public static void AssignAll()
        {
            foreach (Airspace aspAsp in list)
            {
                aspAsp.Assign();
            }

            foreach (Controller ctlCtl in Controller.list)
            {
                ctlCtl.SortAirspace();
            }
        }

        public static List<Airspace> Sort(List<Airspace> _list)
        {
            if (_list.Count <= 1)
            {
                return _list;
            }

            int midpoint = _list.Count / 2;

            List<Airspace> left = new List<Airspace>();
            List<Airspace> right = new List<Airspace>();

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

        private static List<Airspace> Combine(List<Airspace> _left, List<Airspace> _right)
        {
            List<Airspace> sorted = new List<Airspace>();

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

        public static async Task Load(string _pack)
        {
            using (FileStream fs = File.Open(DataLink.strDataDirectory + @"\" + _pack + @"\airspace.txt", FileMode.Open, FileAccess.Read, FileShare.Read))
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

                        if (strarrSplit.Length >= 4)
                        {
                            list.Add(new Airspace(_pack, strarrSplit));
                        }
                        else
                        {
                            Console.WriteLine(strRaw);
                            throw new ArgumentOutOfRangeException("Each line in the file must contain five entries, separated by a '|'");
                        }
                    }
                }
            }
        }
    }
}
