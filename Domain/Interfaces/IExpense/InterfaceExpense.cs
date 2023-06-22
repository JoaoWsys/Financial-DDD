using Domain.Interfaces.Generics;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.IExpense
{
    public interface InterfaceExpense : InterfaceGeneric<Expense>
    {
        Task<IList<Expense>> ListUserExpenses(string emailUsuario);
        Task<IList<Expense>> ListLateExpensePastMonth(string emailUsuario);
    }
}
