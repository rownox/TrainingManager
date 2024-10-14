using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WCSTrainer.Data;

namespace WCSTrainer.Helpers {
   public class TrainingOrderHelper {

      public static async Task<bool> hasPerms(UserManager<UserAccount> userManager, ClaimsPrincipal claim, WCSTrainerContext context, TrainingOrder trainingOrder) {
         var user = await userManager.GetUserAsync(claim);
         if (user == null) {
            return false;
         }
         var currentEmployee = await context.Employees.FirstOrDefaultAsync(e => e.Id == user.EmployeeId);
         if (currentEmployee == null) {
            return false;
         }

         if (hasPerms(userManager, claim, currentEmployee, trainingOrder).Result) {
            return true;
         }
         return false;
      }

      public static async Task<bool> hasPerms(UserManager<UserAccount> userManager, ClaimsPrincipal claim, Employee employee, TrainingOrder trainingOrder) {
         var user = await userManager.GetUserAsync(claim);
         if (user == null) {
            return false;
         }
         var isOwner = await userManager.IsInRoleAsync(user, "owner");
         var isAdmin = await userManager.IsInRoleAsync(user, "admin");
         if (isAdmin || isOwner) return true;

         if (employeeOwns(employee, trainingOrder)) {
            return true;
         }
         return false;
      }

      public static bool employeeOwns(Employee employee, TrainingOrder order) {
         if (order.CreatedByUserId == employee.UserAccountId) {
            return true;
         }
         return false;
      }

      public static bool orderInvolves(UserManager<UserAccount> userManager, ClaimsPrincipal claim, Employee employee, TrainingOrder trainingOrder) {
         if (employee.TrainingOrdersAsTrainee.Contains(trainingOrder)) {
            return true;
         }
         if (employee.TrainingOrdersAsTrainer.Contains(trainingOrder)) {
            return true;
         }
         if (hasPerms(userManager, claim, employee, trainingOrder).Result) {
            return true;
         }
         return false;
      }
   }
}
