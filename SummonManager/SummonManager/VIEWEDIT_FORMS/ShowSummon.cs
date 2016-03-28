using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using SummonManager.CLASSES;

namespace SummonManager
{
    public partial class ShowSummon : Form
    {
        private DBSummon dbs;
        private SummonVO SVO;
        private string IDS;
        private UserVO UVO;
        public ShowSummon(UserVO uvo,SummonVO svo)
        {
            this.UVO = uvo;
            this.SVO = svo;
            InitializeComponent();

            LoadSummon();
            DisableAll();
        }

        private void DisableAll()
        {
            

            summonTransfer1.Enabled = true;
            tbQUANTITY.ReadOnly = true;
            dtpPTIME.Enabled = false;
            tbSHIPPING.ReadOnly = true;
            cbAccept.ReadOnly = true;
            cbAccept.DropDownStyle = ComboBoxStyle.DropDown;
            tbCONTRACT.ReadOnly = true;
            tbDELIVERY.ReadOnly = true;
            cbCustomers.DropDownStyle = ComboBoxStyle.DropDown;
            cbCustomers.ReadOnly = true;
            tbPayStatus.ReadOnly = true;
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
            cbCustDept.ReadOnly = true;
        }
        private void EnableAll()
        {
            summonTransfer1.Enabled = false;
            tbQUANTITY.ReadOnly = false;
            dtpPTIME.Enabled = true;
            tbSHIPPING.ReadOnly = false;
            cbAccept.ReadOnly = false;
            cbAccept.DropDownStyle = ComboBoxStyle.DropDownList;
            tbCONTRACT.ReadOnly = false;
            tbDELIVERY.ReadOnly = false;
            cbCustomers.ReadOnly = false;
            cbCustomers.DropDownStyle = ComboBoxStyle.DropDownList;
            tbPayStatus.ReadOnly = false;
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
            cbMountingKit.DropDownStyle = ComboBoxStyle.DropDownList;
            cbMountingKit.ReadOnly = false;
            cbCustDept.ReadOnly = false;                
        }

        private void LoadSummon()
        {
            //SVO = SummonVO.SummonVOByID(SVO.ID);

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
            dtpCREATED.Value = SVO.CREATED;
            dtpPTIME.Value = SVO.PTIME;
            tbPayStatus.Text = SVO.PAYSTATUS;
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

            //DBPrivateNote dbpn = new DBPrivateNote();
            //tbPrivateNote.Text = dbpn.GetPrivateNote(UVO.id, SVO.ID);

            summonNotes1.Init(SVO.ID, UVO, SVO);
            summonNotes1.Reload();

            summonTransfer1.Init(SVO, UVO,this);


        }

        

        private void cbCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {
            DBCustomer dbc = new DBCustomer();
            cbCustDept.DataSource = dbc.GetDeptsByIDCustomer(cbCustomers.SelectedValue.ToString());

        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            Close();

        }


        private void button1_Click(object sender, EventArgs e)//просто сохранить
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
            SVO = SummonVO.SummonVOByID(this.SVO.ID);
            SVO.ID = this.SVO.ID;
            SVO.IDS = tbIDS.Text;
            SVO.ACCEPTANCE = cbAccept.Text;
            SVO.CONTRACT = tbCONTRACT.Text;
            SVO.CREATED = this.SVO.CREATED;
            SVO.DELIVERY = tbDELIVERY.Text;
            SVO.IDCUSTOMER = cbCustomers.SelectedValue.ToString();
            SVO.IDCUSTOMERDEPT = (int)cbCustDept.SelectedValue;
            SVO.PAYSTATUS = tbPayStatus.Text;
            SVO.IDSTATUS = 1;
            SVO.PTIME = dtpPTIME.Value;
            SVO.QUANTITY = (int)tbQUANTITY.Value;
            SVO.SHIPPING = tbSHIPPING.Text;
            if (cbSISP.SelectedIndex == 0)
                SVO.SISP = false;
            else
                SVO.SISP = true;
            //SVO.TECHREQPATH = tbTECHREQPATH.Tag.ToString();
            SVO.IDACCEPT = (int)cbAccept.SelectedValue;
            SVO.IDPACKING = (int)cbPacking.SelectedValue;
            SVO.IDMOUNTINGKIT = (int)cbMountingKit.SelectedValue;
            if (chbDeterm.Checked)
            {
                SVO.PASSDATE = null;
            }
            else
            {
                SVO.PASSDATE = dtpAPPROX.Value;
            }

            dbs.SaveSummon(SVO);
            if (dtpApproxAtLoad != SVO.PASSDATE)
            {
                dbs.PassDateChanged(SVO.ID);
            }
            dbs.AddSummonView(SVO, UVO);
            MessageBox.Show("Извещение успешно сохранено!");
            DisableAll();
        }

        private void bEdit_Click(object sender, EventArgs e)
        {

            if ((SVO.IDSTATUS != 1) && (SVO.IDSTATUS != 11) && (SVO.IDSTATUS != 2))
            {
                MessageBox.Show("Вы не можете редактировать это извещение, так как не являетесь в данный момент ответственным лицом за это извещение!");
                //MessageBox.Show("Вы можете редактировать только поле \"Состав изделия\", так как не являетесь в данный момент ответственным лицом за это извещение!");
                 return;
                //EnableCOMPOSITION();

            }
            else
            {
                EnableAll();
            }
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

        private void button2_Click(object sender, EventArgs e)
        {
            Customers c = new Customers();
            c.ShowDialog();
            DBCustomer dbc = new DBCustomer();
            cbCustomers.DataSource = dbc.GetAllCustomers();
            cbCustomers.SelectedValue = SVO.IDCUSTOMER;

            cbCustDept.DataSource = dbc.GetDeptsByIDCustomer(cbCustomers.SelectedValue.ToString());

        }

        private void bDel_Click(object sender, EventArgs e)
        {
            DBSummon dbs = new DBSummon();
            SummonVO svo = dbs.GetSummonByIDS(tbIDS.Text);
            if (svo.IDSTATUS != 1)
            {
                MessageBox.Show("Вы можете удалить извещение только со статусом \"Новое\"!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show("Вы действительно хотите удалить это извещение?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (dr == DialogResult.No)
            {
                return;
            }
            string ids = tbIDS.Text;
            dbs.DeleteSummon(ids);
            MessageBox.Show("Извещение успешно удалено!");
            Close();

        }

        private DateTime? dtpApproxAtLoad;
        private void ShowSummon_Load(object sender, EventArgs e)
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
            if ((SVO.IDSTATUS == 1) ||(SVO.IDSTATUS == 11) ||(SVO.IDSTATUS == 2))
            {
                dbs.SetViewed(this.SVO.ID);
            }
            dbs.AddSummonView(SVO, UVO);
            dtpApproxAtLoad = SVO.PASSDATE;

            wpNameView1.Init(SVO.IDWPNAME, SVO.WPTYPE, UVO, SVO);

            InitTableLayout();

        }

        private void InitTableLayout()
        {
            tableLayoutPanel1.RowStyles[0].Height = 40F;
            IProduct product = ProductFactory.Create(SVO.ProductVO.GetID(),SVO.WPTYPE);
            product.FillTableLayoutPanel(tableLayoutPanel1,UVO);
        }




    }
}
