using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProgramLib;
using PersistenceLib;
using System.Web;
using System.Data;
using System.Xml.Serialization;
using System.IO;


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

        public static void Weiterfuehren(String s)
        {

            List<ArbeitsAuftrag> aas = PersistenceCtrl.Instance.GetArbeitsAuftraege();
            ArbeitsAuftrag aa = null;
            foreach (ArbeitsAuftrag a in aas)
            {
                if (a.Uebergabedaten.ID.ToString().Equals(s))
                    aa = a;
            }

            String u = SerializeToString(aa);
            
            Persistence.RemoveArbeitsAuftrag(aa);

            HttpContext.Current.Response.Redirect(aa.program.Path + "?aa=" + HttpUtility.UrlEncode(u));

        }

        public static void Save(Uebergabedaten u)
        {
            if (u.Typ == null)
            {
                HttpContext.Current.Response.Redirect("/workflow-web/End.aspx");
            }
            else
            {
                HttpContext.Current.Session["Uebergabedaten"] = u;

                String s = SerializeToString(u);
                HttpContext.Current.Response.Redirect("/workflow-web/Select.aspx?uebergabedaten=" + HttpUtility.UrlEncode(s));
             }
        }

        public static void CreateAA(Uebergabedaten u, Program p)
        {
            Persistence.AddArbeitsAuftrag(new ArbeitsAuftrag(p, u));

            HttpContext.Current.Response.Redirect("/workflow-web/?saved=true");
        }



        public static T DeserializeFromString<T>(String t)
        {
            var serializer = new XmlSerializer(typeof(T));

            using (var reader = new StringReader(t.Replace("--omgmario--", "<")))
            {
                return (T)serializer.Deserialize(reader);
            }
        }

        public static String SerializeToString(object d)
        {
            var serializer = new XmlSerializer(d.GetType());

            using (var writer = new StringWriter())
            {
                serializer.Serialize(writer, d);

                return writer.ToString().Replace("<", "--omgmario--");
            }
        }

         
    }
}
