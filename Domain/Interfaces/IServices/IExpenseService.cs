﻿using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.IServices
{
    public interface IExpenseService
    {
        Task AddExpense(Expense expense);
        Task UpdateExense(Expense expense);
    }
}
