using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WCSTrainer.Data;

namespace WCSTrainer.Pages.TrainingOrders {
   [Authorize(Roles = "owner, admin, user")]
   public class MonthModel(WCSTrainerContext context) : PageModel {
      public IList<TrainingOrder> TrainingOrders { get; set; }
      public IList<Employee> Employees { get; set; }
      [BindProperty]
      public int selectedYear { get; set; } = DateTime.Now.Year;
      [BindProperty]
      public int selectedMonth { get; set; }
      [BindProperty]
      public string searchFor { get; set; } = "All";

      public async Task OnGetAsync() {
         Employees = await context.Employees.ToListAsync();
         TrainingOrders = await context.TrainingOrders.ToListAsync();
      }

      public async Task<IActionResult> OnPostAsync() {
         Employees = await context.Employees.ToListAsync();
         TrainingOrders = await context.TrainingOrders.ToListAsync();
         return Page();
      }

      public int countOrders() {
         int count = 0;

         foreach (var order in TrainingOrders) {
            DateOnly? orderStart = order.BeginDate;
            DateOnly? orderEnd = order.CompletionDate;
            DateOnly yearStart = new DateOnly(selectedYear, 1, 1);
            DateOnly yearEnd = new DateOnly(selectedYear, 12, 31);
            DateOnly? effectiveStart = orderStart > yearStart ? orderStart : yearStart;
            DateOnly? effectiveEnd = orderEnd < yearEnd ? orderEnd : yearEnd;

            if (effectiveStart <= effectiveEnd) {
               if (employeeHasOrder(order)) {
                  count++;
               }
            }
         }
         return count;
      }

      public int countTotalOrderHours() {
         int count = 0;

         foreach (var order in TrainingOrders) {
            DateOnly? orderStart = order.BeginDate;
            DateOnly? orderEnd = order.CompletionDate;
            DateOnly yearStart = new DateOnly(selectedYear, 1, 1);
            DateOnly yearEnd = new DateOnly(selectedYear, 12, 31);
            DateOnly? effectiveStart = orderStart > yearStart ? orderStart : yearStart;
            DateOnly? effectiveEnd = orderEnd < yearEnd ? orderEnd : yearEnd;

            if (effectiveStart <= effectiveEnd) {
               if (employeeHasOrder(order)) {
                  count += order.Duration;
               }
            }
         }
         return count;
      }

      public int countOrderHours(int month) {
         DateOnly monthStart = new DateOnly(selectedYear, month, 1);
         DateOnly monthEnd = monthStart.AddMonths(1).AddDays(-1);
         int count = 0;

         foreach (TrainingOrder order in TrainingOrders) {
            DateOnly? orderStart = order.BeginDate;
            DateOnly? orderEnd = order.CompletionDate;
            DateOnly? effectiveStart = orderStart > monthStart ? orderStart : monthStart;
            DateOnly? effectiveEnd = orderEnd < monthEnd ? orderEnd : monthEnd;

            if (effectiveStart <= effectiveEnd) {
               if (employeeHasOrder(order)) {
                  count += order.Duration;
               }
            }
         }
         return count;
      }

      public int countMonthOrders(int month) {
         int count = 0;
         DateOnly monthStart = new DateOnly(selectedYear, month, 1);
         DateOnly monthEnd = monthStart.AddMonths(1).AddDays(-1);

         foreach (var order in TrainingOrders) {
            DateOnly? orderStart = order.BeginDate;
            DateOnly? orderEnd = order.CompletionDate;

            if ((orderStart <= monthEnd) && (orderEnd >= monthStart)) {
               if (employeeHasOrder(order)) {
                  count++;
               }
            }
         }
         return count;
      }

      public TrainingOrder? getFirstTrainingOrder(int month, int place) {
         DateOnly monthStart = new DateOnly(selectedYear, month, 1);
         DateOnly monthEnd = monthStart.AddMonths(1).AddDays(-1);
         int placeCount = 0;

         foreach (TrainingOrder order in TrainingOrders) {
            if (order.BeginDate >= monthStart && order.BeginDate <= monthEnd) {
               if (employeeHasOrder(order)) {
                  if (placeCount == place) {
                     return order;
                  } else {
                     placeCount++;
                  }
               }
            }
         }

         return null;
      }

      public bool employeeHasOrder(TrainingOrder order) {
         fixSearch();
         if (searchFor.Equals("All")) {
            return true;
         } else {
            foreach (Employee employee in Employees) {
               if (searchFor.Contains(employee.FirstName) && searchFor.Contains(employee.LastName)) {
                  if (employee.TrainingOrdersAsTrainee.Contains(order)) {
                     return true;
                  }
               }
            }
         }
         return false;
      }

      public void fixSearch() {
         if (searchFor == null) {
            searchFor = "All";
         }
      }
   }
}
