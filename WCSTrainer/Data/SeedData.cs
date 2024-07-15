using Microsoft.AspNetCore.Identity;
using WCSTrainer.Models;

namespace WCSTrainer.Data {
    public static class SeedData {
        public static async Task AssignRoles(UserManager<UserAccount> userManager, RoleManager<IdentityRole> roleManager) {
            var user = await userManager.FindByEmailAsync("ahusain@wolverinecoilspring.com");

            if (user != null) {
                await userManager.AddToRoleAsync(user, "admin");
                await userManager.AddToRoleAsync(user, "trainer");
                await userManager.AddToRoleAsync(user, "trainee");
            }
        }
    }
}
