using Domain.Interfaces.IFinancialSystemUser;
using Domain.Interfaces.IServices;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class FinancialSystemUserService : IFinancialSystemUserService
    {
        private readonly InterfaceFinancialSystemUser _interfaceFinancialSystemUser;

        public FinancialSystemUserService(InterfaceFinancialSystemUser interfaceFinancialSystemUser)
        {
            _interfaceFinancialSystemUser = interfaceFinancialSystemUser;
        }

        public async Task AddFinancialSystemUser(FinancialSystemUser financialSystemUser)
        {
            await _interfaceFinancialSystemUser.Add(financialSystemUser);
        }
    }
}
