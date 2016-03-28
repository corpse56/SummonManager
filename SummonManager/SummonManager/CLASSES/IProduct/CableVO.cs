using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SummonManager.CLASSES
{
    public class CableVO : IProduct
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
            NewCABLE f = new NewCABLE(this, "VIEWONLY", UVO);
            f.ShowDialog();
        }
        void IProduct.FillTableLayoutPanel(TableLayoutPanel TLP, UserVO UVO)
        {
        }

    }
}
