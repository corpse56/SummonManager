using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SummonManager
{
    class DBEXTCABLE :DB
    {
        public DBEXTCABLE() { }

        public DataTable GetAllEXTCABLENames()
        {
            DA.SelectCommand.CommandText = "select * from " + Base.BaseName + "..EXTCABLELIST order by EXTCABLENAME";
            int i = DA.Fill(DS, "t");
            return DS.Tables["t"];
        }

        public DataTable GetAllEXTCABLENamesForPack()
        {
            DA.SelectCommand.CommandText = "select * from " + Base.BaseName + "..EXTCABLELIST where EXTCABLENAME != '(нет)' order by EXTCABLENAME ";
            DA.Fill(DS, "t");
            return DS.Tables["t"];
        }
        public DataTable GetEXTCABLEsForPack(string id)
        {
            DA.SelectCommand.CommandText = "select A.ID nn,B.EXTCABLENAME name,A.COUNT cnt,A.ID id  from " + Base.BaseName + "..EXTCABLEPACK A " +
                                           " left join " + Base.BaseName + "..EXTCABLELIST B on A.IDEXTCABLE = B.ID " +
                                           " where A.IDSUMMON = " + id + " order by EXTCABLENAME";
            DA.Fill(DS, "t");
            return DS.Tables["t"];
        }

        internal void AddNewEXTCABLE(string p)
        {
            DA.InsertCommand.CommandText = "insert into " + Base.BaseName + "..EXTCABLELIST (EXTCABLENAME) values ('" + p + "')";
            DA.InsertCommand.Connection.Open();
            DA.InsertCommand.ExecuteNonQuery();
            DA.InsertCommand.Connection.Close();
        }

        internal string GetEXTCABLE(string p)
        {
            DA.SelectCommand.CommandText = "select * from " + Base.BaseName + "..EXTCABLELIST where ID = " + p;
            DA.Fill(DS, "t");
            return DS.Tables["t"].Rows[0]["EXTCABLENAME"].ToString();
        }

        internal void EditEXTCABLE(string p,string id)
        {
            DA.UpdateCommand.CommandText = "update " + Base.BaseName + "..EXTCABLELIST set EXTCABLENAME  = '" + p + "'" +
                                            " where ID = " + id;
            DA.UpdateCommand.Connection.Open();
            DA.UpdateCommand.ExecuteNonQuery();
            DA.UpdateCommand.Connection.Close();
        }

        internal void AddEXTCABLEToPack(string id, string idextc, string count)
        {
            DA.InsertCommand.CommandText = "insert into " + Base.BaseName + "..EXTCABLEPACK (IDSUMMON,IDEXTCABLE,COUNT) " +
                                          " values( '" + id + "'," + idextc + "," + count + ")";
            DA.InsertCommand.Connection.Open();
            DA.InsertCommand.ExecuteNonQuery();
            DA.InsertCommand.Connection.Close();
        }
        internal void RemoveEXTCABLEFromPack(string id)
        {
            DA.DeleteCommand.CommandText = "delete from " + Base.BaseName + "..EXTCABLEPACK where ID = " + id;
            DA.DeleteCommand.Connection.Open();
            DA.DeleteCommand.ExecuteNonQuery();
            DA.DeleteCommand.Connection.Close();
        }
        internal void RemoveAllEXTCABLEFromPackByID(string id)
        {
            DA.DeleteCommand.CommandText = "delete from " + Base.BaseName + "..EXTCABLEPACK where IDSUMMON = '" + id+"'";
            DA.DeleteCommand.Connection.Open();
            DA.DeleteCommand.ExecuteNonQuery();
            DA.DeleteCommand.Connection.Close();
        }

        internal string GetEXTCABLEsForPackReport(string id)
        {
            DA.SelectCommand.CommandText = "select B.EXTCABLENAME name,A.[COUNT] cnt from " + Base.BaseName + "..EXTCABLEPACK A " +
                                           " left join " + Base.BaseName + "..EXTCABLELIST B on A.IDEXTCABLE = B.ID " +
                                           " where A.IDSUMMON = " + id;
            DA.Fill(DS, "t");
            string res = "";
            foreach (DataRow r in DS.Tables["t"].Rows)
            {
                res += r["name"].ToString() + " - " + r["cnt"].ToString() + " шт.;";
            }
            if (res == "")
            {
                res = "<отсутствуют>";
            }
            else
            {
                res = res.Substring(0, res.Length - 1);
            }
            return res;

        }
    }
}
