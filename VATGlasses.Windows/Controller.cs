using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VATGlasses
{
    class Controller
    {
        private static bool isSet = false;
        public static List<Controller> list;
        public static List<Controller> listActive;
        public static List<Controller> listSorted;

        public string strID { get; private set; }
        public string strStart { get; private set; }
        public string strEnd { get; private set; }
        public decimal? decFreq { get; private set; }
        public string strFIR { get; private set; }
        public string strCallsign { get; private set; }
        public ATC atcClient { get; private set; }
        public List<OwnedAirspace> listOwned { get; private set; }

        public Controller(string _pack, string _id, string _start, string _end, decimal _freq, string _fir, string _callsign)
        {
            strID = _pack + "/" + _id;
            strStart = _start;
            strEnd = _end;
            decFreq = _freq;
            strFIR = _fir;
            strCallsign = _callsign;
            atcClient = null;
            listOwned = new List<OwnedAirspace>();
        }

        public Controller(string _pack, string _id, string _start, string _end, decimal _freq, string _fir, string _callsign, ATC _client)
        {
            strID = _pack + "/" + _id;
            strStart = _start;
            strEnd = _end;
            decFreq = _freq;
            strFIR = _fir;
            strCallsign = _callsign;
            atcClient = _client;
            listOwned = new List<OwnedAirspace>();
        }

        public Controller(string _pack, string[] _data)
        {
            strID = _pack + "/" + _data[0];
            strStart = _data[1];
            strEnd = _data[2];

            if (decimal.TryParse(_data[3], NumberStyles.Float, DataLink.DataCulture, out decimal decParse))
            {
                decFreq = decParse;
            }
            else
            {
                decFreq = null;
            }

            strFIR = _data[4];
            strCallsign = _data[5].Trim(' ');
            atcClient = null;
            listOwned = new List<OwnedAirspace>();
        }

        public void Add(OwnedAirspace _ownedairspace)
        {
            listOwned.Add(_ownedairspace);
        }

        public void Add(Airspace _airspace, Owner _owner)
        {
            listOwned.Add(new OwnedAirspace(_airspace, _owner));
        }

        public void Reset()
        {
            atcClient = null;
            listOwned = new List<OwnedAirspace>();
        }

        public void SortAirspace()
        {
            listOwned = OwnedAirspace.Sort(listOwned);
        }

        public static void AssignAll()
        {
            listActive = new List<Controller>();

            if (isSet)
            {
                foreach (Controller ctlCtl in list)
                {
                    ctlCtl.Reset();
                    if (ctlCtl.SetClient())
                    {
                        listActive.Add(ctlCtl);
                    }
                }
            }
            else
            {
                foreach (Controller ctlCtl in list)
                {
                    if (ctlCtl.SetClient())
                    {
                        listActive.Add(ctlCtl);
                    }
                }
            }

            isSet = true;
            Airspace.AssignAll();
        }

        public static Tuple<Airspace, Sector> FindSector(string _controller, string _airspace, string _sector)
        {
            Controller ctlTemp = Find(_controller);
            if (ctlTemp != null)
            {
                OwnedAirspace owaTemp = ctlTemp.FindOwnedAirspace(_airspace);
                if (owaTemp != null)
                {
                    Sector sctTemp = owaTemp.aspAirspace.FindSector(_sector);
                    if (sctTemp != null)
                    {
                        Sector sctReturn = new Sector(sctTemp);

                        if (owaTemp.intMinAlt > sctReturn.intMinAlt || sctReturn.intMinAlt == null)
                        {
                            sctReturn.intMinAlt = owaTemp.intMinAlt;
                        }

                        if (owaTemp.intMaxAlt < sctReturn.intMaxAlt || sctReturn.intMaxAlt == null)
                        {
                            sctReturn.intMaxAlt = owaTemp.intMaxAlt;
                        }

                        return new Tuple<Airspace, Sector>(owaTemp.aspAirspace, sctReturn);
                    }
                }
            }

            return null;
        }

        public static Controller Find(string _id)
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
                Controller ctlCurrent = listSorted[intMidpoint];

                //If current is search
                if (string.Compare(ctlCurrent.strID, _id) == 0)
                {
                    return ctlCurrent;
                }
                //If current is before search
                else if (string.Compare(ctlCurrent.strID, _id) < 0)
                {
                    intMin = intMidpoint + 1;
                }
                //If current is after search
                else if (string.Compare(ctlCurrent.strID, _id) > 0)
                {
                    intMax = intMidpoint - 1;
                }
            } while (intMin <= intMax);

            return null;
        }

        private OwnedAirspace FindOwnedAirspace(string _id)
        {
            //Set bounds
            int intMidpoint;
            int intMin = 0;

            if (listOwned.Count > 0)
            {
                int intMax = listOwned.Count - 1;

                do
                {
                    //Set midpoint
                    intMidpoint = (intMin + intMax) / 2;

                    //Find midpoint items
                    OwnedAirspace owaCurrent = listOwned[intMidpoint];

                    //If current is search
                    if (string.Compare(owaCurrent.aspAirspace.strID, _id) == 0)
                    {
                        return owaCurrent;
                    }
                    //If current is before search
                    else if (string.Compare(owaCurrent.aspAirspace.strID, _id) < 0)
                    {
                        intMin = intMidpoint + 1;
                    }
                    //If current is after search
                    else if (string.Compare(owaCurrent.aspAirspace.strID, _id) > 0)
                    {
                        intMax = intMidpoint - 1;
                    }
                } while (intMin <= intMax);
            }

            return null;
        }

        private bool SetClient()
        {
            if (ATC.list.Count() == 0)
            {
                return false;
            }

            ATC atcCurrent;
            string[] strarrCurrent;
            List<ATC> listResults = new List<ATC>();
            bool isFound = false;

            //Set bounds
            int intCurrent;
            int intMidpoint;
            int intMin = 0;
            int intMax = ATC.list.Count - 1;

            do
            {
                //Set midpoint
                intMidpoint = (intMin + intMax) / 2;

                //Find midpoint items
                atcCurrent = ATC.list[intMidpoint];
                strarrCurrent = atcCurrent.strCallsign.Split('_');

                //If current is search
                if (string.Compare(strarrCurrent[0], strStart) == 0)
                {
                    //Add current element to results list
                    listResults = new List<ATC>();
                    if (strarrCurrent.Last() == strEnd)
                    {
                        listResults.Add(atcCurrent);
                    }

                    if (intMidpoint > 0)
                    {
                        //Add all matching above
                        intCurrent = intMidpoint - 1;
                        atcCurrent = ATC.list[intCurrent];
                        strarrCurrent = atcCurrent.strCallsign.Split('_');

                        while (strarrCurrent[0] == strStart && intCurrent > 0)
                        {
                            if (strarrCurrent.Last() == strEnd)
                            {
                                listResults.Add(atcCurrent);
                            }
                            intCurrent = intCurrent - 1;
                            atcCurrent = ATC.list[intCurrent];
                            strarrCurrent = atcCurrent.strCallsign.Split('_');
                        }
                    }

                    if (intMidpoint < ATC.list.Count - 1)
                    {
                        //Add all matching below
                        intCurrent = intMidpoint + 1;
                        atcCurrent = ATC.list[intCurrent];
                        strarrCurrent = atcCurrent.strCallsign.Split('_');

                        while (strarrCurrent[0] == strStart && intCurrent < ATC.list.Count - 1)
                        {
                            if (strarrCurrent.Last() == strEnd)
                            {
                                listResults.Add(atcCurrent);
                            }
                            intCurrent = intCurrent + 1;
                            atcCurrent = ATC.list[intCurrent];
                            strarrCurrent = atcCurrent.strCallsign.Split('_');
                        }
                    }

                    //Exit loop
                    isFound = true;
                }
                //If current is before search
                else if (string.Compare(strarrCurrent[0], strStart) < 0)
                {
                    intMin = intMidpoint + 1;
                }
                //If current is after search
                else if (string.Compare(strarrCurrent[0], strStart) > 0)
                {
                    intMax = intMidpoint - 1;
                }
            } while (intMin <= intMax && !isFound);

            foreach (ATC atcAtc in listResults)
            {
                if (atcAtc.decFreq == decFreq && atcAtc.decFreq != (decimal)199.998)
                {
                    atcClient = atcAtc;
                    atcClient.Controller = this;
                    return true;
                }
            }

            return false;
        }

        public static async Task SortAsync()
        {
            listSorted = Sort(list);
        }

        public static List<Controller> Sort(List<Controller> _list)
        {
            if (_list.Count <= 1)
            {
                return _list;
            }

            int midpoint = _list.Count / 2;

            List<Controller> left = new List<Controller>();
            List<Controller> right = new List<Controller>();

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

        private static List<Controller> Combine(List<Controller> _left, List<Controller> _right)
        {
            List<Controller> sorted = new List<Controller>();

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
            using (FileStream fs = File.Open(DataLink.strDataDirectory + @"\" + _pack + @"\controllers.txt", FileMode.Open, FileAccess.Read, FileShare.Read))
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

                        if (strarrSplit.Length == 6)
                        {
                            list.Add(new Controller(_pack, strarrSplit));
                        }
                        else
                        {
                            Console.WriteLine(strRaw);
                            throw new ArgumentOutOfRangeException("Each line in the file must contain six entries, separated by a '|'");
                        }
                    }
                }
            }
        }
    }
}
