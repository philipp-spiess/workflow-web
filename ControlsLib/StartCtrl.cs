using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProgramLib;
using PersistenceLib;
using System.Web;
using System.Data;


namespace ControlsLib
{
    public class StartCtrl
    {
        private static PersistenceMgr Persistence = PersistenceCtrl.Instance;

        public static void Start(String pname)
        {
            Program program = PersistenceCtrl.Instance.GetProgrammByName(pname);

            HttpContext.Current.Response.Redirect(program.Path);
        }

        public static void Weiterfuehren(ArbeitsAuftrag aa)
        {
            aa.program.uebergabedaten = aa.Uebergabedaten;
            aa.program.Start();


            Persistence.RemoveArbeitsAuftrag(aa);
        }

        public static void Save(Uebergabedaten u)
        {
            if (u.Typ == null)
            {
                HttpContext.Current.Response.Redirect("http://localhost/End.aspx");
            }
            else
            {
                HttpContext.Current.Session["Uebergabedaten"] = u;
                HttpContext.Current.Response.Redirect("http://localhost/Select.aspx");
                
                //gui.Show();
            }
        }

        public static void CreateAA(Uebergabedaten u, Program p)
        {
            Persistence.AddArbeitsAuftrag(new ArbeitsAuftrag(p, u));
        }

    }
}
