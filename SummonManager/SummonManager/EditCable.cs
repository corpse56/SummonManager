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
    public partial class EditCable : Form
    {
        string IDW;
        public EditCable(string idw)
        {
            InitializeComponent();
            this.IDW = idw;
            OLDDBCable dbwp = new OLDDBCable();
            textBox1.Text = dbwp.Get(this.IDW);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Введите наименование!");
                return;
            }
            OLDDBCable dbwp = new OLDDBCable();
            dbwp.Edit(textBox1.Text,this.IDW);
            MessageBox.Show("Наименование успешно изменено!");
            Close();
        }
    }
}
