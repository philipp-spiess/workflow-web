using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProgramLib;

namespace workflow_web
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Start_Click(object sender, EventArgs e)
        {
            Program p = (Programme)ProgrammListe.SelectedItem;
            if (p != null)
            {
                StartCtrl.Start(p);
            }
        }

        protected void Weiterfuehren_Click(object sender, EventArgs e)
        {
            ArbeitsAuftrag aa = (ArbeitsAuftrag)ArbeitsauftraegeListe.SelectedItem;
            if (aa != null)
            {
                StartCtrl.Weiterfuehren(aa);
            }
        }

   


      
    }
}
