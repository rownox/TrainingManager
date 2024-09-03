using Microsoft.AspNetCore.Identity;

namespace WCSTrainer.Data {
   public static class SeedData {
      public static async Task AssignRoles(UserManager<UserAccount> userManager, RoleManager<IdentityRole> roleManager) {
         var user = await userManager.FindByNameAsync("AadamH");

         if (user != null) {
            await userManager.AddToRoleAsync(user, "admin");
         }
      }
   }
}
