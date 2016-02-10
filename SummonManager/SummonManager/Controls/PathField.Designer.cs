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
            this.bOpen = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bPathDel
            // 
            this.bPathDel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.bPathDel.BackgroundImage = global::SummonManager.Properties.Resources.DeleteRed;
            this.bPathDel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bPathDel.Location = new System.Drawing.Point(196, 5);
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
            this.bPath.Location = new System.Drawing.Point(108, 4);
            this.bPath.Margin = new System.Windows.Forms.Padding(4);
            this.bPath.Name = "bPath";
            this.bPath.Size = new System.Drawing.Size(80, 24);
            this.bPath.TabIndex = 23;
            this.bPath.Text = "Путь";
            this.bPath.UseVisualStyleBackColor = true;
            this.bPath.Click += new System.EventHandler(this.bPath_Click);
            // 
            // bOpen
            // 
            this.bOpen.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.bOpen.Image = global::SummonManager.Properties.Resources.document_open1;
            this.bOpen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bOpen.Location = new System.Drawing.Point(10, 5);
            this.bOpen.Name = "bOpen";
            this.bOpen.Size = new System.Drawing.Size(91, 24);
            this.bOpen.TabIndex = 26;
            this.bOpen.Text = "Открыть";
            this.bOpen.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bOpen.UseVisualStyleBackColor = true;
            this.bOpen.Click += new System.EventHandler(this.bOpen_Click);
            // 
            // PathField
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.bOpen);
            this.Controls.Add(this.bPathDel);
            this.Controls.Add(this.bPath);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "PathField";
            this.Size = new System.Drawing.Size(231, 32);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button bPathDel;
        public System.Windows.Forms.Button bPath;
        public System.Windows.Forms.Button bOpen;


    }
}
