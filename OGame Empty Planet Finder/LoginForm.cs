using System;
using System.ComponentModel;
using System.Windows.Forms;
using NLog;
using OGameEmptyPlanetFinder.Exceptions;
using OGameEmptyPlanetFinder.GUI;
using OGameEmptyPlanetFinder.HTTP;
using OGameEmptyPlanetFinder.Settings;

namespace OGameEmptyPlanetFinder
{
    public partial class LoginForm : Form
    {
        public static readonly string EMPTY_PLANET_FINDER = "OGame Empty Planet Finder";
        public static readonly string VERSION = "v0.7 - OGame v6.8.x";
        public static readonly string CURRENT_VERSION_NAME = EMPTY_PLANET_FINDER + " " + VERSION;

        private static Logger logger = LogManager.GetCurrentClassLogger();

        private bool connection = true;

        public LoginForm()
        {
            InitializeComponent();
            Text = CURRENT_VERSION_NAME + Text;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            ConnectToTheHost();
        }

        private void butLogin_Click(object sender, EventArgs e)
        {   
            if (connection)
            {
                var item = (ComboboxItem)comboServers.SelectedItem;
                var email = textEmail.Text.Trim();
                var password = textPassword.Text.Trim();
                if (string.IsNullOrEmpty(email) || email.Length < 1)
                {
                    MessageBox.Show("Invalid E-Mail address!", "Error");
                }
                else if (string.IsNullOrEmpty(password) || password.Length < 5)
                {
                    MessageBox.Show("Invalid password!", "Error");
                }
                else if (string.IsNullOrEmpty(comboServers.Text))
                {
                    MessageBox.Show("Invalid server name!", "Error");
                }
                else
                {   
                    try
                    {
                        string[] args = { textEmail.Text, textPassword.Text, item.Value, comboServers.Text };
                        bgwLogin.RunWorkerAsync(args);
                        SetEnabledLogin(false);
                        butLogin.Enabled = false;
                    }
                    catch (Exception ex)
                    {
                        logger.Error(ex, "Login failed");
                    }
                }
            } 
            else
            {
                ConnectToTheHost();
            }
        }

        private void SetEnabledLogin(bool enabled)
        {
            textEmail.Enabled = enabled;
            textPassword.Enabled = enabled;
            comboServers.Enabled = enabled;
            butProxy.Enabled = enabled;
        }

        private void ConnectToTheHost() 
        {
            var servers = HTTPConnectionManager.Instance.RequestServers();
            if (servers != null && servers.Count > 0)
            {
                foreach (var server in servers)
                {
                    if (server.language.Equals(SettingsService.Instance.Settings.ServerLanguage))
                    {
                        comboServers.Items.Add(new ComboboxItem(server.name, server.number.ToString()));
                    }
                }
                connection = true;
                butLogin.Text = "Login";
                SetEnabledLogin(true);
                LoadSettings();
            }
            else
            {
                SetEnabledLogin(false);
                connection = false;
                butLogin.Text = "Retry to connect";
                MessageBox.Show("Couldn´t get data from server", "Error");
            }
        }

        private void butProxy_Click(object sender, EventArgs e)
        {
            var proxyForm = new ProxyForm();
            proxyForm.ShowDialog();
        }

        private void bgwLogin_DoWork(object sender, DoWorkEventArgs e)
        {
            string[] args = (string[])e.Argument;
            bool isSuccess = false;
            try
            {
                isSuccess = HTTPConnectionManager.Instance.RequestLogin(args[0], args[1]);
                if (isSuccess)
                {
                    SettingsService.Instance.Settings.Login.Email = args[0].Trim();
                    SettingsService.Instance.Settings.Login.CryptPassword = args[1].Trim();
                    SettingsService.Instance.Settings.Login.UniNumber = int.Parse(args[2].Trim());
                    SettingsService.Instance.Settings.Login.UniName = args[3].Trim();
                }
            }
            catch (LoginException ex)
            {
                MessageBox.Show(ex.Message, "Error");
                logger.Info(ex, "bgwLogin_DoWork.LoginException");
            }
            catch (Exception ex)
            {
                logger.Error(ex, "bgwLogin_DoWork failed");
            }
            e.Result = isSuccess;
        }

        private void bgwLogin_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result != null && (bool)e.Result)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                DialogResult = DialogResult.None;
                SetEnabledLogin(true);
                butLogin.Enabled = true;
            }
        }

        private void LoadSettings()
        {
            try
            {
                textEmail.Text = SettingsService.Instance.Settings.Login.Email;
                textPassword.Text = SettingsService.Instance.Settings.Login.CryptPassword;
                comboServers.SelectedIndex = comboServers.FindStringExact(SettingsService.Instance.Settings.Login.UniName);
            }
            catch (Exception ex)
            {
                logger.Info(ex, "LoginForm.loadSettings failed");
            }
        }
    }
}
