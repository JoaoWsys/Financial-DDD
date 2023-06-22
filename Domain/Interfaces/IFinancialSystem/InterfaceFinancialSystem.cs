using Domain.Interfaces.Generics;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.IFinancialSystem
{
    public interface InterfaceFinancialSystem : InterfaceGeneric<FinancialSystem>
    {
        Task<IList<FinancialSystem>> ListUserSystems(string userEmail);  
    }
}
