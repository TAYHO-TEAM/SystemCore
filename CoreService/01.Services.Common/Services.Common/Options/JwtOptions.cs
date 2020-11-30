using System;

namespace Services.Common.Options
{
    public class JwtOptions
    {
        public string SecretKey { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public DateTime IssuedAt => DateTime.UtcNow;
        public int AccessTokenExpiration { get; set; }
        public int LengthOfRefreshToken { get; set; }
        public TimeSpan ValidForTimeSpan => TimeSpan.FromMinutes(AccessTokenExpiration);
        public DateTime Expiration => IssuedAt.Add(ValidForTimeSpan);
        public int RefreshTokenExpiryDay { get; set; }
        public Func<string> JtiGenerator => () => Guid.NewGuid().ToString();
    }
}