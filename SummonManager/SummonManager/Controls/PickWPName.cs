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
        public PickWPName()
        {
            InitializeComponent();
        }
        public void Init(UserVO uvo)
        {
            this.UVO = uvo;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            WPName wp = new WPName(true,UVO, WPTYPE.WPNAMELIST);
            wp.ShowDialog();
            if (wp.PickedID == 0)
            {
                return;
            }

            PickedProduct = ProductFactory.Create(wp.PickedID, wp.PickedType);
            textBox1.Text = PickedProduct.GetName();
        }
        public IProduct PickedProduct;
    }
}
