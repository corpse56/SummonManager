﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SummonManager.CLASSES;
using System.Diagnostics;

namespace SummonManager
{
    public partial class EditWPCategory: Form
    {
        string ENTITY;
        public EditWPCategory(string ENTITY_)
        {
            this.ENTITY = ENTITY_;
            InitializeComponent();
            
            DBCOMPARC dbarc = new DBCOMPARC();
            DBCategory dbc = new DBCategory(this.ENTITY);
            dgWP.DataSource = dbc.GetAll();
            dgWP.Columns["ID"].Visible = false;
            dgWP.Columns["CATEGORYNAME"].HeaderText = "Наименование категории";
            dgWP.Columns["CATEGORYNAME"].Width = 200;
            switch (this.ENTITY)
            {
                case "WPNAMELIST":
                    this.Text = "Категории изделия";
                    break;
                case "CABLELIST":
                    this.Text = "Категории кабелей";
                    break;
                case "ZHGUTLIST":
                    this.Text = "Категории жгутов";
                    break;
                case "RUNCARDLIST":
                    this.Text = "Категории технологических карт";
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NewCategory n = new NewCategory(this.ENTITY);
            n.ShowDialog();
            dgWP.DataSource = new DBCategory(this.ENTITY).GetAll();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dgWP.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите строку!");
                return;
            }
            if ((dgWP.SelectedRows[0].Cells["CATEGORYNAME"].Value.ToString().ToUpper() == "ВСЕ") || (dgWP.SelectedRows[0].Cells["CATEGORYNAME"].Value.ToString() == "Не присвоено"))
            {
                MessageBox.Show("Вы не можете удалить эту категорию, так как она является системной!");
                return;
            }
            NewCategory n = new NewCategory(dgWP.SelectedRows[0].Cells["CATEGORYNAME"].Value.ToString(), (int)dgWP.SelectedRows[0].Cells["ID"].Value);
            n.ShowDialog();
            dgWP.DataSource = new DBCategory(this.ENTITY).GetAll();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dgWP.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите строку!");
                return;
            }
            if ((dgWP.SelectedRows[0].Cells["CATEGORYNAME"].Value.ToString().ToUpper() == "ВСЕ") || (dgWP.SelectedRows[0].Cells["CATEGORYNAME"].Value.ToString() == "Не присвоено"))
            {
                MessageBox.Show("Вы не можете удалить эту категорию, так как она является системной!");
                return;
            }

            DialogResult dr = MessageBox.Show("После удаления категории все изделия этой категории получат категорию \"Не присвоено\", а также удалятся все подкатегории этой категории! Вы действительно хотите удалить категорию?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (dr == DialogResult.Yes)
            {
                new DBCategory(this.ENTITY).Delete(dgWP.SelectedRows[0].Cells["ID"].Value.ToString());
                MessageBox.Show("Подкатегория успешно удалена!");
            }
            dgWP.DataSource = new DBCategory(this.ENTITY).GetAll();

        }

        

        

       
    }
}
