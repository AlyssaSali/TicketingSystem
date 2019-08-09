using System;
using System.Collections.Generic;
using System.Text;
using TicketingSystem.ViewModel.ViewModel;

namespace TicketingSystem.BLL.Contracts
{
<<<<<<< HEAD
    public interface IGenericService<TVM> where TVM : class
    {
        IEnumerable<TVM> GetAll();
        TVM GetSingleBy(Guid id);

        ResponseVM Create(TVM entity);
        ResponseVM Delete(Guid guid);
        ResponseVM Update(TVM entity);
=======
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
>>>>>>> d03904ae63c76b400a8493dbaf62e20d91bc2e2f
    }
}
