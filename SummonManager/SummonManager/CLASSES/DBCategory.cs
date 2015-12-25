using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SummonManager
{
    class DBCategory :DB
    {
        public DBCategory() { }

        public DataTable GetAll()
        {
            DA.SelectCommand.CommandText = "select ID,CATEGORYNAME from " + Base.BaseName + "..CATEGORYLIST";
            DA.Fill(DS, "t");
            return DS.Tables["t"];
        }
        public void AddNew(string p)
        {
            DA.InsertCommand.CommandText = "insert into " + Base.BaseName + "..CATEGORYLIST (CATEGORYNAME) values ('" + p + "')";
            DA.InsertCommand.Connection.Open();
            DA.InsertCommand.ExecuteNonQuery();
            DA.InsertCommand.Connection.Close();
        }
        internal string Get(string p)
        {
            DA.SelectCommand.CommandText = "select * from " + Base.BaseName + "..CATEGORYLIST where ID = " + p;
            DA.Fill(DS, "t");
            return DS.Tables["t"].Rows[0]["CATEGORYNAME"].ToString();
        }
        internal void Edit(string p, string id)
        {
            DA.UpdateCommand.CommandText = "update " + Base.BaseName + "..CATEGORYLIST set CATEGORYNAME  = '" + p + "'" +
                                            " where ID = " + id;
            DA.UpdateCommand.Connection.Open();
            DA.UpdateCommand.ExecuteNonQuery();
            DA.UpdateCommand.Connection.Close();
        }

        internal object GetAllExceptAll()
        {
            DA.SelectCommand.CommandText = "select ID,CATEGORYNAME from " + Base.BaseName + "..CATEGORYLIST where ID != 2";
            DA.Fill(DS, "t");
            return DS.Tables["t"];
        }
    }
}
