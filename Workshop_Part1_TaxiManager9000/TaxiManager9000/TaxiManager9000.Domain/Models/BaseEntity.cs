using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiManager9000.Domain.Models
{
    // Abstract class BaseEntity
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public abstract string Print();
    }
}
