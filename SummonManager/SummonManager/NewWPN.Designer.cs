﻿namespace SummonManager
{
    partial class NewWPN
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
            this.tbName = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbCategory = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbDecNum = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbPowerSupply = new System.Windows.Forms.TextBox();
            this.tbConfiguration = new System.Windows.Forms.TextBox();
            this.tbNote = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cbSubCategory = new System.Windows.Forms.ComboBox();
            this.pfDimDrawing = new SummonManager.Controls.PathField();
            this.pfComposition = new SummonManager.Controls.PathField();
            this.pfWIRINGDIAGRAM = new SummonManager.Controls.PathField();
            this.label10 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(217, 12);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(601, 22);
            this.tbName.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(743, 587);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Отмена";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(652, 587);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(85, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Добавить";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Наименование";
            // 
            // cbCategory
            // 
            this.cbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCategory.FormattingEnabled = true;
            this.cbCategory.Location = new System.Drawing.Point(217, 40);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(601, 24);
            this.cbCategory.TabIndex = 4;
            this.cbCategory.SelectedIndexChanged += new System.EventHandler(this.cbCategory_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Категория";
            // 
            // tbDecNum
            // 
            this.tbDecNum.Location = new System.Drawing.Point(217, 100);
            this.tbDecNum.Name = "tbDecNum";
            this.tbDecNum.Size = new System.Drawing.Size(601, 22);
            this.tbDecNum.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Децимальный номер";
            // 
            // tbPowerSupply
            // 
            this.tbPowerSupply.Location = new System.Drawing.Point(217, 467);
            this.tbPowerSupply.Name = "tbPowerSupply";
            this.tbPowerSupply.Size = new System.Drawing.Size(601, 22);
            this.tbPowerSupply.TabIndex = 1;
            // 
            // tbConfiguration
            // 
            this.tbConfiguration.Location = new System.Drawing.Point(217, 495);
            this.tbConfiguration.Name = "tbConfiguration";
            this.tbConfiguration.Size = new System.Drawing.Size(601, 22);
            this.tbConfiguration.TabIndex = 1;
            // 
            // tbNote
            // 
            this.tbNote.Location = new System.Drawing.Point(217, 523);
            this.tbNote.Multiline = true;
            this.tbNote.Name = "tbNote";
            this.tbNote.Size = new System.Drawing.Size(601, 58);
            this.tbNote.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 414);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Состав изделия";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 442);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(138, 16);
            this.label5.TabIndex = 3;
            this.label5.Text = "Габаритный чертёж";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 470);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(119, 16);
            this.label6.TabIndex = 3;
            this.label6.Text = "Электропитание";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 498);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 16);
            this.label7.TabIndex = 3;
            this.label7.Text = "Конфигурация";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 526);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 16);
            this.label8.TabIndex = 3;
            this.label8.Text = "Примечание";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 73);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(101, 16);
            this.label9.TabIndex = 3;
            this.label9.Text = "Подкатегория";
            // 
            // cbSubCategory
            // 
            this.cbSubCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSubCategory.FormattingEnabled = true;
            this.cbSubCategory.Location = new System.Drawing.Point(217, 70);
            this.cbSubCategory.Name = "cbSubCategory";
            this.cbSubCategory.Size = new System.Drawing.Size(601, 24);
            this.cbSubCategory.TabIndex = 4;
            this.cbSubCategory.SelectedIndexChanged += new System.EventHandler(this.cbSubCategory_SelectedIndexChanged);
            // 
            // pfDimDrawing
            // 
            this.pfDimDrawing.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pfDimDrawing.FullPath = "<нет>";
            this.pfDimDrawing.Location = new System.Drawing.Point(214, 434);
            this.pfDimDrawing.Margin = new System.Windows.Forms.Padding(4);
            this.pfDimDrawing.Name = "pfDimDrawing";
            this.pfDimDrawing.Required = false;
            this.pfDimDrawing.Size = new System.Drawing.Size(604, 32);
            this.pfDimDrawing.TabIndex = 6;
            // 
            // pfComposition
            // 
            this.pfComposition.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pfComposition.FullPath = "<нет>";
            this.pfComposition.Location = new System.Drawing.Point(217, 406);
            this.pfComposition.Margin = new System.Windows.Forms.Padding(4);
            this.pfComposition.Name = "pfComposition";
            this.pfComposition.Required = false;
            this.pfComposition.Size = new System.Drawing.Size(601, 32);
            this.pfComposition.TabIndex = 5;
            // 
            // pfWIRINGDIAGRAM
            // 
            this.pfWIRINGDIAGRAM.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pfWIRINGDIAGRAM.FullPath = "<нет>";
            this.pfWIRINGDIAGRAM.Location = new System.Drawing.Point(217, 129);
            this.pfWIRINGDIAGRAM.Margin = new System.Windows.Forms.Padding(4);
            this.pfWIRINGDIAGRAM.Name = "pfWIRINGDIAGRAM";
            this.pfWIRINGDIAGRAM.Required = false;
            this.pfWIRINGDIAGRAM.Size = new System.Drawing.Size(601, 32);
            this.pfWIRINGDIAGRAM.TabIndex = 5;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(9, 132);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(197, 39);
            this.label10.TabIndex = 3;
            this.label10.Text = "Схема электрическая (монтажная)";
            // 
            // NewWPN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 888);
            this.Controls.Add(this.pfDimDrawing);
            this.Controls.Add(this.pfWIRINGDIAGRAM);
            this.Controls.Add(this.pfComposition);
            this.Controls.Add(this.cbSubCategory);
            this.Controls.Add(this.cbCategory);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tbNote);
            this.Controls.Add(this.tbConfiguration);
            this.Controls.Add(this.tbPowerSupply);
            this.Controls.Add(this.tbDecNum);
            this.Controls.Add(this.tbName);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "NewWPN";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавление нового наименования изделия";
            this.Load += new System.EventHandler(this.NewWPN_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbCategory;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbDecNum;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbPowerSupply;
        private System.Windows.Forms.TextBox tbConfiguration;
        private System.Windows.Forms.TextBox tbNote;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private SummonManager.Controls.PathField pfComposition;
        private SummonManager.Controls.PathField pfDimDrawing;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbSubCategory;
        private SummonManager.Controls.PathField pfWIRINGDIAGRAM;
        private System.Windows.Forms.Label label10;
    }
}