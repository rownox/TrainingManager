using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WCSTrainer.Data;

namespace WCSTrainer.Helpers {
   public class TrainingOrderHelper {



      public static async Task<bool> HasPerms(UserManager<UserAccount> userManager, ClaimsPrincipal claim, WCSTrainerContext context, TrainingOrder trainingOrder) {
         var user = await userManager.GetUserAsync(claim);
         if (user == null)
            return false;

         var currentEmployee = await context.Employees
             .Include(e => e.TrainingOrdersAsTrainer)
             .Include(e => e.TrainingOrdersAsTrainee)
             .FirstOrDefaultAsync(e => e.Id == user.EmployeeId);

         if (currentEmployee == null)
            return false;

         return await HasPerms(userManager, user, currentEmployee, trainingOrder);
      }

      public static async Task<bool> HasPerms(UserManager<UserAccount> userManager, UserAccount user, Employee employee, TrainingOrder trainingOrder) {
         var isOwner = await userManager.IsInRoleAsync(user, "owner");
         var isAdmin = await userManager.IsInRoleAsync(user, "admin");
         if (isAdmin || isOwner) return true;

         if (OrderInvolves(employee, trainingOrder)) {
            return true;
         }
         return false;
      }

      public static bool OrderInvolves(Employee employee, TrainingOrder order) {
         if (order.CreatedByUserId == employee.UserAccountId) {
            return true;
         }
         if (employee.TrainingOrdersAsTrainee.Contains(order)) {
            return true;
         }
         if (employee.TrainingOrdersAsTrainer.Contains(order)) {
            return true;
         }
         return false;
      }
   }
}
