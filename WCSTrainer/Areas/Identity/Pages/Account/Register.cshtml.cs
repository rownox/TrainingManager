using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using WCSTrainer.Data;

namespace WCSTrainer.Areas.Identity.Pages.Account {
   [Authorize(Roles = "owner, admin")]

   public class RegisterModel : PageModel {
      private readonly SignInManager<UserAccount> _signInManager;
      private readonly UserManager<UserAccount> _userManager;
      private readonly ILogger<RegisterModel> _logger;
      private readonly IEmailSender _emailSender;
      private readonly WCSTrainerContext _context;

      public RegisterModel(
          UserManager<UserAccount> userManager,
          SignInManager<UserAccount> signInManager,
          ILogger<RegisterModel> logger,
          IEmailSender emailSender,
          WCSTrainerContext context) {
         _userManager = userManager;
         _signInManager = signInManager;
         _logger = logger;
         _emailSender = emailSender;
         _context = context;
      }

      [BindProperty]
      public InputModel Input { get; set; }

      public string ReturnUrl { get; set; }

      public IList<AuthenticationScheme> ExternalLogins { get; set; }

      public class InputModel {
         [Required]
         [Display(Name = "Username")]
         public string Username { get; set; }

         [Required]
         [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
         [DataType(DataType.Password)]
         [Display(Name = "Password")]
         public string Password { get; set; }

         [DataType(DataType.Password)]
         [Display(Name = "Confirm password")]
         [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
         public string ConfirmPassword { get; set; }

         [Required]
         [Display(Name = "First Name")]
         public string FirstName { get; set; }

         [Required]
         [Display(Name = "Last Name")]
         public string LastName { get; set; }

         [Required]
         [Display(Name = "Job Title")]
         public string JobTitle { get; set; }

         [Required]
         [Display(Name = "Shift")]
         public int Shift { get; set; }

         [Required]
         [Display(Name = "Employee ID")]
         public int EmployeeID { get; set; }
      }

      public async Task OnGetAsync(string returnUrl = null) {
         ReturnUrl = returnUrl ?? Url.Content("~/");
         ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
      }

      public async Task<IActionResult> OnPostAsync(string returnUrl = null) {
         returnUrl ??= Url.Content("~/");
         ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

         if (ModelState.IsValid) {
            using var transaction = await _context.Database.BeginTransactionAsync();

            try {
               var user = new UserAccount {
                  UserName = Input.Username,
                  DateCreated = DateTime.Now
               };

               var result = await _userManager.CreateAsync(user, Input.Password);

               if (result.Succeeded) {
                  var employee = new Employee {
                     FirstName = Input.FirstName,
                     LastName = Input.LastName,
                     EmployeeID = Input.EmployeeID,
                     JobTitle = Input.JobTitle,
                     Shift = Input.Shift,
                     UserAccountId = user.Id,
                     UserAccount = user,
                     Active = true
                  };

                  _context.Employees.Add(employee);
                  await _context.SaveChangesAsync();


                  user.EmployeeId = employee.Id;
                  await _userManager.UpdateAsync(user);

                  await transaction.CommitAsync();

                  _logger.LogInformation("User created a new account with password.");

                  await _userManager.AddToRoleAsync(user, "guest");

                  TempData["SuccessMessage"] = $"Account '{user.UserName}' was created successfully.";
               }

               foreach (var error in result.Errors) {
                  ModelState.AddModelError(string.Empty, error.Description);
               }
            } catch (Exception ex) {
               await transaction.RollbackAsync();
               _logger.LogError(ex, "An error occurred while registering a new user.");
               ModelState.AddModelError(string.Empty, "An error occurred while registering. Please try again.");
            }
         }
         return Page();
      }
   }
}