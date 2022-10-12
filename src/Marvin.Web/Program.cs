using HealthChecks.UI.Client;
using Marvin.Web;
using Marvin.Web.Code.Bootstrap;
using Marvin.Web.Code.HealthChecks;
using Marvin.Web.Data;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.AddSwagger();

builder.AddDatabase();

builder.Host.UseSerilog((ctx, lc) =>
    lc.ReadFrom.Configuration(ctx.Configuration)
    );

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

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = new PathString("/login");
    options.SlidingExpiration = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
});

#endregion

builder.Services
.AddControllersWithViews(options =>
{
    options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());

})
.AddFlatAreas(new FlatAreaOptions())
.AddRazorRuntimeCompilation();

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

app.UseRouting();

app.ConfigureSwagger();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(ep =>
{
    ep.MapAreaControllerRoute(areaName: "Landing", name: "default", pattern: "{controller=Landing}/{action=Index}/{id?}");
});

app.MapRazorPages();

app.UseHealthChecks("/status");

app.UseHealthChecks("/healthchecks", new HealthCheckOptions
{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.MapHealthChecksUI();

app.UseSerilogRequestLogging();

app.Run();

