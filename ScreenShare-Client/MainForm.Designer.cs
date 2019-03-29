namespace ScreenShare_Client
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.AxRDPViewer = new AxRDPCOMAPILib.AxRDPViewer();
            ((System.ComponentModel.ISupportInitialize)(this.AxRDPViewer)).BeginInit();
            this.SuspendLayout();
            // 
            // AxRDPViewer
            // 
            this.AxRDPViewer.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.AxRDPViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AxRDPViewer.Enabled = true;
            this.AxRDPViewer.Location = new System.Drawing.Point(0, 0);
            this.AxRDPViewer.Name = "AxRDPViewer";
            this.AxRDPViewer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("AxRDPViewer.OcxState")));
            this.AxRDPViewer.Size = new System.Drawing.Size(933, 637);
            this.AxRDPViewer.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 637);
            this.Controls.Add(this.AxRDPViewer);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.Text = "ScreenShare-Client";
            ((System.ComponentModel.ISupportInitialize)(this.AxRDPViewer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxRDPCOMAPILib.AxRDPViewer AxRDPViewer;
    }
}