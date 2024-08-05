using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WCSTrainer.Data;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddDbContext<WCSTrainerContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection") ?? throw new InvalidOperationException("Connection string 'WCSTrainerContext' not found.")));

builder.Services.AddDefaultIdentity<UserAccount>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<WCSTrainerContext>();

builder.Services.AddDbContext<WCSTrainerContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection") ?? throw new InvalidOperationException("Connection string 'WCSTrainerContext' not found.")));

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

if (app.Environment.IsDevelopment()) {
  app.UseDeveloperExceptionPage();
} else {
  app.UseExceptionHandler("/Error");
  app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapRazorPages();

using (var scope = app.Services.CreateScope()) {
  var services = scope.ServiceProvider;
  var userManager = services.GetRequiredService<UserManager<UserAccount>>();
  var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
  await SeedData.AssignRoles(userManager, roleManager);
}

app.Run();
