using Domain.Interfaces.IExpense;
using Domain.Interfaces.IServices;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class ExpenseService : IExpenseService
    {
        private readonly InterfaceExpense _interfaceExpense;

        public ExpenseService(InterfaceExpense interfaceExpense)
        {
            _interfaceExpense = interfaceExpense;
        }

        public async Task AddExpense(Expense expense)
        {
            var data = DateTime.UtcNow;
            expense.RegisterDate = data;
            expense.Year= data.Year;
            expense.Month = data.Month;

            var valid = expense.StringPropertyValidate(expense.Name, "Name");
            if (valid) await _interfaceExpense.Add(expense);
        }

        public async Task UpdateExense(Expense expense)
        {
            var data = DateTime.UtcNow;
            expense.ChangeDate = data;

            if (expense.IsPayed)
                expense.PaymentDate = data;
            
            var valid = expense.StringPropertyValidate(expense.Name, "Name");
            if (valid) await _interfaceExpense.Update(expense);
        }
    }
}
