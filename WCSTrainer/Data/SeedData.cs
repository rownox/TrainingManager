using Microsoft.AspNetCore.Identity;

namespace WCSTrainer.Data {
   public static class SeedData {
      public static async Task AssignRoles(UserManager<UserAccount> userManager, RoleManager<IdentityRole> roleManager) {
         var ownerList = new List<string>() { "AadamH" };
         var adminList = new List<string>() { "JayD", "KayS", "MatthewW", "DonnaC", "CraigG" };
         var userList = new List<string>() { "" };

         foreach (var ownerPerm in ownerList) {
            var user = await userManager.FindByNameAsync(ownerPerm);
            if (user != null && !await userManager.IsInRoleAsync(user, "owner")) {
               await userManager.AddToRoleAsync(user, "owner");
            }
         }

         foreach (var adminPerm in adminList) {
            var user = await userManager.FindByNameAsync(adminPerm);
            if (user != null && !await userManager.IsInRoleAsync(user, "admin")) {
               await userManager.AddToRoleAsync(user, "admin");
            }
         }

         //foreach (var userPerm in userList) {
         //   var user = await userManager.FindByNameAsync(userPerm);
         //   if (user != null && !await userManager.IsInRoleAsync(user, "user")) {
         //      await userManager.AddToRoleAsync(user, "user");
         //   }
         //}

         var allUsers = userManager.Users.ToList();

         foreach (var user in allUsers) {
            var roles = await userManager.GetRolesAsync(user);
            if (roles.Count == 0) {
               await userManager.AddToRoleAsync(user, "guest");
            }
         }
      }
   }
}
