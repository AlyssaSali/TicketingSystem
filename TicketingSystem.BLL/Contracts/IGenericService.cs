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
        ResponseVM Delete(Guid id);
=======
<<<<<<< HEAD
        ResponseVM Delete(Guid guid);
=======
        ResponseVM Delete(Guid id);
>>>>>>> 672730fec7a9527c892fc88cfb34fa9e84777be3
>>>>>>> af8a36911860fc01eb54fa1355606495cc985b86
        ResponseVM Update(TVM entity);
    }
}
