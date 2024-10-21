using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WCSTrainer.Data;

namespace WCSTrainer.Helpers {
   public class TrainingOrderHelper {

      public static async Task<bool> HasPerms(UserManager<UserAccount> userManager, ClaimsPrincipal claim, WCSTrainerContext context, TrainingOrder trainingOrder) {
         var user = await userManager.GetUserAsync(claim);
         if (user == null) {
            return false;
         }
         var currentEmployee = await context.Employees.FirstOrDefaultAsync(e => e.Id == user.EmployeeId);
         if (currentEmployee == null) {
            return false;
         }

         if (HasPerms(userManager, user, currentEmployee, trainingOrder).Result) {
            return true;
         }
         return false;
      }

      public static async Task<bool> HasPerms(UserManager<UserAccount> userManager, UserAccount user, Employee employee, TrainingOrder trainingOrder) {
         var isOwner = await userManager.IsInRoleAsync(user, "owner");
         var isAdmin = await userManager.IsInRoleAsync(user, "admin");
         if (isAdmin || isOwner) return true;

         if (EmployeeOwns(employee, trainingOrder)) {
            return true;
         }
         return false;
      }

      public static bool EmployeeOwns(Employee employee, TrainingOrder order) {
         if (order.CreatedByUserId == employee.UserAccountId) {
            return true;
         }
         return false;
      }

      public static async Task<bool> OrderInvolves(UserManager<UserAccount> userManager, ClaimsPrincipal claim, TrainingOrder trainingOrder) {
         var user = await userManager.GetUserAsync(claim);
         if (user != null) {
            if (user.Employee != null) {
               if (HasPerms(userManager, user, user.Employee, trainingOrder).Result == true) {
                  return true;
               }
               if (user.Employee.TrainingOrdersAsTrainee.Contains(trainingOrder)) {
                  return true;
               }
               if (user.Employee.TrainingOrdersAsTrainer.Contains(trainingOrder)) {
                  return true;
               }
            }
         }
         return false;
      }
   }
}
