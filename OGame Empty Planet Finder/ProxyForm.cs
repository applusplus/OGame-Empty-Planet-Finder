using System;
using System.Windows.Forms;
using NLog;
using OGameEmptyPlanetFinder.HTTP;
using OGameEmptyPlanetFinder.Settings;

namespace OGameEmptyPlanetFinder
{
    public partial class ProxyForm : Form
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public ProxyForm()
        {
            InitializeComponent();
        }

        private void ProxyForm_Load(object sender, EventArgs e)
        {
            try
            {
                var proxy = SettingsService.Instance.Settings.Proxy;
                if (proxy == null)
                {
                    numericPort.Value = 8888;
                }
                else
                {
                    textHost.Text = proxy.Host;
                    numericPort.Value = Convert.ToDecimal(proxy.Port);
                }
            }
            catch (Exception ex)
            {
                Logger.Warn(ex);
            }
        }

        private void butSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textHost.Text) || numericPort.Value < 1)
            {
                MessageBox.Show("Proxy was unset!", "Info");
                SettingsService.Instance.Settings.Proxy = null;
            }
            else
            {
                SettingsService.Instance.Settings.Proxy = new ProxyEntity(textHost.Text.Trim(), Convert.ToInt32(numericPort.Value));
            }
            Close();
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
