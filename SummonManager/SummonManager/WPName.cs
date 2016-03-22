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
        UserVO UVO;
        bool PICK = false;
        WPTYPE WPT;
        public WPName(bool pick,UserVO uvo,WPTYPE wpt)
        {
            InitializeComponent();
            this.WPT = wpt;

            if (WPT == WPTYPE.WPNAMELIST)
            {
                cbPRODUCTTYPE.ReadOnly = false;
                cbPRODUCTTYPE.SelectedIndex = 0;

            }
            if (WPT == WPTYPE.ZHGUTLIST)
            {
                cbPRODUCTTYPE.ReadOnly = true;
                cbPRODUCTTYPE.SelectedIndex = 1;
            }
            if (WPT == WPTYPE.CABLELIST)
            {
                cbPRODUCTTYPE.ReadOnly = true;
                cbPRODUCTTYPE.SelectedIndex = 2;
            }

            if (pick)
            {
                bChoose.Visible = true;
                bAdd.Visible = false;
                bEdit.Visible = false;
                bClone.Visible = false;
                bDelete.Visible = false;
                bEditCategory.Visible = false;
                bEditSubCategory.Visible = false;
                bArchive.Visible = false;
                bArcShow.Visible = false;
                cbPRODUCTTYPE.Enabled = false;
            }
            else
            {
                bChoose.Visible = false;
            }
            this.UVO = uvo;
            this.PICK = pick;
        }

        private void bClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bAdd_Click(object sender, EventArgs e)//добавить
        {
            NewWPN nwp = new NewWPN(null,"NEW",UVO);
            nwp.ShowDialog();
            DBWPName dbwp = new DBWPName();
            int idsub = (cbSubCat.SelectedValue != null) ? (int)cbSubCat.SelectedValue : 0;
            cbCAT_SelectedIndexChanged(sender, e);
            cbSubCat.SelectedValue = idsub;

        }

        private void bEdit_Click(object sender, EventArgs e)//редактировать
        {
            
            NewWPN ew = new NewWPN(WPNameVO.WPNameVOByID(Convert.ToInt32(dgWP.SelectedRows[0].Cells["ID"].Value)),"EDIT",UVO);
            ew.ShowDialog();
            //DBWPName dbwp = new DBWPName();
            //dgWP.DataSource = dbwp.GetAllWPNames();
            int idsub = (cbSubCat.SelectedValue != null)? (int)cbSubCat.SelectedValue : 0;
            cbCAT_SelectedIndexChanged(sender, e);
            cbSubCat.SelectedValue = idsub;

        }

        private void bClone_Click(object sender, EventArgs e)//клонировать
        {
            WPNameVO wp = WPNameVO.WPNameVOByID(Convert.ToInt32(dgWP.SelectedRows[0].Cells["ID"].Value));
            NewWPN nwp = new NewWPN(wp,"NEWCLONE",UVO);
            nwp.ShowDialog();
            int idsub = (cbSubCat.SelectedValue != null) ? (int)cbSubCat.SelectedValue : 0;
            cbCAT_SelectedIndexChanged(sender, e);
            cbSubCat.SelectedValue = idsub;

        }

        private void bDelete_Click(object sender, EventArgs e)//удалить
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
            cbCAT_SelectedIndexChanged(sender, e);
        }

        private void WPName_Load(object sender, EventArgs e)
        {
            DBCategory dbc = new DBCategory("WPNAMELIST");
            cbCAT.ValueMember = "ID";
            cbCAT.DisplayMember = "CATEGORYNAME";
            cbCAT.DataSource = dbc.GetAll();
            cbCAT.SelectedValue = 2;

            DBWPName dbwp = new DBWPName();
            dgWP.DataSource = dbwp.GetAllWPNames();
            ShowDGV();
            if (!PICK)
            {
                if ((UVO.Role == Roles.Admin) || (UVO.Role == Roles.Inzhener))
                {
                    bAdd.Enabled = true;
                    bEdit.Enabled = true;
                    bClone.Enabled = true;
                    bDelete.Enabled = true;
                    bChoose.Enabled = false;
                    bEditCategory.Enabled = true;
                    bEditSubCategory.Enabled = true;
                    bView.Enabled = true;
                }
                else
                {
                    bAdd.Enabled = false;
                    bEdit.Enabled = false;
                    bClone.Enabled = false;
                    bDelete.Enabled = false;
                    bArchive.Enabled = false;
                    bArcShow.Enabled = false;
                    bChoose.Enabled = false;
                    bEditCategory.Enabled = false;
                    bEditSubCategory.Enabled = false;
                    bView.Enabled = true;
                }
            }


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
                WPNameVO wpVO = WPNameVO.WPNameVOByID((int)dgWP.SelectedRows[0].Cells["ID"].Value);
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

        private void bEditCategory_Click(object sender, EventArgs e)//редактировать категории
        {
            int selval = (int)cbCAT.SelectedValue;
            EditWPCategory ed = new EditWPCategory("WPNAMELIST");
            ed.ShowDialog();
            DBCategory dbc = new DBCategory("WPNAMELIST");
            cbCAT.ValueMember = "ID";
            cbCAT.DisplayMember = "CATEGORYNAME";
            cbCAT.DataSource = dbc.GetAll();
            cbCAT.SelectedValue = selval;
            cbCAT_SelectedIndexChanged(sender, e);

        }
        public int PickedID;
        private void bChoose_Click(object sender, EventArgs e)//Выбрать
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
            if (bChoose.Visible == true)
            {
                PickedID = (int)dgWP.SelectedRows[0].Cells["ID"].Value;
                Close();
            }

        }

        private void bEditSubCategory_Click(object sender, EventArgs e)//редактирование подкатегорий
        {
            int id = (int)cbCAT.SelectedValue;
            if ((id == 1) || (id == 2))
            {
                MessageBox.Show("У выбранной категории не может быть подкатегорий, т.к. она является системной");
                return;
            }
            EditWPSubCategory ed = new EditWPSubCategory(id, "WPNAMELIST");
            ed.ShowDialog();
            //dgWP.DataSource = new DBWPName().GetAllWPNames();
            int idsub = (cbSubCat.SelectedValue != null) ? (int)cbSubCat.SelectedValue : 0;
            cbCAT_SelectedIndexChanged(sender, e);
            cbSubCat.SelectedValue = idsub;

        }
        private void cbPRODUCTTYPE_SelectedIndexChanged(object sender, EventArgs e)
        {

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

        private void bView_Click(object sender, EventArgs e)//просмотр
        {
            NewWPN ew = new NewWPN(WPNameVO.WPNameVOByID(Convert.ToInt32(dgWP.SelectedRows[0].Cells["ID"].Value)), "VIEWONLY", UVO);
            ew.ShowDialog();

        }





    }
}
