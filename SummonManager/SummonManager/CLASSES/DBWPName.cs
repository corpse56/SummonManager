using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SummonManager.CLASSES;

namespace SummonManager
{
    class DBWPName :DB
    {
        public DBWPName() { }

        public DataTable GetAllWPNames()
        {
            DA.SelectCommand.CommandText = "select A.ID,A.WPNAME,B.CATEGORYNAME,isnull(C.SUBCATNAME,'Не присвоено') SUBCATNAME,A.DECNUM,A.COMPOSITION,A.DIMENSIONALDRAWING,A.POWERSUPPLY,A.CONFIGURATION,A.NOTE from " 
                                            + Base.BaseName + "..WPNAMELIST A left join " + Base.BaseName + "..CATEGORYLIST B on B.ID = IDCATEGORY "+
                                           " left join " + Base.BaseName + "..SUBCATEGORYLIST C on C.ID = A.IDSUBCAT " +
                                           " order by WPNAME";
            DS = new DataSet();
            int h = DA.Fill(DS, "t");
            return DS.Tables["t"];
        }
        public DataTable GetCategoryWPNames(int IDCAT, int IDSUBCAT)
        {
            if (IDCAT == 2) return this.GetAllWPNames();
            string sub = new DBSubCategory().GetNameByID(IDSUBCAT);
            if (sub == "Все")
            {
                DA.SelectCommand.CommandText = "select A.ID,A.WPNAME,B.CATEGORYNAME,isnull(C.SUBCATNAME,'Не присвоено') SUBCATNAME,A.DECNUM,A.COMPOSITION,A.DIMENSIONALDRAWING,A.POWERSUPPLY,A.CONFIGURATION,A.NOTE from "
                                                + Base.BaseName + "..WPNAMELIST A left join " + Base.BaseName + "..CATEGORYLIST B on B.ID = IDCATEGORY " +
                                               " left join " + Base.BaseName + "..SUBCATEGORYLIST C on C.ID = A.IDSUBCAT " +
                                               " where A.IDCATEGORY = " + IDCAT + " order by WPNAME";
            }
            else if (sub.ToUpper() == "НЕ ПРИСВОЕНО")
            {
                DA.SelectCommand.CommandText = "select A.ID,A.WPNAME,B.CATEGORYNAME,isnull(C.SUBCATNAME,'Не присвоено') SUBCATNAME,A.DECNUM,A.COMPOSITION,A.DIMENSIONALDRAWING,A.POWERSUPPLY,A.CONFIGURATION,A.NOTE from "
                                                + Base.BaseName + "..WPNAMELIST A left join " + Base.BaseName + "..CATEGORYLIST B on B.ID = IDCATEGORY " +
                                               " left join " + Base.BaseName + "..SUBCATEGORYLIST C on C.ID = A.IDSUBCAT " +
                                               " where A.IDCATEGORY = " + IDCAT + " and (A.IDSUBCAT is null)  order by WPNAME";
            }
            else
            {
                DA.SelectCommand.CommandText = "select A.ID,A.WPNAME,B.CATEGORYNAME,isnull(C.SUBCATNAME,'Не присвоено') SUBCATNAME,A.DECNUM,A.COMPOSITION,A.DIMENSIONALDRAWING,A.POWERSUPPLY,A.CONFIGURATION,A.NOTE from "
                                                + Base.BaseName + "..WPNAMELIST A left join " + Base.BaseName + "..CATEGORYLIST B on B.ID = IDCATEGORY " +
                                               " left join " + Base.BaseName + "..SUBCATEGORYLIST C on C.ID = A.IDSUBCAT " +
                                               " where A.IDCATEGORY = " + IDCAT + " and (A.IDSUBCAT = " + IDSUBCAT + ")  order by WPNAME";
            }

            DS = new DataSet();
            int h = DA.Fill(DS, "t");
            return DS.Tables["t"];
        }
        public DataTable GetCategoryWPNames(int IDCAT)
        {
            if (IDCAT == 2) return this.GetAllWPNames();
            DA.SelectCommand.CommandText = "select A.ID,A.WPNAME,B.CATEGORYNAME,isnull(C.SUBCATNAME,'Не присвоено') SUBCATNAME,A.DECNUM,A.COMPOSITION,A.DIMENSIONALDRAWING,A.POWERSUPPLY,A.CONFIGURATION,A.NOTE from "
                                            + Base.BaseName + "..WPNAMELIST A left join " + Base.BaseName + "..CATEGORYLIST B on B.ID = IDCATEGORY " +
                                           " left join " + Base.BaseName + "..SUBCATEGORYLIST C on C.ID = A.IDSUBCAT " +
                                           " where A.IDCATEGORY = " + IDCAT + " order by WPNAME";
            DS = new DataSet();
            int h = DA.Fill(DS, "t");
            return DS.Tables["t"];
        }

        internal void AddNewWP(WPNameVO p)
        {
            DA.InsertCommand.Parameters.Clear();
            DA.InsertCommand.Parameters.AddWithValue("WPNAME", p.WPName);
            DA.InsertCommand.Parameters.AddWithValue("IDCATEGORY", p.IDCat);
            DA.InsertCommand.Parameters.AddWithValue("IDSUBCAT", p.IDSubCat);
            DA.InsertCommand.Parameters.AddWithValue("DECNUM", p.DecNum);
            DA.InsertCommand.Parameters.AddWithValue("CONFIGURATION", ((object)p.CONFIGURATION) ?? DBNull.Value);
            DA.InsertCommand.Parameters.AddWithValue("COMPOSITION", ((object)p.COMPOSITION ) ?? DBNull.Value);
            DA.InsertCommand.Parameters.AddWithValue("DIMENSIONALDRAWING", ((object)p.DIMENDRAWING) ?? DBNull.Value);
            DA.InsertCommand.Parameters.AddWithValue("POWERSUPPLY", p.PowerSupply);
            DA.InsertCommand.Parameters.AddWithValue("NOTE", p.Note);
            DA.InsertCommand.Parameters.AddWithValue("CREATED", DateTime.Now);
            DA.InsertCommand.CommandText = "insert into " + Base.BaseName + "..WPNAMELIST (WPNAME,IDCATEGORY,DECNUM,COMPOSITION,DIMENSIONALDRAWING,POWERSUPPLY, " +
                                            "NOTE,CONFIGURATION,CREATED,IDSUBCAT) values (@WPNAME,@IDCATEGORY,@DECNUM,@COMPOSITION,@DIMENSIONALDRAWING,@POWERSUPPLY,@NOTE,@CONFIGURATION,@CREATED,@IDSUBCAT)";
            DA.InsertCommand.Connection.Open();
            DA.InsertCommand.ExecuteNonQuery();
            DA.InsertCommand.Connection.Close();
        }

        internal WPNameVO GetWP(int p)
        {
            DA.SelectCommand.CommandText = "select * from " + Base.BaseName + "..WPNAMELIST where ID = " +p;
            DA.Fill(DS, "t");
            WPNameVO wp = new WPNameVO();
            wp.ID = Convert.ToInt32(DS.Tables["t"].Rows[0]["ID"]);
            wp.WPName = DS.Tables["t"].Rows[0]["WPNAME"].ToString();
            wp.IDCat = Convert.ToInt32(DS.Tables["t"].Rows[0]["IDCATEGORY"]);
            if (DS.Tables["t"].Rows[0]["IDSUBCAT"] != DBNull.Value)
                wp.IDSubCat = Convert.ToInt32(DS.Tables["t"].Rows[0]["IDSUBCAT"]);
            else
                wp.IDSubCat = 0;
            wp.DecNum = DS.Tables["t"].Rows[0]["DECNUM"].ToString(); ;
            wp.COMPOSITION = DS.Tables["t"].Rows[0]["COMPOSITION"].ToString();
            wp.DIMENDRAWING = DS.Tables["t"].Rows[0]["DIMENSIONALDRAWING"].ToString();
            wp.PowerSupply = DS.Tables["t"].Rows[0]["POWERSUPPLY"].ToString();
            wp.CONFIGURATION = DS.Tables["t"].Rows[0]["CONFIGURATION"].ToString();
            wp.Note = DS.Tables["t"].Rows[0]["NOTE"].ToString();
            return wp;
        }

        internal void EditWP(WPNameVO p)
        {
            DA.UpdateCommand.Parameters.Clear();
            DA.UpdateCommand.Parameters.AddWithValue("WPNAME", p.WPName);
            DA.UpdateCommand.Parameters.AddWithValue("IDCATEGORY", p.IDCat);
            DA.UpdateCommand.Parameters.AddWithValue("IDSUBCAT", p.IDSubCat);
            DA.UpdateCommand.Parameters.AddWithValue("DECNUM", p.DecNum);
            DA.UpdateCommand.Parameters.AddWithValue("COMPOSITION", p.COMPOSITION);
            DA.UpdateCommand.Parameters.AddWithValue("CONFIGURATION", p.CONFIGURATION);
            DA.UpdateCommand.Parameters.AddWithValue("DIMENSIONALDRAWING", p.DIMENDRAWING);
            DA.UpdateCommand.Parameters.AddWithValue("POWERSUPPLY", p.PowerSupply);
            DA.UpdateCommand.Parameters.AddWithValue("NOTE", p.Note);
            DA.UpdateCommand.Parameters.AddWithValue("ID", p.ID);

            DA.UpdateCommand.CommandText = "update " + Base.BaseName + "..WPNAMELIST set WPNAME  = @WPNAME,IDCATEGORY = @IDCATEGORY,DECNUM = @DECNUM,COMPOSITION = @COMPOSITION,"+
                                            " DIMENSIONALDRAWING = @DIMENSIONALDRAWING,POWERSUPPLY=@POWERSUPPLY,NOTE = @NOTE,CONFIGURATION = @CONFIGURATION,IDSUBCAT = @IDSUBCAT " +
                                            " where ID = @ID";
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

        internal string GetCurrentComposition(string idwp)
        {
            DA.SelectCommand.CommandText = "select COMPOSITION from " + Base.BaseName + "..WPNAMELIST where ID = " + idwp;
            int i = DA.Fill(DS, "t");
            return DS.Tables["t"].Rows[0]["COMPOSITION"].ToString();
        }


        internal object GetPackage(int idwp)
        {
            DA.SelectCommand.Parameters.AddWithValue("IDWP", idwp);
            DA.SelectCommand.CommandText = " select A.ID id,A.ID nn,B.WPNAME,A.CNT " +
                                           " left join " + Base.BaseName + "..WPNAMELIST B ON B.ID = A.IDZHGUT " +
                                           " from " + Base.BaseName + "..WPNAMELIST A where IDWP = @IDWP ";
            DA.Fill(DS, "t");
            return DS.Tables["t"];
        }

        internal WPNameVO GetWPNameByID(int id)
        {
            WPNameVO wp = new WPNameVO();
            DA.SelectCommand.Parameters.AddWithValue("ID", id);
            DA.SelectCommand.CommandText = " select * from " + Base.BaseName + "..WPNAMELIST A where ID = @ID";
            DA.Fill(DS, "t");
            DataRow r = DS.Tables["t"].Rows[0];
            
            wp.WPType = WPTYPE.WPNAMELIST; 
            wp.ID = (int)r["ID"];
            wp.WPName = r["WPNAME"].ToString();
            wp.IDCat= (int)r["IDCATEGORY"];
            wp.IDSubCat = (r["IDSUBCAT"] == DBNull.Value) ? 0 : (int)r["IDSUBCAT"];
            wp.DecNum = r["DECNUM"].ToString();
            wp.WIRINGDIAGRAM = r["WIRINGDIAGRAM"].ToString();
            wp.TECHREQ = r["TECHREQ"].ToString();
            wp.COMPOSITION = r["COMPOSITION"].ToString();
            wp.CONFIGURATION = r["CONFIGURATION"].ToString();
            wp.DIMENDRAWING = r["DIMENSIONALDRAWING"].ToString();
            wp.SBORKA3D = r["SBORKA3D"].ToString();
            wp.MECHPARTS = r["MECHPARTS"].ToString();
            wp.ZHGUTS = new DBZhgutList().GetPackageForVO(wp.ID);
            wp.CABLES = new DBCableList().GetPackageForVO(wp.ID);
            wp.SHILDS = r["SHILDS"].ToString();
            wp.PLANKA = r["PLANKA"].ToString();
            wp.SERIAL = r["SERIAL"].ToString();
            wp.PACKAGING = r["PACKAGING"].ToString();
            wp.PASSPORT = r["PASSPORT"].ToString();
            wp.MANUAL = r["MANUAL"].ToString();
            wp.PACKINGLIST = r["PACKINGLIST"].ToString();
            wp.PowerSupply = r["POWERSUPPLY"].ToString();
            wp.Note = r["NOTE"].ToString();

            wp.COMPOSITIONREQ = (bool)r["COMPOSITIONREQ"];
            wp.DIMENSIONALDRAWINGREQ = (bool)r["DIMENSIONALDRAWINGREQ"];
            //wp.POWERSUPPLYREQ = (bool)r["POWERSUPPLYREQ"];
            wp.CONFIGURATIONREQ = (bool)r["CONFIGURATIONREQ"];
            wp.WIRINGDIAGRAMREQ = (bool)r["WIRINGDIAGRAMREQ"];
            wp.TECHREQREQ = (bool)r["TECHREQREQ"];
            wp.SBORKA3DREQ = (bool)r["SBORKA3DREQ"];
            wp.MECHPARTSREQ = (bool)r["MECHPARTSREQ"];
            wp.SHILDSREQ = (bool)r["SHILDSREQ"];
            wp.PLANKAREQ = (bool)r["PLANKAREQ"];
            wp.SERIALREQ = (bool)r["SERIALREQ"];
            wp.PACKAGINGREQ = (bool)r["PACKAGINGREQ"];
            wp.PASSPORTREQ = (bool)r["PASSPORTREQ"];
            wp.MANUALREQ = (bool)r["MANUALREQ"];
            wp.PACKINGLISTREQ = (bool)r["PACKINGLISTREQ"];
            wp.SOFTWAREREQ = (bool)r["SOFTWAREREQ"];
            wp.CABLELISTREQ = (bool)r["CABLELISTREQ"];
            wp.ZHGUTLISTREQ = (bool)r["ZHGUTLISTREQ"];
            wp.RUNCARDLISTREQ = (bool)r["RUNCARDLISTREQ"];
            wp.CIRCUITBOARDLISTREQ = (bool)r["CIRCUITBOARDLISTREQ"];
            return wp;
        }
    }
}
