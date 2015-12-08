using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SummonManager
{
    class DBWPName :DB
    {
        public DBWPName() { }

        public DataTable GetAllWPNames()
        {
            DA.SelectCommand.CommandText = "select * from " + Base.BaseName + "..WPNAMELIST order by WPNAME";
            DS = new DataSet();
            int h = DA.Fill(DS, "t");
            return DS.Tables["t"];
        }

        internal void AddNewWP(string p)
        {
            DA.InsertCommand.CommandText = "insert into " + Base.BaseName + "..WPNAMELIST (WPNAME) values ('" + p + "')";
            DA.InsertCommand.Connection.Open();
            DA.InsertCommand.ExecuteNonQuery();
            DA.InsertCommand.Connection.Close();
        }

        internal string GetWP(string p)
        {
            DA.SelectCommand.CommandText = "select * from " + Base.BaseName + "..WPNAMELIST where ID = " +p;
            DA.Fill(DS, "t");
            return DS.Tables["t"].Rows[0]["WPNAME"].ToString();
        }

        internal void EditWP(string p,string id)
        {
            DA.UpdateCommand.CommandText = "update " + Base.BaseName + "..WPNAMELIST set WPNAME  = '" + p + "'"+
                                            " where ID = " + id;
            DA.UpdateCommand.Connection.Open();
            DA.UpdateCommand.ExecuteNonQuery();
            DA.UpdateCommand.Connection.Close();
        }



        internal void DeleteByID(string p)
        {
            DA.DeleteCommand.CommandText = "delete from " + Base.BaseName + "..WPNAMELIST where ID = "+p;
            DA.DeleteCommand.Connection.Open();
            DA.DeleteCommand.ExecuteNonQuery();
            DA.DeleteCommand.Connection.Close();
        }

        internal bool Exists(string p)
        {
            DA.SelectCommand.CommandText = "select * from " + Base.BaseName + "..SUMMON where IDWP = " + p;
            int i = DA.Fill(DS, "t");
            return (i>0) ? true:false;
        }
    }
}
