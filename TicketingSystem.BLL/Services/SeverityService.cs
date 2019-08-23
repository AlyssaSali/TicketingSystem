using Microsoft.EntityFrameworkCore;
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
    public class SeverityService : IGenericService<SeverityVM>
    {
        private ToViewModel toViewModel = new ToViewModel();
        private ToModel toModel = new ToModel();
        private readonly TicketingSystemContext context;

        public SeverityService(TicketingSystemContext _context)
        {
            context = _context;
        }
        public ResponseVM Create(SeverityVM severityVM)
        {
            using (context)
            {
                using (var dbTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        severityVM.severityid = Guid.NewGuid();
                        context.Severities.Add(toModel.Severity(severityVM));
                        context.SaveChanges();

                        dbTransaction.Commit();
                        return new ResponseVM("created", true, "Severity");
                    }
                    catch (Exception ex)
                    {
                        dbTransaction.Rollback();
                        return new ResponseVM("created", false, "Severity", ResponseVM.SOMETHING_WENT_WRONG, "", ex);
                    }
                }
            }
        }
        public ResponseVM Delete(Guid id)
        {
            using (context)
            {
                using (var dbTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Severity severityToBeDeleted = context.Severities.Find(id);
                        if (severityToBeDeleted == null)
                            return new ResponseVM("deleted", false, "Severity", ResponseVM.DOES_NOT_EXIST);

                        context.Severities.Remove(severityToBeDeleted);
                        context.SaveChanges();

                        dbTransaction.Commit();
                        return new ResponseVM("deleted", true, "Severity");
                    }
                    catch (Exception ex)
                    {
                        dbTransaction.Rollback();
                        return new ResponseVM("deleted", false, "Severity", ResponseVM.SOMETHING_WENT_WRONG, "", ex);
                    }
                }
            }
        }
        public IEnumerable<SeverityVM> GetAll()
        {
            using (context)
            {
                try
                {
                    var categories = context.Severities.ToList().OrderByDescending(x => x.severityid);
                    var categoriesVm = categories.Select(x => toViewModel.Severity(x));
                    return categoriesVm;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public SeverityVM GetSingleBy(Guid id)
        {
            using (context)
            {
                try
                {
                    var categories = context.Severities.Find(id);
                    SeverityVM severityVM = null;
                    if (categories != null)
                        severityVM = toViewModel.Severity(categories);
                    return severityVM;
                }
                catch (Exception)
                {
                    throw;
                }

            }
        }
        public ResponseVM Update(SeverityVM severityVM)
        {
            using (context)
            {
                using (var dbTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Severity severityToBeUpdated = context.Severities.Find(severityVM.severityid);
                        if (severityToBeUpdated == null)
                            return new ResponseVM("updated", false, "Severity", ResponseVM.DOES_NOT_EXIST);

                        severityToBeUpdated.SeverityCode = severityVM.SeverityCode;
                        severityToBeUpdated.SeverityName = severityVM.SeverityName;
                        severityToBeUpdated.SeverityDesc = severityVM.SeverityDesc;
                        context.SaveChanges();

                        dbTransaction.Commit();
                        return new ResponseVM("updated", true, "Severity");
                    }
                    catch (Exception ex)
                    {
                        dbTransaction.Rollback();
                        return new ResponseVM("updated", false, "Severity", ResponseVM.SOMETHING_WENT_WRONG, "", ex);
                    }
                }
            }
        }

        public DatatableVM.PagingResponse<SeverityVM> GetDataServerSide(DatatableVM.PagingRequest paging)
        {
            using (context)
            {

                var pagingResponse = new PagingResponse<SeverityVM>()
                {
                    // counts how many times the user draws data
                    Draw = paging.Draw
                };
                // initialized query
                IEnumerable<Severity> query = null;
                // search if user provided a search value, i.e. search value is not empty
                if (!string.IsNullOrEmpty(paging.Search.Value))
                {
                    // search based from the search value
                    query = context.Severities
                          .Where(v => v.SeverityCode.ToString().ToLower().Contains(paging.Search.Value.ToLower()) ||
                                      v.SeverityDesc.ToString().ToLower().Contains(paging.Search.Value.ToLower()));
                }
                else
                {
                    // selects all from table
                    query = context.Severities;
                }
                // total records from query
                var recordsTotal = query.Count();
                // orders the data by the sorting selected by the user
                // used ternary operator to determine if ascending or descending
                var colOrder = paging.Order[0];
                switch (colOrder.Column)
                {
                    case 0:
                        query = colOrder.Dir == "asc" ? query.OrderBy(v => v.SeverityCode) : query.OrderByDescending(v => v.SeverityCode);
                        break;

                }

                var taken = query.Skip(paging.Start).Take(paging.Length).ToArray();
                // converts model(query) into viewmodel then assigns it to response which is displayed as "data"
                pagingResponse.Reponse = taken.Select(x => toViewModel.Severity(x));
                pagingResponse.RecordsTotal = recordsTotal;
                pagingResponse.RecordsFiltered = recordsTotal;

                return pagingResponse;
            }
        }
    }
    
}

