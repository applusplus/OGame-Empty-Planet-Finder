using System.Runtime.InteropServices;

namespace OGameEmptyPlanetFinder.WinAPI
{
    public static class WebApiCommon
    {
        [DllImport("wininet.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool InternetSetCookie(string lpszUrlName, string lbszCookieName, string lpszCookieData);
    }
}
