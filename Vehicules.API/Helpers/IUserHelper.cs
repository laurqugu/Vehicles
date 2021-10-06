using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;
using Vehicules.API.Data.Entities;
using Vehicules.API.Models;
using Vehicules.Common.Enum;

namespace Vehicules.API.Helpers
{
    public interface IUserHelper
    {
        Task<User> GetUserAsync(string email);

        Task<User> GetUserAsync(Guid id);

        Task<IdentityResult> AddUserAsync(User user, string password);

        Task<User> AddUserAsync(AddUserViewModel model, Guid imageId, UserType userType);

        Task<IdentityResult> UpdateUserAsync(User user);

        Task<IdentityResult> DeleteUserAsync(User user);

        Task CheckRoleAsync(string roleName);

        Task AddUserToRoleAsync(User use, string roleName);

        Task<bool> IsUserInRoleAsync(User user, string roleName);

        Task<SignInResult> LoginAsync(LoginViewModel model);

        Task LogoutAsync();
    }
}
