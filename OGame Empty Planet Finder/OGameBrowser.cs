using System;
using System.Diagnostics;
using System.Net;
using System.Security;
using System.Windows.Forms;
using Microsoft.Win32;
using NLog;
using OGameEmptyPlanetFinder.HTTP;
using OGameEmptyPlanetFinder.WinAPI;

namespace OGameEmptyPlanetFinder
{
    public partial class OGameBrowser : Form
    {
        private static string PROCESS_NAME = Process.GetCurrentProcess().ProcessName + ".exe";
        private static string REGISTRY_FEATURE_BROWSER_EMULATION = @"SOFTWARE\Microsoft\Internet Explorer\MAIN\FeatureControl\FEATURE_BROWSER_EMULATION";

        private static Logger logger = LogManager.GetCurrentClassLogger();

        private string StartUrl { get; set; }

        public OGameBrowser(string startUrl)
        {
            // https://msdn.microsoft.com/en-us/library/ee330730%28v=vs.85%29.aspx
            setRegistryBrowserEmulation(0x2AF9/*0x2AF8*/);
            InitializeComponent();
            Text = LoginForm.CURRENT_VERSION_NAME + Text;
            StartUrl = startUrl;
        }

        private void OGameBrowser_Load(object sender, EventArgs e)
        {
             try
             {
                 CookieCollection cookieCollection = HTTPConnectionManager.Instance.getCookieCollection(StartUrl);
                 foreach (Cookie cookie in cookieCollection)
                 {
                     WebApiCommon.InternetSetCookie(StartUrl, cookie.Name, cookie.Value);
                 }
                 webBrowserOgame.Navigate(StartUrl);
             }
             catch (ArgumentException ex)
             {
                 logger.Error(ex);
             }
             catch (UriFormatException ex)
             {
                 logger.Error(ex);
             }
        }

        private void OGameBrowser_FormClosing(object sender, FormClosingEventArgs e)
        {
            HTTPConnectionManager.Instance.setCookies(webBrowserOgame.Url, webBrowserOgame.Document.Cookie);
            deleteRegistryBrowserEmulationValue();
        }

        private void setRegistryBrowserEmulation(int value)
        {
            try
            {
                Registry.SetValue("HKEY_LOCAL_MACHINE\\" + REGISTRY_FEATURE_BROWSER_EMULATION, PROCESS_NAME, value, RegistryValueKind.DWord);
            }
            catch (UnauthorizedAccessException ex)
            {
                logger.Warn(ex);
            }
            catch (SecurityException ex)
            {
                logger.Warn(ex);
                MessageBox.Show("You need to run this program as administrator to use this feature!", "Error");
            }
        }

        private void deleteRegistryBrowserEmulationValue()
        {
            try
            {
                var registryKey = Registry.LocalMachine.OpenSubKey(REGISTRY_FEATURE_BROWSER_EMULATION, true);
                registryKey.DeleteValue(PROCESS_NAME);
                registryKey.Close();
            }
            catch (UnauthorizedAccessException ex)
            {
                logger.Warn(ex.ToString());
            }
            catch (SecurityException ex)
            {
                logger.Warn(ex);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
        }
    }
}
