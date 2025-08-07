using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SpendSmart.Models;

namespace SpendSmart.Controllers
{
    public class HomeController : Controller
    {
        // privatna promenliva
        // readonly - mozi da e postavena samo vo konstruktorot, ne mozi da se smeni podocna
        private readonly ILogger<HomeController> _logger;
        // privatna promenliva, samo za citanje promenliva koja ke go cuva tvojot DbContext (konekcijata so bazata)
        private readonly SpendSmartDbContext _context;

        // OVA E KONSTRUKTOR NA HomeController
        // koga ASP.NET ke go sozdade HomeController, avtomatski ke injektira ili ke gi vmetni potrebnite servisi
        public HomeController(ILogger<HomeController> logger, SpendSmartDbContext context)
        {
            _logger = logger; // za logiranje
            _context = context; // za baza
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Expenses()
        {
            var allExpenses = _context.Expenses.ToList();
            var totalExpenses = allExpenses.Sum(x => x.Value);
            ViewBag.Expenses = totalExpenses; // View Bag e dinamicen objekt preku koj mozi da se pratat dopolnitelni informacii od kontrolerot do View
            return View(allExpenses);
        }

        public IActionResult CreateEditExpense(int? id)
        {
            if(id!=null)
            {
                // editing -> load an expense by id
                var expenseInDb = _context.Expenses.SingleOrDefault(expense => expense.Id == id);
                return View(expenseInDb);
            }

            return View();
        }
        public IActionResult DeleteExpense(int id)
        {
            var expenseInDb = _context.Expenses.SingleOrDefault(expense => expense.Id == id);
            _context.Expenses.Remove(expenseInDb);
            _context.SaveChanges();
            return RedirectToAction("Expenses");
        }
        public IActionResult CreateEditExpenseForm(Expense model)
        {
            if (model.Id == 0)
            {
                // Create
                _context.Expenses.Add(model);
            }
            else
            {
                // Editing
                _context.Expenses.Update(model);
            }
                //_context.Expenses.Add(model); // dodavanje na nov objekt (samo go postavuva objektot za dodavanje)
            _context.SaveChanges();
            return RedirectToAction("Expenses"); 
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
