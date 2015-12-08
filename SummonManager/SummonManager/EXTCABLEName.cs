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
    public partial class EXTCABLE: Form
    {
        public EXTCABLE()
        {
            InitializeComponent();
            DBEXTCABLE dbwp = new DBEXTCABLE();
            dgWP.DataSource = dbwp.GetAllEXTCABLENames();
            dgWP.Columns["ID"].Visible = false;
            dgWP.Columns["EXTCABLENAME"].HeaderText = "Наименование изделия";
            dgWP.Columns["EXTCABLENAME"].Width = 350;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NewEXTCABLENAME nwp = new NewEXTCABLENAME();
            nwp.ShowDialog();
            DBEXTCABLE dbwp = new DBEXTCABLE();
            dgWP.DataSource = dbwp.GetAllEXTCABLENames();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            EditEXTCABLENAME ew = new EditEXTCABLENAME(dgWP.SelectedRows[0].Cells["ID"].Value.ToString());
            ew.ShowDialog();
            DBEXTCABLE dbwp = new DBEXTCABLE();
            dgWP.DataSource = dbwp.GetAllEXTCABLENames();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            NewEXTCABLENAME nwp = new NewEXTCABLENAME(dgWP.SelectedRows[0].Cells["EXTCABLENAME"].Value.ToString());
            nwp.ShowDialog();
            DBEXTCABLE dbwp = new DBEXTCABLE();
            dgWP.DataSource = dbwp.GetAllEXTCABLENames();

        }
    }
}
