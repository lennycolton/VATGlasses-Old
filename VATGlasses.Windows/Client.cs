using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VATGlasses
{
    class Client
    {
        public static readonly string strCIDFile = DataLink.strPrefsDirectory + @"\favusers.txt";
        public static readonly string strCSFile = DataLink.strPrefsDirectory + @"\favcallsigns.txt";
        public static readonly string strTempFile = DataLink.strPrefsDirectory + @"\favtempinternalvatglasses.txt";
        public static bool isTempUsed;

        public static List<Client> list { get; private set; }
        public static List<FavClient> listFavs { get; private set; }
        public static List<int> listFavCIDs { get; private set; }
        public static List<string> listFavCSs { get; private set; }

        public string strCallsign { get; protected set; }
        public int intCID { get; protected set; }
        public string strName { get; protected set; }
        public bool isFav { get; protected set; }

        public Client(string[] _data)
        {
            strCallsign = _data[0];

            if (int.TryParse(_data[1], NumberStyles.Integer, DataLink.DataCulture, out int intTemp))
            {
                intCID = intTemp;
            }
            else
            {
                intCID = -1;
            }

            strName = _data[2];
        }

        public static void Reset()
        {
            list = new List<Client>();
            listFavs = new List<FavClient>();
        }

        public static void Add(Client _client)
        {
            list.Add(_client);
        }

        public static List<Client> FindStart(string _start)
        {
            List<Client> listResult = new List<Client>();

            foreach (Client cltClt in list)
            {
                if (cltClt.strCallsign.StartsWith(_start) || cltClt.intCID.ToString().StartsWith(_start))
                {
                    listResult.Add(cltClt);
                }
            }

            return listResult;
        }

        public void RemoveFav()
        {
            isFav = false;
        }

        public static Client Find(int _cid)
        {
            foreach (Client cltClt in list)
            {
                if (cltClt.intCID == _cid)
                {
                    return cltClt;
                }
            }

            return null;
        }

        private static Client FindNoATIS(int _cid)
        {
            foreach (Client cltClt in list)
            {
                if (cltClt.intCID == _cid)
                {
                    if (cltClt is ATC)
                    {
                        if (cltClt.strCallsign.Split('_').Last() != "ATIS")
                        {
                            return cltClt;
                        }
                    }
                    else
                    {
                        return cltClt;
                    }
                }
            }

            return null;
        }

        public static Client Find(string _cs)
        {
            foreach (Client cltClt in list)
            {
                if (cltClt.strCallsign == _cs)
                {
                    return cltClt;
                }
            }

            return null;
        }

        public static async Task LoadFavs()
        {
            listFavs = new List<FavClient>();
            listFavCIDs = new List<int>();
            listFavCSs = new List<string>();

            FileStream fsCID;
            FileStream fsCS;

            if (!Directory.Exists(DataLink.strPrefsDirectory))
            {
                Directory.CreateDirectory(DataLink.strPrefsDirectory);
            }

            if (!File.Exists(strCIDFile))
            {
                fsCID = File.Create(strCIDFile);
            }
            else
            {
                fsCID = File.Open(strCIDFile, FileMode.Open, FileAccess.Read, FileShare.Read);
            }

            using (BufferedStream bs = new BufferedStream(fsCID))
            using (StreamReader sr = new StreamReader(bs))
            {
                string strRaw;
                while ((strRaw = sr.ReadLine()) != null)
                {
                    if (strRaw.Length > 0 && strRaw.First() != ';')
                    {
                        int intCID = -1;

                        int.TryParse(strRaw, NumberStyles.Integer, DataLink.DataCulture, out intCID);

                        if (intCID != -1)
                        {
                            listFavCIDs.Add(intCID);
                        }
                    }
                }
            }

            fsCID.Close();

            if (!File.Exists(strCSFile))
            {
                fsCS = File.Create(strCSFile);
            }
            else
            {
                fsCS = File.Open(strCSFile, FileMode.Open, FileAccess.Read, FileShare.Read);
            }

            using (BufferedStream bs = new BufferedStream(fsCS))
            using (StreamReader sr = new StreamReader(bs))
            {
                string strRaw;
                while ((strRaw = sr.ReadLine()) != null)
                {
                    if (strRaw.Length > 0 && strRaw.First() != ';')
                    {
                        listFavCSs.Add(strRaw);
                    }
                }
            }

            fsCS.Close();
        }

        public static void UpdateFavs()
        {
            foreach (Client cltClt in list)
            {
                cltClt.isFav = false;
            }

            listFavs = new List<FavClient>();
            List<string> listTempCS = new List<string>(listFavCSs);

            foreach (int intInt in listFavCIDs)
            {
                Client cltTemp = FindNoATIS(intInt);

                FavClient fvcFvc = new FavClient(cltTemp, null, intInt);

                if (cltTemp != null)
                {
                    fvcFvc.cltClient.isFav = true;

                    if (listTempCS.Contains(cltTemp.strCallsign))
                    {
                        fvcFvc.strCallsign = cltTemp.strCallsign;
                        listTempCS.Remove(cltTemp.strCallsign);
                    }
                }

                listFavs.Add(fvcFvc);
            }

            foreach (string strStr in listTempCS)
            {
                Client cltTemp = Find(strStr);

                if (cltTemp != null)
                {
                    cltTemp.isFav = true;
                }

                listFavs.Add(new FavClient(cltTemp, strStr));
            }
        }

        public void AddFavCID()
        {
            FavClient fvcTemp = FavClient.FindClient(intCID);
            isFav = true;

            if (fvcTemp == null)
            {
                listFavs.Add(new FavClient(this, null, intCID));
                listFavCIDs.Add(intCID);

                using (StreamWriter sw = File.AppendText(strCIDFile))
                {
                    sw.WriteLine(intCID);
                }
            }
            else if (fvcTemp.intCID == null)
            {
                fvcTemp.intCID = intCID;
                listFavCIDs.Add(intCID);

                using (StreamWriter sw = File.AppendText(strCIDFile))
                {
                    sw.WriteLine(intCID);
                }
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public void AddFavCS()
        {
            FavClient fvcTemp = FavClient.FindClient(strCallsign);
            isFav = true;

            if (fvcTemp == null)
            {
                listFavs.Add(new FavClient(this, strCallsign));
                listFavCSs.Add(strCallsign);

                using (StreamWriter sw = File.AppendText(strCSFile))
                {
                    sw.WriteLine(strCallsign);
                }
            }
            else if (fvcTemp.strCallsign == null)
            {
                fvcTemp.strCallsign = strCallsign;
                listFavCSs.Add(strCallsign);

                using (StreamWriter sw = File.AppendText(strCSFile))
                {
                    sw.WriteLine(strCallsign);
                }
            }
            else
            {
                throw new ArgumentException();
            }
        }
    } 
}
