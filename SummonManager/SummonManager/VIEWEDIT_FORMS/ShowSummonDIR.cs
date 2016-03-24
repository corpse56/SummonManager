using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace SummonManager
{
    public partial class ShowSummonDIR : Form
    {
        private DBSummon dbs;
        private SummonVO SVO;
        private string IDS;
        private string IDSUMMON;
        private UserVO UVO;
        public ShowSummonDIR(string ids, UserVO uvo, string idsummon)
        {
            InitializeComponent();
            this.UVO = uvo;
            this.IDS = ids;
            this.IDSUMMON = idsummon;
            LoadSummon();
            DisableAll();

            if (UVO == null)
            {
                button2.Enabled = false;
                bEdit.Enabled = false;
                //button1.Enabled = false;
                summonTransfer1.Enabled = false;
                summonTransfer2.Enabled = false;
                bDel.Enabled = false;
                summonNotes1.button1.Enabled = false;
                this.Text = "Просмотр завершённого извещения";

            }
            else
            {
                switch (UVO.Role)
                {
                    case Roles.Admin:

                        break;
                    case Roles.Director:
                        button2.Enabled = false;
                        bEdit.Enabled = false;
                       // button1.Enabled = false;
                        summonTransfer1.Enabled = false;
                        summonTransfer2.Enabled = false;
                        bDel.Enabled = false;
                        summonNotes1.button1.Enabled = false;
                        break;
                }
            }
        }

        private void DisableAll()
        {
            //pathFileds1.bPATH1.Enabled = false;
            //pathFileds1.bPATH2.Enabled = false;
            //pathFileds1.bPATH3.Enabled = false;
            //pathFileds1.bCOMPOSITION.Enabled = false;
            //pathFileds1.bMETAL.Enabled = false;
            //pathFileds1.bPATH4.Enabled = false;
            //pathFileds1.bPATH5.Enabled = false;
            //pathFileds1.chSHILD.Enabled = false;
            //pathFileds1.ch3D.Enabled = false;
            //pathFileds1.chPLANKA.Enabled = false;
            //pathFileds1.chMETAL.Enabled = false;
            //pathFileds1.chCOMPOSITION.Enabled = false;
            //pathFileds1.chSERIAL.Enabled = false;

            //pathFileds1.bShildDel.Enabled = false;
            //pathFileds1.bPlankaDel.Enabled = false;
            //pathFileds1.b3DDel.Enabled = false;
            //pathFileds1.bZhgutDel.Enabled = false;
            //pathFileds1.bSerialDel.Enabled = false;
            //pathFileds1.bCompositionDel.Enabled = false;
            //pathFileds1.bMetalDel.Enabled = false;

            pfSHILD.Enabled = false;
            pfPLANKA.Enabled = false;
            pf3D.Enabled = false;
            pfZHGUT.Enabled = false;
            pfMETAL.Enabled = false;
            pfCOMPOSITION.Enabled = false;
            pfMETAL.Enabled = false;
            
            //cbWPNAME.ReadOnly = true;
            //cbWPNAME.DropDownStyle = ComboBoxStyle.DropDown;
            bPATH.Enabled = false;
            tbQUANTITY.ReadOnly = true;
            dtpPTIME.Enabled = false;
            tbSHIPPING.ReadOnly = true;
            cbAccept.ReadOnly = true;
            cbAccept.DropDownStyle = ComboBoxStyle.DropDown;
            tbCONTRACT.ReadOnly = true;
            tbDELIVERY.ReadOnly = true;
            //tbNote.ReadOnly = true;
            cbCustomers.DropDownStyle = ComboBoxStyle.DropDown;
            cbCustomers.ReadOnly = true;
            tbPAYSTATUS.ReadOnly = true;
            cbSISP.DropDownStyle = ComboBoxStyle.DropDown;
            cbSISP.ReadOnly = true;
            bPrint.Enabled = true;
            chbDeterm.Enabled = false;
            dtpAPPROX.Enabled = false;
            cbPacking.DropDownStyle = ComboBoxStyle.DropDown;
            cbPacking.ReadOnly = true;
            cbMountingKit.DropDownStyle = ComboBoxStyle.DropDown;
            cbMountingKit.ReadOnly = true;
            bEditExtCablePack.Enabled = false;
            cbCustDept.ReadOnly = true;
            //cbWPNAME.ReadOnly = true;
            //cbWPNAME.DropDownStyle = ComboBoxStyle.DropDown;
            bPATH.Enabled = false;
            tbQUANTITY.ReadOnly = true;
            dtpPTIME.Enabled = false;
            tbSHIPPING.ReadOnly = true;
            cbAccept.ReadOnly = true;
            cbAccept.DropDownStyle = ComboBoxStyle.DropDown;
            tbCONTRACT.ReadOnly = true;
            tbDELIVERY.ReadOnly = true;
            //tbNote.ReadOnly = true;
            cbCustomers.DropDownStyle = ComboBoxStyle.DropDown;
            cbCustomers.ReadOnly = true;
            tbPAYSTATUS.ReadOnly = true;
            cbSISP.DropDownStyle = ComboBoxStyle.DropDown;
            cbSISP.ReadOnly = true;
            bEdit.Enabled = true;
            bSave.Enabled = false;
            bPrint.Enabled = true;
            chbDeterm.Enabled = false;
            dtpAPPROX.Enabled = false;
            cbPacking.DropDownStyle = ComboBoxStyle.DropDown;
            cbPacking.ReadOnly = true;
            //cbExtCable.DropDownStyle = ComboBoxStyle.DropDown;
            //cbExtCable.ReadOnly = true;
            cbMountingKit.DropDownStyle = ComboBoxStyle.DropDown;
            cbMountingKit.ReadOnly = true;
            bEditExtCablePack.Enabled = false;
            cbCustDept.ReadOnly = true;
            //button1.Enabled = true;
        }
        private void EnableAll()
        {
            //cbWPNAME.ReadOnly = false;
            //cbWPNAME.DropDownStyle = ComboBoxStyle.DropDownList;
            bPATH.Enabled = true;
            tbQUANTITY.ReadOnly = false;
            dtpPTIME.Enabled = true;
            tbSHIPPING.ReadOnly = false;
            cbAccept.ReadOnly = false;
            cbAccept.DropDownStyle = ComboBoxStyle.DropDownList;
            tbCONTRACT.ReadOnly = false;
            tbDELIVERY.ReadOnly = false;
            //tbNote.ReadOnly = false;
            cbCustomers.ReadOnly = false;
            cbCustomers.DropDownStyle = ComboBoxStyle.DropDownList;
            tbPAYSTATUS.ReadOnly = false;
            cbSISP.ReadOnly = false;
            cbSISP.DropDownStyle = ComboBoxStyle.DropDownList;
            bEdit.Enabled = false;
            bSave.Enabled = true;
            bPrint.Enabled = true;
            chbDeterm.Enabled = true;
            if (chbDeterm.Checked)
                dtpAPPROX.Enabled = false;
            else
                dtpAPPROX.Enabled = true;
            cbPacking.DropDownStyle = ComboBoxStyle.DropDownList;
            cbPacking.ReadOnly = false;
            //cbExtCable.DropDownStyle = ComboBoxStyle.DropDownList;
            //cbExtCable.ReadOnly = false;
            cbMountingKit.DropDownStyle = ComboBoxStyle.DropDownList;
            cbMountingKit.ReadOnly = false;
            bEditExtCablePack.Enabled = true;
            cbCustDept.ReadOnly = false;
            //button1.Enabled = false;
            //pathFileds1.bPATH1.Enabled = true;
            //pathFileds1.bPATH2.Enabled = true;
            //pathFileds1.bPATH3.Enabled = true;
            //pathFileds1.bCOMPOSITION.Enabled = true;
            //pathFileds1.bMETAL.Enabled = true;
            //pathFileds1.bPATH4.Enabled = true;
            //pathFileds1.bPATH5.Enabled = true;

            //pathFileds1.chSHILD.Enabled = true;
            //pathFileds1.ch3D.Enabled = true;
            //pathFileds1.chPLANKA.Enabled = true;
            //pathFileds1.chMETAL.Enabled = true;
            //pathFileds1.chCOMPOSITION.Enabled = true;
            //pathFileds1.chSERIAL.Enabled = true;

            //pathFileds1.bShildDel.Enabled = true;
            //pathFileds1.bPlankaDel.Enabled = true;
            //pathFileds1.b3DDel.Enabled = true;
            //pathFileds1.bZhgutDel.Enabled = true;
            //pathFileds1.bSerialDel.Enabled = true;
            //pathFileds1.bCompositionDel.Enabled = true;
            //pathFileds1.bMetalDel.Enabled = true;
            pfSHILD.Enabled = true;
            pfPLANKA.Enabled = true;
            pf3D.Enabled = true;
            pfZHGUT.Enabled = true;
            pfMETAL.Enabled = true;
            pfCOMPOSITION.Enabled = true;
            pfMETAL.Enabled = true;


        }
        private void LoadSummon()
        {
            dbs = new DBSummon();
            SVO = dbs.GetSummonByIDS(IDS);

            tbIDS.Text = SVO.IDS;

            DBCustomer dbc = new DBCustomer();
            cbCustomers.ValueMember = "ID";
            cbCustomers.DisplayMember = "CNAME";
            cbCustomers.DataSource = dbc.GetAllCustomers();
            cbCustomers.SelectedValue = SVO.IDCUSTOMER;

            if (SVO.SISP)
                cbSISP.SelectedIndex = 1;
            else
                cbSISP.SelectedIndex = 0;

            DBAccept dbacc = new DBAccept();
            cbAccept.ValueMember = "ID";
            cbAccept.DisplayMember = "ANAME";
            cbAccept.DataSource = dbacc.GetAllAccept();
            cbAccept.SelectedValue = SVO.IDACCEPT;

           /* DBWPName dbwp = new DBWPName();
            cbWPNAME.ValueMember = "ID";
            cbWPNAME.DisplayMember = "WPNAME";
            cbWPNAME.DataSource = dbwp.GetAllWPNames();
            cbWPNAME.SelectedValue = SVO.IDWPNAME;*/

            DBPacking dbp = new DBPacking();
            cbPacking.ValueMember = "ID";
            cbPacking.DisplayMember = "PNAME";
            cbPacking.DataSource = dbp.GetAll();
            cbPacking.SelectedValue = SVO.IDPACKING;

            //DBEXTCABLE dbec = new DBEXTCABLE();
            //cbExtCable.ValueMember = "ID";
            //cbExtCable.DisplayMember = "EXTCABLENAME";
            //cbExtCable.DataSource = dbec.GetAllEXTCABLENames();
            //cbExtCable.SelectedValue = SVO.IDEXTCABLE;

            DBMountingKit dbmk = new DBMountingKit();
            cbMountingKit.ValueMember = "ID";
            cbMountingKit.DisplayMember = "MOUNTINGKITNAME";
            cbMountingKit.DataSource = dbmk.GetAllDBMountingKitNames();
            cbMountingKit.SelectedValue = SVO.IDMOUNTINGKIT;


            tbCONTRACT.Text = SVO.CONTRACT;
            tbDELIVERY.Text = SVO.DELIVERY;
            //tbNote.Text = SVO.NOTE;
            //tbNOTEPDB.Text = SVO.NOTEPDB;
            tbQUANTITY.Value = SVO.QUANTITY;
            tbSHIPPING.Text = SVO.SHIPPING;
            tbTECHREQPATH.Text = SVO.TECHREQPATH.Substring(SVO.TECHREQPATH.LastIndexOf("\\") + 1);
            tbTECHREQPATH.Tag = SVO.TECHREQPATH;
            dtpCREATED.Value = SVO.CREATED;
            dtpPTIME.Value = SVO.PTIME;
            tbPAYSTATUS.Text = SVO.PAYSTATUS;
            if (SVO.PASSDATE == null)
            {
                chbDeterm.Checked = true;
                dtpAPPROX.Enabled = false;
            }
            else
            {
                chbDeterm.Checked = false;
                dtpAPPROX.Enabled = true;
                dtpAPPROX.Value = (DateTime)SVO.PASSDATE;
            }


            //LoadExtCables();
            UIProc ui = new UIProc();
            ui.LoadExtCables(dgv, this.IDSUMMON.ToString());

            summonNotes1.Init(SVO.ID, UVO, SVO);
            summonNotes1.Reload();

            summonTransfer1.Init(SVO, UVO, this);
            if (SVO.WPNAMEVO.IDCat == 4)
            {
                summonTransfer2.Visible = false;
            }
            summonTransfer2.InitSub(SVO, UVO, this);

            //pfSHILD.Init(SVO.SHILD, SVO.SHILDREQ, false, true, false);
            //pfPLANKA.Init(SVO.PLANKA, SVO.PLANKAREQ, false, true, false);
            //pf3D.Init(SVO.SBORKA3D, SVO.SBORKA3DREQ, false, true, false);
            //pfZHGUT.Init(SVO.ZHGUT, false, false, false, false);
            //pfSERIAL.Init(SVO.SERIAL, SVO.SERIALREQ, false, true, false);
            //pfCOMPOSITION.Init(SVO.COMPOSITION, SVO.COMPOSITIONREQ, false, true, false);
            //pfCOMPOSITION.ValueFromArchive = true;
            //pfMETAL.Init(SVO.METAL, SVO.METALREQ, false, true, false);
            pfMETAL.IsPath = true;


        }


        private void bCancel_Click(object sender, EventArgs e)
        {
            Close();
            
        }
        private void bSave_Click(object sender, EventArgs e)
        {
            if (tbQUANTITY.Value == 0)
            {
                MessageBox.Show("Введите количество изделий!");
                return;
            }
            if (cbCustDept.SelectedValue == null)
            {
                MessageBox.Show("Добавьте отдел заказчика!");
                return;
            }
            DBSummon dbs = new DBSummon();
            SummonVO SVO = new SummonVO();
            SVO = SummonVO.SummonVOByID(this.IDSUMMON);
            SVO.ID = this.IDSUMMON;
            SVO.IDS = tbIDS.Text;
            SVO.ACCEPTANCE = cbAccept.Text;
            SVO.CONTRACT = tbCONTRACT.Text;
            SVO.CREATED = this.SVO.CREATED;
            SVO.DELIVERY = tbDELIVERY.Text;
            SVO.IDCUSTOMER = cbCustomers.SelectedValue.ToString();
            SVO.IDCUSTOMERDEPT = (int)cbCustDept.SelectedValue;
            SVO.PAYSTATUS = tbPAYSTATUS.Text;
            SVO.IDSTATUS = 1;
            SVO.NOTE = ""; //tbNote.Text;
            SVO.NOTEPDB = "";// tbNOTEPDB.Text;
            SVO.PTIME = dtpPTIME.Value;
            SVO.QUANTITY = (int)tbQUANTITY.Value;
            SVO.SHIPPING = tbSHIPPING.Text;
            if (cbSISP.SelectedIndex == 1)
                SVO.SISP = true;
            else
                SVO.SISP = false;
            SVO.TECHREQPATH = tbTECHREQPATH.Tag.ToString();
            //SVO.WPNAME = cbWPNAME.Text;
            //SVO.IDWPNAME = (int)cbWPNAME.SelectedValue;
            SVO.IDACCEPT = (int)cbAccept.SelectedValue;
            SVO.IDPACKING = (int)cbPacking.SelectedValue;
            //SVO.IDEXTCABLE = (int)cbExtCable.SelectedValue;
            SVO.IDMOUNTINGKIT = (int)cbMountingKit.SelectedValue;
            
            //SVO.SHILD = pathFileds1.bSHILDOpen.Tag.ToString();
            //SVO.PLANKA = pathFileds1.bPLANKAOpen.Tag.ToString();
            //SVO.SBORKA3D = pathFileds1.b3DOpen.Tag.ToString();
            //SVO.ZHGUT = pathFileds1.bZHGUTOpen.Tag.ToString();
            //SVO.SERIAL = pathFileds1.bSERIALOpen.Tag.ToString();
            //SVO.METAL = pathFileds1.bMETALOpen.Tag.ToString();
            //SVO.COMPOSITION = pathFileds1.bCOMPOSITIONOpen.Tag.ToString();
            //SVO.SHILDREQ = pathFileds1.chSHILD.Checked;
            //SVO.PLANKAREQ = pathFileds1.chPLANKA.Checked;
            //SVO.SBORKA3DREQ = pathFileds1.ch3D.Checked;
            //SVO.SERIALREQ = pathFileds1.chSERIAL.Checked;
            //SVO.COMPOSITIONREQ = pathFileds1.chCOMPOSITION.Checked;
            //SVO.METALREQ = pathFileds1.chMETAL.Checked;
            SVO.SHILD = pfSHILD.FullPath;
            SVO.PLANKA = pfPLANKA.FullPath;
            SVO.SBORKA3D = pf3D.FullPath;
            SVO.ZHGUT = pfZHGUT.FullPath;
            SVO.SERIAL = pfSERIAL.FullPath;
            SVO.METAL = pfMETAL.FullPath;
            SVO.COMPOSITION = pfCOMPOSITION.FullPath;
            SVO.SHILDREQ = pfSHILD.Required;
            SVO.PLANKAREQ = pfPLANKA.Required;
            SVO.SBORKA3DREQ = pf3D.Required;
            SVO.SERIALREQ = pfSERIAL.Required;
            SVO.COMPOSITIONREQ = pfCOMPOSITION.Required;
            SVO.METALREQ = pfMETAL.Required;

            if (chbDeterm.Checked)
            {
                SVO.PASSDATE = null;
            }
            else
            {
                SVO.PASSDATE = dtpAPPROX.Value;
            }

            dbs.SaveSummon(SVO);
            
            MessageBox.Show("Извещение успешно сохранено!");
            DisableAll();
        }

        private void bPATH_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "All files (*.*)|*.*";
            //dialog.InitialDirectory = @"\\10.177.150.135\server\поездки\карта";
            dialog.InitialDirectory = @"c:\";
            dialog.Title = "Выберите файл";
            dialog.Multiselect = false;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                tbTECHREQPATH.Text = dialog.FileName.Substring(dialog.FileName.LastIndexOf(@"\")+1); ;
                tbTECHREQPATH.Tag = dialog.FileName;
            }
        }
        private void cbCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {
            DBCustomer dbc = new DBCustomer();
            cbCustDept.DataSource = dbc.GetDeptsByIDCustomer(cbCustomers.SelectedValue.ToString());

        }
        private void bEdit_Click(object sender, EventArgs e)
        {
            EnableAll();
        }
        private void chbDeterm_CheckedChanged(object sender, EventArgs e)
        {
            if (chbDeterm.Checked)
                dtpAPPROX.Enabled = false;
            else
                dtpAPPROX.Enabled = true;

        }
        private void bPrint_Click(object sender, EventArgs e)
        {
            DBSummon dbs = new DBSummon();
            SummonVO svo = dbs.GetSummonByIDS(tbIDS.Text);
            SummonVOForReport svor = new SummonVOForReport(svo);
            List<SummonVOForReport> sl = new List<SummonVOForReport>();
            sl.Add(svor);
            ShowReport sr = new ShowReport(sl);
            sr.ShowDialog();
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }
        private DateTime? dtpApproxAtLoad;

        private void ShowSummonDIR_Load(object sender, EventArgs e)
        {
            DBCustomer dbc = new DBCustomer();
            //cbCustomers.ValueMember = "ID";
            //cbCustomers.DisplayMember = "CNAME";
            //cbCustomers.DataSource = dbc.GetAllCustomers();

            cbCustDept.ValueMember = "ID";
            cbCustDept.DisplayMember = "DEPTNAME";
            cbCustDept.DataSource = dbc.GetDeptsByIDCustomer(cbCustomers.SelectedValue.ToString());
            cbCustDept.SelectedValue = SVO.IDCUSTOMERDEPT;

            DBSummon dbs = new DBSummon();
            if (UVO != null)
            {
                dbs.AddSummonView(SVO, UVO);
            }
            dtpApproxAtLoad = SVO.PASSDATE;
            wpNameView1.Init(SVO.IDWPNAME);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Customers c = new Customers();
            c.ShowDialog();
            DBCustomer dbc = new DBCustomer();
            cbCustomers.DataSource = dbc.GetAllCustomers();
            cbCustomers.SelectedValue = SVO.IDCUSTOMER;

            cbCustDept.DataSource = dbc.GetDeptsByIDCustomer(cbCustomers.SelectedValue.ToString());

        }

        //private void bEditExtCablePack_Click(object sender, EventArgs e)
        //{
        //    fEditExtCablePack fecp = new fEditExtCablePack(this.IDSUMMON);
        //    fecp.ShowDialog();
        //    UIProc ui = new UIProc();
        //    ui.LoadExtCables(dgv, this.IDSUMMON);

        //}

        private void button1_Click(object sender, EventArgs e)
        {
            fAdminChangeStatus facs = new fAdminChangeStatus(this.SVO, this.UVO);
            facs.ShowDialog();

        }

        private void tbTECHREQPATH_Click(object sender, EventArgs e)
        {
            if (tbTECHREQPATH.Tag != null)
            {
                if (tbTECHREQPATH.Tag.ToString() != "")
                {
                    //Process.Start(tbTECHREQPATH.Tag.ToString().Substring(0, tbTECHREQPATH.Tag.ToString().LastIndexOf(@"\")), @"\\select, " + @"C:\Users\corps\Documents\gp4600.doc");//tbTECHREQPATH.Tag.ToString().Replace("\\","/"));
                    Process.Start("explorer.exe", @"/select, " + tbTECHREQPATH.Tag.ToString());
                }
            }
        }

        private void tbTECHREQPATH_MouseEnter(object sender, EventArgs e)
        {
            tbTECHREQPATH.ForeColor = Color.Blue;
        }

        private void tbTECHREQPATH_MouseLeave(object sender, EventArgs e)
        {
            tbTECHREQPATH.ForeColor = Color.Black;
        }

        private void bDel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить это извещение?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            DBSummon dbs = new DBSummon();
            dbs.DeleteSummonByID(SVO.ID);
            Close();

        }












    }
}
