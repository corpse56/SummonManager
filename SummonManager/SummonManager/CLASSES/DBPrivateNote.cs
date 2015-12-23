using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SummonManager
{
    class DBPrivateNote:DB
    {
        public void AddPrivateNote(string IDUser, string ids,string note)
        {
            DA.SelectCommand.CommandText = "select * from " + Base.BaseName + "..PRIVATENOTES where IDSUMMON = " + ids + " and IDUSER = " + IDUser;
            DS = new DataSet();
            int h = DA.Fill(DS, "t");
            if (h == 0)
            {
                DA.InsertCommand.CommandText = "insert into " + Base.BaseName + "..PRIVATENOTES (IDSUMMON,IDUSER,PRIVATENOTE)" +
                                               " values (" + ids + "," + IDUser + ",'" + note + "')";
                DA.InsertCommand.Connection.Open();
                DA.InsertCommand.ExecuteNonQuery();
                DA.InsertCommand.Connection.Close();
            }
            else
            {
                DA.UpdateCommand.CommandText = "update " + Base.BaseName + "..PRIVATENOTES set PRIVATENOTE  = '" + note + "'" +
                                " where IDSUMMON = " + ids +" and IDUSER = "+IDUser;
                DA.UpdateCommand.Connection.Open();
                DA.UpdateCommand.ExecuteNonQuery();
                DA.UpdateCommand.Connection.Close();
            }
        }
        public string GetPrivateNote(string IDUser, string ids)
        {
            DA.SelectCommand.CommandText = "select * from " + Base.BaseName + "..PRIVATENOTES where IDSUMMON = "+ids +" and IDUSER = "+IDUser;
            DS = new DataSet();
            int h = DA.Fill(DS, "t");
            if (h == 0) return "";
            return DS.Tables["t"].Rows[0]["PRIVATENOTE"].ToString();

        }

        internal bool ExistsPN(string IDUser, string ids)
        {
            DA.SelectCommand.CommandText = "select * from " + Base.BaseName + "..PRIVATENOTES where IDSUMMON = " + ids + " and IDUSER = " + IDUser;
            DS = new DataSet();
            int h = DA.Fill(DS, "t");
            if (h == 0) return false;
            if (DS.Tables["t"].Rows[0]["PRIVATENOTE"].ToString() == "") return false;
            return true;
        }
    }
}
