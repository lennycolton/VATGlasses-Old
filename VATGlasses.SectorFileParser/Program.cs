using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VATGlasses.SectorFileParser
{
    class Program
    {
        public static readonly CultureInfo DataCulture = new CultureInfo("en-GB");
        static string[] defargs;

        static void Main(string[] args)
        {
            if (args.Length == 4)
            {
                defargs = args;
            }
            else
            {
                if (args.Length != 0)
                {
                    Console.WriteLine("Incorrect number of arguments.");
                }

                Console.WriteLine("To run quickly from command prompt, give your arguments like this:\n<airports file path> <.sct file path> <.ese file path> <fir code>\n");

                defargs = new string[4];

                Console.WriteLine("Enter airports file path:");
                defargs[0] = Console.ReadLine();

                Console.WriteLine("Enter .sct file path:");
                defargs[1] = Console.ReadLine();

                Console.WriteLine("Enter .ese file path:");
                defargs[2] = Console.ReadLine();

                Console.WriteLine("Enter fir code:");
                defargs[3] = Console.ReadLine();
            }


            bool isValid = true;

            if (isValid)
            {
                try
                {
                    Airport.Load(defargs[0]);

                    Runway.list = new List<Runway>();
                    SectorLine.list = new List<SectorLine>();
                    Sector.list = new List<Sector>();
                    Airspace.list = new List<Airspace>();
                    Controller.list = new List<Controller>();
                }
                catch (Exception ex)
                {
                    isValid = false;
                    Console.WriteLine("Error in airports file:\n" + ex);
                    Console.ReadLine();
                }
            }

            if (isValid)
            {
                try
                {
                    ReadSCT(defargs[1]);
                }
                catch (Exception ex)
                {
                    isValid = false;
                    Console.WriteLine("Error in .sct file:\n" + ex);
                    Console.ReadLine();
                }
            }

            if (isValid)
            {
                try
                {
                    ReadESE(defargs[2]);
                }
                catch (Exception ex)
                {
                    isValid = false;
                    Console.WriteLine("Error in .ese file:\n" + ex);
                    Console.ReadLine();
                }
            }

            if (isValid)
            {
                try
                {
                    ParseAirspaces();
                }
                catch (Exception ex)
                {
                    isValid = false;
                    Console.WriteLine("Error while parsing airspace layouts:\n" + ex);
                    Console.ReadLine();
                }
            }

            if (isValid)
            {
                try
                {
                    Write(defargs[3]);
                }
                catch (Exception ex)
                {
                    isValid = false;
                    Console.WriteLine("Error while writing to output files:\n" + ex);
                    Console.ReadLine();
                }
            }
        }

        static void ReadSCT(string _file)
        {
            //bool isAirport = false;
            bool isRunway = false;

            using (FileStream fs = File.Open(_file, FileMode.Open, FileAccess.Read, FileShare.Read))
            using (BufferedStream bs = new BufferedStream(fs))
            using (StreamReader sr = new StreamReader(bs))
            {
                string raw;
                while ((raw = sr.ReadLine()) != null)
                {
                    if (raw.Length != 0 && raw.First() != ';')
                    {
                        if (raw.First() == '[')
                        {
                            //isAirport = false;
                            isRunway = false;

                            //if (raw.ToUpper() == @"[AIRPORT]")
                            //{
                            //    isAirport = true;
                            //}
                            if (raw.ToUpper() == @"[RUNWAY]")
                            {
                                isRunway = true;
                            }
                        }
                        //else if (isAirport)
                        //{
                        //    string live = raw.Split(';')[0];
                        //    string[] split = live.Split(' ');
                        //    string sanitised = "";

                        //    foreach (string part in split)
                        //    {
                        //        if (part != "")
                        //        {
                        //            sanitised += part + ",";
                        //        }
                        //    }

                        //    if (sanitised.Length > 0)
                        //    {
                        //        sanitised = sanitised.Substring(0, sanitised.Length - 2);
                        //    }

                        //    string[] result = sanitised.Split(',');
                        //}
                        else if (isRunway)
                        {
                            string live = raw.Split(';')[0];
                            live = live.Replace('\t', ' ');
                            string[] split = live.Split(' ');
                            string sanitised = "";

                            foreach (string part in split)
                            {
                                if (part != "")
                                {
                                    sanitised += part + ",";
                                }
                            }

                            if (sanitised.Length > 0)
                            {
                                sanitised = sanitised.Substring(0, sanitised.Length - 1);
                            }

                            string[] result = sanitised.Split(',');

                            Airport location = Airport.Find(result[8]);
                            if (location != null)
                            {
                                Runway.list.Add(new Runway(location.ID, result[0]));
                                Runway.list.Add(new Runway(location.ID, result[1]));
                            }
                        }
                    }
                }
            }
        }

        static void ReadESE(string _file)
        {
            List<PolyLine> deferred = new List<PolyLine>();
            bool isPositions = false;
            bool isAirspace = false;
            bool isPolyLine = false;
            bool isSector = false;

            using (FileStream fs = File.Open(_file, FileMode.Open, FileAccess.Read, FileShare.Read))
            using (BufferedStream bs = new BufferedStream(fs))
            using (StreamReader sr = new StreamReader(bs))
            {
                string raw;
                while ((raw = sr.ReadLine()) != null)
                {
                    string live = raw.Split(';')[0];
                    live = live.Replace('\t', ' ');

                    if (raw.Length != 0 && raw.First() != ';')
                    {
                        if (raw.First() == '[')
                        {
                            isPositions = false;
                            isAirspace = false;

                            if (raw.ToUpper() == @"[POSITIONS]")
                            {
                                isPositions = true;
                            }
                            else if (raw.ToUpper() == @"[AIRSPACE]")
                            {
                                isAirspace = true;
                            }
                        }
                        else if (isPositions)
                        {
                            Controller.Add(live.Split(':'));
                        }
                        else if (isAirspace)
                        {
                            if (raw.StartsWith("CIRCLE_SECTORLINE:"))
                            {
                                isPolyLine = false;
                                isSector = false;

                                SectorLine.list.Add(new CircleLine(live.Split(':')));
                            }
                            else if (raw.StartsWith("SECTORLINE:"))
                            {
                                isPolyLine = true;
                                isSector = false;

                                SectorLine.list.Add(new PolyLine(live.Split(':')));
                            }
                            else if (raw.StartsWith("SECTOR:"))
                            {
                                isPolyLine = false;
                                isSector = true;
                                deferred = new List<PolyLine>();

                                if (Controller.listSorted == null)
                                {
                                    Controller.listSorted = Controller.Sort(Controller.list);
                                }

                                string[] liveparts = live.Split(':');

                                Sector.list.Add(new Sector(liveparts));
                            }
                            //else if (isCircleLine)
                            //{                               

                            //}
                            else if (isPolyLine)
                            {
                                if (raw.StartsWith("COORD:"))
                                {
                                    ((PolyLine)SectorLine.list.Last()).AddPoint(live.Split(':'));
                                }
                            }
                            else if (isSector)
                            {
                                if (raw.StartsWith("OWNER:"))
                                {
                                    string[] split = live.Split(':');

                                    for (int i = 1; i < split.Length; i++)
                                    {
                                        string part = split[i];

                                        if (part != "")
                                        {
                                            foreach (Controller ctl in Controller.Find(part))
                                            {
                                                Sector.list.Last().owners.Add(ctl);
                                            }
                                        }
                                    }
                                }
                                else if (raw.StartsWith("ACTIVE:"))
                                {
                                    string[] split = live.Split(':');

                                    Airport apTemp = Airport.Find(split[1]);

                                    if (apTemp != null)
                                    {
                                        Sector.list.Last().runways.Add(Runway.Find(apTemp.ID, split[2]));
                                    }
                                }
                                else if (raw.StartsWith("BORDER:"))
                                {
                                    string[] split = live.Split(':');

                                    for (int i = 1; i < split.Length; i++)
                                    {
                                        string part = split[i];
                                        SectorLine line = SectorLine.Find(part);
                                        Sector last = Sector.list.Last();

                                        if (line != null && line is PolyLine)
                                        {
                                            PolyLine poly = new PolyLine((PolyLine)line);

                                            if (last.lines.Count == 0)
                                            {
                                                last.lines.Add(poly);
                                            }
                                            else
                                            {
                                                if (poly.points[0].SequenceEqual(((PolyLine)last.lines.Last()).points.Last()))
                                                {
                                                    last.lines.Add(poly);
                                                }
                                                else if (poly.points.Last().SequenceEqual(((PolyLine)last.lines.Last()).points.Last()))
                                                {
                                                    poly.points.Reverse();
                                                    last.lines.Add(poly);
                                                }
                                                else if (poly.points[0].SequenceEqual(((PolyLine)last.lines[0]).points[0]))
                                                {
                                                    poly.points.Reverse();
                                                    last.lines.Insert(0, poly);
                                                }
                                                else if (poly.points.Last().SequenceEqual(((PolyLine)last.lines[0]).points[0]))
                                                {
                                                    last.lines.Insert(0, poly);
                                                }
                                                else
                                                {
                                                    deferred.Add(poly);
                                                }
                                            }

                                            bool isChanged = true;
                                            while (deferred.Count > 0 && isChanged)
                                            {
                                                isChanged = false;

                                                for (int j = deferred.Count - 1; j >= 0; j--)
                                                {
                                                    PolyLine plyPly = deferred[j];

                                                    if (plyPly.points[0].SequenceEqual(((PolyLine)last.lines.Last()).points.Last()))
                                                    {
                                                        last.lines.Add(plyPly);
                                                        deferred.RemoveAt(j);
                                                        isChanged = true;
                                                    }
                                                    else if (plyPly.points.Last().SequenceEqual(((PolyLine)last.lines.Last()).points.Last()))
                                                    {
                                                        plyPly.points.Reverse();
                                                        last.lines.Add(plyPly);
                                                        deferred.RemoveAt(j);
                                                        isChanged = true;
                                                    }
                                                    else if (plyPly.points[0].SequenceEqual(((PolyLine)last.lines[0]).points[0]))
                                                    {
                                                        plyPly.points.Reverse();
                                                        last.lines.Insert(0, plyPly);
                                                        deferred.RemoveAt(j);
                                                        isChanged = true;
                                                    }
                                                    else if (plyPly.points.Last().SequenceEqual(((PolyLine)last.lines[0]).points[0]))
                                                    {
                                                        last.lines.Insert(0, plyPly);
                                                        deferred.RemoveAt(j);
                                                        isChanged = true;
                                                    }
                                                }
                                            }
                                        }
                                        else if (line is CircleLine)
                                        {
                                            Sector.list.Last().lines.Add(line);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        static void ParseAirspaces()
        {
            bool isAdded = false;
            Airspace.list = new List<Airspace>();

            foreach (Sector sct in Sector.list)
            {
                isAdded = false;

                foreach (Airspace asp in Airspace.list)
                {
                    if (asp.owners.SequenceEqual(sct.owners))
                    {
                        asp.sectors.Add(sct);
                        isAdded = true;
                    }
                }

                if (!isAdded)
                {
                    Airspace.list.Add(new Airspace(sct));
                }
            }
        }

        static void Write(string _pack)
        {
            string directory = "";

            if (Directory.Exists(@"output\" + _pack))
            {
                int count = 0;

                while(Directory.Exists(@"output\" + _pack + "_" + count.ToString()))
                {
                    count++;
                }

                directory = @"output\" + _pack + "_" + count.ToString();
            }
            else
            {
                directory = @"output\" + _pack;
            }

            Directory.CreateDirectory(directory);

            using (FileStream fs = File.Open(directory + @"\controllers.txt", FileMode.Create, FileAccess.Write, FileShare.Write))
            using (BufferedStream bs = new BufferedStream(fs))
            using (StreamWriter sw = new StreamWriter(bs))
            {
                foreach (Controller ctlCtl in Controller.list)
                {
                    sw.WriteLine(ctlCtl.ID + "|" + ctlCtl.start + "|" + ctlCtl.end + "|" + ctlCtl.freq.ToString("000.000") + "|" + defargs[3] + "|" + ctlCtl.cs + ";" + ctlCtl.label);
                }
            }

            using (FileStream fs = File.Open(directory + @"\airspace.txt", FileMode.Create, FileAccess.Write, FileShare.Write))
            using (BufferedStream bs = new BufferedStream(fs))
            using (StreamWriter sw = new StreamWriter(bs))
            {
                foreach (Airspace aspAsp in Airspace.list)
                {
                    if (aspAsp.owners.Count > 0)
                    {
                        string sectors = "";
                        string description = "";

                        foreach (Sector sctSct in aspAsp.sectors)
                        {
                            if ((sctSct.minAlt != sctSct.maxAlt || (sctSct.minAlt == null && sctSct.maxAlt == null)) && sctSct.lines.Count > 0)
                            {
                                sectors += sctSct.ID + ",";
                                description += sctSct.ident + ", ";
                            }
                            else
                            {
                                Sector.list.Remove(sctSct);
                            }
                        }
                        if (sectors.Length > 0)
                        {
                            sectors = sectors.Substring(0, sectors.Length - 1);
                            //description = description.Substring(0, sectors.Length - 2);

                            string owners = "";

                            foreach (Controller ctlCtl in aspAsp.owners)
                            {
                                owners += ctlCtl.ID + ",";

                                if (ctlCtl.end == "APP" || ctlCtl.end == "DEP")
                                {
                                    owners += "1,,|";
                                }
                                else
                                {
                                    owners += "0,,|";
                                }
                            }

                            sw.WriteLine(aspAsp.ID + "|" + sectors + "|" + owners + aspAsp.owners[0].ident + "|" + description);
                        }
                    }
                    else
                    {
                        foreach (Sector sctSct in aspAsp.sectors)
                        {
                            Sector.list.Remove(sctSct);
                        }
                    }
                }
            }

            using (FileStream fs = File.Open(directory + @"\sectors.txt", FileMode.Create, FileAccess.Write, FileShare.Write))
            using (BufferedStream bs = new BufferedStream(fs))
            using (StreamWriter sw = new StreamWriter(bs))
            {
                foreach (Sector sctSct in Sector.list)
                {
                    string runways = "";

                    foreach (Runway rwyRwy in sctSct.runways)
                    {
                        if (rwyRwy != null)
                        {
                            runways += rwyRwy.ID + ",";
                        }
                    }

                    if (runways.Length > 0)
                    {
                        runways = runways.Substring(0, runways.Length - 1);
                    }

                    string type = "";
                    string lines = "";

                    foreach (SectorLine line in sctSct.lines)
                    {
                        if (line is PolyLine)
                        {
                            type = "0";

                            foreach (double[] dblDbl in ((PolyLine)line).points)
                            {
                                lines += dblDbl[0] + "," + dblDbl[1] + "|";
                            }
                        }
                        else if (line is CircleLine)
                        {
                            type = "1";

                            CircleLine circle = (CircleLine)line;

                            lines += circle.centre[0] + "," + circle.centre[1] + "|" + circle.radius + "|";
                        }
                    }

                    lines = lines.Substring(0, lines.Length - 1);

                    string minAlt = "";
                    string maxAlt = "";

                    if (sctSct.minAlt != null)
                    {
                        minAlt = sctSct.minAlt.ToString();
                    }

                    if (sctSct.maxAlt != null)
                    {
                        maxAlt = sctSct.maxAlt.ToString();
                    }

                    sw.WriteLine(sctSct.ID + "|" + minAlt + "|" + maxAlt + "|" + runways + "|" + type + "|" + lines + ";" + sctSct.ident);
                }
            }

            using (FileStream fs = File.Open(directory + @"\runways.txt", FileMode.Create, FileAccess.Write, FileShare.Write))
            using (BufferedStream bs = new BufferedStream(fs))
            using (StreamWriter sw = new StreamWriter(bs))
            {
                foreach (Runway rwyRwy in Runway.list)
                {
                    sw.WriteLine(rwyRwy.ID + "|" + rwyRwy.airport + "|" + rwyRwy.runway);
                }
            }
        }
    }
}