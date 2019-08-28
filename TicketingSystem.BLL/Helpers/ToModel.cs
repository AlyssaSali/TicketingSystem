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
<<<<<<< HEAD
=======

>>>>>>> 00d9a0867d956b23e7a3c0e36fce9ae308d939f7
>>>>>>> b91f36f85f748ef16088c8249afe1aa938eb57c2
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
<<<<<<< HEAD
=======

>>>>>>> 00d9a0867d956b23e7a3c0e36fce9ae308d939f7
>>>>>>> b91f36f85f748ef16088c8249afe1aa938eb57c2

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
<<<<<<< HEAD
=======

>>>>>>> 00d9a0867d956b23e7a3c0e36fce9ae308d939f7
>>>>>>> b91f36f85f748ef16088c8249afe1aa938eb57c2
                Severityid = severityVM.Severityid,
                SeverityName = severityVM.SeverityName,
                SeverityCode = severityVM.SeverityCode,
                SeverityDesc = severityVM.SeverityDesc
            };
        }
<<<<<<< HEAD
=======

>>>>>>> b91f36f85f748ef16088c8249afe1aa938eb57c2
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
=======
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
>>>>>>> b91f36f85f748ef16088c8249afe1aa938eb57c2
                Officeid = Guid.Parse(employeeVM.Officeid)
                
>>>>>>> 00d9a0867d956b23e7a3c0e36fce9ae308d939f7
            };
        }

        public Ticket Ticket(TicketVM ticketVM)
        {
            return new Ticket
            {
                Ticketid = ticketVM.Ticketid,
                EmployeeID = ticketVM.EmployeeID,
                Officeid = ticketVM.Officeid,
                DateOfRequest = DateTime.ParseExact(ticketVM.Date + " " + ticketVM.Time + ":00", "yyyy-MM-dd HH:mm:ss", null),
                RequestTitle = ticketVM.RequestTitle,
                RequestDesc = ticketVM.RequestDesc,
                RequestedBy = ticketVM.RequestedBy,
                TrackingStatus = ticketVM.TrackingStatus,
<<<<<<< HEAD
                IsOpen = ticketVM.IsOpen
=======
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
>>>>>>> b91f36f85f748ef16088c8249afe1aa938eb57c2
            };
        }

        public ITGroup ITGroup(ITGroupVM itgroupVM)
        {
            return new ITGroup
            {
                ITGroupid = itgroupVM.ITGroupid,
                ITGroupCode = itgroupVM.ITGroupCode,
<<<<<<< HEAD
                ITGroupName = itgroupVM.ITGroupName,
=======
                ITGroupName = itgroupVM.ITGroupName
<<<<<<< HEAD
=======
<<<<<<< HEAD

=======
>>>>>>> 2fb85b2afa0a42a16fcb96d7ab04b103ede54f15
>>>>>>> 89bb63c04e1ad5424f19b0fd116240805a791ee4
>>>>>>> 00d9a0867d956b23e7a3c0e36fce9ae308d939f7
>>>>>>> b91f36f85f748ef16088c8249afe1aa938eb57c2
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
=======
<<<<<<< HEAD
>>>>>>> 89bb63c04e1ad5424f19b0fd116240805a791ee4
>>>>>>> 00d9a0867d956b23e7a3c0e36fce9ae308d939f7
>>>>>>> b91f36f85f748ef16088c8249afe1aa938eb57c2

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
<<<<<<< HEAD
            };
         }

=======
=======
>>>>>>> 89bb63c04e1ad5424f19b0fd116240805a791ee4
>>>>>>> 00d9a0867d956b23e7a3c0e36fce9ae308d939f7
>>>>>>> b91f36f85f748ef16088c8249afe1aa938eb57c2
        public ITGroupMember ITGroupMember(ITGroupMemberVM itgroupmemberVM)
        {
            return new ITGroupMember
            {
                ITGroupMemberid = Guid.Parse( itgroupmemberVM.ITGroupMemberid),
                ITGroupid = Guid.Parse(itgroupmemberVM.ITGroupid)
<<<<<<< HEAD
=======
            };
        }
        public EmployeeEmployeeType EmployeeEmployeeType(EmployeeEmployeeTypeVM employeeEmployeeTypeVM)
        {
            return new EmployeeEmployeeType
            {
                EmployeeEmployeeTypeid = Guid.Parse(employeeEmployeeTypeVM.EmployeeEmployeeTypeid),

                EmployeeTypeid = Guid.Parse(employeeEmployeeTypeVM.EmployeeTypeid)
>>>>>>> b91f36f85f748ef16088c8249afe1aa938eb57c2
            };
        }
    }
}

