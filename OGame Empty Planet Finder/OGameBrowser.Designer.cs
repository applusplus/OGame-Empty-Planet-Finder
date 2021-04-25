using System.ComponentModel;
using System.Windows.Forms;

namespace OGameEmptyPlanetFinder
{
    partial class OGameBrowser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OGameBrowser));
            this.webBrowserOgame = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // webBrowserOgame
            // 
            this.webBrowserOgame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowserOgame.Location = new System.Drawing.Point(0, 0);
            this.webBrowserOgame.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserOgame.Name = "webBrowserOgame";
            this.webBrowserOgame.ScriptErrorsSuppressed = true;
            this.webBrowserOgame.Size = new System.Drawing.Size(1264, 682);
            this.webBrowserOgame.TabIndex = 0;
            this.webBrowserOgame.Url = new System.Uri("http://ogame.de", System.UriKind.Absolute);
            // 
            // OGameBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 682);
            this.Controls.Add(this.webBrowserOgame);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "OGameBrowser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " - OGameBrowser";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OGameBrowser_FormClosing);
            this.Load += new System.EventHandler(this.OGameBrowser_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private WebBrowser webBrowserOgame;
    }
}