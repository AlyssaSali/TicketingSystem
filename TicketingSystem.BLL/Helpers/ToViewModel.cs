using System;
using System.Collections.Generic;
using System.Text;
using TicketingSystem.DAL.Models;
using TicketingSystem.ViewModel.ViewModels;

namespace TicketingSystem.BLL.Helpers
{
    public class ToViewModel
    {
        public OfficeVM Office(Office office)
        {
            return new OfficeVM
            {
                Officeid = office.Officeid,
                OfficeCode = office.OfficeCode,
                OfficeDesc = office.OfficeDesc,
            };
        }

        public Category Category(CategoryVM categoryVM)
        {
            return new Category
            {
                Categoryid = categoryVM.Categoryid,
                CategoryName = categoryVM.CategoryName,
            };
        }

        public Severity Severity(SeverityVM severityVM)
        {
            return new Severity
            {
                Severityid = severityVM.Severityid,
                SeverityName = severityVM.SeverityName,
                SeverityCode = severityVM.SeverityCode,
                SeverityDesc = severityVM.SeverityDesc
            };
        }
        public EmployeeVM Employee(Employee employee)
        { 
            return new EmployeeVM
            {
                EmployeeID = employee.EmployeeID,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                FormOfCommu = employee.FormOfCommu,
                ContactInfo = employee.ContactInfo,
                EmployeeTypeid = employee.EmployeeTypeid,
                EmployeeType = EmployeeType(employee.EmployeeType),
                Officeid = employee.Officeid.ToString(),
                Office = Office(employee.Office)
            };
        }

        public TicketVM Ticket(Ticket ticket)
        {
            return new TicketVM
            {
                Ticketid = ticket.Ticketid,
                CategoryListid = ticket.CategoryListid,
                CategoryList = CategoryList(ticket.CategoryList),                
                ITGroupid = ticket.ITGroupid,
                ITGroup = ITGroup(ticket.ITGroup),
                EmployeeID = ticket.EmployeeID,
                Employee = Employee(ticket.Employee),
                Officeid = ticket.Officeid,
                Office = Office(ticket.Office),
                DateOfRequest = ticket.DateOfRequest,
                FormOfCommu = ticket.FormOfCommu,
                ContactInfo = ticket.ContactInfo,
                RequestTitle = ticket.RequestTitle,
                RequestDesc = ticket.RequestDesc,
                Severity = ticket.Severity,
                Category = ticket.Category,
                TrackingStatus = ticket.TrackingStatus,
                ResponseTime = ticket.ResponseTime,
                ResolveTime = ticket.ResolveTime,
                IsUrgent = ticket.IsUrgent,
                IsOpen = ticket.IsOpen
            };

         }
        public ITGroupVM ITGroup(ITGroup itgroup)
        {
            return new ITGroupVM
            {
                ITGroupid = itgroup.ITGroupid,
                ITGroupCode = itgroup.ITGroupCode,
                ITGroupName = itgroup.ITGroupName,
            };

        }
        public CategoryListVM CategoryList(CategoryList categoryList)
        {
            return new CategoryListVM
            {
                CategoryListid = categoryList.CategoryListid,
                CategoryListName = categoryList.CategoryListName,
                SlaResponseTime = categoryList.SlaResponseTime,
                SlaResolvedTime = categoryList.SlaResolvedTime,
                ItGroup = categoryList.ItGroup,
                categoryid = categoryList.categoryid,
                Category = Category(categoryList.Category),
                severityid = categoryList.severityid,
                Severity = Severity(categoryList.Severity)
            };
        }

        public EmployeeTypeVM EmployeeType(EmployeeType employeetype)
        {
            return new EmployeeTypeVM
            {
                EmployeeTypeid = employeetype.EmployeeTypeid,
                EmployeeTypeName = employeetype.EmployeeTypeName
            };
        }
    }
}
