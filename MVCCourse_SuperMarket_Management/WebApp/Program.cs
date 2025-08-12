using System.Net.Mime;
using System.Security.Cryptography;
using System.Text;
// The support for MVC
// ��������� ������������ ��  ASP.NET Core MVC ���������.
// ����������� �� ���������

var builder = WebApplication.CreateBuilder(args);

// �������� �� MVC ���������� � Views:
builder.Services.AddControllersWithViews();
// ������ �� app �������:
var app = builder.Build();

app.UseStaticFiles(); // �� ��� �� ��������� �� �� �������� �������� ������, �����, CSS, JS files ...
// �������� routing, �� �� ���� ASP.NET �� ���� ���� �� �� ������ URL-��� �� ���������� � action ������.
app.UseRouting();
app.UseAuthorization();

// ���������� �� DEFAULT ROUTE
app.MapControllerRoute(
name: "default",
pattern: "{controller=Home}/{action=Index}/{id?}");
// ���������� �� ����������� 
app.Run();

