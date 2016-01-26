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
    public partial class NewCategory : Form
    {
        public NewCategory()
        {
            InitializeComponent();
        }
        bool edit = false;
        int editID;
        public NewCategory(string cat,int id)
        {
            InitializeComponent();
            textBox1.Text = cat;
            this.Text = "Изменение категории";
            edit = true;
            editID = id;
            button2.Text = "Изменить";
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

            if (edit)
            {
                DBCategory dbwp = new DBCategory();
                dbwp.Edit(textBox1.Text, editID.ToString());
                MessageBox.Show("Категория успешно изменена!");
            }
            else
            {
                DBCategory dbwp = new DBCategory();
                dbwp.AddNew(textBox1.Text);
                MessageBox.Show("Категория успешно добавлена!");
            }
            Close();
        }
    }
}
