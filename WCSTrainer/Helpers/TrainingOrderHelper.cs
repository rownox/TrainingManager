namespace WCSTrainer.Helpers {
   public class TrainingOrderHelper {

      public bool employeeOwns(Employee employee, TrainingOrder order) {
         if (order.CreatedByUserId == employee.UserAccountId) {
            return true;
         }
         return false;
      }

      public bool orderInvolves(Employee employee, TrainingOrder order) {
         if (employee.TrainingOrdersAsTrainee.Contains(order)) {
            return true;
         }
         if (employee.TrainingOrdersAsTrainer.Contains(order)) {
            return true;
         }
         if (employeeOwns(employee, order)) {
            return true;
         }
         return false;
      }
   }
}
