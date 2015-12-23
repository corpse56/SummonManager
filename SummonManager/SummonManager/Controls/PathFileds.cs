using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace SummonManager
{
    public partial class PathFileds : UserControl
    {
        public PathFileds()
        {
            InitializeComponent();
        }
        SummonVO SVO;
        UserVO UVO;
        public void Init(SummonVO SVO_, UserVO UVO_)
        {
            this.SVO = SVO_;
            this.UVO = UVO_;

            tbSHILD.Text = SVO.SHILD.Substring(SVO.SHILD.LastIndexOf("\\") + 1);
            tbSHILD.Tag = SVO.SHILD;
            tbPLANKA.Text = SVO.PLANKA.Substring(SVO.PLANKA.LastIndexOf("\\") + 1);
            tbPLANKA.Tag = SVO.PLANKA;
            tb3D.Text = SVO.SBORKA3D.Substring(SVO.SBORKA3D.LastIndexOf("\\") + 1);
            tb3D.Tag = SVO.SBORKA3D;
            tbZhgut.Text = SVO.ZHGUT.Substring(SVO.ZHGUT.LastIndexOf("\\") + 1);
            tbZhgut.Tag = SVO.ZHGUT;
            tbSer.Text = SVO.SERIAL.Substring(SVO.SERIAL.LastIndexOf("\\") + 1);
            tbSer.Tag = SVO.SERIAL;
            tbCOMPOSITION.Text = SVO.COMPOSITION.Substring(SVO.COMPOSITION.LastIndexOf("\\") + 1);
            tbCOMPOSITION.Tag = SVO.COMPOSITION;
            tbMETAL.Text = SVO.METAL.Substring(SVO.METAL.LastIndexOf("\\") + 1);
            tbMETAL.Tag = SVO.METAL;

            chSHILD.Checked = SVO.SHILDREQ;
            chPLANKA.Checked = SVO.PLANKAREQ;
            ch3D.Checked = SVO.SBORKA3DREQ;
            chCOMPOSITION.Checked = SVO.COMPOSITIONREQ;
            chMETAL.Checked = SVO.METALREQ;
            chSERIAL.Checked = SVO.SERIALREQ;

            //if (UVO_.Role != Roles.Constructor)
            {
                bPATH1.Enabled = false;
                bPATH2.Enabled = false;
                bPATH3.Enabled = false;
                bPATH4.Enabled = false;
                bPATH5.Enabled = false;
                bMETAL.Enabled = false;
                bCOMPOSITION.Enabled = false;

                bShildDel.Enabled = false;
                bPlankaDel.Enabled = false;
                b3DDel.Enabled = false;
                bZhgutDel.Enabled = false;
                bSerialDel.Enabled = false;
                bCompositionDel.Enabled = false;
                bMetalDel.Enabled = false;

            }
            //switch (UVO.Role)
            //{
            //    case Roles.OTK:
            //        chSHILD.Enabled = false;
            //        chPLANKA.Enabled = false;
            //        ch3D.Enabled = false;
            //        chCOMPOSITION.Enabled = false;
            //        chMETAL.Enabled = false;
            //        chSERIAL.Enabled = true;
            //        break;
            //    case Roles.Constructor:
            //        chSHILD.Enabled = true;
            //        chPLANKA.Enabled = true;
            //        ch3D.Enabled = true;
            //        chCOMPOSITION.Enabled = false;
            //        chMETAL.Enabled = true;
            //        chSERIAL.Enabled = false;
            //        break;
            //    default:
                    chSHILD.Enabled = false;
                    chPLANKA.Enabled = false;
                    ch3D.Enabled = false;
                    chCOMPOSITION.Enabled = false;
                    chMETAL.Enabled = false;
                    chSERIAL.Enabled = false;
            //        break;

            //}

        }

        private void bPATH1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "All files (*.*)|*.*";
            //dialog.InitialDirectory = @"\\10.177.150.135\server\поездки\карта";
            dialog.InitialDirectory = @"c:\";
            dialog.Title = "Выберите файл";
            dialog.Multiselect = false;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                tbSHILD.Text = dialog.FileName.Substring(dialog.FileName.LastIndexOf(@"\") + 1); ;
                tbSHILD.Tag = dialog.FileName;
            }
        }

        private void bPATH2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "All files (*.*)|*.*";
            //dialog.InitialDirectory = @"\\10.177.150.135\server\поездки\карта";
            dialog.InitialDirectory = @"c:\";
            dialog.Title = "Выберите файл";
            dialog.Multiselect = false;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                tbPLANKA.Text = dialog.FileName.Substring(dialog.FileName.LastIndexOf(@"\") + 1); ;
                tbPLANKA.Tag = dialog.FileName;
            }
        }

        private void bPATH3_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "All files (*.*)|*.*";
            //dialog.InitialDirectory = @"\\10.177.150.135\server\поездки\карта";
            dialog.InitialDirectory = @"c:\";
            dialog.Title = "Выберите файл";
            dialog.Multiselect = false;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                tb3D.Text = dialog.FileName.Substring(dialog.FileName.LastIndexOf(@"\") + 1); ;
                tb3D.Tag = dialog.FileName;
            }
        }
        private void bPATH4_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "All files (*.*)|*.*";
            //dialog.InitialDirectory = @"\\10.177.150.135\server\поездки\карта";
            dialog.InitialDirectory = @"c:\";
            dialog.Title = "Выберите файл";
            dialog.Multiselect = false;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                tbZhgut.Text = dialog.FileName.Substring(dialog.FileName.LastIndexOf(@"\") + 1); ;
                tbZhgut.Tag = dialog.FileName;
            }
        }
        private void bPATH5_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "All files (*.*)|*.*";
            //dialog.InitialDirectory = @"\\10.177.150.135\server\поездки\карта";
            dialog.InitialDirectory = @"c:\";
            dialog.Title = "Выберите файл";
            dialog.Multiselect = false;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                tbSer.Text = dialog.FileName.Substring(dialog.FileName.LastIndexOf(@"\") + 1); ;
                tbSer.Tag = dialog.FileName;
            }
        }
        private void tbSHILD_Click(object sender, EventArgs e)
        {
            if (tbSHILD.Tag != null)
            {
                if (tbSHILD.Tag.ToString() != "")
                {
                    Process.Start(@"explorer.exe", @"/select, " + tbSHILD.Tag.ToString());
                }
            }
        }

        private void tbPLANKA_Click(object sender, EventArgs e)
        {
            if (tbPLANKA.Tag != null)
            {
                if (tbPLANKA.Tag.ToString() != "")
                {
                    Process.Start(@"explorer.exe", @"/select, " + tbPLANKA.Tag.ToString());
                }
            }
        }


        private void tbSHILD_MouseEnter(object sender, EventArgs e)
        {
            tbSHILD.ForeColor = Color.Blue;

        }

        private void tbPLANKA_MouseEnter(object sender, EventArgs e)
        {
            tbPLANKA.ForeColor = Color.Blue;

        }

        private void tb3D_MouseEnter(object sender, EventArgs e)
        {
            tb3D.ForeColor = Color.Blue;

        }

        private void tbSHILD_MouseLeave(object sender, EventArgs e)
        {
            tbSHILD.ForeColor = Color.Black;

        }

        private void tbPLANKA_MouseLeave(object sender, EventArgs e)
        {
            tbPLANKA.ForeColor = Color.Black;

        }

        private void tb3D_MouseLeave(object sender, EventArgs e)
        {
            tb3D.ForeColor = Color.Black;

        }



        private void tbZhgut_Click(object sender, EventArgs e)
        {
            if (tbZhgut.Tag != null)
            {
                if (tbZhgut.Tag.ToString() != "")
                {
                    Process.Start(@"explorer.exe", @"/select, " + tbZhgut.Tag.ToString());
                }
            }
        }

        private void tbSer_Click(object sender, EventArgs e)
        {
            if (tbSer.Tag != null)
            {
                if (tbSer.Tag.ToString() != "")
                {
                    Process.Start(@"explorer.exe", @"/select, " + tbSer.Tag.ToString());
                }
            }
        }

        private void tbZhgut_MouseEnter(object sender, EventArgs e)
        {
            tbZhgut.ForeColor = Color.Blue;

        }

        private void tbZhgut_MouseLeave(object sender, EventArgs e)
        {
            tbZhgut.ForeColor = Color.Black;

        }

        private void tbSer_MouseEnter(object sender, EventArgs e)
        {
            tbSer.ForeColor = Color.Blue;

        }

        private void tbSer_MouseLeave(object sender, EventArgs e)
        {
            tbSer.ForeColor = Color.Black;

        }

        private void tbCOMPOSITION_Click(object sender, EventArgs e)
        {
            if (tbCOMPOSITION.Tag != null)
            {
                if (tbCOMPOSITION.Tag.ToString() != "")
                {
                    Process.Start(@"explorer.exe", @"/select, " + tbCOMPOSITION.Tag.ToString());
                }
            }
        }

        private void tbCOMPOSITION_MouseEnter(object sender, EventArgs e)
        {
            tbCOMPOSITION.ForeColor = Color.Blue;

        }

        private void tbCOMPOSITION_MouseLeave(object sender, EventArgs e)
        {
            tbCOMPOSITION.ForeColor = Color.Black;

        }

        private void bCOMPOSITION_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "All files (*.*)|*.*";
            //dialog.InitialDirectory = @"\\10.177.150.135\server\поездки\карта";
            dialog.InitialDirectory = @"c:\";
            dialog.Title = "Выберите файл";
            dialog.Multiselect = false;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                tbCOMPOSITION.Text = dialog.FileName.Substring(dialog.FileName.LastIndexOf(@"\") + 1); ;
                tbCOMPOSITION.Tag = dialog.FileName;
            }
        }

        private void tbMETAL_Click(object sender, EventArgs e)
        {
            if (tbMETAL.Tag != null)
            {
                if (tbMETAL.Tag.ToString() != "")
                {
                    //Process.Start(@"explorer.exe", @"/select, " + tbMETAL.Tag.ToString());
                    Process.Start(@"explorer.exe", @tbMETAL.Tag.ToString());
                }
            }
        }

        private void tbMETAL_MouseEnter(object sender, EventArgs e)
        {
            tbMETAL.ForeColor = Color.Blue;

        }

        private void tbMETAL_MouseLeave(object sender, EventArgs e)
        {
            tbMETAL.ForeColor = Color.Black;

        }

        private void bMETAL_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "Выберите директорию с составом металла";
            dialog.SelectedPath = @"X:\Fileserver\Конструкторский отдел\ЗАКАЗ МЕТАЛЛА";
            //dialog.SelectedPath = @"G:\torrent\харламов\ХАРЛАМОВ Листья";
            SendKeys.Send("{TAB}{TAB}{DOWN}{DOWN}{UP}{UP}");
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                DirectoryInfo di = new DirectoryInfo(dialog.SelectedPath);
                string str = di.Name;
                tbMETAL.Text = di.Name; ;
                //tbMETAL.Text = dialog.SelectedPath.Substring(dialog.SelectedPath.LastIndexOf(@"\") + 1); ;
                tbMETAL.Tag = dialog.SelectedPath;
            }
        }
        private void tb3D_Click(object sender, EventArgs e)
        {
            if (tb3D.Tag != null)
            {
                if (tb3D.Tag.ToString() != "")
                {
                    Process.Start(@"explorer.exe", @"/select, " + tb3D.Tag.ToString());
                    //Process.Start(@"explorer.exe", @tb3D.Tag.ToString());
                }
            }
        }

        private void chSHILD_CheckedChanged(object sender, EventArgs e)
        {
            
            //bPATH1.Enabled = chSHILD.Checked;

        }

        private void chPLANKA_CheckedChanged(object sender, EventArgs e)
        {
            //bPATH2.Enabled = chPLANKA.Checked;
        }

        private void ch3D_CheckedChanged(object sender, EventArgs e)
        {
            //bPATH3.Enabled = ch3D.Checked;
        }

        private void chSERIAL_CheckedChanged(object sender, EventArgs e)
        {
            //bPATH5.Enabled = chSERIAL.Checked;
        }

        private void chCOMPOSITION_CheckedChanged(object sender, EventArgs e)
        {
           // bCOMPOSITION.Enabled = chCOMPOSITION.Checked;
        }

        private void chMETAL_CheckedChanged(object sender, EventArgs e)
        {
            //bMETAL.Enabled = chMETAL.Checked;
        }

        private void bShildDel_Click(object sender, EventArgs e)
        {
            tbSHILD.Tag = "";
            tbSHILD.Text = "";
        }

        private void bPlankaDel_Click(object sender, EventArgs e)
        {
            tbPLANKA.Tag = "";
            tbPLANKA.Text = "";
        }

        private void b3DDel_Click(object sender, EventArgs e)
        {
            tb3D.Tag = "";
            tb3D.Text = "";
        }

        private void bZhgutDel_Click(object sender, EventArgs e)
        {
            tbZhgut.Tag = "";
            tbZhgut.Text = "";
        }

        private void bSerialDel_Click(object sender, EventArgs e)
        {
            tbSer.Tag = "";
            tbSer.Text = "";
        }

        private void bCompositionDel_Click(object sender, EventArgs e)
        {
            tbCOMPOSITION.Tag = "";
            tbCOMPOSITION.Text = "";
        }

        private void bMetalDel_Click(object sender, EventArgs e)
        {
            tbMETAL.Tag = "";
            tbMETAL.Text = "";
        }



    }
}
