using System.Net.Mime;
using System.Security.Cryptography;
using System.Text;
// The support for MVC
// Основната конфигурација на  ASP.NET Core MVC апликација.
// поставување на сервисите

var builder = WebApplication.CreateBuilder(args);

// Додавање на MVC контролери и Views:
builder.Services.AddControllersWithViews();
// градење на app објектот:
var app = builder.Build();

app.UseStaticFiles(); // со ова се дозволува да се користат статички фајлови, слики, CSS, JS files ...
// Активира routing, за да може ASP.NET да знае како да ги поврзе URL-ите со контролери и action методи.
app.UseRouting();
app.UseAuthorization();

// ДЕФИНИРАЊЕ НА DEFAULT ROUTE
app.MapControllerRoute(
name: "default",
pattern: "{controller=Home}/{action=Index}/{id?}");
// Стартување на апликацијата 
app.Run();

