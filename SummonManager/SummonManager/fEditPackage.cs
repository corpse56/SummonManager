using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SummonManager.CLASSES;

namespace SummonManager
{
    public partial class fEditPackage : Form
    {
        public WPTYPE WPT;
        public int IDWP;
        UserVO UVO;
        public fEditPackage(WPTYPE wpt, int idwp, UserVO uvo)
        {
            InitializeComponent();
            this.WPT = wpt;
            this.IDWP = idwp;
            this.UVO = uvo;
            
        }

        private void bClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bAdd_Click(object sender, EventArgs e)
        {
            //fAddExtCableForPack faec = new fAddExtCableForPack(IDNEWSUMMON);
            //faec.ShowDialog();
            //fEditExtCablePack_Load(sender, e);
            //MessageBox.Show("Внешний кабель успешно добавлен в комплект!");



            WPName wp = new WPName(true, UVO, WPT);
            wp.ShowDialog();
            if (wp.PickedID == 0) return;
            if (WPT == WPTYPE.CABLELIST)
            {
                DBCableList dbc = new DBCableList();
                dbc.AddToPackage(IDWP, wp.PickedID,1);
            }

        }

        private void bDel_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите кабель!");
                return;
            }

            DialogResult dr = MessageBox.Show("Вы действительно хотите удалить кабель из комплекта?", "Внимание!", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (dr == DialogResult.No)
            {
                return;
            }
            //DBEXTCABLE dbec = new DBEXTCABLE();
            //dbec.RemoveEXTCABLEFromPack(dgv.SelectedRows[0].Cells["id"].Value.ToString());
            //fEditExtCablePack_Load(sender, e);
            //MessageBox.Show("Кабель успешно удалён!");


        }

        private void fEditExtCablePack_Load(object sender, EventArgs e)
        {
            if (WPT == WPTYPE.CABLELIST)
            {
                this.Text = "Редактирование комплекта кабелей";
                DBCableList dbc = new DBCableList();
                dgv.DataSource = dbc.GetPackage(this.IDWP);
                dgv.Columns["name"].HeaderText = "Название кабеля";

            }
            if (WPT == WPTYPE.ZHGUTLIST)
            {
                this.Text = "Редактирование комплекта жгутов";
                DBZhgutList dbz = new DBZhgutList();
                dgv.DataSource = dbz.GetPackage(this.IDWP);
                dgv.Columns["name"].HeaderText = "Название жгута";

            }
            dgv.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dgv.Columns["id"].Visible = false;
            dgv.Columns["nn"].HeaderText = "№№";
            dgv.Columns["nn"].Width = 30;
            dgv.Columns["name"].Width = 500;
            dgv.Columns["cnt"].HeaderText = "Количество";
            dgv.Columns["cnt"].Width = 150;
            int i = 0;
            foreach (DataGridViewRow r in dgv.Rows)
            {
                r.Cells["nn"].Value = ++i;
            }
        }

    }
}
