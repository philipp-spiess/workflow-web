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

            if (Request.QueryString["saved"] != null && Request.QueryString["saved"].Equals("true"))
            {
                Label1.Text = "Arbeitsauftrag gespeichert.";
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
            }
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
                this.ProgrammListe.Items.Add(new ListItem(p.Name, p.Name));
            }
        }

        protected void AA_Click(object sender, EventArgs e)
        {
            Label1.Text = "lom";

            if (ArbeitsauftraegeListe.SelectedItem == null)
            {
                Label1.Text = "No AA selected";
            }
            else
            {
                Label1.Text = ArbeitsauftraegeListe.SelectedItem.Value;
                StartCtrl.Weiterfuehren(ArbeitsauftraegeListe.SelectedItem.Value);
            }
        }
    }
}
