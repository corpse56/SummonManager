using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;

namespace SummonManager
{
    public class PreviousState
    {
        List<int> w = new List<int>();
        List<string> n = new List<string>();
        public int indexOfSortedColumn = -1;
        SortOrder soOfSortedColumn = SortOrder.None;
        public string idOfSelectedRow = "";
        DataGridView dgv;
        public PreviousState(DataGridView dgv_)
        {
            this.dgv = dgv_;
            if (dgv.SelectedRows.Count != 0) idOfSelectedRow = dgv.SelectedRows[0].Cells[0].Value.ToString();
            foreach (DataGridViewColumn c in dgv.Columns)
            {
                w.Add(c.Width);
                n.Add(c.HeaderText);
                if (c.HeaderCell.SortGlyphDirection != SortOrder.None)
                {
                    soOfSortedColumn = c.HeaderCell.SortGlyphDirection;
                    indexOfSortedColumn = c.Index;
                }
            }
        }
        public void Restore()
        {
            int i = 0;
            if (indexOfSortedColumn != -1)
            {
                dgv.Columns[indexOfSortedColumn].HeaderCell.SortGlyphDirection = soOfSortedColumn;
                if (soOfSortedColumn == SortOrder.Ascending)
                    dgv.Sort(dgv.Columns[indexOfSortedColumn],ListSortDirection.Ascending);
                else
                    dgv.Sort(dgv.Columns[indexOfSortedColumn], ListSortDirection.Descending);

                //DGVUI ui = new DGVUI(dgv);
                //ui.Sort(this.indexOfSortedColumn, (List<TaskVO>)dgv.DataSource, soOfSortedColumn);
            }
            foreach (DataGridViewRow r in dgv.Rows)
            {
                if (r.Cells[0].Value.ToString() == this.idOfSelectedRow)
                {
                    r.Selected = true;
                    break;
                }
            }
            //dgv.Columns["ID"].Visible = false;
            foreach (DataGridViewColumn c in dgv.Columns)
            {

                c.Width = w[i];
                c.HeaderText = n[i++];
            }
            if (dgv.SelectedRows.Count != 0)
            {
                dgv.FirstDisplayedScrollingRowIndex = dgv.SelectedRows[0].Index;
            }
            //DGVUI.Paint(dgv);

        }
        public void RestoreSort()
        {
            int i = 0;
            foreach (DataGridViewColumn c in dgv.Columns)
            {

                c.Width = w[i];
                c.HeaderText = n[i++];
            }
            foreach (DataGridViewRow r in dgv.Rows)
            {
                if (r.Cells[0].Value.ToString() == this.idOfSelectedRow)
                {
                    r.Selected = true;
                }
            }
            //dgv.Columns["ID"].Visible = false;
            //DGVUI.Paint(dgv);

        }
    }

}
