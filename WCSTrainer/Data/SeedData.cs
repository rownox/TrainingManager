using Microsoft.AspNetCore.Identity;
using System.Text.Json;

namespace WCSTrainer.Data {
   public static class SeedData {
      public static async Task AssignRoles(UserManager<UserAccount> userManager, RoleManager<IdentityRole> roleManager) {
         var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "data", "roles.json");

         if (!File.Exists(filePath)) {
            return;
         }

         var json = await File.ReadAllTextAsync(filePath);
         var roleAssignments = JsonSerializer.Deserialize<Dictionary<string, List<string>>>(json);

         if (roleAssignments == null) {
            return;
         }

         foreach (var role in roleAssignments) {
            foreach (var username in role.Value) {
               var user = await userManager.FindByNameAsync(username);
               if (user != null && !await userManager.IsInRoleAsync(user, role.Key)) {
                  await userManager.AddToRoleAsync(user, role.Key);
               }
            }
         }

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