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
using SummonManager.CLASSES.IRole_namespace;

namespace SummonManager
{
    public partial class ShowSummonDIR : Form
    {
        private DBSummon dbs;
        private SummonVO SVO;
        private string IDS;
        private string IDSUMMON;
        private IRole UVO;
        public ShowSummonDIR(string ids, IRole uvo, string idsummon)
        {
            InitializeComponent();
            this.UVO = uvo;
            this.IDS = ids;
            this.IDSUMMON = idsummon;
            LoadSummon();
            //DisableAll();

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
            SVO.PTIME = dtpPTIME.Value;
            SVO.QUANTITY = (int)tbQUANTITY.Value;
            SVO.SHIPPING = tbSHIPPING.Text;
            if (cbSISP.SelectedIndex == 1)
                SVO.SISP = true;
            else
                SVO.SISP = false;
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
            
            MessageBox.Show("Извещение успешно сохранено!");
            //DisableAll();
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

            dtpApproxAtLoad = SVO.PASSDATE;
            wpNameView1.Init(SVO.IDWPNAME, SVO.WPTYPE, UVO, SVO);

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }


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

        }












    }
}
