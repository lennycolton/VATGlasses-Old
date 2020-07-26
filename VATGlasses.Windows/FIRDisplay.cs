using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VATGlasses
{
    class FIRDisplay
    {
        public static List<FIRDisplay> list;

        public List<FIR> listFIRs;
        public bool isShown;

        public FIRDisplay(List<FIR> _firs, bool _shown)
        {
            listFIRs = _firs;
            isShown = _shown;
        }

        public FIRDisplay(FIR _fir, bool _shown)
        {
            listFIRs = new List<FIR>();
            listFIRs.Add(_fir);

            isShown = _shown;
        }

        public static void Assign()
        {
            list = new List<FIRDisplay>();
            List<FIR> listExtensions = new List<FIR>();

            foreach (FIR firFir in FIR.list)
            {
                if (firFir.isExtension)
                {
                    listExtensions.Add(firFir);
                }
                else
                {
                    list.Add(new FIRDisplay(firFir, true));
                    firFir.frdDisplay = list.Last();
                }
            }

            foreach (FIR firFir in listExtensions)
            {
                foreach (FIRDisplay frdFrd in list)
                {
                    if (firFir.strIdent == frdFrd.listFIRs[0].strIdent)
                    {
                        frdFrd.listFIRs.Add(firFir);
                        firFir.frdDisplay = frdFrd;
                    }
                }
            }
        }
    }
}
