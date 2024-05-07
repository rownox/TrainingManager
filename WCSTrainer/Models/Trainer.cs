using WebApplication2.Models;

namespace WCSTrainer.Models {
    public class Trainer {
        public int EmployeeID { get; set; }
        public string Skills { get; set; }
        public List<int> Underlings { get; set; }
        public List<int> Completed { get; set; } 
    }
}
