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
            DA.SelectCommand.CommandText = "select A.ID,A.WPNAME,B.CATEGORYNAME,A.DECNUM,A.COMPOSITION,A.DIMENSIONALDRAWING,A.POWERSUPPLY,A.CONFIGURATION,A.NOTE from " 
                                            + Base.BaseName + "..WPNAMELIST A left join " + Base.BaseName + "..CATEGORYLIST B on B.ID = IDCATEGORY order by WPNAME";
            DS = new DataSet();
            int h = DA.Fill(DS, "t");
            return DS.Tables["t"];
        }
        public DataTable GetCategoryWPNames(int IDCAT)
        {
            if (IDCAT == 2) return this.GetAllWPNames();
            DA.SelectCommand.CommandText = "select A.ID,A.WPNAME,B.CATEGORYNAME,A.DECNUM,A.COMPOSITION,A.DIMENSIONALDRAWING,A.POWERSUPPLY,A.CONFIGURATION,A.NOTE from "
                                            + Base.BaseName + "..WPNAMELIST A left join " + Base.BaseName + "..CATEGORYLIST B on B.ID = IDCATEGORY where IDCATEGORY = " + IDCAT + "order by WPNAME";
            DS = new DataSet();
            int h = DA.Fill(DS, "t");
            return DS.Tables["t"];
        }
        internal void AddNewWP(WPNameVO p)
        {
            DA.InsertCommand.Parameters.Clear();
            DA.InsertCommand.Parameters.AddWithValue("WPNAME", p.WPName);
            DA.InsertCommand.Parameters.AddWithValue("IDCATEGORY", p.IDCat);
            DA.InsertCommand.Parameters.AddWithValue("DECNUM", p.DecNum);
            DA.InsertCommand.Parameters.AddWithValue("CONFIGURATION", p.Configuration);
            DA.InsertCommand.Parameters.AddWithValue("COMPOSITION", p.Composition);
            DA.InsertCommand.Parameters.AddWithValue("DIMENSIONALDRAWING", p.DimenDrawing);
            DA.InsertCommand.Parameters.AddWithValue("POWERSUPPLY", p.PowerSupply);
            DA.InsertCommand.Parameters.AddWithValue("NOTE", p.Note);
            DA.InsertCommand.CommandText = "insert into " + Base.BaseName + "..WPNAMELIST (WPNAME,IDCATEGORY,DECNUM,COMPOSITION,DIMENSIONALDRAWING,POWERSUPPLY, " +
                                            "NOTE,CONFIGURATION) values (@WPNAME,@IDCATEGORY,@DECNUM,@COMPOSITION,@DIMENSIONALDRAWING,@POWERSUPPLY,@NOTE,@CONFIGURATION)";
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
            wp.DecNum = DS.Tables["t"].Rows[0]["DECNUM"].ToString(); ;
            wp.Composition = DS.Tables["t"].Rows[0]["COMPOSITION"].ToString();
            wp.DimenDrawing = DS.Tables["t"].Rows[0]["DIMENSIONALDRAWING"].ToString();
            wp.PowerSupply = DS.Tables["t"].Rows[0]["POWERSUPPLY"].ToString();
            wp.Configuration = DS.Tables["t"].Rows[0]["CONFIGURATION"].ToString();
            wp.Note = DS.Tables["t"].Rows[0]["NOTE"].ToString();

            return wp;
        }

        internal void EditWP(WPNameVO p)
        {
            DA.UpdateCommand.Parameters.Clear();
            DA.UpdateCommand.Parameters.AddWithValue("WPNAME", p.WPName);
            DA.UpdateCommand.Parameters.AddWithValue("IDCATEGORY", p.IDCat);
            DA.UpdateCommand.Parameters.AddWithValue("DECNUM", p.DecNum);
            DA.UpdateCommand.Parameters.AddWithValue("COMPOSITION", p.Composition);
            DA.UpdateCommand.Parameters.AddWithValue("CONFIGURATION", p.Configuration);
            DA.UpdateCommand.Parameters.AddWithValue("DIMENSIONALDRAWING", p.DimenDrawing);
            DA.UpdateCommand.Parameters.AddWithValue("POWERSUPPLY", p.PowerSupply);
            DA.UpdateCommand.Parameters.AddWithValue("NOTE", p.Note);
            DA.UpdateCommand.Parameters.AddWithValue("ID", p.ID);

            DA.UpdateCommand.CommandText = "update " + Base.BaseName + "..WPNAMELIST set WPNAME  = @WPNAME,IDCATEGORY = @IDCATEGORY,DECNUM = @DECNUM,COMPOSITION = @COMPOSITION,"+
                                            " DIMENSIONALDRAWING = @DIMENSIONALDRAWING,POWERSUPPLY=@POWERSUPPLY,NOTE = @NOTE,CONFIGURATION = @CONFIGURATION " +
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
    }
}
