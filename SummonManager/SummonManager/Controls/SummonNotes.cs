using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SummonManager
{
    public partial class SummonNotes : UserControl
    {
        public string ID = "0";
        public UserVO UVO;
        public SummonVO SVO;
        public void Init(string ID_,UserVO UVO_,SummonVO SVO_)
        {
            this.ID = ID_;
            this.UVO = UVO_;
            this.SVO = SVO_;
        }
        public SummonNotes()
        {
            InitializeComponent();

            dgNote.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dgNote.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgNote.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DBSummonNotes DBSN = new DBSummonNotes();
            dgNote.DataSource = DBSN.GetAllNotesByIDSummon(ID);

            dgNote.Columns["ID"].Visible = false;
            dgNote.Columns["IDSUMMON"].Visible = false;
            dgNote.Columns["CREATED"].HeaderText = "Дата";
            dgNote.Columns["CREATED"].Width = 70;
            dgNote.Columns["CREATED"].DefaultCellStyle.Format = "dd.MM.yyyy HH:mm";
            dgNote.Columns["ROLENAME"].HeaderText = "Отдел";
            dgNote.Columns["ROLENAME"].Width = 80;
            dgNote.Columns["FIO"].HeaderText = "ФИО";
            dgNote.Columns["FIO"].Width = 90;
            dgNote.Columns["NOTE"].HeaderText = "Примечание";
            dgNote.Columns["NOTE"].Width = 260;
        }

        private void SummonNotes_Load(object sender, EventArgs e)
        {

        }
        public void Reload()
        {
            DBSummonNotes DBSN = new DBSummonNotes();
            dgNote.DataSource = DBSN.GetAllNotesByIDSummon(ID);

        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Reload();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fAddNote fan = new fAddNote(this.ID,this.UVO.id);
            fan.ShowDialog();
            this.Reload();
            DBSummon dbs = new DBSummon();
            dbs.AddSummonView(SVO, UVO);
        }



    }
}
