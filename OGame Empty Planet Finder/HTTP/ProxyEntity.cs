namespace OGameEmptyPlanetFinder.HTTP
{
    public class ProxyEntity
    {
        public string Host { get; set; }
        public int Port { get; set; }

        public ProxyEntity() { }

        public ProxyEntity(string host, int port) 
        {
            Host = host;
            Port = port;
        }
    }
}
