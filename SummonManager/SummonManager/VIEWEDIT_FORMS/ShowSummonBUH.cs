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
    public partial class ShowSummonBUH : Form
    {
        private DBSummon dbs;
        private SummonVO SVO;
        private string IDS;
        private string IDSUMMON;
        private UserVO UVO;
        public ShowSummonBUH(string ids,UserVO uvo,string idsummon)
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
            chbDocsRdy.Enabled = false;
            chbBillPayed.Enabled = false;
        }
        private void EnableAll()
        {
            bEdit.Enabled = false;
            bSave.Enabled = true;
            bPrint.Enabled = true;
            chbDocsRdy.Enabled = true;
            chbBillPayed.Enabled = true;

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
            chbBillPayed.Checked = SVO.BILLPAYED;
            chbDocsRdy.Checked = SVO.DOCSREADY;

            UIProc ui = new UIProc();
            ui.LoadExtCables(dgv, this.IDSUMMON.ToString());

            summonNotes1.Init(SVO.ID, UVO,SVO);
            summonNotes1.Reload();

            pathFileds1.Init(SVO,UVO);
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
            SVO = SummonVO.SummonVOByID(this.IDSUMMON);
            SVO.ID                  = this.IDSUMMON;
            SVO.IDS                 = tbIDS.Text;
            SVO.ACCEPTANCE          = cbAccept.Text;
            SVO.CONTRACT            = tbCONTRACT.Text;
            SVO.CREATED             = this.SVO.CREATED;
            SVO.DELIVERY            = tbDELIVERY.Text;
            SVO.IDCUSTOMER          = cbCustomers.SelectedValue.ToString();
            SVO.IDCUSTOMERDEPT      = (int)cbCustDept.SelectedValue;
            SVO.PAYSTATUS           = tbPAYSTATUS.Text;
            SVO.IDSTATUS            = 1;
            SVO.PTIME               = dtpPTIME.Value;
            SVO.QUANTITY            = (int)tbQUANTITY.Value;
            SVO.SHIPPING            = tbSHIPPING.Text;
            if (cbSISP.SelectedIndex == 1)
                SVO.SISP = true;
            else
                SVO.SISP = false;
            SVO.TECHREQPATH         = tbTECHREQPATH.Tag.ToString();
            //SVO.WPNAME              = cbWPNAME.Text;
            //SVO.IDWPNAME            = (int)cbWPNAME.SelectedValue;
            SVO.IDACCEPT            = (int)cbAccept.SelectedValue;
            SVO.IDPACKING           = (int)cbPacking.SelectedValue;
            SVO.IDMOUNTINGKIT       = (int)cbMountingKit.SelectedValue;
            SVO.VIEWED              = true;
            SVO.SHILD               = pathFileds1.tbSHILD.Tag.ToString();
            SVO.PLANKA              = pathFileds1.tbPLANKA.Tag.ToString();
            SVO.SBORKA3D            = pathFileds1.tb3D.Tag.ToString();
            SVO.ZHGUT = pathFileds1.tbZhgut.Tag.ToString();
            SVO.SERIAL = pathFileds1.tbSer.Tag.ToString();
            SVO.METAL = pathFileds1.tbMETAL.Tag.ToString();
            SVO.COMPOSITION = pathFileds1.tbCOMPOSITION.Tag.ToString();
            
            SVO.SHILDREQ = pathFileds1.chSHILD.Checked;
            SVO.PLANKAREQ = pathFileds1.chPLANKA.Checked;
            SVO.SBORKA3DREQ = pathFileds1.ch3D.Checked;
            SVO.SERIALREQ = pathFileds1.chSERIAL.Checked;
            SVO.COMPOSITIONREQ = pathFileds1.chCOMPOSITION.Checked;
            SVO.METALREQ = pathFileds1.chMETAL.Checked;

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
            SVO.BILLPAYED = chbBillPayed.Checked;
            SVO.DOCSREADY = chbDocsRdy.Checked;
            dbs.SaveSummon(SVO);
            MessageBox.Show("Извещение успешно сохранено!");
            DisableAll();
        }

        private void bEdit_Click(object sender, EventArgs e)
        {
            //if ((SVO.IDSTATUS != 9) && (SVO.IDSTATUS != 12))
            //{
            //    MessageBox.Show("Вы не можете редактировать это извещение, так как не являетесь в данный момент ответственным лицом за это извещение!");
            //    return;
            //}
            EnableAll();
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

        private void chbDeterm_CheckedChanged(object sender, EventArgs e)
        {
            if (chbDeterm.Checked)
                dtpAPPROX.Enabled = false;
            else
                dtpAPPROX.Enabled = true;
        }

        private void ShowSummonLOG_Load(object sender, EventArgs e)
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
            if (SVO.IDSTATUS == 12)
            {
                
                dbs.SetViewed(this.IDSUMMON);
            }
            dbs.AddSummonView(SVO, UVO);

            dtpApproxAtLoad = SVO.PASSDATE;
            wpNameView1.Init(SVO.IDWPNAME);

        }
        private DateTime? dtpApproxAtLoad;

       

        private void tbTECHREQPATH_MouseEnter(object sender, EventArgs e)
        {
            tbTECHREQPATH.ForeColor = Color.Blue;
        }

        private void tbTECHREQPATH_MouseLeave(object sender, EventArgs e)
        {
            tbTECHREQPATH.ForeColor = Color.Black;
        }

        private void tbTECHREQPATH_MouseClick(object sender, MouseEventArgs e)
        {

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

    }
}
