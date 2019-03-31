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
                Udp.Dispose();
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
            this.BtnChange = new System.Windows.Forms.Button();
            this.LbIP = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // BtnCast
            // 
            this.BtnCast.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnCast.Location = new System.Drawing.Point(12, 12);
            this.BtnCast.Name = "BtnCast";
            this.BtnCast.Size = new System.Drawing.Size(119, 39);
            this.BtnCast.TabIndex = 0;
            this.BtnCast.Text = "广播";
            this.BtnCast.UseVisualStyleBackColor = true;
            this.BtnCast.Click += new System.EventHandler(this.BtnCast_Click);
            // 
            // BtnChange
            // 
            this.BtnChange.Location = new System.Drawing.Point(12, 69);
            this.BtnChange.Name = "BtnChange";
            this.BtnChange.Size = new System.Drawing.Size(119, 40);
            this.BtnChange.TabIndex = 1;
            this.BtnChange.Text = "更改分辨率";
            this.BtnChange.UseVisualStyleBackColor = true;
            this.BtnChange.Click += new System.EventHandler(this.BtnChange_Click);
            // 
            // LbIP
            // 
            this.LbIP.FormattingEnabled = true;
            this.LbIP.ItemHeight = 17;
            this.LbIP.Location = new System.Drawing.Point(149, 12);
            this.LbIP.Name = "LbIP";
            this.LbIP.Size = new System.Drawing.Size(278, 208);
            this.LbIP.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 228);
            this.Controls.Add(this.LbIP);
            this.Controls.Add(this.BtnChange);
            this.Controls.Add(this.BtnCast);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.Text = "ScreenShare-Server";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnCast;
        private System.Windows.Forms.Button BtnChange;
        private System.Windows.Forms.ListBox LbIP;
    }
}