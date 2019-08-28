using System;
using System.Collections.Generic;
using System.Text;
using TicketingSystem.DAL.Models;
using TicketingSystem.ViewModel.ViewModels;

namespace TicketingSystem.BLL.Helpers
{
    public class ToModel
    {
<<<<<<< HEAD
=======

>>>>>>> 00d9a0867d956b23e7a3c0e36fce9ae308d939f7
        public Office Office(OfficeVM officeVM)
        {
            return new Office
            {
                Officeid = officeVM.Officeid,
                OfficeCode = officeVM.OfficeCode,
                OfficeDesc = officeVM.OfficeDesc,
            };
        }
<<<<<<< HEAD
=======

>>>>>>> 00d9a0867d956b23e7a3c0e36fce9ae308d939f7

        public Category Category(CategoryVM categoryVM)
        {
            return new Category
            {
                Categoryid = categoryVM.Categoryid,
                CategoryName = categoryVM.CategoryName,
                DateCreated = categoryVM.DateCreated
            };
        }

        public Severity Severity(SeverityVM severityVM)
        {
            return new Severity
            {
<<<<<<< HEAD
=======

>>>>>>> 00d9a0867d956b23e7a3c0e36fce9ae308d939f7
                Severityid = severityVM.Severityid,
                SeverityName = severityVM.SeverityName,
                SeverityCode = severityVM.SeverityCode,
                SeverityDesc = severityVM.SeverityDesc
            };
        }

        public Employee Employee(EmployeeVM employeeVM)
        { 
            return new Employee
            { 
                EmployeeID = employeeVM.EmployeeID,                
                FirstName = employeeVM.FirstName,
                LastName = employeeVM.LastName,
                FormOfCommu = employeeVM.FormOfCommu,
                ContactInfo = employeeVM.ContactInfo,
                EmployeeTypeid = employeeVM.EmployeeTypeid,
<<<<<<< HEAD
                Officeid = Guid.Parse(employeeVM.Officeid)  
=======
=======

        { 
            return new Employee
<<<<<<< HEAD
            { 
=======
            {

>>>>>>> 63171424717892a87f2f85c43afeee8014c441ad
=======

        public Employee Employee(EmployeeVM employeeVM)
        {
            return new Employee { 
>>>>>>> 2fb85b2afa0a42a16fcb96d7ab04b103ede54f15
>>>>>>> 89bb63c04e1ad5424f19b0fd116240805a791ee4
                EmployeeID = employeeVM.EmployeeID,                
                FirstName = employeeVM.FirstName,
                LastName = employeeVM.LastName,
                FormOfCommu = employeeVM.FormOfCommu,
                ContactInfo = employeeVM.ContactInfo,
                //EmployeeTypeid = employeeVM.EmployeeTypeid,
                EmailAddress = employeeVM.EmailAddress,
>>>>>>> 2fb85b2afa0a42a16fcb96d7ab04b103ede54f15
                Officeid = Guid.Parse(employeeVM.Officeid)
                
>>>>>>> 00d9a0867d956b23e7a3c0e36fce9ae308d939f7
            };
        }

        public Ticket Ticket(TicketVM ticketVM)
        {
            return new Ticket
            {
                Ticketid = ticketVM.Ticketid,
                CategoryListid = ticketVM.CategoryListid,
                ITGroupid = ticketVM.ITGroupid,
                EmployeeID = ticketVM.EmployeeID,
                Officeid = ticketVM.Officeid,
                DateOfRequest = ticketVM.DateOfRequest,
                FormOfCommu = ticketVM.FormOfCommu,
                ContactInfo = ticketVM.ContactInfo,
                RequestTitle = ticketVM.RequestTitle,
                RequestDesc = ticketVM.RequestDesc,
                Category = ticketVM.Category,
                Severity = ticketVM.Severity,
                TrackingStatus = ticketVM.TrackingStatus,
                ResponseTime = ticketVM.ResponseTime,
                ResolveTime = ticketVM.ResolveTime,
                IsUrgent = ticketVM.IsUrgent,
                IsOpen = ticketVM.IsOpen
<<<<<<< HEAD
=======
=======
<<<<<<< HEAD
                IsOpen = ticketVM.IsOpen
=======
                IsOpen = ticketVM.IsOpen,
<<<<<<< HEAD
=======
<<<<<<< HEAD
                
=======
>>>>>>> 63171424717892a87f2f85c43afeee8014c441ad
>>>>>>> 2fb85b2afa0a42a16fcb96d7ab04b103ede54f15
>>>>>>> 89bb63c04e1ad5424f19b0fd116240805a791ee4
>>>>>>> 00d9a0867d956b23e7a3c0e36fce9ae308d939f7
            };
        }

        public ITGroup ITGroup(ITGroupVM itgroupVM)
        {
            return new ITGroup
            {
                ITGroupid = itgroupVM.ITGroupid,
                ITGroupCode = itgroupVM.ITGroupCode,
                ITGroupName = itgroupVM.ITGroupName
<<<<<<< HEAD
=======
<<<<<<< HEAD

=======
>>>>>>> 2fb85b2afa0a42a16fcb96d7ab04b103ede54f15
>>>>>>> 89bb63c04e1ad5424f19b0fd116240805a791ee4
>>>>>>> 00d9a0867d956b23e7a3c0e36fce9ae308d939f7
            };
        }

        public CategoryList CategoryList(CategoryListVM categorylistVM)
        {
            return new CategoryList
            {
                CategoryListid = categorylistVM.CategoryListid,
                CategoryListName = categorylistVM.CategoryListName,
                CategoryType = categorylistVM.CategoryType,
                SlaResponseTime = categorylistVM.SlaResponseTime,
                SlaResponseTimeExt = categorylistVM.SlaResponseTimeExt,
                SlaResolvedTime = categorylistVM.SlaResolvedTime,
                SlaResolvedTimeExt = categorylistVM.SlaResolvedTimeExt,
                ITGroupid = Guid.Parse(categorylistVM.ITGroupid),
                Categoryid = Guid.Parse(categorylistVM.Categoryid),
                Severityid = Guid.Parse(categorylistVM.Severityid)
            };
        }

        public TicketMinor TicketMinor(TicketMinorVM ticketMinorVM)
        {
            return new TicketMinor
            {
                TicketMinorid = ticketMinorVM.TicketMinorid,
                Description = ticketMinorVM.Description,
                DateOfRequest = ticketMinorVM.DateOfRequest,
                TimeOfRequest = ticketMinorVM.TimeOfRequest,
                Status = ticketMinorVM.Status,
                WorkDone = ticketMinorVM.WorkDone,
                DateAccomplished = ticketMinorVM.DateAccomplished,
                Officeid = Guid.Parse(ticketMinorVM.Officeid),
                Requesterid = Guid.Parse(ticketMinorVM.Requesterid),
                WorkByid = Guid.Parse(ticketMinorVM.WorkByid),
                CategoryListid = Guid.Parse(ticketMinorVM.CategoryListid)
            };
        }
<<<<<<< HEAD
=======
<<<<<<< HEAD
=======
<<<<<<< HEAD
>>>>>>> 89bb63c04e1ad5424f19b0fd116240805a791ee4
>>>>>>> 00d9a0867d956b23e7a3c0e36fce9ae308d939f7

        public EmployeeType EmployeeType(EmployeeTypeVM employeetypeVM)
        {
            return new EmployeeType
            {
                EmployeeTypeid = employeetypeVM.EmployeeTypeid,
                EmployeeTypeName = employeetypeVM.EmployeeTypeName
<<<<<<< HEAD
            };
        }

=======
<<<<<<< HEAD
            };
         }

=======
=======
>>>>>>> 89bb63c04e1ad5424f19b0fd116240805a791ee4
>>>>>>> 00d9a0867d956b23e7a3c0e36fce9ae308d939f7
        public ITGroupMember ITGroupMember(ITGroupMemberVM itgroupmemberVM)
        {
            return new ITGroupMember
            {
                ITGroupMemberid = Guid.Parse( itgroupmemberVM.ITGroupMemberid),
                ITGroupid = Guid.Parse(itgroupmemberVM.ITGroupid)
            };
        }
        public EmployeeEmployeeType EmployeeEmployeeType(EmployeeEmployeeTypeVM employeeEmployeeTypeVM)
        {
            return new EmployeeEmployeeType
            {
                EmployeeEmployeeTypeid = Guid.Parse(employeeEmployeeTypeVM.EmployeeEmployeeTypeid),

                EmployeeTypeid = Guid.Parse(employeeEmployeeTypeVM.EmployeeTypeid)
            };
        }
    }
}

