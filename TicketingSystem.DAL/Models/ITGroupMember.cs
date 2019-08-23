using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TicketingSystem.DAL.Models
{
    public class ITGroupMember
    {
        [Key]
        public Guid ITGroupMemberid { get; set; }
        [ForeignKey("ITGroup")]
        public Guid ITGroupid { get; set; }
        public ITGroup ITGroup { get; set; }


        public List<GroupEmployee> GroupEmployees { get; set; }
    }
}
