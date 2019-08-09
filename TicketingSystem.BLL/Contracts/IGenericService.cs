using System;
using System.Collections.Generic;
using System.Text;
using TicketingSystem.ViewModel.ViewModel;

namespace TicketingSystem.BLL.Contracts
{
    public interface IGenericService<TVM, TType> where TVM : class where TType : IConvertible
    {
        IEnumerable<TVM> GetAll();
        TVM GetSingleBy(long id);
<<<<<<< HEAD

        ResponseVM Create(TVM entity);
        ResponseVM Delete(TType guid);

        ResponseVM Update(TVM entity);

=======
        ResponseVM Create(TVM entity);
        ResponseVM Delete(long id);
        ResponseVM Update(TVM entity);
>>>>>>> 46c58e86a322ff5f84c1b927d6a1c93aafe67234
    }
}
