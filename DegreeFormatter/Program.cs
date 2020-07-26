using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DegreeFormatter
{
    class Program
    {
        static List<double[]> points = new List<double[]>();

        static void Main(string[] args)
        {
            using (FileStream fs = File.Open(@"D:\Lenny\Documents\DW TWR 2 Coords.txt", FileMode.Open, FileAccess.Read, FileShare.Read))
            using (BufferedStream bs = new BufferedStream(fs))
            using (StreamReader sr = new StreamReader(bs))
            {
                string raw;

                while ((raw = sr.ReadLine()) != null)
                {
                    AddPoint(raw.Split(':'));
                }
            }

            using (FileStream fs = File.Open(@"D:\Lenny\Documents\DW TWR 2 Coords.txt", FileMode.Open, FileAccess.Write, FileShare.Write))
            using (BufferedStream bs = new BufferedStream(fs))
            using (StreamWriter sw = new StreamWriter(bs))
            {
                foreach (double[] coord in points)
                {
                    sw.WriteLine(coord[0].ToString() + "," + coord[1].ToString());
                }
            }
        }

        public static void AddPoint(string[] _data)
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
}
