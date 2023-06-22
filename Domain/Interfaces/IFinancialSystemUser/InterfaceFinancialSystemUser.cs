using Domain.Interfaces.Generics;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Domain.Interfaces.IFinancialSystemUser
{
    public interface InterfaceFinancialSystemUser : InterfaceGeneric<FinancialSystemUser>
    {
        Task<IList<FinancialSystemUser>> ListSystemsUsers(int systemId);
        Task RemoveUsers(List<FinancialSystemUser> users);
        Task<FinancialSystemUser> GetUserByEmail(string userEmail);
    }
}