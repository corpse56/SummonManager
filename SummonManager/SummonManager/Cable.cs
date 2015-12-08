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
    public partial class Cable : Form
    {
        public Cable()
        {
            InitializeComponent();
            DBCable dbwp = new DBCable();
            dgWP.DataSource = dbwp.GetAll();
            dgWP.Columns["ID"].Visible = false;
            dgWP.Columns["CNAME"].HeaderText = "Наименование кабеля";
            dgWP.Columns["CNAME"].Width = 350;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NewCable nwp = new NewCable();
            nwp.ShowDialog();
            DBCable dbwp = new DBCable();
            dgWP.DataSource = dbwp.GetAll();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            EditCable ew = new EditCable(dgWP.SelectedRows[0].Cells["ID"].Value.ToString());
            ew.ShowDialog();
            DBCable dbwp = new DBCable();
            dgWP.DataSource = dbwp.GetAll();

        }
    }
}