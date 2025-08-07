using System.ComponentModel.DataAnnotations; // built-in namespace in .NET that contains classes and attributes used for: Validation (required, stringlength, range, email address, display...)

namespace SpendSmart.Models
{
    public class Expense
    {
        public int Id { get; set; }
        public decimal Value { get; set; }
        // The ? makes it nullable, so the value can be either a string or null
        [Required]
        public string? Description { get; set; }
    }
}
