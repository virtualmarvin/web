using FuncSharp;
using HealthChecks.UI.Client;
using Marvin.Web.Data;
using Marvin.Web.HealthChecks;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
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

builder.Services
    .AddHealthChecksUI()
    .AddInMemoryStorage();
/*    .AddPostgreSqlStorage(connectionString);*/

builder.Services.AddHealthChecks()
    .AddNpgSql(connectionString, name: "Database")
    .AddCheck<ExampleHealthCheck>("Example");

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

app.UseRouting()
    .UseEndpoints(config => config.MapHealthChecksUI()); ;

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.UseHealthChecks("/status");

app.UseHealthChecks("/healthchecks", new HealthCheckOptions
{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.Run();
