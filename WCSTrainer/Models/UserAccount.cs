using Microsoft.AspNetCore.Identity;

namespace WCSTrainer.Models {
    public class UserAccount : IdentityUser {
        public string EmployeeID { get; set; }
        public bool LightMode { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
