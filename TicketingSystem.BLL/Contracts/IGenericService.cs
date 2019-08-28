using System;
using System.Collections.Generic;
using System.Text;
using TicketingSystem.ViewModel.ViewModel;
using static TicketingSystem.ViewModel.ViewModels.DatatableVM;

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

        ResponseVM Delete(Guid id);
=======
<<<<<<< HEAD
        ResponseVM Delete(Guid guid);
=======
        ResponseVM Delete(Guid id);
<<<<<<< HEAD
=======
<<<<<<< HEAD

=======
>>>>>>> 63171424717892a87f2f85c43afeee8014c441ad
>>>>>>> 2fb85b2afa0a42a16fcb96d7ab04b103ede54f15
>>>>>>> 89bb63c04e1ad5424f19b0fd116240805a791ee4
>>>>>>> 00d9a0867d956b23e7a3c0e36fce9ae308d939f7
        ResponseVM Update(TVM entity);

        PagingResponse<TVM> GetDataServerSide(PagingRequest paging);
    }
}
