using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SummonManager.CLASSES
{
    class DBZhgutList :DB
    {
        public DataTable GetPackage(int IDWP)
        {
            DA.SelectCommand.Parameters.AddWithValue("IDWP", IDWP);
            DA.SelectCommand.CommandText = " select A.ID id,A.ID nn,B.ZHGUTNAME name,A.CNT " +
                                           " from " + Base.BaseName + "..ZHGUTS A " +
                                           " left join " + Base.BaseName + "..ZHGUTLIST B ON B.ID = A.IDZHGUT " +
                                           " where IDWP = @IDWP ";
            DA.Fill(DS, "t");
            return DS.Tables["t"];
        }


        internal ZhgutVO GetZhgutVOByID(int ID)
        {
            DA.SelectCommand.Parameters.AddWithValue("ID", ID);
            DA.SelectCommand.CommandText = " select * from" + Base.BaseName + "..ZHGUTLIST where ID = @ID ";
            DA.Fill(DS, "t");
            DataRow r = DS.Tables["t"].Rows[0];
            ZhgutVO ZVO = new ZhgutVO();
            ZVO.ID = (int)r["ID"];
            ZVO.IDCat = (int)r["IDCATEGORY"];
            ZVO.IDSubCat = (int)r["IDSUBCAT"];
            ZVO.DecNum = r["DECNUM"].ToString();
            ZVO.ZHGUTPATH = r["ZHGUTPATH"].ToString();
            ZVO.NOTE = r["NOTE"].ToString();
            return ZVO;
        }

        internal List<ZhgutVO> GetPackageForVO(int IDWP)
        {
            DA.SelectCommand.Parameters.AddWithValue("IDWP", IDWP);
            DA.SelectCommand.CommandText = " select A.IDZHGUT id,A.ID nn,B.ZHGUTNAME name,A.CNT " +
                                           " from " + Base.BaseName + "..ZHGUTS A" +
                                           " left join " + Base.BaseName + "..ZHGUTLIST B ON B.ID = A.IDZHGUT "+
                                           "  where IDWP = @IDWP ";
            DA.Fill(DS, "t");
            List<ZhgutVO> ret = new List<ZhgutVO>();
            foreach (DataRow r in DS.Tables["t"].Rows)
            {
                ret.Add(ZhgutVO.GetZhgutVOByID((int)r["id"]));
            }

            return ret;
        }
        public DataTable GetAllZhguts()
        {
            DA.SelectCommand.CommandText = "select A.ID,A.ZHGUTNAME,B.CATEGORYNAME,isnull(C.SUBCATNAME,'Не присвоено') SUBCATNAME,A.DECNUM,A.ZHGUTPATH,A.NOTE from "
                                            + Base.BaseName + "..ZHGUTLIST A "+
                                           " left join " + Base.BaseName + "..CATEGORYLIST B on B.ID = IDCATEGORY " +
                                           " left join " + Base.BaseName + "..SUBCATEGORYLIST C on C.ID = A.IDSUBCAT " +
                                           " order by ZHGUTNAME";
            DS = new DataSet();
            int h = DA.Fill(DS, "t");
            return DS.Tables["t"];
        }
        public DataTable GetCategoryZhgutList(int IDCAT, int IDSUBCAT)
        {
            if (IDCAT == 15) return this.GetAllZhguts();
            string sub = new DBSubCategory().GetNameByID(IDSUBCAT);
            if (sub.ToUpper() == "ВСЕ")
            {
                DA.SelectCommand.CommandText = "select A.ID,A.ZHGUTNAME,B.CATEGORYNAME,isnull(C.SUBCATNAME,'Не присвоено') SUBCATNAME,A.DECNUM,A.ZHGUTPATH,A.NOTE from " +
                                                 Base.BaseName + "..ZHGUTLIST A "+
                                               " left join " + Base.BaseName + "..CATEGORYLIST B on B.ID = IDCATEGORY " +
                                               " left join " + Base.BaseName + "..SUBCATEGORYLIST C on C.ID = A.IDSUBCAT " +
                                               " where A.IDCATEGORY = " + IDCAT + " order by ZHGUTNAME";
            }
            else if (sub.ToUpper() == "НЕ ПРИСВОЕНО")
            {
                DA.SelectCommand.CommandText = "select A.ID,A.ZHGUTNAME,B.CATEGORYNAME,isnull(C.SUBCATNAME,'Не присвоено') SUBCATNAME,A.DECNUM,A.ZHGUTPATH,A.NOTE from " +
                                                Base.BaseName + "..ZHGUTLIST A " +
                                               " left join " + Base.BaseName + "..CATEGORYLIST B on B.ID = IDCATEGORY " +
                                               " left join " + Base.BaseName + "..SUBCATEGORYLIST C on C.ID = A.IDSUBCAT " +
                                               " where A.IDCATEGORY = " + IDCAT + " and (A.IDSUBCAT is null)  order by ZHGUTNAME";
            }
            else
            {
                DA.SelectCommand.CommandText = "select A.ID,A.ZHGUTNAME,B.CATEGORYNAME,isnull(C.SUBCATNAME,'Не присвоено') SUBCATNAME,A.DECNUM,A.ZHGUTPATH,A.NOTE from " +
                                                 Base.BaseName + "..ZHGUTLIST A " +
                                               " left join " + Base.BaseName + "..CATEGORYLIST B on B.ID = IDCATEGORY " +
                                               " left join " + Base.BaseName + "..SUBCATEGORYLIST C on C.ID = A.IDSUBCAT " +
                                               " where A.IDCATEGORY = " + IDCAT + " and (A.IDSUBCAT = " + IDSUBCAT + ")  order by ZHGUTNAME";
            }

            DS = new DataSet();
            int h = DA.Fill(DS, "t");
            return DS.Tables["t"];
        }
        public DataTable GetCategoryZhgutList(int IDCAT)
        {
            if (IDCAT == 15) return this.GetAllZhguts();
            DA.SelectCommand.CommandText = "select A.ID,A.ZHGUTNAME,B.CATEGORYNAME,isnull(C.SUBCATNAME,'Не присвоено') SUBCATNAME,A.DECNUM,A.ZHGUTPATH,A.NOTE from " +
                                            Base.BaseName + "..ZHGUTLIST A " +
                                           " left join " + Base.BaseName + "..CATEGORYLIST B on B.ID = IDCATEGORY " +
                                           " left join " + Base.BaseName + "..SUBCATEGORYLIST C on C.ID = A.IDSUBCAT " +
                                           " where A.IDCATEGORY = " + IDCAT + " order by ZHGUTNAME";
            DS = new DataSet();
            int h = DA.Fill(DS, "t");
            return DS.Tables["t"];
        }
    }
}
