using Marvin.Web;
using Marvin.Web.Areas._Related;
using Marvin.Web.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpContextAccessor();

// Caching 
builder.Services.AddScoped<ICache, Cache>();
builder.Services.AddScoped<ILookup, Lookup>();
builder.Services.AddScoped<ITypeahead, Typeahead>();
builder.Services.AddSingleton<IFilter, Filter>();

// Support services
builder.Services.AddScoped<IExcel, Excel>();
builder.Services.AddScoped<IEmail, Email>();
builder.Services.AddScoped<IRollup, Rollup>();
builder.Services.AddSingleton<IRelated, Related>();

// Applications services
builder.Services.AddScoped<IViewedService, ViewedService>();

// Identity support
builder.Services.AddScoped<ICurrentUser, CurrentUser>();
builder.Services.AddScoped<IUserClaimsPrincipalFactory<IdentityUser>, ClaimsPrincipalFactory>();
builder.Services.AddScoped<IIdentityService, IdentityService>();

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
        .AddEntityFrameworkStores<ApplicationDbContext>()
        .AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = new PathString("/login");
    options.SlidingExpiration = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
});

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequiredLength = 8;
    options.Password.RequireDigit = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireLowercase = true;
});

// Database contexts: For localdb connectionString's path is calculated
var connectionString = builder.Configuration.GetConnectionString("Marvin")
                              .Replace("{Path}", builder.Environment.ContentRootPath);

builder.Services.AddDbContext<UltraContext>(options =>
                         options.UseSqlServer(connectionString));
builder.Services.AddDbContext<ApplicationDbContext>(options =>
                         options.UseSqlServer(connectionString));

builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add(typeof(GlobalExceptionFilter));
    options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
    options.Filters.Add(typeof(ControllerAccessorFilter)); // required for ultra-clean architecture

}).AddFlatAreas(new FlatAreaOptions())
  .AddRazorRuntimeCompilation();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

// ----

var app = builder.Build();

var httpContextAccessor = app.Services.GetRequiredService<IHttpContextAccessor>();
ServiceLocator.Register(httpContextAccessor);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();