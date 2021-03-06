﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using SummonManager.Properties;
using System.IO;
using SummonManager.CLASSES.IRole_namespace;

namespace SummonManager.Controls
{
    public partial class PathField : UserControl
    {
        public string ACCESSMODE;
        public PathField()
        {
            InitializeComponent();
            //this.PATH = "<нет>";
            //tbPath.Text = "<нет>";
            PaintRed();
        }
        public void PaintRed()
        {
            if ((chRequired.Checked) && (tbPath.Text == "<нет>")
                && (this.CurrentRole == (Roles)this.Tag)
                || ((this.CurrentRole == Roles.SimpleInzhener) && ((Roles)this.Tag == Roles.Inzhener)))
            {
                tbPath.BackColor = Color.Tomato;
            }
            else
            {
                tbPath.BackColor = SystemColors.ControlLight;
            }
        }
        Roles ResposibleRole,CurrentRole;
        string tmpPATH = "<нет>";
        string PATH;
        public string FullPath
        {
            get { return this.PATH; }
            set 
            {
                if ((value == null) || (value.ToString() == ""))
                {
                    this.PATH = "<нет>";
                    tbPath.Text = "<нет>";
                }
                else
                {
                    this.PATH = value;
                    tbPath.Text = this.FileName;
                }
                PaintRed();
            }
        }
        public string FileName
        {
            get 
            {
                if ((this.PATH == "<нет>") || (this.PATH == null))
                {
                    return "<нет>";
                }
                else
                {
                    return this.PATH.Substring(this.PATH.LastIndexOf("\\") + 1);
                }
            }
        }
        bool EnabledPF = true;
        public new bool Enabled
        {
            get { return EnabledPF; }
            set
            {
                if (value)
                {
                    this.EnabledPF = value;
                    bPath.Enabled = true;
                    bPathDel.Enabled = true;
                    bPathDel.BackgroundImage = Resources.delete_ok;
                    //chRequired.Enabled = true;
                }
                else
                {
                    this.EnabledPF = value;
                    bPath.Enabled = false;
                    bPathDel.Enabled = false;
                    bPathDel.BackgroundImage = Resources.delete_disable;

                    if ((ACCESSMODE != "VIEWONLY") && (CurrentRole == Roles.Inzhener))
                    {
                        bPathDel.Enabled = true;
                        bPathDel.BackgroundImage = Resources.delete_ok;
                    }
                    //chRequired.Enabled = false;
                }
            }
        }
        bool REQ;
        public bool Required
        {
            get { return REQ; }
            set
            {
                this.REQ = value;
                chRequired.Checked = this.REQ;
                if ((ResposibleRole == CurrentRole) || (CurrentRole == Roles.Admin) || ((CurrentRole == Roles.SimpleInzhener) && (ResposibleRole == Roles.Inzhener)))
                {
                    this.Enabled = value;
                }
                if (!value)
                {
                    tmpPATH = this.FullPath;
                    this.FullPath = "<нет>";
                }
                else
                {
                    if (tmpPATH != "<нет>")
                    this.FullPath = tmpPATH;
                }
                PaintRed();
            }
        }
        bool DELVISIBLE;
        public bool bDelVisible
        {
            get { return DELVISIBLE; }
            set
            {
                DELVISIBLE = value;
                bPathDel.Visible = value;
            }
        }
        bool BPATHVISIBLE;
        public bool bPathVisible
        {
            get { return BPATHVISIBLE; }
            set
            {
                BPATHVISIBLE = value;
                bPath.Visible = value;
            }
        }
        public bool RequiredVisible
        {
            set
            {
                if (value)
                {
                    chRequired.Visible = true;
                }
                else
                {
                    chRequired.Visible = false;
                }
            }
        }
        public bool RequiredEnabled
        {
            set
            {
                chRequired.Enabled = value;
            }
        }
        

        ToolTip tt;
        public void Init(string path,bool req, bool enbl, bool reqvis, bool reqenbl, Roles resprole, Roles currole, string access_mode)
        {
            //this.PATH = path;
            //tbPath.Tag = path;
            this.ACCESSMODE = access_mode;
            this.ResposibleRole = resprole;
            this.Tag = ResposibleRole;
            this.CurrentRole = currole;
            this.FullPath = path;
            this.Required = req;
            this.RequiredVisible = reqvis;
            this.chRequired.Enabled = reqenbl;
            this.Enabled = enbl;
            tt = new ToolTip();
            tt.SetToolTip(this.tbPath, this.FullPath);
            //this.tbPath.
            //tbPath.Text = this.FileName;
            //SetIcons();
        }
        public bool IsPath = false;
        public bool ISPATH
        {
            get { return IsPath; }
            set { IsPath = value; }
        }
        private void bPath_Click(object sender, EventArgs e)
        {
            if (IsPath)
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
                    //bMETALOpen.Tag = dialog.SelectedPath;
                    //SetIcons();
                    this.FullPath = dialog.SelectedPath;
                }
            }
            else
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "All files (*.*)|*.*";
                //dialog.InitialDirectory = @"\\10.177.150.135\server\поездки\карта";
                dialog.InitialDirectory = @"c:\";
                dialog.Title = "Выберите файл";
                dialog.Multiselect = false;
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    this.FullPath = dialog.FileName;
                    tbPath.Text = this.FileName;
                    //SetIcons();
                }
            }
        }
        //private void SetIcons()
        //{
        //    if (tbPath.Tag.ToString() == "")
        //    {
        //        tbPath.Text = "<нет>";
        //        this.FullPath = "<нет>";
        //    }
        //    else
        //    {
        //        //this.PATH = 
        //        tbPath.Text = this.FileName;// 

        //    }
        //}
        
        private void bPathDel_Click(object sender, EventArgs e)
        {
            this.FullPath = "<нет>";
            //tbPath.Tag = "";
            //tbPath.Text = "";
            //SetIcons();
        }

        private void textBox1_MouseLeave(object sender, EventArgs e)
        {
            tbPath.ForeColor = Color.Black;
        }

        private void tbPath_Click(object sender, EventArgs e)
        {
            if (this.FullPath != "<нет>")
            {
                //Process.Start(@"explorer.exe", this.FullPath);
                Process.Start(@"explorer.exe", @"/select, " + this.FullPath);
            }
        }

        private void tbPath_MouseEnter(object sender, EventArgs e)
        {
            tbPath.ForeColor = Color.Blue;
            
        }

        private void tbPath_MouseLeave(object sender, EventArgs e)
        {
            tbPath.ForeColor = Color.Black;
        }

        private void chRequired_CheckedChanged(object sender, EventArgs e)
        {
            this.Required = chRequired.Checked;
        }

        //tbPath.Image = Resources.document_open_disabled;
        //tbPath.Enabled = false;
        //tbPath.Image = Resources.document_open;
        //tbPath.Enabled = true;
   





    }
}
