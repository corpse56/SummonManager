using System;
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
        public EditWPCategory()
        {
            
            InitializeComponent();
            
            DBCOMPARC dbarc = new DBCOMPARC();
            DBCategory dbc = new DBCategory();
            dgWP.DataSource = dbc.GetAll();
            dgWP.Columns["ID"].Visible = false;
            dgWP.Columns["CATEGORYNAME"].HeaderText = "Наименование категории";
            dgWP.Columns["CATEGORYNAME"].Width = 200;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NewCategory n = new NewCategory();
            n.ShowDialog();
            dgWP.DataSource = new DBCategory().GetAll();
        }

        

        

       
    }
}
