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
    public partial class NewSummon : Form
    {
        private DBSummon dbs;
        private UserVO UVO;
        private int IDNEWSUMMON;
        public NewSummon(UserVO uvo)
        {
            InitializeComponent();
            this.UVO = uvo;
            dbs = new DBSummon();
            // tbIDS.Text = dbs.GetNextNumber();
            tbIDS.Text = "<не определено>";

            IDNEWSUMMON = dbs.AddNIPSummon();
            dtpCREATED.Value = DateTime.Now;

            cbSISP.SelectedIndex = 0;

            DBCustomer dbc = new DBCustomer();
            cbCustomers.ValueMember = "ID";
            cbCustomers.DisplayMember = "CNAME";
            cbCustomers.DataSource = dbc.GetAllCustomers();

            /*DBWPName dbwp = new DBWPName();
            cbWPNAME.ValueMember = "ID";
            cbWPNAME.DisplayMember = "WPNAME";
            cbWPNAME.DataSource = dbwp.GetAllWPNames();*/

            DBAccept dbacc = new DBAccept();
            cbAccept.ValueMember = "ID";
            cbAccept.DisplayMember = "ANAME";
            cbAccept.DataSource = dbacc.GetAllAccept();

            DBPacking dbp = new DBPacking();
            cbPacking.ValueMember = "ID";
            cbPacking.DisplayMember = "PNAME";
            cbPacking.DataSource = dbp.GetAll();

            //DBEXTCABLE dbec = new DBEXTCABLE();
            //cbExtCable.ValueMember = "ID";
            //cbExtCable.DisplayMember = "EXTCABLENAME";
            //cbExtCable.DataSource = dbec.GetAllEXTCABLENames();

            DBMountingKit dbmk = new DBMountingKit();
            cbMountingKit.ValueMember = "ID";
            cbMountingKit.DisplayMember = "MOUNTINGKITNAME";
            cbMountingKit.DataSource = dbmk.GetAllDBMountingKitNames();
            cbMountingKit.SelectedIndex = 0;

            tbTECHREQPATH.Text = "";
            tbTECHREQPATH.Tag = "";

            UIProc ui = new UIProc();
            ui.LoadExtCables(dgv, this.IDNEWSUMMON.ToString());
            //LoadExtCables();
        }
        private void NewSummon_Load(object sender, EventArgs e)
        {
            DBCustomer dbc = new DBCustomer();
            //cbCustomers.ValueMember = "ID";
            //cbCustomers.DisplayMember = "CNAME";
            //cbCustomers.DataSource = dbc.GetAllCustomers();

            cbCustDept.ValueMember = "ID";
            cbCustDept.DisplayMember = "DEPTNAME";
            cbCustDept.DataSource = dbc.GetDeptsByIDCustomer(cbCustomers.SelectedValue.ToString());

        
        }
        private void cbCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {
            DBCustomer dbc = new DBCustomer();
            cbCustDept.DataSource = dbc.GetDeptsByIDCustomer(cbCustomers.SelectedValue.ToString());

        }
        private void button2_Click(object sender, EventArgs e)
        {
            //NewCustomer nc = new NewCustomer();
            //nc.ShowDialog();
            Customers c = new Customers();
            c.ShowDialog();
            DBCustomer dbc = new DBCustomer();
            cbCustomers.DataSource = dbc.GetAllCustomers();

            cbCustDept.DataSource = dbc.GetDeptsByIDCustomer(cbCustomers.SelectedValue.ToString());
            //cbCustomers.SelectedValue = SVO.IDCUSTOMER;
        }



        private void bCancel_Click(object sender, EventArgs e)
        {
            DBEXTCABLE dbec = new DBEXTCABLE();
            dbec.RemoveAllEXTCABLEFromPackByID(this.IDNEWSUMMON.ToString());
            Close();
        }

        private void bAdd_Click(object sender, EventArgs e)
        {
            if (tbQUANTITY.Value == 0)
            {
                MessageBox.Show("Введите количество изделий!");
                return;
            }
            if (cbCustDept.Items.Count == 0)
            {
                MessageBox.Show("Необходиом добавить хотя бы один отдел заказчика!");
                return;
            }
            if (MessageBox.Show("Вы действительно хотите сохранить и передать в ПДБ?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            DBSummon dbs = new DBSummon();
            SummonVO SVO = new SummonVO();
            SVO.ID = this.IDNEWSUMMON.ToString();
            SVO.IDS = dbs.GetNextNumber();
            SVO.ACCEPTANCE = cbAccept.Text;
            SVO.CONTRACT = tbCONTRACT.Text;
            SVO.CREATED = DateTime.Now;
            SVO.DELIVERY = tbDELIVERY.Text;
            SVO.IDCUSTOMER = cbCustomers.SelectedValue.ToString();
            SVO.PAYSTATUS = tbPAYSTATUS.Text;
            SVO.IDSTATUS = 2;
            SVO.NOTE = tbNote.Text;
            SVO.PTIME = dtpPTIME.Value;
            SVO.QUANTITY = (int)tbQUANTITY.Value;
            SVO.SHIPPING = tbSHIPPING.Text;
            if (cbSISP.SelectedIndex == 0)
                SVO.SISP = false;
            else
                SVO.SISP = true;
            SVO.TECHREQPATH = tbTECHREQPATH.Tag.ToString();
            SVO.WPNAME = pickWPName1.textBox1.Text;//cbWPNAME.Text;
            SVO.IDACCEPT = (int)cbAccept.SelectedValue;
            //SVO.IDWPNAME = (int)cbWPNAME.SelectedValue;
            SVO.IDWPNAME = pickWPName1.PickedID;
            SVO.IDPACKING = (int)cbPacking.SelectedValue;
            SVO.IDMOUNTINGKIT = (int)cbMountingKit.SelectedValue;
            SVO.IDCUSTOMERDEPT = (int)cbCustDept.SelectedValue;
            SVO.PASSDATE = null;
            SVO.VIEWED = false;
            SVO.NOTEPDB = "";
            SVO.SHILD = "";
            SVO.PLANKA = "";
            SVO.SBORKA3D = "";
            SVO.ZHGUT = "";
            SVO.SERIAL = "";
            SVO.METAL = "";
            SVO.COMPOSITION = "";
            SVO.SHILDREQ = true;
            SVO.PLANKAREQ = true;
            SVO.SBORKA3DREQ = true;
            SVO.SERIALREQ = true;
            SVO.COMPOSITIONREQ = true;
            SVO.METALREQ = true;
            SVO.DOCSREADY = false;
            SVO.BILLPAYED = false;
            dbs.AddNewSummon(SVO,UVO);
            alow_delete_cablepack = false;
            //MessageBox.Show("Извещение успешно создано и передано в ОЗиС!");
            this.Close();
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

        private void bSave_Click(object sender, EventArgs e)
        {

            if (tbQUANTITY.Value == 0)
            {
                MessageBox.Show("Введите количество изделий!");
                return;
            }
            if (cbCustDept.Items.Count == 0)
            {
                MessageBox.Show("Необходиом добавить хотя бы один отдел заказчика!");
                return;
            }
            DBSummon dbs = new DBSummon();
            SummonVO SVO = new SummonVO();
            SVO.ID = this.IDNEWSUMMON.ToString();
            SVO.IDS = dbs.GetNextNumber();
            SVO.ACCEPTANCE = cbAccept.Text;
            SVO.CONTRACT = tbCONTRACT.Text;
            SVO.CREATED = DateTime.Now;
            SVO.DELIVERY = tbDELIVERY.Text;
            SVO.IDCUSTOMER = cbCustomers.SelectedValue.ToString();
            SVO.PAYSTATUS = tbPAYSTATUS.Text;
            SVO.IDSTATUS = 1;
            SVO.NOTE = tbNote.Text;
            SVO.PTIME = dtpPTIME.Value;
            SVO.QUANTITY = (int)tbQUANTITY.Value;
            SVO.SHIPPING = tbSHIPPING.Text;
            if (cbSISP.SelectedIndex == 0)
                SVO.SISP = false;
            else
                SVO.SISP = true;
            SVO.TECHREQPATH = tbTECHREQPATH.Tag.ToString();
            SVO.WPNAME = pickWPName1.textBox1.Text;//cbWPNAME.Text;
            SVO.IDACCEPT = (int)cbAccept.SelectedValue;
            //SVO.IDWPNAME = (int)cbWPNAME.SelectedValue;
            SVO.IDWPNAME = pickWPName1.PickedID;
            SVO.IDPACKING = (int)cbPacking.SelectedValue;
            //SVO.IDEXTCABLE = (int)cbExtCable.SelectedValue;
            SVO.IDMOUNTINGKIT = (int)cbMountingKit.SelectedValue;
            SVO.IDCUSTOMERDEPT = (int)cbCustDept.SelectedValue;
            SVO.VIEWED = true;
            SVO.NOTEPDB = "";
            SVO.SHILD = "";
            SVO.PLANKA = "";
            SVO.SBORKA3D = "";
            SVO.ZHGUT = "";
            SVO.SERIAL = "";
            SVO.METAL = "";
            SVO.COMPOSITION = "";
            SVO.SHILDREQ = true;
            SVO.PLANKAREQ = true;
            SVO.SBORKA3DREQ = true;
            SVO.SERIALREQ = true;
            SVO.COMPOSITIONREQ = true;
            SVO.METALREQ = true;
            SVO.BILLPAYED = false;
            SVO.DOCSREADY = false;
            if (chbDeterm.Checked)
                SVO.PASSDATE = null;
            else
                SVO.PASSDATE = dtpAPPROX.Value;

            dbs.SaveNewSummon(SVO,UVO);
            tbIDS.Text = SVO.IDS;
            MessageBox.Show("Извещение успешно создано! Извещению присвоен номер: "+SVO.IDS);
            alow_delete_cablepack = false;
            this.Close();
        }
        bool alow_delete_cablepack = true;
        private void chbDeterm_CheckedChanged(object sender, EventArgs e)
        {
            if (chbDeterm.Checked)
                dtpAPPROX.Enabled = false;
            else
                dtpAPPROX.Enabled = true;

        }


        private void bEditExtCablePack_Click(object sender, EventArgs e)
        {
            fEditExtCablePack fecp = new fEditExtCablePack(this.IDNEWSUMMON.ToString());
            fecp.ShowDialog();
            UIProc ui = new UIProc();
            ui.LoadExtCables(dgv, this.IDNEWSUMMON.ToString());

//            LoadExtCables();
        }

        private void NewSummon_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (alow_delete_cablepack)
            {
                DBEXTCABLE dbec = new DBEXTCABLE();
                dbec.RemoveAllEXTCABLEFromPackByID(this.IDNEWSUMMON.ToString());
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
