using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProgramLib
{
    public class ArbeitsAuftrag
    {
        public Program program { get; set; }
        public Uebergabedaten Uebergabedaten { get; set; }

        public ArbeitsAuftrag(Program p, Uebergabedaten u)
        {
            this.program = p;
            this.Uebergabedaten = u;
        }

        public ArbeitsAuftrag() { }

        public override string ToString()
        {
            return "AA #" + Uebergabedaten.ID + " mit " + program.ToString();
        }
    }
}
