using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VATGlasses.SectorFileParser
{
    class Controller
    {
        public static int count = 0;
        public static List<Controller> list;
        public static List<Controller> listSorted;

        public int ID;
        public string label;
        public string cs;
        public decimal freq;
        public string ident;
        public string start;
        public string end;

        internal static bool SetOffset(string v)
        {
            if (int.TryParse(v, NumberStyles.Integer, Program.DataCulture, out count) && count >= 0)
            {
                return true;
            }

            return false;
        }

        public Controller(string[] _data)
        {
            ID = count;
            count++;

            label = _data[0];
            cs = _data[1];

            if (!decimal.TryParse(_data[2], NumberStyles.Integer, Program.DataCulture, out freq) || freq < 0)
            {
                freq = (decimal)199.998;
            }

            ident = _data[3];
            start = _data[5];
            end = _data[6];
        }

        public static void Add(string[] _data)
        {
            if (_data[6] == "APP" || _data[6] == "DEP" || _data[6] == "CTR" || _data[6] == "FSS")
            {
                list.Add(new Controller(_data));
            }
        }

        //Binary Search, based on identifier
        public static List<Controller> Find(string _ident)
        {
            //Create fields
            Controller ControllerCurrent = null;
            List<Controller> listResults;
            int intCurrent;

            //Set bounds
            int intMidpoint;
            int intMin = 0;
            int intMax = listSorted.Count() - 1;

            do
            {
                //Set midpoint
                intMidpoint = (intMin + intMax) / 2;

                //Find midpoint items
                ControllerCurrent = listSorted[intMidpoint];

                //Find all matching if search term found
                if (ControllerCurrent.ident == _ident)
                {
                    //Add current element to results listSorted
                    listResults = new List<Controller>();

                    //Add all matching with lower indices
                    intCurrent = intMidpoint;

                    if (intCurrent >= 0)
                    {
                        while (intCurrent >= 0 && listSorted[intCurrent].ident == _ident)
                        {
                            //Add value to results listSorted and increment down
                            listResults.Add(listSorted[intCurrent]);
                            intCurrent--;
                        }
                    }

                    //Add all matching with higher indices
                    intCurrent = intMidpoint + 1;

                    if (intCurrent < listSorted.Count)
                    {
                        while (intCurrent < listSorted.Count() && listSorted[intCurrent].ident == _ident)
                        {
                            //Add value to results listSorted and increment up
                            listResults.Add(listSorted[intCurrent]);
                            intCurrent++;
                        }
                    }

                    //Return results
                    return listResults;
                }
                //Set new minimum if current is too low
                else if (string.Compare(ControllerCurrent.ident, _ident) < 0)
                {
                    intMin = intMidpoint + 1;
                }
                //Set new maximum if current is too high
                else if (string.Compare(ControllerCurrent.ident, _ident) > 0)
                {
                    intMax = intMidpoint - 1;
                }
            } while (intMin <= intMax);

            //Return null if nothing found
            return new List<Controller>();
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
                    if (string.Compare(_left[0].ident, _right[0].ident) <= 0)
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
    }
}
