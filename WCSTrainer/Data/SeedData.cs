using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace WCSTrainer.Data {
   public static class SeedData {
      public static async Task AssignRoles(UserManager<UserAccount> userManager, RoleManager<IdentityRole> roleManager) {

         if (!userManager.Users.IsNullOrEmpty()) {
            var allUsers = userManager.Users.ToList();

            foreach (var user in allUsers) {
               var roles = await userManager.GetRolesAsync(user);
               await userManager.AddToRoleAsync(user, "owner");
            }
         }
      }
   }
}
