using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SummonManager.Controls;

namespace SummonManager.CLASSES
{
    public enum WPTYPE { WPNAMELIST, CABLELIST, ZHGUTLIST}
    public static class WPTYPETOSTRING
    {
        public static string ToString(WPTYPE WPT)
        {
            switch (WPT)
            {
                case WPTYPE.WPNAMELIST:
                    return "WPNAMELIST";
                case WPTYPE.ZHGUTLIST:
                    return "ZHGUTLIST";
                case WPTYPE.CABLELIST:
                    return "CABLELIST";
            }
            return "";
        }
    }


    public class WPNameVO : IProduct
    {
        
        public WPNameVO()
        {
            //DBWPName dbwp = new DBWPName();
            //this = dbwp.GetWP(ID);
            //this.WPType = wpt;
            
        }
        internal static WPNameVO WPNameVOByID(int id)
        {
            return new DBWPName().GetWPNameByID(id);
        }

        public WPTYPE WPType; 
        public int ID;
        public string WPName;
        public int IDCat;
        public int IDSubCat;
        public string DecNum;
        public string WIRINGDIAGRAM;
        public string TECHREQ;
        public string COMPOSITION;
        public string CONFIGURATION;
        public string DIMENDRAWING;
        public string SBORKA3D;
        public string MECHPARTS;
        public List<ZhgutVO> ZHGUTS;
        public List<CableVO> CABLES;
        public string SHILDS;
        public string PLANKA;
        public string SERIAL;
        public string PACKAGING;
        public string PASSPORT;
        public string MANUAL;
        public string PACKINGLIST;
        public string PowerSupply;
        public string Note;

        public bool COMPOSITIONREQ;
        public bool DIMENSIONALDRAWINGREQ	;
        //public bool POWERSUPPLYREQ	;
        public bool CONFIGURATIONREQ;	
        public bool WIRINGDIAGRAMREQ;	
        public bool TECHREQREQ	;
        public bool SBORKA3DREQ	;
        public bool MECHPARTSREQ;	
        public bool SHILDSREQ	;
        public bool PLANKAREQ	;
        public bool SERIALREQ	;
        public bool PACKAGINGREQ	;
        public bool PASSPORTREQ	;
        public bool MANUALREQ	;
        public bool PACKINGLISTREQ	;
        public bool SOFTWAREREQ	;
        public bool CABLELISTREQ;	
        public bool ZHGUTLISTREQ;	
        public bool RUNCARDLISTREQ	;
        public bool CIRCUITBOARDLISTREQ;


        string IProduct.GetName()
        {
            return WPName + " " + DecNum;
        }
        WPTYPE IProduct.GetProductType()
        {
            return this.WPType;
        }
        int IProduct.GetID()
        {
            return this.ID;
        }
        void IProduct.ViewOnly(UserVO UVO)
        {
            NewWPN f = new NewWPN(this, "VIEWONLY", UVO);
            f.ShowDialog();
        }
        void IProduct.FillTableLayoutPanel(TableLayoutPanel TLP, UserVO UVO)
        {
            //===============================================================Inzhener
            WPNameVO wp = (WPNameVO)this;
            if (wp.COMPOSITIONREQ)
            {
                PathField pf = new PathField();
                pf.Init(wp.COMPOSITION, true, false, false, true, Roles.Inzhener, UVO.Role);
                pf.bDelVisible = false;
                pf.bPathVisible = false;
                pf.tbPath.Width += 150;
                UIWorks.AddToTLP(TLP, "Состав изделия", pf);
            }
            if (wp.TECHREQREQ)
            {
                PathField pf = new PathField();
                pf.Init(wp.TECHREQ, true, false, false, true, Roles.Inzhener, UVO.Role);
                pf.bDelVisible = false;
                pf.bPathVisible = false;
                pf.tbPath.Width += 150;

                UIWorks.AddToTLP(TLP, "Технические требования", pf);
            }
            if (wp.CONFIGURATIONREQ)
            {
                PathField pf = new PathField();
                pf.Init(wp.CONFIGURATION, true, false, false, true, Roles.Inzhener, UVO.Role);
                pf.bDelVisible = false;
                pf.bPathVisible = false;
                pf.tbPath.Width += 150;
                UIWorks.AddToTLP(TLP, "Конфигурация", pf);
            }
            //===============================================================Constructor
            if (wp.DIMENSIONALDRAWINGREQ)
            {
                PathField pf = new PathField();
                pf.Init(wp.DIMENDRAWING, true, false, false, true, Roles.Constructor, UVO.Role);
                pf.bDelVisible = false;
                pf.bPathVisible = false;
                pf.tbPath.Width += 150;
                UIWorks.AddToTLP(TLP, "Габаритный чертёж", pf);
            }
            if (wp.SBORKA3DREQ)
            {
                PathField pf = new PathField();
                pf.Init(wp.SBORKA3D, true, false, false, true, Roles.Constructor, UVO.Role);
                pf.bDelVisible = false;
                pf.bPathVisible = false;
                pf.tbPath.Width += 150;
                UIWorks.AddToTLP(TLP, "3Д сборка", pf);
            }
            if (wp.MECHPARTSREQ)
            {
                PathField pf = new PathField();
                pf.Init(wp.MECHPARTS, true, false, false, true, Roles.Constructor, UVO.Role);
                pf.bDelVisible = false;
                pf.bPathVisible = false;
                pf.tbPath.Width += 150;
                UIWorks.AddToTLP(TLP, "Проект механических деталей", pf);
            }
            if (wp.SHILDSREQ)
            {
                PathField pf = new PathField();
                pf.Init(wp.SHILDS, true, false, false, true, Roles.Constructor, UVO.Role);
                pf.bDelVisible = false;
                pf.bPathVisible = false;
                pf.tbPath.Width += 150;
                UIWorks.AddToTLP(TLP, "Шильды", pf);
            }
            if (wp.PLANKAREQ)
            {
                PathField pf = new PathField();
                pf.Init(wp.PLANKA, true, false, false, true, Roles.Constructor, UVO.Role);
                pf.bDelVisible = false;
                pf.bPathVisible = false;
                pf.tbPath.Width += 150;
                UIWorks.AddToTLP(TLP, "Планка фирменная", pf);
            }
            if (wp.PACKAGINGREQ)
            {
                PathField pf = new PathField();
                pf.Init(wp.PACKAGING, true, false, false, true, Roles.Constructor, UVO.Role);
                pf.bDelVisible = false;
                pf.bPathVisible = false;
                pf.tbPath.Width += 150;
                UIWorks.AddToTLP(TLP, "Упаковка", pf);
            }
            //===================================================================================TEHNOLOG

            //===================================================================================shemotehbik
            if (wp.WIRINGDIAGRAMREQ)
            {
                PathField pf = new PathField();
                pf.Init(wp.WIRINGDIAGRAM, true, false, false, true, Roles.Shemotehnik, UVO.Role);
                pf.bDelVisible = false;
                pf.bPathVisible = false;
                pf.tbPath.Width += 150;
                UIWorks.AddToTLP(TLP, "Схема электрическая монтажная", pf);
            }


            //===================================================================================OTK
            if (wp.SERIALREQ)
            {
                PathField pf = new PathField();
                pf.Init(wp.SERIAL, true, false, false, true, Roles.OTK, UVO.Role);
                pf.bDelVisible = false;
                pf.bPathVisible = false;
                pf.tbPath.Width += 150;
                UIWorks.AddToTLP(TLP, "Серийные номера", pf);
            }

            //===================================================================================OTD
            if (wp.PASSPORTREQ)
            {
                PathField pf = new PathField();
                pf.Init(wp.PASSPORT, true, false, false, true, Roles.OTD, UVO.Role);
                pf.bDelVisible = false;
                pf.bPathVisible = false;
                pf.tbPath.Width += 150;
                UIWorks.AddToTLP(TLP, "Паспорт/ЭТ", pf);
            }
            if (wp.MANUALREQ)
            {
                PathField pf = new PathField();
                pf.Init(wp.MANUAL, true, false, false, true, Roles.OTD, UVO.Role);
                pf.bDelVisible = false;
                pf.bPathVisible = false;
                pf.tbPath.Width += 150;
                UIWorks.AddToTLP(TLP, "РЭ", pf);
            }
            if (wp.PACKINGLISTREQ)
            {
                PathField pf = new PathField();
                pf.Init(wp.PACKINGLIST, true, false, false, true, Roles.OTD, UVO.Role);
                pf.bDelVisible = false;
                pf.bPathVisible = false;
                pf.tbPath.Width += 150;
                UIWorks.AddToTLP(TLP, "Лист упаковочный", pf);
            }


        }



    }
}
