using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTB.Eshop.Application.ViewModels;
using UTB.Eshop.Domain.Entities;

namespace UTB.Eshop.Application.Abstraction
{
    public interface IAdminJidelnicekManagement

    {
        IList<Jidelnicek> Select();
       
        bool Delete(int id);

        Jidelnicek GetJidelnicekById(int id);

        bool UpdateJidelnicek(Jidelnicek updatedJidelnicek);

    }
}
