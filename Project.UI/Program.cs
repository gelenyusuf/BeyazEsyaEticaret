using Microsoft.AspNetCore.Identity;
using Project.BLL.ServiceInjections;
using Project.DAL.ContextClasses;
using Project.ENTITIES.Entities;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpClient();

builder.Services.AddControllersWithViews();

builder.Services.AddDistributedMemoryCache(); 
builder.Services.AddSession(x =>
{
    x.IdleTimeout = TimeSpan.FromMinutes(5); 
    x.Cookie.HttpOnly = true; 
    x.Cookie.IsEssential = true;
});

builder.Services
    .AddIdentity<AppUser, AppRole>()
    .AddEntityFrameworkStores<MyContext>()
    .AddDefaultTokenProviders();

builder.Services.AddIdentityServices();


builder.Services.AddDbContextService(builder.Configuration);

builder.Services.AddRepServices();

builder.Services.AddManagerServices();



WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.MapControllerRoute(
     name: "Admin",
     pattern: "{area}/{controller=Home}/{action=Index}/{id?}"
    );
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Register}/{id?}");

app.Run();
