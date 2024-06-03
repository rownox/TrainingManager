using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WCSTrainer.Models;
using WebApplication2.Models;

namespace WCSTrainer.Pages.TrainingOrders {
    public class SchedulingModel : PageModel {
        private readonly WCSTrainer.Data.WCSTrainerContext _context;

        public SchedulingModel(WCSTrainer.Data.WCSTrainerContext context) {
            _context = context;
        }
        public IList<TrainingOrder> TrainingOrders { get; set; }
        public IList<Employee> Employees { get; set; }

        [BindProperty]
        public int selectedYear { get; set; } = DateTime.Now.Year;

        [BindProperty]
        public int selectedMonth { get; set; }

        [BindProperty]
        public string searchFor { get; set; } = "All";

        public async Task OnGetAsync() {
            Employees = await _context.Employee.ToListAsync();
            TrainingOrders = await _context.TrainingOrder.ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync() {
            Employees = await _context.Employee.ToListAsync();
            TrainingOrders = await _context.TrainingOrder.ToListAsync();
            return Page();
        }

        public int countOrders() {
            int count = 0;

            foreach (var order in TrainingOrders) {
                DateOnly orderStart = order.beginDate;
                DateOnly orderEnd = order.endDate;
                DateOnly yearStart = new DateOnly(selectedYear, 1, 1);
                DateOnly yearEnd = new DateOnly(selectedYear, 12, 31);
                DateOnly effectiveStart = orderStart > yearStart ? orderStart : yearStart;
                DateOnly effectiveEnd = orderEnd < yearEnd ? orderEnd : yearEnd;

                if (effectiveStart <= effectiveEnd) {
                    if (employeeHasOrder(order.Id.ToString())) {
                        count++;
                    }
                }
            }
            return count;
        }

        public int countTotalOrderHours() {
            int count = 0;

            foreach (var order in TrainingOrders) {
                DateOnly orderStart = order.beginDate;
                DateOnly orderEnd = order.endDate;
                DateOnly yearStart = new DateOnly(selectedYear, 1, 1);
                DateOnly yearEnd = new DateOnly(selectedYear, 12, 31);
                DateOnly effectiveStart = orderStart > yearStart ? orderStart : yearStart;
                DateOnly effectiveEnd = orderEnd < yearEnd ? orderEnd : yearEnd;

                if (effectiveStart <= effectiveEnd) {
                    if (employeeHasOrder(order.Id.ToString())) {
                        count += order.duration;
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
                DateOnly orderStart = order.beginDate;
                DateOnly orderEnd = order.endDate;
                DateOnly effectiveStart = orderStart > monthStart ? orderStart : monthStart;
                DateOnly effectiveEnd = orderEnd < monthEnd ? orderEnd : monthEnd;

                if (effectiveStart <= effectiveEnd) {
                    if (employeeHasOrder(order.Id.ToString())) {
                        count += order.duration;
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
                DateOnly orderStart = order.beginDate;
                DateOnly orderEnd = order.endDate;

                if ((orderStart <= monthEnd) && (orderEnd >= monthStart)) {
                    if (employeeHasOrder(order.Id.ToString())) {
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
                if (order.beginDate >= monthStart && order.beginDate <= monthEnd) {
                    if (employeeHasOrder(order.Id.ToString())) {
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

        public bool employeeHasOrder(string orderID) {
            fixSearch();
            if (searchFor.Equals("All")) {
                return true;
            } else {
                foreach (Employee employee in Employees) {
                    if (searchFor.Contains(employee.FirstName) && searchFor.Contains(employee.LastName)) {
                        if (employee.TrainingOrders.Contains(orderID)) {
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
