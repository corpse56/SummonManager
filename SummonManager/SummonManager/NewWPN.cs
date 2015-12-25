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
        public NewWPN()
        {
            InitializeComponent();
        }
        WPNameVO Clone;
        public NewWPN(WPNameVO clone)
        {
            InitializeComponent();
            if (clone.WPName != "")
            {
                this.Clone = clone;
                tbName.Text = clone.WPName;
                cbCategory.SelectedValue = clone.IDCat;
                tbDecNum.Text = clone.DecNum;
                tbPowerSupply.Text = clone.PowerSupply;
                tbConfiguration.Text = clone.Configuration;
                tbNote.Text = clone.Note;


                pfComposition.tbPath.Text = clone.Composition.Substring(clone.Composition.LastIndexOf("\\") + 1);
                pfComposition.tbPath.Tag = clone.Composition;

                pfDimDrawing.tbPath.Text = clone.DimenDrawing.Substring(clone.DimenDrawing.LastIndexOf("\\") + 1);
                pfDimDrawing.tbPath.Tag = clone.DimenDrawing;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (tbName.Text == "")
            {
                MessageBox.Show("Введите наименование!");
                return;
            }
            WPNameVO wp = new WPNameVO();
            wp.WPName = tbName.Text;
            wp.IDCat = Convert.ToInt32(cbCategory.SelectedValue);
            wp.DecNum = tbDecNum.Text;
            wp.Composition = pfComposition.tbPath.Tag.ToString();
            wp.DimenDrawing = pfDimDrawing.tbPath.Tag.ToString();
            wp.PowerSupply = tbPowerSupply.Text;
            wp.Configuration = tbConfiguration.Text;
            wp.Note = tbNote.Text;
            DBWPName dbwp = new DBWPName();
            dbwp.AddNewWP(wp);
            MessageBox.Show("Наименование успешно добавлено!");
            Close();
        }

        private void NewWPN_Load(object sender, EventArgs e)
        {
            DBCategory dbc = new DBCategory();
            cbCategory.ValueMember = "ID";
            cbCategory.DisplayMember = "CATEGORYNAME";
            cbCategory.DataSource = dbc.GetAllExceptAll();

            if (Clone.IDCat != 0)
            {
                cbCategory.SelectedValue = Clone.IDCat;
            }
            else
            {
                cbCategory.SelectedValue = 1;
            }

        }
    }
}
