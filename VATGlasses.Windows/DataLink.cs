using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Text.RegularExpressions;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Globalization;

namespace VATGlasses
{
    class DataLink
    {
        public static readonly string strUserDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\VATGlasses";
        public static readonly string strDataDirectory = strUserDirectory + @"\data";
        public static readonly string strOldDataDirectory = strUserDirectory + @"\olddata";
        public static readonly string strPrefsDirectory = strUserDirectory + @"\prefs";
        public static DataLink Current;
        private const string strVersionURL = "http://vatglasses.ga/releases/version.txt";
        private string strStatusURL = "http://status.vatsim.net/";
        public static readonly CultureInfo DataCulture = new CultureInfo("en-GB");

        //Status Properties
        string strMessage;
        List<string> listFull;
        string strMETAR;
        string strUser;

        //General Data
        public int intVersion { get; private set; }
        public decimal decReload { get; private set; }
        public DateTime dtUpdate { get; private set; }
        public int intConnected { get; private set; }

        //Server Data
        public List<Server> listServers { get; private set; }

        public DataLink() { }

        //public void CheckVersion()
        //{
        //    WebClient wcTemp = new WebClient();
        //    wcTemp.DownloadFile(strVersionURL, "version.txt");

        //    string strRaw = File.ReadAllText("version.txt");
        //    File.Delete("version.txt");

        //    string[] split = strRaw.Split('.');

        //    Version verCurrent = Assembly.GetExecutingAssembly().GetName().Version;
        //    Version verNew = new Version(int.Parse(split[0], DataCulture), int.Parse(split[1], DataCulture), int.Parse(split[2], DataCulture), int.Parse(split[3], DataCulture));

        //    if (verCurrent.CompareTo(verNew) < 0)
        //    {
        //        MessageBox.Show("Version " + verNew.ToString() + " is now available from the VATGlasses website. Update to get all of the latest features!", "Update Available", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //}

        public void PullStatus()
        {
            bool isMoved = false;
            listFull = new List<string>();

            do
            {
                WebClient wcTemp = new WebClient();
                string strRaw = wcTemp.DownloadString(strStatusURL);
                foreach (string strStr in strRaw.Split(new string[] { "\r\n" }, StringSplitOptions.None))
                {
                    if (strStr.Length != 0 && strStr[0] != ';')
                    {
                        Console.WriteLine(strStr);
                        string[] strSplit = strStr.Split('=');
                        switch (strSplit[0])
                        {
                            case "msg0":
                                strMessage = strSplit[1];
                                break;
                            case "url0":
                                listFull.Add(strSplit[1]);
                                break;
                            case "moveto0":
                                isMoved = true;
                                strStatusURL = strSplit[1];
                                break;
                            case "metar0":
                                strMETAR = strSplit[1];
                                break;
                            case "user0":
                                strUser = strSplit[1];
                                break;
                            default:
                                break;
                        }
                    }
                }
            } while (isMoved);
        }

        public static void LoadFiles()
        {
            if (!Directory.Exists(strDataDirectory))
            {
                Directory.CreateDirectory(strDataDirectory);
            }

            if (!Directory.Exists(strPrefsDirectory))
            {
                Directory.CreateDirectory(strPrefsDirectory);
            }

            List<Task> listStandaloneTasks = new List<Task>();

            listStandaloneTasks.Add(Country.Load(Country.strDataFile));
            listStandaloneTasks.Add(FIR.Load(FIR.strDataFile));

            Task tskFavs = Client.LoadFavs();

            string[] strarrDirectories = Directory.GetDirectories(strDataDirectory);

            for (int i = 0; i < strarrDirectories.Length; i++)
            {
                strarrDirectories[i] = strarrDirectories[i].Split('\\').Last();
            }

            Controller.list = new List<Controller>();
            List<Task> listControllerTasks = new List<Task>();

            foreach (string strStr in strarrDirectories)
            {
                listControllerTasks.Add(Controller.Load(strStr));
            }

            Task.WaitAll(listControllerTasks.ToArray());
            Controller.SortAsync().Wait();

            Task.WaitAll(listStandaloneTasks.ToArray());

            Airport.Load(Airport.strDataFile, Airport.strFavFile).Wait();

            Runway.list = new List<Runway>();
            List<Task> listRunwayTasks = new List<Task>();

            foreach (string strStr in strarrDirectories)
            {
                listRunwayTasks.Add(Runway.Load(strStr));
            }

            Task.WaitAll(listRunwayTasks.ToArray());

            Runway.listSorted = Runway.Sort(Runway.list);
            Runway.LoadCurrents(Runway.strCurrentFile);

            Sector.list = new List<Sector>();
            List<Task> listSectorTasks = new List<Task>();

            foreach (string strStr in strarrDirectories)
            {
                listSectorTasks.Add(Sector.Load(strStr));
            }

            Task.WaitAll(listSectorTasks.ToArray());
            Sector.SortAsync().Wait();

            Airspace.list = new List<Airspace>();
            List<Task> listAirspaceTasks = new List<Task>();

            foreach (string strStr in strarrDirectories)
            {
                listAirspaceTasks.Add(Airspace.Load(strStr));
            }

            Task.WaitAll(listAirspaceTasks.ToArray());
            Airspace.listSorted = Airspace.Sort(Airspace.list);

            Task.WaitAll(tskFavs);
        }

        public void Pull()
        {
            foreach (Airport apAp in Airport.listSorted)
            {
                apAp.Reset();
            }

            Client.Reset();
            Pilot.Reset();
            FPlan.ResetPrefiles();
            ATC.Reset();
            ATC.ResetOBS();
            Server.Reset();

            int intCurrent = 0;

            Random rndTemp = new Random();
            int intIndex = rndTemp.Next(0, listFull.Count - 1);

            WebClient wcTemp = new WebClient();
            string strRaw = wcTemp.DownloadString(listFull[intIndex]);

            foreach (string strStr in strRaw.Split(new string[] { "\n" }, StringSplitOptions.None))
            {
                if (strStr.Length != 0 && strStr[0] != ';')
                {
                    if (strStr[0] == '!')
                    {
                        switch(strStr.Substring(1, 7))
                        {
                            case "GENERAL":
                                intCurrent = 1;
                                break;
                            case "CLIENTS":
                                intCurrent = 2;
                                break;
                            case "SERVERS":
                                intCurrent = 3;
                                break;
                            case "PREFILE":
                                intCurrent = 4;
                                break;
                        }
                    }
                    else
                    {
                        string[] strarrTemp;
                        switch (intCurrent)
                        {
                            case 1:
                                strarrTemp = Regex.Replace(strStr, @"\s+", "").Split('=');
                                switch (strarrTemp[0])
                                {
                                    case "VERSION":
                                        intVersion = int.Parse(strarrTemp[1], DataCulture);

                                        //if (intVersion != Properties.Settings.Default.DataVersion)
                                        //{
                                            //MessageBox.Show("This version of VATGlasses was designed for an old version of the VATSIM.net Status API. Please update to the latest version. If this is currently the latest version, please submit a bug report at our website.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            //Environment.Exit(0);
                                        //}

                                        break;
                                    case "RELOAD":
                                        decReload = decimal.Parse(strarrTemp[1], DataCulture);
                                        break;
                                    case "UPDATE":
                                        dtUpdate = new DateTime(int.Parse(strarrTemp[1].Substring(0, 4), DataCulture), int.Parse(strarrTemp[1].Substring(4, 2), DataCulture), int.Parse(strarrTemp[1].Substring(6, 2), DataCulture), int.Parse(strarrTemp[1].Substring(8, 2), DataCulture), int.Parse(strarrTemp[1].Substring(10, 2), DataCulture), int.Parse(strarrTemp[1].Substring(12, 2), DataCulture));
                                        break;
                                    case "CONNECTEDCLIENTS":
                                        intConnected = int.Parse(strarrTemp[1], DataCulture);
                                        break;
                                    default:
                                        break;
                                }
                                break;
                            case 2:
                                strarrTemp = strStr.Split(':');
                                Client cltTemp = null;

                                if (strarrTemp[3] == "PILOT")
                                {
                                    cltTemp = new Pilot(strarrTemp);
                                    Pilot.Add((Pilot)cltTemp);
                                }
                                else if (strarrTemp[3] == "ATC")
                                {
                                    if (isATC(strarrTemp[0], strarrTemp[18]))
                                    {
                                        cltTemp = ATC.Add(strarrTemp, false);
                                    }
                                    else
                                    {
                                        cltTemp = ATC.Add(strarrTemp, true);
                                    }
                                }

                                int intCID = -1;
                                int.TryParse(strarrTemp[1], NumberStyles.None, DataCulture, out intCID);

                                //if (Client.listFavCSs.Contains(strarrTemp[0]) && Client.listFavCIDs.Contains(intCID))
                                //{
                                //    Client.listFavs.Add(new FavClient(cltTemp, cltTemp.strCallsign, intCID));
                                //}
                                //else if (Client.listFavCSs.Contains(strarrTemp[0]))
                                //{
                                //    Client.listFavs.Add(new FavClient(cltTemp, cltTemp.strCallsign, null));
                                //}
                                //else if (Client.listFavCIDs.Contains(intCID))
                                //{
                                //    Client.listFavs.Add(new FavClient(cltTemp, null, intCID));
                                //}
                                break;
                            case 3:
                                Server.Add(new Server(strStr.Split(':')));
                                break;
                            case 4:
                                FPlan.AddPrefile(new FPlan(strStr.Split(':')));
                                break;
                            default:
                                break;
                        }
                    }
                }
            }

            Pilot.SortList();
            ATC.SortList();
            Controller.AssignAll();
            Airport.AssignTopDown();
            Client.UpdateFavs();
        }

        public string GetMETAR(string _ICAO)
        {
            WebClient wcTemp = new WebClient();
            string strResult = wcTemp.DownloadString(strMETAR + "?id=" + _ICAO);

            if (strResult == null || strResult == "")
            {
                strResult = "Airport not found.";
            }

            return strResult;
        }

        private bool isATC(string _callsign, string _facility)
        {
            string[] strarrValid = new string[] { "DEL", "GND", "TWR", "APP", "DEP", "CTR", "FSS", "ATIS" };
            int intFacility = 0;

            int.TryParse(_facility, NumberStyles.None, DataCulture, out intFacility);

            if (intFacility > 0)
            {
                string strEnd = _callsign.Split('_').Last();

                foreach (string strStr in strarrValid)
                {
                    if (strEnd == strStr)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
