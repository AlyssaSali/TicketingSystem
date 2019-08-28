using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketingSystem.BLL.Contracts;
using TicketingSystem.BLL.Helpers;
using TicketingSystem.DAL.Models;
using TicketingSystem.ViewModel.ViewModel;
using TicketingSystem.ViewModel.ViewModels;
using static TicketingSystem.ViewModel.ViewModels.DatatableVM;

namespace TicketingSystem.BLL.Services
{
    public class TicketMinorService : IGenericService<TicketMinorVM>
    {
        private ToViewModel toViewModel = new ToViewModel();
        private ToModel toModel = new ToModel();
        private readonly TicketingSystemContext context;

        public TicketMinorService(TicketingSystemContext _context)
        {
            context = _context;
        }
        public ResponseVM Create(TicketMinorVM ticketMinorVM)
        {
            using (context)
            {
                using (var dbTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        ticketMinorVM.TicketMinorid = Guid.NewGuid();
                        ticketMinorVM.DateAccomplished = DateTime.Now;
                        context.TicketMinors.Add(toModel.TicketMinor(ticketMinorVM));
                        context.SaveChanges();

                        dbTransaction.Commit();
                        return new ResponseVM("created", true, "TicketMinor");
                    }
                    catch (Exception ex)
                    {
                        dbTransaction.Rollback();
                        return new ResponseVM("created", false, "TicketMinor", ResponseVM.SOMETHING_WENT_WRONG, "", ex);
                    }
                }
            }
        }

        public ResponseVM Delete(Guid id)
        {
            using (context)
            {
                if (context.TicketMinors.Where(x => x.TicketMinorid == id && x.Status == "Open").Any())
                {
                    return new ResponseVM("deleted", false, "TicketMinor", "Can't delete! Ticket is still open.");
                }
                using (var dbTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        TicketMinor ticketMinorToBeDeleted = context.TicketMinors.Find(id);
                        if (ticketMinorToBeDeleted == null)
                            return new ResponseVM("deleted", false, "TicketMinor", ResponseVM.DOES_NOT_EXIST);

                        context.TicketMinors.Remove(ticketMinorToBeDeleted);
                        context.SaveChanges();

                        dbTransaction.Commit();
                        return new ResponseVM("deleted", true, "TicketMinor");
                    }
                    catch (Exception ex)
                    {
                        dbTransaction.Rollback();
                        return new ResponseVM("deleted", false, "TicketMinor", ResponseVM.SOMETHING_WENT_WRONG, "", ex);
                    }
                }
            }
        }
        public IEnumerable<TicketMinorVM> GetAll()
        {
            using (context)
            {
                try
                {
                    var categories = context.TicketMinors
                        .Include(x => x.Office)
                        .Include(x => x.Employee)
                        .Include(x => x.CategoryList)
                        .ToList().OrderBy(x => x.Status);
                    var categoriesVm = categories.Select(x => toViewModel.TicketMinor(x));
                    return categoriesVm;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public TicketMinorVM GetSingleBy(Guid id)
        {
            using (context)
            {
                try
                {
                    var categories = context.TicketMinors.Find(id);
                    TicketMinorVM ticketMinorVM = null;
                    if (categories != null)
                        ticketMinorVM = toViewModel.TicketMinor(categories);
                    return ticketMinorVM;
                }
                catch (Exception)
                {
                    throw;
                }

            }
        }

        public ResponseVM Update(TicketMinorVM ticketMinorVM)
        {
            using (context)
            {
                using (var dbTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        TicketMinor ticketMinorToBeUpdated = context.TicketMinors.Find(ticketMinorVM.TicketMinorid);
                        if (ticketMinorToBeUpdated == null)
                            return new ResponseVM("updated", false, "TicketMinor", ResponseVM.DOES_NOT_EXIST);

                        ticketMinorToBeUpdated.DateAccomplished = DateTime.Now;
                        ticketMinorToBeUpdated.WorkByid = Guid.Parse(ticketMinorVM.WorkByid);
                        ticketMinorToBeUpdated.WorkDone = ticketMinorVM.WorkDone;
                        ticketMinorToBeUpdated.Status = ticketMinorVM.Status;
                        context.SaveChanges();

                        dbTransaction.Commit();
                        return new ResponseVM("updated", true, "TicketMinor");
                    }
                    catch (Exception ex)
                    {
                        dbTransaction.Rollback();
                        return new ResponseVM("updated", false, "TicketMinor", ResponseVM.SOMETHING_WENT_WRONG, "", ex);
                    }
                }
            }
        }

        public DatatableVM.PagingResponse<TicketMinorVM> GetDataServerSide(DatatableVM.PagingRequest paging)
        {
<<<<<<< HEAD
            using (context)
            {

                var pagingResponse = new PagingResponse<TicketMinorVM>()
                {
                    // counts how many times the user draws data
                    Draw = paging.Draw
                };
                // initialized query
                IEnumerable<TicketMinor> query = null;
                // search if user provided a search value, i.e. search value is not empty
                if (!string.IsNullOrEmpty(paging.Search.Value))
                {
                    // search based from the search value
                    query = context.TicketMinors
                          .Include(x => x.Office)
                          .Include(x => x.Employee)
                          .Include(x => x.CategoryList)
                          .Where(v => v.TicketMinorid.ToString().ToLower().Contains(paging.Search.Value.ToLower())
                                   || v.Description.ToString().ToLower().Contains(paging.Search.Value.ToLower())
                                   || v.Status.ToString().ToLower().Contains(paging.Search.Value.ToLower())
                                   || v.WorkDone.ToString().ToLower().Contains(paging.Search.Value.ToLower())
                                   || v.DateOfRequest.ToString().ToLower().Contains(paging.Search.Value.ToLower())
                                   || v.TimeOfRequest.ToString().ToLower().Contains(paging.Search.Value.ToLower())
                                   || v.Office.ToString().ToLower().Contains(paging.Search.Value.ToLower())
                                   || v.Employee.ToString().ToLower().Contains(paging.Search.Value.ToLower())
                                   || v.CategoryList.ToString().ToLower().Contains(paging.Search.Value.ToLower())
                                   );
                }
                else
                {
                    // selects all from table
                    query = context.TicketMinors;
                }
                // total records from query
                var recordsTotal = query.Count();
                // orders the data by the sorting selected by the user
                // used ternary operator to determine if ascending or descending
                var colOrder = paging.Order[0];
                switch (colOrder.Column)
                {
                    case 0:
                        query = colOrder.Dir == "asc" ? query.OrderBy(v => v.TicketMinorid) : query.OrderByDescending(v => v.TicketMinorid);
                        break;

                }

                var taken = query.Skip(paging.Start).Take(paging.Length).ToArray();
                // converts model(query) into viewmodel then assigns it to response which is displayed as "data"
                pagingResponse.Reponse = taken.Select(x => toViewModel.TicketMinor(x));
                pagingResponse.RecordsTotal = recordsTotal;
                pagingResponse.RecordsFiltered = recordsTotal;

                return pagingResponse;
            }
=======
            throw new NotImplementedException();
>>>>>>> 00d9a0867d956b23e7a3c0e36fce9ae308d939f7
        }
    }
}

