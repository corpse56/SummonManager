using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace SummonManager
{
    partial class ShowSummonINZHENER
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.tbIDS = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbTECHREQPATH = new System.Windows.Forms.TextBox();
            this.tbCONTRACT = new System.Windows.Forms.TextBox();
            this.tbSHIPPING = new System.Windows.Forms.TextBox();
            this.tbDELIVERY = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.bCancel = new System.Windows.Forms.Button();
            this.bPrint = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.dtpCREATED = new System.Windows.Forms.DateTimePicker();
            this.bPATH = new System.Windows.Forms.Button();
            this.dtpPTIME = new System.Windows.Forms.DateTimePicker();
            this.bSave = new System.Windows.Forms.Button();
            this.bEdit = new System.Windows.Forms.Button();
            this.chbDeterm = new System.Windows.Forms.CheckBox();
            this.dtpAPPROX = new System.Windows.Forms.DateTimePicker();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.tbPAYSTATUS = new System.Windows.Forms.TextBox();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.bEditExtCablePack = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.tbSerial = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.pfMETAL = new SummonManager.Controls.PathField();
            this.pfCOMPOSITION = new SummonManager.Controls.PathField();
            this.pfSERIAL = new SummonManager.Controls.PathField();
            this.pfZHGUT = new SummonManager.Controls.PathField();
            this.pf3D = new SummonManager.Controls.PathField();
            this.pfPLANKA = new SummonManager.Controls.PathField();
            this.pfSHILD = new SummonManager.Controls.PathField();
            this.wpNameView1 = new SummonManager.Controls.WPNameView();
            this.pathFileds1 = new SummonManager.PathFileds();
            this.cbCustDept = new SummonManager.RComboBox();
            this.cbMountingKit = new SummonManager.RComboBox();
            this.cbPacking = new SummonManager.RComboBox();
            this.cbAccept = new SummonManager.RComboBox();
            this.tbQUANTITY = new SummonManager.RNumericUpDown();
            this.cbSISP = new SummonManager.RComboBox();
            this.cbCustomers = new SummonManager.RComboBox();
            this.summonNotes1 = new SummonManager.SummonNotes();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbQUANTITY)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(155, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Извещение №";
            // 
            // tbIDS
            // 
            this.tbIDS.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.tbIDS.Location = new System.Drawing.Point(261, 12);
            this.tbIDS.Name = "tbIDS";
            this.tbIDS.ReadOnly = true;
            this.tbIDS.Size = new System.Drawing.Size(133, 22);
            this.tbIDS.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(165, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Наименование изделия";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 272);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(174, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Технические требования";
            // 
            // tbTECHREQPATH
            // 
            this.tbTECHREQPATH.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tbTECHREQPATH.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tbTECHREQPATH.Location = new System.Drawing.Point(199, 269);
            this.tbTECHREQPATH.Name = "tbTECHREQPATH";
            this.tbTECHREQPATH.ReadOnly = true;
            this.tbTECHREQPATH.Size = new System.Drawing.Size(348, 22);
            this.tbTECHREQPATH.TabIndex = 3;
            this.tbTECHREQPATH.MouseLeave += new System.EventHandler(this.tbTECHREQPATH_MouseLeave);
            this.tbTECHREQPATH.Click += new System.EventHandler(this.tbTECHREQPATH_Click);
            this.tbTECHREQPATH.MouseEnter += new System.EventHandler(this.tbTECHREQPATH_MouseEnter);
            // 
            // tbCONTRACT
            // 
            this.tbCONTRACT.Location = new System.Drawing.Point(197, 439);
            this.tbCONTRACT.Name = "tbCONTRACT";
            this.tbCONTRACT.Size = new System.Drawing.Size(415, 22);
            this.tbCONTRACT.TabIndex = 3;
            // 
            // tbSHIPPING
            // 
            this.tbSHIPPING.Location = new System.Drawing.Point(197, 495);
            this.tbSHIPPING.Name = "tbSHIPPING";
            this.tbSHIPPING.Size = new System.Drawing.Size(415, 22);
            this.tbSHIPPING.TabIndex = 3;
            // 
            // tbDELIVERY
            // 
            this.tbDELIVERY.Location = new System.Drawing.Point(197, 523);
            this.tbDELIVERY.Name = "tbDELIVERY";
            this.tbDELIVERY.Size = new System.Drawing.Size(415, 22);
            this.tbDELIVERY.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 300);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "Количество*";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 328);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(140, 16);
            this.label5.TabIndex = 2;
            this.label5.Text = "Срок сдачи изделия";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 356);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 16);
            this.label6.TabIndex = 2;
            this.label6.Text = "Приемка";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 384);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(160, 16);
            this.label7.TabIndex = 2;
            this.label7.Text = "Организация заказчик";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 442);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(141, 16);
            this.label9.TabIndex = 2;
            this.label9.Text = "№ Счёта и договора";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 470);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(105, 16);
            this.label10.TabIndex = 2;
            this.label10.Text = "Статус оплаты";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(9, 498);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(126, 16);
            this.label11.TabIndex = 2;
            this.label11.Text = "Условия отгрузки";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(9, 526);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(127, 16);
            this.label12.TabIndex = 2;
            this.label12.Text = "Условия поставки";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(9, 554);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(60, 16);
            this.label13.TabIndex = 2;
            this.label13.Text = "СИ и СП";
            // 
            // bCancel
            // 
            this.bCancel.Location = new System.Drawing.Point(304, 832);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(75, 42);
            this.bCancel.TabIndex = 4;
            this.bCancel.Text = "Отмена";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // bPrint
            // 
            this.bPrint.Enabled = false;
            this.bPrint.Location = new System.Drawing.Point(3, 832);
            this.bPrint.Name = "bPrint";
            this.bPrint.Size = new System.Drawing.Size(69, 42);
            this.bPrint.TabIndex = 7;
            this.bPrint.Text = "Печать";
            this.bPrint.UseVisualStyleBackColor = true;
            this.bPrint.Click += new System.EventHandler(this.bPrint_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(12, 57);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(115, 16);
            this.label15.TabIndex = 2;
            this.label15.Text = "Дата извещения";
            // 
            // dtpCREATED
            // 
            this.dtpCREATED.Enabled = false;
            this.dtpCREATED.Location = new System.Drawing.Point(200, 52);
            this.dtpCREATED.Name = "dtpCREATED";
            this.dtpCREATED.Size = new System.Drawing.Size(200, 22);
            this.dtpCREATED.TabIndex = 8;
            // 
            // bPATH
            // 
            this.bPATH.Location = new System.Drawing.Point(553, 268);
            this.bPATH.Name = "bPATH";
            this.bPATH.Size = new System.Drawing.Size(60, 25);
            this.bPATH.TabIndex = 9;
            this.bPATH.Text = "Путь";
            this.bPATH.UseVisualStyleBackColor = true;
            this.bPATH.Click += new System.EventHandler(this.bPATH_Click);
            // 
            // dtpPTIME
            // 
            this.dtpPTIME.Location = new System.Drawing.Point(199, 325);
            this.dtpPTIME.Name = "dtpPTIME";
            this.dtpPTIME.Size = new System.Drawing.Size(200, 22);
            this.dtpPTIME.TabIndex = 10;
            // 
            // bSave
            // 
            this.bSave.Location = new System.Drawing.Point(209, 832);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(89, 42);
            this.bSave.TabIndex = 12;
            this.bSave.Text = "Сохранить";
            this.bSave.UseVisualStyleBackColor = true;
            this.bSave.Click += new System.EventHandler(this.button1_Click);
            // 
            // bEdit
            // 
            this.bEdit.Location = new System.Drawing.Point(78, 832);
            this.bEdit.Name = "bEdit";
            this.bEdit.Size = new System.Drawing.Size(124, 42);
            this.bEdit.TabIndex = 13;
            this.bEdit.Text = "Редактировать";
            this.bEdit.UseVisualStyleBackColor = true;
            this.bEdit.Click += new System.EventHandler(this.bEdit_Click);
            // 
            // chbDeterm
            // 
            this.chbDeterm.AutoSize = true;
            this.chbDeterm.Checked = true;
            this.chbDeterm.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbDeterm.Location = new System.Drawing.Point(410, 793);
            this.chbDeterm.Name = "chbDeterm";
            this.chbDeterm.Size = new System.Drawing.Size(128, 20);
            this.chbDeterm.TabIndex = 27;
            this.chbDeterm.Text = "Не определено";
            this.chbDeterm.UseVisualStyleBackColor = true;
            this.chbDeterm.CheckedChanged += new System.EventHandler(this.chbDeterm_CheckedChanged);
            // 
            // dtpAPPROX
            // 
            this.dtpAPPROX.Enabled = false;
            this.dtpAPPROX.Location = new System.Drawing.Point(200, 793);
            this.dtpAPPROX.Name = "dtpAPPROX";
            this.dtpAPPROX.Size = new System.Drawing.Size(200, 22);
            this.dtpAPPROX.TabIndex = 26;
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(12, 793);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(186, 36);
            this.label16.TabIndex = 25;
            this.label16.Text = "Ориентировочная дата сдачи";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(12, 242);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(71, 16);
            this.label17.TabIndex = 31;
            this.label17.Text = "Упаковка";
            // 
            // tbPAYSTATUS
            // 
            this.tbPAYSTATUS.Location = new System.Drawing.Point(197, 467);
            this.tbPAYSTATUS.Name = "tbPAYSTATUS";
            this.tbPAYSTATUS.Size = new System.Drawing.Size(415, 22);
            this.tbPAYSTATUS.TabIndex = 3;
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgv.Location = new System.Drawing.Point(200, 135);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(415, 101);
            this.dgv.TabIndex = 47;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(12, 108);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(149, 16);
            this.label20.TabIndex = 45;
            this.label20.Text = "Монтажный комплект";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(14, 136);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(116, 16);
            this.label21.TabIndex = 46;
            this.label21.Text = "Внешние кабели";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(10, 416);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(138, 16);
            this.label22.TabIndex = 49;
            this.label22.Text = "Отдел организации";
            // 
            // bEditExtCablePack
            // 
            this.bEditExtCablePack.Image = global::SummonManager.Properties.Resources.edit1;
            this.bEditExtCablePack.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bEditExtCablePack.Location = new System.Drawing.Point(125, 166);
            this.bEditExtCablePack.Name = "bEditExtCablePack";
            this.bEditExtCablePack.Size = new System.Drawing.Size(69, 44);
            this.bEditExtCablePack.TabIndex = 48;
            this.bEditExtCablePack.Text = "---->";
            this.bEditExtCablePack.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bEditExtCablePack.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 762);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(134, 16);
            this.label8.TabIndex = 79;
            this.label8.Text = "Металл для заказа";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(9, 734);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(113, 16);
            this.label14.TabIndex = 80;
            this.label14.Text = "Состав изделия";
            // 
            // tbSerial
            // 
            this.tbSerial.AutoSize = true;
            this.tbSerial.Location = new System.Drawing.Point(9, 706);
            this.tbSerial.Name = "tbSerial";
            this.tbSerial.Size = new System.Drawing.Size(126, 16);
            this.tbSerial.TabIndex = 78;
            this.tbSerial.Text = "Серийные номера";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(9, 678);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(51, 16);
            this.label18.TabIndex = 76;
            this.label18.Text = "Жгуты";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(9, 650);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(74, 16);
            this.label24.TabIndex = 77;
            this.label24.Text = "3D сборка";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(9, 619);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(135, 16);
            this.label23.TabIndex = 81;
            this.label23.Text = "Планка фирменная";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(9, 588);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(130, 16);
            this.label19.TabIndex = 82;
            this.label19.Text = "Комплект шильдов";
            // 
            // pfMETAL
            // 
            this.pfMETAL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pfMETAL.FullPath = "<нет>";
            this.pfMETAL.Location = new System.Drawing.Point(196, 750);
            this.pfMETAL.Margin = new System.Windows.Forms.Padding(4);
            this.pfMETAL.Name = "pfMETAL";
            this.pfMETAL.Required = false;
            this.pfMETAL.Size = new System.Drawing.Size(414, 28);
            this.pfMETAL.TabIndex = 72;
            // 
            // pfCOMPOSITION
            // 
            this.pfCOMPOSITION.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pfCOMPOSITION.FullPath = "<нет>";
            this.pfCOMPOSITION.Location = new System.Drawing.Point(196, 722);
            this.pfCOMPOSITION.Margin = new System.Windows.Forms.Padding(4);
            this.pfCOMPOSITION.Name = "pfCOMPOSITION";
            this.pfCOMPOSITION.Required = false;
            this.pfCOMPOSITION.Size = new System.Drawing.Size(414, 28);
            this.pfCOMPOSITION.TabIndex = 71;
            // 
            // pfSERIAL
            // 
            this.pfSERIAL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pfSERIAL.FullPath = "<нет>";
            this.pfSERIAL.Location = new System.Drawing.Point(196, 694);
            this.pfSERIAL.Margin = new System.Windows.Forms.Padding(4);
            this.pfSERIAL.Name = "pfSERIAL";
            this.pfSERIAL.Required = false;
            this.pfSERIAL.Size = new System.Drawing.Size(414, 28);
            this.pfSERIAL.TabIndex = 73;
            // 
            // pfZHGUT
            // 
            this.pfZHGUT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pfZHGUT.FullPath = "<нет>";
            this.pfZHGUT.Location = new System.Drawing.Point(196, 666);
            this.pfZHGUT.Margin = new System.Windows.Forms.Padding(4);
            this.pfZHGUT.Name = "pfZHGUT";
            this.pfZHGUT.Required = false;
            this.pfZHGUT.Size = new System.Drawing.Size(414, 28);
            this.pfZHGUT.TabIndex = 69;
            // 
            // pf3D
            // 
            this.pf3D.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pf3D.FullPath = "<нет>";
            this.pf3D.Location = new System.Drawing.Point(197, 638);
            this.pf3D.Margin = new System.Windows.Forms.Padding(4);
            this.pf3D.Name = "pf3D";
            this.pf3D.Required = false;
            this.pf3D.Size = new System.Drawing.Size(414, 28);
            this.pf3D.TabIndex = 70;
            // 
            // pfPLANKA
            // 
            this.pfPLANKA.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pfPLANKA.FullPath = "<нет>";
            this.pfPLANKA.Location = new System.Drawing.Point(196, 607);
            this.pfPLANKA.Margin = new System.Windows.Forms.Padding(4);
            this.pfPLANKA.Name = "pfPLANKA";
            this.pfPLANKA.Required = false;
            this.pfPLANKA.Size = new System.Drawing.Size(414, 28);
            this.pfPLANKA.TabIndex = 75;
            // 
            // pfSHILD
            // 
            this.pfSHILD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pfSHILD.FullPath = "<нет>";
            this.pfSHILD.Location = new System.Drawing.Point(196, 580);
            this.pfSHILD.Margin = new System.Windows.Forms.Padding(4);
            this.pfSHILD.Name = "pfSHILD";
            this.pfSHILD.Required = false;
            this.pfSHILD.Size = new System.Drawing.Size(414, 28);
            this.pfSHILD.TabIndex = 74;
            // 
            // wpNameView1
            // 
            this.wpNameView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.wpNameView1.Location = new System.Drawing.Point(196, 72);
            this.wpNameView1.Margin = new System.Windows.Forms.Padding(4);
            this.wpNameView1.Name = "wpNameView1";
            this.wpNameView1.Size = new System.Drawing.Size(417, 31);
            this.wpNameView1.TabIndex = 68;
            // 
            // pathFileds1
            // 
            this.pathFileds1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pathFileds1.Location = new System.Drawing.Point(668, 188);
            this.pathFileds1.Margin = new System.Windows.Forms.Padding(4);
            this.pathFileds1.Name = "pathFileds1";
            this.pathFileds1.Size = new System.Drawing.Size(413, 212);
            this.pathFileds1.TabIndex = 67;
            this.pathFileds1.Visible = false;
            // 
            // cbCustDept
            // 
            this.cbCustDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCustDept.FormattingEnabled = true;
            this.cbCustDept.Location = new System.Drawing.Point(199, 411);
            this.cbCustDept.Name = "cbCustDept";
            this.cbCustDept.Size = new System.Drawing.Size(414, 24);
            this.cbCustDept.TabIndex = 50;
            // 
            // cbMountingKit
            // 
            this.cbMountingKit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMountingKit.FormattingEnabled = true;
            this.cbMountingKit.Items.AddRange(new object[] {
            "ДА",
            "НЕТ"});
            this.cbMountingKit.Location = new System.Drawing.Point(199, 105);
            this.cbMountingKit.Name = "cbMountingKit";
            this.cbMountingKit.Size = new System.Drawing.Size(415, 24);
            this.cbMountingKit.TabIndex = 44;
            // 
            // cbPacking
            // 
            this.cbPacking.FormattingEnabled = true;
            this.cbPacking.Location = new System.Drawing.Point(199, 239);
            this.cbPacking.Name = "cbPacking";
            this.cbPacking.Size = new System.Drawing.Size(413, 24);
            this.cbPacking.TabIndex = 32;
            // 
            // cbAccept
            // 
            this.cbAccept.FormattingEnabled = true;
            this.cbAccept.Location = new System.Drawing.Point(199, 352);
            this.cbAccept.Name = "cbAccept";
            this.cbAccept.Size = new System.Drawing.Size(416, 24);
            this.cbAccept.TabIndex = 29;
            // 
            // tbQUANTITY
            // 
            this.tbQUANTITY.Location = new System.Drawing.Point(198, 298);
            this.tbQUANTITY.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.tbQUANTITY.Name = "tbQUANTITY";
            this.tbQUANTITY.Size = new System.Drawing.Size(201, 22);
            this.tbQUANTITY.TabIndex = 11;
            // 
            // cbSISP
            // 
            this.cbSISP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSISP.FormattingEnabled = true;
            this.cbSISP.Items.AddRange(new object[] {
            "НЕТ",
            "ДА"});
            this.cbSISP.Location = new System.Drawing.Point(196, 549);
            this.cbSISP.Name = "cbSISP";
            this.cbSISP.Size = new System.Drawing.Size(415, 24);
            this.cbSISP.TabIndex = 6;
            // 
            // cbCustomers
            // 
            this.cbCustomers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCustomers.FormattingEnabled = true;
            this.cbCustomers.Location = new System.Drawing.Point(199, 381);
            this.cbCustomers.Name = "cbCustomers";
            this.cbCustomers.Size = new System.Drawing.Size(415, 24);
            this.cbCustomers.TabIndex = 6;
            this.cbCustomers.SelectedIndexChanged += new System.EventHandler(this.cbCustomers_SelectedIndexChanged);
            // 
            // summonNotes1
            // 
            this.summonNotes1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.summonNotes1.Location = new System.Drawing.Point(622, 9);
            this.summonNotes1.Margin = new System.Windows.Forms.Padding(4);
            this.summonNotes1.Name = "summonNotes1";
            this.summonNotes1.Size = new System.Drawing.Size(550, 694);
            this.summonNotes1.TabIndex = 65;
            // 
            // ShowSummonINZHENER
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1174, 878);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.tbSerial);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.pfMETAL);
            this.Controls.Add(this.pfCOMPOSITION);
            this.Controls.Add(this.pfSERIAL);
            this.Controls.Add(this.pfZHGUT);
            this.Controls.Add(this.pf3D);
            this.Controls.Add(this.pfPLANKA);
            this.Controls.Add(this.pfSHILD);
            this.Controls.Add(this.wpNameView1);
            this.Controls.Add(this.pathFileds1);
            this.Controls.Add(this.cbCustDept);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.bEditExtCablePack);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.cbMountingKit);
            this.Controls.Add(this.cbPacking);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.cbAccept);
            this.Controls.Add(this.chbDeterm);
            this.Controls.Add(this.dtpAPPROX);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.bEdit);
            this.Controls.Add(this.bSave);
            this.Controls.Add(this.tbQUANTITY);
            this.Controls.Add(this.dtpPTIME);
            this.Controls.Add(this.bPATH);
            this.Controls.Add(this.dtpCREATED);
            this.Controls.Add(this.bPrint);
            this.Controls.Add(this.cbSISP);
            this.Controls.Add(this.cbCustomers);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.tbDELIVERY);
            this.Controls.Add(this.tbSHIPPING);
            this.Controls.Add(this.tbPAYSTATUS);
            this.Controls.Add(this.tbCONTRACT);
            this.Controls.Add(this.tbTECHREQPATH);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbIDS);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.summonNotes1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "ShowSummonINZHENER";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Просмотр извещения (Главный инженер)";
            this.Load += new System.EventHandler(this.ShowSummonCONSTR_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbQUANTITY)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbIDS;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbTECHREQPATH;
        private System.Windows.Forms.TextBox tbCONTRACT;
        private System.Windows.Forms.TextBox tbSHIPPING;
        private System.Windows.Forms.TextBox tbDELIVERY;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button bCancel;
        private RComboBox cbCustomers;
        private System.Windows.Forms.Button bPrint;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DateTimePicker dtpCREATED;
        private System.Windows.Forms.Button bPATH;
        private RComboBox cbSISP;
        private System.Windows.Forms.DateTimePicker dtpPTIME;
        private RNumericUpDown tbQUANTITY;
        private System.Windows.Forms.Button bSave;
        private System.Windows.Forms.Button bEdit;
        private CheckBox chbDeterm;
        private DateTimePicker dtpAPPROX;
        private Label label16;
        private RComboBox cbAccept;
        private RComboBox cbPacking;
        private Label label17;
        private TextBox tbPAYSTATUS;
        private Button bEditExtCablePack;
        private DataGridView dgv;
        private Label label20;
        private Label label21;
        private RComboBox cbMountingKit;
        private RComboBox cbCustDept;
        private Label label22;
        private SummonNotes summonNotes1;
        private PathFileds pathFileds1;
        private SummonManager.Controls.WPNameView wpNameView1;
        private Label label8;
        private Label label14;
        private Label tbSerial;
        private Label label18;
        private Label label24;
        private Label label23;
        private Label label19;
        private SummonManager.Controls.PathField pfMETAL;
        private SummonManager.Controls.PathField pfCOMPOSITION;
        private SummonManager.Controls.PathField pfSERIAL;
        private SummonManager.Controls.PathField pfZHGUT;
        private SummonManager.Controls.PathField pf3D;
        private SummonManager.Controls.PathField pfPLANKA;
        private SummonManager.Controls.PathField pfSHILD;
    }
}