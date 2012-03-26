using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProgramLib;
using ControlsLib;

namespace Programm3
{
    public partial class _Default : System.Web.UI.Page
    {
        ArbeitsAuftrag ArbeitsAuftrag = null;
        String Data = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            String s = Request.QueryString["aa"];
            if (s != null && s.Length >= 1)
            {
                ArbeitsAuftrag  = StartCtrl.DeserializeFromString<ArbeitsAuftrag>(s);
                Data = ArbeitsAuftrag.Uebergabedaten.GetDaten<String>();
                Daten.Text = Data + "\" to \"" + ReverseString(Data);
            }
        }

        protected void Go_Click(object sender, EventArgs e)
        {
            if (Data != null && ArbeitsAuftrag != null)
            {
                Program p = PersistenceCtrl.Instance.GetProgrammByName("P3 - StringRev");
                Uebergabedaten u = new Uebergabedaten(p.OutputTyp);
                u.SetDaten(ReverseString(Data));

                StartCtrl.Save(u);
            }
        }

        public static string ReverseString(string text)
        {
            if (text.Length == 1 || String.IsNullOrEmpty(text))
                return text;
            else
                return ReverseString(text.Substring(1)) + text.Substring(0, 1);
        }
    }
}
