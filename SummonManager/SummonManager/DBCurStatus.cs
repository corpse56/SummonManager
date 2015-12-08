﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SummonManager
{
    class DBCurStatus :DB
    {
        public DBCurStatus() { }

        public void AddNewCurstatus(string IDS,string iduser)
        {
            DA.InsertCommand.CommandText = "insert into " + Base.BaseName + "..CURSTATUS (IDS,STATID,CAUSE,CHANGED,IDUSER) " +
                                           " values ('"+IDS+"',1,'Новое','" + DateTime.Now.ToString("yyyyMMdd HH:mm") + "'," + iduser + ")";
            DA.InsertCommand.Connection.Open();
            DA.InsertCommand.ExecuteNonQuery();
            DA.InsertCommand.CommandText = "insert into " + Base.BaseName + "..CURSTATUS (IDS,STATID,CAUSE,CHANGED,IDUSER) " +
                                           " values ('" + IDS + "',2,'-','" + DateTime.Now.ToString("yyyyMMdd HH:mm") + "'," + iduser + ")";
            DA.InsertCommand.ExecuteNonQuery();
            DA.InsertCommand.Connection.Close();
            DA.UpdateCommand.CommandText = "update " + Base.BaseName + "..SUMMON set IDSTATUS = 2 where IDS = '" + IDS + "'";
            DA.UpdateCommand.Connection.Open();
            DA.UpdateCommand.ExecuteNonQuery();
            DA.UpdateCommand.Connection.Close();

        }

        internal void SaveNewCurstatus(string IDS, string iduser)
        {
            DA.InsertCommand.CommandText = "insert into " + Base.BaseName + "..CURSTATUS (IDS,STATID,CAUSE,CHANGED,IDUSER) " +
                                           " values ('" + IDS + "',1,'Новое','" + DateTime.Now.ToString("yyyyMMdd HH:mm") + "'," + iduser + ")";
            DA.InsertCommand.Connection.Open();
            DA.InsertCommand.ExecuteNonQuery();
            DA.InsertCommand.Connection.Close();
            DA.UpdateCommand.CommandText = "update " + Base.BaseName + "..SUMMON set IDSTATUS = 1 where IDS = '" + IDS + "'";
            DA.UpdateCommand.Connection.Open();
            DA.UpdateCommand.ExecuteNonQuery();
            DA.UpdateCommand.Connection.Close();

        }

        internal void ChangeStatus(SummonVO SVO, int idstatus,string cause,string iduser)
        {
            DA.InsertCommand.CommandText = "insert into " + Base.BaseName + "..CURSTATUS (IDS,STATID,CAUSE,CHANGED,IDUSER) " +
                      " values ('" + SVO.IDS + "',"+idstatus.ToString()+",@cause,'" + DateTime.Now.ToString("yyyyMMdd HH:mm") + "'," + iduser + ")";
            DA.InsertCommand.Parameters.Add("cause", System.Data.SqlDbType.NVarChar);
            DA.InsertCommand.Parameters["cause"].Value = cause;
            DA.InsertCommand.Connection.Open();
            DA.InsertCommand.ExecuteNonQuery();
            DA.InsertCommand.Connection.Close();
            DA.InsertCommand.Parameters.Remove(DA.InsertCommand.Parameters["cause"]);
            DA.UpdateCommand.CommandText = "update " + Base.BaseName + "..SUMMON set VIEWED = 0,IDSTATUS = "+idstatus.ToString()+" where IDS = '" + SVO.IDS + "'";
            DA.UpdateCommand.Connection.Open();
            DA.UpdateCommand.ExecuteNonQuery();
            DA.UpdateCommand.Connection.Close();
        }

        public DataTable GetAllStatuses()
        {
            DS = new DataSet();
            DA.SelectCommand.CommandText = "select * from " + Base.BaseName + "..STATUSLIST where ID != 14";
            DA.Fill(DS, "t");
            return DS.Tables["t"];
        }
        
        public DataTable GetAllStatuses(Roles role)
        {
            DS = new DataSet();
            switch (role)
            {
                case Roles.Logist:
                    DA.SelectCommand.CommandText = "select ID,'Закрыть извещение' SNAME from " + Base.BaseName +
                        "..STATUSLIST where ID != 14 and (ID = 13)";
                    break;
                case Roles.Manager:
                    DA.SelectCommand.CommandText = "select ID,case when ID = 3 then 'ПДБ' else 'Отдел логистики' end SNAME from " + Base.BaseName +
                        "..STATUSLIST where ID != 14 and ID in(3,12)";
                    break;
                case Roles.Montage:
                    DA.SelectCommand.CommandText = "select ID,case when ID = 16 then 'ОТК' else 'Цех' end SNAME from " + Base.BaseName +
                        "..STATUSLIST where ID != 14 and ID in (16,5)";
                    break;
                case Roles.OTK:
                    //DA.SelectCommand.CommandText = "select ID,case when ID = 2 then 'Менеджер' else 'Коммерческий отдел' end SNAME from " + Base.BaseName +
                    DA.SelectCommand.CommandText = "select ID,case when ID = 2 then 'Менеджер' else " +
                                                            " case when ID = 9 then 'Коммерческий отдел' else" +
                                                            " case when ID = 8 then 'Цех (на рекламацию)' else" +
                                                            " case when ID = 3 then 'ПДБ' else" +
                                                            " case when ID = 4 then 'Производство' else" +
                                                            " 'Монтажники' end end end end end SNAME" +
                                                            " from " + Base.BaseName +
                        "..STATUSLIST where ID != 14 and ID in (9,2,8,18,3,4)--,8,17,18)";
                    break;
                case Roles.Ozis:
                    //DA.SelectCommand.CommandText = "select ID,case when ID = 4 then 'Производство' else 'Монтажники' end SNAME from " + Base.BaseName +
                    DA.SelectCommand.CommandText = "select ID,case when ID = 4 then 'Производство' else " +
                                                            " case when ID = 15 then 'Монтажники' else" +
                                                            " case when ID = 2 then 'Менеджер' else" +
                                                            " 'Монтажники' end end end SNAME" +
                                                            " from " + Base.BaseName +
                        "..STATUSLIST where ID != 14 and ID in (4,15,2)";
                    break;
                case Roles.Prod:
                    DA.SelectCommand.CommandText = "select ID,case when ID = 5 then 'Цех' else " +
                                                            " case when ID = 3 then 'ПДБ' else" +
                                                            " case when ID = 7 then 'ОТК' else" +
                                                            " 'Монтажники' end end end SNAME" +
                                                            " from " + Base.BaseName +
                        "..STATUSLIST where ID != 14 and ID in (5,3,7,15)";
                    break;
                case Roles.Ware:
                    DA.SelectCommand.CommandText = "select ID,'Отдел логистики' SNAME from " + Base.BaseName +
                        "..STATUSLIST where ID != 14 and ID in (11)";
                    break;
                case Roles.Wsh:
                    DA.SelectCommand.CommandText = "select ID,case when ID = 7 then 'ОТК' else " +
                                                            " case when ID = 6 then 'Производство' else" +
                                                            " case when ID = 3 then 'ПДБ' else" +
                                                            " 'Монтажники' end end end SNAME" +
                                                            " from " + Base.BaseName +
                        "..STATUSLIST where ID != 14 and ID in (7,6,3,15)";
                    break;
            }
            //DA.SelectCommand.CommandText = "select * from " + Base.BaseName + "..STATUSLIST where ID != 14";
            DA.Fill(DS, "t");
            return DS.Tables["t"];
        }
    }
}