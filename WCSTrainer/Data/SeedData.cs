using Microsoft.AspNetCore.Identity;

namespace WCSTrainer.Data {
   public static class SeedData {
      public static async Task AssignRoles(UserManager<UserAccount> userManager, RoleManager<IdentityRole> roleManager) {
         var ownerList = new List<String>() { "AadamH" };
         var adminList = new List<String>() { "JayD" };
         var userList = new List<String>() { "KayS" };


         foreach (var ownerPerm in ownerList) {
            var user = await userManager.FindByNameAsync(ownerPerm);

            if (user != null) {
               await userManager.AddToRoleAsync(user, "owner");
            }
         }

         foreach (var adminPerm in adminList) {
            var user = await userManager.FindByNameAsync(adminPerm);

            if (user != null) {
               await userManager.AddToRoleAsync(user, "admin");
            }
         }

         foreach (var userPerm in userList) {
            var user = await userManager.FindByNameAsync(userPerm);

            if (user != null) {
               await userManager.AddToRoleAsync(user, "user");
            }
         }
      }
   }
}
