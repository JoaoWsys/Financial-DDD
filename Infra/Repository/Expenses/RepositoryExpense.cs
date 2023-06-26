using Domain.Interfaces.IExpense;
using Entities.Entities;
using Infra.Configuration;
using Infra.Repository.Generics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repository.Expenses
{
    public class RepositoryExpense : RepositoryGenerics<Expense>, InterfaceExpense
    {
        private readonly DbContextOptions<ContextBase> _OptionsBuilder;

        public RepositoryExpense()
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task<IList<Expense>> ListUserExpenses(string userEmail)
        {
            using (var database = new ContextBase(_OptionsBuilder))
            {
                return await
                   (from s in database.FinancialSystem
                    join c in database.Category on s.Id equals c.SystemId
                    join us in database.FinancialSystemUser on s.Id equals us.SystemId
                    join e in database.Expense on c.Id equals e.CategoryId
                    where us.UserEmail.Equals(userEmail) && s.Month == e.Month && s.Year == e.Year 
                    select e).AsNoTracking().ToListAsync();
            }
        }

        public async Task<IList<Expense>> ListLateExpensePastMonth(string userEmail)
        {
            using (var database = new ContextBase(_OptionsBuilder))
            {
                return await
                   (from s in database.FinancialSystem
                    join c in database.Category on s.Id equals c.SystemId
                    join us in database.FinancialSystemUser on s.Id equals us.SystemId
                    join e in database.Expense on c.Id equals e.CategoryId
                    where us.UserEmail.Equals(userEmail) && e.Month < DateTime.Now.Month && !e.IsPayed
                    select e).AsNoTracking().ToListAsync();
            }
        }
}
}
