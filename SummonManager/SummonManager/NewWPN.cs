using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SummonManager.CLASSES;
using SummonManager.Controls;

namespace SummonManager
{
    public partial class NewWPN : Form
    {
        WPNameVO Clone,EditWP;
        //ACCESSMODE: NEW,NEWCLONE,EDIT
        //NEW - форма переделывается под добавление нового изделия; EDIT - форма переделывается под редактирование; NEWCLONE - добавление на основе существующего
        private string AccessMode = "";

        UserVO UVO;
        bool RequireVisible = true;
        bool RequireEnabled = false;


        public NewWPN(WPNameVO wp, string accessmode_,UserVO uvo)
        {
            InitializeComponent();

            this.AccessMode = accessmode_;
            this.UVO = uvo;
            RequireVisible = true;//((UVO.Role == Roles.Inzhener) || (UVO.Role == Roles.Admin)) ? true : false;
            RequireEnabled = false;
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


        }

        private void InitVIEWONLY(WPNameVO wp)
        {
            RequireVisible = true;
            tbName.Text = wp.WPName;
            tbName.Enabled = false;
            cbCategory.SelectedValue = wp.IDCat;
            cbCategory.Enabled = false;
            cbSubCategory.SelectedValue = wp.IDSubCat;
            cbSubCategory.Enabled = false;
            tbDecNum.Text = wp.DecNum;
            tbDecNum.Enabled = false;
            tbPowerSupply.Text = wp.PowerSupply;
            tbPowerSupply.Enabled = false;
            tbNote.Text = wp.Note;
            tbNote.Enabled = false;

            pfWIRINGDIAGRAM.Init(wp.WIRINGDIAGRAM, wp.WIRINGDIAGRAMREQ, false, RequireVisible, RequireEnabled, Roles.Shemotehnik, UVO.Role);
            pfTECHREQ.Init(wp.TECHREQ, wp.TECHREQREQ, false, RequireVisible, RequireEnabled,Roles.Inzhener, UVO.Role);
            pfComposition.Init(wp.COMPOSITION, wp.COMPOSITIONREQ, false, RequireVisible, RequireEnabled,Roles.Inzhener, UVO.Role);
            pfCONFIGURATION.Init(wp.CONFIGURATION, wp.CONFIGURATIONREQ, false, RequireVisible, RequireEnabled,Roles.Inzhener, UVO.Role);
            pfDimDrawing.Init(wp.DIMENDRAWING, wp.DIMENSIONALDRAWINGREQ, false, RequireVisible, RequireEnabled,Roles.Constructor, UVO.Role);
            pf3DSBORKA.Init(wp.SBORKA3D, wp.SBORKA3DREQ, false, RequireVisible, RequireEnabled,Roles.Constructor, UVO.Role);
            pfMECHPARTS.Init(wp.MECHPARTS, wp.MECHPARTSREQ, false, RequireVisible, RequireEnabled,Roles.Constructor, UVO.Role);
            packZHGUT.Init(WPTYPE.ZHGUTLIST, wp.ID, wp.ZHGUTLISTREQ, false, RequireVisible, RequireEnabled, Roles.Constructor, UVO.Role, UVO);
            packCABLE.Init(WPTYPE.CABLELIST, wp.ID, wp.CABLELISTREQ, false, RequireVisible, RequireEnabled, Roles.Constructor, UVO.Role,UVO);
            pfSHILDS.Init(wp.SHILDS, wp.SHILDSREQ, false, RequireVisible, RequireEnabled,Roles.Constructor, UVO.Role);
            pfPLANKA.Init(wp.PLANKA, wp.PLANKAREQ, false, RequireVisible, RequireEnabled,Roles.Constructor, UVO.Role);
            pfSERIAL.Init(wp.SERIAL, wp.SERIALREQ, false, RequireVisible, RequireEnabled, Roles.OTK, UVO.Role);
            pfPACKAGING.Init(wp.PACKAGING, wp.PACKAGINGREQ, false, RequireVisible, RequireEnabled, Roles.Constructor, UVO.Role);
            pfPASSPORT.Init(wp.PASSPORT, wp.PASSPORTREQ, false, RequireVisible, RequireEnabled, Roles.OTD, UVO.Role);
            pfMANUAL.Init(wp.MANUAL, wp.MANUALREQ, false, RequireVisible, RequireEnabled, Roles.OTD, UVO.Role);
            pfPACKINGLIST.Init(wp.PACKINGLIST, wp.PACKINGLISTREQ, false, RequireVisible, RequireEnabled, Roles.OTD, UVO.Role);

            packZHGUT.Enabled = false;
            packCABLE.Enabled = false;
        }

        private void InitEDIT(WPNameVO wp)
        {
            EditWP = wp;
            tbName.Text = wp.WPName;
            tbName.Enabled = false;
            cbCategory.SelectedValue = wp.IDCat;
            cbCategory.Enabled = false;
            cbSubCategory.SelectedValue = wp.IDSubCat;
            cbSubCategory.Enabled = false;
            tbDecNum.Text = wp.DecNum;
            tbDecNum.Enabled = false;
            tbPowerSupply.Text = wp.PowerSupply;
            tbPowerSupply.Enabled = false;
            tbNote.Text = wp.Note;
            tbNote.Enabled = false;

            pfWIRINGDIAGRAM.Init(wp.WIRINGDIAGRAM, wp.WIRINGDIAGRAMREQ, false, RequireVisible, RequireEnabled, Roles.Shemotehnik, UVO.Role);
            pfTECHREQ.Init(wp.TECHREQ, wp.TECHREQREQ, false, RequireVisible, RequireEnabled, Roles.Inzhener, UVO.Role);
            pfComposition.Init(wp.COMPOSITION, wp.COMPOSITIONREQ, false, RequireVisible, RequireEnabled, Roles.Inzhener, UVO.Role);
            pfCONFIGURATION.Init(wp.CONFIGURATION, wp.CONFIGURATIONREQ, false, RequireVisible, RequireEnabled, Roles.Inzhener, UVO.Role);
            pfDimDrawing.Init(wp.DIMENDRAWING, wp.DIMENSIONALDRAWINGREQ, false, RequireVisible, RequireEnabled, Roles.Constructor, UVO.Role);
            pf3DSBORKA.Init(wp.SBORKA3D, wp.SBORKA3DREQ, false, RequireVisible, RequireEnabled, Roles.Constructor, UVO.Role);
            pfMECHPARTS.Init(wp.MECHPARTS, wp.MECHPARTSREQ, false, RequireVisible, RequireEnabled, Roles.Constructor, UVO.Role);
            packZHGUT.Init(WPTYPE.ZHGUTLIST, wp.ID, wp.ZHGUTLISTREQ, false, RequireVisible, RequireEnabled, Roles.Constructor, UVO.Role,UVO);
            packCABLE.Init(WPTYPE.CABLELIST, wp.ID, wp.CABLELISTREQ, false, RequireVisible, RequireEnabled, Roles.Constructor, UVO.Role, UVO);
            pfSHILDS.Init(wp.SHILDS, wp.SHILDSREQ, false, RequireVisible, RequireEnabled, Roles.Constructor, UVO.Role);
            pfPLANKA.Init(wp.PLANKA, wp.PLANKAREQ, false, RequireVisible, RequireEnabled, Roles.Constructor, UVO.Role);
            pfSERIAL.Init(wp.SERIAL, wp.SERIALREQ, false, RequireVisible, RequireEnabled, Roles.OTK, UVO.Role);
            pfPACKAGING.Init(wp.PACKAGING, wp.PACKAGINGREQ, false, RequireVisible, RequireEnabled, Roles.Constructor, UVO.Role);
            pfPASSPORT.Init(wp.PASSPORT, wp.PASSPORTREQ, false, RequireVisible, RequireEnabled, Roles.OTD, UVO.Role);
            pfMANUAL.Init(wp.MANUAL, wp.MANUALREQ, false, RequireVisible, RequireEnabled, Roles.OTD, UVO.Role);
            pfPACKINGLIST.Init(wp.PACKINGLIST, wp.PACKINGLISTREQ, false, RequireVisible, RequireEnabled, Roles.OTD, UVO.Role);

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
                tbName.Enabled = false;
                cbCategory.Enabled = false;
                cbSubCategory.Enabled = false;
                tbDecNum.Enabled = false;
                tbPowerSupply.Enabled = false;
                tbNote.Enabled = false;

                pfWIRINGDIAGRAM.Init(Clone.WIRINGDIAGRAM, Clone.WIRINGDIAGRAMREQ, false, RequireVisible, RequireEnabled, Roles.Shemotehnik, UVO.Role);
                pfTECHREQ.Init(Clone.TECHREQ, Clone.TECHREQREQ, false, RequireVisible, RequireEnabled, Roles.Inzhener, UVO.Role);
                pfComposition.Init(Clone.COMPOSITION, Clone.COMPOSITIONREQ, false, RequireVisible, RequireEnabled, Roles.Inzhener, UVO.Role);
                pfCONFIGURATION.Init(Clone.CONFIGURATION, Clone.CONFIGURATIONREQ, false, RequireVisible, RequireEnabled, Roles.Inzhener, UVO.Role);
                pfDimDrawing.Init(Clone.DIMENDRAWING, Clone.DIMENSIONALDRAWINGREQ, false, RequireVisible, RequireEnabled, Roles.Constructor, UVO.Role);
                pf3DSBORKA.Init(Clone.SBORKA3D, Clone.SBORKA3DREQ, false, RequireVisible, RequireEnabled, Roles.Constructor, UVO.Role);
                pfMECHPARTS.Init(Clone.MECHPARTS, Clone.MECHPARTSREQ, false, RequireVisible, RequireEnabled, Roles.Constructor, UVO.Role);
                packZHGUT.Init(WPTYPE.ZHGUTLIST, Clone.ID, Clone.ZHGUTLISTREQ, false, RequireVisible, RequireEnabled, Roles.Constructor, UVO.Role, UVO);
                packCABLE.Init(WPTYPE.CABLELIST, Clone.ID, Clone.CABLELISTREQ, false, RequireVisible, RequireEnabled, Roles.Constructor, UVO.Role, UVO);
                pfSHILDS.Init(Clone.SHILDS, Clone.SHILDSREQ, false, RequireVisible, RequireEnabled, Roles.Constructor, UVO.Role);
                pfPLANKA.Init(Clone.PLANKA, Clone.PLANKAREQ, false, RequireVisible, RequireEnabled, Roles.Constructor, UVO.Role);
                pfSERIAL.Init(Clone.SERIAL, Clone.SERIALREQ, false, RequireVisible, RequireEnabled, Roles.OTK, UVO.Role);
                pfPACKAGING.Init(Clone.PACKAGING, Clone.PACKAGINGREQ, false, RequireVisible, RequireEnabled, Roles.Constructor, UVO.Role);
                pfPASSPORT.Init(Clone.PASSPORT, Clone.PASSPORTREQ, false, RequireVisible, RequireEnabled, Roles.OTD, UVO.Role);
                pfMANUAL.Init(Clone.MANUAL, Clone.MANUALREQ, false, RequireVisible, RequireEnabled, Roles.OTD, UVO.Role);
                pfPACKINGLIST.Init(Clone.PACKINGLIST, Clone.PACKINGLISTREQ, false, RequireVisible, RequireEnabled, Roles.OTD, UVO.Role);
                tbPowerSupply.Text = Clone.PowerSupply;
                tbNote.Text = Clone.Note;
                AllocateRoles();
            }
        }

        private void InitNEW()
        {

            pfWIRINGDIAGRAM.Init("", false, false, RequireVisible, RequireEnabled, Roles.Shemotehnik, UVO.Role);
            pfTECHREQ.Init("", false, false, RequireVisible, RequireEnabled, Roles.Inzhener, UVO.Role);
            pfComposition.Init("", false, false, RequireVisible, RequireEnabled, Roles.Inzhener, UVO.Role);
            pfCONFIGURATION.Init("", false, false, RequireVisible, RequireEnabled, Roles.Inzhener, UVO.Role);
            pfDimDrawing.Init("", false, false, RequireVisible, RequireEnabled, Roles.Constructor, UVO.Role);
            pf3DSBORKA.Init("", false, false, RequireVisible, RequireEnabled, Roles.Constructor, UVO.Role);
            pfMECHPARTS.Init("", false, false, RequireVisible, RequireEnabled, Roles.Constructor, UVO.Role);
            packZHGUT.Init(WPTYPE.ZHGUTLIST, 0, false, false, RequireVisible, RequireEnabled, Roles.Constructor, UVO.Role, UVO);
            packCABLE.Init(WPTYPE.CABLELIST, 0, false, false, RequireVisible, RequireEnabled, Roles.Constructor, UVO.Role, UVO);
            pfSHILDS.Init("", false, false, RequireVisible, RequireEnabled, Roles.Constructor, UVO.Role);
            pfPLANKA.Init("", false, false, RequireVisible, RequireEnabled, Roles.Constructor, UVO.Role);
            pfSERIAL.Init("", false, false, RequireVisible, RequireEnabled, Roles.OTK, UVO.Role);
            pfPACKAGING.Init("", false, false, RequireVisible, RequireEnabled, Roles.Constructor, UVO.Role);
            pfPASSPORT.Init("", false, false, RequireVisible, RequireEnabled, Roles.OTD, UVO.Role);
            pfMANUAL.Init("", false, false, RequireVisible, RequireEnabled, Roles.OTD, UVO.Role);
            pfPACKINGLIST.Init("", false, false, RequireVisible, RequireEnabled, Roles.OTD, UVO.Role);
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

            pfTECHREQ.Enabled = pfTECHREQ.Required;
            pfComposition.Enabled = pfComposition.Required;
            pfCONFIGURATION.Enabled = pfCONFIGURATION.Required;

            foreach (Control c in this.Controls)
            {
                if (c.GetType() == typeof(PathField))
                {
                    (c as PathField).RequiredEnabled = true;
                }
            }
            packCABLE.RequiredEnabled = true;
            packZHGUT.RequiredEnabled = true;

        }

        private void EnableOTD()
        {
            pfPASSPORT.Enabled = pfPASSPORT.Required;
            pfMANUAL.Enabled = pfMANUAL.Required;
            pfPACKINGLIST.Enabled = pfPACKINGLIST.Required;
        }

        private void EnableTehnolog()
        {
            tbNote.Enabled = true;
        }

        private void EnableShemotehnik()
        {
            pfWIRINGDIAGRAM.Enabled = pfWIRINGDIAGRAM.Required;
            tbNote.Enabled = true;
        }
        private void EnableConstructor()
        {
            tbName.Enabled = true;
            cbCategory.Enabled = true;
            cbSubCategory.Enabled = true;
            tbDecNum.Enabled = true;
            tbNote.Enabled = true;

            pfDimDrawing.Enabled = pfDimDrawing.Required;
            pf3DSBORKA.Enabled = pf3DSBORKA.Required;
            pfMECHPARTS.Enabled = pfMECHPARTS.Required;
            pfSHILDS.Enabled = pfSHILDS.Required;
            pfPLANKA.Enabled = pfPLANKA.Required;
            pfPACKAGING.Enabled = pfPACKAGING.Required;
            if ((AccessMode != "NEW") || (AccessMode != "NEWCLONE"))
            {
                packCABLE.Enabled = packCABLE.Required;
                packZHGUT.Enabled = packZHGUT.Required;
            }
        }

        private void EnableAdmin()
        {
            tbName.Enabled = true;
            cbCategory.Enabled = true;
            cbSubCategory.Enabled = true;
            tbDecNum.Enabled = true;
            tbPowerSupply.Enabled = true;
            tbNote.Enabled = true;

            pfWIRINGDIAGRAM.Enabled = pfWIRINGDIAGRAM.Required;
            pfTECHREQ.Enabled = pfTECHREQ.Required;
            pfComposition.Enabled = pfComposition.Required;
            pfCONFIGURATION.Enabled = pfCONFIGURATION.Required;
            pfDimDrawing.Enabled = pfDimDrawing.Required;
            pf3DSBORKA.Enabled = pf3DSBORKA.Required;
            pfMECHPARTS.Enabled = pfMECHPARTS.Required;
            pfSHILDS.Enabled = pfSHILDS.Required;
            pfPLANKA.Enabled = pfPLANKA.Required;
            pfSERIAL.Enabled = pfSERIAL.Required;
            pfPACKAGING.Enabled = pfPACKAGING.Required;
            pfPASSPORT.Enabled = pfPASSPORT.Required;
            pfMANUAL.Enabled = pfMANUAL.Required;
            pfPACKINGLIST.Enabled = pfPACKINGLIST.Required;
            if ((AccessMode != "NEW") || (AccessMode != "NEWCLONE"))
            {
                packCABLE.Enabled = packCABLE.Required;
                packZHGUT.Enabled = packZHGUT.Required;
            }
            foreach (Control c in this.Controls)
            {
                if (c.GetType() == typeof(PathField))
                {
                    (c as PathField).RequiredEnabled = true;
                }
            }
            packCABLE.RequiredEnabled = true;
            packZHGUT.RequiredEnabled = true;


        }


        private void button1_Click(object sender, EventArgs e)//cancel
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)//save
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
                if (UVO.Role == Roles.Admin)                                dbwp.EditWP(wp);
                if (UVO.Role == Roles.Constructor)                          dbwp.EditWP_Constructor(wp);
                if ((UVO.Role == Roles.Inzhener) ||
                    (UVO.Role == Roles.SimpleInzhener))                     dbwp.EditWP_Inzhener(wp);
                if (UVO.Role == Roles.Tehnolog)                             dbwp.EditWP_Tehnolog(wp);
                if (UVO.Role == Roles.Shemotehnik)                          dbwp.EditWP_Shemotehnik(wp);

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

            button1.Select();

        }
        private void LoadSubs(int idCat)
        {
            if ((cbCategory.Text.ToUpper() == "ВСЕ") || (cbCategory.Text.ToUpper() == "НЕ ПРИСВОЕНО"))
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
