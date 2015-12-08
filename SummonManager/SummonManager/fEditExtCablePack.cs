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
    public partial class fEditExtCablePack : Form
    {
        string IDNEWSUMMON;
        public fEditExtCablePack(string idnewsummon)
        {
            InitializeComponent();
            IDNEWSUMMON = idnewsummon;
        }

        private void bClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bAdd_Click(object sender, EventArgs e)
        {
            fAddExtCableForPack faec = new fAddExtCableForPack(IDNEWSUMMON);
            faec.ShowDialog();
            fEditExtCablePack_Load(sender, e);
            MessageBox.Show("Внешний кабель успешно добавлен в комплект!");

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
            DBEXTCABLE dbec = new DBEXTCABLE();
            dgv.DataSource = dbec.GetEXTCABLEsForPack(IDNEWSUMMON);
            dgv.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dgv.Columns["id"].HeaderText = "Номер извещения";
            dgv.Columns["id"].Visible = false;
            dgv.Columns["nn"].HeaderText = "№№";
            dgv.Columns["nn"].Width = 30;
            dgv.Columns["name"].HeaderText = "Название кабеля";
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
