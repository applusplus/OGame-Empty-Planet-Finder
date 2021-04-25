namespace OGameEmptyPlanetFinder.Autoplay
{
    public class PlayForMe
    {
        private AlertManager alertManager;

        public PlayForMe()
        {
            init();
        }

        private void init()
        {
            
        }
        
        public AlertManager GetAlertManager()
        {
            if (alertManager == null)
            {
                alertManager = new AlertManager();
            }
            return alertManager;
        }
    }
}
