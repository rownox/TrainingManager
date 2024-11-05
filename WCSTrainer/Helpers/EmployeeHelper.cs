using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WCSTrainer.Helpers {
   public class EmployeeHelper {

      public static async Task<bool> hasPerms(int? id, UserManager<UserAccount> userManager, ClaimsPrincipal claim) {
         var user = await userManager.GetUserAsync(claim);

         if (user != null) {
            if (user.EmployeeId == id) {
               return true;
            }
            var isOwner = await userManager.IsInRoleAsync(user, "owner");
            var isAdmin = await userManager.IsInRoleAsync(user, "admin");
            if (isOwner || isAdmin) {
               return true;
            }
         }
         return false;
      }
   }
}
