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
    public partial class NewWPN : Form
    {
        public NewWPN()
        {
            InitializeComponent();
        }
        public NewWPN(string clone)
        {
            InitializeComponent();
            textBox1.Text = clone;
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
            DBWPName dbwp = new DBWPName();
            dbwp.AddNewWP(textBox1.Text);
            MessageBox.Show("Наименование успешно добавлено!");
            Close();
        }
    }
}
