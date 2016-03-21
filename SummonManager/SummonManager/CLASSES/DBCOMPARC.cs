using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SummonManager.CLASSES
{
    class DBCOMPARC:DB
    {
        public DBCOMPARC() { }

       
        public void AddNew(WPNameVO wp, string NewComposition)
        {
            DA.SelectCommand.CommandText = "select max(DATEARC) arc from " + Base.BaseName + "..WPCOMPOSITIONARCHIVE where IDWP = "+wp.ID;
            int i = DA.Fill(DS, "t");
            DateTime fromdate;
            object o = DS.Tables["t"].Rows[0]["arc"];
            if (o == DBNull.Value)
            {
                fromdate = new DateTime(2010, 1, 1);
            }
            else
            {
                fromdate = (DateTime)DS.Tables["t"].Rows[0]["arc"];
            }

            DA.InsertCommand.Parameters.AddWithValue("comp", wp.COMPOSITION);
            DA.InsertCommand.Parameters.AddWithValue("from", fromdate);
            DA.InsertCommand.CommandText = "insert into " + Base.BaseName + "..WPCOMPOSITIONARCHIVE (IDWP,ARCPATH,DATEARC,FROMDATE) values (" + wp.ID + 
                                                                                        ",@comp,getdate(),@from)";
            DA.InsertCommand.Connection.Open();
            DA.InsertCommand.ExecuteNonQuery();
            DA.InsertCommand.Connection.Close();

            DA.UpdateCommand.Parameters.AddWithValue("comp", NewComposition);
            DA.UpdateCommand.CommandText = "update " + Base.BaseName + "..WPNAMELIST set COMPOSITION  = @comp where ID = " + wp.ID;
            DA.UpdateCommand.Connection.Open();
            DA.UpdateCommand.ExecuteNonQuery();
            DA.UpdateCommand.Connection.Close();




        }
       

        internal string GetRightComposition(WPNameVO wPNameVO,string svoid)
        {
            DA.SelectCommand.CommandText = "  select A.ID,A.CREATED,A.COMPOSITION,B.* "+
                                            " from ALPHA..SUMMON A "+
                                            " left join ALPHA..WPCOMPOSITIONARCHIVE B on A.IDWP = B.IDWP "+
                                            " where A.IDWP = "+wPNameVO.ID+"   and A.ID  = "+svoid+
                                            " and A.CREATED between B.FROMDATE and B.DATEARC ";
            int i = DA.Fill(DS, "t");
            if (i == 0)
            {
                return new DBWPName().GetCurrentComposition(wPNameVO.ID.ToString());
            }
            else
            {
                return DS.Tables["t"].Rows[0]["ARCPATH"].ToString();
            }
        }

        internal object GetAll(string IDWP)
        {
            DA.SelectCommand.CommandText = "select ARCPATH,FROMDATE,DATEARC from " + Base.BaseName + "..WPCOMPOSITIONARCHIVE";
            DA.Fill(DS, "t");
            return DS.Tables["t"];
        }
    }
}
