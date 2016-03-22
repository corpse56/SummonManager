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
    public partial class WPNameView : UserControl
    {
        SummonVO SVO;
        public WPNameView(SummonVO svo)
        {
            SVO = svo;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (SVO.WPNAMEVO.WPType == WPTYPE.WPNAMELIST)
            {
                WPNameVO.WPNameVOByID(SelectedWPNameID);
                NewWPN ewp = new NewWPN(WPNameVO.WPNameVOByID(SelectedWPNameID), "VIEWONLY",null);
                ewp.ShowDialog();
            }

        }
        public void Init(int _SelectedWPNameID)
        {
            this.SelectedWPNameID = _SelectedWPNameID;
            WPNameVO vo = WPNameVO.WPNameVOByID(_SelectedWPNameID);
            textBox1.Text = vo.WPName + " " + vo.DecNum;
        }
        public int SelectedWPNameID;
    }
}
