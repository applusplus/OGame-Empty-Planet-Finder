using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using NLog;
using OGameEmptyPlanetFinder.GUI;
using OGameEmptyPlanetFinder.HTTP;
using OGameEmptyPlanetFinder.Settings;

namespace OGameEmptyPlanetFinder
{
    public partial class LanguageForm : Form
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public LanguageForm()
        {
            InitializeComponent();
            Text = LoginForm.CURRENT_VERSION_NAME;
        }

        private void HomepageForm_Load(object sender, EventArgs e)
        {
            Init();
            SplashScreenForm.CloseSplashScreen();
            FormCommons.SetOnTop(this);
        }

        private void Init()
        {
            var servers = HTTPConnectionManager.Instance.RequestServers();
            if (servers != null && servers.Count > 0)
            {
                var langaugeSet = new HashSet<string>();
                foreach (var server in servers)
                {
                    langaugeSet.Add(server.language);
                }
                foreach (var language in langaugeSet.ToList())
                {
                    cbServerLangauge.Items.Add(new ComboboxItem(language.ToUpper(), language));
                }
                cbServerLangauge.SelectedIndex = 0;
                if (!string.IsNullOrEmpty(SettingsService.Instance.Settings.ServerLanguage))
                {
                    cbServerLangauge.SelectedIndex = cbServerLangauge.FindStringExact(SettingsService.Instance.Settings.ServerLanguage.ToUpper());
                }

                butOk.Enabled = true;
            }
            else
            {
                MessageBox.Show("Couldn´t get game server list from server\nCheck proxy settings and try again.", "Error");
            }
        }

        private void butOk_Click(object sender, EventArgs e)
        {
            if (cbServerLangauge.SelectedIndex >= 0 && !string.IsNullOrEmpty(((ComboboxItem) cbServerLangauge.SelectedItem).Key))
            {
                SettingsService.Instance.Settings.ServerLanguage = ((ComboboxItem) cbServerLangauge.SelectedItem).Value.ToLower();
            }
            else
            {
                MessageBox.Show("You have to choose your server langauge here!\nFor Example: DE, US etc.", "Error");
            }
        }

        private void butProxy_Click(object sender, EventArgs e)
        {
            var proxyForm = new ProxyForm();
            proxyForm.ShowDialog();
        }

        private void LanguageForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SettingsService.Instance.Save();
        }
    }
}
