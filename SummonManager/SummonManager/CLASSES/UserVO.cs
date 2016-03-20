using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SummonManager
{
    public enum Roles { nol, Manager, Ozis, Prod, OTK, Ware, Logist, Admin, Director, Wsh, Montage, Constructor,Inzhener, Buhgalter, SimpleInzhener, Shemotehnik, Tehnolog, OTD}
    public class UserVO
    {
        public UserVO() 
        {
        }
        public string Fio;
        public string Login;
        public string Pass;
        public Roles Role;
        public string id;

        public override string ToString()
        {
            switch (this.Role)
            {
                case Roles.Admin:
                    return "Администратор";
                case Roles.Constructor:
                    return "Конструктор";
                case Roles.Director:
                    return "Директор";
                case Roles.Logist:
                    return "Отдел логистики";
                case Roles.Manager:
                    return "Менеджер";
                case Roles.Montage:
                    return "Монтажники";
                case Roles.nol:
                    return "без роли";
                case Roles.OTK:
                    return "ОТК";
                case Roles.Ozis:
                    return "ПДБ";
                case Roles.Prod:
                    return "Производство";
                case Roles.Ware:
                    return "Коммерческий отдел";
                case Roles.Wsh:
                    return "Цех";
                case Roles.Inzhener:
                    return "Главный инженер";
                case Roles.Buhgalter:
                    return "Бухгалтер";
                case Roles.SimpleInzhener:
                    return "Инженер";
                case Roles.Shemotehnik:
                    return "Схемотехник";
                case Roles.Tehnolog:
                    return "Технолог";
                case Roles.OTD:
                    return "ОТД";

                default:
                    return "не определено";
            }
        }
    }
}
