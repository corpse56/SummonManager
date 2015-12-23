using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SummonManager
{
    class UIProc
    {
        public void LoadExtCables(DataGridView dgv, string IDNEWSUMMON)
        {
            DBEXTCABLE dbec = new DBEXTCABLE();
            dgv.DataSource = dbec.GetEXTCABLEsForPack(IDNEWSUMMON);
            dgv.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            dgv.Columns["id"].HeaderText = "Номер извещения";
            dgv.Columns["id"].Visible = false;
            dgv.Columns["nn"].HeaderText = "№№";
            dgv.Columns["nn"].Width = 30;
            dgv.Columns["name"].HeaderText = "Название кабеля";
            dgv.Columns["name"].Width = 270;
            dgv.Columns["cnt"].HeaderText = "Количество";
            dgv.Columns["cnt"].Width = 100;
            int i = 0;
            foreach (DataGridViewRow r in dgv.Rows)
            {
                r.Cells["nn"].Value = ++i;
            }

        }
    }
}
