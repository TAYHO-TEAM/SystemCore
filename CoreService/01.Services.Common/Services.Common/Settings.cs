﻿namespace Services.Common
{
    public class Settings
    {
        public const string ErrorsFileName = "ErrorMessages";
        public const string ResourceFolderName = "Resources";
        public const string TemplateFolderName = "Templates";
        public const string ForgotPassword = "forgotpassword";

        public const string CommonErrorPrefix = "ERR_COM_";
        public const int PageSizeMax = 100;
        public const int DefaultPageSize = 100;

        // Url
        public const string APIQueryRoute = "api/[controller]";

        public const string APIDefaultRoute = "api/v{version:apiVersion}/[controller]";
        public const string CommandAPIDefaultRoute = "api/cmd/v{version:apiVersion}/[controller]";
        public const string ReadAPIDefaultRoute = "api/read/v{version:apiVersion}/[controller]";

        // Jwt Default Setting.
        public const int ValidFor = 120;

        public const string DefaultIssuer = "TayHo.Acc.Identity";
        public const string DefaultAudience = "Everyone";
        public const int RefreshTokenExpiryTime = 2;
        public const string SecretKey = "superSecretKey@345";
    }
}