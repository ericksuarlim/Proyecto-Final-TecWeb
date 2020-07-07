using DealerAPI.Models;
using DealerAPI.Models.Auth;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DealerAPI.Services
{
    public interface IUserService
    {
        Task<UserManagerResponse> RegisterUserAsync(RegisterViewModel model);
        Task<UserManagerResponse> CreateRoleAsync(CreateRoleViewModel model);
        Task<UserManagerResponse> LoginUserAsync(LoginViewModel model);
        Task<UserManagerResponse> CreateUserRoleAsync(CreateUserRoleViewModel model);

    }
}
