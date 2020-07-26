using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VATGlasses
{
    class FIR
    {
        public static readonly string strDataFile = DataLink.strDataDirectory + @"\firs.txt";

        public static List<FIR> list { get; protected set; }

        public string strIdent { get; private set; }
        //public string strName { get; private set; }
        public bool isOceanic { get; private set; }
        public bool isExtension { get; private set; }
        public List<double[]> listVertices { get; private set; }
        public double dblCentreLat { get; private set; }
        public double dblCentreLon { get; private set; }
        public FIRDisplay frdDisplay { get; set; } = null;

        public FIR(string _ident, double _lat, double _lon, bool _oceanic, bool _extension, List<double[]> _vertices)
        {
            strIdent = _ident;
            //strName = _name;
            isOceanic = _oceanic;
            isExtension = _extension;
            listVertices = _vertices;
            dblCentreLat = _lat;
            dblCentreLon = _lon;
        }

        public FIR(FIR _fir)
        {
            strIdent = _fir.strIdent;
            //strName = _fir.strName;
            isOceanic = _fir.isOceanic;
            isExtension = _fir.isExtension;
            listVertices = _fir.listVertices;
            dblCentreLat = _fir.dblCentreLat;
            dblCentreLon = _fir.dblCentreLon;
        }

        public FIR(string[] _data)
        {
            //strName = _data.Item2;
            strIdent = _data[0];

            if (_data[1] == "1")
            {
                isOceanic = true;
            }
            else
            {
                isOceanic = false;
            }

            if (_data[2] == "1")
            {
                isExtension = true;
            }
            else
            {
                isExtension = false;
            }

            dblCentreLat = double.Parse(_data[3], DataLink.DataCulture);
            dblCentreLon = double.Parse(_data[4], DataLink.DataCulture);

            listVertices = new List<double[]>();
            for (int i = 5; i < _data.Length; i++)
            {
                string[] strarrSplit = _data[i].Split(',');
                listVertices.Add(new double[] { double.Parse(strarrSplit[0], DataLink.DataCulture), double.Parse(strarrSplit[1], DataLink.DataCulture) });
            }
        }

        public static async Task Load(string _filename)
        {
            list = new List<FIR>();

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

                        if (strarrSplit.Length >= 6)
                        {
                            list.Add(new FIR(strarrSplit));
                        }
                        else
                        {
                            Console.WriteLine(strRaw);
                            throw new ArgumentOutOfRangeException("Each line in the file must contain at least six entries, separated by a '|'");
                        }
                    }
                }
            }

            FIRDisplay.Assign();
        }
    }
}
