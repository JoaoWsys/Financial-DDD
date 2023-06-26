using Domain.Interfaces.ICategory;
using Domain.Interfaces.IServices;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly InterfaceCategory _interfaceCategory;
        public CategoryService(InterfaceCategory interfaceCategory) 
        {
            _interfaceCategory = interfaceCategory;
        }
        public async Task AddCategory(Category category)
        {
            var valid = category.StringPropertyValidate(category.Name, "Name");
            if (valid) await _interfaceCategory.Add(category);
        }

        public async Task UpdateCategory(Category category)
        {
            var valid = category.StringPropertyValidate(category.Name, "Name");
            if (valid) await _interfaceCategory.Update(category);
        }
    }
}
