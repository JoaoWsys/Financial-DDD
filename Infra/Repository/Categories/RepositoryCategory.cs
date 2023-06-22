using Domain.Interfaces.ICategory;
using Entities.Entities;
using Infra.Repository.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repository.Categories
{
    public class RepositoryCategory : RepositoryGenerics<Category>, InterfaceCategory
    {
        public Task<IList<Category>> ListUserCategories(string userEmail)
        {
            throw new NotImplementedException();
        }
    }
}
