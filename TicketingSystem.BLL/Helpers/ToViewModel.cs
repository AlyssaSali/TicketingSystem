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


        public CategoryVM Category(Category category)
        {
            return new CategoryVM
            {
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
                EmployeeTypeid = employee.EmployeeTypeid,
                EmployeeType = EmployeeType(employee.EmployeeType),
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
                EmployeeID = ticket.EmployeeID,
                Employee = Employee(ticket.Employee),
                Officeid = ticket.Officeid,
                Office = Office(ticket.Office),
                Date = ticket.DateOfRequest.ToShortDateString(),
                Time = ticket.DateOfRequest.ToShortTimeString(),
                RequestTitle = ticket.RequestTitle,
                RequestDesc = ticket.RequestDesc,
                RequestedBy = ticket.RequestedBy,
                TrackingStatus = ticket.TrackingStatus,
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
                ITGroup = categoryList.ITGroup != null ? ITGroup(categoryList.ITGroup) : null,
                Categoryid = (categoryList.Categoryid).ToString(),
                Category = categoryList.Category != null ? Category(categoryList.Category) : null,
                Severityid = (categoryList.Severityid).ToString(),
                Severity = categoryList.Severity != null ? Severity(categoryList.Severity) : null
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

