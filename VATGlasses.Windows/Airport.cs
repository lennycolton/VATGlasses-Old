using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VATGlasses
{
    class Airport
    {
        public static readonly string strDataFile = DataLink.strDataDirectory + @"\airports.txt";
        public static readonly string strFavFile = DataLink.strPrefsDirectory + @"\favairports.txt";

        public static List<Airport> list;
        public static List<Airport> listAlias;
        public static List<Airport> listSorted;
        public static List<Airport> listFavs;

        public int intID { get; private set; }
        public string strICAO { get; private set; }
        public string strName { get; private set; }
        public double dblLat { get; private set; }
        public double dblLon { get; private set; }
        public string[] strarrAlias { get; private set; }
        public string strFIR { get; private set; }
        public bool isInfo { get; private set; }
        public bool isRadio { get; private set; }
        public int intFrom { get; private set; } = 0;
        public int intTo { get; private set; } = 0;
        public bool hasATIS { get; private set; } = false;
        public bool hasTower { get; private set; } = false;
        public bool hasGround { get; private set; } = false;
        public bool hasDelivery { get; private set; } = false;
        public List<ATC> listTower { get; private set; } = new List<ATC>();
        public List<ATC> listGround { get; private set; } = new List<ATC>();
        public List<ATC> listDelivery { get; private set; } = new List<ATC>();
        public List<ATC> listATIS { get; private set; } = new List<ATC>();
        public List<Runway> listRunways { get; private set; } = new List<Runway>();
        public List<Runway> listActive { get; private set; } = new List<Runway>();
        public List<Controller> listTopDown { get; private set; } = new List<Controller>();
        public Controller ctlTopDown { get; private set; }
        public int intTopDown { get; private set; } = 0;
        public int intAerodrome { get; private set; } = 0;
        public bool isActiveSet = false;

        public Airport(int _id, string _icao, string _name, double _lat, double _lon, string[] _alias, string _fir, bool _info, bool _radio, List<Controller> _topdown)
        {
            intID = _id;
            strICAO = _icao;
            strName = _name;
            dblLat = _lat;
            dblLon = _lon;
            strarrAlias = _alias;
            strFIR = _fir;
            isInfo = _info;
            isRadio = _radio;
            listTopDown = _topdown;
        }

        public Airport(string[] _data)
        {
            intID = int.Parse(_data[0], DataLink.DataCulture);
            strICAO = _data[1];
            strName = _data[2];
            dblLat = double.Parse(_data[3], DataLink.DataCulture);
            dblLon = double.Parse(_data[4], DataLink.DataCulture);

            if (_data[5].Length != 0)
            {
                strarrAlias = _data[5].Split(',');
            }
            else
            {
                strarrAlias = new string[0];
            }

            strFIR = _data[6];
            
            if (_data[7] == "1")
            {
                isInfo = true;
            }
            else
            {
                isInfo = false;
            }

            if (_data[8] == "1")
            {
                isRadio = true;
            }
            else
            {
                isRadio = false;
            }

            if (_data.Length > 9)
            {
                for (int i = 9; i < _data.Length; i++)
                {
                    Controller ctlFind = Controller.Find(_data[i]);

                    if (ctlFind != null)
                    {
                        listTopDown.Add(ctlFind);
                    }
                }
            }
        }

        public static async Task Load(string _filename, string _favourites)
        {
            list = new List<Airport>();
            listAlias = new List<Airport>();
            listSorted = new List<Airport>();
            listFavs = new List<Airport>();

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

                        if (strarrSplit.Length >= 9)
                        {
                            Airport apTemp = new Airport(strarrSplit);
                            list.Add(apTemp);

                            if (apTemp.strarrAlias.Length != 0)
                            {
                                listAlias.Add(apTemp);
                            }
                        }
                        else
                        {
                            Console.WriteLine(strRaw);
                            throw new ArgumentOutOfRangeException("Each line in the file must contain at least nine entries, separated by a '|'");
                        }
                    }
                }
            }

            FileStream fsfav;

            if (!Directory.Exists(DataLink.strPrefsDirectory))
            {
                Directory.CreateDirectory(DataLink.strPrefsDirectory);
            }

            if (!File.Exists(_favourites))
            {
                fsfav = File.Create(_favourites);
            }
            else
            {
                fsfav = File.Open(_favourites, FileMode.Open, FileAccess.Read, FileShare.Read);
            }

            using (BufferedStream bs = new BufferedStream(fsfav))
            using (StreamReader sr = new StreamReader(bs))
            {
                string strRaw;
                while ((strRaw = sr.ReadLine()) != null)
                {
                    if (strRaw.Length > 0 && strRaw.First() != ';')
                    {
                        string[] strarrCommented = strRaw.Split(';');
                        strRaw = strarrCommented[0];

                        int intIndex = -1;

                        int.TryParse(strRaw, NumberStyles.None, DataLink.DataCulture, out intIndex);

                        if (intIndex != -1)
                        {
                            listFavs.Add(FindID(intIndex));
                        }
                    }
                }
            }

            fsfav.Close();

            listSorted = Sort(list);
        }

        public static void AssignTopDown()
        {
            foreach (Airport apAp in list)
            {
                apAp.SetTopDown();
            }
        }

        private void SetTopDown()
        {
            intTopDown = 0;

            if (listDelivery.Count > 0)
            {
                intTopDown = 1;
            }
            else if (listGround.Count > 0)
            {
                intTopDown = 2;
            }
            else if (listTower.Count > 0)
            {
                intTopDown = 3;
            }
            else
            {
                foreach (Controller ctlCtl in listTopDown)
                {
                    if (intTopDown == 0 && ctlCtl.atcClient != null)
                    {
                        intTopDown = 4;
                        ctlTopDown = ctlCtl;
                    }
                }
            }
        }

        private bool isFav()
        {
            foreach (Airport apAp in listFavs)
            {
                if (apAp == this)
                {
                    return true;
                }
            }

            return false;
        }

        public void RemoveFav()
        {
            if (!Client.isTempUsed)
            {
                Client.isTempUsed = true;

                if (listFavs.Contains(this))
                {
                    listFavs.Remove(this);
                }

                RemoveFavHidden(strFavFile, Client.strTempFile, intID.ToString());

                Client.isTempUsed = false;
            }
        }

        private void RemoveFavHidden(string _filename, string _tempfile, string _value)
        {
            using (FileStream fs = File.Open(_filename, FileMode.Open, FileAccess.Read, FileShare.Read))
            using (BufferedStream bs = new BufferedStream(fs))
            using (StreamReader sr = new StreamReader(bs))
            {
                try
                {
                    File.Delete(_tempfile);
                }
                catch
                {
                }

                using (StreamWriter sw = new StreamWriter(_tempfile))
                {
                    string strRaw;
                    while ((strRaw = sr.ReadLine()) != null)
                    {
                        if (strRaw != _value)
                        {
                            sw.WriteLine(strRaw);
                        }
                    }
                }
            }

            File.Delete(strFavFile);
            File.Move(_tempfile, _filename); 
        }

        public void AddActive(Runway _runway)
        {
            listActive.Add(_runway);
        }

        public void ClearActives()
        {
            listActive = new List<Runway>();
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

        //Binary Search for class instance from public list.
        public static Airport FindID(int _id)
        {
            Airport airCurrent = null;

            //Set bounds
            int intMidpoint;
            int intMin = 0;
            int intMax = listSorted.Count - 1;

            do
            {
                //Set midpoint
                intMidpoint = (intMin + intMax) / 2;

                //Find midpoint items
                airCurrent = list[intMidpoint];

                //If current is search
                if (airCurrent.intID == _id)
                {
                    return airCurrent;
                }
                //If current is before search
                else if (airCurrent.intID < _id)
                {
                    intMin = intMidpoint + 1;
                }
                //If current is after search
                else if (airCurrent.intID > _id)
                {
                    intMax = intMidpoint - 1;
                }
            } while (intMin <= intMax);

            return null;
        }

        //Binary Search for class instance from public list.
        public static Airport FindICAO(string _icao)
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
                if (string.Compare(airCurrent.strICAO, _icao) == 0)
                {
                    return airCurrent;
                }
                //If current is before search
                else if (string.Compare(airCurrent.strICAO, _icao) < 0)
                {
                    intMin = intMidpoint + 1;
                }
                //If current is after search
                else if (string.Compare(airCurrent.strICAO, _icao) > 0)
                {
                    intMax = intMidpoint - 1;
                }
            } while (intMin <= intMax);

            return null;
        }

        //Binary Search for class instance from public list.
        public static Airport FindAlias(string _alias)
        {
            foreach (Airport apAp in listAlias)
            {
                foreach (string strStr in apAp.strarrAlias)
                {
                    return apAp;
                }
            }

            return null;
        }

        public static Airport FindWithAlias(string _callsign)
        {
            Airport apReturn = FindICAO(_callsign);

            if (apReturn == null)
            {
                return FindAlias(_callsign);
            }
            else
            {
                return apReturn;
            }
        }

        public static List<Airport> FindStartICAO(string _start)
        {
            List<Airport> listResult = new List<Airport>();

            foreach (Airport apAp in list)
            {
                if (apAp.strICAO.StartsWith(_start))
                {
                    listResult.Add(apAp);
                }
            }

            return listResult;
        }

        public static List<Airport> FindStartName(string _start)
        {
            List<Airport> listResult = new List<Airport>();

            foreach (Airport apAp in list)
            {
                if (apAp.strName.StartsWith(_start))
                {
                    listResult.Add(apAp);
                }
            }

            return listResult;
        }

        public void AddFav()
        {
            if (isFav())
            {
                throw new ArgumentException();
            }
            else
            {
                listFavs.Add(this);

                using (StreamWriter sw = File.AppendText(strFavFile))
                {
                    sw.WriteLine(intID);
                }
            }
        }

        public void AddFrom()
        {
            intFrom++;
        }

        public void AddTo()
        {
            intTo++;
        }

        public void AddATIS(ATC _atc)
        {
            if (!hasATIS)
            {
                hasATIS = true;
                intAerodrome += 1;
            }

            listATIS.Add(_atc);
        }

        public void AddTower(ATC _atc)
        {
            if (!hasTower)
            {
                hasTower = true;
                intAerodrome += 8;
            }

            listTower.Add(_atc);
        }

        public void AddGround(ATC _atc)
        {
            if (!hasGround)
            {
                hasGround = true;
                intAerodrome += 4;
            }

            listGround.Add(_atc);
        }

        public void AddDelivery(ATC _atc)
        {
            if (!hasDelivery)
            {
                hasDelivery = true;
                intAerodrome += 2;
            }

            listDelivery.Add(_atc);
        }

        public int AerodromeCount()
        {
            return listDelivery.Count + listGround.Count + listTower.Count + listATIS.Count;
        }

        public void Reset()
        {
            intFrom = 0;
            intTo = 0;
            hasATIS = false;
            hasTower = false;
            hasGround = false;
            hasDelivery = false;
            listDelivery = new List<ATC>();
            listGround = new List<ATC>();
            listTower = new List<ATC>();
            listATIS = new List<ATC>();
            intAerodrome = 0;
        }
    }
}
