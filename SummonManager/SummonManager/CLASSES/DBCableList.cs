using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SummonManager.CLASSES
{
    class DBCableList :DB
    {
        public DataTable GetPackage(int IDWP)
        {
            DA.SelectCommand.Parameters.AddWithValue("IDWP", IDWP);
            DA.SelectCommand.CommandText = " select A.ID id,A.ID nn,B.CABLENAME,A.CNT " +
                                           " left join " + Base.BaseName + "..CABLELIST B ON B.ID = A.IDCABLE " +
                                           " from " + Base.BaseName + "..CABLES A where IDWP = @IDWP ";
            DA.Fill(DS, "t");
            return DS.Tables["t"];
        }
        public List<CableVO> GetPackageForVO(int IDWP)
        {
            DA.SelectCommand.Parameters.AddWithValue("IDWP", IDWP);
            DA.SelectCommand.CommandText = " select A.IDCABLE id,A.ID nn,B.CABLENAME,A.CNT " +
                                           " left join " + Base.BaseName + "..CABLELIST B ON B.ID = A.IDCABLE " +
                                           " from " + Base.BaseName + "..CABLES A where IDWP = @IDWP ";
            DA.Fill(DS, "t");
            List<CableVO> ret = new List<CableVO>();
            foreach (DataRow r in DS.Tables["t"].Rows)
            {
                ret.Add(CableVO.GetCableVOByID((int)r["id"]));
            }

            return ret;
        }

        internal CableVO GetCableVOByID(int ID)
        {
            DA.SelectCommand.Parameters.AddWithValue("ID", ID);
            DA.SelectCommand.CommandText = " select * from" + Base.BaseName + "..CABLELIST where ID = @ID ";
            DA.Fill(DS, "t");
            DataRow r = DS.Tables["t"].Rows[0];
            CableVO CVO = new CableVO();
            CVO.ID = (int)r["ID"];
            CVO.IDCat = (int)r["IDCATEGORY"];
            CVO.IDSubCat = (int)r["IDSUBCAT"];
            CVO.DecNum = r["DECNUM"].ToString();
            CVO.DIMENDRAWING = r["DIMENSIONALDRAWING"].ToString();
            CVO.CONECTORS = r["CONNECTORS"].ToString();
            CVO.CLENGTH = r["CLENGTH"].ToString();
            CVO.NOTE = r["NOTE"].ToString();
            return CVO;
        }
    }
}
