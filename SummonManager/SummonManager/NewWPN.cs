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
        WPNameVO Clone,EditWP;
        //ACCESSMODE: NEW,NEWCLONE,EDIT
        //NEW - форма переделывается под добавление нового изделия; EDIT - форма переделывается под редактирование; NEWCLONE - добавление на основе существующего
        private string AccessMode = "NEW";

        UserVO UVO;
        bool RequireVisible = false;


        public NewWPN(WPNameVO wp, string accessmode_,UserVO uvo)
        {
            this.AccessMode = accessmode_;
            this.UVO = uvo;
            RequireVisible = ((UVO.Role == Roles.Inzhener) || (UVO.Role == Roles.Admin)) ? true : false;

            if (AccessMode == "NEW")
            {
                InitNEW();
                this.Text = "Создание нового изделия";
                
            }
            if (AccessMode == "NEWCLONE")
            {
                InitNEWCLONE(wp);
                this.Text = "Создание нового изделия на основе существующего";
            }
            if (AccessMode == "EDIT")
            {
                InitEDIT(wp);
                this.Text = "Редактирование изделия";
            }
            if (AccessMode == "VIEWONLY")
            {
                InitVIEWONLY(wp);
                this.Text = "Просмотр сведений об изделии";
                button2.Visible = false;
            }

            InitializeComponent();

        }

        private void InitVIEWONLY(WPNameVO wp)
        {
            RequireVisible = false;
            tbName.Text = wp.WPName;
            cbCategory.SelectedValue = wp.IDCat;
            cbSubCategory.SelectedValue = wp.IDSubCat;
            tbDecNum.Text = wp.DecNum;
            tbPowerSupply.Text = wp.PowerSupply;
            tbNote.Text = wp.Note;

            pfWIRINGDIAGRAM.Init(wp.WIRINGDIAGRAM, wp.WIRINGDIAGRAMREQ, false, RequireVisible);
            pfTECHREQ.Init(wp.TECHREQ, wp.TECHREQREQ, false, RequireVisible);
            pfComposition.Init(wp.COMPOSITION, wp.COMPOSITIONREQ, false, RequireVisible);
            pfCONFIGURATION.Init(wp.CONFIGURATION, wp.CONFIGURATIONREQ, false, RequireVisible);
            pfDimDrawing.Init(wp.DIMENDRAWING, wp.DIMENSIONALDRAWINGREQ, false, RequireVisible);
            pf3DSBORKA.Init(wp.SBORKA3D, wp.SBORKA3DREQ, false, RequireVisible);
            pfMECHPARTS.Init(wp.MECHPARTS, wp.MECHPARTSREQ, false, RequireVisible);
            packZHGUT.Init(WPTYPE.ZHGUTLIST, wp.ID, wp.ZHGUTLISTREQ, false, RequireVisible);
            packCABLE.Init(WPTYPE.CABLELIST, wp.ID, wp.CABLELISTREQ, false, RequireVisible);
            pfSHILDS.Init(wp.SHILDS, wp.SHILDSREQ, false, RequireVisible);
            pfPLANKA.Init(wp.PLANKA, wp.PLANKAREQ, false, RequireVisible);
            pfSERIAL.Init(wp.SERIAL, wp.SERIALREQ, false, RequireVisible);
            pfPACKAGING.Init(wp.PACKAGING, wp.PACKAGINGREQ, false, RequireVisible);
            pfPASSPORT.Init(wp.PASSPORT, wp.PASSPORTREQ, false, RequireVisible);
            pfMANUAL.Init(wp.MANUAL, wp.MANUALREQ, false, RequireVisible);
            pfPACKINGLIST.Init(wp.PACKINGLIST, wp.PACKINGLISTREQ, false, RequireVisible);
        }

        private void InitEDIT(WPNameVO wp)
        {
            EditWP = wp;
            tbName.Text = wp.WPName;
            cbCategory.SelectedValue = wp.IDCat;
            cbSubCategory.SelectedValue = wp.IDSubCat;
            tbDecNum.Text = wp.DecNum;
            tbPowerSupply.Text = wp.PowerSupply;
            tbNote.Text = wp.Note;

            pfWIRINGDIAGRAM.Init(wp.WIRINGDIAGRAM, wp.WIRINGDIAGRAMREQ, false, RequireVisible);
            pfTECHREQ.Init(wp.TECHREQ, wp.TECHREQREQ, false, RequireVisible);
            pfComposition.Init(wp.COMPOSITION, wp.COMPOSITIONREQ, false, RequireVisible);
            pfCONFIGURATION.Init(wp.CONFIGURATION, wp.CONFIGURATIONREQ, false, RequireVisible);
            pfDimDrawing.Init(wp.DIMENDRAWING, wp.DIMENSIONALDRAWINGREQ, false, RequireVisible);
            pf3DSBORKA.Init(wp.SBORKA3D, wp.SBORKA3DREQ, false, RequireVisible);
            pfMECHPARTS.Init(wp.MECHPARTS, wp.MECHPARTSREQ, false, RequireVisible); 
            packZHGUT.Init(WPTYPE.ZHGUTLIST, wp.ID, wp.ZHGUTLISTREQ, false,RequireVisible);
            packCABLE.Init(WPTYPE.CABLELIST, wp.ID, wp.CABLELISTREQ, false,RequireVisible);
            pfSHILDS.Init(wp.SHILDS, wp.SHILDSREQ, false, RequireVisible);
            pfPLANKA.Init(wp.PLANKA, wp.PLANKAREQ, false, RequireVisible);
            pfSERIAL.Init(wp.SERIAL, wp.SERIALREQ, false, RequireVisible);
            pfPACKAGING.Init(wp.PACKAGING, wp.PACKAGINGREQ, false, RequireVisible);
            pfPASSPORT.Init(wp.PASSPORT, wp.PASSPORTREQ, false, RequireVisible);
            pfMANUAL.Init(wp.MANUAL, wp.MANUALREQ, false, RequireVisible);
            pfPACKINGLIST.Init(wp.PACKINGLIST, wp.PACKINGLISTREQ, false, RequireVisible);

            AllocateRoles();

        }




        private void InitNEWCLONE(WPNameVO clone)
        {
            if (clone.WPName != "")
            {
                this.Clone = clone;

                //wp.WPType = WPTYPE.WPNAMELIST;
                //wp.ID = (int)r["ID"];

                tbName.Text = Clone.WPName;
                cbCategory.SelectedValue = Clone.IDCat;
                cbSubCategory.SelectedValue = Clone.IDSubCat;
                tbDecNum.Text = Clone.DecNum;
                cbCategory.SelectedValue = Clone.IDCat;//CHECK!!!!!!!!
                cbSubCategory.SelectedValue = Clone.IDSubCat;//CHECK!!!!!!!!!
                
                
                pfWIRINGDIAGRAM.Init(Clone.WIRINGDIAGRAM, false, false, RequireVisible);
                pfTECHREQ.Init(Clone.TECHREQ, false, false, RequireVisible);
                pfComposition.Init(Clone.COMPOSITION, false, false, RequireVisible);
                pfCONFIGURATION.Init(Clone.CONFIGURATION, false, false, RequireVisible);
                pfDimDrawing.Init(Clone.DIMENDRAWING, false, false, RequireVisible);
                pf3DSBORKA.Init(Clone.SBORKA3D, false, false, RequireVisible);
                pfMECHPARTS.Init(Clone.MECHPARTS, false, false, RequireVisible);
                packZHGUT.Init(WPTYPE.ZHGUTLIST, Clone.ID, Clone.ZHGUTLISTREQ, false, RequireVisible);
                packCABLE.Init(WPTYPE.CABLELIST, Clone.ID, Clone.CABLELISTREQ, false, RequireVisible);
                pfSHILDS.Init(Clone.SHILDS, false, false, RequireVisible);
                pfPLANKA.Init(Clone.PLANKA, false, false, RequireVisible);
                pfSERIAL.Init(Clone.SERIAL, false, false, RequireVisible);
                pfPACKAGING.Init(Clone.PACKAGING, false, false, RequireVisible);
                pfPASSPORT.Init(Clone.PASSPORT, false, false, RequireVisible);
                pfMANUAL.Init(Clone.MANUAL, false, false, RequireVisible);
                pfPACKINGLIST.Init(Clone.PACKINGLIST, false, false, RequireVisible);
                tbPowerSupply.Text = Clone.PowerSupply;
                tbNote.Text = Clone.Note;
                AllocateRoles();
            }
        }

        private void InitNEW()
        {
            
            pfWIRINGDIAGRAM.Init("", false, true, RequireVisible); 
            pfTECHREQ.Init("", false, true, RequireVisible); 
            pfComposition.Init("", false, true, RequireVisible); 
            pfCONFIGURATION.Init("", false, true, RequireVisible); 
            pfDimDrawing.Init("", false, true, RequireVisible); 
            pf3DSBORKA.Init("", false, true, RequireVisible); 
            pfMECHPARTS.Init("", false, true, RequireVisible); 
            packZHGUT.Init(WPTYPE.ZHGUTLIST, Clone.ID, Clone.ZHGUTLISTREQ, false,RequireVisible);
            packCABLE.Init(WPTYPE.CABLELIST, Clone.ID, Clone.CABLELISTREQ, false,RequireVisible);
            pfSHILDS.Init("", false, true, RequireVisible); 
            pfPLANKA.Init("", false, true, RequireVisible); 
            pfSERIAL.Init("", false, true, RequireVisible); 
            pfPACKAGING.Init("", false, true, RequireVisible); 
            pfPASSPORT.Init("", false, true, RequireVisible); 
            pfMANUAL.Init("", false, true, RequireVisible); 
            pfPACKINGLIST.Init("", false, true, RequireVisible);
            AllocateRoles();
        }

        private void AllocateRoles()
        {
            switch (UVO.Role)
            {
                case Roles.Admin:
                    EnableAdmin();
                    break;
                case Roles.Inzhener:
                case Roles.SimpleInzhener:
                    EnableInzhener();
                    break;
                case Roles.Constructor:
                    EnableConstructor();
                    break;
                case Roles.Shemotehnik:
                    EnableShemotehnik();
                    break;
                case Roles.Tehnolog:
                    EnableTehnolog();
                    break;
                case Roles.OTD:
                    EnableOTD();
                    break;
            }
        }



        private void EnableInzhener()
        {
            tbName.Enabled = true;
            cbCategory.Enabled = true;
            cbSubCategory.Enabled = true;
            tbDecNum.Enabled = true;
            tbNote.Enabled = true;
            tbPowerSupply.Enabled = true;

            pfTECHREQ.Enabled = true;
            pfComposition.Enabled = true;
            pfCONFIGURATION.Enabled = true;
        }

        private void EnableOTD()
        {
            pfPASSPORT.Enabled = true;
            pfMANUAL.Enabled = true;
            pfPACKINGLIST.Enabled = true;
        }

        private void EnableTehnolog()
        {
            throw new NotImplementedException();
        }

        private void EnableShemotehnik()
        {
            pfWIRINGDIAGRAM.Enabled = true;
        }
        private void EnableConstructor()
        {
            tbName.Enabled = true;
            cbCategory.Enabled = true;
            cbSubCategory.Enabled = true;
            tbDecNum.Enabled = true;
            tbNote.Enabled = true;

            pfDimDrawing.Enabled = true;
            pf3DSBORKA.Enabled = true;
            pfMECHPARTS.Enabled = true;
            packZHGUT.Enabled = true;
            packCABLE.Enabled = true;
            pfSHILDS.Enabled = true;
            pfPLANKA.Enabled = true;
            pfPACKAGING.Enabled = true;
        }

        private void EnableAdmin()
        {
            tbName.Enabled = true;
            cbCategory.Enabled = true;
            cbSubCategory.Enabled = true;
            tbDecNum.Enabled = true;
            tbPowerSupply.Enabled = true;
            tbNote.Enabled = true;

            pfWIRINGDIAGRAM.Enabled = true;
            pfTECHREQ.Enabled = true;
            pfComposition.Enabled = true;
            pfCONFIGURATION.Enabled = true;
            pfDimDrawing.Enabled = true;
            pf3DSBORKA.Enabled = true;
            pfMECHPARTS.Enabled = true;
            packZHGUT.Enabled = true;
            packCABLE.Enabled = true;
            pfSHILDS.Enabled = true;
            pfPLANKA.Enabled = true;
            pfSERIAL.Enabled = true;
            pfPACKAGING.Enabled = true;
            pfPASSPORT.Enabled = true;
            pfMANUAL.Enabled = true;
            pfPACKINGLIST.Enabled = true;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WPNameVO wp = new WPNameVO();
            if (tbName.Text == "")
            {
                MessageBox.Show("Введите наименование!");
                return;
            }
            
            wp.WPType                   = WPTYPE.WPNAMELIST;
            //wp.ID = (int)r["ID"];
            wp.WPName                   = tbName.Text;
            wp.IDCat                    = Convert.ToInt32(cbCategory.SelectedValue);
            wp.IDSubCat                 = (cbSubCategory.SelectedValue == null) ? 0 : (int)cbSubCategory.SelectedValue;
            wp.DecNum                   = tbDecNum.Text;
            wp.WIRINGDIAGRAM            = (pfWIRINGDIAGRAM.FullPath == "<нет>") ? null : pfWIRINGDIAGRAM.FullPath;
            wp.TECHREQ                  = (pfTECHREQ.FullPath == "<нет>") ? null : pfTECHREQ.FullPath;
            wp.COMPOSITION              = (pfComposition.FullPath == "<нет>") ? null : pfComposition.FullPath;
            wp.CONFIGURATION            = (pfCONFIGURATION.FullPath == "<нет>") ? null : pfCONFIGURATION.FullPath;
            wp.DIMENDRAWING             = (pfDimDrawing.FullPath == "<нет>") ? null : pfDimDrawing.FullPath; ;
            wp.SBORKA3D                 = (pf3DSBORKA.FullPath == "<нет>") ? null : pf3DSBORKA.FullPath;
            wp.MECHPARTS                = (pfMECHPARTS.FullPath == "<нет>") ? null : pfMECHPARTS.FullPath;
            wp.ZHGUTS                   = new DBZhgutList().GetPackageForVO(wp.ID);
            wp.CABLES                   =  new DBCableList().GetPackageForVO(wp.ID);
            wp.SHILDS                   = (pfSHILDS.FullPath == "<нет>") ? null : pfSHILDS.FullPath;
            wp.PLANKA                   = (pfPLANKA.FullPath == "<нет>") ? null : pfPLANKA.FullPath;
            wp.SERIAL                   = (pfSERIAL.FullPath == "<нет>") ? null : pfSERIAL.FullPath;
            wp.PACKAGING                = (pfPACKAGING.FullPath == "<нет>") ? null : pfPACKAGING.FullPath;
            wp.PASSPORT                 = (pfPASSPORT.FullPath == "<нет>") ? null : pfPASSPORT.FullPath;
            wp.MANUAL                   = (pfMANUAL.FullPath == "<нет>") ? null : pfMANUAL.FullPath;
            wp.PACKINGLIST              = (pfPACKINGLIST.FullPath == "<нет>") ? null : pfPACKINGLIST.FullPath; 
            wp.PowerSupply              = tbPowerSupply.Text;
            wp.Note                     = tbNote.Text;

            wp.COMPOSITIONREQ           = pfComposition.Required;
            wp.DIMENSIONALDRAWINGREQ    = pfDimDrawing.Required	;
            //wp.POWERSUPPLYREQ	        = pfpowe;
            wp.CONFIGURATIONREQ         = pfCONFIGURATION.Required;	
            wp.WIRINGDIAGRAMREQ         = pfWIRINGDIAGRAM.Required;	
            wp.TECHREQREQ	            = pfTECHREQ.Required;
            wp.SBORKA3DREQ	            = pf3DSBORKA.Required;
            wp.MECHPARTSREQ             = pfMECHPARTS.Required;	
            wp.SHILDSREQ	            = pfSHILDS.Required;
            wp.PLANKAREQ	            = pfPLANKA.Required;
            wp.SERIALREQ	            = pfSERIAL.Required;
            wp.PACKAGINGREQ	            = pfPACKAGING.Required;
            wp.PASSPORTREQ              = pfPASSPORT.Required;
            wp.MANUALREQ	            = pfMANUAL.Required;
            wp.PACKINGLISTREQ	        = pfPACKINGLIST.Required;
            //wp.SOFTWAREREQ	;
            wp.CABLELISTREQ             = packCABLE.Required;	
            wp.ZHGUTLISTREQ             = packZHGUT.Required;	
            //wp.RUNCARDLISTREQ	;
            //wp.CIRCUITBOARDLISTREQ;

            DBWPName dbwp = new DBWPName();
            if (AccessMode == "EDIT")
            {
                wp.ID = EditWP.ID;
                dbwp.EditWP(wp);
                MessageBox.Show("Изделие успешно сохранено!");
            }
            if ((AccessMode == "NEW") || (AccessMode == "NEWCLONE"))
            {
                dbwp.AddNewWP(wp);
                MessageBox.Show("Изделие успешно добавлено!");
            }
            Close();
        }

        private void NewWPN_Load(object sender, EventArgs e)
        {
            DBCategory dbc = new DBCategory("WPNAMELIST");
            cbCategory.ValueMember = "ID";
            cbCategory.DisplayMember = "CATEGORYNAME";
            cbCategory.DataSource = dbc.GetAllExceptAll();

            if (AccessMode == "NEWCLONE")
            {
                if (Clone.IDCat != 0)
                {
                    cbCategory.SelectedValue = Clone.IDCat;
                }
                else
                {
                    cbCategory.SelectedValue = 1;
                }
            }
            if (AccessMode == "NEW")
            {
                cbCategory.SelectedValue = 1;
            }
            if (AccessMode == "EDIT")
            {
                if (EditWP.IDCat != 0)
                {
                    cbCategory.SelectedValue = EditWP.IDCat;
                }
                else
                {
                    cbCategory.SelectedValue = 1;
                }

            }
            LoadSubs((int)cbCategory.SelectedValue);
            if (AccessMode == "NEWCLONE")
                cbSubCategory.SelectedValue = Clone.IDSubCat;
            if (AccessMode == "EDIT")
                cbSubCategory.SelectedValue = EditWP.IDSubCat;



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

            }
        }
        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSubs((int)cbCategory.SelectedValue);
        }

       
    }
}
