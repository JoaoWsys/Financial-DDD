using Domain.Interfaces.IFinancialSystem;
using Entities.Entities;
using Infra.Configuration;
using Infra.Repository.Generics;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repository.FinancialSystems
{
    public class RepositoryFinancialSystem : RepositoryGenerics<FinancialSystem>, InterfaceFinancialSystem
    {
        private readonly DbContextOptions<ContextBase> _OptionsBuilder;

        public RepositoryFinancialSystem()
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task<IList<FinancialSystem>> ListUserSystems(string userEmail)
        {
            using (var database = new ContextBase(_OptionsBuilder))
            {
                return await
                   (from s in database.FinancialSystem
                    join us in database.FinancialSystemUser on s.Id equals us.SystemId
                    where us.UserEmail.Equals(userEmail)
                    select s).AsNoTracking().ToListAsync();
            }
        }
    }
}
