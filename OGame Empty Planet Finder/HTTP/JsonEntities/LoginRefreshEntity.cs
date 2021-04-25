namespace OGameEmptyPlanetFinder.HTTP.JsonEntities
{
    public class LoginRefreshEntity
    {
        public string language { get; set; }
        public string token { get; set; }
        public string kid { get; set; } = "";

        public LoginRefreshEntity()
        {
        }

        public LoginRefreshEntity(string language, string token, string kid = "")
        {
            this.language = language;
            this.token = token;
            this.kid = kid;
        }
    }
}
