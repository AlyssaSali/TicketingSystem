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
<<<<<<< HEAD
                if (context.Offices.Where(x => x.OfficeCode == officeVM.OfficeCode || x.OfficeDesc == officeVM.OfficeDesc).Any())
=======
<<<<<<< HEAD
                if (context.Offices.Where(x => x.OfficeCode == officeVM.OfficeCode || x.OfficeDesc == officeVM.OfficeDesc).Any())
=======
<<<<<<< HEAD


                if (context.Offices.Where(x => x.OfficeCode == officeVM.OfficeCode || x.OfficeDesc == officeVM.OfficeDesc).Any())

=======
<<<<<<< HEAD
                //check if record already exists
                if (context.Offices.Where(b => b.OfficeCode.ToLower() == officeVM.OfficeCode.ToLower()).Any())
=======
                if (context.Offices.Where(x => x.OfficeCode == officeVM.OfficeCode || x.OfficeDesc == officeVM.OfficeDesc).Any())
>>>>>>> 2fb85b2afa0a42a16fcb96d7ab04b103ede54f15
>>>>>>> 89bb63c04e1ad5424f19b0fd116240805a791ee4
>>>>>>> 00d9a0867d956b23e7a3c0e36fce9ae308d939f7
>>>>>>> b91f36f85f748ef16088c8249afe1aa938eb57c2
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
<<<<<<< HEAD
                if (context.Employees.Where(x => x.Officeid == id).Any())
                {
                    return new ResponseVM("deleted", false, "Office", ResponseVM.DONT_DELETE);
=======
<<<<<<< HEAD
                if (context.Employees.Where(x => x.Officeid == id).Any() || context.TicketMinors.Where(x => x.Officeid == id).Any())
                {
                    return new ResponseVM("deleted", false, "Office", ResponseVM.DONT_DELETE);
=======
<<<<<<< HEAD
                if (context.Employees.Where(b => b.Officeid == id).Any())
                {
                    return new ResponseVM("deleted", false, "Office", "Can't delete record. It is used in a transaction");
=======
<<<<<<< HEAD
                if (context.Employees.Where(b => b.Officeid == id).Any())
                {
                    return new ResponseVM("deleted", false, "Office", "Can't delete record. It is used in a transaction");
=======
                if (context.Employees.Where(x => x.Officeid == id).Any())
                {
                    return new ResponseVM("deleted", false, "Office", ResponseVM.DONT_DELETE);
>>>>>>> 2fb85b2afa0a42a16fcb96d7ab04b103ede54f15
>>>>>>> 89bb63c04e1ad5424f19b0fd116240805a791ee4
>>>>>>> 00d9a0867d956b23e7a3c0e36fce9ae308d939f7
>>>>>>> b91f36f85f748ef16088c8249afe1aa938eb57c2
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
<<<<<<< HEAD
                    return new ResponseVM("updated", false, "Office", ResponseVM.ALREADY_EXIST);
=======
                    return new ResponseVM("updated", false, "Office", ResponseVM.NO_NEW_DATA);
<<<<<<< HEAD
=======
<<<<<<< HEAD
=======
>>>>>>> 2fb85b2afa0a42a16fcb96d7ab04b103ede54f15
>>>>>>> 89bb63c04e1ad5424f19b0fd116240805a791ee4
>>>>>>> 00d9a0867d956b23e7a3c0e36fce9ae308d939f7
>>>>>>> b91f36f85f748ef16088c8249afe1aa938eb57c2
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

