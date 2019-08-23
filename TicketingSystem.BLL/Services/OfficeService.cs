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
    public class OfficeService : IGenericService<OfficeVM>
    {
        private ToViewModel toViewModel = new ToViewModel();
        private ToModel toModel = new ToModel();
        private readonly TicketingSystemContext context;

        public OfficeService(TicketingSystemContext _context)
        {
            context = _context;
        }
        public ResponseVM Create(OfficeVM officeVM)
        {
            using (context)
            {
                if (context.Offices.Where(x => x.OfficeCode == officeVM.OfficeCode || x.OfficeDesc == officeVM.OfficeDesc).Any())
                {
                    return new ResponseVM("created", false, "Office", ResponseVM.ALREADY_EXIST);
                }
                using (var dbTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        officeVM.Officeid = Guid.NewGuid();
                        context.Offices.Add(toModel.Office(officeVM));
                        context.SaveChanges();

                        dbTransaction.Commit();
                        return new ResponseVM("created", true, "Office");
                    }
                    catch (Exception ex)
                    {
                        dbTransaction.Rollback();
                        return new ResponseVM("created", false, "Office", ResponseVM.SOMETHING_WENT_WRONG, "", ex);
                    }
                }
            }
        }
        public ResponseVM Delete(Guid id)
        {
            using (context)
            {
                if (context.Employees.Where(x => x.Officeid == id).Any())
                {
                    return new ResponseVM("deleted", false, "Office", ResponseVM.DONT_DELETE);
                }
                using (var dbTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Office officeToBeDeleted = context.Offices.Find(id);
                        if (officeToBeDeleted == null)
                            return new ResponseVM("deleted", false, "Office", ResponseVM.DOES_NOT_EXIST);

                        context.Offices.Remove(officeToBeDeleted);
                        context.SaveChanges();

                        dbTransaction.Commit();
                        return new ResponseVM("deleted", true, "Office");
                    }
                    catch (Exception ex)
                    {
                        dbTransaction.Rollback();
                        return new ResponseVM("deleted", false, "Office", ResponseVM.SOMETHING_WENT_WRONG, "", ex);
                    }
                }
            }
        }
        public IEnumerable<OfficeVM> GetAll()
        {
            using (context)
            {
                try
                {
                    var offices = context.Offices.ToList().OrderByDescending(x => x.Officeid);
                    var officesVm = offices.Select(x => toViewModel.Office(x));
                    return officesVm;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public OfficeVM GetSingleBy(Guid id)
        {
            using (context)
            {
                try
                {
                    var offices = context.Offices.Find(id);
                    OfficeVM officeVM = null;
                    if (offices != null)
                        officeVM = toViewModel.Office(offices);
                    return officeVM;
                }
                catch (Exception)
                {
                    throw;
                }

            }
        }
        public ResponseVM Update(OfficeVM officeVM)
        {
            using (context)
            {
                if (context.Offices.Where(x => x.OfficeCode == officeVM.OfficeCode && x.OfficeDesc == officeVM.OfficeDesc).Any())
                {
                    return new ResponseVM("updated", false, "Office", ResponseVM.NO_NEW_DATA);
                }
                using (var dbTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Office officeToBeUpdated = context.Offices.Find(officeVM.Officeid);
                        if (officeToBeUpdated == null)
                            return new ResponseVM("updated", false, "Office", ResponseVM.DOES_NOT_EXIST);

                        officeToBeUpdated.OfficeCode = officeVM.OfficeCode;
                        officeToBeUpdated.OfficeDesc = officeVM.OfficeDesc;
                        context.SaveChanges();

                        dbTransaction.Commit();
                        return new ResponseVM("updated", true, "Office");
                    }
                    catch (Exception ex)
                    {
                        dbTransaction.Rollback();
                        return new ResponseVM("updated", false, "Office", ResponseVM.SOMETHING_WENT_WRONG, "", ex);
                    }
                }
            }
        }

        public DatatableVM.PagingResponse<OfficeVM> GetDataServerSide(DatatableVM.PagingRequest paging)
        {
            using (context)
            {

                var pagingResponse = new PagingResponse<OfficeVM>()
                {
                    // counts how many times the user draws data
                    Draw = paging.Draw
                };
                // initialized query
                IEnumerable<Office> query = null;
                // search if user provided a search value, i.e. search value is not empty
                if (!string.IsNullOrEmpty(paging.Search.Value))
                {
                    // search based from the search value
                    query = context.Offices
                          .Where(v => v.OfficeCode.ToString().ToLower().Contains(paging.Search.Value.ToLower()));
                }
                else
                {
                    // selects all from table
                    query = context.Offices;
                }
                // total records from query
                var recordsTotal = query.Count();
                // orders the data by the sorting selected by the user
                // used ternary operator to determine if ascending or descending
                var colOrder = paging.Order[0];
                switch (colOrder.Column)
                {
                    case 0:
                        query = colOrder.Dir == "asc" ? query.OrderBy(v => v.OfficeCode) : query.OrderByDescending(v => v.OfficeCode);
                        break;

                }

                var taken = query.Skip(paging.Start).Take(paging.Length).ToArray();
                // converts model(query) into viewmodel then assigns it to response which is displayed as "data"
                pagingResponse.Reponse = taken.Select(x => toViewModel.Office(x));
                pagingResponse.RecordsTotal = recordsTotal;
                pagingResponse.RecordsFiltered = recordsTotal;

                return pagingResponse;
            }
        }
    }
    
}

