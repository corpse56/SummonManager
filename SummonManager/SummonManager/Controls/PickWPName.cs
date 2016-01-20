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
        public PickWPName()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WPName wp = new WPName(true);
            wp.ShowDialog();
            if (wp.PickedID == 0)
            {
                return;
            }
            DBWPName dbw = new DBWPName();

            WPNameVO WPVO = new WPNameVO(wp.PickedID);
            textBox1.Text = WPVO.WPName + " " + WPVO.DecNum;
            textBox1.Tag = wp.PickedID;
            this.PickedID = wp.PickedID;
        }
        public int PickedID;
    }
}
