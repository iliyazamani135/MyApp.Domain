namespace MyAppAPI.Settings
{
    public class JwtSettings
    {
        public string SecretKey { get; set; } = "ThisIsASecretKeyForJWT123!";
        public string Issuer { get; set; } = "MyAppIssuer";
        public string Audience { get; set; } = "MyAppAudience";
        public int ExpiryMinutes { get; set; } = 60;
    }
}
