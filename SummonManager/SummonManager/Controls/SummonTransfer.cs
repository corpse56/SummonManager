﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SummonManager
{
    public partial class SummonTransfer : UserControl
    {

        SummonVO SVO;
        UserVO UVO;
        Form FORM;
        bool sub = false;
        public SummonTransfer()
        {
            InitializeComponent();
        }
        public void Init(SummonVO svo, UserVO uvo, Form form)
        {
        //    InitializeComponent();
            this.SVO = svo;
            this.UVO = uvo;
            this.FORM = form;
            cbStatus.Enabled = false;
            done = false;

            DBCurStatus dbcs = new DBCurStatus();
            cbStatus.ValueMember = "ID";
            cbStatus.DisplayMember = "SNAME";
            cbStatus.DataSource = dbcs.GetAllStatuses(UVO,SVO);
            cbStatus.SelectedValue = SVO.IDSTATUS;

            SetDefaults();

        }
        internal void InitSub(SummonVO SVO, UserVO UVO, ShowSummonOZIS form)
        {
            this.SVO = SVO;
            this.UVO = UVO;
            this.FORM = form;
            cbStatus.Enabled = false;
            done = false;
            if ((UVO.Role != Roles.OTK) && (UVO.Role != Roles.Montage) && (UVO.Role != Roles.Ozis))
            {
                this.Visible = false;
                return;
            }

            DBCurStatus dbcs = new DBCurStatus();
            cbStatus.ValueMember = "ID";
            cbStatus.DisplayMember = "SNAME";
            cbStatus.DataSource = dbcs.GetAllSubStatuses(UVO, SVO);
            cbStatus.SelectedValue = SVO.IDSTATUS;

            SetDefaultsSub();
            groupBox1.Text = "Смена субстатуса";
            button3.Text = "Сменить субстатус";
            label1.Text = "Выберите субстатус";
            sub = true;
        }

        private void SetDefaultsSub()
        {
            switch (UVO.Role)//ставим умолчания
            {
                case Roles.OTK:
                    cbStatus.SelectedValue = 17;
                    break;
                case Roles.Ozis:
                    cbStatus.SelectedValue = 15;
                    break;
                case Roles.Montage:
                    cbStatus.SelectedValue = 16;
                    break;

            }
        }
        private void SetDefaults()
        {
            switch (UVO.Role)//ставим умолчания
            {
                case Roles.Logist:
                    cbStatus.SelectedValue = 13;
                    break;
                case Roles.Manager:
                    cbStatus.SelectedValue = 3;
                    break;
                case Roles.Montage:
                    cbStatus.SelectedValue = 16;
                    break;
                case Roles.OTK:
                    cbStatus.SelectedValue = 99;
                    break;
                case Roles.Ozis:
                    cbStatus.SelectedValue = 4;
                    break;
                case Roles.Prod:
                    if (SVO.SISP)
                        cbStatus.SelectedValue = 19;
                    else
                        cbStatus.SelectedValue = 5;
                    break;
                case Roles.Ware:
                    cbStatus.SelectedValue = 12;
                    break;
                case Roles.Wsh:
                    if (SVO.SISP)
                        cbStatus.SelectedValue = 20;
                    else
                        cbStatus.SelectedValue = 7;
                    break;

            }
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                cbStatus.Enabled = true;
            }
            else
            {
                cbStatus.Enabled = false;
                SetDefaults();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!sub)
            {
                switch (UVO.Role)
                {
                    case Roles.Logist:
                        if (LogistSwitch())
                        {
                            if (!Change())
                            {
                                return;
                            }
                        }
                        else return;
                        break;
                    case Roles.Manager:
                        if (ManagerSwitch())
                        {
                            if (!Change())
                            {
                                return;
                            }
                        }
                        else return;
                        break;
                    case Roles.Montage:
                        if (MontageSwitch())
                        {
                            if (!Change())
                            {
                                return;
                            }
                        }
                        else return;
                        break;
                    case Roles.OTK:
                        if (OTKSwitch())
                        {
                            if (!Change())
                            {
                                return;
                            }
                        }
                        else return;
                        break;
                    case Roles.Ozis:
                        if (OzisSwitch())
                        {
                            if (!Change())
                            {
                                return;
                            }
                        }
                        else return;
                        break;
                    case Roles.Prod:
                        if (ProdSwitch())
                        {
                            if (!Change())
                            {
                                return;
                            }
                        }
                        else return;
                        break;
                    case Roles.Ware:
                        if (WareSwitch())
                        {
                            if (!Change())
                            {
                                return;
                            }
                        }
                        else return;
                        break;
                    case Roles.Wsh:
                        if (WshSwitch())
                        {
                            if (!Change())
                            {
                                return;
                            }
                        }
                        else return;
                        break;
                }
                MessageBox.Show("Извещение успешно передано!");
                done = true;
                FORM.Close();
            }
            else//======================================================SUBSTATUS==============================================
            {
                switch (UVO.Role)
                {
                    case Roles.OTK:
                        if (OTKSubSwitch())
                        {
                            if (!ChangeSub())
                            {
                                return;
                            }
                        }
                        else return;
                        break;
                    case Roles.Ozis:
                        if (OzisSubSwitch())
                        {
                            if (!ChangeSub())
                            {
                                return;
                            }
                        }
                        else return;
                        break;
                    case Roles.Montage:
                        if (MontageSubSwitch())
                        {
                            if (!ChangeSub())
                            {
                                return;
                            }
                        }
                        else return;
                        break;
                }
            }
        }




        private bool ChangeSub()
        {
            if (MessageBox.Show("Вы действительно хотите изменить субстатус этого извещения на '" + cbStatus.Text + "'?",
                "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return false;
            }
            DBCurStatus dbcs = new DBCurStatus();
            dbcs.ChangeSubStatus(SVO, (int)cbStatus.SelectedValue, UVO.id);
            return true;
        }
        public bool done = false;
        private bool Change()
        {
            if (MessageBox.Show("Вы действительно хотите изменить статус этого извещения на '" + cbStatus.Text + "'?",
                "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return false;
            }
            DBCurStatus dbcs = new DBCurStatus();
            dbcs.ChangeStatus(SVO, (int)cbStatus.SelectedValue, UVO.id);
            if ((int)cbStatus.SelectedValue == 3)//вставить оповещение для ОТК, чтоб заполняли серийные номера!
            {
                Notification n = new Notification();
                n.IDNTYPE = "1";
                n.IDSUMMON = SVO.ID;
                DBNotification dbn = new DBNotification();
                dbn.AddNew(n);
            }
            return true;
        }
        private bool OTKSubSwitch()
        {
            if (SVO.IDSUBST != 16)
            {
                MessageBox.Show("Вы не можете изменить субстатус, так как не являетесь в данный момент ответственным лицом за текущий субстатус!");
                return false;
            }
            return true;
        }
        private bool MontageSubSwitch()
        {
            if (SVO.IDSUBST != 15)
            {
                MessageBox.Show("Вы не можете изменить субстатус, так как не являетесь в данный момент ответственным лицом за текущий субстатус!");
                return false;
            }
            return true;
        }

        private bool OzisSubSwitch()
        {
            if ((SVO.IDSUBST != 0) && (SVO.IDSUBST != 17))
            {
                MessageBox.Show("Вы не можете изменить субстатус, так как не являетесь в данный момент ответственным лицом за текущий субстатус!");
                return false;
            }
            return true;
        }

        private bool WshSwitch()
        {
            if ((SVO.IDSTATUS != 5) && (SVO.IDSTATUS != 8))
            {
                MessageBox.Show("Вы не можете передавать это извещение, так как не являетесь в данный момент ответственным лицом за это извещение!");
                return false;
            }

            return true;
        }

        private bool WareSwitch()
        {
            if (SVO.IDSTATUS != 9)
            {
                MessageBox.Show("Вы не можете передавать это извещение, так как не являетесь в данный момент ответственным лицом за это извещение!");
                return false;
            }

            return true;
        }

        private bool ProdSwitch()
        {
            if ((SVO.IDSTATUS != 2) && (SVO.IDSTATUS != 4) && (SVO.IDSTATUS != 6))
            {
                MessageBox.Show("Вы не можете передавать это извещение, так как не являетесь в данный момент ответственным лицом за это извещение!");
                return false;
            }
            switch ((int)cbStatus.SelectedValue)
            {
                case 5:
                    if ((this.SVO.IDSTATUS != 4) && (this.SVO.IDSTATUS != 6))
                    {
                        MessageBox.Show("Вы не можете передать в цех это извещение, так как оно еще не было передано в ПДБ!");
                        return false;
                    }
                    break;
                case 3:
                    if ((this.SVO.IDSTATUS != 2) && (this.SVO.IDSTATUS != 4) && (this.SVO.IDSTATUS != 6))
                    {
                        MessageBox.Show("Вы не можете передать это извещение в ПДБ. Несоответствие статуса.");
                        return false;
                    }
                    break;
            }
            return true;
        }

        private bool OzisSwitch()
        {
            if ( (SVO.IDSTATUS != 3) && (SVO.IDSTATUS != 17))
            {
                MessageBox.Show("Вы не можете передавать это извещение, так как не являетесь в данный момент ответственным лицом за это извещение!");
                return false;
            } 
            switch ((int)cbStatus.SelectedValue)
            {
                case 4:
                    if ((SVO.IDSTATUS != 3) && (SVO.IDSTATUS != 17))
                    {
                        MessageBox.Show("Вы не можете передать это извещение монтажникам, не являетесь в данный момент ответственным за это извещение!");
                        return false;
                    }
                    break;
                case 15:
                    if ((SVO.IDSTATUS != 3) && (SVO.IDSTATUS != 17))
                    {
                        MessageBox.Show("Вы не можете передать это извещение монтажникам, не являетесь в данный момент ответственным за это извещение!");
                        return false;
                    }
                    break;
            }
            return true;
        }

        private bool OTKSwitch()
        {
           
            switch ((int)cbStatus.SelectedValue)
            {
                case 18:
                    if (SVO.IDSTATUS != 16)
                    {
                        MessageBox.Show("Вы не можете вернуть это извещение монтажникам, так как оно не от монтажников!");
                        return false;
                    } 
                    break;
                case 17:
                    if (SVO.IDSTATUS != 16)
                    {
                        MessageBox.Show("Вы не можете передать это извещение в ПДБ, так как оно не от монтажников!");
                        return false;
                    }
                    break;
                case 8:
                    if ( (SVO.IDSTATUS != 7) && (SVO.IDSTATUS != 16))
                    {
                        MessageBox.Show("Вы не можете вернуть в цех это извещение, так как не являетесь в данный момент ответственным лицом за это извещение или извещение пришло от монтажников!");
                        return false;
                    }
                    break;
                case 9:
                    if ((SVO.IDSTATUS != 7) && (SVO.IDSTATUS != 16))
                    {
                        MessageBox.Show("Вы не можете передать в коммерческий отдел это извещение, так как не являетесь в данный момент ответственным лицом за это извещение!");
                        return false;
                    }
                    break;
            }
            return true;
        }

        private bool MontageSwitch()
        {
            switch ((int)cbStatus.SelectedValue)
            {
                case 16:
                    if ((SVO.IDSTATUS != 15) && (SVO.IDSTATUS != 18))
                    {
                        MessageBox.Show("Вы не можете передавать это извещение, так как не являетесь в данный момент ответственным лицом за это извещение!");
                        return false;
                    } break;
            }
            return true;
        }

        private bool LogistSwitch()
        {
            switch ((int)cbStatus.SelectedValue)
            {
                case 13:
                    if (this.SVO.IDSTATUS != 12)
                    {
                        MessageBox.Show("Вы не можете редактировать это извещение, так как не являетесь в данный момент ответственным лицом за это извещение!");
                        return false;
                    }
                    break;
            }
            return true;
        }

        private bool ManagerSwitch()
        {
            if ((SVO.IDSTATUS != 1) && (SVO.IDSTATUS != 11) && (SVO.IDSTATUS != 2))
            {
                MessageBox.Show("Вы не можете передавать это извещение, так как не являетесь в данный момент ответственным лицом за это извещение!");
                return false;
            }
            switch ((int)cbStatus.SelectedValue)
            {
                case 3:
                    if ((SVO.IDSTATUS == 3))
                    {
                        MessageBox.Show("Вы не можете передать в ПДБ это извещение, так как оно уже в ПДБ !");
                        return false;
                    }
                    if ((SVO.IDSTATUS == 11))
                    {
                        MessageBox.Show("Вы не можете передать в ПДБ это извещение, так как оно уже готово к отгрузке!");
                        return false;
                    }
                    break;
                case 12:
                    if ((SVO.IDSTATUS != 11))
                    {
                        MessageBox.Show("Вы не можете пометить это извещение как отгружаемое, так как оно либо еще не готово к отгрузке, либо уже отгружается!");
                        return false;
                    }
                    break;
            }
            return true;
        }



    }
}
