using System.Windows.Forms;

namespace OGameEmptyPlanetFinder.GUI
{
    public static class FormCommons
    {
        public static void SetOnTop(Form form)
        {
            form.WindowState = FormWindowState.Normal;
            form.TopMost = true;
            form.TopMost = false;
            form.Activate();
        }
    }
}
