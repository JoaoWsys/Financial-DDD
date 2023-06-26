using Domain.Interfaces.ICategory;
using Entities.Entities;
using Infra.Configuration;
using Infra.Repository.Generics;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repository.Categories
{
    public class RepositoryCategory : RepositoryGenerics<Category>, InterfaceCategory
    {
        private readonly DbContextOptions<ContextBase> _OptionsBuilder;

        public RepositoryCategory()
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }
        public async Task<IList<Category>> ListUserCategories(string userEmail)
        {
            using(var database = new ContextBase(_OptionsBuilder)) 
            {
                return await
                    (from s in database.FinancialSystem
                     join c in database.Category on s.Id equals c.SystemId
                     join us in database.FinancialSystemUser on s.Id equals us.SystemId
                     where us.UserEmail.Equals(userEmail) && us.CurrentSystem
                     select c).AsNoTracking().ToListAsync();
            }
        }
    }
}
