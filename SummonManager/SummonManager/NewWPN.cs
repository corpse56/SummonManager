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
    public partial class NewWPN : Form
    {
        public NewWPN()
        {
            InitializeComponent();
            pfComposition.Init("",false,true,false);
            pfDimDrawing.Init("", false, true, false);
        }
        WPNameVO Clone;
        public NewWPN(WPNameVO clone)
        {
            InitializeComponent();
            if (clone.WPName != "")
            {
                this.Clone = clone;
                tbName.Text = clone.WPName;
                cbCategory.SelectedValue = clone.IDCat;
                cbSubCategory.SelectedValue = clone.IDSubCat;
                tbDecNum.Text = clone.DecNum;
                tbPowerSupply.Text = clone.PowerSupply;
                //tbConfiguration.Text = clone.Configuration;
                tbNote.Text = clone.Note;


                pfComposition.Init(clone.COMPOSITION, false, true, false);
                pfDimDrawing.Init(clone.DIMENDRAWING, false, true, false);

            }

        }
        private string AccessMode = "NEW";//NEW - форма переделывается под добавление нового изделия; EDIT - форма переделывается под редактирование
        public NewWPN(WPNameVO wp,string _accessmode)
        {
            InitializeComponent();
            this.AccessMode = _accessmode;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (AccessMode == "NEW")//вставляем
            {
                if (tbName.Text == "")
                {
                    MessageBox.Show("Введите наименование!");
                    return;
                }
                WPNameVO wp = new WPNameVO();
                wp.WPType = WPTYPE.WPNAMELIST;
                //wp.ID = (int)r["ID"];
                wp.WPName = tbName.Text;
                wp.IDCat = Convert.ToInt32(cbCategory.SelectedValue);
                wp.IDSubCat = (cbSubCategory.SelectedValue == null) ? 0 : (int)cbSubCategory.SelectedValue;
                wp.DecNum = tbDecNum.Text;
                wp.WIRINGDIAGRAM = (pfWIRINGDIAGRAM.FullPath == "<нет>") ? null : pfWIRINGDIAGRAM.FullPath;
                wp.TECHREQ = (pfTECHREQ.FullPath == "<нет>") ? null : pfTECHREQ.FullPath;
                wp.COMPOSITION = (pfComposition.FullPath == "<нет>") ? null : pfComposition.FullPath;
                wp.CONFIGURATION = (pfCONFIGURATION.FullPath == "<нет>") ? null : pfCONFIGURATION.FullPath;
                wp.DIMENDRAWING = (pfDimDrawing.FullPath == "<нет>") ? null : pfDimDrawing.FullPath; ;
                wp.SBORKA3D = (pf3DSBORKA.FullPath == "<нет>") ? null : pf3DSBORKA.FullPath;
                wp.MECHPARTS = (pfMECHPARTS.FullPath == "<нет>") ? null : pfMECHPARTS.FullPath;
                wp.ZHGUTS = new DBZhgutList().GetPackageForVO(wp.ID);
                wp.CABLES = new DBCableList().GetPackageForVO(wp.ID);
                wp.SHILDS = (pfSHILDS.FullPath == "<нет>") ? null : pfSHILDS.FullPath;
                wp.PLANKA = (pfPLANKA.FullPath == "<нет>") ? null : pfPLANKA.FullPath;
                wp.SERIAL = (pfSERIAL.FullPath == "<нет>") ? null : pfSERIAL.FullPath;
                wp.PACKAGING = (pfPACKAGING.FullPath == "<нет>") ? null : pfPACKAGING.FullPath;
                wp.PASSPORT = (pfPASSPORT.FullPath == "<нет>") ? null : pfPASSPORT.FullPath;
                wp.MANUAL = (pfMANUAL.FullPath == "<нет>") ? null : pfMANUAL.FullPath;
                wp.PACKINGLIST = (pfPACKINGLIST.FullPath == "<нет>") ? null : pfPACKINGLIST.FullPath; r["MANUAL"].ToString();
                wp.PowerSupply = tbPowerSupply.Text;
                wp.Note = tbNote.Text;
                
                DBWPName dbwp = new DBWPName();
                dbwp.AddNewWP(wp);
                MessageBox.Show("Наименование успешно добавлено!");
                Close();
            }
            if (AccessMode == "EDIT")//редактируем
            {

            }
        }

        private void NewWPN_Load(object sender, EventArgs e)
        {
            DBCategory dbc = new DBCategory("WPNAMELIST");
            cbCategory.ValueMember = "ID";
            cbCategory.DisplayMember = "CATEGORYNAME";
            cbCategory.DataSource = dbc.GetAllExceptAll();

            if (Clone.IDCat != 0)
            {
                cbCategory.SelectedValue = Clone.IDCat;
            }
            else
            {
                cbCategory.SelectedValue = 1;
            }

            LoadSubs((int)cbCategory.SelectedValue);



        }
        private void LoadSubs(int idCat)
        {
            if ((idCat == 1) || (idCat == 2))
            {
                cbSubCategory.Text = "";
                cbSubCategory.Enabled = false;
            }
            else
            {
                cbSubCategory.Enabled = true;
                DBSubCategory dbs = new DBSubCategory();
                cbSubCategory.ValueMember = "ID";
                cbSubCategory.DisplayMember = "SUBCATNAME";
                cbSubCategory.DataSource = dbs.GetAllExceptAll(idCat);
                cbSubCategory.SelectedValue = Clone.IDSubCat;
            }
        }
        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSubs((int)cbCategory.SelectedValue);
        }

        private void cbSubCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
