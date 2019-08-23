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
                //check if record already exists
                if (context.Offices.Where(b => b.OfficeCode.ToLower() == officeVM.OfficeCode.ToLower()).Any())
=======
                if (context.Offices.Where(x => x.OfficeCode == officeVM.OfficeCode || x.OfficeDesc == officeVM.OfficeDesc).Any())
>>>>>>> 2fb85b2afa0a42a16fcb96d7ab04b103ede54f15
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
                if (context.Employees.Where(b => b.Officeid == id).Any())
                {
                    return new ResponseVM("deleted", false, "Office", "Can't delete record. It is used in a transaction");
=======
                if (context.Employees.Where(x => x.Officeid == id).Any())
                {
                    return new ResponseVM("deleted", false, "Office", ResponseVM.DONT_DELETE);
>>>>>>> 2fb85b2afa0a42a16fcb96d7ab04b103ede54f15
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
<<<<<<< HEAD
                //check if record already exists
                if (context.Offices.Where(b => b.OfficeCode.ToLower() == officeVM.OfficeCode.ToLower()).Any())
                {
                    return new ResponseVM("created", false, "Office", ResponseVM.ALREADY_EXIST);
=======
                if (context.Offices.Where(x => x.OfficeCode == officeVM.OfficeCode && x.OfficeDesc == officeVM.OfficeDesc).Any())
                {
                    return new ResponseVM("updated", false, "Office", ResponseVM.NO_NEW_DATA);
>>>>>>> 2fb85b2afa0a42a16fcb96d7ab04b103ede54f15
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
    }
}

