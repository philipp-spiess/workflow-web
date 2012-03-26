using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProgramLib;
using PersistenceLib;
using ControlsLib;

namespace Programm1
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Go_Click(object sender, EventArgs e)
        {
            if (Text.Text.Length < 1)
            {
                Label1.Text = "Bitte Text eingeben!!";
            }
            else
            {   
                Program p = PersistenceCtrl.Instance.GetProgrammByName("P1 - Start");
                Uebergabedaten u = new Uebergabedaten(p.OutputTyp);
                u.SetDaten(Text.Text);

                StartCtrl.Save(u);

                Label1.Text = "Jetzt wirds lustig...";
            }
        }
    }
}
