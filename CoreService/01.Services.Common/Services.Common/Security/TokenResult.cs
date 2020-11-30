namespace Services.Common.Security
{
    public class TokenResult
    {
        public TokenResult()
        {
        }

        public TokenResult(string accessToken, string refreshToken, int expiresIn)
        {
            AccessToken = accessToken;
            RefreshToken = refreshToken;
            ExpiresIn = expiresIn;
        }

        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public int ExpiresIn { get; set; }
    }
}