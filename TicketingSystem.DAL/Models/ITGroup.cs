using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TicketingSystem.DAL.Models
{
    public class ITGroup
    {
        [Key]
        public Guid ITGroupid { get; set; }
        public string ITGroupCode { get; set; }
        public string ITGroupName { get; set; }
        public virtual ICollection<ITGroupMember> ITGroupMembers { get; set; }
        public virtual ICollection<CategoryList> CategoryLists { get; set; }
    }
}
