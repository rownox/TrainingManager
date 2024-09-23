using Microsoft.AspNetCore.Identity;

namespace WCSTrainer.Data {
   public static class SeedData {
      public static async Task AssignRoles(UserManager<UserAccount> userManager, RoleManager<IdentityRole> roleManager) {
         var adminsList = new List<String>() { "AadamH", "JayD" };

         foreach (var admin in adminsList) {
            var user = await userManager.FindByNameAsync(admin);

            if (user != null) {
               await userManager.AddToRoleAsync(user, "admin");
            }
         }
      }
   }
}
