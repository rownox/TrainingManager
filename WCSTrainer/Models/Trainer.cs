using WebApplication2.Models;

namespace WCSTrainer.Models {
    public class Trainer {
        public int EmployeeID { get; set; }
        public string Skills { get; set; }
        public IList<Employee>? Underlings { get; set; }
        public IList<TrainingOrder>? Completed { get; set; }

        public Trainer(int EmployeeID, string Skills, IList<Employee>? Underlings, IList<TrainingOrder>? Completed) {
            this.EmployeeID = EmployeeID;
            this.Skills = Skills;
            this.Underlings = Underlings;
            this.Completed = Completed;
        }
    }
}
