using Microsoft.EntityFrameworkCore;
using StoreApp.Models;

var builder = WebApplication.CreateBuilder(args);

// -------------------------------------------------
// Service Registrations (app.Build()'dan önce yapılır)
// -------------------------------------------------
builder.Services.AddControllersWithViews()
                .AddRazorRuntimeCompilation();

builder.Services.AddDbContext<RepositoryContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("sqlconnection"))
);

var app = builder.Build();

// -------------------------------------------------
// Middleware Pipeline
// -------------------------------------------------
if (app.Environment.IsDevelopment())
{
    // Geliştirme ortamında detaylı hata sayfası
    app.UseDeveloperExceptionPage();
}
else
{
    // Prod ortamı için global hata yakalama
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

// -------------------------------------------------
// Endpoint Mapping
// -------------------------------------------------
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.Run();
