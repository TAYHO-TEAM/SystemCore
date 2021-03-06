﻿using System.Threading.Tasks;
using Services.Common.Security;

namespace Acc.Cmd.Domain.Services
{
    public interface IAccountService
    {
        Task<TokenAccountResult> LoginAsync(string userName, string password);
        Task<TokenAccountResult> RefreshTokenAsync(string refreshToken);
        Task LogoutAsync();
    }
}
