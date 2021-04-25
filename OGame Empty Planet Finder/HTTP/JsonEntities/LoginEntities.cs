namespace OGameEmptyPlanetFinder.HTTP.JsonEntities
{
    namespace LoginEntities
    {
        public class Credentials
        {
            public string email { get; set; }
            public string password { get; set; }
        }

        public class Login
        {
            public Credentials credentials { get; set; }
            public string language { get; set; }
            public string kid { get; set; } = "";
            public bool autoLogin { get; set; }
        }
    }
}
