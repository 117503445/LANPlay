namespace ScreenShare_Server
{
    partial class MainForm
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
            this.BtnCast = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnCast
            // 
            this.BtnCast.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnCast.Font = new System.Drawing.Font("微软雅黑", 42F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnCast.Location = new System.Drawing.Point(0, 0);
            this.BtnCast.Name = "BtnCast";
            this.BtnCast.Size = new System.Drawing.Size(439, 228);
            this.BtnCast.TabIndex = 0;
            this.BtnCast.Text = "广播";
            this.BtnCast.UseVisualStyleBackColor = true;
            this.BtnCast.Click += new System.EventHandler(this.BtnCast_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 228);
            this.Controls.Add(this.BtnCast);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.Text = "ScreenShare-Server";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnCast;
    }
}