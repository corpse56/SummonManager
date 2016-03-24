using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SummonManager.CLASSES;
using SummonManager.Properties;

namespace SummonManager.Controls
{
    public partial class Package : UserControl
    {
        WPTYPE WPT;
        int IDWP;
        UserVO UVO;
        public Package()
        {
            InitializeComponent();
        }
        Roles ResposibleRole, CurrentRole;
        bool REQ;
        public bool Required
        {
            get { return REQ; }
            set
            {
                this.REQ = value;
                checkBox1.Checked = this.REQ;
                if ((ResposibleRole == CurrentRole) || (CurrentRole == Roles.Admin) || ((CurrentRole == Roles.SimpleInzhener) && (ResposibleRole == Roles.Inzhener)))
                {
                    this.Enabled = value;
                }
            }
        }
        public bool RequiredVisible
        {
            set
            {
                if (value)
                {
                    checkBox1.Visible = true;
                }
                else
                {
                    checkBox1.Visible = false;
                }
            }
        }
        public bool RequiredEnabled
        {
            set
            {
                checkBox1.Enabled = value;
            }
        }
        bool EnabledPACKCONTROL = true;
        public new bool Enabled
        {
            get { return EnabledPACKCONTROL; }
            set
            {
                if (value)
                {
                    this.EnabledPACKCONTROL = true;
                    button1.Enabled = true;
                    dgv.Enabled = true;
                    //checkBox1.Enabled = true;
                    button1.BackgroundImage = Resources.edit1;
                }
                else
                {
                    this.EnabledPACKCONTROL = false;
                    button1.Enabled = false;
                    dgv.Enabled = false;
                    //checkBox1.Enabled = false;
                    button1.BackgroundImage = Resources.edit_notes_gray;
                }
            }
        }
        public void Init(WPTYPE wpt, int idwp, bool require, bool enabled, bool require_visible, bool require_enabled, Roles resprole, Roles currole,UserVO uvo)
        {
            this.ResposibleRole = resprole;
            this.CurrentRole = currole;
            this.WPT = wpt;
            this.IDWP = idwp;
            this.Required = require;
            this.RequiredVisible = require_visible;
            this.checkBox1.Enabled = require_enabled;
            this.Enabled = enabled;
            this.UVO = uvo;
            switch (WPT)
            {
                case WPTYPE.CABLELIST:
                    DBCableList dbc = new DBCableList();
                    dgv.DataSource = dbc.GetPackage(IDWP);
                    dgv.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
                    dgv.Columns["id"].Visible = false;
                    dgv.Columns["nn"].HeaderText = "№№";
                    dgv.Columns["nn"].FillWeight = 30;
                    dgv.Columns["name"].HeaderText = "Название кабеля";
                    dgv.Columns["name"].FillWeight = 400;
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
                    dgv.Columns["name"].HeaderText = "Название жгута";
                    dgv.Columns["name"].FillWeight = 400;
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
            fEditPackage fep = new fEditPackage(WPT, IDWP, UVO);
            fep.ShowDialog();

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            this.Required = checkBox1.Checked;
        }
    }
}
