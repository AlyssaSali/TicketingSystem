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

<<<<<<< HEAD
        public Category Category(CategoryVM categoryVM)
=======
        
        public CategoryVM Category(Category category)
>>>>>>> 63171424717892a87f2f85c43afeee8014c441ad
        {
            return new Category
            {
<<<<<<< HEAD
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
=======

                Categoryid = category.Categoryid,
                CategoryName = category.CategoryName,
                DateCreated = category.DateCreated
            };
        }

        public SeverityVM Severity(Severity severity)
        {

            return new SeverityVM
            {
<<<<<<< HEAD

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

=======
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
>>>>>>> 2fb85b2afa0a42a16fcb96d7ab04b103ede54f15
                EmployeeID = employee.EmployeeID,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                EmailAddress = employee.EmailAddress,
                Officeid = employee.Officeid.ToString(),
<<<<<<< HEAD
                Office = employee.Office != null ? Office(employee.Office): null,
                FullName = ToFullName(employee.FirstName, employee.LastName)

=======
                Office = Office(employee.Office),
                FullName = ToFullName(employee.FirstName, employee.LastName)
>>>>>>> 2fb85b2afa0a42a16fcb96d7ab04b103ede54f15
            };
        }
        public string ToFullName(string firstName, string lastName)
        {
            return $"{firstName} { (string.IsNullOrEmpty(lastName) ? "" : " " + lastName)} ";
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
<<<<<<< HEAD
                IsOpen = ticket.IsOpen,
                
=======
                IsOpen = ticket.IsOpen
>>>>>>> 2fb85b2afa0a42a16fcb96d7ab04b103ede54f15
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
=======

<<<<<<< HEAD
=======
<<<<<<< HEAD
        private List<EmployeeVM> GroupEmployee(List<GroupEmployee> groupEmployee)
        {
            List<EmployeeVM> employeeLists = new List<EmployeeVM>();
            if (groupEmployee != null)
            {
                foreach (var ge in groupEmployee)
                {
                    var employee = Employee(ge.Employee);
                    employeeLists.Add(employee);
                }
            }
            else
                employeeLists = null;

            return employeeLists;
        }
    

=======
>>>>>>> 63171424717892a87f2f85c43afeee8014c441ad
>>>>>>> 2fb85b2afa0a42a16fcb96d7ab04b103ede54f15
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

<<<<<<< HEAD
<<<<<<< HEAD
        public EmployeeTypeVM EmployeeType(EmployeeType employeetype)
        {
            return new EmployeeTypeVM
            {
                EmployeeTypeid = employeetype.EmployeeTypeid,
                EmployeeTypeName = employeetype.EmployeeTypeName
=======
        public ITGroupMemberVM ITGroupMember(ITGroupMember itgroupmember)

        {
            return new ITGroupMemberVM
            {

                ITGroupMemberid = itgroupmember.ITGroupMemberid.ToString(),
                
                ITGroupid = itgroupmember.ITGroupid.ToString(),
                ITGroup = ITGroup(itgroupmember.ITGroup),
                Employees = GroupEmployee(itgroupmember.GroupEmployees)
            };
        }


>>>>>>> 63171424717892a87f2f85c43afeee8014c441ad
=======
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
>>>>>>> 2fb85b2afa0a42a16fcb96d7ab04b103ede54f15
            };
        }
>>>>>>> 2fb85b2afa0a42a16fcb96d7ab04b103ede54f15
    }
}

