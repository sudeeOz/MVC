var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews(); //middleway

var app = builder.Build();

app.UseHttpsRedirection();
app.UseRouting();

app.MapControllerRoute(
    name:"default",
    pattern:"{controller=Home}/{action=Index}/{id?}");

app.Run();
