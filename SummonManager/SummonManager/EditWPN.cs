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
    public partial class EditWPN : Form
    {
        int IDW;
        bool viewonly = false;
        public EditWPN(int idw,bool viewOnly)
        {
            InitializeComponent();
            if (viewOnly)
            {
                this.viewonly = viewOnly;
                button2.Visible = false;
                pfComposition.bPath.Enabled = false;
                pfComposition.bPathDel.Enabled = false;
                pfDimDrawing.bPath.Enabled = false;
                pfDimDrawing.bPathDel.Enabled = false;
                this.Text = "Просмотр сведений об изделии";
                tbName.ReadOnly = true;
                tbNote.ReadOnly = true;
                tbPowerSupply.ReadOnly = true;
                tbDecNum.ReadOnly = true;
                tbConfiguration.ReadOnly = true;
                cbCategory.Enabled = false;
                cbSubCategory.Enabled = false;
            }
            this.IDW = idw;
            DBWPName dbwp = new DBWPName();
            WPNameVO wp = dbwp.GetWP(this.IDW);
            tbName.Text = wp.WPName;
            cbCategory.SelectedValue = wp.IDCat;
            cbSubCategory.SelectedValue = wp.IDSubCat;
            tbDecNum.Text = wp.DecNum;
            tbPowerSupply.Text = wp.PowerSupply;
            tbConfiguration.Text = wp.Configuration;
            tbNote.Text = wp.Note;
            

            pfComposition.tbPath.Text = wp.Composition.Substring(wp.Composition.LastIndexOf("\\") + 1);
            pfComposition.tbPath.Tag = wp.Composition;

            pfDimDrawing.tbPath.Text = wp.DimenDrawing.Substring(wp.DimenDrawing.LastIndexOf("\\") + 1);
            pfDimDrawing.tbPath.Tag = wp.DimenDrawing;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (tbName.Text == "")
            {
                MessageBox.Show("Введите наименование!");
                return;
            }

            DBWPName dbwp = new DBWPName();
            WPNameVO wp = new WPNameVO();
            wp.WPName = tbName.Text;
            wp.IDCat = Convert.ToInt32(cbCategory.SelectedValue);
            wp.IDSubCat = Convert.ToInt32(cbSubCategory.SelectedValue);
            wp.DecNum = tbDecNum.Text;
            wp.Composition = pfComposition.tbPath.Tag.ToString();
            wp.DimenDrawing = pfDimDrawing.tbPath.Tag.ToString();
            wp.PowerSupply = tbPowerSupply.Text;
            wp.Configuration = tbConfiguration.Text;
            wp.Note = tbNote.Text;
            wp.ID = this.IDW;
            dbwp.EditWP(wp);
            MessageBox.Show("Наименование успешно изменено!");
            Close();
        }

        private void EditWPN_Load(object sender, EventArgs e)
        {
            DBCategory dbc = new DBCategory();
            cbCategory.ValueMember = "ID";
            cbCategory.DisplayMember = "CATEGORYNAME";
            cbCategory.DataSource = dbc.GetAllExceptAll();

            DBWPName dbwp = new DBWPName();
            WPNameVO wp = dbwp.GetWP(this.IDW);

            cbCategory.SelectedValue = wp.IDCat;

            LoadSubs((int)cbCategory.SelectedValue);


        }
        private void LoadSubs(int idCat)
        {
            if ((idCat == 1) || (idCat == 2))
            {
                cbSubCategory.Text = "";
                cbSubCategory.Enabled = false;
            }
            if (!viewonly)
            {
                cbSubCategory.Enabled = true;
            }
            DBSubCategory dbs = new DBSubCategory();
            cbSubCategory.ValueMember = "ID";
            cbSubCategory.DisplayMember = "SUBCATNAME";
            cbSubCategory.DataSource = dbs.GetAllExceptAll(idCat);

            DBWPName dbwp = new DBWPName();
            WPNameVO wp = dbwp.GetWP(this.IDW);
            cbSubCategory.SelectedValue = wp.IDSubCat;
            
        }

        private void bComposition_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "All files (*.*)|*.*";
            //dialog.InitialDirectory = @"\\10.177.150.135\server\поездки\карта";
            dialog.InitialDirectory = @"c:\";
            dialog.Title = "Выберите файл";
            dialog.Multiselect = false;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                pfComposition.tbPath.Text = dialog.FileName.Substring(dialog.FileName.LastIndexOf(@"\") + 1); ;
                pfComposition.tbPath.Tag = dialog.FileName;
            }
        }

        private void bDimDrawing_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "All files (*.*)|*.*";
            //dialog.InitialDirectory = @"\\10.177.150.135\server\поездки\карта";
            dialog.InitialDirectory = @"c:\";
            dialog.Title = "Выберите файл";
            dialog.Multiselect = false;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                pfDimDrawing.tbPath.Text = dialog.FileName.Substring(dialog.FileName.LastIndexOf(@"\") + 1); ;
                pfDimDrawing.tbPath.Tag = dialog.FileName;
            }
        }

        private void bCompositionDel_Click(object sender, EventArgs e)
        {
            pfComposition.tbPath.Tag = "";
            pfComposition.tbPath.Text = "";

        }

        private void bDimDrawingDel_Click(object sender, EventArgs e)
        {
            pfDimDrawing.tbPath.Tag = "";
            pfDimDrawing.tbPath.Text = "";
            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSubs((int)cbCategory.SelectedValue);

        }




    }
}
