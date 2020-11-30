namespace Services.Common.Security
{
    public class TokenAccountResult : TokenResult
    {
        public TokenAccountResult():base()
        {
        }

        public TokenAccountResult(string accessToken, string refreshToken, int expiresIn): base(accessToken, refreshToken, expiresIn)
        {
            AccessToken = accessToken;
            RefreshToken = refreshToken;
            ExpiresIn = expiresIn;
        }
        public string UserName { get; set; }
        public string Title { get; set; } 
        public byte[] AvatarImg { get; set; }
    }

}