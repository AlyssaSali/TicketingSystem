using System;
using System.Collections.Generic;
using System.Text;
using TicketingSystem.DAL.Models;
using TicketingSystem.ViewModel.ViewModels;

namespace TicketingSystem.BLL.Helpers
{
    public class ToViewModel
    {
<<<<<<< HEAD
=======
<<<<<<< HEAD
=======

>>>>>>> 672730fec7a9527c892fc88cfb34fa9e84777be3
>>>>>>> af8a36911860fc01eb54fa1355606495cc985b86
        public OfficeVM Office(Office office)
        {
            return new OfficeVM
            {
                Officeid = office.Officeid,
                OfficeCode = office.OfficeCode,
                OfficeDesc = office.OfficeDesc,
            };
<<<<<<< HEAD
        }

=======
<<<<<<< HEAD
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
=======

        }
>>>>>>> af8a36911860fc01eb54fa1355606495cc985b86
        public EmployeeVM Employee(Employee employee)
>>>>>>> 672730fec7a9527c892fc88cfb34fa9e84777be3
        {
            return new SeverityVM
            {
<<<<<<< HEAD
                severityid = severity.severityid,
                SeverityCode = severity.SeverityCode,
                SeverityName = severity.SeverityName,
                SeverityDesc = severity.SeverityDesc,
=======
                EmployeeID = employee.EmployeeID,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                EmailAddress = employee.EmailAddress,
<<<<<<< HEAD
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
                IsOpen = ticket.IsOpen
=======
                Office = employee.Office
>>>>>>> 672730fec7a9527c892fc88cfb34fa9e84777be3
>>>>>>> af8a36911860fc01eb54fa1355606495cc985b86
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

<<<<<<< HEAD
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

=======
>>>>>>> 672730fec7a9527c892fc88cfb34fa9e84777be3
    }
}
