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

                Categoryid = category.Categoryid,
                CategoryName = category.CategoryName,
                DateCreated = category.DateCreated
            };
        }

        public SeverityVM Severity(Severity severity)
        {
            return new SeverityVM
            {
                Severityid = severity.Severityid,
                SeverityCode = severity.SeverityCode,
                SeverityName = severity.SeverityName,
                SeverityDesc = severity.SeverityDesc,
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
                Office = Office(employee.Office),
                FullName = ToFullName(employee.FirstName, employee.LastName)
            };
        }

        public string ToFullName(string firstName, string lastName)
        {
            return $"{firstName} { (string.IsNullOrEmpty(lastName) ? "" : " " + lastName)} ";
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
                CategoryType = categoryList.CategoryType,
                SlaResponseTime = categoryList.SlaResponseTime,
                SlaResponseTimeExt = categoryList.SlaResponseTimeExt,
                SlaResolvedTime = categoryList.SlaResolvedTime,
                SlaResolvedTimeExt = categoryList.SlaResolvedTimeExt,
                ITGroupid = (categoryList.ITGroupid).ToString(),
                ITGroup = categoryList.ITGroup != null ? ITGroup(categoryList.ITGroup):null,
                Categoryid = (categoryList.Categoryid).ToString(),
                Category = categoryList.Category != null ? Category(categoryList.Category):null,
                Severityid = (categoryList.Severityid).ToString(),
                Severity = categoryList.Severity != null ? Severity(categoryList.Severity):null
            };
        }

        public TicketMinorVM TicketMinor(TicketMinor ticketMinor)
        {
            return new TicketMinorVM
            {
                TicketMinorid = ticketMinor.TicketMinorid,
                Description = ticketMinor.Description,
                DateOfRequest = ticketMinor.DateOfRequest,
                TimeOfRequest = ticketMinor.TimeOfRequest,
                Status = ticketMinor.Status,
                WorkDone = ticketMinor.WorkDone,
                Officeid = (ticketMinor.Officeid).ToString(),
                Office = Office(ticketMinor.Office),
                Requesterid = (ticketMinor.Requesterid).ToString(),
                WorkByid = (ticketMinor.WorkByid).ToString(),
                Employee = Employee(ticketMinor.Employee),
                CategoryListid = (ticketMinor.CategoryListid).ToString(),
                CategoryList = CategoryList(ticketMinor.CategoryList)
            };
        }
    }
}
