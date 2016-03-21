using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SummonManager
{
    class OLDDBCable :DB
    {
        public OLDDBCable() { }
        public DataTable GetAll()
        {
            DA.SelectCommand.CommandText = "select * from " + Base.BaseName + "..CABLELIST";
            DA.Fill(DS, "t");
            return DS.Tables["t"];
        }
        public void AddNew(string p)
        {
            DA.InsertCommand.CommandText = "insert into " + Base.BaseName + "..CABLELIST (CNAME) values ('" + p + "')";
            DA.InsertCommand.Connection.Open();
            DA.InsertCommand.ExecuteNonQuery();
            DA.InsertCommand.Connection.Close();
        }
        internal string Get(string p)
        {
            DA.SelectCommand.CommandText = "select * from " + Base.BaseName + "..CABLELIST where ID = " + p;
            DA.Fill(DS, "t");
            return DS.Tables["t"].Rows[0]["CNAME"].ToString();
        }
        internal void Edit(string p, string id)
        {
            DA.UpdateCommand.CommandText = "update " + Base.BaseName + "..CABLELIST set CNAME  = '" + p + "'" +
                                            " where ID = " + id;
            DA.UpdateCommand.Connection.Open();
            DA.UpdateCommand.ExecuteNonQuery();
            DA.UpdateCommand.Connection.Close();
        }
    }
}
