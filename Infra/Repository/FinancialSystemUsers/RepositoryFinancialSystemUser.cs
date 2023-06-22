using Domain.Interfaces.IFinancialSystemUser;
using Entities.Entities;
using Infra.Repository.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repository.FinancialSystems
{
    public class RepositoryFinancialSystemUser : RepositoryGenerics<FinancialSystemUser>, InterfaceFinancialSystemUser
    {
        public Task<FinancialSystemUser> GetUserByEmail(string userEmail)
        {
            throw new NotImplementedException();
        }

        public Task<IList<FinancialSystemUser>> ListSystemsUsers(int systemId)
        {
            throw new NotImplementedException();
        }

        public Task RemoveUsers(List<FinancialSystemUser> users)
        {
            throw new NotImplementedException();
        }
    }
}
