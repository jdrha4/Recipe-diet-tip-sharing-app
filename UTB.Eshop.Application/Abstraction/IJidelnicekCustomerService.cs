using System;
using System.Collections.Generic;
using UTB.Eshop.Domain.Entities;

namespace UTB.Eshop.Application.Abstraction
{
    public interface IJidelnicekCustomerService
    {
        IList<Jidelnicek> GetJidelnickyForUser(int userId);

        bool Delete(int id);

        Jidelnicek GetJidelnicekById(int id);  

        bool UpdateJidelnicek(Jidelnicek updatedJidelnicek);
    }
}
