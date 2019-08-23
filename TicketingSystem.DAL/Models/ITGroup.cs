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
=======
        public virtual ICollection<CategoryList> CategoryLists { get; set; }
>>>>>>> 2fb85b2afa0a42a16fcb96d7ab04b103ede54f15

    }
}
