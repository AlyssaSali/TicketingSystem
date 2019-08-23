using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TicketingSystem.BLL.Contracts;
using TicketingSystem.BLL.Helpers;
using TicketingSystem.DAL.Models;
using TicketingSystem.ViewModel.ViewModel;
using TicketingSystem.ViewModel.ViewModels;
using static TicketingSystem.ViewModel.ViewModels.DatatableVM;

namespace TicketingSystem.BLL.Services
{
    public class ITGroupService : IGenericService<ITGroupVM>
    {
        private ToViewModel toViewModel = new ToViewModel();
        private ToModel toModel = new ToModel();
        private readonly TicketingSystemContext context;

        public ITGroupService(TicketingSystemContext _context)
        {
            context = _context;
        }
        public ResponseVM Create(ITGroupVM itgroupVM)
        {
            using (context)
            {
                if (context.ITGroups.Where(x => x.ITGroupName == itgroupVM.ITGroupName).Any())
                {
                    return new ResponseVM("created", false, "ITGroup", ResponseVM.ALREADY_EXIST);
                }
                using (var dbTransaction = context.Database.BeginTransaction())
                {
                    try
                    {

                        context.ITGroups.Add(toModel.ITGroup(itgroupVM));
                        context.SaveChanges();

                        dbTransaction.Commit();
                        return new ResponseVM("created", true, "ITGroup");
                    }
                    catch (Exception ex)
                    {
                        dbTransaction.Rollback();
                        return new ResponseVM("created", false, "ITGroup", ResponseVM.SOMETHING_WENT_WRONG, "", ex);
                    }
                }
            }
        }
        public ResponseVM Delete(Guid id)
        {
            using (context)
            {
                if (context.CategoryLists.Where(x => x.ITGroupid == id).Any())
                {
                    return new ResponseVM("deleted", false, "ITGroup", ResponseVM.DONT_DELETE);
                }
                using (var dbTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        ITGroup itgroupToBeDeleted = context.ITGroups.Find(id);
                        if (itgroupToBeDeleted == null)
                            return new ResponseVM("deleted", false, "ITGroup", ResponseVM.DOES_NOT_EXIST);

                        context.ITGroups.Remove(itgroupToBeDeleted);
                        context.SaveChanges();

                        dbTransaction.Commit();
                        return new ResponseVM("deleted", true, "ITGroup");
                    }
                    catch (Exception ex)
                    {
                        dbTransaction.Rollback();
                        return new ResponseVM("deleted", false, "ITGroup", ResponseVM.SOMETHING_WENT_WRONG, "", ex);
                    }
                }
            }
        }
        public IEnumerable<ITGroupVM> GetAll()
        {
            using (context)
            {
                try
                {
                    var itgroups = context.ITGroups.ToList().OrderByDescending(x => x.ITGroupid);
                    var itgroupsVm = itgroups.Select(x => toViewModel.ITGroup(x));
                    return itgroupsVm;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public ITGroupVM GetSingleBy(Guid id)
        {
            using (context)
            {
                try
                {
                    var itgroups = context.ITGroups.Find(id);
                    ITGroupVM itgroupVM = null;
                    if (itgroups != null)
                        itgroupVM = toViewModel.ITGroup(itgroups);
                    return itgroupVM;
                }
                catch (Exception)
                {
                    throw;
                }

            }
        }
        public ResponseVM Update(ITGroupVM itgroupVM)
        {
            using (context)
            {
                if (context.ITGroups.Where(x => x.ITGroupName == itgroupVM.ITGroupName).Any())
                {
                    return new ResponseVM("updated", false, "ITGroup", ResponseVM.NO_NEW_DATA);
                }
                using (var dbTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        ITGroup itgroupToBeUpdated = context.ITGroups.Find(itgroupVM.ITGroupid);
                        if (itgroupToBeUpdated == null)
                            return new ResponseVM("updated", false, "ITGroup", ResponseVM.DOES_NOT_EXIST);

                        itgroupToBeUpdated.ITGroupCode = itgroupVM.ITGroupCode;
                        itgroupToBeUpdated.ITGroupName = itgroupVM.ITGroupName;
                        context.SaveChanges();

                        dbTransaction.Commit();
                        return new ResponseVM("updated", true, "ITGroup");
                    }
                    catch (Exception ex)
                    {
                        dbTransaction.Rollback();
                        return new ResponseVM("updated", false, "ITGroup", ResponseVM.SOMETHING_WENT_WRONG, "", ex);
                    }
                }
            }
        }

        public PagingResponse<ITGroupVM> GetDataServerSide(PagingRequest paging)
        {    
            using (context)
            {

                var pagingResponse = new PagingResponse<ITGroupVM>()
                {
                    // counts how many times the user draws data
                    Draw = paging.Draw
                };
                // initialized query
                IEnumerable<ITGroup> query = null;
                // search if user provided a search value, i.e. search value is not empty
                if (!string.IsNullOrEmpty(paging.Search.Value))
                {
                    // search based from the search value
                    query = context.ITGroups
                          .Where(v => v.ITGroupCode.ToString().ToLower().Contains(paging.Search.Value.ToLower()) ||
                                      v.ITGroupName.ToString().ToLower().Contains(paging.Search.Value.ToLower()));
                }
                else
                {
                    // selects all from table
                    query = context.ITGroups;
                }
                // total records from query
                var recordsTotal = query.Count();
                // orders the data by the sorting selected by the user
                // used ternary operator to determine if ascending or descending
                var colOrder = paging.Order[0];
                switch (colOrder.Column)
                {
                    case 0:
                        query = colOrder.Dir == "asc" ? query.OrderBy(v => v.ITGroupName) : query.OrderByDescending(v => v.ITGroupName);
                        break;
                    
                }

                var taken = query.Skip(paging.Start).Take(paging.Length).ToArray();
                // converts model(query) into viewmodel then assigns it to response which is displayed as "data"
                pagingResponse.Reponse = taken.Select(x => toViewModel.ITGroup(x));
                pagingResponse.RecordsTotal = recordsTotal;
                pagingResponse.RecordsFiltered = recordsTotal;

                return pagingResponse;
            }
        }
    }


}

