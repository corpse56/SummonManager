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
    public partial class fAddExtCableForPack : Form
    {
        string IDNEWSUMMON;
        public fAddExtCableForPack(string idnewsummon)
        {
            InitializeComponent();
            IDNEWSUMMON = idnewsummon;
        }

        private void fAddExtCable_Load(object sender, EventArgs e)
        {
            DBEXTCABLE dbec = new DBEXTCABLE();
            comboBox1.DataSource = dbec.GetAllEXTCABLENamesForPack();
            comboBox1.ValueMember = "ID";
            comboBox1.DisplayMember = "EXTCABLENAME";
            


        }

        private void button2_Click(object sender, EventArgs e)
        {
            DBEXTCABLE dbec = new DBEXTCABLE();
            dbec.AddEXTCABLEToPack(IDNEWSUMMON, comboBox1.SelectedValue.ToString(), numericUpDown1.Value.ToString());
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
