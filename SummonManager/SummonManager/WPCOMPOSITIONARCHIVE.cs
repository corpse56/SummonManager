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
    public partial class WPCOMPOSITIONARCHIVE: Form
    {
        string IDWP;
        public WPCOMPOSITIONARCHIVE(string idwp)
        {
            IDWP = idwp;
            InitializeComponent();
            DBEXTCABLE dbwp = new DBEXTCABLE();
            DBCOMPARC dbarc = new DBCOMPARC();

            dgWP.DataSource = dbarc.GetAll(IDWP);
            //.IDWP.dgWP.Columns["ID"].Visible = false;
            dgWP.Columns["ARCPATH"].HeaderText = "Путь";
            dgWP.Columns["ARCPATH"].Width = 350;
            dgWP.Columns["FROMDATE"].HeaderText = "Дата начала действия";
            dgWP.Columns["FROMDATE"].Width = 150;
            dgWP.Columns["DATEARC"].HeaderText = "Дата архивирования";
            dgWP.Columns["DATEARC"].Width = 150;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

       
    }
}
