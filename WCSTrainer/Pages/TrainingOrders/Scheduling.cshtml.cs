using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WCSTrainer.Pages.TrainingOrders {
   [Authorize(Roles = "owner, admin, user")]
   public class SchedulingModel(WCSTrainer.Data.WCSTrainerContext context) : PageModel {

      public IList<TrainingOrder> TrainingOrders { get; set; } = default!;
      public IList<Employee> Employees { get; set; } = default!;
      [BindProperty]
      public int selectedYear { get; set; } = DateTime.Now.Year;
      [BindProperty]
      public int selectedMonth { get; set; }
      [BindProperty]
      public int searchFor { get; set; }
      public int EarliestYear { get; set; }

      public async Task<IActionResult> OnGetAsync() {
         Employees = await context.Employees
            .Include(e => e.TrainingOrdersAsTrainer)
            .ToListAsync();
         TrainingOrders = await context.TrainingOrders.ToListAsync();

         EarliestYear = TrainingOrders
            .Select(t => t.CreateDate.Year)
            .DefaultIfEmpty(DateTime.Now.Year)
            .Min();

         return Page();
      }

      public IActionResult OnPost() {
         return OnGetAsync().Result;
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
                  if (order.Status == "Active") {
                     count += order.Duration;
                  }
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

            if (orderStart.HasValue && orderStart.Value.Month == month && orderStart.Value.Year == selectedYear) {
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

            if (orderStart.HasValue && orderStart.Value.Month == month && orderStart.Value.Year == selectedYear) {
               if (employeeHasOrder(order)) {
                  count++;
               }
            }
         }
         return count;
      }


      public List<TrainingOrder> getMonthOrders(int month) {
         List<TrainingOrder> ordersInMonth = new List<TrainingOrder>();
         DateOnly monthStart = new DateOnly(selectedYear, month, 1);
         DateOnly monthEnd = monthStart.AddMonths(1).AddDays(-1);

         foreach (var order in TrainingOrders) {
            DateOnly? orderStart = order.BeginDate;

            if (orderStart.HasValue && orderStart.Value.Month == month && orderStart.Value.Year == selectedYear) {
               if (employeeHasOrder(order)) {
                  if (order.Archived != true && order.Status == "Active") {
                     ordersInMonth.Add(order);
                  }
               }
            }
         }
         return ordersInMonth;
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
         if (searchFor == 0) {
            return true;
         } else {

            foreach (Employee employee in Employees) {
               if (searchFor == employee.Id) {
                  if (employee.TrainingOrdersAsTrainer.Contains(order)) {
                     return true;
                  }
               }
            }
         }
         return false;
      }
   }
}
