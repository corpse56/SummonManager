using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SummonManager.CLASSES
{
    public enum WPTYPE { WPNAMELIST, CABLELIST, ZHGUTLIST}

    public class WPNameVO
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
        public bool POWERSUPPLYREQ	;
        public bool CONFIGURATIONREQ;	
        public bool WIRINGDIAGRAMREQ;	
        public bool TECHREQREQ	;
        public bool SBORKA3DREQ	;
        public bool MECHPARTSREQ;	
        public bool SHILDSREQ	;
        public bool PLANKAREQ	;
        public bool SERIALREQ	;
        public bool PACKAGEREQ	;
        public bool PASSPORTREQ	;
        public bool MANUALREQ	;
        public bool PACKAGELISTREQ	;
        public bool SOFTWAREREQ	;
        public bool CABLELISTREQ;	
        public bool ZHGUTLISTREQ;	
        public bool RUNCARDLISTREQ	;
        public bool CIRCUITBOARDLISTREQ;

    }
}
