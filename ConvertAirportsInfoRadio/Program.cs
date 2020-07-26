using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertAirportsInfoRadio
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string[]> lines = new List<string[]>();

            using (FileStream fs = File.Open(@"D:\Lenny\Documents\GitHub\VATGlasses-Data\airports.txt", FileMode.Open, FileAccess.Read, FileShare.Read))
            using (BufferedStream bs = new BufferedStream(fs))
            using (StreamReader sr = new StreamReader(bs))
            {
                string raw;

                while ((raw = sr.ReadLine()) != null)
                {
                    lines.Add(raw.Split('|'));
                }
            }

            using (FileStream fs = File.Open(@"D:\Lenny\Documents\GitHub\VATGlasses-Data\airports1.txt", FileMode.Open, FileAccess.Write, FileShare.Write))
            using (BufferedStream bs = new BufferedStream(fs))
            using (StreamWriter sw = new StreamWriter(bs))
            {
                foreach (string[] line in lines)
                {
                    string write = line[0] + "|" + line[1] + "|" + line[2] + "|" + line[3] + "|" + line[4] + "|" + line[5] + "|" + line[6] + "|0|0";

                    for (int i = 7; i < line.Length; i++)
                    {
                        write += "|" + line[i];
                    }

                    sw.WriteLine(write);
                }
            }
        }
    }
}
