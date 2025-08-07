using Microsoft.EntityFrameworkCore;
namespace SpendSmart.Models
{
    // Definiranje na nova klasa SpendSmartDbContext
    // Taa klasa nasleduva (Extends) od DbContext - bazna klasa koja e del od Entity Framework Core
    // Db context e glavnata klasa koja go pretstavuva kontekstot kon bazata na podatoci
    // so ova se sozdava sopstven kontekst za rabotenje so bazata
    public class SpendSmartDbContext:DbContext
    {
        // Db set e tabela koja ke se narekua Expenses
        public DbSet<Expense> Expenses { get; set; }
        // Konstruktor
        // Ovaj konstruktor prima eden parametar od tipot DbContextOptions<SpendSmartDbContext>
        // set na opcii za konfiguriranje na bazata
        public SpendSmartDbContext(DbContextOptions<SpendSmartDbContext> options):base(options)
        {
             
        }
    }
}
