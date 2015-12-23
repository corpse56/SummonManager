using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlTypes;

namespace SummonManager
{
    class DBSummon :DB
    {

        internal string GetNextNumber()
        {
            string start = DateTime.Now.Year.ToString() + "0101";
            string end = DateTime.Now.Year.ToString() + "1231";
            DA.SelectCommand.CommandText = "select IDS from " + Base.BaseName + "..SUMMON where CREATED = "+
                                           "(select max(CREATED) from " + Base.BaseName + "..SUMMON where CREATED between '"+start+"' and '"+end+"')";
            DS = new DataSet();
            int i = DA.Fill(DS, "t");
            if (i==0) //если первое в году
                return "0001" + "-" + DateTime.Now.ToString("yy");
            string curIDS = DS.Tables["t"].Rows[0]["IDS"].ToString();
            string number = curIDS.Substring(0, 4);
            int next = int.Parse(number)+1;
            string nextIDS = next.ToString();
            if (nextIDS.Length == 1)
                nextIDS = "000" + nextIDS;
            else
            if (nextIDS.Length == 2)
                nextIDS = "00" + nextIDS;
            else
            if (nextIDS.Length == 3)
                nextIDS = "0" + nextIDS;


            return nextIDS + "-"+DateTime.Now.ToString("yy");
        }

        internal void AddNewSummon(SummonVO SVO,UserVO UVO)
        {
            /*DA.InsertCommand.Parameters.Add("ACCEPTANCE", SqlDbType.NVarChar);
            DA.InsertCommand.Parameters["ACCEPTANCE"].Value = SVO.ACCEPTANCE;
            DA.InsertCommand.Parameters.Add("CONTRACT", SqlDbType.NVarChar);
            DA.InsertCommand.Parameters["CONTRACT"].Value = SVO.CONTRACT;
            DA.InsertCommand.Parameters.Add("CREATED", SqlDbType.DateTime);
            DA.InsertCommand.Parameters["CREATED"].Value = SVO.CREATED;
            DA.InsertCommand.Parameters.Add("DELIVERY", SqlDbType.NVarChar);
            DA.InsertCommand.Parameters["DELIVERY"].Value = SVO.DELIVERY;
            //DA.InsertCommand.Parameters.Add("IDCURSTATUS", SqlDbType.Int);
            //DA.InsertCommand.Parameters["IDCURSTATUS"].Value = SVO.IDCURSTATUS;
            DA.InsertCommand.Parameters.Add("IDCUSTOMER", SqlDbType.Int);
            DA.InsertCommand.Parameters["IDCUSTOMER"].Value = SVO.IDCUSTOMER;
            DA.InsertCommand.Parameters.Add("PAYSTATUS", SqlDbType.NVarChar);
            DA.InsertCommand.Parameters["PAYSTATUS"].Value = SVO.PAYSTATUS;
            DA.InsertCommand.Parameters.Add("IDS", SqlDbType.NVarChar);
            DA.InsertCommand.Parameters["IDS"].Value = SVO.IDS;
            DA.InsertCommand.Parameters.Add("IDSTATUS", SqlDbType.Int);
            DA.InsertCommand.Parameters["IDSTATUS"].Value = SVO.IDSTATUS;
            DA.InsertCommand.Parameters.Add("NOTE", SqlDbType.NVarChar);
            DA.InsertCommand.Parameters["NOTE"].Value = SVO.NOTE;
            DA.InsertCommand.Parameters.Add("PTIME", SqlDbType.DateTime);
            DA.InsertCommand.Parameters["PTIME"].Value = SVO.PTIME;
            DA.InsertCommand.Parameters.Add("QUANTITY", SqlDbType.Int);
            DA.InsertCommand.Parameters["QUANTITY"].Value = SVO.QUANTITY;
            DA.InsertCommand.Parameters.Add("SHIPPING", SqlDbType.NVarChar);
            DA.InsertCommand.Parameters["SHIPPING"].Value = SVO.SHIPPING;
            DA.InsertCommand.Parameters.Add("SISP", SqlDbType.Bit);
            DA.InsertCommand.Parameters["SISP"].Value = SVO.SISP;
            DA.InsertCommand.Parameters.Add("TECHREQPATH", SqlDbType.NVarChar);
            DA.InsertCommand.Parameters["TECHREQPATH"].Value = SVO.TECHREQPATH;
            DA.InsertCommand.Parameters.Add("WPNAME", SqlDbType.NVarChar);
            DA.InsertCommand.Parameters["WPNAME"].Value = SVO.WPNAME;
            DA.InsertCommand.Parameters.Add("IDWP", SqlDbType.Int);
            DA.InsertCommand.Parameters["IDWP"].Value = SVO.IDWPNAME;
            DA.InsertCommand.Parameters.Add("IDACCEPT", SqlDbType.Int);
            DA.InsertCommand.Parameters["IDACCEPT"].Value = SVO.IDACCEPT;
            DA.InsertCommand.Parameters.Add("IDPACKING", SqlDbType.Int);
            DA.InsertCommand.Parameters["IDPACKING"].Value = SVO.IDPACKING;
            DA.InsertCommand.Parameters.Add("IDEXTCABLE", SqlDbType.Int);
            DA.InsertCommand.Parameters["IDEXTCABLE"].Value = SVO.IDEXTCABLE;
            DA.InsertCommand.Parameters.Add("IDMOUNTINGKIT", SqlDbType.Int);
            DA.InsertCommand.Parameters["IDMOUNTINGKIT"].Value = SVO.IDMOUNTINGKIT;
            DA.InsertCommand.Parameters.Add("IDCUSTOMERDEPT", SqlDbType.Int);
            DA.InsertCommand.Parameters["IDCUSTOMERDEPT"].Value = SVO.IDCUSTOMERDEPT;
            DA.InsertCommand.Parameters.Add("VIEWED", SqlDbType.Bit);
            DA.InsertCommand.Parameters["VIEWED"].Value = SVO.VIEWED;
            DA.InsertCommand.Parameters.Add("PASSDATE", SqlDbType.DateTime);
            if (SVO.PASSDATE == null)
                DA.InsertCommand.Parameters["PASSDATE"].Value = SqlDateTime.Null;
            else
                DA.InsertCommand.Parameters["PASSDATE"].Value = SVO.PASSDATE;

            DA.InsertCommand.CommandText = "insert into " + Base.BaseName + "..SUMMON (ACCEPTANCE,CONTRACT,CREATED,DELIVERY,IDCUSTOMER,PAYSTATUS,IDS, "+
            " IDSTATUS,NOTE,PTIME,QUANTITY,SHIPPING,SISP,TECHREQPATH,WPNAME,IDWP,IDACCEPT,PASSDATE,IDPACKING,IDEXTCABLE,IDMOUNTINGKIT,IDCUSTOMERDEPT,VIEWED) " +
            " values (@ACCEPTANCE,@CONTRACT,@CREATED,@DELIVERY,@IDCUSTOMER,@PAYSTATUS,@IDS, " +
            " @IDSTATUS,@NOTE,@PTIME,@QUANTITY,@SHIPPING,@SISP,@TECHREQPATH,@WPNAME,@IDWP,@IDACCEPT,@PASSDATE,@IDPACKING, "+
            " @IDEXTCABLE,@IDMOUNTINGKIT,@IDCUSTOMERDEPT,@VIEWED)";
            DA.InsertCommand.Connection.Open();
            DA.InsertCommand.ExecuteNonQuery();
            DA.InsertCommand.Connection.Close();*/

            this.SaveSummon(SVO);

            DBCurStatus dbcs = new DBCurStatus();
            dbcs.AddNewCurstatus(SVO.IDS, UVO.id);

        }

        internal void SaveNewSummon(SummonVO SVO,UserVO UVO)
        {
            /*
            DA.InsertCommand.Parameters.Add("ACCEPTANCE", SqlDbType.NVarChar);
            DA.InsertCommand.Parameters["ACCEPTANCE"].Value = SVO.ACCEPTANCE;
            DA.InsertCommand.Parameters.Add("CONTRACT", SqlDbType.NVarChar);
            DA.InsertCommand.Parameters["CONTRACT"].Value = SVO.CONTRACT;
            DA.InsertCommand.Parameters.Add("CREATED", SqlDbType.DateTime);
            DA.InsertCommand.Parameters["CREATED"].Value = SVO.CREATED;
            DA.InsertCommand.Parameters.Add("DELIVERY", SqlDbType.NVarChar);
            DA.InsertCommand.Parameters["DELIVERY"].Value = SVO.DELIVERY;
            //DA.InsertCommand.Parameters.Add("IDCURSTATUS", SqlDbType.Int);
            //DA.InsertCommand.Parameters["IDCURSTATUS"].Value = SVO.IDCURSTATUS;
            DA.InsertCommand.Parameters.Add("IDCUSTOMER", SqlDbType.Int);
            DA.InsertCommand.Parameters["IDCUSTOMER"].Value = SVO.IDCUSTOMER;
            DA.InsertCommand.Parameters.Add("PAYSTATUS", SqlDbType.NVarChar);
            DA.InsertCommand.Parameters["PAYSTATUS"].Value = SVO.PAYSTATUS;
            DA.InsertCommand.Parameters.Add("IDS", SqlDbType.NVarChar);
            DA.InsertCommand.Parameters["IDS"].Value = SVO.IDS;
            DA.InsertCommand.Parameters.Add("IDSTATUS", SqlDbType.Int);
            DA.InsertCommand.Parameters["IDSTATUS"].Value = SVO.IDSTATUS;
            DA.InsertCommand.Parameters.Add("NOTE", SqlDbType.NVarChar);
            DA.InsertCommand.Parameters["NOTE"].Value = SVO.NOTE;
            DA.InsertCommand.Parameters.Add("PTIME", SqlDbType.DateTime);
            DA.InsertCommand.Parameters["PTIME"].Value = SVO.PTIME;
            DA.InsertCommand.Parameters.Add("QUANTITY", SqlDbType.Int);
            DA.InsertCommand.Parameters["QUANTITY"].Value = SVO.QUANTITY;
            DA.InsertCommand.Parameters.Add("SHIPPING", SqlDbType.NVarChar);
            DA.InsertCommand.Parameters["SHIPPING"].Value = SVO.SHIPPING;
            DA.InsertCommand.Parameters.Add("SISP", SqlDbType.Bit);
            DA.InsertCommand.Parameters["SISP"].Value = SVO.SISP;
            DA.InsertCommand.Parameters.Add("TECHREQPATH", SqlDbType.NVarChar);
            DA.InsertCommand.Parameters["TECHREQPATH"].Value = SVO.TECHREQPATH;
            DA.InsertCommand.Parameters.Add("WPNAME", SqlDbType.NVarChar);
            DA.InsertCommand.Parameters["WPNAME"].Value = SVO.WPNAME;
            DA.InsertCommand.Parameters.Add("IDWP", SqlDbType.Int);
            DA.InsertCommand.Parameters["IDWP"].Value = SVO.IDWPNAME;
            DA.InsertCommand.Parameters.Add("IDACCEPT", SqlDbType.Int);
            DA.InsertCommand.Parameters["IDACCEPT"].Value = SVO.IDACCEPT;
            DA.InsertCommand.Parameters.Add("IDPACKING", SqlDbType.Int);
            DA.InsertCommand.Parameters["IDPACKING"].Value = SVO.IDPACKING;
            DA.InsertCommand.Parameters.Add("IDEXTCABLE", SqlDbType.Int);
            DA.InsertCommand.Parameters["IDEXTCABLE"].Value = SVO.IDEXTCABLE;
            DA.InsertCommand.Parameters.Add("IDMOUNTINGKIT", SqlDbType.Int);
            DA.InsertCommand.Parameters["IDMOUNTINGKIT"].Value = SVO.IDMOUNTINGKIT;
            DA.InsertCommand.Parameters.Add("IDCUSTOMERDEPT", SqlDbType.Int);
            DA.InsertCommand.Parameters["IDCUSTOMERDEPT"].Value = SVO.IDCUSTOMERDEPT;
            DA.InsertCommand.Parameters.Add("VIEWED", SqlDbType.Bit);
            DA.InsertCommand.Parameters["VIEWED"].Value = SVO.VIEWED;
            DA.InsertCommand.Parameters.Add("PASSDATE", SqlDbType.DateTime);
            if (SVO.PASSDATE == null)
                DA.InsertCommand.Parameters["PASSDATE"].Value = SqlDateTime.Null;
            else
                DA.InsertCommand.Parameters["PASSDATE"].Value = SVO.PASSDATE;

            DA.InsertCommand.CommandText = "insert into " + Base.BaseName + "..SUMMON (ACCEPTANCE,CONTRACT,CREATED,DELIVERY,IDCUSTOMER,PAYSTATUS,IDS, " +
            "IDSTATUS,NOTE,PTIME,QUANTITY,SHIPPING,SISP,TECHREQPATH,WPNAME,IDWP,IDACCEPT,PASSDATE,IDPACKING,IDEXTCABLE,IDMOUNTINGKIT,IDCUSTOMERDEPT,VIEWED) values (@ACCEPTANCE,@CONTRACT,@CREATED,@DELIVERY,@IDCUSTOMER,@PAYSTATUS,@IDS, " +
            "@IDSTATUS,@NOTE,@PTIME,@QUANTITY,@SHIPPING,@SISP,@TECHREQPATH,@WPNAME,@IDWP,@IDACCEPT,@PASSDATE,@IDPACKING,@IDEXTCABLE,@IDMOUNTINGKIT,@IDCUSTOMERDEPT,@VIEWED)";
            DA.InsertCommand.Connection.Open();
            DA.InsertCommand.ExecuteNonQuery();
            DA.InsertCommand.Connection.Close();
            */
            this.SaveSummon(SVO);

            DBCurStatus dbcs = new DBCurStatus();
            dbcs.SaveNewCurstatus(SVO.IDS, UVO.id);

        }

        internal SummonVO GetSummonByIDS(string ids)
        {
            DA.SelectCommand.CommandText = "select * from " + Base.BaseName + "..SUMMON where IDS = '" + ids + "'";
            DA.Fill(DS, "t");
            SummonVO SVO = new SummonVO();
            SVO.ID = DS.Tables["t"].Rows[0]["ID"].ToString();
            SVO.ACCEPTANCE = DS.Tables["t"].Rows[0]["ACCEPTANCE"].ToString();
            SVO.CONTRACT = DS.Tables["t"].Rows[0]["CONTRACT"].ToString();
            SVO.CREATED = (DateTime)DS.Tables["t"].Rows[0]["CREATED"];
            SVO.DELIVERY = DS.Tables["t"].Rows[0]["DELIVERY"].ToString();
            //string tmp = DS.Tables["t"].Rows[0]["IDCURSTATUS"].ToString();
            //SVO.IDCURSTATUS = int.Parse(DS.Tables["t"].Rows[0]["IDCURSTATUS"].ToString());
            SVO.IDCUSTOMER = DS.Tables["t"].Rows[0]["IDCUSTOMER"].ToString();
            SVO.PAYSTATUS = DS.Tables["t"].Rows[0]["PAYSTATUS"].ToString();
            SVO.IDS = DS.Tables["t"].Rows[0]["IDS"].ToString();
            SVO.IDSTATUS = (int)(DS.Tables["t"].Rows[0]["IDSTATUS"]);
            SVO.NOTE = DS.Tables["t"].Rows[0]["NOTE"].ToString();
            SVO.NOTEPDB = DS.Tables["t"].Rows[0]["NOTEPDB"].ToString();
            SVO.PTIME = (DateTime)DS.Tables["t"].Rows[0]["PTIME"];
            SVO.QUANTITY = (int)DS.Tables["t"].Rows[0]["QUANTITY"];
            SVO.SHIPPING = DS.Tables["t"].Rows[0]["SHIPPING"].ToString();
            SVO.SISP = (bool)DS.Tables["t"].Rows[0]["SISP"];
            SVO.TECHREQPATH = DS.Tables["t"].Rows[0]["TECHREQPATH"].ToString();
            SVO.WPNAME = DS.Tables["t"].Rows[0]["WPNAME"].ToString();
            SVO.IDWPNAME = (int)DS.Tables["t"].Rows[0]["IDWP"];
            SVO.IDACCEPT = (int)DS.Tables["t"].Rows[0]["IDACCEPT"];
            SVO.IDPACKING = (int)DS.Tables["t"].Rows[0]["IDPACKING"];
            SVO.IDEXTCABLE = (int)DS.Tables["t"].Rows[0]["IDEXTCABLE"];
            SVO.IDMOUNTINGKIT = (int)DS.Tables["t"].Rows[0]["IDMOUNTINGKIT"];
            SVO.IDCUSTOMERDEPT = (int)DS.Tables["t"].Rows[0]["IDCUSTOMERDEPT"];
            SVO.OTKCOMMENT = DS.Tables["t"].Rows[0]["otkcomment"].ToString();
            SVO.VIEWED = (bool)DS.Tables["t"].Rows[0]["VIEWED"];
            SVO.SHILD = DS.Tables["t"].Rows[0]["SHILD"].ToString();
            SVO.PLANKA = DS.Tables["t"].Rows[0]["PLANKA"].ToString();
            SVO.SBORKA3D = DS.Tables["t"].Rows[0]["SBORKA3D"].ToString();
            SVO.ZHGUT = DS.Tables["t"].Rows[0]["ZHGUT"].ToString();
            SVO.SERIAL = DS.Tables["t"].Rows[0]["SERIAL"].ToString();
            SVO.COMPOSITION = DS.Tables["t"].Rows[0]["COMPOSITION"].ToString();
            SVO.METAL = DS.Tables["t"].Rows[0]["METAL"].ToString();
            SVO.SHILDREQ = (bool)DS.Tables["t"].Rows[0]["SHILDREQ"];
            SVO.PLANKAREQ = (bool)DS.Tables["t"].Rows[0]["PLANKAREQ"];
            SVO.SBORKA3DREQ = (bool)DS.Tables["t"].Rows[0]["SBORKA3DREQ"];
            SVO.SERIALREQ = (bool)DS.Tables["t"].Rows[0]["SERIALREQ"];
            SVO.COMPOSITIONREQ = (bool)DS.Tables["t"].Rows[0]["COMPOSITIONREQ"];
            SVO.METALREQ = (bool)DS.Tables["t"].Rows[0]["METALREQ"];
            if (DS.Tables["t"].Rows[0]["PASSDATE"] == DBNull.Value)
            {
                SVO.PASSDATE = null;
                SVO.PASSDATETEXT = "Не определено";
            }
            else
            {
                SVO.PASSDATE = (DateTime)DS.Tables["t"].Rows[0]["PASSDATE"];
                SVO.PASSDATETEXT = ((DateTime)DS.Tables["t"].Rows[0]["PASSDATE"]).ToString("dd.MM.yyyy");
            }

            return SVO;            
        }

        internal void SaveSummon(SummonVO SVO)
        {
            DA.UpdateCommand.Parameters.Add("ID", SqlDbType.Int);
            DA.UpdateCommand.Parameters["ID"].Value = SVO.ID;
            DA.UpdateCommand.Parameters.Add("ACCEPTANCE", SqlDbType.NVarChar);
            DA.UpdateCommand.Parameters["ACCEPTANCE"].Value = SVO.ACCEPTANCE;
            DA.UpdateCommand.Parameters.Add("CONTRACT", SqlDbType.NVarChar);
            DA.UpdateCommand.Parameters["CONTRACT"].Value = SVO.CONTRACT;
            DA.UpdateCommand.Parameters.Add("CREATED", SqlDbType.DateTime);
            DA.UpdateCommand.Parameters["CREATED"].Value = SVO.CREATED;
            DA.UpdateCommand.Parameters.Add("DELIVERY", SqlDbType.NVarChar);
            DA.UpdateCommand.Parameters["DELIVERY"].Value = SVO.DELIVERY;
            //DA.UpdateCommand.Parameters.Add("IDCURSTATUS", SqlDbType.Int);
            //DA.UpdateCommand.Parameters["IDCURSTATUS"].Value = SVO.IDCURSTATUS;
            DA.UpdateCommand.Parameters.Add("IDCUSTOMER", SqlDbType.Int);
            DA.UpdateCommand.Parameters["IDCUSTOMER"].Value = SVO.IDCUSTOMER;
            DA.UpdateCommand.Parameters.Add("PAYSTATUS", SqlDbType.NVarChar);
            DA.UpdateCommand.Parameters["PAYSTATUS"].Value = SVO.PAYSTATUS;
            DA.UpdateCommand.Parameters.Add("IDS", SqlDbType.NVarChar);
            DA.UpdateCommand.Parameters["IDS"].Value = SVO.IDS;
            //DA.UpdateCommand.Parameters.Add("IDSTATUS", SqlDbType.Int);
            //DA.UpdateCommand.Parameters["IDSTATUS"].Value = SVO.IDSTATUS;
            DA.UpdateCommand.Parameters.Add("NOTE", SqlDbType.NVarChar);
            DA.UpdateCommand.Parameters["NOTE"].Value = SVO.NOTE;
            DA.UpdateCommand.Parameters.Add("NOTEPDB", SqlDbType.NVarChar);
            DA.UpdateCommand.Parameters["NOTEPDB"].Value = SVO.NOTEPDB;
            DA.UpdateCommand.Parameters.Add("PTIME", SqlDbType.DateTime);
            DA.UpdateCommand.Parameters["PTIME"].Value = SVO.PTIME;
            DA.UpdateCommand.Parameters.Add("QUANTITY", SqlDbType.Int);
            DA.UpdateCommand.Parameters["QUANTITY"].Value = SVO.QUANTITY;
            DA.UpdateCommand.Parameters.Add("SHIPPING", SqlDbType.NVarChar);
            DA.UpdateCommand.Parameters["SHIPPING"].Value = SVO.SHIPPING;
            DA.UpdateCommand.Parameters.Add("SISP", SqlDbType.Bit);
            DA.UpdateCommand.Parameters["SISP"].Value = SVO.SISP;
            DA.UpdateCommand.Parameters.Add("TECHREQPATH", SqlDbType.NVarChar);
            DA.UpdateCommand.Parameters["TECHREQPATH"].Value = SVO.TECHREQPATH;
            DA.UpdateCommand.Parameters.Add("WPNAME", SqlDbType.NVarChar);
            DA.UpdateCommand.Parameters["WPNAME"].Value = SVO.WPNAME;
            DA.UpdateCommand.Parameters.Add("IDWP", SqlDbType.Int);
            DA.UpdateCommand.Parameters["IDWP"].Value = SVO.IDWPNAME;
            DA.UpdateCommand.Parameters.Add("IDACCEPT", SqlDbType.Int);
            DA.UpdateCommand.Parameters["IDACCEPT"].Value = SVO.IDACCEPT;
            DA.UpdateCommand.Parameters.Add("IDPACKING", SqlDbType.Int);
            DA.UpdateCommand.Parameters["IDPACKING"].Value = SVO.IDPACKING;
            DA.UpdateCommand.Parameters.Add("IDEXTCABLE", SqlDbType.Int);
            DA.UpdateCommand.Parameters["IDEXTCABLE"].Value = SVO.IDEXTCABLE;
            DA.UpdateCommand.Parameters.Add("IDMOUNTINGKIT", SqlDbType.Int);
            DA.UpdateCommand.Parameters["IDMOUNTINGKIT"].Value = SVO.IDMOUNTINGKIT;
            DA.UpdateCommand.Parameters.Add("IDCUSTOMERDEPT", SqlDbType.Int);
            DA.UpdateCommand.Parameters["IDCUSTOMERDEPT"].Value = SVO.IDCUSTOMERDEPT;
            DA.UpdateCommand.Parameters.Add("VIEWED", SqlDbType.Bit);
            DA.UpdateCommand.Parameters["VIEWED"].Value = SVO.VIEWED;
            DA.UpdateCommand.Parameters.Add("SHILD", SqlDbType.NVarChar);
            DA.UpdateCommand.Parameters["SHILD"].Value = SVO.SHILD;
            DA.UpdateCommand.Parameters.Add("PLANKA", SqlDbType.NVarChar);
            DA.UpdateCommand.Parameters["PLANKA"].Value = SVO.PLANKA;
            DA.UpdateCommand.Parameters.Add("SBORKA3D", SqlDbType.NVarChar);
            DA.UpdateCommand.Parameters["SBORKA3D"].Value = SVO.SBORKA3D;
            DA.UpdateCommand.Parameters.Add("ZHGUT", SqlDbType.NVarChar);
            DA.UpdateCommand.Parameters["ZHGUT"].Value = SVO.ZHGUT;
            DA.UpdateCommand.Parameters.Add("SERIAL", SqlDbType.NVarChar);
            DA.UpdateCommand.Parameters["SERIAL"].Value = SVO.SERIAL;
            DA.UpdateCommand.Parameters.Add("COMPOSITION", SqlDbType.NVarChar);
            DA.UpdateCommand.Parameters["COMPOSITION"].Value = SVO.COMPOSITION;
            DA.UpdateCommand.Parameters.Add("METAL", SqlDbType.NVarChar);
            DA.UpdateCommand.Parameters["METAL"].Value = SVO.METAL;

            DA.UpdateCommand.Parameters.Add("SHILDREQ", SqlDbType.Bit);
            DA.UpdateCommand.Parameters["SHILDREQ"].Value = SVO.SHILDREQ;
            DA.UpdateCommand.Parameters.Add("PLANKAREQ", SqlDbType.Bit);
            DA.UpdateCommand.Parameters["PLANKAREQ"].Value = SVO.PLANKAREQ;
            DA.UpdateCommand.Parameters.Add("SBORKA3DREQ", SqlDbType.Bit);
            DA.UpdateCommand.Parameters["SBORKA3DREQ"].Value = SVO.SBORKA3DREQ;
            DA.UpdateCommand.Parameters.Add("SERIALREQ", SqlDbType.Bit);
            DA.UpdateCommand.Parameters["SERIALREQ"].Value = SVO.SERIALREQ;
            DA.UpdateCommand.Parameters.Add("COMPOSITIONREQ", SqlDbType.Bit);
            DA.UpdateCommand.Parameters["COMPOSITIONREQ"].Value = SVO.COMPOSITIONREQ;
            DA.UpdateCommand.Parameters.Add("METALREQ", SqlDbType.Bit);
            DA.UpdateCommand.Parameters["METALREQ"].Value = SVO.METALREQ;


            DA.UpdateCommand.Parameters.Add("PASSDATE", SqlDbType.DateTime);
            if (SVO.PASSDATE == null)
                DA.UpdateCommand.Parameters["PASSDATE"].Value = SqlDateTime.Null;
            else
                DA.UpdateCommand.Parameters["PASSDATE"].Value = SVO.PASSDATE;

            DA.UpdateCommand.CommandText = "update " + Base.BaseName + "..SUMMON set ACCEPTANCE=@ACCEPTANCE,CONTRACT=@CONTRACT,DELIVERY=@DELIVERY,IDCUSTOMER=@IDCUSTOMER,PAYSTATUS=@PAYSTATUS, " +
            "NOTE=@NOTE,PTIME=@PTIME,QUANTITY=@QUANTITY,SHIPPING=@SHIPPING,SISP=@SISP,TECHREQPATH=@TECHREQPATH,WPNAME=@WPNAME  " +
            ", IDWP = @IDWP,IDACCEPT = @IDACCEPT,PASSDATE = @PASSDATE,IDPACKING = @IDPACKING, NOTEPDB = @NOTEPDB, CREATED = @CREATED " +
            " , IDMOUNTINGKIT = @IDMOUNTINGKIT, IDCUSTOMERDEPT = @IDCUSTOMERDEPT, IDEXTCABLE = @IDEXTCABLE, VIEWED = @VIEWED , IDS = @IDS " +
            " , SHILD=@SHILD, PLANKA=@PLANKA, SBORKA3D=@SBORKA3D, ZHGUT=@ZHGUT, SERIAL=@SERIAL,COMPOSITION = @COMPOSITION, METAL = @METAL " +
            " , SHILDREQ=@SHILDREQ, PLANKAREQ=@PLANKAREQ, SBORKA3DREQ=@SBORKA3DREQ, SERIALREQ=@SERIALREQ,COMPOSITIONREQ = @COMPOSITIONREQ, METALREQ = @METALREQ " +
            " where ID = @ID";
            DA.UpdateCommand.Connection.Open();
            DA.UpdateCommand.ExecuteNonQuery();
            DA.UpdateCommand.Connection.Close();
        }

        internal void PassToOZIS(SummonVO SVO,string userid)
        {
            this.SaveSummon(SVO);
            DBCurStatus dbcs = new DBCurStatus();
            dbcs.ChangeStatus(SVO,2,"-",userid);
        }

        internal void PassToProd(SummonVO SVO, string userid)
        {
            this.SaveSummon(SVO);
            DBCurStatus dbcs = new DBCurStatus();
            dbcs.ChangeStatus(SVO, 3, "-", userid);
        }

        internal void PassToOTK(SummonVO SVO, string userid)
        {
            this.SaveSummon(SVO);
            DBCurStatus dbcs = new DBCurStatus();
            dbcs.ChangeStatus(SVO, 7, "-", userid);
        }

        internal void PassToWare(SummonVO SVO, string userid)
        {
            this.SaveSummon(SVO);
            DBCurStatus dbcs = new DBCurStatus();
            dbcs.ChangeStatus(SVO, 9, "-", userid);
        }


        internal void PassToFinish(SummonVO SVO, string userid)
        {
            this.SaveSummon(SVO);
            DBCurStatus dbcs = new DBCurStatus();
            dbcs.ChangeStatus(SVO, 13, "-", userid);
        }

        internal string GetCustomerName(string p)
        {
            DA.SelectCommand.CommandText = "select * from " + Base.BaseName + "..CUSTOMERS where ID = " + p;
            DS = new DataSet();
            DA.Fill(DS, "t");
            return DS.Tables["t"].Rows[0]["CNAME"].ToString();
        }

        internal string GetCustomerContact(string p)
        {
            DA.SelectCommand.CommandText = "select * from " + Base.BaseName + "..CUSTOMERS where ID = " + p;
            DS = new DataSet();
            DA.Fill(DS, "t");
            return DS.Tables["t"].Rows[0]["CONTACT"].ToString();
        }

        internal string GetStatusName(int p)
        {
            DA.SelectCommand.CommandText = "select * from " + Base.BaseName + "..STATUSLIST where ID = " + p;
            DS = new DataSet();
            DA.Fill(DS, "t");
            return DS.Tables["t"].Rows[0]["SNAME"].ToString();
        }

        internal DataTable GetHistory(string ids)
        {
            //DA.SelectCommand.CommandText = "select A.IDS ids,B.SNAME sts, A.CAUSE cause, A.CHANGED chg, C.FIO fio " +
            //                               " from " + Base.BaseName + "..CURSTATUS A " +
            //                               " left join " + Base.BaseName + "..STATUSLIST B on A.STATID = B.ID " +
            //                               " left join " + Base.BaseName + "..USERS C on A.IDUSER = C.ID " +
            //                               " where A.IDS = '" + ids+"'";
            DA.SelectCommand.CommandText = "select A.IDS ids,B.SNAME sts, A.CAUSE cause, A.CHANGED chg, C.FIO fio, DATEDIFF(minute, A.CHANGED,N.CHANGED) ts " +
             "from " + Base.BaseName + "..CURSTATUS A  " +
             " left join " + Base.BaseName + "..STATUSLIST B on A.STATID = B.ID  " +
             " left join " + Base.BaseName + "..USERS C on A.IDUSER = C.ID  " +
             " left join " + Base.BaseName + "..CURSTATUS N on N.IDS = A.IDS  " +
             " where A.IDS = '" + ids + "'  " +
             " and N.ID = (select MIN(NN.ID) from " + Base.BaseName + "..CURSTATUS NN  " +
			 "             where NN.IDS = A.IDS and NN.ID > A.ID) "+
            "union all "+
            "select A.IDS ids,B.SNAME sts, A.CAUSE cause, A.CHANGED chg, C.FIO fio , DATEDIFF(minute,  A.CHANGED,GETDATE()) ts "+
            " from " + Base.BaseName + "..CURSTATUS A  " +
            "  left join " + Base.BaseName + "..STATUSLIST B on A.STATID = B.ID  " +
            "  left join " + Base.BaseName + "..USERS C on A.IDUSER = C.ID  " +
            "  where A.IDS = '" + ids + "' " +
            " and A.ID = (select MAX(ID) from  " + Base.BaseName + "..CURSTATUS AA where AA.IDS =  '" + ids + "')";
            DS = new DataSet();
            DA.Fill(DS, "t");
            return DS.Tables["t"];
        }
        internal DataTable GetPieChart(DateTime dstart,DateTime dend)
        {
            //DA.SelectCommand.CommandText = "select A.IDS ids,B.SNAME sts, A.CAUSE cause, A.CHANGED chg, C.FIO fio " +
            //                               " from " + Base.BaseName + "..CURSTATUS A " +
            //                               " left join " + Base.BaseName + "..STATUSLIST B on A.STATID = B.ID " +
            //                               " left join " + Base.BaseName + "..USERS C on A.IDUSER = C.ID " +
            //                               " where A.IDS = '" + ids+"'";
            DA.SelectCommand.CommandText = "with F0 as (  " +
            "select distinct B.SNAME sts, DATEDIFF(minute, A.CHANGED,N.CHANGED) ts,B.ID id  " +
            "from " + Base.BaseName + "..STATUSLIST B  " +
            " join " + Base.BaseName + "..CURSTATUS A  on A.STATID = B.ID " +
            " left join " + Base.BaseName + "..CURSTATUS N on N.IDS = A.IDS   " +
            "left join " + Base.BaseName + "..SUMMON S on S.IDS = A.IDS   " +
            "where cast(cast(S.CREATED as varchar(11)) as datetime) between '" + dstart.ToString("yyyyMMdd") + "' and  '" + dend.ToString("yyyyMMdd") + "' " +
            "and B.ID != 13 and B.ID != 14 and N.ID = (select MIN(NN.ID) from " + Base.BaseName + "..CURSTATUS NN   " +
            "             where NN.IDS = A.IDS and NN.ID > A.ID)  " +
            "union all  " +
            "select distinct B.SNAME sts,  DATEDIFF(minute,  A.CHANGED,GETDATE()) ts,B.ID id " +
            "from " + Base.BaseName + "..STATUSLIST B  " +
            " join " + Base.BaseName + "..CURSTATUS A  on A.STATID = B.ID   " +
            " left join " + Base.BaseName + "..SUMMON S on S.IDS = A.IDS   " +
            "where cast(cast(S.CREATED as varchar(11)) as datetime) between '" + dstart.ToString("yyyyMMdd") + "' and  '" + dend.ToString("yyyyMMdd") + "' " +
            " and B.ID != 13 and B.ID != 14 and A.ID = (select MAX(ID) from  " + Base.BaseName + "..CURSTATUS AA where AA.IDS =  A.IDS) " +
            " ), " +
            " F1 as " +
            " ( " +
            " select sts sts,SUM(ts) ts, id id  from F0 " +
            "  group by sts,id " +
            " union all " +
            " select SNAME sts,SUM(0) ts, id id from  " +
            " " + Base.BaseName + "..STATUSLIST B  " +
            " where B.ID != 13 and B.ID != 14 " +
            " group by SNAME,id " +
            " ), " +
            " F2 as " +
            "( " +
            "select sts sts, SUM(ts) ts,id id from F1  " +
            "group by sts,id  " +
            "), F3 as( " +
            "select case when id = 16 then 'ОТК' else  " +
            "       case when id = 17 then 'ПДБ. В работе' else " +
            "       case when id = 15 or id = 18 then 'У монтажников' else sts end end end sts, " +
            "       SUM(ts) ts, " +
            "       case when id = 16 then 7 else  " +
            "       case when id = 17 then 3 else " +
            "       case when id = 15 or id = 18 then 15 else id end end end id " +
            "        from F2  " +
            "       group by sts,id) " +
            "select sts, SUM(ts) ts,id from F3 group by sts,id order by id";
            DS = new DataSet();
            DA.Fill(DS, "t");
            return DS.Tables["t"];
        }



        internal void PassToPrepProduction(SummonVO SVO, string userid)
        {
            this.SaveSummon(SVO);
            DBCurStatus dbcs = new DBCurStatus();
            dbcs.ChangeStatus(SVO, 2, "-", userid);
        }

        internal void PassToPDB(SummonVO SVO, string userid)
        {
            this.SaveSummon(SVO);
            DBCurStatus dbcs = new DBCurStatus();
            dbcs.ChangeStatus(SVO, 3, "-", userid);
        }

        internal void PassToWorkshop(SummonVO SVO, string userid)
        {
            this.SaveSummon(SVO);
            DBCurStatus dbcs = new DBCurStatus();
            dbcs.ChangeStatus(SVO, 5, "-", userid);
        }

        internal void PassToProdFromWorkshop(SummonVO SVO, string userid)
        {
            this.SaveSummon(SVO);
            DBCurStatus dbcs = new DBCurStatus();
            dbcs.ChangeStatus(SVO, 4, "-", userid);
        }

        internal void PassToManagerFinish(SummonVO SVO, string userid)
        {
            this.SaveSummon(SVO);
            DBCurStatus dbcs = new DBCurStatus();
            dbcs.ChangeStatus(SVO, 11, "-", userid);
        }
        internal void PassBackToManager(SummonVO SVO, string userid, string cause)
        {
            this.SaveSummon(SVO);
            DBCurStatus dbcs = new DBCurStatus();
            dbcs.ChangeStatus(SVO, 1, cause, userid);
        }

        internal string GetCustomerAddress(string p)
        {
            DA.SelectCommand.CommandText = "select * from " + Base.BaseName + "..CUSTOMERS where ID = " + p;
            DS = new DataSet();
            DA.Fill(DS, "t");
            return DS.Tables["t"].Rows[0]["ADDRESS"].ToString();
        }

        internal string GetCustomerContactExe(string p)
        {
            DA.SelectCommand.CommandText = "select * from " + Base.BaseName + "..CUSTOMERS where ID = " + p;
            DS = new DataSet();
            DA.Fill(DS, "t");
            return DS.Tables["t"].Rows[0]["CONTACTEXE"].ToString();
        }

        internal string GetCustomerContactLog(string p)
        {
            DA.SelectCommand.CommandText = "select * from " + Base.BaseName + "..CUSTOMERS where ID = " + p;
            DS = new DataSet();
            DA.Fill(DS, "t");
            return DS.Tables["t"].Rows[0]["CONTACTFINLOG"].ToString();
        }


        internal void DeleteSummon(string ids)
        {
            DA.DeleteCommand = new System.Data.SqlClient.SqlCommand();
            DA.DeleteCommand.Connection = new System.Data.SqlClient.SqlConnection(MainF.ConnectionString);
            DA.DeleteCommand.Parameters.Add("ids", SqlDbType.NVarChar);
            DA.DeleteCommand.Parameters["ids"].Value = ids;
            DA.DeleteCommand.CommandText = "delete from " + Base.BaseName + "..SUMMON where IDS = @ids";
            DA.DeleteCommand.Connection.Open();
            DA.DeleteCommand.ExecuteNonQuery();
            DA.DeleteCommand.Connection.Close();
        }
        internal void DeleteSummonByID(string id)
        {
            DA.DeleteCommand = new System.Data.SqlClient.SqlCommand();
            DA.DeleteCommand.Connection = new System.Data.SqlClient.SqlConnection(MainF.ConnectionString);
            DA.DeleteCommand.Parameters.Add("id", SqlDbType.Int);
            DA.DeleteCommand.Parameters["id"].Value = id;
            DA.DeleteCommand.CommandText = "delete from " + Base.BaseName + "..SUMMON where ID = @id";
            DA.DeleteCommand.Connection.Open();
            DA.DeleteCommand.ExecuteNonQuery();
            DA.DeleteCommand.Connection.Close();
        }
        internal void AddOTKComment(string id,string comment)
        {
            DA.UpdateCommand = new System.Data.SqlClient.SqlCommand();
            DA.UpdateCommand.Connection = new System.Data.SqlClient.SqlConnection(MainF.ConnectionString);
            DA.UpdateCommand.Parameters.Add("id", SqlDbType.Int);
            DA.UpdateCommand.Parameters["id"].Value = id;
            DA.UpdateCommand.Parameters.Add("comment", SqlDbType.NVarChar);
            DA.UpdateCommand.Parameters["comment"].Value = comment;
            DA.UpdateCommand.CommandText = "update " + Base.BaseName + "..SUMMON set otkcomment = @comment where ID = @id";
            DA.UpdateCommand.Connection.Open();
            DA.UpdateCommand.ExecuteNonQuery();
            DA.UpdateCommand.Connection.Close();
        }
        internal int AddNIPSummon()
        {
            DA.InsertCommand.CommandText = "insert into " + Base.BaseName + "..SUMMON (IDS,IDSTATUS,QUANTITY) " +
            " values ('',14,0);select SCOPE_IDENTITY()";
            DA.InsertCommand.Connection.Open();

            int idresult = Convert.ToInt32(DA.InsertCommand.ExecuteScalar());
            DA.InsertCommand.Connection.Close();
            return idresult;
        }
        internal void DeleteNIPSummons()
        {
            DA.DeleteCommand = new System.Data.SqlClient.SqlCommand();
            DA.DeleteCommand.Connection = new System.Data.SqlClient.SqlConnection(MainF.ConnectionString);
            DA.DeleteCommand.CommandText = "delete from " + Base.BaseName + "..SUMMON where IDSTATUS = 14";
            DA.DeleteCommand.Connection.Open();
            DA.DeleteCommand.ExecuteNonQuery();
            DA.DeleteCommand.Connection.Close();
        }

        internal void SetViewed(string id)
        {
            DA.UpdateCommand = new System.Data.SqlClient.SqlCommand();
            DA.UpdateCommand.Connection = new System.Data.SqlClient.SqlConnection(MainF.ConnectionString);
            DA.UpdateCommand.CommandText = "update " + Base.BaseName + "..SUMMON set VIEWED = 1 where ID = "+id;
            DA.UpdateCommand.Connection.Open();
            DA.UpdateCommand.ExecuteNonQuery();
            DA.UpdateCommand.Connection.Close();


        }

        internal string GetCustomerDeptName(int IDDEPT,string IDCUST)
        {
            DA.SelectCommand.CommandText = "select * from " + Base.BaseName + "..CUSTOMERDEPTLIST where IDCUSTOMER = " + IDCUST+ 
                                            " and ID = " +IDDEPT;
            DS = new DataSet();
            DA.Fill(DS, "t");
            return DS.Tables["t"].Rows[0]["DEPTNAME"].ToString();
        }

        internal string GetDeptContactExe(int IDDEPT, string IDCUST)
        {
            DA.SelectCommand.CommandText = "select * from " + Base.BaseName + "..CUSTOMERDEPTLIST where IDCUSTOMER = " + IDCUST +
                                            " and ID = " + IDDEPT;
            DS = new DataSet();
            DA.Fill(DS, "t");
            return DS.Tables["t"].Rows[0]["CONTACTEXE"].ToString();
        }

        internal string GetDeptContactLog(int IDDEPT, string IDCUST)
        {
            DA.SelectCommand.CommandText = "select * from " + Base.BaseName + "..CUSTOMERDEPTLIST where IDCUSTOMER = " + IDCUST +
                                            " and ID = " + IDDEPT;
            DS = new DataSet();
            DA.Fill(DS, "t");
            return DS.Tables["t"].Rows[0]["CONTACTFINLOG"].ToString();
        }



        internal void PassDateChanged(string id)
        {
            DA.UpdateCommand = new System.Data.SqlClient.SqlCommand();
            DA.UpdateCommand.Connection = new System.Data.SqlClient.SqlConnection(MainF.ConnectionString);
            DA.UpdateCommand.CommandText = "update " + Base.BaseName + "..SUMMON set PASSDATECHANGED = getdate() where ID = " + id;
            DA.UpdateCommand.Connection.Open();
            DA.UpdateCommand.ExecuteNonQuery();
            DA.UpdateCommand.Connection.Close();
        }



        internal void AddSummonView(SummonVO SVO, UserVO UVO)
        {
            DA.InsertCommand = new System.Data.SqlClient.SqlCommand();
            DA.InsertCommand.Connection = new System.Data.SqlClient.SqlConnection(MainF.ConnectionString);
            DA.InsertCommand.CommandText = "insert into " + Base.BaseName + "..SUMMONVIEWS (IDSUMMON,DATEVIEWED,IDUSER) values "+
                "("+SVO.ID+",getdate(),"+UVO.id+") ";
            DA.InsertCommand.Connection.Open();
            DA.InsertCommand.ExecuteNonQuery();
            DA.InsertCommand.Connection.Close();
        }
    }
}
