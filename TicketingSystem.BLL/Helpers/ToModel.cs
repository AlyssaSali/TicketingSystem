﻿using System;
using System.Collections.Generic;
using System.Text;
using TicketingSystem.DAL.Models;
using TicketingSystem.ViewModel.ViewModels;

namespace TicketingSystem.BLL.Helpers
{
    public class ToModel
    {
        public Office Office(OfficeVM officeVM)
        {
            return new Office
            {
                Officeid = officeVM.Officeid,
                OfficeCode = officeVM.OfficeCode,
                OfficeDesc = officeVM.OfficeDesc,
            };
        }

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
                Severityid = severityVM.Severityid,
                SeverityName = severityVM.SeverityName,
                SeverityCode = severityVM.SeverityCode,
                SeverityDesc = severityVM.SeverityDesc
            };
        }

        public Employee Employee(EmployeeVM employeeVM)
        {
            return new Employee { 
                EmployeeID = employeeVM.EmployeeID,                
                FirstName = employeeVM.FirstName,
                LastName = employeeVM.LastName,
                EmailAddress = employeeVM.EmailAddress,
                Officeid = Guid.Parse(employeeVM.Officeid)
            };
        }

        public Ticket Ticket(TicketVM ticketVM)
        {
            return new Ticket
            {
                Ticketid = ticketVM.Ticketid,
                DateOfRequest = ticketVM.DateOfRequest,
                FormOfCommu = ticketVM.FormOfCommu,
                ContactInfo = ticketVM.ContactInfo,
                RequestTitle = ticketVM.RequestTitle,
                RequestDesc = ticketVM.RequestDesc,
                TrackingSatus = ticketVM.TrackingSatus,
                ResponseTime = ticketVM.ResponseTime,
                ResolveTime = ticketVM.ResolveTime,
                IsUrgent = ticketVM.IsUrgent,
                IsOpen = ticketVM.IsOpen,
            };
        }
        public ITGroup ITGroup(ITGroupVM itgroupVM)
        {
            return new ITGroup
            {
                ITGroupid = itgroupVM.ITGroupid,
                ITGroupCode = itgroupVM.ITGroupCode,
                ITGroupName = itgroupVM.ITGroupName
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
                Officeid = Guid.Parse(ticketMinorVM.Officeid),
                Requesterid = Guid.Parse(ticketMinorVM.Requesterid),
                WorkByid = Guid.Parse(ticketMinorVM.WorkByid),
                CategoryListid = Guid.Parse(ticketMinorVM.CategoryListid)
            };
        }

    }
}
