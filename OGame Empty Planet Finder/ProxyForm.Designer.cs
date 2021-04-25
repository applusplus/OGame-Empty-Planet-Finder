using System.ComponentModel;
using System.Windows.Forms;

namespace OGameEmptyPlanetFinder
{
    partial class ProxyForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.labHost = new System.Windows.Forms.Label();
            this.textHost = new System.Windows.Forms.TextBox();
            this.labPort = new System.Windows.Forms.Label();
            this.numericPort = new System.Windows.Forms.NumericUpDown();
            this.butSave = new System.Windows.Forms.Button();
            this.butCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericPort)).BeginInit();
            this.SuspendLayout();
            // 
            // labHost
            // 
            this.labHost.AutoSize = true;
            this.labHost.Location = new System.Drawing.Point(12, 19);
            this.labHost.Name = "labHost";
            this.labHost.Size = new System.Drawing.Size(57, 13);
            this.labHost.TabIndex = 0;
            this.labHost.Text = "IPv4 Host:";
            // 
            // textHost
            // 
            this.textHost.Location = new System.Drawing.Point(75, 16);
            this.textHost.Name = "textHost";
            this.textHost.Size = new System.Drawing.Size(178, 20);
            this.textHost.TabIndex = 1;
            // 
            // labPort
            // 
            this.labPort.AutoSize = true;
            this.labPort.Location = new System.Drawing.Point(40, 53);
            this.labPort.Name = "labPort";
            this.labPort.Size = new System.Drawing.Size(29, 13);
            this.labPort.TabIndex = 2;
            this.labPort.Text = "Port:";
            // 
            // numericPort
            // 
            this.numericPort.Location = new System.Drawing.Point(75, 51);
            this.numericPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numericPort.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericPort.Name = "numericPort";
            this.numericPort.Size = new System.Drawing.Size(55, 20);
            this.numericPort.TabIndex = 3;
            this.numericPort.Value = new decimal(new int[] {
            8080,
            0,
            0,
            0});
            // 
            // butSave
            // 
            this.butSave.Location = new System.Drawing.Point(43, 98);
            this.butSave.Name = "butSave";
            this.butSave.Size = new System.Drawing.Size(75, 23);
            this.butSave.TabIndex = 4;
            this.butSave.Text = "Save";
            this.butSave.UseVisualStyleBackColor = true;
            this.butSave.Click += new System.EventHandler(this.butSave_Click);
            // 
            // butCancel
            // 
            this.butCancel.Location = new System.Drawing.Point(178, 98);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(75, 23);
            this.butCancel.TabIndex = 5;
            this.butCancel.Text = "Cancel";
            this.butCancel.UseVisualStyleBackColor = true;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // ProxyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(281, 133);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butSave);
            this.Controls.Add(this.numericPort);
            this.Controls.Add(this.labPort);
            this.Controls.Add(this.textHost);
            this.Controls.Add(this.labHost);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "ProxyForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Proxy Settings";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.ProxyForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericPort)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label labHost;
        private TextBox textHost;
        private Label labPort;
        private NumericUpDown numericPort;
        private Button butSave;
        private Button butCancel;
    }
}