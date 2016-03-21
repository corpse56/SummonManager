using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SummonManager.CLASSES
{
    public class CableVO
    {
        public CableVO() 
        {
            this.WPType = WPTYPE.CABLELIST;
        }

        public static CableVO GetCableVOByID(int ID)
        {
            return new DBCableList().GetCableVOByID(ID);

        }
        public WPTYPE WPType;
        public int ID;
        public string WPName;
        public int IDCat;
        public int IDSubCat;
        public string DecNum;
        public string DIMENDRAWING;
        public string CONECTORS;
        public string CLENGTH;
        public string NOTE;


    }
}
