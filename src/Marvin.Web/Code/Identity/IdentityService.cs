using Marvin.Web.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Marvin.Web
{
    // ASP.NET Identity related services

    #region Interface

    public interface IIdentityService
    {
        Task SecureUserAsync(User user, string? password, params string[] roles);
        Task CreateUserAsync(User user, string? password, params string[] roles);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(User user);

        Task<SignInResult> PasswordSignInAsync(string email, string password);
        Task SignOutAsync();
        Task RefreshClaimsAsync(User user);
        Task<IdentityResult> ChangePasswordAsync(User user, string currentPassword, string newPassword);
        Task<IdentityResult> ResetPasswordAsync(User user, string newPassword);

        Task CreateRole(string role);
    }

    #endregion

    public class IdentityService : IIdentityService
    {
        #region Dependency Injection 

        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UltraContext _db;
        private readonly ILoggerFactory _loggerFactory;

        public IdentityService(UserManager<IdentityUser> userManager,
                               SignInManager<IdentityUser> signInManager,
                               RoleManager<IdentityRole> roleManager, 
                               UltraContext db, 
                               ILoggerFactory loggerFactory)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _db = db;
            _loggerFactory = loggerFactory;
        }

        #endregion

        #region Services

        public async Task<SignInResult> PasswordSignInAsync(string email, string password)
        {
            var user = _db.Users.Single(u => u.Email == email);
            
            // This triggers 'CreateAsync' in ClaimsPrincipalFactory
            return await _signInManager.PasswordSignInAsync(user.IdentityName, password, true, false); // isPersistent, shouldLockout);
        }

        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task SecureUserAsync(User user, string? password, params string[] roles)
        {
            try
            {
                user.IdentityName = Guid.NewGuid().ToString();
                var appUser = new IdentityUser { UserName = user.IdentityName, Email = user.Email }; // provide email, but not used 

                IdentityResult result;
                if (password != null)
                {
                    result = await _userManager.CreateAsync(appUser, password);
                }
                else
                {
                    result = await _userManager.CreateAsync(appUser);  // user with external login
                }

                result = await _userManager.AddToRolesAsync(appUser, roles);

                user.IdentityId = appUser.Id;
            }
            catch (Exception ex)
            {
                var logger = _loggerFactory.CreateLogger<IdentityService>();
                logger.LogError(0, ex, "Error in InsertUserAsync.");

                throw new Exception("In InsertUserAsync :", ex);
            }
        }

        public async Task CreateUserAsync(User user, string? password, params string[] roles)
        {
            try
            {
                user.IdentityName = Guid.NewGuid().ToString();
                var appUser = new IdentityUser { UserName = user.IdentityName, Email = user.Email }; // provide email, but not used 

                IdentityResult result;
                if (password != null)
                {
                    result = await _userManager.CreateAsync(appUser, password);
                }
                else
                {
                    result = await _userManager.CreateAsync(appUser);  // user with external login
                }

                result = await _userManager.AddToRolesAsync(appUser, roles);

                user.IdentityId = appUser.Id;

                _db.Users.Add(user);
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                var logger = _loggerFactory.CreateLogger<IdentityService>();
                logger.LogError(0, ex, "Error in InsertUserAsync.");

                throw new Exception("In InsertUserAsync :", ex);
            }
        }

        public async Task UpdateUserAsync(User user)
        {
            try
            {
                var original = _db.Users.Single(u => u.Id == user.Id);

                if (original.Role != user.Role) await ChangeRoleAsync(user, original.Role);

                if (original.Email != user.Email) await ChangeEmailAsync(user);

                // cannot track 2 entities with same key: 'original' and 'user'
                _db.Entry(original).State = EntityState.Detached;

                _db.Users.Update(user);
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                var logger = _loggerFactory.CreateLogger<IdentityService>();
                logger.LogError(0, ex, "Error in UpdateUserAsync.");

                throw new Exception("In UpdateUserAsync :", ex);
            }
        }

        public async Task DeleteUserAsync(User user)
        {
            try
            {
                var appUser = await _userManager.FindByIdAsync(user.IdentityId);

                await _userManager.RemoveFromRoleAsync(appUser, user.Role);
                await _userManager.DeleteAsync(appUser);
            }
            catch (Exception ex)
            {
                var logger = _loggerFactory.CreateLogger<IdentityService>();
                logger.LogError(0, ex, "Error in DeleteUserAsync.");

                throw new Exception("In DeleteUserAsync :", ex);
            }
        }

        public async Task<IdentityResult> ChangePasswordAsync(User user, string currentPassword, string newPassword)
        {
            var appUser = await _userManager.FindByIdAsync(user.IdentityId);
            return await _userManager.ChangePasswordAsync(appUser, currentPassword, newPassword);
        }

        public async Task<IdentityResult> ResetPasswordAsync(User user, string newPassword)
        {
            var appUser = await _userManager.FindByIdAsync(user.IdentityId);
            await _userManager.RemovePasswordAsync(appUser);
            return await _userManager.AddPasswordAsync(appUser, newPassword);
        }

        public async Task RefreshClaimsAsync(User user)
        {
            var appUser = await _userManager.FindByIdAsync(user.IdentityId);

            // This triggers 'CreateAsync' in ClaimsPrincipalFactory
            await _signInManager.RefreshSignInAsync(appUser);
        }

        private async Task ChangeRoleAsync(User user, string oldRole)
        {
            var appUser = await _userManager.FindByIdAsync(user.IdentityId);
            await _userManager.RemoveFromRoleAsync(appUser, oldRole);
            await _userManager.AddToRoleAsync(appUser, user.Role);
        }

        private async Task ChangeEmailAsync(User user)
        {
            var appUser = await _userManager.FindByIdAsync(user.IdentityId);
            await _userManager.SetEmailAsync(appUser, user.Email);
        }

        public async Task CreateRole(string role)
        {
            if (!await _roleManager.RoleExistsAsync(role))
            {
                await _roleManager.CreateAsync(new IdentityRole(role));
            }
        }

        #endregion
    }
}