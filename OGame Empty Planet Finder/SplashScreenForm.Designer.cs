using System.ComponentModel;
using System.Windows.Forms;

namespace OGameEmptyPlanetFinder
{
    partial class SplashScreenForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SplashScreenForm));
            this.labLoading = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labLoading
            // 
            this.labLoading.AutoSize = true;
            this.labLoading.BackColor = System.Drawing.Color.Transparent;
            this.labLoading.Font = new System.Drawing.Font("BankGothic Lt BT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labLoading.ForeColor = System.Drawing.SystemColors.Window;
            this.labLoading.Location = new System.Drawing.Point(110, 253);
            this.labLoading.MinimumSize = new System.Drawing.Size(280, 0);
            this.labLoading.Name = "labLoading";
            this.labLoading.Size = new System.Drawing.Size(280, 17);
            this.labLoading.TabIndex = 1;
            this.labLoading.Text = "Loading, please wait...";
            this.labLoading.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // SplashScreenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::OGameEmptyPlanetFinder.Properties.Resources.splash_screen;
            this.ClientSize = new System.Drawing.Size(500, 313);
            this.Controls.Add(this.labLoading);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SplashScreenForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SplashScreen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label labLoading;
    }
}