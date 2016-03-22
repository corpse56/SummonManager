using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SummonManager.CLASSES;

namespace SummonManager.Controls
{
    public partial class PickWPName : UserControl
    {
        UserVO UVO;
        public PickWPName(UserVO UVO_)
        {
            InitializeComponent();
            this.UVO = UVO_;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WPName wp = new WPName(true,UVO, WPTYPE.WPNAMELIST);
            wp.ShowDialog();
            if (wp.PickedID == 0)
            {
                return;
            }
            DBWPName dbw = new DBWPName();

            WPNameVO WPVO = WPNameVO.WPNameVOByID(wp.PickedID);
            textBox1.Text = WPVO.WPName + " " + WPVO.DecNum;
            textBox1.Tag = wp.PickedID;
            this.PickedID = wp.PickedID;
        }
        public int PickedID;
    }
}
