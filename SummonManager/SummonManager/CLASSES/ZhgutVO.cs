using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SummonManager.CLASSES
{
    public class ZhgutVO
    {
        public ZhgutVO() { }

        public static ZhgutVO GetZhgutVOByID(int ID)
        {
            return new DBZhgutList().GetZhgutVOByID(ID);

        }
        public WPTYPE WPType;
        public int ID;
        public string WPName;
        public int IDCat;
        public int IDSubCat;
        public string DecNum;
        public string ZHGUTPATH;
        public string NOTE;

        
    }
}
