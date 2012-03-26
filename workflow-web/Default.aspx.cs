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
            if (!IsPostBack)
            {
                this.RefreshList();
            }
        }

        protected void Start_Click(object sender, EventArgs e)
        {
            if (ProgrammListe.SelectedItem == null)
            {

                Label1.Text = "No programm selected";
            }
            else
            {
                StartCtrl.Start(ProgrammListe.SelectedItem.Value);
                //Label1.Text = "Look: " + ProgrammListe.SelectedItem.Value;
            }
        }

        protected void Weiterfuehren_Click(object sender, EventArgs e)
        {

        }

        protected void Aktualisieren_Click(object sender, EventArgs e)
        {
            this.RefreshList();
        }
   

        private void RefreshList()
        {
          
            
            List<Program> programs = PersistenceCtrl.Instance.GetProgramme();
            List<ArbeitsAuftrag> arbeitsauftraege = PersistenceCtrl.Instance.GetArbeitsAuftraege();

            ArbeitsauftraegeListe.Items.Clear();
            foreach(ArbeitsAuftrag aa in arbeitsauftraege)
            {
                this.ArbeitsauftraegeListe.Items.Add(new ListItem(aa.ToString(),aa.Uebergabedaten.ID.ToString()));
            }

            ProgrammListe.Items.Clear();
            foreach (Program p in programs)
            {  
                this.ProgrammListe.Items.Add(new ListItem(p.ToString(),p.Name));
            }
        }

      


      
    }
}
