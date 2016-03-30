﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SummonManager
{
    public partial class NewCable_old : Form
    {
        public NewCable_old()
        {
            InitializeComponent();
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
            dbwp.AddNew(textBox1.Text);
            MessageBox.Show("Наименование успешно добавлено!");
            Close();
        }
    }
}