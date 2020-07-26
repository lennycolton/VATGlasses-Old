using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VATGlasses
{
    class FavClient
    {
        public Client cltClient;
        public string strCallsign;
        public int? intCID;

        public FavClient(Client _client = null, string _callsign = null, int? _cid = null)
        {
            cltClient = _client;
            strCallsign = _callsign;
            intCID = _cid;
        }

        public static FavClient FindClient(int _cid)
        {
            foreach (FavClient fvcFvc in Client.listFavs)
            {
                if (fvcFvc.cltClient != null && fvcFvc.cltClient.intCID == _cid)
                {
                    return fvcFvc;
                }
            }

            return null;
        }

        public static FavClient FindClient(string _cs)
        {
            foreach (FavClient fvcFvc in Client.listFavs)
            {
                if (fvcFvc.cltClient != null && fvcFvc.cltClient.strCallsign == _cs)
                {
                    return fvcFvc;
                }
            }

            return null;
        }

        public void RemoveCallsign()
        {
            if (!Client.isTempUsed)
            {
                Client.isTempUsed = true;

                Remove(Client.strCSFile, Client.strTempFile, strCallsign.ToString());

                strCallsign = null;

                if (intCID == null)
                {
                    Client.listFavs.Remove(this);
                    cltClient.RemoveFav();
                }

                Client.isTempUsed = false;
            }
        }

        public void RemoveCID()
        {
            if (!Client.isTempUsed)
            {
                Client.isTempUsed = true;

                Remove(Client.strCIDFile, Client.strTempFile, intCID.ToString());

                intCID = null;

                if (strCallsign == null)
                {
                    Client.listFavs.Remove(this);
                    cltClient.RemoveFav();
                }

                Client.isTempUsed = false;
            }
        }

        private void Remove(string _filename, string _tempfile,string _value)
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

            File.Delete(_filename);
            File.Move(_tempfile, _filename);
        }
    }
}
