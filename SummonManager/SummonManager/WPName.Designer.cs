namespace SummonManager
{
    partial class WPName
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
            this.dgWP = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.cbCAT = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bArchive = new System.Windows.Forms.Button();
            this.bArcShow = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgWP)).BeginInit();
            this.SuspendLayout();
            // 
            // dgWP
            // 
            this.dgWP.AllowUserToAddRows = false;
            this.dgWP.AllowUserToDeleteRows = false;
            this.dgWP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgWP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgWP.Location = new System.Drawing.Point(12, 77);
            this.dgWP.MultiSelect = false;
            this.dgWP.Name = "dgWP";
            this.dgWP.RowHeadersVisible = false;
            this.dgWP.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgWP.Size = new System.Drawing.Size(1189, 281);
            this.dgWP.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(1126, 364);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Закрыть";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button2.Location = new System.Drawing.Point(12, 364);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(86, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Добавить";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button3.Location = new System.Drawing.Point(218, 364);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(88, 23);
            this.button3.TabIndex = 1;
            this.button3.Text = "Изменить";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button4.Location = new System.Drawing.Point(104, 364);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(108, 23);
            this.button4.TabIndex = 2;
            this.button4.Text = "Клонировать";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button5.Location = new System.Drawing.Point(312, 364);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 3;
            this.button5.Text = "Удалить";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // cbCAT
            // 
            this.cbCAT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCAT.FormattingEnabled = true;
            this.cbCAT.Location = new System.Drawing.Point(164, 44);
            this.cbCAT.Name = "cbCAT";
            this.cbCAT.Size = new System.Drawing.Size(441, 24);
            this.cbCAT.TabIndex = 4;
            this.cbCAT.SelectedIndexChanged += new System.EventHandler(this.cbCAT_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Выберите категорию";
            // 
            // bArchive
            // 
            this.bArchive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bArchive.Location = new System.Drawing.Point(393, 364);
            this.bArchive.Name = "bArchive";
            this.bArchive.Size = new System.Drawing.Size(264, 23);
            this.bArchive.TabIndex = 6;
            this.bArchive.Text = "Архивировать состав изделия";
            this.bArchive.UseVisualStyleBackColor = true;
            this.bArchive.Click += new System.EventHandler(this.bArchive_Click);
            // 
            // bArcShow
            // 
            this.bArcShow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bArcShow.Location = new System.Drawing.Point(663, 364);
            this.bArcShow.Name = "bArcShow";
            this.bArcShow.Size = new System.Drawing.Size(260, 23);
            this.bArcShow.TabIndex = 7;
            this.bArcShow.Text = "Показать архив составов изделия";
            this.bArcShow.UseVisualStyleBackColor = true;
            this.bArcShow.Click += new System.EventHandler(this.bArcShow_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(611, 44);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(224, 23);
            this.button6.TabIndex = 8;
            this.button6.Text = "Редактировать категории";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // WPName
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1213, 391);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.bArcShow);
            this.Controls.Add(this.bArchive);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbCAT);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgWP);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "WPName";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Наименование изделия";
            this.Load += new System.EventHandler(this.WPName_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgWP)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgWP;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.ComboBox cbCAT;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bArchive;
        private System.Windows.Forms.Button bArcShow;
        private System.Windows.Forms.Button button6;
    }
}