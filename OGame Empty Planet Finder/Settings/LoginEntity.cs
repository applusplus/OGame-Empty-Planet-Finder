using Newtonsoft.Json;
using OGameEmptyPlanetFinder.Cryption;

namespace OGameEmptyPlanetFinder.Settings
{
    [JsonObject(MemberSerialization.OptOut)]
    public class LoginEntity
    {
        private static readonly EncryptionAES AES = new EncryptionAES();

        public string Email { get; set; }
        private string _password;
        public string Password
        {
            get => _password;
            set => _password = value;
        }
        public int UniNumber { get; set; }
        public string UniName { get; set; }

        [JsonIgnore]
        public string CryptPassword
        {
            get => AES.Decrypt(_password);
            set => _password = AES.Encrypt(value);
        }
    }
}
