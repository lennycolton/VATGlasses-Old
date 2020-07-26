using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Net;
using System.IO;
using System.IO.Compression;
using System.Reflection;

namespace VATGlasses
{
    class GitUpdater
    {
        string strJSON = "";
        public GitHubAPIData apiData;
        int intClient = -1;
        WebClient client;
        string strCurrentVersion;

        public GitUpdater()
        {
        }

        public bool[] CheckPrefs()
        {
            bool[] isarrReturn = new bool[4];

            if (!Directory.Exists(DataLink.strUserDirectory))
            {
                Directory.CreateDirectory(DataLink.strUserDirectory);
            }

            if (!Directory.Exists(DataLink.strDataDirectory))
            {
                Directory.CreateDirectory(DataLink.strDataDirectory);
            }

            if (File.Exists(DataLink.strDataDirectory + @"\currentrunways.txt"))
            {
                isarrReturn[0] = true;
            }
            else
            {
                isarrReturn[0] = false;
            }

            if (File.Exists(DataLink.strDataDirectory + @"\favairports.txt"))
            {
                isarrReturn[1] = true;
            }
            else
            {
                isarrReturn[1] = false;
            }

            if (File.Exists(DataLink.strDataDirectory + @"\favcallsigns.txt"))
            {
                isarrReturn[2] = true;
            }
            else
            {
                isarrReturn[2] = false;
            }

            if (File.Exists(DataLink.strDataDirectory + @"\favusers.txt"))
            {
                isarrReturn[3] = true;
            }
            else
            {
                isarrReturn[3] = false;
            }

            return isarrReturn;
        }

        public void MovePrefs(bool[] _files)
        {
            if (!Directory.Exists(DataLink.strPrefsDirectory))
            {
                Directory.CreateDirectory(DataLink.strPrefsDirectory);
            }

            if (_files[0])
            {
                if (File.Exists(Runway.strCurrentFile))
                {
                    File.Delete(Runway.strCurrentFile);
                }

                File.Move(DataLink.strDataDirectory + @"\currentrunways.txt", Runway.strCurrentFile);
            }

            if (_files[1])
            {
                if (File.Exists(Airport.strFavFile))
                {
                    File.Delete(Airport.strFavFile);
                }

                File.Move(DataLink.strDataDirectory + @"\favairports.txt", Airport.strFavFile);
            }

            if (_files[2])
            {
                if (File.Exists(Client.strCSFile))
                {
                    File.Delete(Client.strCSFile);
                }

                File.Move(DataLink.strDataDirectory + @"\favcallsigns.txt", Client.strCSFile);
            }

            if (_files[3])
            {
                if (File.Exists(Client.strCIDFile))
                {
                    File.Delete(Client.strCIDFile);
                }

                File.Move(DataLink.strDataDirectory + @"\favusers.txt", Client.strCIDFile);
            }
        }

        public Tuple<bool[],Version[]> CheckUpdate()
        {
            Version verMinProgramVersion = Assembly.GetExecutingAssembly().GetName().Version;
            Version verMaxProgramVersion = Assembly.GetExecutingAssembly().GetName().Version;

            bool isDataPresent = false;
            bool isNewDataVersion = false;
            bool isProgramVersionTooLow = false;
            bool isProgramVersionTooHigh = false;

            GetLatestInfo();

            if (!Directory.Exists(DataLink.strUserDirectory))
            {
                Directory.CreateDirectory(DataLink.strUserDirectory);
            }

            if (!Directory.Exists(DataLink.strDataDirectory))
            {
                Directory.CreateDirectory(DataLink.strDataDirectory);
            }

            if (File.Exists(DataLink.strDataDirectory + @"\version.txt"))
            {
                isDataPresent = true;
                strCurrentVersion = File.ReadAllText(DataLink.strDataDirectory + @"\version.txt");

                if (strCurrentVersion != apiData.strTag)
                {
                    isNewDataVersion = true;
                }
            }
            else
            {
                strCurrentVersion = apiData.strTag + "_NoCurrentFound";
                isNewDataVersion = true;
            }

            WebClient wcTemp = new WebClient();

            foreach (GitHubAPIAsset astAst in apiData.listAssets)
            {
                if (astAst.strName == "minversion.txt")
                {
                    string strMinVersion = wcTemp.DownloadString(astAst.strURL);
                    verMinProgramVersion = new Version(strMinVersion);
                }
                else if (astAst.strName == "maxversion.txt")
                {
                    string strMaxVersion = wcTemp.DownloadString(astAst.strURL);
                    verMaxProgramVersion = new Version(strMaxVersion);
                }
            }

            if (Assembly.GetExecutingAssembly().GetName().Version.CompareTo(verMinProgramVersion) < 0)
            {
                isProgramVersionTooLow = true;
            }

            if (Assembly.GetExecutingAssembly().GetName().Version.CompareTo(verMaxProgramVersion) > 0)
            {
                isProgramVersionTooHigh = true;
            }

            return new Tuple<bool[], Version[]>(new bool[] { isDataPresent, isNewDataVersion, isProgramVersionTooLow, isProgramVersionTooHigh }, new Version[] { verMinProgramVersion, verMaxProgramVersion });
        }

        private void GetLatestInfo()
        {
            ResetClient();
            strJSON = client.DownloadString("https://api.github.com/repos/lennycolton/VATGlasses-Data/releases/latest");
            apiData = JsonSerializer.Deserialize<GitHubAPIData>(strJSON);
        }

        public void Update()
        {
            if (!Directory.Exists(DataLink.strDataDirectory))
            {
                Directory.CreateDirectory(DataLink.strDataDirectory);
            }

            List<string> listFiles = Directory.GetFiles(DataLink.strDataDirectory, "*.*", SearchOption.TopDirectoryOnly).ToList();
            List<string> listDirs = Directory.GetDirectories(DataLink.strDataDirectory, "*.*", SearchOption.TopDirectoryOnly).ToList();
            string strPath = DataLink.strOldDataDirectory + @"\" + strCurrentVersion;

            if (!Directory.Exists(DataLink.strOldDataDirectory))
            {
                Directory.CreateDirectory(DataLink.strOldDataDirectory);
            }

            if (Directory.Exists(strPath))
            {
                bool isCreated = false;
                int i = 0;

                do
                {
                    if (Directory.Exists(strPath + "_" + i))
                    {
                        i++;
                    }
                    else
                    {
                        strPath += "_" + i;
                        Directory.CreateDirectory(strPath);
                        isCreated = true;
                    }
                } while (!isCreated);
            }
            else
            {
                Directory.CreateDirectory(strPath);
            }

            foreach (string strFile in listFiles)
            {
                FileInfo finFile = new FileInfo(strFile);
                finFile.MoveTo(strPath + @"\" + finFile.Name);
            }

            foreach (string strDir in listDirs)
            {
                DirectoryInfo dinDir = new DirectoryInfo(strDir);
                dinDir.MoveTo(strPath + @"\" + dinDir.Name);
            }

            if (File.Exists(DataLink.strDataDirectory + @"\newdata.zip"))
            {
                File.Delete(DataLink.strDataDirectory + @"\newdata.zip");
            }

            if (Directory.Exists(DataLink.strDataDirectory + @"\newdata"))
            {
                Directory.Delete(DataLink.strDataDirectory + @"\newdata");
            }

            ResetClient();
            client.DownloadFile(apiData.strURL, DataLink.strDataDirectory + @"\newdata.zip");
            Directory.CreateDirectory(DataLink.strDataDirectory + @"\newdata");

            ZipFile.ExtractToDirectory(DataLink.strDataDirectory + @"\newdata.zip", DataLink.strDataDirectory + @"\newdata");
            File.WriteAllText(DataLink.strDataDirectory + @"\version.txt", apiData.strTag);
            List<string> listDirsTemp = Directory.GetDirectories(DataLink.strDataDirectory + @"\newdata", "*.*", SearchOption.TopDirectoryOnly).ToList();

            foreach (string strStr in listDirsTemp)
            {
                listFiles = Directory.GetFiles(strStr, "*.*", SearchOption.TopDirectoryOnly).ToList();
                listDirs = Directory.GetDirectories(strStr, "*.*", SearchOption.TopDirectoryOnly).ToList();
            }

            foreach (string strFile in listFiles)
            {
                FileInfo finFile = new FileInfo(strFile);
                finFile.MoveTo(DataLink.strDataDirectory + @"\" + finFile.Name);
            }

            foreach (string strDir in listDirs)
            {
                DirectoryInfo dinDir = new DirectoryInfo(strDir);
                dinDir.MoveTo(DataLink.strDataDirectory + @"\" + dinDir.Name);
            }

            File.Delete(DataLink.strDataDirectory + @"\newdata.zip");
            Directory.Delete(DataLink.strDataDirectory + @"\newdata", true);
        }

        public void ResetClient()
        {
            intClient++;
            client = new WebClient();
            client.Headers.Add("user-agent", intClient.ToString());
        }
    }

    class GitHubAPIData
    {
        [JsonPropertyName("tag_name")]
        public string strTag { get; set; }

        [JsonPropertyName("name")]
        public string strName { get; set; }

        [JsonPropertyName("zipball_url")]
        public string strURL { get; set; }

        [JsonPropertyName("assets")]
        public List<GitHubAPIAsset> listAssets { get; set; }
    }

    class GitHubAPIAsset
    {
        [JsonPropertyName("browser_download_url")]
        public string strURL { get; set; }

        [JsonPropertyName("name")]
        public string strName { get; set; }
    }
}
