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
    public partial class NewEXTCABLENAME : Form
    {
        public NewEXTCABLENAME()
        {
            InitializeComponent();
        }
        public NewEXTCABLENAME(string str)
        {
            InitializeComponent();
            textBox1.Text = str;
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
            DBEXTCABLE dbexc = new DBEXTCABLE();
            dbexc.AddNewEXTCABLE(textBox1.Text);
            MessageBox.Show("Наименование успешно добавлено!");
            Close();
        }
    }
}
