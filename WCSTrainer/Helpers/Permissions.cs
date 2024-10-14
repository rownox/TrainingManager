using Microsoft.AspNetCore.Identity;

namespace WCSTrainer.Helpers {
   public class Permissions {

      private readonly UserManager<IdentityUser> _userManager;
      private readonly IHttpContextAccessor _httpContextAccessor;

      public Permissions(UserManager<IdentityUser> userManager, IHttpContextAccessor httpContextAccessor) {
         _userManager = userManager;
         _httpContextAccessor = httpContextAccessor;
      }

      public async Task<bool> UserHasRoleAsync(string roleName) {
         var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
         if (user == null) {
            return false;
         }
         return await _userManager.IsInRoleAsync(user, roleName);
      }
   }
}
