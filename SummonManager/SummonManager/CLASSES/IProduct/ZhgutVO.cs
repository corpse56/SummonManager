﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SummonManager.CLASSES.IRole_namespace;

namespace SummonManager.CLASSES
{
    public class ZhgutVO :IProduct
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
        void IProduct.ViewOnly(IRole UVO)
        {
            NewZHGUT f = new NewZHGUT(this, "VIEWONLY", UVO);
            f.ShowDialog();
        }
        void IProduct.ViewEdit(IRole UVO)
        {
            NewZHGUT f = new NewZHGUT(this, "EDIT", UVO);
            f.ShowDialog();
        }
        void IProduct.FillTableLayoutPanel(TableLayoutPanel TLP, IRole UVO)
        {
        }

        
    }
}