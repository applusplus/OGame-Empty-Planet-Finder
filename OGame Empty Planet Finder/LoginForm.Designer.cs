using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace OGameEmptyPlanetFinder
{
    partial class LoginForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(LoginForm));
            this.labOgameLogin = new Label();
            this.labLoginName = new Label();
            this.labPassword = new Label();
            this.textEmail = new TextBox();
            this.textPassword = new TextBox();
            this.comboServers = new ComboBox();
            this.labServer = new Label();
            this.butLogin = new Button();
            this.labCopyright = new Label();
            this.butProxy = new Button();
            this.bgwLogin = new BackgroundWorker();
            this.SuspendLayout();
            // 
            // labOgameLogin
            // 
            this.labOgameLogin.AutoSize = true;
            this.labOgameLogin.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.labOgameLogin.ForeColor = SystemColors.HotTrack;
            this.labOgameLogin.Location = new Point(129, 9);
            this.labOgameLogin.Name = "labOgameLogin";
            this.labOgameLogin.Size = new Size(83, 13);
            this.labOgameLogin.TabIndex = 5;
            this.labOgameLogin.Text = "OGame Login";
            // 
            // labLoginName
            // 
            this.labLoginName.AutoSize = true;
            this.labLoginName.Location = new Point(53, 39);
            this.labLoginName.Name = "labLoginName";
            this.labLoginName.Size = new Size(35, 13);
            this.labLoginName.TabIndex = 6;
            this.labLoginName.Text = "Email:";
            // 
            // labPassword
            // 
            this.labPassword.AutoSize = true;
            this.labPassword.Location = new Point(32, 74);
            this.labPassword.Name = "labPassword";
            this.labPassword.Size = new Size(56, 13);
            this.labPassword.TabIndex = 7;
            this.labPassword.Text = "Password:";
            // 
            // textEmail
            // 
            this.textEmail.Location = new Point(96, 36);
            this.textEmail.Name = "textEmail";
            this.textEmail.Size = new Size(180, 20);
            this.textEmail.TabIndex = 0;
            // 
            // textPassword
            // 
            this.textPassword.Location = new Point(96, 71);
            this.textPassword.Name = "textPassword";
            this.textPassword.Size = new Size(180, 20);
            this.textPassword.TabIndex = 1;
            this.textPassword.UseSystemPasswordChar = true;
            // 
            // comboServers
            // 
            this.comboServers.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboServers.FormattingEnabled = true;
            this.comboServers.Location = new Point(96, 106);
            this.comboServers.Name = "comboServers";
            this.comboServers.Size = new Size(180, 21);
            this.comboServers.TabIndex = 2;
            // 
            // labServer
            // 
            this.labServer.AutoSize = true;
            this.labServer.Location = new Point(47, 109);
            this.labServer.Name = "labServer";
            this.labServer.Size = new Size(41, 13);
            this.labServer.TabIndex = 8;
            this.labServer.Text = "Server:";
            // 
            // butLogin
            // 
            this.butLogin.Location = new Point(120, 137);
            this.butLogin.Name = "butLogin";
            this.butLogin.Size = new Size(107, 30);
            this.butLogin.TabIndex = 3;
            this.butLogin.Text = "Login";
            this.butLogin.UseVisualStyleBackColor = true;
            this.butLogin.Click += new EventHandler(this.butLogin_Click);
            // 
            // labCopyright
            // 
            this.labCopyright.AutoSize = true;
            this.labCopyright.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.labCopyright.ForeColor = SystemColors.Highlight;
            this.labCopyright.Location = new Point(64, 182);
            this.labCopyright.Name = "labCopyright";
            this.labCopyright.Size = new Size(204, 13);
            this.labCopyright.TabIndex = 9;
            this.labCopyright.Text = "applusplus Copyright (C) 2013-2019";
            // 
            // butProxy
            // 
            this.butProxy.Location = new Point(271, 177);
            this.butProxy.Name = "butProxy";
            this.butProxy.Size = new Size(75, 23);
            this.butProxy.TabIndex = 4;
            this.butProxy.Text = "Proxy";
            this.butProxy.UseVisualStyleBackColor = true;
            this.butProxy.Click += new EventHandler(this.butProxy_Click);
            // 
            // bgwLogin
            // 
            this.bgwLogin.DoWork += new DoWorkEventHandler(this.bgwLogin_DoWork);
            this.bgwLogin.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.bgwLogin_RunWorkerCompleted);
            // 
            // LoginForm
            // 
            this.AcceptButton = this.butLogin;
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(349, 204);
            this.Controls.Add(this.butProxy);
            this.Controls.Add(this.labCopyright);
            this.Controls.Add(this.butLogin);
            this.Controls.Add(this.labServer);
            this.Controls.Add(this.comboServers);
            this.Controls.Add(this.textPassword);
            this.Controls.Add(this.textEmail);
            this.Controls.Add(this.labPassword);
            this.Controls.Add(this.labLoginName);
            this.Controls.Add(this.labOgameLogin);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.Icon = ((Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "LoginForm";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = " - Login";
            this.Load += new EventHandler(this.LoginForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label labOgameLogin;
        private Label labLoginName;
        private Label labPassword;
        private TextBox textEmail;
        private TextBox textPassword;
        private ComboBox comboServers;
        private Label labServer;
        private Button butLogin;
        private Label labCopyright;
        private Button butProxy;
        private BackgroundWorker bgwLogin;
    }
}

