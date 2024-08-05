using Microsoft.AspNetCore.Identity;

public class UserAccount : IdentityUser {
  public DateTime DateCreated { get; set; }
  public int EmployeeId { get; set; }
  public Employee Employee { get; set; }
}