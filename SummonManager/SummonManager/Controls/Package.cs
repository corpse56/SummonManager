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
        int IDWP
        public Package()
        {
            InitializeComponent();
        }
        public void Init(WPTYPE wpt,int idwp)
        {
            this.WPT = wpt;
            this.IDWP = idwp;
            switch (WPT)
            {
                case WPTYPE.CABLELIST:
                    DBCableList dbc = new DBCableList();
                    dgv.DataSource = dbc.GetPackage(IDWP);
                    dgv.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
                    dgv.Columns["id"].Visible = false;
                    dgv.Columns["nn"].HeaderText = "№№";
                    dgv.Columns["nn"].Width = 30;
                    dgv.Columns["CABLENAME"].HeaderText = "Название кабеля";
                    dgv.Columns["CABLENAME"].Width = 400;
                    dgv.Columns["CNT"].HeaderText = "Количество";
                    dgv.Columns["CNT"].Width = 100;
                    int i = 0;
                    foreach (DataGridViewRow r in dgv.Rows)
                    {
                        r.Cells["nn"].Value = ++i;
                    }
                    break;
                case WPTYPE.ZHGUTLIST:
                    break;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
