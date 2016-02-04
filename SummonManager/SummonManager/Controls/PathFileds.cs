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
using SummonManager.Properties;

namespace SummonManager
{
    public partial class PathFileds : UserControl
    {
//        bSHILDOpen
//bPLANKAOpen
//b3DOpen
//bZHGUTOpen
//bSERIALOpen
//bCOMPOSITIONOpen
//bMETALOpen
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

            //tbSHILD.Text = SVO.SHILD.Substring(SVO.SHILD.LastIndexOf("\\") + 1);
            bSHILDOpen.Tag = SVO.SHILD;
            
            //tbPLANKA.Text = SVO.PLANKA.Substring(SVO.PLANKA.LastIndexOf("\\") + 1);
            bPLANKAOpen.Tag = SVO.PLANKA;
            //tb3D.Text = SVO.SBORKA3D.Substring(SVO.SBORKA3D.LastIndexOf("\\") + 1);
            b3DOpen.Tag = SVO.SBORKA3D;
            //tbZhgut.Text = SVO.ZHGUT.Substring(SVO.ZHGUT.LastIndexOf("\\") + 1);
            bZHGUTOpen.Tag = SVO.ZHGUT;
            //tbSer.Text = SVO.SERIAL.Substring(SVO.SERIAL.LastIndexOf("\\") + 1);
            bSERIALOpen.Tag = SVO.SERIAL;
            //tbCOMPOSITION.Text = SVO.COMPOSITION.Substring(SVO.COMPOSITION.LastIndexOf("\\") + 1);
            bCOMPOSITIONOpen.Tag = SVO.COMPOSITION;
            //tbMETAL.Text = SVO.METAL.Substring(SVO.METAL.LastIndexOf("\\") + 1);
            bMETALOpen.Tag = SVO.METAL;
            SetIcons();
            if (SVO.SHILD == "")
            {
                bSHILDOpen.Image = Resources.document_open_disabled;
                bSHILDOpen.Text = "<нет>";
                bSHILDOpen.Enabled = false;
            }
            if (SVO.PLANKA == "")
            {
                bPLANKAOpen.Image = Resources.document_open_disabled;
                bPLANKAOpen.Text = "<нет>";
                bPLANKAOpen.Enabled = false;
            }


            chSHILD.Checked = SVO.SHILDREQ;
            chPLANKA.Checked = SVO.PLANKAREQ;
            ch3D.Checked = SVO.SBORKA3DREQ;
            chCOMPOSITION.Checked = SVO.COMPOSITIONREQ;
            chMETAL.Checked = SVO.METALREQ;
            chSERIAL.Checked = SVO.SERIALREQ;
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


           
            chSHILD.Enabled = false;
            chPLANKA.Enabled = false;
            ch3D.Enabled = false;
            chCOMPOSITION.Enabled = false;
            chMETAL.Enabled = false;
            chSERIAL.Enabled = false;

        }

        private void SetIcons()
        {
            if (bSHILDOpen.Tag.ToString() == "")
            {
                bSHILDOpen.Image = Resources.document_open_disabled;
                bSHILDOpen.Text = "<нет>";
                bSHILDOpen.Enabled = false;
            }
            else
            {
                bSHILDOpen.Image = Resources.document_open;
                bSHILDOpen.Text = "Открыть";
                bSHILDOpen.Enabled = true;
            }
            if (bPLANKAOpen.Tag.ToString() == "")
            {
                bPLANKAOpen.Image = Resources.document_open_disabled;
                bPLANKAOpen.Text = "<нет>";
                bPLANKAOpen.Enabled = false;
            }
            else
            {
                bPLANKAOpen.Image = Resources.document_open;
                bPLANKAOpen.Text = "Открыть";
                bPLANKAOpen.Enabled = true;
            }

            if (b3DOpen.Tag.ToString() == "")
            {
                b3DOpen.Image = Resources.document_open_disabled;
                b3DOpen.Text = "<нет>";
                b3DOpen.Enabled = false;
            }
            else
            {
                b3DOpen.Image = Resources.document_open;
                b3DOpen.Text = "Открыть";
                b3DOpen.Enabled = true;
            }
            if (bZHGUTOpen.Tag.ToString() == "")
            {
                bZHGUTOpen.Image = Resources.document_open_disabled;
                bZHGUTOpen.Text = "<нет>";
                bZHGUTOpen.Enabled = false;
            }
            else
            {
                bZHGUTOpen.Image = Resources.document_open;
                bZHGUTOpen.Text = "Открыть";
                bZHGUTOpen.Enabled = true;
            }
            if (bSERIALOpen.Tag.ToString() == "")
            {
                bSERIALOpen.Image = Resources.document_open_disabled;
                bSERIALOpen.Text = "<нет>";
                bSERIALOpen.Enabled = false;
            }
            else
            {
                bSERIALOpen.Image = Resources.document_open;
                bSERIALOpen.Text = "Открыть";
                bSERIALOpen.Enabled = true;
            }
            if (bCOMPOSITIONOpen.Tag.ToString() == "")
            {
                bCOMPOSITIONOpen.Image = Resources.document_open_disabled;
                bCOMPOSITIONOpen.Text = "<нет>";
                bCOMPOSITIONOpen.Enabled = false;
            }
            else
            {
                bCOMPOSITIONOpen.Image = Resources.document_open;
                bCOMPOSITIONOpen.Text = "Открыть";
                bCOMPOSITIONOpen.Enabled = true;
            }
            if (bMETALOpen.Tag.ToString() == "")
            {
                bMETALOpen.Image = Resources.document_open_disabled;
                bMETALOpen.Text = "<нет>";
                bMETALOpen.Enabled = false;
            }
            else
            {
                bMETALOpen.Image = Resources.document_open;
                bMETALOpen.Text = "Открыть";
                bMETALOpen.Enabled = true;
            }
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
                //tbSHILD.Text = dialog.FileName.Substring(dialog.FileName.LastIndexOf(@"\") + 1); ;
                bSHILDOpen.Tag = dialog.FileName;
                SetIcons();
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
                //tbPLANKA.Text = dialog.FileName.Substring(dialog.FileName.LastIndexOf(@"\") + 1); ;
                bPLANKAOpen.Tag = dialog.FileName;
                SetIcons();
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
                //tb3D.Text = dialog.FileName.Substring(dialog.FileName.LastIndexOf(@"\") + 1); ;
                b3DOpen.Tag = dialog.FileName;
                SetIcons();
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
                //tbZhgut.Text = dialog.FileName.Substring(dialog.FileName.LastIndexOf(@"\") + 1); ;
                bZHGUTOpen.Tag = dialog.FileName;
                SetIcons();
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
                //tbSer.Text = dialog.FileName.Substring(dialog.FileName.LastIndexOf(@"\") + 1); ;
                bSERIALOpen.Tag = dialog.FileName;
                SetIcons();
            }
        }
        private void tbSHILD_Click(object sender, EventArgs e)
        {
            
        }

        private void tbPLANKA_Click(object sender, EventArgs e)
        {
            
        }


        private void tbSHILD_MouseEnter(object sender, EventArgs e)
        {
            //tbSHILD.ForeColor = Color.Blue;

        }

        private void tbPLANKA_MouseEnter(object sender, EventArgs e)
        {
           // tbPLANKA.ForeColor = Color.Blue;

        }

        private void tb3D_MouseEnter(object sender, EventArgs e)
        {
          //  tb3D.ForeColor = Color.Blue;

        }

        private void tbSHILD_MouseLeave(object sender, EventArgs e)
        {
           // tbSHILD.ForeColor = Color.Black;

        }

        private void tbPLANKA_MouseLeave(object sender, EventArgs e)
        {
           // tbPLANKA.ForeColor = Color.Black;

        }

        private void tb3D_MouseLeave(object sender, EventArgs e)
        {
           // tb3D.ForeColor = Color.Black;

        }



        private void tbZhgut_Click(object sender, EventArgs e)
        {
           
        }

        private void tbSer_Click(object sender, EventArgs e)
        {
           
        }

        private void tbZhgut_MouseEnter(object sender, EventArgs e)
        {
           // tbZhgut.ForeColor = Color.Blue;

        }

        private void tbZhgut_MouseLeave(object sender, EventArgs e)
        {
           // tbZhgut.ForeColor = Color.Black;

        }

        private void tbSer_MouseEnter(object sender, EventArgs e)
        {
           // tbSer.ForeColor = Color.Blue;

        }

        private void tbSer_MouseLeave(object sender, EventArgs e)
        {
           // tbSer.ForeColor = Color.Black;

        }

        private void tbCOMPOSITION_Click(object sender, EventArgs e)
        {
            
        }

        private void tbCOMPOSITION_MouseEnter(object sender, EventArgs e)
        {
           // tbCOMPOSITION.ForeColor = Color.Blue;

        }

        private void tbCOMPOSITION_MouseLeave(object sender, EventArgs e)
        {
           // tbCOMPOSITION.ForeColor = Color.Black;

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
                //tbCOMPOSITION.Text = dialog.FileName.Substring(dialog.FileName.LastIndexOf(@"\") + 1); ;
                bCOMPOSITIONOpen.Tag = dialog.FileName;
                SetIcons();
            }
        }

        private void tbMETAL_Click(object sender, EventArgs e)
        {
            
        }

        private void tbMETAL_MouseEnter(object sender, EventArgs e)
        {
           // tbMETAL.ForeColor = Color.Blue;

        }

        private void tbMETAL_MouseLeave(object sender, EventArgs e)
        {
           // tbMETAL.ForeColor = Color.Black;

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
                //tbMETAL.Text = di.Name; ;
                //tbMETAL.Text = dialog.SelectedPath.Substring(dialog.SelectedPath.LastIndexOf(@"\") + 1); ;
                bMETALOpen.Tag = dialog.SelectedPath;
                SetIcons();
            }
        }
        private void tb3D_Click(object sender, EventArgs e)
        {
           
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
            bSHILDOpen.Tag = "";
            SetIcons();
            //tbSHILD.Text = "";
        }

        private void bPlankaDel_Click(object sender, EventArgs e)
        {
            bPLANKAOpen.Tag = "";
            SetIcons();
            //tbPLANKA.Text = "";
        }

        private void b3DDel_Click(object sender, EventArgs e)
        {
            b3DOpen.Tag = "";
            SetIcons();
            //tb3D.Text = "";
        }

        private void bZhgutDel_Click(object sender, EventArgs e)
        {
            bZHGUTOpen.Tag = "";
            SetIcons();
            //tbZhgut.Text = "";
        }

        private void bSerialDel_Click(object sender, EventArgs e)
        {
            bSERIALOpen.Tag = "";
            SetIcons();
            //tbSer.Text = "";
        }

        private void bCompositionDel_Click(object sender, EventArgs e)
        {
            bCOMPOSITIONOpen.Tag = "";
            SetIcons();
            //tbCOMPOSITION.Text = "";
        }

        private void bMetalDel_Click(object sender, EventArgs e)
        {
            bMETALOpen.Tag = "";
            SetIcons();
            //tbMETAL.Text = "";
        }

        private void bSHILDOpen_Click(object sender, EventArgs e)
        {
            if (bSHILDOpen.Tag != null)
            {
                if (bSHILDOpen.Tag.ToString() != "")
                {
                    Process.Start(@"explorer.exe", @"/select, " + bSHILDOpen.Tag.ToString());
                }
            }
        }

        private void bPLANKAOpen_Click(object sender, EventArgs e)
        {
            if (bPLANKAOpen.Tag != null)
            {
                if (bPLANKAOpen.Tag.ToString() != "")
                {
                    Process.Start(@"explorer.exe", @"/select, " + bPLANKAOpen.Tag.ToString());
                }
            }
        }

        private void b3DOpen_Click(object sender, EventArgs e)
        {
            if (b3DOpen.Tag != null)
            {
                if (b3DOpen.Tag.ToString() != "")
                {
                    Process.Start(@"explorer.exe", @"/select, " + b3DOpen.Tag.ToString());
                    //Process.Start(@"explorer.exe", @tb3D.Tag.ToString());
                }
            }
        }

        private void bZHGUTOpen_Click(object sender, EventArgs e)
        {
            if (bZHGUTOpen.Tag != null)
            {
                if (bZHGUTOpen.Tag.ToString() != "")
                {
                    Process.Start(@"explorer.exe", @"/select, " + bZHGUTOpen.Tag.ToString());
                }
            }
        }

        private void bSERIALOpen_Click(object sender, EventArgs e)
        {
            if (bSERIALOpen.Tag != null)
            {
                if (bSERIALOpen.Tag.ToString() != "")
                {
                    Process.Start(@"explorer.exe", @"/select, " + bSERIALOpen.Tag.ToString());
                }
            }
        }

        private void bCOMPOSITIONOpen_Click(object sender, EventArgs e)
        {
            if (bCOMPOSITIONOpen.Tag != null)
            {
                if (bCOMPOSITIONOpen.Tag.ToString() != "")
                {
                    Process.Start(@"explorer.exe", @"/select, " + bCOMPOSITIONOpen.Tag.ToString());
                }
            }
        }

        private void bMETALOpen_Click(object sender, EventArgs e)
        {
            if (bMETALOpen.Tag != null)
            {
                if (bMETALOpen.Tag.ToString() != "")
                {
                    //Process.Start(@"explorer.exe", @"/select, " + tbMETAL.Tag.ToString());
                    Process.Start(@"explorer.exe", bMETALOpen.Tag.ToString());
                }
            }
        }



    }
}
