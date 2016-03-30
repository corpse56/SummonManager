﻿using System;
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
    public partial class ShowSummonOTK : Form
    {
        private DBSummon dbs;
        private SummonVO SVO;
        private string IDS;
        private string IDSUMMON;
        private IRole UVO;
        public ShowSummonOTK(string ids, IRole uvo, string idsummon)
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
            //pathFileds1.bPATH5.Enabled = false;
            //pathFileds1.chSERIAL.Enabled = false;
            //pathFileds1.bSerialDel.Enabled = false;
            pfSERIAL.Enabled = false;

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
            tbStatus.Enabled = false;
            tbSubStatus.Enabled = false;
        }
        private void EnableAll()
        {
            //pathFileds1.bPATH5.Enabled = true;
            //pathFileds1.chSERIAL.Enabled = true;
            //pathFileds1.bSerialDel.Enabled = true;
            pfSERIAL.Enabled = true;

            summonTransfer1.Enabled = false;
            bEdit.Enabled = false;
            bSave.Enabled = true;
            bPrint.Enabled = true;
            chbDeterm.Enabled = true;
            if (chbDeterm.Checked)
                dtpAPPROX.Enabled = false;
            else
                dtpAPPROX.Enabled = true;
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
            //tbTECHREQPATH.Text = SVO.TECHREQPATH.Substring(SVO.TECHREQPATH.LastIndexOf("\\") + 1);
            //tbTECHREQPATH.Tag = SVO.TECHREQPATH;
            dtpCREATED.Value = SVO.CREATED;
            dtpPTIME.Value = SVO.PTIME;
            tbPAYSTATUS.Text = SVO.PAYSTATUS;
            SVO.IDPACKING = (int)cbPacking.SelectedValue;

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


            summonNotes1.Init(SVO.ID, UVO, SVO);
            summonNotes1.Reload();
            summonTransfer1.Init(SVO, UVO, this);
            if ((SVO.ProductVO.GetProductType() == WPTYPE.CABLELIST) || (SVO.ProductVO.GetProductType() == WPTYPE.ZHGUTLIST))
            {
                summonTransfer2.Visible = false;
            }
            summonTransfer2.InitSub(SVO, UVO, this);

            //pathFileds1.Init(SVO, UVO);
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
            SVO.PTIME = dtpPTIME.Value;
            SVO.QUANTITY = (int)tbQUANTITY.Value;
            SVO.SHIPPING = tbSHIPPING.Text;
            if (cbSISP.SelectedIndex == 1)
                SVO.SISP = true;
            else
                SVO.SISP = false;
            //SVO.TECHREQPATH = tbTECHREQPATH.Tag.ToString();
            //SVO.WPNAME = cbWPNAME.Text;
            //SVO.IDWPNAME = (int)cbWPNAME.SelectedValue;
            SVO.IDACCEPT = (int)cbAccept.SelectedValue;
            SVO.IDPACKING = (int)cbPacking.SelectedValue;
            SVO.IDMOUNTINGKIT = (int)cbMountingKit.SelectedValue;
            SVO.VIEWED = true;

            //SVO.SHILD = pfSHILD.FullPath;
            //SVO.PLANKA = pfPLANKA.FullPath;
            //SVO.SBORKA3D = pf3D.FullPath;
            //SVO.ZHGUT = pfZHGUT.FullPath;
            //SVO.SERIAL = pfSERIAL.FullPath;
            //SVO.METAL = pfMETAL.FullPath;
            //SVO.COMPOSITION = pfCOMPOSITION.FullPath;
            //SVO.SHILDREQ = pfSHILD.Required;
            //SVO.PLANKAREQ = pfPLANKA.Required;
            //SVO.SBORKA3DREQ = pf3D.Required;
            //SVO.SERIALREQ = pfSERIAL.Required;
            //SVO.COMPOSITIONREQ = pfCOMPOSITION.Required;
            //SVO.METALREQ = pfMETAL.Required;
            
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
            //if ((SVO.SERIALREQ) && ((SVO.SERIAL == "") || (SVO.SERIAL == null)))
            //{
            //    Notification n = new Notification();
            //    n.IDNTYPE = "1";
            //    n.IDSUMMON = SVO.ID;
            //    DBNotification dbn = new DBNotification();
            //    dbn.AddNew(n);
            //}
            MessageBox.Show("Извещение успешно сохранено!");
            DisableAll();
        }
       
        

        private void bEdit_Click(object sender, EventArgs e)
        {

            if ((SVO.IDSTATUS != 7) && (SVO.IDSTATUS != 16))
            {
                //MessageBox.Show("Вы не можете редактировать это извещение, так как не являетесь в данный момент ответственным лицом за это извещение или оно пришло от монтажников!");
                MessageBox.Show("Вы можете редактировать только поле \"Серийные номера\", так как не являетесь в данный момент ответственным лицом за это извещение или оно пришло от монтажников!");
                //return;
                //EnablebPATH5();
                pfSERIAL.Enabled = true;
                bEdit.Enabled = false;
                bSave.Enabled = true;
            }
            else
            {
                EnableAll();
            }
        }

        private void bBack_Click(object sender, EventArgs e)
        {
            if (SVO.IDSTATUS != 7)
            {
                MessageBox.Show("Вы не можете вернуть в цех это извещение, так как не являетесь в данный момент ответственным лицом за это извещение или извещение пришло от монтажников!");
                return;
            }
            if (MessageBox.Show("Вы действительно хотите вернуть извещение на доработку?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            Cause c = new Cause();
            c.ShowDialog();
            if (!c.result)
            {
                return;
            }
            DBCurStatus dbcs = new DBCurStatus();
            SummonVO SVO_ = new SummonVO();
            SVO_.IDS = tbIDS.Text;
            dbcs.ChangeStatus(SVO_, 8, c.cause, UVO.id);
            //MessageBox.Show("Извещение успешно возвращено в производство на доработку!");
            Close();
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

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void ShowSummonOTK_Load(object sender, EventArgs e)
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

            if ((SVO.IDSTATUS == 2) || (SVO.IDSTATUS == 7) || (SVO.IDSTATUS == 16))
            {
                dbs.SetViewed(this.IDSUMMON);
            }

            dtpApproxAtLoad = SVO.PASSDATE;
            wpNameView1.Init(SVO.IDWPNAME, SVO.WPTYPE, UVO, SVO);

        }
        private DateTime? dtpApproxAtLoad;

        private void tbTECHREQPATH_MouseClick(object sender, MouseEventArgs e)
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

        private void button1_Click_2(object sender, EventArgs e)
        {
            if (SVO.IDSTATUS != 16)
            {
                MessageBox.Show("Вы не можете вернуть это извещение монтажникам, так как оно не от монтажников!");
                return;
            }
            if (MessageBox.Show("Вы действительно хотите вернуть это извещение монтажникам?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            Cause c = new Cause();
            c.ShowDialog();
            if (!c.result)
            {
                return;
            }

            DBCurStatus dbcs = new DBCurStatus();
            SummonVO SVO_ = new SummonVO();
            SVO_.IDS = tbIDS.Text;
            dbcs.ChangeStatus(SVO_, 18, c.cause, UVO.id);
            //MessageBox.Show("Извещение успешно возвращено в производство на доработку!");
            Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (SVO.IDSTATUS != 16)
            {
                MessageBox.Show("Вы не можете передать это извещение в ПДБ, так как оно не от монтажников!");
                return;
            }
            if (MessageBox.Show("Вы действительно хотите передать это извещение в ПДБ после монтажа?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            DBCurStatus dbcs = new DBCurStatus();
            SummonVO SVO_ = new SummonVO();
            SVO_.IDS = tbIDS.Text;
            dbcs.ChangeStatus(SVO_, 17, "", UVO.id);
            //MessageBox.Show("Извещение успешно возвращено в производство на доработку!");
            Close();
        }

   
    }
}
