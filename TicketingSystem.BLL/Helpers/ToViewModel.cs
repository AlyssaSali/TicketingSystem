﻿using System;
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
=======
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

>>>>>>> 89bb63c04e1ad5424f19b0fd116240805a791ee4
                Categoryid = category.Categoryid,
                CategoryName = category.CategoryName,
                DateCreated = category.DateCreated
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
                //EmployeeTypeid = employee.EmployeeTypeid,
                //EmployeeType = employee.EmployeeType != null ? EmployeeType(employee.EmployeeType) : null,
                Officeid = employee.Officeid.ToString(),
                Office = employee.Office != null ? Office(employee.Office) : null,
                FullName = ToFullName(employee.FirstName, employee.LastName)

            };
        }

        public SeverityVM Severity(Severity severity)
        {

            return new SeverityVM
            {

                Severityid = severity.Severityid,
                SeverityCode = severity.SeverityCode,
                SeverityName = severity.SeverityName,
                SeverityDesc = severity.SeverityDesc
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
<<<<<<< HEAD
=======
<<<<<<< HEAD
=======

<<<<<<< HEAD
=======
<<<<<<< HEAD
>>>>>>> 89bb63c04e1ad5424f19b0fd116240805a791ee4
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

<<<<<<< HEAD
        private List<EmployeeVM> TypeEmployee(List<TypeEmployee> typeEmployees)
        {
            List<EmployeeVM> employeeLists = new List<EmployeeVM>();
            if (typeEmployees != null)
            {
                foreach (var te in typeEmployees)
                {
                    var employee = Employee(te.Employee);
                    employeeLists.Add(employee);
                }
            }
            else
                employeeLists = null;

            return employeeLists;
        }

=======
=======
>>>>>>> 63171424717892a87f2f85c43afeee8014c441ad
>>>>>>> 2fb85b2afa0a42a16fcb96d7ab04b103ede54f15
>>>>>>> 89bb63c04e1ad5424f19b0fd116240805a791ee4
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
=======
<<<<<<< HEAD
<<<<<<< HEAD
>>>>>>> 89bb63c04e1ad5424f19b0fd116240805a791ee4
        public EmployeeTypeVM EmployeeType(EmployeeType employeetype)
        {
            return new EmployeeTypeVM
            {
                EmployeeTypeid = employeetype.EmployeeTypeid,
                EmployeeTypeName = employeetype.EmployeeTypeName
<<<<<<< HEAD
            };
        }
=======
=======
>>>>>>> 89bb63c04e1ad5424f19b0fd116240805a791ee4
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
        public EmployeeEmployeeTypeVM EmployeeEmployeeType(EmployeeEmployeeType employeeEmployeeType)

        {
            return new EmployeeEmployeeTypeVM
            {

                EmployeeEmployeeTypeid = employeeEmployeeType.EmployeeEmployeeTypeid.ToString(),

<<<<<<< HEAD
                EmployeeTypeid = employeeEmployeeType.EmployeeTypeid.ToString(),
                EmployeeType = EmployeeType(employeeEmployeeType.EmployeeType),
                Employees = TypeEmployee(employeeEmployeeType.TypeEmployees)
            };
        }
=======
>>>>>>> 63171424717892a87f2f85c43afeee8014c441ad
=======
>>>>>>> 89bb63c04e1ad5424f19b0fd116240805a791ee4
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
        public UserVM User(User user)
        {
            return new UserVM
            {
                FirstName = user.FirstName,
                MiddleName = user.MiddleName,
                LastName = user.LastName,
                UserName=user.UserName
            };
        }
    }
}

