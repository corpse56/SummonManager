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
    partial class ShowSummon
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.chbDocsRdy = new System.Windows.Forms.CheckBox();
            this.chbBillPayed = new System.Windows.Forms.CheckBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.summonTransfer2 = new SummonManager.SummonTransfer();
            this.label1 = new System.Windows.Forms.Label();
            this.tbSubStatus = new System.Windows.Forms.TextBox();
            this.tbStatus = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.summonTransfer1 = new SummonManager.SummonTransfer();
            this.wpNameView1 = new SummonManager.Controls.WPNameView();
            this.cbCustDept = new SummonManager.RComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.cbPacking = new SummonManager.RComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.bEditCustomers = new System.Windows.Forms.Button();
            this.dtpAPPROX = new System.Windows.Forms.DateTimePicker();
            this.label16 = new System.Windows.Forms.Label();
            this.cbAccept = new SummonManager.RComboBox();
            this.tbQUANTITY = new SummonManager.RNumericUpDown();
            this.dtpPTIME = new System.Windows.Forms.DateTimePicker();
            this.dtpCREATED = new System.Windows.Forms.DateTimePicker();
            this.cbMountingKit = new SummonManager.RComboBox();
            this.cbSISP = new SummonManager.RComboBox();
            this.cbCustomers = new SummonManager.RComboBox();
            this.tbDELIVERY = new System.Windows.Forms.TextBox();
            this.tbSHIPPING = new System.Windows.Forms.TextBox();
            this.tbPayStatus = new System.Windows.Forms.TextBox();
            this.tbCONTRACT = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbIDS = new System.Windows.Forms.TextBox();
            this.bPurchMat = new System.Windows.Forms.Button();
            this.bDelSummon = new System.Windows.Forms.Button();
            this.bEdit = new System.Windows.Forms.Button();
            this.bSave = new System.Windows.Forms.Button();
            this.bPrint = new System.Windows.Forms.Button();
            this.bCancel = new System.Windows.Forms.Button();
            this.chbDeterm = new System.Windows.Forms.CheckBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.bViewWP = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.bEditWP = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.summonNotes1 = new SummonManager.SummonNotes();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbQUANTITY)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.chbDocsRdy);
            this.splitContainer1.Panel1.Controls.Add(this.chbBillPayed);
            this.splitContainer1.Panel1.Controls.Add(this.label19);
            this.splitContainer1.Panel1.Controls.Add(this.label21);
            this.splitContainer1.Panel1.Controls.Add(this.summonTransfer2);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.tbSubStatus);
            this.splitContainer1.Panel1.Controls.Add(this.tbStatus);
            this.splitContainer1.Panel1.Controls.Add(this.label14);
            this.splitContainer1.Panel1.Controls.Add(this.label8);
            this.splitContainer1.Panel1.Controls.Add(this.summonTransfer1);
            this.splitContainer1.Panel1.Controls.Add(this.wpNameView1);
            this.splitContainer1.Panel1.Controls.Add(this.cbCustDept);
            this.splitContainer1.Panel1.Controls.Add(this.label20);
            this.splitContainer1.Panel1.Controls.Add(this.cbPacking);
            this.splitContainer1.Panel1.Controls.Add(this.label18);
            this.splitContainer1.Panel1.Controls.Add(this.bEditCustomers);
            this.splitContainer1.Panel1.Controls.Add(this.dtpAPPROX);
            this.splitContainer1.Panel1.Controls.Add(this.label16);
            this.splitContainer1.Panel1.Controls.Add(this.cbAccept);
            this.splitContainer1.Panel1.Controls.Add(this.tbQUANTITY);
            this.splitContainer1.Panel1.Controls.Add(this.dtpPTIME);
            this.splitContainer1.Panel1.Controls.Add(this.dtpCREATED);
            this.splitContainer1.Panel1.Controls.Add(this.cbMountingKit);
            this.splitContainer1.Panel1.Controls.Add(this.cbSISP);
            this.splitContainer1.Panel1.Controls.Add(this.cbCustomers);
            this.splitContainer1.Panel1.Controls.Add(this.tbDELIVERY);
            this.splitContainer1.Panel1.Controls.Add(this.tbSHIPPING);
            this.splitContainer1.Panel1.Controls.Add(this.tbPayStatus);
            this.splitContainer1.Panel1.Controls.Add(this.tbCONTRACT);
            this.splitContainer1.Panel1.Controls.Add(this.label13);
            this.splitContainer1.Panel1.Controls.Add(this.label12);
            this.splitContainer1.Panel1.Controls.Add(this.label11);
            this.splitContainer1.Panel1.Controls.Add(this.label10);
            this.splitContainer1.Panel1.Controls.Add(this.label9);
            this.splitContainer1.Panel1.Controls.Add(this.label7);
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.label15);
            this.splitContainer1.Panel1.Controls.Add(this.label17);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.tbIDS);
            this.splitContainer1.Panel1.Controls.Add(this.bPurchMat);
            this.splitContainer1.Panel1.Controls.Add(this.bDelSummon);
            this.splitContainer1.Panel1.Controls.Add(this.bEdit);
            this.splitContainer1.Panel1.Controls.Add(this.bSave);
            this.splitContainer1.Panel1.Controls.Add(this.bPrint);
            this.splitContainer1.Panel1.Controls.Add(this.bCancel);
            this.splitContainer1.Panel1.Controls.Add(this.chbDeterm);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1175, 891);
            this.splitContainer1.SplitterDistance = 618;
            this.splitContainer1.TabIndex = 277;
            // 
            // chbDocsRdy
            // 
            this.chbDocsRdy.AutoSize = true;
            this.chbDocsRdy.Checked = true;
            this.chbDocsRdy.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbDocsRdy.Location = new System.Drawing.Point(190, 567);
            this.chbDocsRdy.Name = "chbDocsRdy";
            this.chbDocsRdy.Size = new System.Drawing.Size(149, 20);
            this.chbDocsRdy.TabIndex = 326;
            this.chbDocsRdy.Text = "Документы готовы";
            this.chbDocsRdy.UseVisualStyleBackColor = true;
            // 
            // chbBillPayed
            // 
            this.chbBillPayed.AutoSize = true;
            this.chbBillPayed.Checked = true;
            this.chbBillPayed.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbBillPayed.Location = new System.Drawing.Point(190, 539);
            this.chbBillPayed.Name = "chbBillPayed";
            this.chbBillPayed.Size = new System.Drawing.Size(154, 20);
            this.chbBillPayed.TabIndex = 327;
            this.chbBillPayed.Text = "Счёт оплачен 100%";
            this.chbBillPayed.UseVisualStyleBackColor = true;
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(6, 567);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(174, 18);
            this.label19.TabIndex = 324;
            this.label19.Text = "Состояние документов";
            // 
            // label21
            // 
            this.label21.Location = new System.Drawing.Point(6, 539);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(120, 18);
            this.label21.TabIndex = 325;
            this.label21.Text = "Состояние счёта";
            // 
            // summonTransfer2
            // 
            this.summonTransfer2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.summonTransfer2.Location = new System.Drawing.Point(4, 736);
            this.summonTransfer2.Margin = new System.Windows.Forms.Padding(4);
            this.summonTransfer2.Name = "summonTransfer2";
            this.summonTransfer2.Size = new System.Drawing.Size(477, 96);
            this.summonTransfer2.TabIndex = 323;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(145, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 16);
            this.label1.TabIndex = 322;
            this.label1.Text = "Извещение №";
            // 
            // tbSubStatus
            // 
            this.tbSubStatus.Location = new System.Drawing.Point(189, 507);
            this.tbSubStatus.Name = "tbSubStatus";
            this.tbSubStatus.Size = new System.Drawing.Size(284, 22);
            this.tbSubStatus.TabIndex = 320;
            // 
            // tbStatus
            // 
            this.tbStatus.Location = new System.Drawing.Point(189, 479);
            this.tbStatus.Name = "tbStatus";
            this.tbStatus.Size = new System.Drawing.Size(284, 22);
            this.tbStatus.TabIndex = 321;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(4, 507);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(135, 16);
            this.label14.TabIndex = 318;
            this.label14.Text = "Текущий субстатус";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 482);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(112, 16);
            this.label8.TabIndex = 319;
            this.label8.Text = "Текущий статус";
            // 
            // summonTransfer1
            // 
            this.summonTransfer1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.summonTransfer1.Location = new System.Drawing.Point(1, 636);
            this.summonTransfer1.Margin = new System.Windows.Forms.Padding(4);
            this.summonTransfer1.Name = "summonTransfer1";
            this.summonTransfer1.Size = new System.Drawing.Size(488, 92);
            this.summonTransfer1.TabIndex = 316;
            // 
            // wpNameView1
            // 
            this.wpNameView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.wpNameView1.Location = new System.Drawing.Point(191, 70);
            this.wpNameView1.Margin = new System.Windows.Forms.Padding(4);
            this.wpNameView1.Name = "wpNameView1";
            this.wpNameView1.Size = new System.Drawing.Size(417, 31);
            this.wpNameView1.TabIndex = 317;
            // 
            // cbCustDept
            // 
            this.cbCustDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCustDept.FormattingEnabled = true;
            this.cbCustDept.Location = new System.Drawing.Point(195, 277);
            this.cbCustDept.Name = "cbCustDept";
            this.cbCustDept.Size = new System.Drawing.Size(393, 24);
            this.cbCustDept.TabIndex = 315;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(6, 277);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(138, 16);
            this.label20.TabIndex = 314;
            this.label20.Text = "Отдел организации";
            // 
            // cbPacking
            // 
            this.cbPacking.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPacking.FormattingEnabled = true;
            this.cbPacking.Location = new System.Drawing.Point(194, 134);
            this.cbPacking.Name = "cbPacking";
            this.cbPacking.Size = new System.Drawing.Size(413, 24);
            this.cbPacking.TabIndex = 313;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(6, 107);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(149, 16);
            this.label18.TabIndex = 312;
            this.label18.Text = "Монтажный комплект";
            // 
            // bEditCustomers
            // 
            this.bEditCustomers.Location = new System.Drawing.Point(594, 247);
            this.bEditCustomers.Name = "bEditCustomers";
            this.bEditCustomers.Size = new System.Drawing.Size(16, 55);
            this.bEditCustomers.TabIndex = 311;
            this.bEditCustomers.Text = "+";
            this.bEditCustomers.UseVisualStyleBackColor = true;
            this.bEditCustomers.Click += new System.EventHandler(this.bEditCustomers_Click);
            // 
            // dtpAPPROX
            // 
            this.dtpAPPROX.Enabled = false;
            this.dtpAPPROX.Location = new System.Drawing.Point(192, 449);
            this.dtpAPPROX.Name = "dtpAPPROX";
            this.dtpAPPROX.Size = new System.Drawing.Size(200, 22);
            this.dtpAPPROX.TabIndex = 310;
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(4, 449);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(186, 36);
            this.label16.TabIndex = 309;
            this.label16.Text = "Ориентировочная дата сдачи";
            // 
            // cbAccept
            // 
            this.cbAccept.FormattingEnabled = true;
            this.cbAccept.Location = new System.Drawing.Point(194, 219);
            this.cbAccept.Name = "cbAccept";
            this.cbAccept.Size = new System.Drawing.Size(416, 24);
            this.cbAccept.TabIndex = 308;
            // 
            // tbQUANTITY
            // 
            this.tbQUANTITY.Location = new System.Drawing.Point(193, 164);
            this.tbQUANTITY.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.tbQUANTITY.Name = "tbQUANTITY";
            this.tbQUANTITY.Size = new System.Drawing.Size(201, 22);
            this.tbQUANTITY.TabIndex = 307;
            // 
            // dtpPTIME
            // 
            this.dtpPTIME.Location = new System.Drawing.Point(194, 191);
            this.dtpPTIME.Name = "dtpPTIME";
            this.dtpPTIME.Size = new System.Drawing.Size(200, 22);
            this.dtpPTIME.TabIndex = 306;
            // 
            // dtpCREATED
            // 
            this.dtpCREATED.Enabled = false;
            this.dtpCREATED.Location = new System.Drawing.Point(194, 46);
            this.dtpCREATED.Name = "dtpCREATED";
            this.dtpCREATED.Size = new System.Drawing.Size(200, 22);
            this.dtpCREATED.TabIndex = 305;
            // 
            // cbMountingKit
            // 
            this.cbMountingKit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMountingKit.FormattingEnabled = true;
            this.cbMountingKit.Items.AddRange(new object[] {
            "ДА",
            "НЕТ"});
            this.cbMountingKit.Location = new System.Drawing.Point(193, 104);
            this.cbMountingKit.Name = "cbMountingKit";
            this.cbMountingKit.Size = new System.Drawing.Size(415, 24);
            this.cbMountingKit.TabIndex = 304;
            // 
            // cbSISP
            // 
            this.cbSISP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSISP.FormattingEnabled = true;
            this.cbSISP.Items.AddRange(new object[] {
            "НЕТ",
            "ДА"});
            this.cbSISP.Location = new System.Drawing.Point(192, 419);
            this.cbSISP.Name = "cbSISP";
            this.cbSISP.Size = new System.Drawing.Size(415, 24);
            this.cbSISP.TabIndex = 303;
            // 
            // cbCustomers
            // 
            this.cbCustomers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCustomers.FormattingEnabled = true;
            this.cbCustomers.Location = new System.Drawing.Point(194, 247);
            this.cbCustomers.Name = "cbCustomers";
            this.cbCustomers.Size = new System.Drawing.Size(394, 24);
            this.cbCustomers.TabIndex = 302;
            this.cbCustomers.SelectedIndexChanged += new System.EventHandler(this.cbCustomers_SelectedIndexChanged);
            // 
            // tbDELIVERY
            // 
            this.tbDELIVERY.Location = new System.Drawing.Point(193, 393);
            this.tbDELIVERY.Name = "tbDELIVERY";
            this.tbDELIVERY.Size = new System.Drawing.Size(415, 22);
            this.tbDELIVERY.TabIndex = 299;
            // 
            // tbSHIPPING
            // 
            this.tbSHIPPING.Location = new System.Drawing.Point(193, 365);
            this.tbSHIPPING.Name = "tbSHIPPING";
            this.tbSHIPPING.Size = new System.Drawing.Size(415, 22);
            this.tbSHIPPING.TabIndex = 298;
            // 
            // tbPayStatus
            // 
            this.tbPayStatus.Location = new System.Drawing.Point(193, 337);
            this.tbPayStatus.Name = "tbPayStatus";
            this.tbPayStatus.Size = new System.Drawing.Size(415, 22);
            this.tbPayStatus.TabIndex = 301;
            // 
            // tbCONTRACT
            // 
            this.tbCONTRACT.Location = new System.Drawing.Point(193, 304);
            this.tbCONTRACT.Name = "tbCONTRACT";
            this.tbCONTRACT.Size = new System.Drawing.Size(415, 22);
            this.tbCONTRACT.TabIndex = 300;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(5, 424);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(60, 16);
            this.label13.TabIndex = 289;
            this.label13.Text = "СИ и СП";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(5, 396);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(127, 16);
            this.label12.TabIndex = 290;
            this.label12.Text = "Условия поставки";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(5, 368);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(126, 16);
            this.label11.TabIndex = 291;
            this.label11.Text = "Условия отгрузки";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(5, 340);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(105, 16);
            this.label10.TabIndex = 286;
            this.label10.Text = "Статус оплаты";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(5, 307);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(141, 16);
            this.label9.TabIndex = 287;
            this.label9.Text = "№ Счёта и договора";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 250);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(160, 16);
            this.label7.TabIndex = 288;
            this.label7.Text = "Организация заказчик";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 222);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 16);
            this.label6.TabIndex = 295;
            this.label6.Text = "Приемка";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 194);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(140, 16);
            this.label5.TabIndex = 296;
            this.label5.Text = "Срок сдачи изделия";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 166);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 16);
            this.label4.TabIndex = 297;
            this.label4.Text = "Количество*";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 51);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(115, 16);
            this.label15.TabIndex = 292;
            this.label15.Text = "Дата извещения";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(5, 142);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(71, 16);
            this.label17.TabIndex = 293;
            this.label17.Text = "Упаковка";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(172, 16);
            this.label2.TabIndex = 294;
            this.label2.Text = "Наименование продукта";
            // 
            // tbIDS
            // 
            this.tbIDS.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.tbIDS.Location = new System.Drawing.Point(255, 6);
            this.tbIDS.Name = "tbIDS";
            this.tbIDS.ReadOnly = true;
            this.tbIDS.Size = new System.Drawing.Size(133, 22);
            this.tbIDS.TabIndex = 285;
            // 
            // bPurchMat
            // 
            this.bPurchMat.Location = new System.Drawing.Point(239, 833);
            this.bPurchMat.Name = "bPurchMat";
            this.bPurchMat.Size = new System.Drawing.Size(90, 49);
            this.bPurchMat.TabIndex = 284;
            this.bPurchMat.Text = "Покупные материалы";
            this.bPurchMat.UseVisualStyleBackColor = true;
            this.bPurchMat.Click += new System.EventHandler(this.bPurchMat_Click);
            // 
            // bDelSummon
            // 
            this.bDelSummon.Location = new System.Drawing.Point(335, 833);
            this.bDelSummon.Name = "bDelSummon";
            this.bDelSummon.Size = new System.Drawing.Size(90, 49);
            this.bDelSummon.TabIndex = 283;
            this.bDelSummon.Text = "Удалить извещение";
            this.bDelSummon.UseVisualStyleBackColor = true;
            this.bDelSummon.Click += new System.EventHandler(this.bDelSummon_Click);
            // 
            // bEdit
            // 
            this.bEdit.Location = new System.Drawing.Point(71, 833);
            this.bEdit.Name = "bEdit";
            this.bEdit.Size = new System.Drawing.Size(71, 49);
            this.bEdit.TabIndex = 281;
            this.bEdit.Text = "Редактировать";
            this.bEdit.UseVisualStyleBackColor = true;
            this.bEdit.Click += new System.EventHandler(this.bEdit_Click);
            // 
            // bSave
            // 
            this.bSave.Location = new System.Drawing.Point(148, 833);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(85, 49);
            this.bSave.TabIndex = 280;
            this.bSave.Text = "Сохранить";
            this.bSave.UseVisualStyleBackColor = true;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // bPrint
            // 
            this.bPrint.Enabled = false;
            this.bPrint.Location = new System.Drawing.Point(1, 833);
            this.bPrint.Name = "bPrint";
            this.bPrint.Size = new System.Drawing.Size(64, 49);
            this.bPrint.TabIndex = 279;
            this.bPrint.Text = "Печать";
            this.bPrint.UseVisualStyleBackColor = true;
            this.bPrint.Click += new System.EventHandler(this.bPrint_Click);
            // 
            // bCancel
            // 
            this.bCancel.Location = new System.Drawing.Point(431, 833);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(68, 49);
            this.bCancel.TabIndex = 278;
            this.bCancel.Text = "Отмена";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // chbDeterm
            // 
            this.chbDeterm.AutoSize = true;
            this.chbDeterm.Checked = true;
            this.chbDeterm.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbDeterm.Location = new System.Drawing.Point(398, 449);
            this.chbDeterm.Name = "chbDeterm";
            this.chbDeterm.Size = new System.Drawing.Size(128, 20);
            this.chbDeterm.TabIndex = 277;
            this.chbDeterm.Text = "Не определено";
            this.chbDeterm.UseVisualStyleBackColor = true;
            this.chbDeterm.CheckedChanged += new System.EventHandler(this.chbDeterm_CheckedChanged);
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.bViewWP);
            this.splitContainer2.Panel1.Controls.Add(this.label3);
            this.splitContainer2.Panel1.Controls.Add(this.bEditWP);
            this.splitContainer2.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.summonNotes1);
            this.splitContainer2.Size = new System.Drawing.Size(553, 891);
            this.splitContainer2.SplitterDistance = 471;
            this.splitContainer2.TabIndex = 0;
            // 
            // bViewWP
            // 
            this.bViewWP.Location = new System.Drawing.Point(456, 5);
            this.bViewWP.Name = "bViewWP";
            this.bViewWP.Size = new System.Drawing.Size(84, 23);
            this.bViewWP.TabIndex = 43;
            this.bViewWP.Text = "Просмотр";
            this.bViewWP.UseVisualStyleBackColor = true;
            this.bViewWP.Click += new System.EventHandler(this.bViewWP_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(166, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(239, 16);
            this.label3.TabIndex = 42;
            this.label3.Text = "Необходимые сведения о продукте";
            // 
            // bEditWP
            // 
            this.bEditWP.Location = new System.Drawing.Point(3, 6);
            this.bEditWP.Name = "bEditWP";
            this.bEditWP.Size = new System.Drawing.Size(122, 23);
            this.bEditWP.TabIndex = 41;
            this.bEditWP.Text = "Редактировать";
            this.bEditWP.UseVisualStyleBackColor = true;
            this.bEditWP.Click += new System.EventHandler(this.bEditWP_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.AutoScroll = true;
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 46);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 484F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(545, 420);
            this.tableLayoutPanel1.TabIndex = 38;
            // 
            // summonNotes1
            // 
            this.summonNotes1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.summonNotes1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.summonNotes1.Location = new System.Drawing.Point(0, 0);
            this.summonNotes1.Margin = new System.Windows.Forms.Padding(4);
            this.summonNotes1.Name = "summonNotes1";
            this.summonNotes1.Size = new System.Drawing.Size(551, 414);
            this.summonNotes1.TabIndex = 33;
            // 
            // ShowSummon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1175, 891);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "ShowSummon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Просмотр извещения (менеджер)";
            this.Load += new System.EventHandler(this.ShowSummon_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tbQUANTITY)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private SplitContainer splitContainer1;
        private Label label1;
        private Label label14;
        private Label label8;
        private Label label20;
        private Label label18;
        private Label label16;
        private Label label13;
        private Label label12;
        private Label label11;
        private Label label10;
        private Label label9;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label15;
        private Label label17;
        private Label label2;
        private SplitContainer splitContainer2;
        private Label label19;
        private Label label21;
        private Label label3;
        public TextBox tbSubStatus;
        public TextBox tbStatus;
        public SummonTransfer summonTransfer1;
        public SummonManager.Controls.WPNameView wpNameView1;
        public RComboBox cbCustDept;
        public RComboBox cbPacking;
        public Button bEditCustomers;
        public DateTimePicker dtpAPPROX;
        public RComboBox cbAccept;
        public RNumericUpDown tbQUANTITY;
        public DateTimePicker dtpPTIME;
        public RComboBox cbMountingKit;
        public RComboBox cbSISP;
        public RComboBox cbCustomers;
        public TextBox tbDELIVERY;
        public TextBox tbSHIPPING;
        public TextBox tbPayStatus;
        public TextBox tbCONTRACT;
        public Button bPurchMat;
        public Button bDelSummon;
        public Button bEdit;
        public Button bSave;
        public Button bPrint;
        public Button bCancel;
        public CheckBox chbDeterm;
        public TableLayoutPanel tableLayoutPanel1;
        public SummonNotes summonNotes1;
        public SummonTransfer summonTransfer2;
        public CheckBox chbDocsRdy;
        public CheckBox chbBillPayed;
        public Button bEditWP;
        public TextBox tbIDS;
        public DateTimePicker dtpCREATED;
        private Button bViewWP;
    }
}