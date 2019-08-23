using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TicketingSystem.ViewModel.ViewModels
{
    public class ITGroupMemberVM
    {
       
        public string ITGroupMemberid { get; set; }
        public string ITGroupid { get; set; }
        public ITGroupVM ITGroup { get; set; }
        
        public List<EmployeeVM> Employees { get; set; }
     
        public IEnumerable<Guid> EmployeeIdList { get; set; }


    }
}
