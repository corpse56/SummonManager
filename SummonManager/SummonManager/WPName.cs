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
    public partial class WPName : Form
    {

        public WPName(bool pick)
        {
            InitializeComponent();
            if (pick)
            {
                button7.Visible = true;
                button2.Visible = false;
                button3.Visible = false;
                button4.Visible = false;
                button5.Visible = false;
                button6.Visible = false;
                bArchive.Visible = false;
                bArcShow.Visible = false;
            }
            else
            {
                button7.Visible = false;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NewWPN nwp = new NewWPN();
            nwp.ShowDialog();
            DBWPName dbwp = new DBWPName();
            dgWP.DataSource = dbwp.GetAllWPNames();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            EditWPN ew = new EditWPN(Convert.ToInt32(dgWP.SelectedRows[0].Cells["ID"].Value),false);
            ew.ShowDialog();
            DBWPName dbwp = new DBWPName();
            dgWP.DataSource = dbwp.GetAllWPNames();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            WPNameVO wp = new WPNameVO();
            DBWPName dbwp = new DBWPName();
            wp = dbwp.GetWP(Convert.ToInt32(dgWP.SelectedRows[0].Cells["ID"].Value));
            NewWPN nwp = new NewWPN(wp);
            nwp.ShowDialog();
            dgWP.DataSource = dbwp.GetAllWPNames();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            if (MessageBox.Show("Вы действительно хотите удалить это наименование?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            DBWPName dbwp = new DBWPName();
            if (dbwp.Exists(dgWP.SelectedRows[0].Cells["ID"].Value.ToString()))
            {
                MessageBox.Show("Вы не можете удалить это наименование поскольку существует извещение с таким наименованием!");
                return;
            }
            dbwp.DeleteByID(dgWP.SelectedRows[0].Cells["ID"].Value.ToString());
            dgWP.DataSource = dbwp.GetAllWPNames();
        }

        private void WPName_Load(object sender, EventArgs e)
        {
            DBCategory dbc = new DBCategory();
            cbCAT.ValueMember = "ID";
            cbCAT.DisplayMember = "CATEGORYNAME";
            cbCAT.DataSource = dbc.GetAll();
            cbCAT.SelectedValue = 2;

            DBWPName dbwp = new DBWPName();
            dgWP.DataSource = dbwp.GetAllWPNames();
            ShowDGV();

        }

        private void ShowDGV()
        {
            dgWP.Columns["ID"].Visible = false;
            dgWP.Columns["WPNAME"].HeaderText = "Наименование изделия";
            dgWP.Columns["CATEGORYNAME"].HeaderText = "Категория";
            dgWP.Columns["SUBCATNAME"].HeaderText = "Подкатегория";
            dgWP.Columns["DECNUM"].HeaderText = "Децимальный номер";
            dgWP.Columns["COMPOSITION"].HeaderText = "Состав изделия";
            dgWP.Columns["DIMENSIONALDRAWING"].HeaderText = "Габаритный чертёж";
            dgWP.Columns["POWERSUPPLY"].HeaderText = "Электропитание";
            dgWP.Columns["CONFIGURATION"].HeaderText = "Конфигурация";
            dgWP.Columns["NOTE"].HeaderText = "Примечание";
            foreach (DataGridViewRow r in dgWP.Rows)
            {
                r.Cells["COMPOSITION"].Tag = r.Cells["COMPOSITION"].Value;
                r.Cells["COMPOSITION"].Value = r.Cells["COMPOSITION"].Tag.ToString().Substring(r.Cells["COMPOSITION"].Tag.ToString().LastIndexOf("\\") + 1);
                r.Cells["DIMENSIONALDRAWING"].Tag = r.Cells["DIMENSIONALDRAWING"].Value;
                r.Cells["DIMENSIONALDRAWING"].Value = r.Cells["DIMENSIONALDRAWING"].Tag.ToString().Substring(r.Cells["DIMENSIONALDRAWING"].Tag.ToString().LastIndexOf("\\") + 1);
            }
            dgWP.Columns["WPNAME"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgWP.Columns["SUBCATNAME"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgWP.Columns["CATEGORYNAME"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgWP.Columns["DECNUM"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgWP.Columns["COMPOSITION"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgWP.Columns["DIMENSIONALDRAWING"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgWP.Columns["POWERSUPPLY"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgWP.Columns["CONFIGURATION"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgWP.Columns["NOTE"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgWP.Columns["WPNAME"].FillWeight = 250;
            dgWP.Columns["CATEGORYNAME"].FillWeight = 100;
            dgWP.Columns["SUBCATNAME"].FillWeight = 100;
            dgWP.Columns["DECNUM"].FillWeight = 200;
            dgWP.Columns["COMPOSITION"].FillWeight = 100;
            dgWP.Columns["DIMENSIONALDRAWING"].FillWeight = 100;
            dgWP.Columns["POWERSUPPLY"].FillWeight = 100;
            dgWP.Columns["CONFIGURATION"].FillWeight = 150;
            dgWP.Columns["NOTE"].FillWeight = 200;

        }



        private void bArchive_Click(object sender, EventArgs e)
        {
            int cat = (int)cbCAT.SelectedValue;
            if (dgWP.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите строку!");
                return;
            }
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "All files (*.*)|*.*";
            dialog.InitialDirectory = @"c:\";
            dialog.Title = "Перед архивированием выберите новый состав изделия!";
            dialog.Multiselect = false;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                WPNameVO wpVO = new WPNameVO((int)dgWP.SelectedRows[0].Cells["ID"].Value);
                DBCOMPARC dbarc = new DBCOMPARC();
                dbarc.AddNew(wpVO, dialog.FileName);
                MessageBox.Show("Состав изделия успешно заархивирован!");
                DBWPName dbwp = new DBWPName();
                dgWP.DataSource = dbwp.GetAllWPNames();
                ShowDGV();
                cbCAT.SelectedValue = cat;
            }
            else
            {
                return;
            }

        }

        private void bArcShow_Click(object sender, EventArgs e)
        {
            if (dgWP.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите строку!");
                return;
            }

            WPCOMPOSITIONARCHIVE arc = new WPCOMPOSITIONARCHIVE(dgWP.SelectedRows[0].Cells["ID"].Value.ToString());
            arc.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            EditWPCategory ed = new EditWPCategory();
            ed.ShowDialog();
            dgWP.DataSource = new DBWPName().GetAllWPNames();


        }
        public int PickedID;
        private void button7_Click(object sender, EventArgs e)
        {
            if (dgWP.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите изделие!");
                return;
            }
            PickedID = (int)dgWP.SelectedRows[0].Cells["ID"].Value;
            Close();
        }

        private void dgWP_DoubleClick(object sender, EventArgs e)
        {
            if (button7.Visible == true)
            {
                PickedID = (int)dgWP.SelectedRows[0].Cells["ID"].Value;
                Close();
            }

        }

        private void button8_Click(object sender, EventArgs e)
        {
            int id = (int)cbCAT.SelectedValue;
            if ((id == 1) || (id == 2))
            {
                MessageBox.Show("У выбранной категории не может быть подкатегорий, т.к. она является системной");
                return;
            }
            EditWPSubCategory ed = new EditWPSubCategory(id);
            ed.ShowDialog();
            dgWP.DataSource = new DBWPName().GetAllWPNames();

        }
        private void cbCAT_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((Convert.ToInt32(cbCAT.SelectedValue) == 1) || (Convert.ToInt32(cbCAT.SelectedValue) == 2))
            {
                cbSubCat.Text = "";
                cbSubCat.Enabled = false;
            }
            else
            {
                cbSubCat.Enabled = true;
                DBSubCategory dbs = new DBSubCategory();
                cbSubCat.ValueMember = "ID";
                cbSubCat.DisplayMember = "SUBCATNAME";
                cbSubCat.DataSource = dbs.GetAll(Convert.ToInt32(cbCAT.SelectedValue));
                cbSubCat.SelectedItem = cbCAT.Items[0];
            }
            if (cbSubCat.Enabled)
            {
                dgWP.DataSource = new DBWPName().GetCategoryWPNames(Convert.ToInt32(cbCAT.SelectedValue), Convert.ToInt32(cbSubCat.SelectedValue));
            }
            else
            {
                dgWP.DataSource = new DBWPName().GetCategoryWPNames(Convert.ToInt32(cbCAT.SelectedValue));
            }

        }
        private void cbSubCat_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgWP.DataSource = new DBWPName().GetCategoryWPNames(Convert.ToInt32(cbCAT.SelectedValue), Convert.ToInt32(cbSubCat.SelectedValue));

        }



    }
}
