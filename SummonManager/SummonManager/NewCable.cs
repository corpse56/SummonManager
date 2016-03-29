using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SummonManager.CLASSES;
using SummonManager.Controls;
using SummonManager.CLASSES.IRole_namespace;

namespace SummonManager
{
    public partial class NewCABLE : Form
    {
        CableVO Clone, EditWP;
        //ACCESSMODE: NEW,NEWCLONE,EDIT
        //NEW - форма переделывается под добавление нового изделия; EDIT - форма переделывается под редактирование; NEWCLONE - добавление на основе существующего
        private string AccessMode = "";

        IRole UVO;
        bool RequireVisible = true;
        bool RequireEnabled = false;


        public NewCABLE(CableVO wp, string accessmode_, IRole uvo)
        {
            InitializeComponent();

            this.AccessMode = accessmode_;
            this.UVO = uvo;
            RequireVisible = true;//((UVO.Role == Roles.Inzhener) || (UVO.Role == Roles.Admin)) ? true : false;
            RequireEnabled = false;
            if (AccessMode == "NEW")
            {
                InitNEW();
                this.Text = "Создание нового изделия";
                
            }
            if (AccessMode == "NEWCLONE")
            {
                InitNEWCLONE(wp);
                this.Text = "Создание нового изделия на основе существующего";
            }
            if (AccessMode == "EDIT")
            {
                InitEDIT(wp);
                this.Text = "Редактирование изделия";
            }
            if (AccessMode == "VIEWONLY")
            {
                InitVIEWONLY(wp);
                this.Text = "Просмотр сведений об изделии";
                button2.Visible = false;
            }


        }

        private void InitVIEWONLY(CableVO wp)
        {
            RequireVisible = true;
            tbName.Text = wp.WPName;
            tbName.Enabled = false;
            cbCategory.SelectedValue = wp.IDCat;
            cbCategory.Enabled = false;
            cbSubCategory.SelectedValue = wp.IDSubCat;
            cbSubCategory.Enabled = false;
            tbDecNum.Text = wp.DecNum;
            tbDecNum.Enabled = false;
            tbCLENGTH.Text = wp.CLENGTH;
            tbCLENGTH.Enabled = false;
            tbNote.Text = wp.NOTE;
            tbNote.Enabled = false;
            tbCONNECTORS.Text = wp.CONECTORS;
            tbCONNECTORS.Enabled = false;
            pfDimDrawing.Init(wp.DIMENDRAWING, true, false, false, RequireEnabled, Roles.Constructor, UVO.Role);

        }

        private void InitEDIT(CableVO wp)
        {
            EditWP = wp;
            tbName.Text = wp.WPName;
            cbCategory.SelectedValue = wp.IDCat;
            cbSubCategory.SelectedValue = wp.IDSubCat;
            tbDecNum.Text = wp.DecNum;
            tbCLENGTH.Text = wp.CLENGTH;
            tbNote.Text = wp.NOTE;

            pfDimDrawing.Init(wp.DIMENDRAWING, true, true, false, RequireEnabled, Roles.Constructor, UVO.Role);


            //AllocateRoles();

        }

        private void InitNEWCLONE(CableVO clone)
        {
            if (clone.WPName != "")
            {
                this.Clone = clone;

                //wp.WPType = WPTYPE.WPNAMELIST;
                //wp.ID = (int)r["ID"];

                tbName.Text = Clone.WPName;
                cbCategory.SelectedValue = Clone.IDCat;
                cbSubCategory.SelectedValue = Clone.IDSubCat;
                tbDecNum.Text = Clone.DecNum;
                cbCategory.SelectedValue = Clone.IDCat;//CHECK!!!!!!!!
                cbSubCategory.SelectedValue = Clone.IDSubCat;//CHECK!!!!!!!!!
                pfDimDrawing.Init(Clone.DIMENDRAWING, true, true, false, RequireEnabled, Roles.Constructor, UVO.Role);
                tbCONNECTORS.Text = Clone.CONECTORS;
                tbCLENGTH.Text = Clone.CLENGTH;
                tbNote.Text = Clone.NOTE;
                //AllocateRoles();
            }
        }

        private void InitNEW()
        {
            pfDimDrawing.Init("", true, true, false, RequireEnabled, Roles.Constructor, UVO.Role);
        }


        private void button1_Click(object sender, EventArgs e)//cancel
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)//save
        {
            CableVO wp = new CableVO();
            if (tbName.Text == "")
            {
                MessageBox.Show("Введите наименование!");
                return;
            }
            
            wp.WPType                   = WPTYPE.CABLELIST;
            wp.WPName                   = tbName.Text;
            wp.IDCat                    = Convert.ToInt32(cbCategory.SelectedValue);
            wp.IDSubCat                 = (cbSubCategory.SelectedValue == null) ? 0 : (int)cbSubCategory.SelectedValue;
            wp.DecNum                   = tbDecNum.Text;
            wp.DIMENDRAWING             = (pfDimDrawing.FullPath == "<нет>") ? null : pfDimDrawing.FullPath; ;
            wp.CLENGTH                  = tbCLENGTH.Text;
            wp.CONECTORS                = tbCONNECTORS.Text;
            wp.NOTE                     = tbNote.Text;

            DBCableList dbc = new DBCableList();
            if (AccessMode == "EDIT")
            {
                wp.ID = EditWP.ID;
                dbc.EditCable(wp);

                MessageBox.Show("Кабель успешно сохранён!");
            }
            if ((AccessMode == "NEW") || (AccessMode == "NEWCLONE"))
            {
                dbc.AddNewCable(wp);
                MessageBox.Show("Кабель успешно добавлен!");
            }
            Close();
        }

        private void NewWPN_Load(object sender, EventArgs e)
        {
            DBCategory dbc = new DBCategory("CABLELIST");
            cbCategory.ValueMember = "ID";
            cbCategory.DisplayMember = "CATEGORYNAME";
            cbCategory.DataSource = dbc.GetAllExceptAll();

            if (AccessMode == "NEWCLONE")
            {
                if (Clone.IDCat != 0)
                {
                    cbCategory.SelectedValue = Clone.IDCat;
                }
                else
                {
                    cbCategory.SelectedIndex = 0;
                }
            }
            if (AccessMode == "NEW")
            {
                cbCategory.SelectedIndex = 0;
            }
            if (AccessMode == "EDIT")
            {
                if (EditWP.IDCat != 0)
                {
                    cbCategory.SelectedValue = EditWP.IDCat;
                }
                else
                {
                    cbCategory.SelectedIndex = 0;
                }

            }
            LoadSubs((int)cbCategory.SelectedValue);
            if (AccessMode == "NEWCLONE")
                cbSubCategory.SelectedValue = Clone.IDSubCat;
            if (AccessMode == "EDIT")
                cbSubCategory.SelectedValue = EditWP.IDSubCat;



        }
        private void LoadSubs(int idCat)
        {
            if ((cbCategory.Text.ToUpper() == "ВСЕ") || (cbCategory.Text.ToUpper() == "НЕ ПРИСВОЕНО"))
            {
                cbSubCategory.Text = "";
                cbSubCategory.Enabled = false;
            }
            else
            {
                cbSubCategory.Enabled = true;
                DBSubCategory dbs = new DBSubCategory();
                cbSubCategory.ValueMember = "ID";
                cbSubCategory.DisplayMember = "SUBCATNAME";
                cbSubCategory.DataSource = dbs.GetAllExceptAll(idCat);

            }
        }
        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSubs((int)cbCategory.SelectedValue);
        }

       
    }
}
