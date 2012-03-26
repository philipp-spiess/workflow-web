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
    public partial class Select : System.Web.UI.Page
    {
        Uebergabedaten Uebergabedaten = null;
        protected void Page_Load(object sender, EventArgs e)
        {

            String s = Request.QueryString["uebergabedaten"];
            if (s == null || s.Length < 1)
            {
                Label1.Text = "Nope, not this time!";

            }
            else
            {
                Uebergabedaten = StartCtrl.DeserializeFromString<Uebergabedaten>(s);

                List<Program> programme = PersistenceCtrl.Instance.GetProgramsOfType(Uebergabedaten.Typ);

                if (!IsPostBack)
                {
                    Programme.Items.Clear();
                    foreach (Program p in programme)
                    {
                        Programme.Items.Add(new ListItem(p.Name, p.Name));
                    }
                }
            }
        }

        protected void Go_Click(object sender, EventArgs e)
        {
            if (Uebergabedaten == null || Programme.SelectedValue == null || Programme.SelectedValue.Length < 1)
            {
                Label1.Text = "Please select a program";
            }
            else
            {
                PersistenceCtrl.Instance.GetProgrammByName(Programme.SelectedValue);
                
                StartCtrl.CreateAA(Uebergabedaten, PersistenceCtrl.Instance.GetProgrammByName(Programme.SelectedValue));
            }
        }
    }
}