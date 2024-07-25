using Microsoft.AspNetCore.Mvc;
using WCSTrainer.Models;

namespace WCSTrainer.Components {

    public class PeopleViewComponent : ViewComponent {
        public IViewComponentResult Invoke(string displayMode = "both") {
            var model = new PeopleComponentModel {
                DisplayMode = displayMode,
                Items = GetItems() // You might want to inject a service here instead
            };
            return View(model);
        }

        private List<object> GetItems() {
            // Sample data
            return new List<object>
            {
                new Person { Id = "1", Name = "John Doe", Status = "Trainer", Groups = "Group A", Hours = 10 },
                new Person { Id = "2", Name = "Jane Smith", Status = "Trainee", Groups = "Group B", Hours = 5 },
                new Group { Id = "3", Name = "Group A", Count = 5 },
                new Group { Id = "4", Name = "Group B", Count = 3 }
            };
        }
    }
}
