using FuncSharp;
using Marvin.Web.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

#region DatabaseSetup
var usePostgres = builder.Configuration["UsePostgres"];
var activeConnectionString = builder.Configuration["ActiveConnectionString"];
var connectionString = builder.Configuration.GetConnectionString(activeConnectionString);

activeConnectionString.Contains("PostgresConnection")
    .Match(
        t => builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(connectionString)),
        f => builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString))
    );

builder.Services.AddDatabaseDeveloperPageExceptionFilter();
#endregion

#region IdentityAndAccessManagement
builder.Services
    .AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddAuthentication()
    .AddGoogle(googleOptions =>
    {
        googleOptions.ClientId = builder.Configuration["Authentication:Google:ClientId"];
        googleOptions.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"];
    }).AddFacebook(facebookOptions =>
    {
        facebookOptions.AppId = builder.Configuration["Authentication:Facebook:AppId"];
        facebookOptions.AppSecret = builder.Configuration["Authentication:Facebook:AppSecret"];
    });
#endregion

builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
