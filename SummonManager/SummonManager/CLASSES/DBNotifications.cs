﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SummonManager
{
    class Notification
    {
        public string ID;
        public string IDNTYPE;
        public string IDSUMMON;
        public string IDS;
    }
    class DBNotification :DB
    {
        public DBNotification() { }
        public DataTable GetAllNTYPES()
        {
            DA.SelectCommand.CommandText = "select * from " + Base.BaseName + "..NOTIFICATIONTYPE";
            DA.Fill(DS, "t");
            return DS.Tables["t"];
        }
        public void AddNew(Notification n)
        {
            DA.InsertCommand.CommandText = "insert into " + Base.BaseName + "..NOTIFICATIONS (IDNTYPE,IDSUMMON) values ("
                                            + n.IDNTYPE + ","+n.IDSUMMON+")";
            DA.InsertCommand.Connection.Open();
            DA.InsertCommand.ExecuteNonQuery();
            DA.InsertCommand.Connection.Close();
        }
        internal List<Notification> GetNotByTYPE(string type)
        {
            DA.SelectCommand.CommandText = "select A.*,B.IDS from " + Base.BaseName + "..NOTIFICATIONS A "+
                                            " left join " + Base.BaseName + "..SUMMON B on A.IDSUMMON = B.ID where IDNTYPE = " + type;
            DA.Fill(DS, "t");
            List<Notification> ln = new List<Notification>();
            foreach (DataRow r in DS.Tables["t"].Rows)
            {
                Notification n = new Notification();
                n.ID = r["ID"].ToString();
                n.IDSUMMON = r["IDSUMMON"].ToString();
                n.IDNTYPE = r["IDNTYPE"].ToString();
                n.IDS = r["IDS"].ToString();
                ln.Add(n);
            }

            return ln;
        }
        internal void Delete(Notification n)
        {
            DA.DeleteCommand.CommandText = "delete from " + Base.BaseName + "..NOTIFICATIONS " +
                                            " where ID = " + n.ID;
            DA.DeleteCommand.Connection.Open();
            DA.DeleteCommand.ExecuteNonQuery();
            DA.DeleteCommand.Connection.Close();
        }

        internal bool IsOTKRight(string id)
        {
            DS.Clear();
            DA.SelectCommand.CommandText = "select cast(case when (SERIAL is null or SERIAL = '') and SERIALREQ = 1 then 1 else 0 end as bit) paint_otk "+
                                            " from " + Base.BaseName + "..SUMMON where ID = " + id + " and IDSTATUS not in (1,2,13,14) ";
            int i = DA.Fill(DS, "t");
            if (i == 0)
            {
                return false;
            }
            return (bool)DS.Tables["t"].Rows[0]["paint_otk"];
        }

        internal void FillNotifications()
        {

            DA.InsertCommand.CommandText =  "  insert into [ALPHA].[dbo].[NOTIFICATIONS] (IDNTYPE,IDSUMMON) " +
                          "select 1,ID from [ALPHA].[dbo].SUMMON A where (SERIAL is null or SERIAL = '') and SERIALREQ = 1 " +
                          " and A.IDSTATUS not in (1,2,13,14) " +
                         " and NOT exists (select 1 from [ALPHA].[dbo].[NOTIFICATIONS] B " +
					                      "  where B.IDNTYPE = 1 and B.IDSUMMON = A.ID)";
            DA.InsertCommand.Connection.Open();
            DA.InsertCommand.ExecuteNonQuery();
            //DA.InsertCommand.Connection.Close();

            DA.InsertCommand.CommandText = "  insert into [ALPHA].[dbo].[NOTIFICATIONS] (IDNTYPE,IDSUMMON) " +
             "select 2,ID from [ALPHA].[dbo].SUMMON A where ((SERIAL is not null and SERIAL != '') or SERIALREQ = 0) " +
             " and ((SHILD is null or SHILD = '')and SHILDREQ=1 or (PLANKA is null or PLANKA = '') and PLANKAREQ = 1)" +
             " and A.IDSTATUS not in (1,2,13,14) " +
            " and NOT exists (select 1 from [ALPHA].[dbo].[NOTIFICATIONS] B " +
                             "  where B.IDNTYPE = 2 and B.IDSUMMON = A.ID)";
            //DA.InsertCommand.Connection.Open();
            DA.InsertCommand.ExecuteNonQuery();

            DA.InsertCommand.CommandText = "  insert into [ALPHA].[dbo].[NOTIFICATIONS] (IDNTYPE,IDSUMMON) " +
             "select 3,A.ID from [ALPHA].[dbo].SUMMON A left join [ALPHA].[dbo].PURCHASEDMATERIALS pm on A.ID = pm.IDS where  " +
             " ((SHILD is not null and SHILD != '') and SHILDREQ=1 and (PLANKA is not null and PLANKA != '') and PLANKAREQ = 1)" +
             " and (pm.SHILDORDERED = 0 or pm.SHILDORDERED is null) " +
             " and A.IDSTATUS not in (1,2,13,14) " +
            " and NOT exists (select 1 from [ALPHA].[dbo].[NOTIFICATIONS] B " +
                             "  where B.IDNTYPE = 3 and B.IDSUMMON = A.ID)";
            //DA.InsertCommand.Connection.Open();
            DA.InsertCommand.ExecuteNonQuery();
            DA.InsertCommand.Connection.Close();
        }

        internal bool IsCONSTRRight(string id)
        {
            DS.Clear();
            DA.SelectCommand.CommandText = "select cast(case when (((SERIAL is not null and SERIAL != '') and SERIALREQ = 1)) and (((SHILD is null or SHILD = '')and SHILDREQ=1 or (PLANKA is null or PLANKA = '') and PLANKAREQ = 1)) then 1 else 0 end as bit) paint_constr " +
                                            " from " + Base.BaseName + "..SUMMON where ID = " + id + " and IDSTATUS not in (1,2,13,14) " ;
            int i = DA.Fill(DS, "t");
            if (i == 0)
            {
                return false;
            }
            return (bool)DS.Tables["t"].Rows[0]["paint_constr"];
        }

        internal bool IsPDBRight(string id)
        {
            DS.Clear();
            DA.SelectCommand.CommandText = "select cast(case when (((SHILD is not null and SHILD != '') and SHILDREQ=1 "+
                                           " and (PLANKA is not null and PLANKA != '') and PLANKAREQ = 1) and (pm.SHILDORDERED = 0 or pm.SHILDORDERED is null) ) " +
                                           " then 1 else 0 end as bit) paint_pdb from [ALPHA].[dbo].SUMMON A " +
             "left join [ALPHA].[dbo].PURCHASEDMATERIALS pm on A.ID = pm.IDS " +
             " where A.IDSTATUS not in (1,2,13,14) and A.ID = "+id;
            int i = DA.Fill(DS, "t");
            if (i == 0)
            {
                return false;
            }
            return (bool)DS.Tables["t"].Rows[0]["paint_pdb"];
        }
    }
}