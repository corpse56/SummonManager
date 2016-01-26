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
        public void AddNew(string CatName)
        {
            DA.InsertCommand.CommandText = "insert into " + Base.BaseName + "..CATEGORYLIST (CATEGORYNAME) values ('" + CatName + "')";
            DA.InsertCommand.Connection.Open();
            DA.InsertCommand.ExecuteNonQuery();
            DA.InsertCommand.Connection.Close();
        }
        internal string Get(int ID)
        {
            DA.SelectCommand.CommandText = "select * from " + Base.BaseName + "..CATEGORYLIST where ID = " + ID;
            DA.Fill(DS, "t");
            return DS.Tables["t"].Rows[0]["CATEGORYNAME"].ToString();
        }
        internal void Edit(string CatName, string id)
        {
            DA.UpdateCommand.CommandText = "update " + Base.BaseName + "..CATEGORYLIST set CATEGORYNAME  = '" + CatName + "'" +
                                            " where ID = " + id;
            DA.UpdateCommand.Connection.Open();
            DA.UpdateCommand.ExecuteNonQuery();
            DA.UpdateCommand.Connection.Close();
        }
        internal void Delete(string ID)
        {
            DA.DeleteCommand.CommandText = "delete from " + Base.BaseName + "..CATEGORYLIST where ID = " + ID;
            DA.DeleteCommand.Connection.Open();
            DA.DeleteCommand.ExecuteNonQuery();
            DA.DeleteCommand.Connection.Close();
        }
        internal object GetAllExceptAll()
        {
            DA.SelectCommand.CommandText = "select ID,CATEGORYNAME from " + Base.BaseName + "..CATEGORYLIST where ID != 2";
            DA.Fill(DS, "t");
            return DS.Tables["t"];
        }
    }
}
