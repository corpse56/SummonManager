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
            DA.SelectCommand.CommandText = " select A.ID id,A.ID nn,B.CABLENAME name,A.CNT " +
                                           " from " + Base.BaseName + "..CABLES A " +
                                           " left join " + Base.BaseName + "..CABLELIST B ON B.ID = A.IDCABLE " +
                                           "  where IDWP = @IDWP ";
            DA.Fill(DS, "t");
            return DS.Tables["t"];
        }
        public List<CableVO> GetPackageForVO(int IDWP)
        {
            DA.SelectCommand.Parameters.AddWithValue("IDWP", IDWP);
            DA.SelectCommand.CommandText = " select A.IDCABLE id,A.ID nn,B.CABLENAME name,A.CNT " +
                                           " from " + Base.BaseName + "..CABLES A "+
                                           " left join " + Base.BaseName + "..CABLELIST B ON B.ID = A.IDCABLE " +
                                           "  where IDWP = @IDWP ";
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
        public DataTable GetAllCables()
        {
            DA.SelectCommand.CommandText = "select A.ID,A.CABLENAME,B.CATEGORYNAME,isnull(C.SUBCATNAME,'Не присвоено') SUBCATNAME,A.DECNUM,A.DIMENSIONALDRAWING,A.CONNECTORS,A.CLENGTH,A.NOTE from " +
                                            Base.BaseName + "..CABLELIST A " +
                                           " left join " + Base.BaseName + "..CATEGORYLIST B on B.ID = IDCATEGORY " +
                                           " left join " + Base.BaseName + "..SUBCATEGORYLIST C on C.ID = A.IDSUBCAT " +
                                           " order by CABLENAME";
            DS = new DataSet();
            int h = DA.Fill(DS, "t");
            return DS.Tables["t"];
        }
        public DataTable GetCategoryCableList(int IDCAT, int IDSUBCAT)
        {
            if (IDCAT == 13) return this.GetAllCables();
            string sub = new DBSubCategory().GetNameByID(IDSUBCAT);
            if (sub.ToUpper() == "ВСЕ")
            {
                DA.SelectCommand.CommandText = "select A.ID,A.CABLENAME,B.CATEGORYNAME,isnull(C.SUBCATNAME,'Не присвоено') SUBCATNAME,A.DECNUM,A.DIMENSIONALDRAWING,A.CONNECTORS,A.CLENGTH,A.NOTE from " +
                                                 Base.BaseName + "..CABLELIST A " +
                                               " left join " + Base.BaseName + "..CATEGORYLIST B on B.ID = IDCATEGORY " +
                                               " left join " + Base.BaseName + "..SUBCATEGORYLIST C on C.ID = A.IDSUBCAT " +
                                               " where A.IDCATEGORY = " + IDCAT + " order by CABLENAME";
            }
            else if (sub.ToUpper() == "НЕ ПРИСВОЕНО")
            {
                DA.SelectCommand.CommandText = "select A.ID,A.CABLENAME,B.CATEGORYNAME,isnull(C.SUBCATNAME,'Не присвоено') SUBCATNAME,A.DECNUM,A.DIMENSIONALDRAWING,A.CONNECTORS,A.CLENGTH,A.NOTE from " +
                                                Base.BaseName + "..CABLELIST A " +
                                               " left join " + Base.BaseName + "..CATEGORYLIST B on B.ID = IDCATEGORY " +
                                               " left join " + Base.BaseName + "..SUBCATEGORYLIST C on C.ID = A.IDSUBCAT " +
                                               " where A.IDCATEGORY = " + IDCAT + " and (A.IDSUBCAT is null)  order by CABLENAME";
            }
            else
            {
                DA.SelectCommand.CommandText = "select A.ID,A.CABLENAME,B.CATEGORYNAME,isnull(C.SUBCATNAME,'Не присвоено') SUBCATNAME,A.DECNUM,A.DIMENSIONALDRAWING,A.CONNECTORS,A.CLENGTH,A.NOTE from " +
                                                 Base.BaseName + "..CABLELIST A " +
                                               " left join " + Base.BaseName + "..CATEGORYLIST B on B.ID = IDCATEGORY " +
                                               " left join " + Base.BaseName + "..SUBCATEGORYLIST C on C.ID = A.IDSUBCAT " +
                                               " where A.IDCATEGORY = " + IDCAT + " and (A.IDSUBCAT = " + IDSUBCAT + ")  order by CABLENAME";
            }

            DS = new DataSet();
            int h = DA.Fill(DS, "t");
            return DS.Tables["t"];
        }
        public DataTable GetCategoryCableList(int IDCAT)
        {
            if (IDCAT == 13) return this.GetAllCables();//13 это категория ВСЕ у CABLELIST
            DA.SelectCommand.CommandText = "select A.ID,A.CABLENAME,B.CATEGORYNAME,isnull(C.SUBCATNAME,'Не присвоено') SUBCATNAME,A.DECNUM,A.DIMENSIONALDRAWING,A.CONNECTORS,A.CLENGTH,A.NOTE from " +
                                            Base.BaseName + "..CABLELIST A " +
                                           " left join " + Base.BaseName + "..CATEGORYLIST B on B.ID = IDCATEGORY " +
                                           " left join " + Base.BaseName + "..SUBCATEGORYLIST C on C.ID = A.IDSUBCAT " +
                                           " where A.IDCATEGORY = " + IDCAT + " order by CABLENAME";
            DS = new DataSet();
            int h = DA.Fill(DS, "t");
            return DS.Tables["t"];
        }
    }
}
