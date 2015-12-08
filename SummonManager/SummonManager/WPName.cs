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
    public partial class WPName : Form
    {
        public WPName()
        {
            InitializeComponent();
            DBWPName dbwp = new DBWPName();
            dgWP.DataSource = dbwp.GetAllWPNames();
            dgWP.Columns["ID"].Visible = false;
            dgWP.Columns["WPNAME"].HeaderText = "Наименование изделия";
            dgWP.Columns["WPNAME"].Width = 350;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NewWPN nwp = new NewWPN();
            nwp.ShowDialog();
            DBWPName dbwp = new DBWPName();
            dgWP.DataSource = dbwp.GetAllWPNames();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            EditWPN ew = new EditWPN(dgWP.SelectedRows[0].Cells["ID"].Value.ToString());
            ew.ShowDialog();
            DBWPName dbwp = new DBWPName();
            dgWP.DataSource = dbwp.GetAllWPNames();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            NewWPN nwp = new NewWPN(dgWP.SelectedRows[0].Cells["WPNAME"].Value.ToString());
            nwp.ShowDialog();
            DBWPName dbwp = new DBWPName();
            dgWP.DataSource = dbwp.GetAllWPNames();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            if (MessageBox.Show("Вы действительно хотите удалить это наименование?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            DBWPName dbwp = new DBWPName();
            if (dbwp.Exists(dgWP.SelectedRows[0].Cells["ID"].Value.ToString()))
            {
                MessageBox.Show("Вы не можете удалить это наименование поскольку существует извещение с таким наименованием!");
                return;
            }
            dbwp.DeleteByID(dgWP.SelectedRows[0].Cells["ID"].Value.ToString());
            dgWP.DataSource = dbwp.GetAllWPNames();
        }



    }
}
