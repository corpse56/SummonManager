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
        UserVO UVO;
        public WPNameView()
        {
            //SVO = svo;
            //UVO = UVO_;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            SVO.ProductVO.ViewOnly(UVO);

        }
        public void Init(int ID,WPTYPE WPT, UserVO uvo,SummonVO svo)
        {
            PickedProduct = ProductFactory.Create(ID, WPT);
            textBox1.Text = PickedProduct.GetName();
            this.UVO = uvo;
            this.SVO = svo;
        }
        public void Init(int ID, string WPT, UserVO uvo, SummonVO svo)
        {
            PickedProduct = ProductFactory.Create(ID, WPT);
            textBox1.Text = PickedProduct.GetName();
            this.UVO = uvo;
            this.SVO = svo;
        }
        public IProduct PickedProduct;
    }
}
