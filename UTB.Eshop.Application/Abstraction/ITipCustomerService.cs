using System;
using System.Collections.Generic;
using UTB.Eshop.Domain.Entities;

namespace UTB.Eshop.Application.Abstraction
{
    public interface ITipCustomerService
    {
        IList<Tip> GetTipsForUser(int userId);

        bool Delete(int id);

      
    }
}
