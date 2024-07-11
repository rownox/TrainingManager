using Microsoft.AspNetCore.Identity;

namespace WCSTrainer.Models {
    public class UserAccount : IdentityUser {
        public DateTime DateCreated { get; set; }
        public Employee Employee { get; set; }
    }
}
