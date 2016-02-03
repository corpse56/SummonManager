using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace SummonManager.Controls
{
    public partial class PathField : UserControl
    {
        public PathField()
        {
            InitializeComponent();
        }

        private void bPath_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "All files (*.*)|*.*";
            //dialog.InitialDirectory = @"\\10.177.150.135\server\поездки\карта";
            dialog.InitialDirectory = @"c:\";
            dialog.Title = "Выберите файл";
            dialog.Multiselect = false;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                //tbPath.Text = dialog.FileName.Substring(dialog.FileName.LastIndexOf(@"\") + 1); ;
                bOpen.Tag = dialog.FileName;
            }
        }

        private void tbPath_Click(object sender, EventArgs e)
        {

        }

        private void tbPath_MouseEnter(object sender, EventArgs e)
        {
            //tbPath.ForeColor = Color.Blue;
        }

        private void tbPath_MouseLeave(object sender, EventArgs e)
        {
           // tbPath.ForeColor = Color.Black;
        }

        private void bPathDel_Click(object sender, EventArgs e)
        {
            bOpen.Tag = "";
            //tbPath.Text = "";

        }

        private void tbPath_TextChanged(object sender, EventArgs e)
        {

        }

        private void bOpen_Click(object sender, EventArgs e)
        {
            if (bOpen.Tag != null)
            {
                if (bOpen.Tag.ToString() != "")
                {
                    Process.Start(@"explorer.exe", @bOpen.Tag.ToString());
                }
            }
        }

   





    }
}
