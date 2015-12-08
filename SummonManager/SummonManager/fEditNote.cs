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
    public partial class fEditNote : Form
    {
        string ids;
        DBSummon dbs;
        SummonVO SVO;
        public string notetext = "";
        public bool result = false;
        public fEditNote(string ids_)
        {
            InitializeComponent();
            this.ids = ids_;
            dbs = new DBSummon();
            SVO = dbs.GetSummonByIDS(ids);
            textBox1.Text = SVO.NOTE;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            result = true;
            SVO.NOTE = textBox1.Text;
            dbs.SaveSummon(SVO);
            notetext = textBox1.Text;
            MessageBox.Show("Сохранено успешно!");
            Close();
        }
    }
}
