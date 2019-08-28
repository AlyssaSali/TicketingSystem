using System;
using System.Collections.Generic;
using System.Text;

namespace TicketingSystem.ViewModel.ViewModels
{
    public class EmployeeEmployeeTypeVM
    {
        public string EmployeeEmployeeTypeid { get; set; }
        public string EmployeeTypeid { get; set; }
        public EmployeeTypeVM EmployeeType { get; set; }

        public List<EmployeeVM> Employees { get; set; }

        public IEnumerable<Guid> EmployeeIdList { get; set; }
    }
}
