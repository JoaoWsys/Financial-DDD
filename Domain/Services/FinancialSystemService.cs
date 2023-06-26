using Domain.Interfaces.IFinancialSystem;
using Domain.Interfaces.IServices;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class FinancialSystemService : IFinancialSystemService
    {
        private readonly InterfaceFinancialSystem _interfaceFinancialSystem;

        public FinancialSystemService(InterfaceFinancialSystem interfaceFinancialSystem)
        {
            _interfaceFinancialSystem = interfaceFinancialSystem;
        }

        public async Task AddFinancialSystem(FinancialSystem financialSystem)
        {
            var valid = financialSystem.StringPropertyValidate(financialSystem.Name, "Name");

            if (valid)
            {
                var data = DateTime.Now;

                financialSystem.ClosingDay = 1;
                financialSystem.Year = data.Year;
                financialSystem.Month = data.Month;
                financialSystem.YearCopy = data.Year;
                financialSystem.MonthCopy = data.Year;
                financialSystem.GenerateExpenseCopy = true;

                await _interfaceFinancialSystem.Add(financialSystem);
            }
        }

        public async Task UpdateFinancialSystem(FinancialSystem financialSystem)
        {
            var valid = financialSystem.StringPropertyValidate(financialSystem.Name, "Name");

            if (valid)
            {
                financialSystem.ClosingDay = 1;
                await _interfaceFinancialSystem.Update(financialSystem);
            }
        }
    }
}
