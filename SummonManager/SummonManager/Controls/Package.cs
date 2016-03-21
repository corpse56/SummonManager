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
    public partial class Package : UserControl
    {
        WPTYPE WPT;
        int IDWP;
        public Package()
        {
            InitializeComponent();
        }
        bool REQ;
        public bool Required
        {
            get { return REQ; }
            set
            {
                this.REQ = value;
                checkBox1.Checked = this.REQ;
            }
        }
        public void Init(WPTYPE wpt,int idwp,bool require)
        {
            this.WPT = wpt;
            this.IDWP = idwp;
            this.REQ = require;
            switch (WPT)
            {
                case WPTYPE.CABLELIST:
                    DBCableList dbc = new DBCableList();
                    dgv.DataSource = dbc.GetPackage(IDWP);
                    dgv.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
                    dgv.Columns["id"].Visible = false;
                    dgv.Columns["nn"].HeaderText = "№№";
                    dgv.Columns["nn"].FillWeight = 30;
                    dgv.Columns["CABLENAME"].HeaderText = "Название кабеля";
                    dgv.Columns["CABLENAME"].FillWeight = 400;
                    dgv.Columns["CNT"].HeaderText = "Количество";
                    dgv.Columns["CNT"].FillWeight = 100;
                    int i = 0;
                    foreach (DataGridViewRow r in dgv.Rows)
                    {
                        r.Cells["nn"].Value = ++i;
                    }
                    break;
                case WPTYPE.ZHGUTLIST:
                    DBZhgutList dbz = new DBZhgutList();
                    dgv.DataSource = dbz.GetPackage(IDWP);
                    dgv.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
                    dgv.Columns["id"].Visible = false;
                    dgv.Columns["nn"].HeaderText = "№№";
                    dgv.Columns["nn"].FillWeight = 30;
                    dgv.Columns["ZHGUTNAME"].HeaderText = "Название жгута";
                    dgv.Columns["ZHGUTNAME"].FillWeight = 400;
                    dgv.Columns["CNT"].HeaderText = "Количество";
                    dgv.Columns["CNT"].FillWeight = 100;
                    i = 0;
                    foreach (DataGridViewRow r in dgv.Rows)
                    {
                        r.Cells["nn"].Value = ++i;
                    }
                    break;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            fEditPackage fep = new fEditPackage(WPT, IDWP);
            fep.ShowDialog();

        }
    }
}
