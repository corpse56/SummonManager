﻿using System;
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
                //cbPRODUCTTYPE.Enabled = false;
                cbPRODUCTTYPE.SelectedIndex = 0;
            }
            if (WPT == WPTYPE.ZHGUTLIST)
            {
                //cbPRODUCTTYPE.Enabled = false;
                cbPRODUCTTYPE.SelectedIndex = 1;
            }
            if (WPT == WPTYPE.CABLELIST)
            {
                //cbPRODUCTTYPE.Enabled = false;
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
                //cbPRODUCTTYPE.Enabled = false;
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
            if (cbPRODUCTTYPE.SelectedIndex == 0)
            {
                NewWPN nwp = new NewWPN(null, "NEW", UVO);
                nwp.ShowDialog();
            }
            if (cbPRODUCTTYPE.SelectedIndex == 1)
            {
                NewZHGUT nwp = new NewZHGUT(null, "NEW", UVO);//zhguts
                nwp.ShowDialog();
            }
            if (cbPRODUCTTYPE.SelectedIndex == 2)
            {
                NewCABLE nwp = new NewCABLE(null, "NEW", UVO);//cables
                nwp.ShowDialog();
            }

            int idsub = (cbSubCat.SelectedValue != null) ? (int)cbSubCat.SelectedValue : 0;
            cbCAT_SelectedIndexChanged(sender, e);
            cbSubCat.SelectedValue = idsub;

            //MessageBox.Show("Успешно добавлено!");
        }

        private void bEdit_Click(object sender, EventArgs e)//редактировать
        {
            if (cbPRODUCTTYPE.SelectedIndex == 0)
            {
                NewWPN ew = new NewWPN(WPNameVO.WPNameVOByID(Convert.ToInt32(dgWP.SelectedRows[0].Cells["ID"].Value)), "EDIT", UVO);
                ew.ShowDialog();
            }
            if (cbPRODUCTTYPE.SelectedIndex == 1)
            {
                NewZHGUT ew = new NewZHGUT(ZhgutVO.GetZhgutVOByID(Convert.ToInt32(dgWP.SelectedRows[0].Cells["ID"].Value)), "EDIT", UVO);
                ew.ShowDialog();
            }
            if (cbPRODUCTTYPE.SelectedIndex == 2)
            {
                NewCABLE ew = new NewCABLE(CableVO.GetCableVOByID(Convert.ToInt32(dgWP.SelectedRows[0].Cells["ID"].Value)), "EDIT", UVO);
                ew.ShowDialog();
            }
            int idsub = (cbSubCat.SelectedValue != null) ? (int)cbSubCat.SelectedValue : 0;
            cbCAT_SelectedIndexChanged(sender, e);
            cbSubCat.SelectedValue = idsub;

        }

        private void bClone_Click(object sender, EventArgs e)//клонировать
        {
            if (cbPRODUCTTYPE.SelectedIndex == 0)
            {
                NewWPN ew = new NewWPN(WPNameVO.WPNameVOByID(Convert.ToInt32(dgWP.SelectedRows[0].Cells["ID"].Value)), "NEWCLONE", UVO);
                ew.ShowDialog();
            }
            if (cbPRODUCTTYPE.SelectedIndex == 1)
            {
                NewZHGUT ew = new NewZHGUT(ZhgutVO.GetZhgutVOByID(Convert.ToInt32(dgWP.SelectedRows[0].Cells["ID"].Value)), "NEWCLONE", UVO);
                ew.ShowDialog();
            }
            if (cbPRODUCTTYPE.SelectedIndex == 2)
            {
                NewCABLE ew = new NewCABLE(CableVO.GetCableVOByID(Convert.ToInt32(dgWP.SelectedRows[0].Cells["ID"].Value)), "NEWCLONE", UVO);
                ew.ShowDialog();
            }

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
            if (cbPRODUCTTYPE.SelectedIndex == 0)
            {
                DBWPName dbwp = new DBWPName();
                if (dbwp.Exists(dgWP.SelectedRows[0].Cells["ID"].Value.ToString()))
                {
                    MessageBox.Show("Вы не можете удалить это наименование поскольку существует извещение с таким наименованием!");
                    return;
                }
                dbwp.DeleteByID(dgWP.SelectedRows[0].Cells["ID"].Value.ToString());
            }
            if (cbPRODUCTTYPE.SelectedIndex == 1)
            {
                DBZhgutList dbwp = new DBZhgutList();
                if (dbwp.Exists(dgWP.SelectedRows[0].Cells["ID"].Value.ToString()))
                {
                    MessageBox.Show("Вы не можете удалить это наименование поскольку существует извещение с таким наименованием!");
                    return;
                }
                dbwp.DeleteByID(dgWP.SelectedRows[0].Cells["ID"].Value.ToString());
            }
            if (cbPRODUCTTYPE.SelectedIndex == 2)
            {
                DBCableList dbwp = new DBCableList();
                if (dbwp.Exists(dgWP.SelectedRows[0].Cells["ID"].Value.ToString()))
                {
                    MessageBox.Show("Вы не можете удалить это наименование поскольку существует извещение с таким наименованием!");
                    return;
                }
                dbwp.DeleteByID(dgWP.SelectedRows[0].Cells["ID"].Value.ToString());
            }


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
                bChoose.Enabled = false;

                if ((UVO.Role == Roles.Admin) || (UVO.Role == Roles.Inzhener))
                {
                    bAdd.Enabled = true;
                    bEdit.Enabled = true;
                    bClone.Enabled = true;
                    bDelete.Enabled = true;
                    bEditCategory.Enabled = true;
                    bEditSubCategory.Enabled = true;
                    bView.Enabled = true;
                }
                else if ((UVO.Role == Roles.Constructor) || /*(UVO.Role == Roles.Tehnolog) ||*/ (UVO.Role == Roles.Shemotehnik) || (UVO.Role == Roles.SimpleInzhener))
                {
                    bAdd.Enabled = false;
                    bEdit.Enabled = true;
                    bClone.Enabled = false;
                    bDelete.Enabled = false;
                    bArchive.Enabled = false;
                    bArcShow.Enabled = false;
                    bEditCategory.Enabled = false;
                    bEditSubCategory.Enabled = false;
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
                    bEditCategory.Enabled = false;
                    bEditSubCategory.Enabled = false;
                    bView.Enabled = true;
                }
            }


        }

        private void ShowDGV()
        {
            dgWP.Columns["ID"].Visible = false;
            dgWP.Columns["CATEGORYNAME"].HeaderText = "Категория";
            dgWP.Columns["SUBCATNAME"].HeaderText = "Подкатегория";
            dgWP.Columns["DECNUM"].HeaderText = "Децимальный номер";
            dgWP.Columns["NOTE"].HeaderText = "Примечание";
            dgWP.Columns["SUBCATNAME"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgWP.Columns["CATEGORYNAME"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgWP.Columns["DECNUM"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgWP.Columns["NOTE"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgWP.Columns["CATEGORYNAME"].FillWeight = 100;
            dgWP.Columns["SUBCATNAME"].FillWeight = 100;
            dgWP.Columns["DECNUM"].FillWeight = 200;
            dgWP.Columns["NOTE"].FillWeight = 200;

        }
        private void ShowDGV_WPNAME()
        {
            ShowDGV();
            dgWP.Columns["WPNAME"].HeaderText = "Наименование изделия";
            dgWP.Columns["COMPOSITION"].HeaderText = "Состав изделия";
            dgWP.Columns["TECHREQ"].HeaderText = "Технические требования";
            foreach (DataGridViewRow r in dgWP.Rows)
            {
                r.Cells["COMPOSITION"].Tag = r.Cells["COMPOSITION"].Value;
                r.Cells["COMPOSITION"].Value = r.Cells["COMPOSITION"].Tag.ToString().Substring(r.Cells["COMPOSITION"].Tag.ToString().LastIndexOf("\\") + 1);
                r.Cells["TECHREQ"].Tag = r.Cells["TECHREQ"].Value;
                r.Cells["TECHREQ"].Value = r.Cells["TECHREQ"].Tag.ToString().Substring(r.Cells["TECHREQ"].Tag.ToString().LastIndexOf("\\") + 1);
            }
            dgWP.Columns["WPNAME"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgWP.Columns["COMPOSITION"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgWP.Columns["TECHREQ"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgWP.Columns["WPNAME"].FillWeight = 250;
            dgWP.Columns["COMPOSITION"].FillWeight = 200;
            dgWP.Columns["TECHREQ"].FillWeight = 200;
        }
        private void ShowDGV_ZHGUT()
        {
            ShowDGV();
            dgWP.Columns["ZHGUTNAME"].HeaderText = "Наименование жгута";
            dgWP.Columns["ZHGUTPATH"].HeaderText = "Жгут изготовление";
            foreach (DataGridViewRow r in dgWP.Rows)
            {
                r.Cells["ZHGUTPATH"].Tag = r.Cells["ZHGUTPATH"].Value;
                r.Cells["ZHGUTPATH"].Value = r.Cells["ZHGUTPATH"].Tag.ToString().Substring(r.Cells["ZHGUTPATH"].Tag.ToString().LastIndexOf("\\") + 1);
            }
            dgWP.Columns["ZHGUTNAME"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgWP.Columns["ZHGUTPATH"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgWP.Columns["ZHGUTNAME"].FillWeight = 250;
            dgWP.Columns["ZHGUTPATH"].FillWeight = 250;
        }
        private void ShowDGV_CABLE()
        {
            ShowDGV();
            dgWP.Columns["CABLENAME"].HeaderText = "Наименование кабеля";
            dgWP.Columns["DIMENSIONALDRAWING"].HeaderText = "Сборочный чертёж";
            dgWP.Columns["CONNECTORS"].HeaderText = "Соединители";
            dgWP.Columns["CLENGTH"].HeaderText = "Длина";

            foreach (DataGridViewRow r in dgWP.Rows)
            {
                r.Cells["DIMENSIONALDRAWING"].Tag = r.Cells["DIMENSIONALDRAWING"].Value;
                r.Cells["DIMENSIONALDRAWING"].Value = r.Cells["DIMENSIONALDRAWING"].Tag.ToString().Substring(r.Cells["DIMENSIONALDRAWING"].Tag.ToString().LastIndexOf("\\") + 1);
            }
            dgWP.Columns["CONNECTORS"].FillWeight = 150;
            dgWP.Columns["CLENGTH"].FillWeight = 70;
            dgWP.Columns["CABLENAME"].FillWeight = 250;
            dgWP.Columns["DIMENSIONALDRAWING"].FillWeight = 250;
            dgWP.Columns["CABLENAME"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgWP.Columns["DIMENSIONALDRAWING"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgWP.Columns["CONNECTORS"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgWP.Columns["CLENGTH"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

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
            string Entity="";
            if (cbPRODUCTTYPE.SelectedIndex == 0)
            {
                Entity = "WPNAMELIST";
            }
            if (cbPRODUCTTYPE.SelectedIndex == 1)
            {
                Entity = "ZHGUTLIST";
            }
            if (cbPRODUCTTYPE.SelectedIndex == 2)
            {
                Entity = "CABLELIST";
            }

            int selval = (int)cbCAT.SelectedValue;
            EditWPCategory ed = new EditWPCategory(Entity);
            ed.ShowDialog();
            DBCategory dbc = new DBCategory(Entity);
            cbCAT.ValueMember = "ID";
            cbCAT.DisplayMember = "CATEGORYNAME";
            cbCAT.DataSource = dbc.GetAll();
            cbCAT.SelectedValue = selval;
            cbCAT_SelectedIndexChanged(sender, e);

        }
        private void bEditSubCategory_Click(object sender, EventArgs e)//редактирование подкатегорий
        {
            int id = (int)cbCAT.SelectedValue;
            if ((cbCAT.Text.ToUpper() == "ВСЕ") || (cbCAT.Text.ToUpper() == "НЕ ПРИСВОЕНО"))
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
        public int PickedID;
        public WPTYPE PickedType;
        private void bChoose_Click(object sender, EventArgs e)//Выбрать
        {
            if (dgWP.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите изделие!");
                return;
            }
            PickedID = (int)dgWP.SelectedRows[0].Cells["ID"].Value;
            if (cbPRODUCTTYPE.SelectedIndex == 0)
            {
                PickedType = WPTYPE.WPNAMELIST;
            }
            if (cbPRODUCTTYPE.SelectedIndex == 1)
            {
                PickedType = WPTYPE.ZHGUTLIST;
            }
            if (cbPRODUCTTYPE.SelectedIndex == 2)
            {
                PickedType = WPTYPE.CABLELIST;
            }

            Close();
        }

        private void dgWP_DoubleClick(object sender, EventArgs e)
        {
            if (PICK == true)
            {
                if (dgWP.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Выберите изделие!");
                    return;
                }
                PickedID = (int)dgWP.SelectedRows[0].Cells["ID"].Value;
                if (cbPRODUCTTYPE.SelectedIndex == 0)
                {
                    PickedType = WPTYPE.WPNAMELIST;
                }
                if (cbPRODUCTTYPE.SelectedIndex == 1)
                {
                    PickedType = WPTYPE.ZHGUTLIST;
                }
                if (cbPRODUCTTYPE.SelectedIndex == 2)
                {
                    PickedType = WPTYPE.CABLELIST;
                }

                Close();
            }

        }

       
        private void cbPRODUCTTYPE_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbPRODUCTTYPE.SelectedIndex == 0) //"WPNAMELIST"
            {
                DBCategory dbc = new DBCategory("WPNAMELIST");
                cbCAT.ValueMember = "ID";
                cbCAT.DisplayMember = "CATEGORYNAME";
                cbCAT.DataSource = dbc.GetAll();
                //cbCAT.SelectedValue = dbc.GetSubCatNE_PRISVOENO();
                cbCAT.SelectedIndex = 1;
                FillDGV_WPNAMELIST();

            }
            if (cbPRODUCTTYPE.SelectedIndex == 1) //"ZHGUTLIST"
            {
                DBCategory dbc = new DBCategory("ZHGUTLIST");
                cbCAT.ValueMember = "ID";
                cbCAT.DisplayMember = "CATEGORYNAME";
                cbCAT.DataSource = dbc.GetAll();
                //cbCAT.SelectedValue = 2;
                cbCAT.SelectedIndex = 1;
                FillDGV_ZHGUTLIST();

            }
            if (cbPRODUCTTYPE.SelectedIndex == 2) //"CABLELIST"
            {
                DBCategory dbc = new DBCategory("CABLELIST");
                cbCAT.ValueMember = "ID";
                cbCAT.DisplayMember = "CATEGORYNAME";
                cbCAT.DataSource = dbc.GetAll();
                //cbCAT.SelectedValue = 2;
                cbCAT.SelectedIndex = 1;
                FillDGV_CABLELIST();

            }
            

        }
        private void cbCAT_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((cbCAT.Text.ToUpper() == "ВСЕ") || (cbCAT.Text.ToUpper() == "НЕ ПРИСВОЕНО"))
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
                //cbSubCat.SelectedItem = cbCAT.Items[0];
                cbSubCat.SelectedIndex = 1;
            }
            switch (cbPRODUCTTYPE.SelectedIndex)
            {
                case 0://wpname
                    FillDGV_WPNAMELIST();
                    break;
                case 1://zhgut
                    FillDGV_ZHGUTLIST();
                    break;
                case 2://cable
                    FillDGV_CABLELIST();
                    break;
            }

        }
        private void cbSubCat_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbPRODUCTTYPE.SelectedIndex)
            {
                case 0://wpname
                    dgWP.DataSource = new DBWPName().GetCategoryWPNames(Convert.ToInt32(cbCAT.SelectedValue), Convert.ToInt32(cbSubCat.SelectedValue));
                    break;
                case 1://zhgut
                    dgWP.DataSource = new DBZhgutList().GetCategoryZhgutList(Convert.ToInt32(cbCAT.SelectedValue), Convert.ToInt32(cbSubCat.SelectedValue));
                    break;
                case 2://cable
                    dgWP.DataSource = new DBCableList().GetCategoryCableList(Convert.ToInt32(cbCAT.SelectedValue), Convert.ToInt32(cbSubCat.SelectedValue));
                    break;
            }
            

        }

        private void bView_Click(object sender, EventArgs e)//просмотр
        {
            if (dgWP.SelectedRows.Count == 0)
            {
                return;
            }
            if (cbPRODUCTTYPE.SelectedIndex == 0)
            {
                NewWPN ew = new NewWPN(WPNameVO.WPNameVOByID(Convert.ToInt32(dgWP.SelectedRows[0].Cells["ID"].Value)), "VIEWONLY", UVO);
                ew.ShowDialog();
            }
            if (cbPRODUCTTYPE.SelectedIndex == 1)
            {
                NewZHGUT ew = new NewZHGUT(ZhgutVO.GetZhgutVOByID(Convert.ToInt32(dgWP.SelectedRows[0].Cells["ID"].Value)), "VIEWONLY", UVO);
                ew.ShowDialog();
            }
            if (cbPRODUCTTYPE.SelectedIndex == 2)
            {
                NewCABLE ew = new NewCABLE(CableVO.GetCableVOByID(Convert.ToInt32(dgWP.SelectedRows[0].Cells["ID"].Value)), "VIEWONLY", UVO);
                ew.ShowDialog();
            }
        }

        private void FillDGV_WPNAMELIST()
        {
            if (cbSubCat.Enabled)
            {
                dgWP.DataSource = new DBWPName().GetCategoryWPNames(Convert.ToInt32(cbCAT.SelectedValue), Convert.ToInt32(cbSubCat.SelectedValue));
            }
            else
            {
                dgWP.DataSource = new DBWPName().GetCategoryWPNames(Convert.ToInt32(cbCAT.SelectedValue));
            }
            ShowDGV_WPNAME();
        }
        private void FillDGV_ZHGUTLIST()
        {           
            if (cbSubCat.Enabled)
            {
                dgWP.DataSource = new DBZhgutList().GetCategoryZhgutList(Convert.ToInt32(cbCAT.SelectedValue), Convert.ToInt32(cbSubCat.SelectedValue));
            }
            else
            {
                dgWP.DataSource = new DBZhgutList().GetCategoryZhgutList(Convert.ToInt32(cbCAT.SelectedValue));
            }
            ShowDGV_ZHGUT();
        }
        private void FillDGV_CABLELIST()
        {
            if (cbSubCat.Enabled)
            {
                dgWP.DataSource = new DBCableList().GetCategoryCableList(Convert.ToInt32(cbCAT.SelectedValue), Convert.ToInt32(cbSubCat.SelectedValue));
            }
            else
            {
                dgWP.DataSource = new DBCableList().GetCategoryCableList(Convert.ToInt32(cbCAT.SelectedValue));
            }
            ShowDGV_CABLE();
        }

        private void dgWP_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (PICK)
            {
                bChoose_Click(sender ,e);
            }
            else
            {
                bEdit_Click(sender, e);
            }
        }




    }
}
