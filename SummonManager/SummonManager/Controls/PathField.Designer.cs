namespace SummonManager.Controls
{
    partial class PathField
    {
        /// <summary> 
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Обязательный метод для поддержки конструктора - не изменяйте 
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.bPathDel = new System.Windows.Forms.Button();
            this.bPath = new System.Windows.Forms.Button();
            this.tbPath = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // bPathDel
            // 
            this.bPathDel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.bPathDel.BackgroundImage = global::SummonManager.Properties.Resources.DeleteRed;
            this.bPathDel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bPathDel.Location = new System.Drawing.Point(521, 5);
            this.bPathDel.Margin = new System.Windows.Forms.Padding(4);
            this.bPathDel.Name = "bPathDel";
            this.bPathDel.Size = new System.Drawing.Size(26, 23);
            this.bPathDel.TabIndex = 25;
            this.bPathDel.UseVisualStyleBackColor = true;
            this.bPathDel.Click += new System.EventHandler(this.bPathDel_Click);
            // 
            // bPath
            // 
            this.bPath.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.bPath.Location = new System.Drawing.Point(433, 4);
            this.bPath.Margin = new System.Windows.Forms.Padding(4);
            this.bPath.Name = "bPath";
            this.bPath.Size = new System.Drawing.Size(80, 24);
            this.bPath.TabIndex = 23;
            this.bPath.Text = "Путь";
            this.bPath.UseVisualStyleBackColor = true;
            this.bPath.Click += new System.EventHandler(this.bPath_Click);
            // 
            // tbPath
            // 
            this.tbPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tbPath.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tbPath.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tbPath.Location = new System.Drawing.Point(4, 4);
            this.tbPath.Margin = new System.Windows.Forms.Padding(4);
            this.tbPath.Name = "tbPath";
            this.tbPath.ReadOnly = true;
            this.tbPath.Size = new System.Drawing.Size(423, 22);
            this.tbPath.TabIndex = 22;
            this.tbPath.MouseLeave += new System.EventHandler(this.tbPath_MouseLeave);
            this.tbPath.Click += new System.EventHandler(this.tbPath_Click);
            this.tbPath.MouseEnter += new System.EventHandler(this.tbPath_MouseEnter);
            // 
            // PathField
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.bPathDel);
            this.Controls.Add(this.bPath);
            this.Controls.Add(this.tbPath);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "PathField";
            this.Size = new System.Drawing.Size(556, 32);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button bPathDel;
        public System.Windows.Forms.Button bPath;
        public System.Windows.Forms.TextBox tbPath;
    }
}
