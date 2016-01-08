using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SummonManager.CLASSES
{
    public struct WPNameVO
    {
        public WPNameVO(int ID)
        {
            DBWPName dbwp = new DBWPName();
            this = dbwp.GetWP(ID);
        }
        public int ID;
        public string WPName;
        public int IDCat;
        public string DecNum;
        public string Composition;
        public string DimenDrawing;
        public string PowerSupply;
        public string Configuration;
        public string Note;
    }
}
