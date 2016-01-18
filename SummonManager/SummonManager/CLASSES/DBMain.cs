using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SummonManager
{
    public class DBMain : DB
    {
        public DBMain()
        {

        }
        public DataTable GetMainView(Roles role,UserVO uvo)
        {
            //DS = new DataSet();
            switch (role)
            {
                case Roles.Admin:
                    //DA.SelectCommand.CommandText = "select * from " + Base.BaseName + "..MAINVIEW where idstatus != 13 order by ids";
                    //DA.SelectCommand.CommandText = "select * from " + Base.BaseName + "..MAINVIEW where idstatus != 13 and idstatus != 14 order by ids";
                    DA.SelectCommand.CommandText = "select * from " + Base.BaseName + "..f_MAINVIEW(" + uvo.id + ") where idstatus != 13 and idstatus != 14 order by ids";
                    break;
                case Roles.Logist:
                    //DA.SelectCommand.CommandText = "select * from " + Base.BaseName + "..MAINVIEW where idstatus = 11 or idstatus = 12 order by ids";
                    //DA.SelectCommand.CommandText = "select * from " + Base.BaseName + "..MAINVIEW where idstatus != 13 and idstatus != 14 order by ids";
                    DA.SelectCommand.CommandText = "select * from " + Base.BaseName + "..f_MAINVIEW(" + uvo.id + ") where idstatus != 13 and idstatus != 14 order by ids";
                    break;
                case Roles.Manager:
                    //DA.SelectCommand.CommandText = "select * from " + Base.BaseName + "..MAINVIEW where idstatus != 13 and idstatus in (1,12,7,11) order by ids";
                    //DA.SelectCommand.CommandText = "select * from " + Base.BaseName + "..MAINVIEW where idstatus != 13 and idstatus != 14 order by ids";
                    DA.SelectCommand.CommandText = "select * from " + Base.BaseName + "..f_MAINVIEW(" + uvo.id + ") where idstatus != 13 and idstatus != 14 order by ids";
                    break;
                case Roles.OTK:
                    //DA.SelectCommand.CommandText = "select * from " + Base.BaseName + "..MAINVIEW where idstatus = 7 or idstatus = 5 or idstatus = 8 order by ids";
                    //DA.SelectCommand.CommandText = "select * from " + Base.BaseName + "..MAINVIEW where idstatus != 13 and idstatus != 14 order by ids";
                    DA.SelectCommand.CommandText = "select * from " + Base.BaseName + "..f_MAINVIEW(" + uvo.id + ") where idstatus != 13 and idstatus != 14 order by ids";
                    break;
                case Roles.Ozis:
                    //DA.SelectCommand.CommandText = "select * from " + Base.BaseName + "..MAINVIEW where idstatus = 3 order by ids";
                    //DA.SelectCommand.CommandText = "select * from " + Base.BaseName + "..MAINVIEW where idstatus != 13 and idstatus != 14 order by ids";
                    DA.SelectCommand.CommandText = "select * from " + Base.BaseName + "..f_MAINVIEW(" + uvo.id + ") where idstatus != 13 and idstatus != 14 order by ids";
                    break;
                case Roles.Prod:
                    //DA.SelectCommand.CommandText = "select * from " + Base.BaseName + "..MAINVIEW where idstatus in (1,2,3,4,6,9,8) order by ids";
                    //DA.SelectCommand.CommandText = "select * from " + Base.BaseName + "..MAINVIEW where idstatus != 13 and idstatus != 14 order by ids";
                    DA.SelectCommand.CommandText = "select * from " + Base.BaseName + "..f_MAINVIEW(" + uvo.id + ") where idstatus != 13 and idstatus != 14 order by ids";
                    break;
                case Roles.Ware:
                    //DA.SelectCommand.CommandText = "select * from " + Base.BaseName + "..MAINVIEW where idstatus = 9 order by ids";
                    //DA.SelectCommand.CommandText = "select * from " + Base.BaseName + "..MAINVIEW where idstatus != 13 and idstatus != 14 order by ids";
                    DA.SelectCommand.CommandText = "select * from " + Base.BaseName + "..f_MAINVIEW(" + uvo.id + ") where idstatus != 13 and idstatus != 14 order by ids";
                    break;
                case Roles.Wsh:
                    //DA.SelectCommand.CommandText = "select * from " + Base.BaseName + "..MAINVIEW where idstatus in (5,8) order by ids";
                    //DA.SelectCommand.CommandText = "select * from " + Base.BaseName + "..MAINVIEW where idstatus != 13 and idstatus != 14 order by ids";
                    DA.SelectCommand.CommandText = "select * from " + Base.BaseName + "..f_MAINVIEW(" + uvo.id + ") where idstatus != 13 and idstatus != 14 order by ids";
                    break;
                case Roles.Director:
                    //DA.SelectCommand.CommandText = "select * from " + Base.BaseName + "..MAINVIEW where idstatus != 13 order by ids";
                    //DA.SelectCommand.CommandText = "select * from " + Base.BaseName + "..MAINVIEW where idstatus != 13 and idstatus != 14 order by ids";
                    DA.SelectCommand.CommandText = "select * from " + Base.BaseName + "..f_MAINVIEW(" + uvo.id + ") where idstatus != 13 and idstatus != 14 order by ids";
                    break;
                case Roles.Montage:
                    //DA.SelectCommand.CommandText = "select * from " + Base.BaseName + "..MAINVIEW where idstatus != 13 order by ids";
                    //DA.SelectCommand.CommandText = "select * from " + Base.BaseName + "..MAINVIEW where idstatus != 13 and idstatus != 14 order by ids";
                    DA.SelectCommand.CommandText = "select * from " + Base.BaseName + "..f_MAINVIEW(" + uvo.id + ") where idstatus != 13 and idstatus != 14 order by ids";
                    break;
                case Roles.Constructor:
                    //DA.SelectCommand.CommandText = "select * from " + Base.BaseName + "..MAINVIEW where idstatus != 13 order by ids";
                    //DA.SelectCommand.CommandText = "select * from " + Base.BaseName + "..MAINVIEW where idstatus != 13 and idstatus != 14 order by ids";
                    DA.SelectCommand.CommandText = "select * from " + Base.BaseName + "..f_MAINVIEW(" + uvo.id + ") where idstatus != 13 and idstatus != 14 order by ids";
                    break;
                case Roles.Inzhener:
                    //DA.SelectCommand.CommandText = "select * from " + Base.BaseName + "..MAINVIEW where idstatus != 13 order by ids";
                    //DA.SelectCommand.CommandText = "select * from " + Base.BaseName + "..MAINVIEW where idstatus != 13 and idstatus != 14 order by ids";
                    DA.SelectCommand.CommandText = "select * from " + Base.BaseName + "..f_MAINVIEW(" + uvo.id + ") where idstatus != 13 and idstatus != 14 order by ids";
                    break;
                case Roles.Buhgalter:
                    //DA.SelectCommand.CommandText = "select * from " + Base.BaseName + "..MAINVIEW where idstatus != 13 order by ids";
                    //DA.SelectCommand.CommandText = "select * from " + Base.BaseName + "..MAINVIEW where idstatus != 13 and idstatus != 14 order by ids";
                    DA.SelectCommand.CommandText = "select * from " + Base.BaseName + "..f_MAINVIEW(" + uvo.id + ") where idstatus =9 or idstatus =12 order by ids";
                    break;
            }
            //DA.SelectCommand.CommandText = "select * from " + Base.BaseName + "..MAINVIEW where idstatus != 'Завершено' order by ids";

            int i = DA.Fill(DS, "t");
            return DS.Tables["t"];
        }
        internal object GetMainViewMy(Roles roles,UserVO uvo)
        {
            switch (roles)
            {
                case Roles.Admin:
                    DA.SelectCommand.CommandText = "select * from " + Base.BaseName + "..f_MAINVIEW(" + uvo.id + ") where idstatus != 13 and idstatus != 14  order by ids";
                    break;
                case Roles.Logist:
                    DA.SelectCommand.CommandText = "select * from " + Base.BaseName + "..f_MAINVIEW(" + uvo.id + ") where idstatus != 13 and idstatus != 14 and idstatus in (12) order by ids";
                    break;
                case Roles.Manager:
                    DA.SelectCommand.CommandText = "select * from " + Base.BaseName + "..f_MAINVIEW(" + uvo.id + ") where idstatus != 13 and idstatus != 14 and idstatus in (1,2,11) order by ids";
                    break;
                case Roles.OTK:
                    DA.SelectCommand.CommandText = "select * from " + Base.BaseName + "..f_MAINVIEW(" + uvo.id + ") where idstatus != 13 and idstatus != 14 and idstatus in (2,7,16) order by ids";
                    break;
                case Roles.Ozis:
                    DA.SelectCommand.CommandText = "select * from " + Base.BaseName + "..f_MAINVIEW(" + uvo.id + ") where idstatus != 13 and idstatus != 14 and idstatus in (2,3,17) order by ids";
                    break;
                case Roles.Prod:
                    DA.SelectCommand.CommandText = "select * from " + Base.BaseName + "..f_MAINVIEW(" + uvo.id + ") where idstatus != 13 and idstatus != 14 and idstatus in (2,4,6) order by ids ";
                    break;
                case Roles.Ware:
                    DA.SelectCommand.CommandText = "select * from " + Base.BaseName + "..f_MAINVIEW(" + uvo.id + ") where idstatus != 13 and idstatus != 14 and idstatus in (9) order by ids";
                    break;
                case Roles.Wsh:
                    DA.SelectCommand.CommandText = "select * from " + Base.BaseName + "..f_MAINVIEW(" + uvo.id + ") where idstatus != 13 and idstatus != 14 and idstatus in (5,8) order by ids";
                    break;
                case Roles.Director:
                    DA.SelectCommand.CommandText = "select * from " + Base.BaseName + "..f_MAINVIEW(" + uvo.id + ") where idstatus != 13 and idstatus != 14 order by ids";
                    break;
                case Roles.Montage:
                    DA.SelectCommand.CommandText = "select * from " + Base.BaseName + "..f_MAINVIEW(" + uvo.id + ") where idstatus != 13 and idstatus != 14 and idsubst in (15,18) order by ids";
                    break;
                case Roles.Constructor:
                    DA.SelectCommand.CommandText = "select * from " + Base.BaseName + "..f_MAINVIEW(" + uvo.id + ") where idstatus != 13 and idstatus != 14 and paint_constr = 1 order by ids";
                    break;
                case Roles.Inzhener:
                    DA.SelectCommand.CommandText = "select * from " + Base.BaseName + "..f_MAINVIEW(" + uvo.id + ") where idstatus != 13 and idstatus != 14 and paint_inzh = 1 order by ids";
                    break;
            }

            int i = DA.Fill(DS, "t");
            return DS.Tables["t"];
        }

        internal object GetMainViewFinished()
        {
            DA.SelectCommand.CommandText = "select * from " + Base.BaseName + "..f_MAINVIEW(1) where idstatus = 13 order by ids";
            int i = DA.Fill(DS, "t");
            return DS.Tables["t"];
        }

    }
}
