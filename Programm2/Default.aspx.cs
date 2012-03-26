using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProgramLib;
using ControlsLib;


namespace Programm2
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
                ArbeitsAuftrag = StartCtrl.DeserializeFromString<ArbeitsAuftrag>(s);
                Data = ArbeitsAuftrag.Uebergabedaten.GetDaten<String>();
                Daten.Text = Data;
            }
        }

        protected void Go_Click(object sender, EventArgs e)
        {
            if (Data != null && ArbeitsAuftrag != null)
            {
                Program p = PersistenceCtrl.Instance.GetProgrammByName("P2 - Ende");
                Uebergabedaten u = new Uebergabedaten(p.OutputTyp);
                u.SetDaten(Data);

                StartCtrl.Save(u);
            }
        }
    }
}
