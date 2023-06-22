using Domain.Interfaces.IFinancialSystem;
using Entities.Entities;
using Infra.Repository.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repository.FinancialSystems
{
    public class RepositoryFinancialSystemUsers : RepositoryGenerics<FinancialSystem>, InterfaceFinancialSystem
    {
        public Task<IList<FinancialSystem>> ListUserSystems(string userEmail)
        {
            throw new NotImplementedException();
        }
    }
}
