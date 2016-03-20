namespace SummonManager
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
            this.tbNote = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cbSubCategory = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.pfSHILDS = new SummonManager.Controls.PathField();
            this.pfMECHPARTS = new SummonManager.Controls.PathField();
            this.pf3DSBORKA = new SummonManager.Controls.PathField();
            this.pfDimDrawing = new SummonManager.Controls.PathField();
            this.pfWIRINGDIAGRAM = new SummonManager.Controls.PathField();
            this.pfTECHREQ = new SummonManager.Controls.PathField();
            this.pfCONFIGURATION = new SummonManager.Controls.PathField();
            this.pfComposition = new SummonManager.Controls.PathField();
            this.label15 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(299, 12);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(601, 22);
            this.tbName.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(825, 720);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Отмена";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(734, 720);
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
            this.cbCategory.Location = new System.Drawing.Point(299, 40);
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
            this.tbDecNum.Location = new System.Drawing.Point(299, 100);
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
            this.tbPowerSupply.Location = new System.Drawing.Point(299, 600);
            this.tbPowerSupply.Name = "tbPowerSupply";
            this.tbPowerSupply.Size = new System.Drawing.Size(601, 22);
            this.tbPowerSupply.TabIndex = 1;
            // 
            // tbNote
            // 
            this.tbNote.Location = new System.Drawing.Point(299, 656);
            this.tbNote.Multiline = true;
            this.tbNote.Name = "tbNote";
            this.tbNote.Size = new System.Drawing.Size(601, 58);
            this.tbNote.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 199);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Состав изделия";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 260);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(138, 16);
            this.label5.TabIndex = 3;
            this.label5.Text = "Габаритный чертёж";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 603);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(119, 16);
            this.label6.TabIndex = 3;
            this.label6.Text = "Электропитание";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 229);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 16);
            this.label7.TabIndex = 3;
            this.label7.Text = "Конфигурация";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 659);
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
            this.cbSubCategory.Location = new System.Drawing.Point(299, 70);
            this.cbSubCategory.Name = "cbSubCategory";
            this.cbSubCategory.Size = new System.Drawing.Size(601, 24);
            this.cbSubCategory.TabIndex = 4;
            this.cbSubCategory.SelectedIndexChanged += new System.EventHandler(this.cbSubCategory_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(13, 137);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(233, 16);
            this.label10.TabIndex = 3;
            this.label10.Text = "Схема электрическая (монтажная)";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(14, 169);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(174, 16);
            this.label11.TabIndex = 3;
            this.label11.Text = "Технические требования";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(18, 289);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(73, 16);
            this.label12.TabIndex = 3;
            this.label12.Text = "3Д сборка";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(19, 319);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(208, 16);
            this.label13.TabIndex = 3;
            this.label13.Text = "Проект механических деталей";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(16, 503);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(59, 16);
            this.label14.TabIndex = 3;
            this.label14.Text = "Шильды";
            // 
            // pfSHILDS
            // 
            this.pfSHILDS.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pfSHILDS.FullPath = "<нет>";
            this.pfSHILDS.Location = new System.Drawing.Point(299, 493);
            this.pfSHILDS.Margin = new System.Windows.Forms.Padding(4);
            this.pfSHILDS.Name = "pfSHILDS";
            this.pfSHILDS.Required = false;
            this.pfSHILDS.Size = new System.Drawing.Size(601, 32);
            this.pfSHILDS.TabIndex = 6;
            // 
            // pfMECHPARTS
            // 
            this.pfMECHPARTS.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pfMECHPARTS.FullPath = "<нет>";
            this.pfMECHPARTS.Location = new System.Drawing.Point(298, 316);
            this.pfMECHPARTS.Margin = new System.Windows.Forms.Padding(4);
            this.pfMECHPARTS.Name = "pfMECHPARTS";
            this.pfMECHPARTS.Required = false;
            this.pfMECHPARTS.Size = new System.Drawing.Size(601, 32);
            this.pfMECHPARTS.TabIndex = 6;
            // 
            // pf3DSBORKA
            // 
            this.pf3DSBORKA.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pf3DSBORKA.FullPath = "<нет>";
            this.pf3DSBORKA.Location = new System.Drawing.Point(299, 286);
            this.pf3DSBORKA.Margin = new System.Windows.Forms.Padding(4);
            this.pf3DSBORKA.Name = "pf3DSBORKA";
            this.pf3DSBORKA.Required = false;
            this.pf3DSBORKA.Size = new System.Drawing.Size(601, 32);
            this.pf3DSBORKA.TabIndex = 6;
            // 
            // pfDimDrawing
            // 
            this.pfDimDrawing.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pfDimDrawing.FullPath = "<нет>";
            this.pfDimDrawing.Location = new System.Drawing.Point(299, 254);
            this.pfDimDrawing.Margin = new System.Windows.Forms.Padding(4);
            this.pfDimDrawing.Name = "pfDimDrawing";
            this.pfDimDrawing.Required = false;
            this.pfDimDrawing.Size = new System.Drawing.Size(601, 32);
            this.pfDimDrawing.TabIndex = 6;
            // 
            // pfWIRINGDIAGRAM
            // 
            this.pfWIRINGDIAGRAM.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pfWIRINGDIAGRAM.FullPath = "<нет>";
            this.pfWIRINGDIAGRAM.Location = new System.Drawing.Point(299, 129);
            this.pfWIRINGDIAGRAM.Margin = new System.Windows.Forms.Padding(4);
            this.pfWIRINGDIAGRAM.Name = "pfWIRINGDIAGRAM";
            this.pfWIRINGDIAGRAM.Required = false;
            this.pfWIRINGDIAGRAM.Size = new System.Drawing.Size(601, 32);
            this.pfWIRINGDIAGRAM.TabIndex = 5;
            // 
            // pfTECHREQ
            // 
            this.pfTECHREQ.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pfTECHREQ.FullPath = "<нет>";
            this.pfTECHREQ.Location = new System.Drawing.Point(299, 160);
            this.pfTECHREQ.Margin = new System.Windows.Forms.Padding(4);
            this.pfTECHREQ.Name = "pfTECHREQ";
            this.pfTECHREQ.Required = false;
            this.pfTECHREQ.Size = new System.Drawing.Size(601, 32);
            this.pfTECHREQ.TabIndex = 5;
            // 
            // pfCONFIGURATION
            // 
            this.pfCONFIGURATION.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pfCONFIGURATION.FullPath = "<нет>";
            this.pfCONFIGURATION.Location = new System.Drawing.Point(299, 222);
            this.pfCONFIGURATION.Margin = new System.Windows.Forms.Padding(4);
            this.pfCONFIGURATION.Name = "pfCONFIGURATION";
            this.pfCONFIGURATION.Required = false;
            this.pfCONFIGURATION.Size = new System.Drawing.Size(601, 32);
            this.pfCONFIGURATION.TabIndex = 5;
            // 
            // pfComposition
            // 
            this.pfComposition.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pfComposition.FullPath = "<нет>";
            this.pfComposition.Location = new System.Drawing.Point(299, 192);
            this.pfComposition.Margin = new System.Windows.Forms.Padding(4);
            this.pfComposition.Name = "pfComposition";
            this.pfComposition.Required = false;
            this.pfComposition.Size = new System.Drawing.Size(601, 32);
            this.pfComposition.TabIndex = 5;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(19, 347);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(120, 16);
            this.label15.TabIndex = 3;
            this.label15.Text = "Комплект жгутов";
            // 
            // NewWPN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(912, 888);
            this.Controls.Add(this.pfSHILDS);
            this.Controls.Add(this.pfMECHPARTS);
            this.Controls.Add(this.pf3DSBORKA);
            this.Controls.Add(this.pfDimDrawing);
            this.Controls.Add(this.pfWIRINGDIAGRAM);
            this.Controls.Add(this.pfTECHREQ);
            this.Controls.Add(this.pfCONFIGURATION);
            this.Controls.Add(this.pfComposition);
            this.Controls.Add(this.cbSubCategory);
            this.Controls.Add(this.cbCategory);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tbNote);
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
        private SummonManager.Controls.PathField pfTECHREQ;
        private System.Windows.Forms.Label label11;
        private SummonManager.Controls.PathField pfCONFIGURATION;
        private SummonManager.Controls.PathField pf3DSBORKA;
        private System.Windows.Forms.Label label12;
        private SummonManager.Controls.PathField pfMECHPARTS;
        private System.Windows.Forms.Label label13;
        private SummonManager.Controls.PathField pfSHILDS;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
    }
}