using System;
using System.Collections.Generic;
using System.Text;
using TicketingSystem.ViewModel.ViewModel;

namespace TicketingSystem.BLL.Contracts
{
    public interface IGenericService<TVM> where TVM : class
    {
        IEnumerable<TVM> GetAll();
        TVM GetSingleBy(Guid id);

        ResponseVM Create(TVM entity);
<<<<<<< HEAD
        ResponseVM Delete(Guid guid);
=======
        ResponseVM Delete(Guid id);
>>>>>>> 2fb85b2afa0a42a16fcb96d7ab04b103ede54f15
        ResponseVM Update(TVM entity);
    }
}
