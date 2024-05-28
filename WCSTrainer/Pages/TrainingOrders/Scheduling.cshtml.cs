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

        public IList<TrainingOrder> TrainingOrders { get; set; } = default!;
        public IList<Employee> Employees { get; set; }

        [BindProperty]
        public int selectedYear { get; set; } = DateTime.Now.Year;
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

        public string getEmployee(string traineeID) {
            foreach (Employee employee in Employees) {
                if (employee.Id.ToString().Equals(traineeID)) {
                    return employee.FirstName + " " + employee.LastName;
                }
            }
            return traineeID;
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
                    count ++;
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
                    int days = (effectiveEnd.ToDateTime(TimeOnly.MinValue) - effectiveStart.ToDateTime(TimeOnly.MinValue)).Days + 1;

                    count += order.duration * days;
                }
            }

            return count;
        }


        public int countOrderHours(int month) {
            int count = 0;

            DateOnly monthStart = new DateOnly(selectedYear, month, 1);
            DateOnly monthEnd = monthStart.AddMonths(1).AddDays(-1);

            foreach (TrainingOrder order in TrainingOrders) {
                DateOnly orderStart = order.beginDate;
                DateOnly orderEnd = order.endDate;

                DateOnly effectiveStart = orderStart > monthStart ? orderStart : monthStart;
                DateOnly effectiveEnd = orderEnd < monthEnd ? orderEnd : monthEnd;

                if (effectiveStart <= effectiveEnd) {
                    int days = (effectiveEnd.ToDateTime(new TimeOnly(0, 0)) - effectiveStart.ToDateTime(new TimeOnly(0, 0))).Days + 1;

                    count += order.duration * days;
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
                    count++;
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
                    if (placeCount == place) {
                        return order;
                    } else {
                        placeCount++;
                    }
                }
            }

            return null;
        }
    }
}
