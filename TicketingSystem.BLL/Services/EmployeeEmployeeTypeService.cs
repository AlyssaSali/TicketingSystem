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
    public class EmployeeEmployeeTypeService:IGenericService<EmployeeEmployeeTypeVM>
    {
        private ToViewModel toViewModel = new ToViewModel();
        private ToModel toModel = new ToModel();
        private object employeeEmployeeTypeSaved;
        private readonly TicketingSystemContext context;


        public EmployeeEmployeeTypeService(TicketingSystemContext _context)
        {
            context = _context;
        }

        public ResponseVM Create(EmployeeEmployeeTypeVM employeeEmployeeTypeVM)
        {
            using (context)
            {
                using (var dbTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        employeeEmployeeTypeVM.EmployeeEmployeeTypeid = Guid.NewGuid().ToString();
                        var employeeEmployeeTypeSaved = context.EmployeeEmployeeTypes.Add(toModel.EmployeeEmployeeType(employeeEmployeeTypeVM)).Entity;
                        context.SaveChanges();

                        foreach (var empID in employeeEmployeeTypeVM.EmployeeIdList)
                        {

                            var employee = context.Employees.Find(empID);
                            if (employee == null)
                                return new ResponseVM("create", false, "EmployeeEmployeeType", "Employee does not exists");
                            var typeEmployee = new TypeEmployee
                            {
                                EmployeeID = empID,
                                EmployeeEmployeeTypeid = employeeEmployeeTypeSaved.EmployeeEmployeeTypeid,
                                EmployeeFullName = toViewModel.ToFullName(employee.FirstName, employee.LastName)
                            };

                            context.TypeEmployees.Add(typeEmployee);
                            context.SaveChanges();
                        }


                        dbTransaction.Commit();
                        return new ResponseVM
                            ("create", true, "EmployeeEmployeeType");

                    }
                    catch (Exception ex)
                    {
                        dbTransaction.Rollback();
                        return new ResponseVM("create", false, "EmployeeEmployeeType", ResponseVM.SOMETHING_WENT_WRONG, "", ex);
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
                        EmployeeEmployeeType employeeEmployeeTypeTobeDeleted = context.EmployeeEmployeeTypes.Find(id);
                        if (employeeEmployeeTypeTobeDeleted == null)
                            return new ResponseVM("deleted", false, "EmployeeEmployeeType", ResponseVM.DOES_NOT_EXIST);
                        //delete

                        var removeFromTypeEmployees = context.TypeEmployees.Where(x => x.EmployeeEmployeeTypeid == employeeEmployeeTypeTobeDeleted.EmployeeEmployeeTypeid);
                        context.TypeEmployees.RemoveRange(removeFromTypeEmployees);
                        context.SaveChanges();

                        context.EmployeeEmployeeTypes.Remove(employeeEmployeeTypeTobeDeleted);
                        context.SaveChanges();

                        dbTransaction.Commit();
                        return new ResponseVM
                            ("deleted", true, "EmployeeEmployeeType");
                    }
                    catch (Exception ex)
                    {
                        dbTransaction.Rollback();
                        return new ResponseVM
                            ("deleted", false, "EmployeeEmployeeType", ResponseVM.SOMETHING_WENT_WRONG, "", ex);
                    }
                }
            }
        }
        public IEnumerable<EmployeeEmployeeTypeVM> GetAll()
        {
            using (context)
            {
                try
                {
                    var employeeEmployeeTypes = context.EmployeeEmployeeTypes
                        .Include(x => x.EmployeeType)
                        .Include(x => x.TypeEmployees)
                            .ThenInclude(x => x.Employee)
                        .ToList()
                        .OrderByDescending(x => x.EmployeeEmployeeTypeid);
                    var employeeEmployeeTypesVM = employeeEmployeeTypes.Select(x => toViewModel.EmployeeEmployeeType(x));
                    return employeeEmployeeTypesVM;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public EmployeeEmployeeTypeVM GetSingleBy(Guid id)
        {
            using (context)
            {
                try
                {

                    var employeeEmployeeType = context.EmployeeEmployeeTypes
                        .Include(x => x.EmployeeType)
                        .Where(x => x.EmployeeEmployeeTypeid == id)
                        .FirstOrDefault();
                    EmployeeEmployeeTypeVM employeeEmployeeTypeVM = null;
                    if (employeeEmployeeType != null)
                        employeeEmployeeTypeVM = toViewModel.EmployeeEmployeeType(employeeEmployeeType);
                    return employeeEmployeeTypeVM;

                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public ResponseVM Update(EmployeeEmployeeTypeVM employeeEmployeeTypeVM)
        {
            using (context)
            {
                using (var dbTransaction = context.Database.BeginTransaction())
                {
                    try
                    {

                        EmployeeEmployeeType employeeEmployeeTypeTobeUpdated = context.EmployeeEmployeeTypes.Where(x => x.EmployeeEmployeeTypeid == Guid.Parse(employeeEmployeeTypeVM.EmployeeEmployeeTypeid)).FirstOrDefault();
                       

                        if (employeeEmployeeTypeTobeUpdated == null)
                            return new ResponseVM("update", false, "EmployeeEmployeeType", ResponseVM.DOES_NOT_EXIST);

                        employeeEmployeeTypeTobeUpdated.EmployeeTypeid = Guid.Parse(employeeEmployeeTypeVM.EmployeeTypeid);
                        context.SaveChanges();

                        var removeFromTypeEmployees = context.TypeEmployees.Where(x => x.EmployeeEmployeeTypeid == employeeEmployeeTypeTobeUpdated.EmployeeEmployeeTypeid);
                        context.TypeEmployees.RemoveRange(removeFromTypeEmployees);
                        context.SaveChanges();


                        foreach (var empID in employeeEmployeeTypeVM.EmployeeIdList)
                        {
                            var employee = context.Employees.Find(empID);
                            if (employee == null)
                                return new ResponseVM("create", false, "EmployeeEmployeeType", "Employee does not exists");
                            var typeEmployee = new TypeEmployee
                            {
                                EmployeeID = empID,
                                EmployeeEmployeeTypeid = employeeEmployeeTypeTobeUpdated.EmployeeEmployeeTypeid,
                                EmployeeFullName = toViewModel.ToFullName(employee.FirstName, employee.LastName)
                            };

                            context.TypeEmployees.Add(typeEmployee);
                            context.SaveChanges();
                        }

                        dbTransaction.Commit();
                        return new ResponseVM("updated", true, "EmployeeEmployeeType");
                    }
                    catch (Exception ex)
                    {
                        dbTransaction.Rollback();
                        return new ResponseVM
                            ("updated", false, "EmployeeEmployeeType", ResponseVM.SOMETHING_WENT_WRONG, "", ex);

                        throw;
                    }

                }
            }
        }

        public PagingResponse<EmployeeEmployeeTypeVM> GetDataServerSide(PagingRequest paging)
        {
            using (context)
            {
                var pagingResponse = new PagingResponse<EmployeeEmployeeTypeVM>()
                {
                    // counts how many times the user draws data
                    Draw = paging.Draw
                };
                // initialized query
                IEnumerable<EmployeeEmployeeType> query = null;
                // search if user provided a search value, i.e. search value is not empty
                if (!string.IsNullOrEmpty(paging.Search.Value))
                {
                    // search based from the search value     
                    query = context.EmployeeEmployeeTypes.Include(x => x.EmployeeType)
                                         .Include(x => x.TypeEmployees)
                                         .ThenInclude(x => x.Employee)
                                         .Where(v =>
                                                     v.EmployeeType.EmployeeTypeName.ToString().ToLower().Contains(paging.Search.Value.ToLower()) ||
                                                     v.TypeEmployees.Any(x => x.EmployeeFullName.ToLower().Contains(paging.Search.Value.ToLower())));
                }
                else
                {
                    // selects all from table
                    query = context.EmployeeEmployeeTypes
                                        .Include(x => x.EmployeeType)
                                        .Include(x => x.TypeEmployees)
                                        .ThenInclude(x => x.Employee);
                }
                // total records from query
                var recordsTotal = query.Count();
                // orders the data by the sorting selected by the user
                // used ternary operator to determine if ascending or descending
                var colOrder = paging.Order[0];
                switch (colOrder.Column)
                {
                    case 0:
                        query = colOrder.Dir == "asc" ? query.OrderBy(b => b.EmployeeType.EmployeeTypeName) : query.OrderByDescending(b => b.EmployeeType.EmployeeTypeName);
                        break;

                }
                var taken = query.Skip(paging.Start).Take(paging.Length).ToArray();
                // converts model(query) into viewmodel then assigns it to response which is displayed as "data"
                pagingResponse.Reponse = taken.Select(x => toViewModel.EmployeeEmployeeType(x));
                pagingResponse.RecordsTotal = recordsTotal;
                pagingResponse.RecordsFiltered = recordsTotal;

                return pagingResponse;
            }
        }
    }
}
