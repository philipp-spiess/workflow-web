﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProgramLib;
using System.Data.Odbc;
using System.Configuration;
using System.Runtime.Remoting;

namespace PersistenceLib
{
    public class PersistenceMgr
    {
        private OdbcConnection con;

        public PersistenceMgr()
        {
            AppSettingsReader config = new AppSettingsReader();
            String connector = (String)config.GetValue("Connector", typeof(String));
            con = new OdbcConnection(connector);
            con.Open();
        }

        public Program GetProgrammByName(String pname)
        {
            List<Program> programme = GetAllProgramme();
            Program program = null;

            String lol = "";
            foreach (Program p in programme)
            {
                lol += " " + p.Name;
                if (pname.Equals(p.Name))
                    program = p;
            }

            if (program == null)
            {
                throw new Exception("No program called '" + pname + "' ... LOL= " + lol);
            }

            return program;
        }

        public List<Program> GetProgramme()
        {
            List<Program> programme = new List<Program>();

            String query = @"select pname, path, 'x' as x, i_typ_name, o_typ_name from web_programm where i_typ_name is null";

            OdbcCommand command = new OdbcCommand(query, con);
            OdbcDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Typ out_typ = null;
                if (!reader.IsDBNull(4))
                    out_typ = new Typ(reader.GetString(4));

                Program p = new Program();
                p.Name = reader.GetString(0);
                p.Path = reader.GetString(1);
                p.OutputTyp = out_typ;
                p.InputTyp = null;

                programme.Add(p);

            }

            return programme;
        }

        public List<Program> GetAllProgramme()
        {
            List<Program> programme = new List<Program>();

            String query = @"select pname, path, 'x' as x, i_typ_name, o_typ_name from web_programm";

            OdbcCommand command = new OdbcCommand(query, con);
            OdbcDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Typ out_typ = null;
                if (!reader.IsDBNull(4))
                    out_typ = new Typ(reader.GetString(4));

                Typ input_typ = null;
                if (!reader.IsDBNull(3))
                    input_typ = new Typ(reader.GetString(3));

                Program p = new Program();
                p.Name = reader.GetString(0);
                p.Path = reader.GetString(1);
                p.OutputTyp = out_typ;
                p.InputTyp = input_typ;

                programme.Add(p);

            }

            return programme;
        }


        public List<ArbeitsAuftrag> GetArbeitsAuftraege()
        {
            List<ArbeitsAuftrag> arbeitsauftraege = new List<ArbeitsAuftrag>();

            String query = "select web_programm.pname, web_programm.path, 'x' as x, web_programm.i_typ_name, "
                         + "web_programm.i_typ_name, web_daten.did, web_daten.typ_tname, web_daten.data from web_AA "
                         + "join web_programm on (web_AA.programm_pname = web_programm.pname) "
                         + "join web_daten on (web_daten.did = web_AA.daten_did);";

            OdbcCommand command = new OdbcCommand(query, con);
            OdbcDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {

                Typ in_typ = null;
                if (!reader.IsDBNull(3))
                    in_typ = new Typ(reader.GetString(4));

                Typ out_typ = null;
                if (!reader.IsDBNull(4))
                    out_typ = new Typ(reader.GetString(4));

                Program p = new Program();
                p.Name = reader.GetString(0);
                p.Path = reader.GetString(1);
                p.OutputTyp = out_typ;
                p.InputTyp = in_typ;

                arbeitsauftraege.Add(
                    new ArbeitsAuftrag(
                        p,
                        new Uebergabedaten(
                            reader.GetInt32(5),
                            new Typ(reader.GetString(6)),
                            reader.GetString(7)
                        )
                    )
                );
            }

            return arbeitsauftraege;
        }

        public void AddArbeitsAuftrag(ArbeitsAuftrag aa)
        {
            if (aa.Uebergabedaten.ID <= 0)
                aa.Uebergabedaten.ID = this.getDatenID();


            OdbcCommand c;

            c = new OdbcCommand("insert into web_daten (did, typ_tname, data) values (?, ?, ?)", con);

            c.Parameters.Add("did", OdbcType.Int);
            c.Parameters.Add("typ_tname", OdbcType.VarChar);
            c.Parameters.Add("data", OdbcType.VarChar);

            c.Parameters["did"].Value = aa.Uebergabedaten.ID;
            c.Parameters["typ_tname"].Value = aa.Uebergabedaten.Typ.Name;
            c.Parameters["data"].Value = aa.Uebergabedaten.Daten;

            c.ExecuteNonQuery();

            c = new OdbcCommand("insert into web_AA (programm_pname, daten_did) values (?, ?)", con);

            c.Parameters.Add("programm_pname", OdbcType.VarChar);
            c.Parameters.Add("daten_did", OdbcType.Int);

            c.Parameters["programm_pname"].Value = aa.program.Name;
            c.Parameters["daten_did"].Value = aa.Uebergabedaten.ID;

            c.ExecuteNonQuery();

        }

        public void RemoveArbeitsAuftrag(ArbeitsAuftrag aa)
        {
            OdbcCommand c;

            c = new OdbcCommand("delete from web_AA where daten_did = ?", con);

            c.Parameters.Add("daten_did", OdbcType.Int, 4, "daten_did");
            c.Parameters["daten_did"].Value = aa.Uebergabedaten.ID;

            c.ExecuteNonQuery();

            c = new OdbcCommand("delete from web_daten where did = ?", con);

            c.Parameters.Add("did", OdbcType.Int, 4, "did");
            c.Parameters["did"].Value = aa.Uebergabedaten.ID;

            c.ExecuteNonQuery();

        }

        public List<Program> GetProgramsOfType(Typ t)
        {
            List<Program> programme = new List<Program>();

            String query = @"select pname, path, 'x' as x, i_typ_name, o_typ_name from web_programm where i_typ_name = ?";

            OdbcCommand command = new OdbcCommand(query, con);
            command.Parameters.Add("i_typ_name", OdbcType.VarChar, 50, "i_typ_name");
            command.Parameters["i_typ_name"].Value = t.Name;

            OdbcDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Program p = new Program();
                p.Name = reader.GetString(0);
                p.Path = reader.GetString(2);

                Typ out_typ = null;
                if (!reader.IsDBNull(4))
                    out_typ = new Typ(reader.GetString(4));

                Typ in_typ = null;
                if (!reader.IsDBNull(3))
                    in_typ = new Typ(reader.GetString(3));

                p.OutputTyp = out_typ;
                p.InputTyp = in_typ;

                programme.Add(p);
            }

            return programme;

        }

        public List<Program> GetProgramsOfUebergabedaten(Uebergabedaten u)
        {
            return this.GetProgramsOfType(u.Typ);
        }

        public int getDatenID()
        {
            String query = @"select daten_seq.nextval from dual";

            OdbcCommand command = new OdbcCommand(query, con);
            OdbcDataReader reader = command.ExecuteReader();

            reader.Read();

            return reader.GetInt32(0);
        }
    }
}
