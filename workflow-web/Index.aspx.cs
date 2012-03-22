using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProgramLib;
using ControlsLib;


namespace workflow_web
{
    public partial class _Default : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            this.RefreshList();
        }

        protected void Start_Click(object sender, EventArgs e)
        {

        }

        protected void Weiterfuehren_Click(object sender, EventArgs e)
        {

        }
   

        private void RefreshList()
        {

            List<Program> programs = PersistenceCtrl.Instance.GetProgramme();
            List<ArbeitsAuftrag> arbeitsauftraege = PersistenceCtrl.Instance.GetArbeitsAuftraege();

            foreach(ArbeitsAuftrag aa in arbeitsauftraege)
            {
                this.ArbeitsauftraegeListe.Items.Add(new ListItem(aa.ToString(),aa.Uebergabedaten.ID.ToString()));
            }

            foreach (Program p in programs)
            {  
                if(p != null)
                    this.ProgrammListe.Items.Add(new ListItem(p.ToString(),p.Name));
            }
        }


      
    }
}
