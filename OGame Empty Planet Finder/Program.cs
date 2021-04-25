using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OGameEmptyPlanetFinder
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            SplashScreenForm.StartSplashScreen();
            Task.Delay(2000).Wait();
            var languageForm = new LanguageForm();
            if (languageForm.ShowDialog() == DialogResult.OK)
            {
                languageForm.Close();
                var loginForm = new LoginForm();
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    loginForm.Close();
                    Application.Run(new FinderForm());
                }
            }        
        }
    }
}