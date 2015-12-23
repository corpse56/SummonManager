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
    public partial class EditWPN : Form
    {
        int IDW;
        public EditWPN(int idw)
        {
            InitializeComponent();
            this.IDW = idw;
            DBWPName dbwp = new DBWPName();
            WPNameVO wp = dbwp.GetWP(this.IDW);
            tbName.Text = wp.WPName;
            cbCategory.SelectedValue = wp.IDCat;
            tbDecNum.Text = wp.DecNum;
            tbPowerSupply.Text = wp.PowerSupply;
            tbConfiguration.Text = wp.Configuration;
            tbNote.Text = wp.Note;

            //tbComposition.Text = wp.Composition.Substring(wp.Composition.LastIndexOf("\\") + 1);
            //tbComposition.Tag = wp.Composition;

            tbDimDraw.Text = wp.DimenDrawing.Substring(wp.DimenDrawing.LastIndexOf("\\") + 1);
            tbDimDraw.Tag = wp.DimenDrawing;

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

            DBWPName dbwp = new DBWPName();
            WPNameVO wp = new WPNameVO();
            wp.WPName = tbName.Text;
            wp.IDCat = Convert.ToInt32(cbCategory.SelectedValue);
            wp.DecNum = tbDecNum.Text;
            //wp.Composition = tbComposition.Tag.ToString();
            wp.DimenDrawing = tbDimDraw.Tag.ToString();
            wp.PowerSupply = tbPowerSupply.Text;
            wp.Configuration = tbConfiguration.Text;
            wp.Note = tbNote.Text;
            wp.ID = this.IDW;
            dbwp.EditWP(wp);
            MessageBox.Show("Наименование успешно изменено!");
            Close();
        }

        private void EditWPN_Load(object sender, EventArgs e)
        {
            DBCategory dbc = new DBCategory();
            cbCategory.ValueMember = "ID";
            cbCategory.DisplayMember = "CATEGORYNAME";
            cbCategory.DataSource = dbc.GetAll();

            DBWPName dbwp = new DBWPName();
            WPNameVO wp = dbwp.GetWP(this.IDW);

            cbCategory.SelectedValue = wp.IDCat;

        }


        private void bComposition_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "All files (*.*)|*.*";
            //dialog.InitialDirectory = @"\\10.177.150.135\server\поездки\карта";
            dialog.InitialDirectory = @"c:\";
            dialog.Title = "Выберите файл";
            dialog.Multiselect = false;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                //tbComposition.Text = dialog.FileName.Substring(dialog.FileName.LastIndexOf(@"\") + 1); ;
                //tbComposition.Tag = dialog.FileName;
            }
        }

        private void bDimDrawing_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "All files (*.*)|*.*";
            //dialog.InitialDirectory = @"\\10.177.150.135\server\поездки\карта";
            dialog.InitialDirectory = @"c:\";
            dialog.Title = "Выберите файл";
            dialog.Multiselect = false;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                tbDimDraw.Text = dialog.FileName.Substring(dialog.FileName.LastIndexOf(@"\") + 1); ;
                tbDimDraw.Tag = dialog.FileName;
            }
        }

        private void bCompositionDel_Click(object sender, EventArgs e)
        {
            //tbComposition.Tag = "";
            //tbComposition.Text = "";

        }

        private void bDimDrawingDel_Click(object sender, EventArgs e)
        {
            tbDimDraw.Tag = "";
            tbDimDraw.Text = "";

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }




    }
}
