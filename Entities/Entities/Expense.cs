using Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    [Table("Expense")]
    public class Expense : Base
    {
        public decimal Value { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }

        public EnumExpenseType ExpenseType { get; set; }

        public DateTime RegisterDate { get; set; }
        public DateTime ChangeDate { get; set; }
        public DateTime PaymentDate { get; set; }
        public DateTime DueDate { get; set; }

        public bool IsPayed { get; set; }
        public bool IsLate { get; set;}

        [ForeignKey("Category")]
        [Column(Order = 1)]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
