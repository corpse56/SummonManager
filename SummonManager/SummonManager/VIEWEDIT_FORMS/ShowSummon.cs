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
    public partial class ShowSummon : Form
    {
        public SummonVO SVO;
        public IRole UVO;
        public ShowSummon(IRole uvo,SummonVO svo)
        {
            this.UVO = uvo;
            this.SVO = svo;
            InitializeComponent(); 
        }

        private void cbCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {
            DBCustomer dbc = new DBCustomer();
            cbCustDept.DataSource = dbc.GetDeptsByIDCustomer(cbCustomers.SelectedValue.ToString());

        }

        private void button1_Click(object sender, EventArgs e)//просто сохранить
        {

        }
        private void bSave_Click(object sender, EventArgs e)
        {
            UVO.SaveSummon(this);
            UVO.DisableAbsolute(this);
            UVO.EnableInitial(this);

        }
        private void bEdit_Click(object sender, EventArgs e)
        {
            UVO.EnableEdit(this);



        }


        private void chbDeterm_CheckedChanged(object sender, EventArgs e)
        {
            if (chbDeterm.Checked)
                dtpAPPROX.Enabled = false;
            else
                dtpAPPROX.Enabled = true;
        }


        public DateTime? dtpApproxAtLoad;

        private void ShowSummon_Load(object sender, EventArgs e)
        {
            UVO.ssLoad(this);

            DBCustomer dbc = new DBCustomer();
            cbCustDept.ValueMember = "ID";
            cbCustDept.DisplayMember = "DEPTNAME";
            cbCustDept.DataSource = dbc.GetDeptsByIDCustomer(cbCustomers.SelectedValue.ToString());
            cbCustDept.SelectedValue = SVO.IDCUSTOMERDEPT;

            DBSummon dbs = new DBSummon();
            dbs.AddSummonView(SVO, UVO);
            dtpApproxAtLoad = SVO.PASSDATE;

            wpNameView1.Init(SVO.IDWPNAME, SVO.WPTYPE, UVO, SVO);

            InitTableLayout();

            this.Text = "Просмотр извещения (" + UVO.GetRoleName() + ")";

            UVO.EnableInitial(this);

        }





        private void InitTableLayout()
        {
            tableLayoutPanel1.RowStyles.Clear();
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            //tableLayoutPanel1.RowStyles[0].Height = 40F;
            IProduct product = ProductFactory.Create(SVO.ProductVO.GetID(),SVO.WPTYPE);
            product.FillTableLayoutPanel(tableLayoutPanel1,UVO);
        }

        private void bPurchMat_Click(object sender, EventArgs e)
        {
            PurchasedMaterials fpm = new PurchasedMaterials(SVO.ID);
            fpm.ShowDialog();
        }

        private void bEditCustomers_Click(object sender, EventArgs e)
        {
            Customers c = new Customers();
            c.ShowDialog();
            DBCustomer dbc = new DBCustomer();
            cbCustomers.DataSource = dbc.GetAllCustomers();
            cbCustomers.SelectedValue = SVO.IDCUSTOMER;

            cbCustDept.DataSource = dbc.GetDeptsByIDCustomer(cbCustomers.SelectedValue.ToString());

        }

        private void bDelSummon_Click(object sender, EventArgs e)//админ
        {
            if ((SVO.IDSTATUS != 1) && (UVO.Role == Roles.Manager))
            {
                MessageBox.Show("Вы можете удалить извещение только со статусом \"Новое\"!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (MessageBox.Show("Вы действительно хотите удалить это извещение?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
                else
                {
                    DBSummon dbs = new DBSummon();
                    dbs.DeleteSummonByID(SVO.ID);
                    MessageBox.Show("Извещение успешно удалено!");
                    Close();
                }
            }
            if (UVO.Role == Roles.Admin)
            {
                if (MessageBox.Show("Вы действительно хотите удалить это извещение?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
                else
                {
                    DBSummon dbs = new DBSummon();
                    dbs.DeleteSummonByID(SVO.ID);
                    MessageBox.Show("Извещение успешно удалено!");
                    Close();
                }
            }
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

        private void bCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bEditWP_Click(object sender, EventArgs e)
        {
            IProduct pr = SVO.ProductVO;
            pr.ViewEdit(UVO);
            InitTableLayout();
        }




    }
}
