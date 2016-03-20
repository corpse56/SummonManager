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
            this.bClose = new System.Windows.Forms.Button();
            this.bAdd = new System.Windows.Forms.Button();
            this.bEdit = new System.Windows.Forms.Button();
            this.bClone = new System.Windows.Forms.Button();
            this.bDelete = new System.Windows.Forms.Button();
            this.cbCAT = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bArchive = new System.Windows.Forms.Button();
            this.bArcShow = new System.Windows.Forms.Button();
            this.bEditCategory = new System.Windows.Forms.Button();
            this.bChoose = new System.Windows.Forms.Button();
            this.cbSubCat = new System.Windows.Forms.ComboBox();
            this.bEditSubCategory = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.bView = new System.Windows.Forms.Button();
            this.cbTYPE = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
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
            this.dgWP.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgWP.Location = new System.Drawing.Point(12, 135);
            this.dgWP.MultiSelect = false;
            this.dgWP.Name = "dgWP";
            this.dgWP.RowHeadersVisible = false;
            this.dgWP.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgWP.Size = new System.Drawing.Size(1189, 315);
            this.dgWP.TabIndex = 0;
            this.dgWP.DoubleClick += new System.EventHandler(this.dgWP_DoubleClick);
            // 
            // bClose
            // 
            this.bClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bClose.Location = new System.Drawing.Point(1126, 456);
            this.bClose.Name = "bClose";
            this.bClose.Size = new System.Drawing.Size(75, 23);
            this.bClose.TabIndex = 1;
            this.bClose.Text = "Закрыть";
            this.bClose.UseVisualStyleBackColor = true;
            this.bClose.Click += new System.EventHandler(this.button1_Click);
            // 
            // bAdd
            // 
            this.bAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bAdd.Location = new System.Drawing.Point(12, 456);
            this.bAdd.Name = "bAdd";
            this.bAdd.Size = new System.Drawing.Size(86, 23);
            this.bAdd.TabIndex = 1;
            this.bAdd.Text = "Добавить";
            this.bAdd.UseVisualStyleBackColor = true;
            this.bAdd.Click += new System.EventHandler(this.button2_Click);
            // 
            // bEdit
            // 
            this.bEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bEdit.Location = new System.Drawing.Point(218, 456);
            this.bEdit.Name = "bEdit";
            this.bEdit.Size = new System.Drawing.Size(88, 23);
            this.bEdit.TabIndex = 1;
            this.bEdit.Text = "Изменить";
            this.bEdit.UseVisualStyleBackColor = true;
            this.bEdit.Click += new System.EventHandler(this.button3_Click);
            // 
            // bClone
            // 
            this.bClone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bClone.Location = new System.Drawing.Point(104, 456);
            this.bClone.Name = "bClone";
            this.bClone.Size = new System.Drawing.Size(108, 23);
            this.bClone.TabIndex = 2;
            this.bClone.Text = "Клонировать";
            this.bClone.UseVisualStyleBackColor = true;
            this.bClone.Click += new System.EventHandler(this.button4_Click);
            // 
            // bDelete
            // 
            this.bDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bDelete.Location = new System.Drawing.Point(312, 456);
            this.bDelete.Name = "bDelete";
            this.bDelete.Size = new System.Drawing.Size(75, 23);
            this.bDelete.TabIndex = 3;
            this.bDelete.Text = "Удалить";
            this.bDelete.UseVisualStyleBackColor = true;
            this.bDelete.Click += new System.EventHandler(this.button5_Click);
            // 
            // cbCAT
            // 
            this.cbCAT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCAT.FormattingEnabled = true;
            this.cbCAT.Location = new System.Drawing.Point(194, 65);
            this.cbCAT.Name = "cbCAT";
            this.cbCAT.Size = new System.Drawing.Size(291, 24);
            this.cbCAT.TabIndex = 4;
            this.cbCAT.SelectedIndexChanged += new System.EventHandler(this.cbCAT_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Выберите категорию";
            // 
            // bArchive
            // 
            this.bArchive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bArchive.Location = new System.Drawing.Point(939, 244);
            this.bArchive.Name = "bArchive";
            this.bArchive.Size = new System.Drawing.Size(40, 23);
            this.bArchive.TabIndex = 6;
            this.bArchive.Text = "Архивировать состав изделия";
            this.bArchive.UseVisualStyleBackColor = true;
            this.bArchive.Visible = false;
            this.bArchive.Click += new System.EventHandler(this.bArchive_Click);
            // 
            // bArcShow
            // 
            this.bArcShow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bArcShow.Location = new System.Drawing.Point(985, 244);
            this.bArcShow.Name = "bArcShow";
            this.bArcShow.Size = new System.Drawing.Size(36, 23);
            this.bArcShow.TabIndex = 7;
            this.bArcShow.Text = "Показать архив составов изделия";
            this.bArcShow.UseVisualStyleBackColor = true;
            this.bArcShow.Visible = false;
            this.bArcShow.Click += new System.EventHandler(this.bArcShow_Click);
            // 
            // bEditCategory
            // 
            this.bEditCategory.Location = new System.Drawing.Point(491, 65);
            this.bEditCategory.Name = "bEditCategory";
            this.bEditCategory.Size = new System.Drawing.Size(214, 23);
            this.bEditCategory.TabIndex = 8;
            this.bEditCategory.Text = "Редактировать категории";
            this.bEditCategory.UseVisualStyleBackColor = true;
            this.bEditCategory.Click += new System.EventHandler(this.button6_Click);
            // 
            // bChoose
            // 
            this.bChoose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bChoose.Location = new System.Drawing.Point(1043, 456);
            this.bChoose.Name = "bChoose";
            this.bChoose.Size = new System.Drawing.Size(77, 23);
            this.bChoose.TabIndex = 9;
            this.bChoose.Text = "Выбрать";
            this.bChoose.UseVisualStyleBackColor = true;
            this.bChoose.Click += new System.EventHandler(this.button7_Click);
            // 
            // cbSubCat
            // 
            this.cbSubCat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSubCat.FormattingEnabled = true;
            this.cbSubCat.Location = new System.Drawing.Point(194, 102);
            this.cbSubCat.Name = "cbSubCat";
            this.cbSubCat.Size = new System.Drawing.Size(291, 24);
            this.cbSubCat.TabIndex = 4;
            this.cbSubCat.SelectedIndexChanged += new System.EventHandler(this.cbSubCat_SelectedIndexChanged);
            // 
            // bEditSubCategory
            // 
            this.bEditSubCategory.Location = new System.Drawing.Point(711, 65);
            this.bEditSubCategory.Name = "bEditSubCategory";
            this.bEditSubCategory.Size = new System.Drawing.Size(368, 23);
            this.bEditSubCategory.TabIndex = 10;
            this.bEditSubCategory.Text = "Редактировать подкатегории выбранной категории";
            this.bEditSubCategory.UseVisualStyleBackColor = true;
            this.bEditSubCategory.Click += new System.EventHandler(this.button8_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(170, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Выберите подкатегорию";
            // 
            // bView
            // 
            this.bView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bView.Location = new System.Drawing.Point(393, 456);
            this.bView.Name = "bView";
            this.bView.Size = new System.Drawing.Size(92, 23);
            this.bView.TabIndex = 11;
            this.bView.Text = "Просмотр";
            this.bView.UseVisualStyleBackColor = true;
            this.bView.Click += new System.EventHandler(this.bView_Click);
            // 
            // cbTYPE
            // 
            this.cbTYPE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTYPE.FormattingEnabled = true;
            this.cbTYPE.Location = new System.Drawing.Point(194, 12);
            this.cbTYPE.Name = "cbTYPE";
            this.cbTYPE.Size = new System.Drawing.Size(291, 24);
            this.cbTYPE.TabIndex = 4;
            this.cbTYPE.SelectedIndexChanged += new System.EventHandler(this.cbCAT_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Выберите тип";
            // 
            // WPName
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1213, 483);
            this.Controls.Add(this.bView);
            this.Controls.Add(this.bEditSubCategory);
            this.Controls.Add(this.bChoose);
            this.Controls.Add(this.bEditCategory);
            this.Controls.Add(this.bArcShow);
            this.Controls.Add(this.bArchive);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbSubCat);
            this.Controls.Add(this.cbTYPE);
            this.Controls.Add(this.cbCAT);
            this.Controls.Add(this.bDelete);
            this.Controls.Add(this.bClone);
            this.Controls.Add(this.bEdit);
            this.Controls.Add(this.bAdd);
            this.Controls.Add(this.bClose);
            this.Controls.Add(this.dgWP);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "WPName";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Справочник изделий";
            this.Load += new System.EventHandler(this.WPName_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgWP)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgWP;
        private System.Windows.Forms.Button bClose;
        private System.Windows.Forms.Button bAdd;
        private System.Windows.Forms.Button bEdit;
        private System.Windows.Forms.Button bClone;
        private System.Windows.Forms.Button bDelete;
        private System.Windows.Forms.ComboBox cbCAT;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bArchive;
        private System.Windows.Forms.Button bArcShow;
        private System.Windows.Forms.Button bEditCategory;
        private System.Windows.Forms.Button bChoose;
        private System.Windows.Forms.ComboBox cbSubCat;
        private System.Windows.Forms.Button bEditSubCategory;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bView;
        private System.Windows.Forms.ComboBox cbTYPE;
        private System.Windows.Forms.Label label3;
    }
}