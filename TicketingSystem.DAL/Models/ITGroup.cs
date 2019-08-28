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
<<<<<<< HEAD
        public virtual ICollection<ITGroupMember> ITGroupMembers { get; set; }
        public virtual ICollection<CategoryList> CategoryLists { get; set; }
=======
<<<<<<< HEAD
        public virtual ICollection<ITGroupMember> ITGroupMembers { get; set; }
        public virtual ICollection<CategoryList> CategoryLists { get; set; }
=======

        public virtual ICollection<ITGroupMember> ITGroupMembers { get; set; }

        public virtual ICollection<CategoryList> CategoryLists { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }

<<<<<<< HEAD
>>>>>>> 00d9a0867d956b23e7a3c0e36fce9ae308d939f7
        public virtual ICollection<Ticket> Tickets { get; set; }
>>>>>>> b91f36f85f748ef16088c8249afe1aa938eb57c2
    }
}
