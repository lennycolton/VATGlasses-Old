using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Device.Location;

namespace VATGlasses.VRCParser
{
    class SectorLine
    {
        public static List<SectorLine> list;

        public string ident;

        public SectorLine(string _ident)
        {
            ident = _ident;
        }

        public SectorLine(SectorLine _copy)
        {
            ident = _copy.ident;
        }

        public static SectorLine Find(string _ident)
        {
            foreach (SectorLine line in list)
            {
                if (line.ident == _ident)
                {
                    return line;
                }
            }

            return null;
        }
    }

    class PolyLine : SectorLine
    {
        public List<double[]> points;

        public PolyLine(string[] _data) : base(_data[1])
        {
            points = new List<double[]>();
        }

        public PolyLine(PolyLine _copy) : base (_copy)
        {
            points = new List<double[]>(_copy.points);
        }

        public void AddPoint(string[] _data)
        {
            string latString = _data[1].Substring(1, _data[1].Length - 1);
            string[] latSplit = latString.Split('.');
            Array.Resize(ref latSplit, 4);

            for (int i = 0; i < latSplit.Length; i++)
            {
                if (latSplit[i] == null)
                {
                    latSplit[i] = "0";
                }
                else
                {
                    latSplit[i] = latSplit[i].Trim(' ');
                }
            }

            double lat = double.Parse(latSplit[0]) + double.Parse(latSplit[1]) / 60 + double.Parse(latSplit[2] + "." + latSplit[3]) / 3600;

            if (char.ToUpper(_data[1][0]) == 'S')
            {
                lat = -lat;
            }

            string lonString = _data[2].Substring(1, _data[2].Length - 1);
            string[] lonSplit = lonString.Split('.');
            Array.Resize(ref lonSplit, 4);

            for (int i = 0; i < lonSplit.Length; i++)
            {
                if (lonSplit[i] == null)
                {
                    lonSplit[i] = "0";
                }
                else
                {
                    lonSplit[i] = lonSplit[i].Trim(' ');
                }
            }

            double lon = double.Parse(lonSplit[0]) + double.Parse(lonSplit[1]) / 60 + double.Parse(lonSplit[2] + "." + lonSplit[3]) / 3600;

            if (char.ToUpper(_data[2][0]) == 'W')
            {
                lon = -lon;
            }

            points.Add(new double[] { lat, lon });
        }
    }

    class CircleLine : SectorLine
    {
        public double[] centre;
        public double radius;

        public CircleLine(string[] _data) : base(_data[1])
        {
            if (_data.Length == 4)
            {
                Airport apTemp = Airport.Find(_data[2]);

                if (apTemp != null)
                {
                    centre = new double[2] { apTemp.lat, apTemp.lon };
                }
            }
            else if (_data.Length == 5)
            {
                string latString = _data[2].Substring(1, _data[2].Length - 1);
                string[] latSplit = latString.Split('.');
                Array.Resize(ref latSplit, 4);

                double lat = double.Parse(latSplit[0]) + double.Parse(latSplit[1]) / 60 + double.Parse(latSplit[2] + "." + latSplit[3]) / 3600;

                if (char.ToUpper(_data[2][0]) == 'S')
                {
                    lat = -lat;
                }

                string lonString = _data[3].Substring(1, _data[3].Length - 1);
                string[] lonSplit = lonString.Split('.');
                Array.Resize(ref lonSplit, 4);

                double lon = double.Parse(lonSplit[0]) + double.Parse(lonSplit[1]) / 60 + double.Parse(lonSplit[2] + "." + lonSplit[3]) / 3600;

                if (char.ToUpper(_data[3][0]) == 'W')
                {
                    lon = -lon;
                }

                centre = new double[] { lat, lon };
            }

            radius = double.Parse(_data.Last());
        }
    }
}
