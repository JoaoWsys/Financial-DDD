using Domain.Interfaces.IExpense;
using Entities.Entities;
using Infra.Repository.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repository.Expenses
{
    public class RepositoryExpense : RepositoryGenerics<Expense>, InterfaceExpense
    {
        public Task<IList<Expense>> ListLateExpensePastMonth(string emailUsuario)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Expense>> ListUserExpenses(string emailUsuario)
        {
            throw new NotImplementedException();
        }
    }
}
