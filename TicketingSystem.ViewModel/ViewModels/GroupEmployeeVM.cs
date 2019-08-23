using System;
using System.Collections.Generic;
using System.Text;

namespace TicketingSystem.ViewModel.ViewModels
{
    public class GroupEmployeeVM
    {
        public string GroupEmployeeid { get; set; }

        public string ITGroupMemberid { get; set; }

        public ITGroupMemberVM ITGroupMember { get; set; }

        public string EmployeeID { get; set; }
        public EmployeeVM Employee { get; set; }

        public string EmployeeFullName { get; set; }
    }
}
