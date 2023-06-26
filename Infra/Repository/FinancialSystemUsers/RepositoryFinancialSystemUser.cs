using Domain.Interfaces.IFinancialSystemUser;
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
    public class RepositoryFinancialSystemUser : RepositoryGenerics<FinancialSystemUser>, InterfaceFinancialSystemUser
    {
        private readonly DbContextOptions<ContextBase> _OptionsBuilder;

        public RepositoryFinancialSystemUser()
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }
        public async Task<FinancialSystemUser> GetUserByEmail(string userEmail)
        {
            using (var database = new ContextBase(_OptionsBuilder))
            {
                return await
                   database.FinancialSystemUser.AsNoTracking().
                   FirstOrDefaultAsync(x => x.UserEmail.Equals(userEmail));
            }
        }

        public async Task<IList<FinancialSystemUser>> ListSystemsUsers(int systemId)
        {
            using (var database = new ContextBase(_OptionsBuilder))
            {
                return await
                   database.FinancialSystemUser
                   .Where(s => s.SystemId == systemId).AsNoTracking()
                   .ToListAsync();
            }
        }

        public async Task RemoveUsers(List<FinancialSystemUser> users)
        {
            using (var database = new ContextBase(_OptionsBuilder))
            {
                database.FinancialSystemUser
                    .RemoveRange(users);

                await database.SaveChangesAsync();
            }
        }
    }
}
