using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TicketingSystem.BLL.Helpers;
using TicketingSystem.DAL.Models;
using TicketingSystem.ViewModel.ViewModel;
using TicketingSystem.ViewModel.ViewModels;

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
                //check if employee exists in ticket
                if (context.Tickets.Where(b => b.EmployeeID == id).Any())
                {
                    return new ResponseVM("deleted", false, "Employee", "Can't delete record. It is used in a transaction");
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
                    catch (Exception ex)
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
    }
}
