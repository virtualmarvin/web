using HealthChecks.UI.Client;
using Marvin.Web.Bootstrap;
using Marvin.Web.Data;
using Marvin.Web.HealthChecks;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.AddDatabase();

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
