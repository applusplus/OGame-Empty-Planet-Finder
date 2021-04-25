using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace OGameEmptyPlanetFinder
{
    public partial class SplashScreenForm : Form
    {
        private static Thread thread;
        private static string loadingMessage = "";

        private static SplashScreenForm _splashScreen;
        public static SplashScreenForm SplashScreen { get {return _splashScreen;} }

        public SplashScreenForm()
        {
            InitializeComponent();
            Text = LoginForm.CURRENT_VERSION_NAME + Text;
            if (!loadingMessage.Equals(""))
            {
                labLoading.Text = loadingMessage;
            }
        }

        private static void ShowSplashScreen()
        {
            _splashScreen = new SplashScreenForm();
            Application.Run(SplashScreen);
        }

        public static void CloseSplashScreen()
        {
            try
            {
                _splashScreen?.Invoke(new MethodInvoker(delegate { _splashScreen.Close(); }));
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }
            thread = null;
            _splashScreen = null;
        }

        public static void StartSplashScreen(string loading = "")
        {
            if (SplashScreen != null)
                return;
            loadingMessage = loading;
            thread = new Thread(ShowSplashScreen)
            {
                IsBackground = true
            };
            thread.Start();
        }
    }
}
