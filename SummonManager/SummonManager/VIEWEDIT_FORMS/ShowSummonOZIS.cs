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
    public partial class ShowSummonOZIS : Form
    {
        private DBSummon dbs;
        private SummonVO SVO;
        private string IDS;
        private string IDSUMMON;
        private UserVO UVO;
        public ShowSummonOZIS(string ids,UserVO uvo,string idsummon)
        {
            InitializeComponent();
            this.UVO = uvo;
            this.IDS = ids;
            this.IDSUMMON = idsummon;
            LoadSummon();
            DisableAll();

        }

        private void DisableAll()
        {
            summonTransfer1.Enabled = true;
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
            cbMountingKit.DropDownStyle = ComboBoxStyle.DropDown;
            cbMountingKit.ReadOnly = true;
            bEditExtCablePack.Enabled = false;
            cbCustDept.ReadOnly = true;
            chbShildOrdered.Enabled = false;
            bPurchMat.Enabled = true;
            tbStatus.Enabled = false;
            tbSubStatus.Enabled = false;
        }
        private void EnableAll()
        {
            chbShildOrdered.Enabled = true;
            summonTransfer1.Enabled = false;
            bEdit.Enabled = false;
            bSave.Enabled = true;
            bPrint.Enabled = true;
            chbDeterm.Enabled = true;
            if (chbDeterm.Checked)
                dtpAPPROX.Enabled = false;
            else
                dtpAPPROX.Enabled = true;
            bPurchMat.Enabled = false;
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

            /*DBWPName dbwp = new DBWPName();
            cbWPNAME.ValueMember = "ID";
            cbWPNAME.DisplayMember = "WPNAME";
            cbWPNAME.DataSource = dbwp.GetAllWPNames();
            cbWPNAME.SelectedValue = SVO.IDWPNAME;*/

            DBPacking dbp = new DBPacking();
            cbPacking.ValueMember = "ID";
            cbPacking.DisplayMember = "PNAME";
            cbPacking.DataSource = dbp.GetAll();
            cbPacking.SelectedValue = SVO.IDPACKING;

            DBMountingKit dbmk = new DBMountingKit();
            cbMountingKit.ValueMember = "ID";
            cbMountingKit.DisplayMember = "MOUNTINGKITNAME";
            cbMountingKit.DataSource = dbmk.GetAllDBMountingKitNames();
            cbMountingKit.SelectedValue = SVO.IDMOUNTINGKIT;

            tbCONTRACT.Text = SVO.CONTRACT;
            tbDELIVERY.Text = SVO.DELIVERY;
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
            tbStatus.Text = SVO.STATUSNAME;
            tbSubStatus.Text = SVO.SUBSTATUSNAME;
            UIProc ui = new UIProc();
            ui.LoadExtCables(dgv, this.IDSUMMON.ToString());

            summonNotes1.Init(SVO.ID, UVO, SVO);
            summonNotes1.Reload();

            summonTransfer1.Init(SVO, UVO, this);
            if (SVO.WPNAMEVO.IDCat == 4)
                summonTransfer2.Visible = false;
            summonTransfer2.InitSub(SVO, UVO, this);

            pathFileds1.Init(SVO, UVO);
            //pfSHILD.Init(SVO.SHILD, SVO.SHILDREQ, false, true, false);
            //pfPLANKA.Init(SVO.PLANKA, SVO.PLANKAREQ, false, true, false);
            //pf3D.Init(SVO.SBORKA3D, SVO.SBORKA3DREQ, false, true, false);
            //pfZHGUT.Init(SVO.ZHGUT, false, false, false, false);
            //pfSERIAL.Init(SVO.SERIAL, SVO.SERIALREQ, false, true, false);
            //pfCOMPOSITION.Init(SVO.COMPOSITION, SVO.COMPOSITIONREQ, false, true, false);
            //pfCOMPOSITION.ValueFromArchive = true;
            //pfMETAL.Init(SVO.METAL, SVO.METALREQ, false, true, false);
            pfMETAL.IsPath = true;


            DBPURCHASEDMATERIALS dbpm = new DBPURCHASEDMATERIALS();
            PurchMaterials pm = dbpm.Get(SVO.ID);
            chbShildOrdered.Checked = pm.SHILDORDERED;

        }

        private void cbCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            Close();
            
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
                tbTECHREQPATH.Text = dialog.FileName.Substring(dialog.FileName.LastIndexOf(@"\") + 1); ;
                tbTECHREQPATH.Tag = dialog.FileName;
            }
        }

        private void button1_Click(object sender, EventArgs e)//просто сохранить
        {
            if (tbQUANTITY.Value == 0)
            {
                MessageBox.Show("Введите количество изделий!");
                return;
            }
            DBSummon dbs = new DBSummon();
            SummonVO SVO = new SummonVO();
            SVO = SummonVO.SummonVOByIDS(this.IDS);

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
            SVO.IDMOUNTINGKIT = (int)cbMountingKit.SelectedValue;
            SVO.VIEWED = true;
            SVO.SHILD = pfSHILD.FullPath;//pathFileds1.bSHILDOpen.Tag.ToString();
            SVO.PLANKA = pfPLANKA.FullPath;//pathFileds1.bPLANKAOpen.Tag.ToString();
            SVO.SBORKA3D = pf3D.FullPath;//pathFileds1.b3DOpen.Tag.ToString();
            SVO.ZHGUT = pfZHGUT.FullPath;//pathFileds1.bZHGUTOpen.Tag.ToString();
            SVO.SERIAL = pfSERIAL.FullPath;//pathFileds1.bSERIALOpen.Tag.ToString();
            SVO.METAL = pfMETAL.FullPath;//pathFileds1.bMETALOpen.Tag.ToString();
            SVO.COMPOSITION = pfCOMPOSITION.FullPath;//pathFileds1.bCOMPOSITIONOpen.Tag.ToString();
            SVO.SHILDREQ = pfSHILD.Required;//pathFileds1.chSHILD.Checked;
            SVO.PLANKAREQ = pfPLANKA.Required;//pathFileds1.chPLANKA.Checked;
            SVO.SBORKA3DREQ = pf3D.Required;//pathFileds1.ch3D.Checked;
            SVO.SERIALREQ = pfSERIAL.Required;//pathFileds1.chSERIAL.Checked;
            SVO.COMPOSITIONREQ = pfCOMPOSITION.Required;//pathFileds1.chCOMPOSITION.Checked;
            SVO.METALREQ = pfMETAL.Required;//pathFileds1.chMETAL.Checked;

            if (chbDeterm.Checked)
            {
                SVO.PASSDATE = null;
            }
            else
            {
                SVO.PASSDATE = dtpAPPROX.Value;
            }
            if (dtpApproxAtLoad != SVO.PASSDATE)
            {
                dbs.PassDateChanged(SVO.ID);
            }
            dbs.SaveSummon(SVO);

            //сохраняем заказные материалы
            DBPURCHASEDMATERIALS dbpm = new DBPURCHASEDMATERIALS();
            PurchMaterials pm = new PurchMaterials();
            pm = dbpm.Get(SVO.ID);
            pm.SHILDORDERED = chbShildOrdered.Checked;
            dbpm.Save(pm, SVO.ID);
            MessageBox.Show("Извещение успешно сохранено!");
            DisableAll();
        }

        private void bEdit_Click(object sender, EventArgs e)
        {
            if ((SVO.IDSTATUS != 2) && (SVO.IDSTATUS != 3) && (SVO.IDSTATUS != 17))
            {
                //MessageBox.Show("Вы не можете редактировать это извещение, так как не являетесь в данный момент ответственным лицом за это извещение!");
                MessageBox.Show("Вы можете редактировать только поле \"Шильды заказаны\", так как не являетесь в данный момент ответственным лицом за это извещение или оно пришло от монтажников!");
                //return;
                EnablebSHILDORDERED();

               // MessageBox.Show("Вы можете редактировать только поле \"Состав изделия\", так как не являетесь в данный момент ответственным лицом за это извещение!");
               // EnableComposition();

            }
            else
            {
                EnableAll();
            }
        }

        private void EnablebSHILDORDERED()
        {
            chbShildOrdered.Enabled = true;
            bEdit.Enabled = false;
            bSave.Enabled = true;
            bPurchMat.Enabled = false;

        }

        //private void EnableComposition()
        //{
        //    pathFileds1.bCOMPOSITION.Enabled = true;
        //    bSave.Enabled = true;
        //    bEdit.Enabled = false;

        //}


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


        private void button1_Click_3(object sender, EventArgs e)
        {
            fEditNotePDB fe = new fEditNotePDB(tbIDS.Text);
            fe.ShowDialog();
            DisableAll();
            LoadSummon();

        }

        private void ShowSummonOZIS_Load(object sender, EventArgs e)
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

            if ((SVO.IDSTATUS == 2) || (SVO.IDSTATUS == 3) || (SVO.IDSTATUS == 17))
            {
                dbs.SetViewed(this.IDSUMMON);
            }
            dbs.AddSummonView(SVO, UVO);
            dtpApproxAtLoad = SVO.PASSDATE;
            wpNameView1.Init(SVO.IDWPNAME);

        }
        private DateTime? dtpApproxAtLoad;

        private void tbTECHREQPATH_MouseClick(object sender, EventArgs e)
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

        private void button2_Click_1(object sender, EventArgs e)
        {
            if ((SVO.IDSTATUS != 3) && (SVO.IDSTATUS != 17))
            {
                MessageBox.Show("Вы не можете передать это извещение монтажникам, не являетесь в данный момент ответственным за это извещение!");
                return;
            }
            if (MessageBox.Show("Вы действительно хотите передать это извещение монтажникам?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            DBCurStatus dbcs = new DBCurStatus();
            SummonVO SVO_ = new SummonVO();
            SVO_.IDS = tbIDS.Text;
            dbcs.ChangeStatus(SVO_, 15, "", UVO.id);
            //MessageBox.Show("Извещение успешно возвращено в производство на доработку!");
            Close();
        }

        private void bAddPrivateNote_Click(object sender, EventArgs e)
        {
            fEditPrivateNote fepn = new fEditPrivateNote(SVO.ID, UVO.id);
            fepn.ShowDialog();

            DBPrivateNote dbpn = new DBPrivateNote();
            //tbPrivateNote.Text = dbpn.GetPrivateNote(UVO.id, SVO.ID);

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

        private void bPurchMat_Click(object sender, EventArgs e)
        {
            PurchasedMaterials fpm = new PurchasedMaterials(SVO.ID);
            fpm.ShowDialog();
        }

       
      

    

    }
}
