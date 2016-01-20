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
        public WPNameView()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EditWPN ewp = new EditWPN(SelectedWPNameID, true);
            ewp.ShowDialog();
        }
        public void Init(int _SelectedWPNameID)
        {
            this.SelectedWPNameID = _SelectedWPNameID;
            WPNameVO vo = new WPNameVO(_SelectedWPNameID);
            textBox1.Text = vo.WPName + " " + vo.DecNum;
        }
        public int SelectedWPNameID;
    }
}
