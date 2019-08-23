using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TicketingSystem.DAL.Models
{
    public class GroupEmployee
    {
        [Key]
        public Guid GroupEmployeeid { get; set; }

        [ForeignKey("Employee")]
        public Guid EmployeeID { get; set; }
        public Employee Employee { get; set; }
        public string EmployeeFullName { get; set; }
        [ForeignKey("ITGroupMember")]
        public Guid ITGroupMemberid { get; set; }
        public ITGroupMember ITGroupMember { get; set; }
       




        //[ForeignKey("ITGroup")]
        //public Guid ITGroupid { get; set; }
        //public ITGroup ITGroup { get; set; }


    }
}
