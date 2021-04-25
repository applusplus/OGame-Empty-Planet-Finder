using System.ComponentModel;
using System.Windows.Forms;

namespace OGameEmptyPlanetFinder
{
    partial class LanguageForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LanguageForm));
            this.labChooseIt = new System.Windows.Forms.Label();
            this.butOk = new System.Windows.Forms.Button();
            this.cbServerLangauge = new System.Windows.Forms.ComboBox();
            this.butProxy = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labChooseIt
            // 
            this.labChooseIt.AutoSize = true;
            this.labChooseIt.Location = new System.Drawing.Point(90, 9);
            this.labChooseIt.Name = "labChooseIt";
            this.labChooseIt.Size = new System.Drawing.Size(156, 13);
            this.labChooseIt.TabIndex = 0;
            this.labChooseIt.Text = "Choose your OGame Language";
            // 
            // butOk
            // 
            this.butOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.butOk.Enabled = false;
            this.butOk.Location = new System.Drawing.Point(130, 66);
            this.butOk.Name = "butOk";
            this.butOk.Size = new System.Drawing.Size(75, 23);
            this.butOk.TabIndex = 3;
            this.butOk.Text = "OK";
            this.butOk.UseVisualStyleBackColor = true;
            this.butOk.Click += new System.EventHandler(this.butOk_Click);
            // 
            // cbServerLangauge
            // 
            this.cbServerLangauge.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbServerLangauge.FormattingEnabled = true;
            this.cbServerLangauge.Location = new System.Drawing.Point(151, 34);
            this.cbServerLangauge.Name = "cbServerLangauge";
            this.cbServerLangauge.Size = new System.Drawing.Size(38, 21);
            this.cbServerLangauge.TabIndex = 4;
            // 
            // butProxy
            // 
            this.butProxy.Location = new System.Drawing.Point(247, 66);
            this.butProxy.Name = "butProxy";
            this.butProxy.Size = new System.Drawing.Size(75, 23);
            this.butProxy.TabIndex = 5;
            this.butProxy.Text = "Proxy";
            this.butProxy.UseVisualStyleBackColor = true;
            this.butProxy.Click += new System.EventHandler(this.butProxy_Click);
            // 
            // LanguageForm
            // 
            this.AcceptButton = this.butOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 101);
            this.Controls.Add(this.butProxy);
            this.Controls.Add(this.cbServerLangauge);
            this.Controls.Add(this.butOk);
            this.Controls.Add(this.labChooseIt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "LanguageForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " - Which OGame?";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LanguageForm_FormClosing);
            this.Load += new System.EventHandler(this.HomepageForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label labChooseIt;
        private Button butOk;
        private ComboBox cbServerLangauge;
        private Button butProxy;
    }
}