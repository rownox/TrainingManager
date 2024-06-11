using Microsoft.EntityFrameworkCore;
using WCSTrainer.Data;
using WCSTrainer.Models;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddDbContext<WCSTrainerContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection") ?? throw new InvalidOperationException("Connection string 'WCSTrainerContext' not found.")));

builder.Services.AddDefaultIdentity<UserAccount>(options => options.SignIn.RequireConfirmedAccount = false).AddEntityFrameworkStores<IdentityContext>();
builder.Services.AddDbContext<IdentityContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection") ?? throw new InvalidOperationException("Connection string 'WCSTrainerContext' not found.")));

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

//app.MapRazorComponents<>()
//    .AddInteractiveServerRenderMode();

app.Run();
