using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TicketingSystem.BLL.Helpers;
using TicketingSystem.DAL.Models;
using TicketingSystem.ViewModel.ViewModel;
using TicketingSystem.ViewModel.ViewModels;
using static TicketingSystem.ViewModel.ViewModels.DatatableVM;

namespace TicketingSystem.BLL.Contracts
{
    public class EmployeeService : IGenericService<EmployeeVM>
    {
        private ToViewModel toViewModel = new ToViewModel();
        private ToModel toModel = new ToModel();
        private readonly TicketingSystemContext context;

        //inject dependencies
        public EmployeeService(TicketingSystemContext _context) {
            context = _context;
        }

        public ResponseVM Create(EmployeeVM employeeVM) {
            using (context)
            {
                //check if record already exists
                if (context.Employees.Where(b => b.FirstName.ToLower() == employeeVM.FirstName.ToLower()).Any() &&
                    context.Employees.Where(b => b.LastName.ToLower() == employeeVM.LastName.ToLower()).Any())
                {
                    return new ResponseVM("created", false, "Employee", ResponseVM.ALREADY_EXIST);
                }
                using (var dbTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        employeeVM.EmployeeID = Guid.NewGuid();
                        //converts to book type then save to context
                        context.Employees.Add(toModel.Employee(employeeVM));
                        context.SaveChanges();

                        //commits changes to db
                        dbTransaction.Commit();
                        return new ResponseVM("created", true, "Employee");
                    }
                    catch (Exception ex)
                    {

                        dbTransaction.Rollback();
                        return new ResponseVM("created", false, "Employee", ResponseVM.SOMETHING_WENT_WRONG, "", ex);
                    }
                }
            }
        }
        public ResponseVM Update(EmployeeVM employeeVM) {
            using (context)
            {
                using (var dbTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        //find employee from the database
                        Employee employeeToBeUpdated = context.Employees.Find(employeeVM.EmployeeID);
                        //ends function if employee does not exists
                        if (employeeToBeUpdated == null)
                        {
                            return new ResponseVM("updated", false, "Employee", ResponseVM.DOES_NOT_EXIST);
                        }

                        //update changes then save to context
                        employeeToBeUpdated.EmployeeID = employeeVM.EmployeeID;
                        employeeToBeUpdated.FirstName = employeeVM.FirstName;
                        employeeToBeUpdated.LastName = employeeVM.LastName;
                        employeeToBeUpdated.FormOfCommu = employeeVM.FormOfCommu;
                        employeeToBeUpdated.ContactInfo = employeeVM.ContactInfo;
                        employeeToBeUpdated.EmployeeTypeid = employeeVM.EmployeeTypeid;
                        employeeToBeUpdated.Officeid = Guid.Parse(employeeVM.Officeid);
                        context.SaveChanges();

                        //commit changes to db
                        dbTransaction.Commit();
                        return new ResponseVM("updated", true, "Employee");
                    }
                    catch (Exception ex)
                    {
                        dbTransaction.Rollback();
                        return new ResponseVM("updated", false, "Employee", ResponseVM.SOMETHING_WENT_WRONG, "", ex);
                    }
                }
            }
        }
        public ResponseVM Delete(Guid id)
        {
            using (context)
            {
                if (context.TicketMinors.Where(b => b.Requesterid == id || b.WorkByid == id).Any())
                {
                    return new ResponseVM("deleted", false, "Employee", ResponseVM.DONT_DELETE);
                }
                using (var dbTransaction = context.Database.BeginTransaction())
                {
                    
                    try
                    {
                        Employee employeeToBeDeleted = context.Employees.Find(id);
                        //ends function if employee does not exists
                        if (employeeToBeDeleted == null)
                        {
                            return new ResponseVM("deleted", false, "Employee", ResponseVM.DOES_NOT_EXIST);
                        }
                        //delete employee then save to context
                        context.Employees.Remove(employeeToBeDeleted);
                        context.SaveChanges();

                        //commit changes to db
                        dbTransaction.Commit();
                        return new ResponseVM("deleted", true, "Employee");
                    }
                    catch (Exception ex)
                    {
                        dbTransaction.Rollback();
                        return new ResponseVM("deleted", false, "Employee", ResponseVM.SOMETHING_WENT_WRONG, "", ex);
                        
                    }
                }
            }
        }
        public IEnumerable<EmployeeVM> GetAll() {
            using (context)
            {
                using (var dbTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        //gets all employees and order the from last to first
                        var employees = context.Employees
                            .Include(x => x.Office)
                            .Include(x => x.EmployeeType)
                            .ToList()
                            .OrderByDescending(x => x.EmployeeID);
                        var employeesVm = employees.Select(x=>toViewModel.Employee(x));
                        return employeesVm;
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
        }
        public EmployeeVM GetSingleBy(Guid id)
        {
            using (context)
            {
                using (var dbTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var employee = context.Employees
                            .Include(x=>x.Office)
                            .Include(x => x.EmployeeType)
                            .Where(x => x.EmployeeID == id)
                            .FirstOrDefault();
                        EmployeeVM employeeVm = null;
                        if (employee != null)
                        {
                            employeeVm = toViewModel.Employee(employee);
                        }
                        return employeeVm;
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
            }
        }

        public DatatableVM.PagingResponse<EmployeeVM> GetDataServerSide(DatatableVM.PagingRequest paging)
        {
            using (context)
            {

                var pagingResponse = new PagingResponse<EmployeeVM>()
                {
                    // counts how many times the user draws data
                    Draw = paging.Draw
                };
                // initialized query
                IEnumerable<Employee> query = null;
                // search if user provided a search value, i.e. search value is not empty
                if (!string.IsNullOrEmpty(paging.Search.Value))
                {
                    // search based from the search value
                    query = context.Employees.Include(x => x.Office)
                          .Where(v => v.Office.ToString().ToLower().Contains(paging.Search.Value.ToLower()) || v.FirstName.ToString().ToLower().Contains(paging.Search.Value.ToLower()) ||
                    v.LastName.ToString().ToLower().Contains(paging.Search.Value.ToLower()));
                }
                else
                {
                    // selects all from table
                    query = context.Employees;
                }
                // total records from query
                var recordsTotal = query.Count();
                // orders the data by the sorting selected by the user
                // used ternary operator to determine if ascending or descending
                var colOrder = paging.Order[0];
                switch (colOrder.Column)
                {
                    case 0:
                        query = colOrder.Dir == "asc" ? query.OrderBy(v => v.EmployeeID) : query.OrderByDescending(v => v.EmployeeID);
                        break;

                }

                var taken = query.Skip(paging.Start).Take(paging.Length).ToArray();
                // converts model(query) into viewmodel then assigns it to response which is displayed as "data"
                pagingResponse.Reponse = taken.Select(x => toViewModel.Employee(x));
                pagingResponse.RecordsTotal = recordsTotal;
                pagingResponse.RecordsFiltered = recordsTotal;

                return pagingResponse;
            }
        }
    }
    
}
