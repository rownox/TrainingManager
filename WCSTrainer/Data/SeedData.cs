using Microsoft.AspNetCore.Identity;
using WCSTrainer.Models;

namespace WCSTrainer.Data {
    public static class SeedData {
        public static async Task AssignRoles(UserManager<UserAccount> userManager, RoleManager<IdentityRole> roleManager) {
            var user = await userManager.FindByEmailAsync("ahusain@wolverinecoilspring.com");
            var user2 = await userManager.FindByEmailAsync("AadamH35@gmail.com");

            if (user != null) {
                await userManager.AddToRoleAsync(user, "admin");
                await userManager.AddToRoleAsync(user, "trainer");
                await userManager.AddToRoleAsync(user, "trainee");
            }

            if (user2 != null) {
                await userManager.AddToRoleAsync(user2, "admin");
                await userManager.AddToRoleAsync(user2, "trainer");
                await userManager.AddToRoleAsync(user2, "trainee");
            }
        }
    }
}
