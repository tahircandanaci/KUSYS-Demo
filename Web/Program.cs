using Data.EFCore.Context;
using Data.EFCore;
using Domain.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Add Context
builder.Services.AddScoped<KUSYSContext>();
//builder.Services.AddDbContext<KUSYSContext>(options =>
//options.UseSqlServer(builder.Configuration.GetConnectionString("KUSYS_CS")));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddSession(option =>
{
    option.IdleTimeout = TimeSpan.FromMinutes(30);
});

//var roles = new List<IoCRole>
//{
//    new IoCRole
//    {
//        Dll = "Data.EFCore.dll", //DLL name
//        Implementation = "Data.EFCore", // Implementation name, can be used for a control if you use several projects and wanted to separate them
//        Priority = 1, // Priority that the dll should be loaded
//        LifeTime = LifeTime.SCOPED, // Lifetime of your addiction injection
//        Name = "EFCore", //Dependency name. It is used only for identification
//        Active = true
//    }
//};

//var allowedInterfaceNamespaces = new List<string> { "Domain" };
//builder.Services.RegisterDynamicDependencies(new IoCConfiguration(roles, allowedInterfaceNamespaces));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseSession();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();
