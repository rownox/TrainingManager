using Microsoft.AspNetCore.Identity;

namespace WCSTrainer.Data {
   public static class SeedData {
      public static async Task AssignRoles(UserManager<UserAccount> userManager, RoleManager<IdentityRole> roleManager) {
         var adminsList = new List<String>() { "AadamH", "JayD" };
         var trainerList = new List<String>() { "KayS" };

         foreach (var admin in adminsList) {
            var user = await userManager.FindByNameAsync(admin);

            if (user != null) {
               await userManager.AddToRoleAsync(user, "admin");
            }
         }

         foreach (var trainer in trainerList) {
            var user = await userManager.FindByNameAsync(trainer);

            if (user != null) {
               await userManager.AddToRoleAsync(user, "trainer");
            }
         }
      }
   }
}
