using Microsoft.AspNetCore.Identity;

namespace WCSTrainer.Data {
   public static class SeedData {
      public static async Task AssignRoles(UserManager<UserAccount> userManager, RoleManager<IdentityRole> roleManager) {
         var user = await userManager.FindByEmailAsync("ahusain@wolverinecoilspring.com");
         var user2 = await userManager.FindByEmailAsync("AadamH35@gmail.com");

         foreach (var account in userManager.Users.ToList()) {
            await userManager.AddToRoleAsync(account, "trainee");
         }

         if (user != null) {
            await userManager.AddToRoleAsync(user, "admin");
         }

         if (user2 != null) {
            await userManager.AddToRoleAsync(user2, "trainer");
         }
      }
   }
}
