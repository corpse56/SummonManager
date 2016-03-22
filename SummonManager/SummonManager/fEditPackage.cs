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
        string IDNEWSUMMON;
        public WPTYPE WPT;
        public int IDWP;
        public fEditPackage(WPTYPE wpt, int idwp)
        {
            this.WPT = wpt;
            this.IDWP = idwp;
            InitializeComponent();
            //IDNEWSUMMON = idnewsummon;
            
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
            DBEXTCABLE dbec = new DBEXTCABLE();
            dbec.RemoveEXTCABLEFromPack(dgv.SelectedRows[0].Cells["id"].Value.ToString());
            fEditExtCablePack_Load(sender, e);
            MessageBox.Show("Кабель успешно удалён!");


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
