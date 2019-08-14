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

        
        public CategoryVM Category(Category category)
        {
            return new CategoryVM
            {
                categoryid = category.categoryid,
                CategoryName = category.CategoryName
            };
        }

        public SeverityVM Severity(Severity severity)
        {

            return new SeverityVM
            {

                severityid = severity.severityid,
                SeverityCode = severity.SeverityCode,
                SeverityName = severity.SeverityName,
                SeverityDesc = severity.SeverityDesc
            };
         }

        public EmployeeVM Employee(Employee employee)

        {
            return new EmployeeVM
            {

                EmployeeID = employee.EmployeeID,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                EmailAddress = employee.EmailAddress,
                Officeid = employee.Officeid.ToString(),
                Office = Office(employee.Office)

            };
        }

        public TicketVM Ticket(Ticket ticket)
        {
            return new TicketVM
            {
                Ticketid = ticket.Ticketid,
                DateOfRequest = ticket.DateOfRequest,
                FormOfCommu = ticket.FormOfCommu,
                ContactInfo = ticket.ContactInfo,
                RequestTitle = ticket.RequestTitle,
                RequestDesc = ticket.RequestDesc,
                TrackingSatus = ticket.TrackingSatus,
                ResponseTime = ticket.ResponseTime,
                ResolveTime = ticket.ResolveTime,
                IsUrgent = ticket.IsUrgent,
                IsOpen = ticket.IsOpen,
                
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
    }
}
