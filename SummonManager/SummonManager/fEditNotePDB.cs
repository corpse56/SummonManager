using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SummonManager
{
    public partial class fEditNotePDB : Form
    {
        string ids;
        DBSummon dbs;
        SummonVO SVO;
        public fEditNotePDB(string ids_)
        {
            InitializeComponent();
            this.ids = ids_;
            dbs = new DBSummon();
            SVO = dbs.GetSummonByIDS(ids);
            textBox1.Text = SVO.NOTEPDB;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SVO.NOTEPDB = textBox1.Text;
            dbs.SaveSummon(SVO);
            MessageBox.Show("Сохранено успешно!");
            Close();
        }
    }
}
